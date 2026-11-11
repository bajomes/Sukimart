using System.Globalization;

namespace Sukimart
{
    public partial class FormDashboardAdmin : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormDashboardAdmin()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            btnKasir.Click += btnKasir_Click;
            btnGudang.Click += btnGudang_Click;
            btnLaporan.Click += btnLaporan_Click;
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);

            SesuaikanPeran();

            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            IsiDashboard();
        }

        private void SesuaikanPeran()
        {
            if (Navigasi.PeranAktif == "gudang")
            {
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
                btnKatalog.Visible = true;
                lblJudul.Text = "Dashboard Gudang";
            }
            else if (Navigasi.PeranAktif == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnKasir.Visible = true;
                btnKatalog.Visible = true;
                btnRiwayat.Visible = true;
                lblJudul.Text = "Dashboard Kasir";
            }
            else
            {
                btnKasir.Visible = true;
                btnRiwayat.Visible = true;
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
                lblJudul.Text = "Dashboard Admin";
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;

            int jarak = 24;

            // Kolom kanan (Peringatan Stok & Kartu 3): lebar 32% (minimal 304px)
            int lebarKolomKanan = Math.Max(304, (int)(lebarTersedia * 0.32));
            int lebarKolomKiri = lebarTersedia - jarak - lebarKolomKanan;

            // Kolom kiri: Kartu 1 dan Kartu 2 membagi rata lebar kolom kiri
            int lebarKartuKiri = (lebarKolomKiri - jarak) / 2;
            pnlTransaksi.Location = new Point(margin, 112);
            pnlTransaksi.Size = new Size(lebarKartuKiri, 112);

            pnlTerjual.Location = new Point(margin + lebarKartuKiri + jarak, 112);
            pnlTerjual.Size = new Size(lebarKartuKiri, 112);

            // Kolom kanan: Kartu 3 mengikuti lebar kolom kanan
            int posXKanan = margin + lebarKolomKiri + jarak;
            pnlStok.Location = new Point(posXKanan, 112);
            pnlStok.Size = new Size(lebarKolomKanan, 112);

            // Tinggi area bawah
            int tinggiBawah = Math.Max(200, pnlKanan.ClientSize.Height - 320);

            // Tabel Transaksi Terbaru di kiri bawah
            lblTransaksiTerbaru.Location = new Point(margin, 248);
            dataGridView1.Location = new Point(margin, 280);
            dataGridView1.Size = new Size(lebarKolomKiri, tinggiBawah);

            // Panel Peringatan Stok di kanan bawah
            lblPeringatan.Location = new Point(posXKanan, 248);
            pnlPeringatan.Location = new Point(posXKanan, 280);
            pnlPeringatan.Size = new Size(lebarKolomKanan, tinggiBawah);

            lstStokMenipis.Location = new Point(20, 20);
            lstStokMenipis.Size = new Size(Math.Max(100, pnlPeringatan.ClientSize.Width - 40), Math.Max(100, pnlPeringatan.ClientSize.Height - 40));
        }

        private void IsiDashboard()
        {
            lblTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                List<Transaksi> daftarTransaksi = PenyimpananData.BacaTransaksi();
                List<Barang> daftarBarang = PenyimpananData.BacaBarang();

                List<Transaksi> transaksiHariIni = daftarTransaksi
                    .Where(transaksi => transaksi.Tanggal.Date == DateTime.Today)
                    .ToList();

                lblNilaiTransaksi.Text = HitungTransaksiHariIni(transaksiHariIni).ToString();
                lblNilaiPenjualan.Text = "Rp " + HitungPenjualanHariIni(transaksiHariIni)
                    .ToString("N0", BudayaIndonesia);

                IsiStokMenipis(daftarBarang);
                IsiTransaksiTerbaru(daftarTransaksi);
            }
            catch (Exception ex)
            {
                lblNilaiTransaksi.Text = "0";
                lblNilaiPenjualan.Text = "Rp 0";
                lblNilaiStok.Text = "0";
                lstStokMenipis.Items.Clear();
                dataGridView1.DataSource = null;

                MessageBox.Show(
                    "Data dashboard gagal dibaca. Pastikan file JSON tersedia dan formatnya benar.\n\n" + ex.Message,
                    "Kesalahan Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int HitungTransaksiHariIni(List<Transaksi> transaksiHariIni)
        {
            return transaksiHariIni.Count;
        }

        private int HitungPenjualanHariIni(List<Transaksi> transaksiHariIni)
        {
            return transaksiHariIni.Sum(transaksi => transaksi.Total);
        }

        private void IsiStokMenipis(List<Barang> daftarBarang)
        {
            lstStokMenipis.Items.Clear();

            foreach (Barang barang in daftarBarang)
            {
                if (barang.Stok <= barang.StokMinimum)
                {
                    lstStokMenipis.Items.Add(
                        barang.Nama + " (sisa " + barang.Stok + ")");
                }
            }

            lblNilaiStok.Text = lstStokMenipis.Items.Count.ToString();
        }

        private void IsiTransaksiTerbaru(List<Transaksi> daftarTransaksi)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.DataSource = daftarTransaksi
                .OrderByDescending(transaksi => transaksi.Tanggal)
                .Take(10)
                .Select(transaksi => new
                {
                    Nomor = transaksi.Id,
                    Tanggal = transaksi.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                    Kasir = transaksi.Kasir,
                    Total = "Rp " + transaksi.Total.ToString("N0", BudayaIndonesia)
                })
                .ToList();

            UIHelper.TerapkanWarnaGrid(dataGridView1);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.KeluarKeLogin(this);
        }

        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        private void btnKasir_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKasir(this);
        }

        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }
    }
}
