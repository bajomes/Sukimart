using System.Globalization;

namespace Sukimart
{
    /// <summary>
    /// FormDashboardKasir: Tampilan ringkasan metrik khusus untuk pengguna dengan peran Kasir.
    /// Menyajikan informasi transaksi hari ini, total barang yang terjual hari ini,
    /// indikator peringatan stok barang, dan riwayat transaksi terbaru.
    /// </summary>
    public partial class FormDashboardKasir : Form
    {
        // Format angka dan mata uang Indonesia (Rp x.xxx)
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormDashboardKasir()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            UIHelper.SusunTombolSidebar(pnlKiri);
            MaximizeBox = true;

            // Tangani event resize agar tata letak kartu dan tabel tetap proporsional
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            // Ambil dan tampilkan data metrik pada dashboard
            IsiDashboard();
        }

        // =========================================================================
        // PENGATURAN TATA LETAK RESPONSIF
        // =========================================================================

        /// <summary>
        /// Menata posisi 3 kartu ringkasan di baris atas dan tabel transaksi di bawahnya.
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
            int lebarKartu = (lebarTersedia - 2 * jarak) / 3;

            // Kartu 1: Transaksi Hari Ini
            pnlTransaksi.Location = new Point(margin, 112);
            pnlTransaksi.Size = new Size(lebarKartu, 112);

            // Kartu 2: Barang Terjual Hari Ini
            pnlTerjual.Location = new Point(margin + lebarKartu + jarak, 112);
            pnlTerjual.Size = new Size(lebarKartu, 112);

            // Kartu 3: Peringatan Stok
            pnlStok.Location = new Point(margin + 2 * (lebarKartu + jarak), 112);
            pnlStok.Size = new Size(lebarKartu, 112);

            // Tabel Transaksi Terbaru di bagian bawah
            int tinggiBawah = Math.Max(200, pnlKanan.ClientSize.Height - 320);
            dataGridView1.Location = new Point(margin, 280);
            dataGridView1.Size = new Size(lebarTersedia, tinggiBawah);
        }

        // =========================================================================
        // PENGAMBILAN & PENAMPILAN DATA DASHBOARD
        // =========================================================================

        /// <summary>
        /// Mengisi seluruh komponen data dashboard dari file JSON:
        /// transaksi hari ini, total barang terjual, peringatan stok, dan riwayat transaksi.
        /// </summary>
        private void IsiDashboard()
        {
            lblTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                // Baca data dari berkas JSON
                List<Transaksi> daftarTransaksi = PenyimpananData.BacaTransaksi();
                List<DetailTransaksi> daftarDetail = PenyimpananData.BacaDetailTransaksi();
                List<Barang> daftarBarang = PenyimpananData.BacaBarang();

                // 1. Tampilkan kartu Jumlah Transaksi Hari Ini
                lblNilaiTransaksi.Text = HitungTransaksiHariIni(daftarTransaksi).ToString();

                // 2. Tampilkan kartu Total Unit Barang Terjual Hari Ini
                lblNilaiTerjual.Text = HitungBarangTerjual(daftarDetail).ToString();
                lblNilaiTerjual.ForeColor = UIHelper.WarnaStatusAman;

                // 3. Tampilkan kartu Jumlah Barang Peringatan Stok (Habis / Minimum)
                lblNilaiStok.Text = HitungPeringatanStok(daftarBarang).ToString();
                lblNilaiStok.ForeColor = UIHelper.WarnaStatusHabis;

                // 4. Tampilkan 10 transaksi terbaru pada tabel
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

        /// <summary>
        /// Menghitung jumlah transaksi yang terjadi pada tanggal hari ini.
        /// </summary>
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

        /// <summary>
        /// Menghitung akumulasi total kuantitas barang yang terjual pada tanggal hari ini.
        /// </summary>
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

        /// <summary>
        /// Menghitung banyaknya jenis barang yang stoknya berada di bawah atau sama dengan stok minimum.
        /// </summary>
        private int HitungPeringatanStok(List<Barang> daftarBarang)
        {
            int jumlah = 0;
            foreach (Barang barang in daftarBarang)
            {
                if (barang.Aktif && barang.Stok <= barang.StokMinimum)
                {
                    jumlah++;
                }
            }
            return jumlah;
        }

        /// <summary>
        /// Mengisi tabel dengan 10 transaksi terbaru (diurutkan dari tanggal paling akhir).
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
                    Waktu = transaksi.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                    Total = "Rp " + transaksi.Total.ToString("N0", BudayaIndonesia)
                })
                .ToList();

            if (dataGridView1.Columns["Nomor"] is DataGridViewColumn colNomor)
            {
                colNomor.MinimumWidth = 175;
                colNomor.FillWeight = 135F;
            }
            if (dataGridView1.Columns["Waktu"] is DataGridViewColumn colWaktu)
            {
                colWaktu.MinimumWidth = 135;
                colWaktu.FillWeight = 110F;
            }

            UIHelper.TerapkanWarnaGrid(dataGridView1);
        }

        // =========================================================================
        // EVENT HANDLER TOMBOL NAVIGASI SIDEBAR
        // (Tersambung langsung dengan Designer via Event Click)
        // =========================================================================

        // Tetap di halaman dashboard
        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            // Sedang di form dashboard kasir
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

        // Membuka form Log Aktivitas sistem
        private void btnLogAktivitas_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLogAktivitas(this);
        }

        // Keluar dari sesi kasir (Logout)
        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }
    }
}
