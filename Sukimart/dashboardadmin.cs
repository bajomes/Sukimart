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
            lstStokMenipis.DrawMode = DrawMode.OwnerDrawFixed;
            lstStokMenipis.ItemHeight = 36;
            lstStokMenipis.IntegralHeight = false;
            lstStokMenipis.DrawItem += LstStokMenipis_DrawItem;
            btnKasir.Click += btnKasir_Click;
            btnGudang.Click += btnGudang_Click;
            btnLaporan.Click += btnLaporan_Click;
            btnLaporanInventaris.Click += (s, e) => Navigasi.BukaLaporanInventaris(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);

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
                btnLaporanInventaris.Visible = true;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
                btnKatalog.Visible = true;
                lblJudul.Text = "Dashboard Gudang";
            }
            else if (Navigasi.PeranAktif == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnLaporanInventaris.Visible = false;
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
                btnLaporanInventaris.Visible = true;
                btnPengguna.Visible = true;
                lblJudul.Text = "Dashboard Admin";
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        private void AturTataLetakResponsif()
        {
            if (nightControlBox1 != null)
            {
                nightControlBox1.Location = new Point(pnlKanan.ClientSize.Width - nightControlBox1.Width, 0);
                nightControlBox1.BringToFront();
            }

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

            lstStokMenipis.Location = new Point(16, 16);
            lstStokMenipis.Size = new Size(Math.Max(100, pnlPeringatan.ClientSize.Width - 32), Math.Max(100, pnlPeringatan.ClientSize.Height - 32));
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
                lblNilaiPenjualan.ForeColor = UIHelper.WarnaStatusAman;
                lblNilaiStok.ForeColor = UIHelper.WarnaStatusHabis;

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

            var peringatan = daftarBarang
                .Where(b => b.Aktif && b.Stok <= b.StokMinimum)
                .OrderBy(b => b.Stok <= 0 ? 0 : 1)
                .ThenBy(b => b.Stok)
                .ThenBy(b => b.Nama)
                .ToList();

            foreach (Barang barang in peringatan)
            {
                lstStokMenipis.Items.Add(barang);
            }

            lblNilaiStok.Text = lstStokMenipis.Items.Count.ToString();
        }

        private void LstStokMenipis_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstStokMenipis.Items.Count) return;

            e.DrawBackground();
            if (lstStokMenipis.Items[e.Index] is not Barang barang) return;

            string status = UIHelper.TentukanStatusStok(barang.Stok, barang.StokMinimum);
            var (fore, back, border) = UIHelper.WarnaStatusStok(status);

            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;

            using (SolidBrush brBg = new SolidBrush(lstStokMenipis.BackColor))
            {
                g.FillRectangle(brBg, bounds);
            }

            Rectangle rectBadge = new Rectangle(bounds.X + 4, bounds.Y + (bounds.Height - 22) / 2, 72, 22);
            using (SolidBrush brBadge = new SolidBrush(back))
            using (Pen penBadge = new Pen(border))
            {
                g.FillRectangle(brBadge, rectBadge);
                g.DrawRectangle(penBadge, rectBadge.X, rectBadge.Y, rectBadge.Width - 1, rectBadge.Height - 1);
            }

            using Font fontBadge = FontInter.Buat(8F, FontStyle.Bold);
            TextRenderer.DrawText(g, status, fontBadge, rectBadge, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            string infoStok = $"Stok: {barang.Stok} / Min: {barang.StokMinimum}";
            using Font fontInfo = FontInter.Buat(8.5F, FontStyle.Regular);
            Size ukuranInfo = TextRenderer.MeasureText(g, infoStok, fontInfo);
            int lebarInfo = Math.Min(ukuranInfo.Width + 4, Math.Max(80, bounds.Width / 3));

            Rectangle rectInfo = new Rectangle(bounds.Right - lebarInfo - 4, bounds.Y, lebarInfo, bounds.Height);
            TextRenderer.DrawText(g, infoStok, fontInfo, rectInfo, UIHelper.WarnaTeksSekunder,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            int xNama = rectBadge.Right + 8;
            int lebarNama = Math.Max(40, rectInfo.Left - xNama - 6);
            Rectangle rectNama = new Rectangle(xNama, bounds.Y, lebarNama, bounds.Height);
            using Font fontNama = FontInter.Buat(9F, FontStyle.Bold);
            TextRenderer.DrawText(g, $"{barang.Kode} · {barang.Nama}", fontNama, rectNama, UIHelper.WarnaTeksUtama,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            using Pen penGaris = new Pen(UIHelper.WarnaGarisTepi);
            g.DrawLine(penGaris, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
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

            if (dataGridView1.Columns["Nomor"] is DataGridViewColumn colNomor)
            {
                colNomor.MinimumWidth = 175;
                colNomor.FillWeight = 135F;
            }
            if (dataGridView1.Columns["Tanggal"] is DataGridViewColumn colTgl)
            {
                colTgl.MinimumWidth = 130;
                colTgl.FillWeight = 110F;
            }

            UIHelper.TerapkanWarnaGrid(dataGridView1);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
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
