using System.Globalization;

namespace Sukimart
{
    public partial class FormDashboardKasir : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormDashboardKasir()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += btnKatalog_Click;
            btnRiwayat.Click += btnRiwayat_Click;

            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            IsiDashboard();
        }

        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;

            int jarak = 24;
            int lebarKartu = (lebarTersedia - 2 * jarak) / 3;

            pnlTransaksi.Location = new Point(margin, 112);
            pnlTransaksi.Size = new Size(lebarKartu, 112);

            pnlTerjual.Location = new Point(margin + lebarKartu + jarak, 112);
            pnlTerjual.Size = new Size(lebarKartu, 112);

            pnlStok.Location = new Point(margin + 2 * (lebarKartu + jarak), 112);
            pnlStok.Size = new Size(lebarKartu, 112);

            int tinggiBawah = Math.Max(200, pnlKanan.ClientSize.Height - 320);
            dataGridView1.Location = new Point(margin, 280);
            dataGridView1.Size = new Size(lebarTersedia, tinggiBawah);
        }

        private void IsiDashboard()
        {
            lblTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                List<Transaksi> daftarTransaksi = PenyimpananData.BacaTransaksi();
                List<DetailTransaksi> daftarDetail = PenyimpananData.BacaDetailTransaksi();
                List<Barang> daftarBarang = PenyimpananData.BacaBarang();

                lblNilaiTransaksi.Text = HitungTransaksiHariIni(daftarTransaksi).ToString();
                lblNilaiTerjual.Text = HitungBarangTerjual(daftarDetail).ToString();
                lblNilaiStok.Text = HitungStokMenipis(daftarBarang).ToString();

                IsiTransaksiTerbaru(daftarTransaksi);
            }
            catch (Exception ex)
            {
                lblNilaiTransaksi.Text = "0";
                lblNilaiTerjual.Text = "0";
                lblNilaiStok.Text = "0";
                dataGridView1.DataSource = null;

                MessageBox.Show(
                    "Dashboard gagal membaca data JSON. Periksa file data dan coba lagi.\n\n" + ex.Message,
                    "Kesalahan Membaca Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int HitungTransaksiHariIni(List<Transaksi> daftarTransaksi)
        {
            int jumlah = 0;

            foreach (Transaksi transaksi in daftarTransaksi)
            {
                if (transaksi.Tanggal.Date == DateTime.Today)
                {
                    jumlah++;
                }
            }

            return jumlah;
        }

        private int HitungBarangTerjual(List<DetailTransaksi> daftarDetail)
        {
            int total = 0;

            foreach (DetailTransaksi detail in daftarDetail)
            {
                if (detail.Tanggal.Date == DateTime.Today)
                {
                    total += detail.Jumlah;
                }
            }

            return total;
        }

        private int HitungStokMenipis(List<Barang> daftarBarang)
        {
            int jumlah = 0;

            foreach (Barang barang in daftarBarang)
            {
                if (barang.Stok <= barang.StokMinimum)
                {
                    jumlah++;
                }
            }

            return jumlah;
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
                    Waktu = transaksi.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                    Total = "Rp " + transaksi.Total.ToString("N0", BudayaIndonesia)
                })
                .ToList();

            UIHelper.TerapkanWarnaGrid(dataGridView1);
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
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
    }
}
