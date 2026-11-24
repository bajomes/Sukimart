using System.Globalization;

namespace Sukimart
{
    /// <summary>
    /// FormDashboardAdmin: Tampilan utama setelah login untuk Administrator.
    /// Menyajikan ringkasan statistik: jumlah transaksi hari ini, total omzet hari ini,
    /// indikator stok menipis/habis, tabel 10 transaksi terbaru, dan peringatan stok.
    /// </summary>
    public partial class FormDashboardAdmin : Form
    {
        // Format angka dan mata uang Indonesia (Rp x.xxx)
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormDashboardAdmin()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;

            // Sesuaikan menu sidebar berdasarkan hak akses peran pengguna
            SesuaikanPeran();

            // Tangani event resize agar tampilan dashboard tetap proporsional
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            // Ambil dan tampilkan seluruh data metrik dashboard
            IsiDashboard();
        }

        // =========================================================================
        // PENGATURAN TATA LETAK & HAK AKSES PERAN
        // =========================================================================

        /// <summary>
        /// Menyesuaikan tombol sidebar dan judul dashboard sesuai peran pengguna saat ini.
        /// </summary>
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
                // Default Admin: Semua menu aktif
                btnKasir.Visible = true;
                btnRiwayat.Visible = true;
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
                lblJudul.Text = "Dashboard Admin";
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        /// <summary>
        /// Menata posisi kartu ringkasan, tabel transaksi, dan panel peringatan stok.
        /// </summary>
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

            // Area bawah
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

        // =========================================================================
        // PENGAMBILAN & PENAMPILAN DATA DASHBOARD
        // =========================================================================

        /// <summary>
        /// Mengisi seluruh komponen dashboard dari file data JSON:
        /// menghitung transaksi hari ini, omzet hari ini, stok menipis, dan riwayat transaksi terbaru.
        /// </summary>
        private void IsiDashboard()
        {
            lblTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                // Baca data dari file transaksi.json dan barang.json
                List<Transaksi> daftarTransaksi = PenyimpananData.BacaTransaksi();
                List<Barang> daftarBarang = PenyimpananData.BacaBarang();

                // Filter transaksi yang tanggalnya sama dengan hari ini
                List<Transaksi> transaksiHariIni = daftarTransaksi
                    .Where(transaksi => transaksi.Tanggal.Date == DateTime.Today)
                    .ToList();

                // 1. Tampilkan kartu Jumlah Transaksi Hari Ini
                lblNilaiTransaksi.Text = HitungTransaksiHariIni(transaksiHariIni).ToString();

                // 2. Tampilkan kartu Total Penjualan (Omzet) Hari Ini
                lblNilaiPenjualan.Text = "Rp " + HitungPenjualanHariIni(transaksiHariIni)
                    .ToString("N0", BudayaIndonesia);

                // 3. Tampilkan peringatan barang stok menipis/habis
                IsiStokMenipis(daftarBarang);

                // 4. Tampilkan 10 transaksi terbaru pada tabel
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

        /// <summary>
        /// Menghitung total banyaknya transaksi yang terjadi hari ini.
        /// </summary>
        private int HitungTransaksiHariIni(List<Transaksi> transaksiHariIni)
        {
            return transaksiHariIni.Count;
        }

        /// <summary>
        /// Menghitung total nominal omzet penjualan hari ini.
        /// </summary>
        private int HitungPenjualanHariIni(List<Transaksi> transaksiHariIni)
        {
            return transaksiHariIni.Sum(transaksi => transaksi.Total);
        }

        /// <summary>
        /// Memeriksa seluruh barang: jika stok <= stok minimum, masukkan ke daftar peringatan stok.
        /// </summary>
        private void IsiStokMenipis(List<Barang> daftarBarang)
        {
            lstStokMenipis.Items.Clear();

            foreach (Barang barang in daftarBarang)
            {
                if (barang.Stok <= barang.StokMinimum)
                {
                    string status = barang.Stok == 0 ? "HABIS" : $"sisa {barang.Stok}";
                    lstStokMenipis.Items.Add($"{barang.Nama} ({status})");
                }
            }

            // Angka badge peringatan stok
            lblNilaiStok.Text = lstStokMenipis.Items.Count.ToString();

            // Jika tidak ada barang menipis
            if (lstStokMenipis.Items.Count == 0)
            {
                lstStokMenipis.Items.Add("✅ Semua stok dalam batas aman");
            }
        }

        /// <summary>
        /// Mengisi tabel 10 transaksi terbaru (diurutkan dari waktu paling baru).
        /// </summary>
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

            // Atur proporsi lebar kolom tabel
            if (dataGridView1.Columns.Contains("Nomor"))
                dataGridView1.Columns["Nomor"].FillWeight = 170F;
            if (dataGridView1.Columns.Contains("Tanggal"))
                dataGridView1.Columns["Tanggal"].FillWeight = 115F;
            if (dataGridView1.Columns.Contains("Kasir"))
                dataGridView1.Columns["Kasir"].FillWeight = 75F;
            if (dataGridView1.Columns.Contains("Total"))
                dataGridView1.Columns["Total"].FillWeight = 90F;
        }

        // =========================================================================
        // EVENT HANDLER TOMBOL NAVIGASI SIDEBAR
        // (Tersambung langsung dengan Designer via Event Click)
        // =========================================================================

        // Tetap di halaman dashboard
        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            // Sedang di form dashboard
        }

        // Membuka form Kasir / POS
        private void btnKasir_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKasir(this);
        }

        // Membuka form Katalog Produk
        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        // Membuka form Riwayat Transaksi
        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        // Membuka form Gudang
        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        // Membuka form Laporan
        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }

        // Membuka form Manajemen Pengguna
        private void btnPengguna_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaPengguna(this);
        }

        // Membuka form Log Aktivitas sistem
        private void btnLogAktivitas_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLogAktivitas(this);
        }

        // Tombol Keluar / Logout
        private void btnKeluarBenar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }
    }
}
