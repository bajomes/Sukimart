using System.Globalization;

namespace Sukimart
{
    /// <summary>
    /// FormLaporan: Formulir untuk melihat laporan penjualan, analisis laba per produk,
    /// serta laporan mutasi stok dan inventaris gudang.
    /// Dilengkapi dengan filter rentang tanggal, kartu ringkasan omzet/transaksi/laba,
    /// dan kemampuan ekspor laporan ke berkas format JSON.
    /// </summary>
    public partial class FormLaporan : Form
    {
        // Format mata uang dan angka sesuai standar Indonesia (titik ribuan, koma desimal)
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        // Menyimpan peran pengguna yang sedang login (admin atau gudang)
        private readonly string peran;

        // Data transaksi dan detail item transaksi yang dimuat dari file JSON
        private List<Transaksi> semuaTransaksi = new List<Transaksi>();
        private List<DetailTransaksi> semuaDetail = new List<DetailTransaksi>();

        // Status mode laporan saat ini: "penjualan" atau "gudang"
        private string jenisLaporan = "penjualan";

        // Sub-jenis laporan penjualan: "transaksi" atau "laba"
        private string subJenisPenjualan = "transaksi";

        // Daftar data laba per produk untuk pengurutan kolom interaktif
        private List<ItemLabaProduk> daftarLabaSaatIni = new List<ItemLabaProduk>();
        private string kolomUrutLaba = "LabaKotor";
        private SortOrder urutanSortLaba = SortOrder.Descending;

        public FormLaporan() : this("admin") { }

        public FormLaporan(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;

            // Jika peran gudang, otomatis buka laporan inventaris gudang
            if (this.peran == "gudang")
            {
                jenisLaporan = "gudang";
            }

            gridLaporan.AllowUserToResizeRows = false;
            gridLaba.AllowUserToResizeRows = false;

            // Sembunyikan tombol filter lama
            btnHariIni.Visible = false;
            btnBulanIni.Visible = false;
            btnSemuaWaktu.Visible = false;

            // Atur rentang tanggal default: 30 hari ke belakang sampai hari ini
            dtpMulai.Value = DateTime.Today.AddDays(-30);
            dtpSelesai.Value = DateTime.Today;

            // Sesuaikan tampilan sidebar berdasarkan hak akses peran
            SesuaikanPeran();

            // Tangani event resize panel dengan metode bernama eksplisit (bebas lambda)
            pnlKanan.Resize += pnlKanan_Resize;
            AturTataLetakResponsif();

            // Muat data dari file transaksi.json dan detail_transaksi.json
            MuatDataLaporan();
        }

        // Event handler resize panel kanan
        private void pnlKanan_Resize(object? sender, EventArgs e)
        {
            AturTataLetakResponsif();
        }

        // =========================================================================
        // PENGATURAN TATA LETAK & HAK AKSES PERAN
        // =========================================================================

        /// <summary>
        /// Menyesuaikan tata letak kartu ringkasan, tombol filter, dan tabel secara proporsional.
        /// </summary>
        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;

            int jarak = 20;
            int lebarKartu = (lebarTersedia - 3 * jarak) / 4;

            // 1. Empat Kartu KPI
            pnlCard1.Location = new Point(margin, 112);
            pnlCard1.Size = new Size(lebarKartu, 112);

            pnlCard2.Location = new Point(margin + lebarKartu + jarak, 112);
            pnlCard2.Size = new Size(lebarKartu, 112);

            pnlCard3.Location = new Point(margin + 2 * (lebarKartu + jarak), 112);
            pnlCard3.Size = new Size(lebarKartu, 112);

            pnlCard4.Location = new Point(margin + 3 * (lebarKartu + jarak), 112);
            pnlCard4.Size = new Size(lebarKartu, 112);

            // 2. Baris Filter & Mode Laporan
            bool isPenjualan = jenisLaporan == "penjualan";
            bool isLaba = isPenjualan && subJenisPenjualan == "laba";

            btnSubTransaksi.Visible = isPenjualan;
            btnSubLaba.Visible = isPenjualan;

            if (isPenjualan)
            {
                btnPenjualan.Location = new Point(margin, 248);
                btnGudangReport.Location = new Point(margin + 116, 248);

                btnSubTransaksi.Location = new Point(margin + 264, 248);
                btnSubLaba.Location = new Point(margin + 364, 248);

                dtpMulai.Location = new Point(margin + 446, 252);
                dtpSelesai.Location = new Point(margin + 570, 252);
                btnTerapkanTanggal.Location = new Point(margin + 694, 248);
                btnSimpanJson.Location = new Point(margin + 802, 248);
            }
            else
            {
                btnPenjualan.Location = new Point(margin, 248);
                btnGudangReport.Location = new Point(margin + 116, 248);

                dtpMulai.Location = new Point(margin + 264, 252);
                dtpSelesai.Location = new Point(margin + 388, 252);
                btnTerapkanTanggal.Location = new Point(margin + 512, 248);
                btnSimpanJson.Location = new Point(margin + 620, 248);
            }

            lblRingkasan.Location = new Point(margin, 292);
            lblRingkasan.Size = new Size(lebarTersedia, 42);

            // 3. Grid Laporan & Panel Total Laba
            int yGrid = 344;
            int tinggiTotal = 48;
            int tinggiTersedia = Math.Max(180, pnlKanan.ClientSize.Height - yGrid - 40);

            if (isLaba)
            {
                int tinggiGridLaba = tinggiTersedia - tinggiTotal - 8;
                gridLaba.Location = new Point(margin, yGrid);
                gridLaba.Size = new Size(lebarTersedia, tinggiGridLaba);
                gridLaba.Visible = true;
                gridLaporan.Visible = false;

                pnlTotalLaba.Location = new Point(margin, yGrid + tinggiGridLaba + 8);
                pnlTotalLaba.Size = new Size(lebarTersedia, tinggiTotal);
                pnlTotalLaba.Visible = true;
            }
            else
            {
                gridLaporan.Location = new Point(margin, yGrid);
                gridLaporan.Size = new Size(lebarTersedia, tinggiTersedia);
                gridLaporan.Visible = true;
                gridLaba.Visible = false;
                pnlTotalLaba.Visible = false;
            }
        }

        /// <summary>
        /// Menyesuaikan tombol navigasi yang boleh diakses berdasarkan peran pengguna.
        /// </summary>
        private void SesuaikanPeran()
        {
            bool admin = peran == "admin";
            btnGudang.Visible = admin;
            btnLaporan.Visible = admin;
            btnPengguna.Visible = admin;
            btnLogAktivitas.Visible = admin;
            btnPenjualan.Visible = admin;
            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        /// <summary>
        /// Mengatur gaya visual tombol mode laporan (aktif = warna emas, tidak aktif = putih).
        /// </summary>
        private static void AturTombolMode(Button tombol, string teks, Point lokasi, bool aktif, int lebar)
        {
            tombol.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
            tombol.Cursor = Cursors.Hand;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            tombol.FlatAppearance.BorderSize = aktif ? 0 : 1;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.Font = new Font("Inter", 10F, aktif ? FontStyle.Bold : FontStyle.Regular);
            tombol.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            tombol.Location = lokasi;
            tombol.Size = new Size(lebar, 32);
            tombol.Text = teks;
        }

        // Mengatur gaya visual tombol sub-tab Transaksi / Laba
        private static void AturTombolSub(Button tombol, string teks, bool aktif)
        {
            tombol.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
            tombol.Cursor = Cursors.Hand;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            tombol.FlatAppearance.BorderSize = aktif ? 0 : 1;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.Font = new Font("Inter", 9.5F, aktif ? FontStyle.Bold : FontStyle.Regular);
            tombol.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            tombol.Text = teks;
        }

        // =========================================================================
        // EVENT HANDLER TOMBOL NAVIGASI SIDEBAR
        // (Tersambung langsung dengan Designer via Event Click)
        // =========================================================================

        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaDashboard(this);
        }

        private void btnKasir_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKasir(this);
        }

        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        private void btnPengguna_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaPengguna(this);
        }

        // Membuka form Log Aktivitas sistem
        private void btnLogAktivitas_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLogAktivitas(this);
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }

        // =========================================================================
        // EVENT HANDLER FILTER & AKSI LAPORAN
        // =========================================================================

        private void btnPenjualan_Click(object? sender, EventArgs e)
        {
            UbahJenisLaporan("penjualan");
        }

        private void btnGudangReport_Click(object? sender, EventArgs e)
        {
            UbahJenisLaporan("gudang");
        }

        private void btnSubTransaksi_Click(object? sender, EventArgs e)
        {
            UbahSubJenisPenjualan("transaksi");
        }

        private void btnSubLaba_Click(object? sender, EventArgs e)
        {
            UbahSubJenisPenjualan("laba");
        }

        private void btnTerapkanTanggal_Click(object? sender, EventArgs e)
        {
            TerapkanLaporan();
        }

        private void btnSimpanJson_Click(object? sender, EventArgs e)
        {
            SimpanLaporanKeJson();
        }

        private void btnHariIni_Click(object? sender, EventArgs e)
        {
            AturTanggal(DateTime.Today, DateTime.Today);
        }

        private void btnBulanIni_Click(object? sender, EventArgs e)
        {
            AturTanggal(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Today);
        }

        private void btnSemuaWaktu_Click(object? sender, EventArgs e)
        {
            AturTanggal(DateTime.Today.AddYears(-10), DateTime.Today);
        }

        // =========================================================================
        // LOGIKA PENGOLAHAN DATA LAPORAN
        // =========================================================================

        /// <summary>
        /// Memuat data transaksi dan rincian transaksi dari penyimpanan JSON.
        /// </summary>
        public void MuatDataLaporan()
        {
            try
            {
                semuaTransaksi = PenyimpananData.BacaTransaksi();
                semuaDetail = PenyimpananData.BacaDetailTransaksi();
                TerapkanLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data laporan: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AturTanggal(DateTime mulai, DateTime selesai)
        {
            dtpMulai.Value = mulai;
            dtpSelesai.Value = selesai;
            TerapkanLaporan();
        }

        private void UbahJenisLaporan(string jenis)
        {
            jenisLaporan = jenis;
            AturTombolMode(btnPenjualan, "Penjualan", btnPenjualan.Location, jenis == "penjualan", 110);
            AturTombolMode(btnGudangReport, "Inventaris Gudang", btnGudangReport.Location, jenis == "gudang", 142);
            AturTataLetakResponsif();
            TerapkanLaporan();
        }

        private void UbahSubJenisPenjualan(string subJenis)
        {
            subJenisPenjualan = subJenis;
            AturTombolSub(btnSubTransaksi, "Transaksi", subJenis == "transaksi");
            AturTombolSub(btnSubLaba, "Laba", subJenis == "laba");
            AturTataLetakResponsif();
            TerapkanLaporan();
        }

        /// <summary>
        /// Memvalidasi tanggal dan menerapkan filter laporan sesuai mode yang dipilih.
        /// </summary>
        private void TerapkanLaporan()
        {
            if (dtpMulai.Value.Date > dtpSelesai.Value.Date)
            {
                MessageBox.Show("Tanggal mulai tidak boleh setelah tanggal selesai.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlKanan.SuspendLayout();
            try
            {
                if (jenisLaporan == "gudang")
                {
                    TerapkanLaporanGudang();
                }
                else
                {
                    if (subJenisPenjualan == "laba")
                    {
                        TerapkanLaporanLaba();
                    }
                    else
                    {
                        TerapkanLaporanPenjualan();
                    }
                }
            }
            finally
            {
                pnlKanan.ResumeLayout();
            }
        }

        /// <summary>
        /// Menghitung statistik penjualan (omzet, transaksi, item) dan menampilkan ke tabel transaksi.
        /// </summary>
        private void TerapkanLaporanPenjualan()
        {
            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);

            List<Transaksi> transaksi = semuaTransaksi
                .Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai)
                .ToList();

            HashSet<string> idTransaksi = transaksi.Select(data => data.Id).ToHashSet();
            List<DetailTransaksi> detail = semuaDetail
                .Where(data => idTransaksi.Contains(data.IdTransaksi))
                .ToList();

            int totalOmzet = transaksi.Sum(data => data.Total);
            int totalTransaksi = transaksi.Count;
            int totalItem = detail.Sum(data => data.Jumlah);
            int rataRata = totalTransaksi > 0 ? totalOmzet / totalTransaksi : 0;

            lblJudul.Text = "Laporan Penjualan";
            lblCard1Judul.Text = "Total Pendapatan";
            lblCard2Judul.Text = "Jumlah Transaksi";
            lblCard3Judul.Text = "Item Terjual";
            lblCard4Judul.Text = "Rata-rata Transaksi";

            lblOmzetNilai.Text = "Rp " + totalOmzet.ToString("N0", BudayaIndonesia);
            lblOmzetNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblTrxNilai.Text = totalTransaksi.ToString("N0", BudayaIndonesia);
            lblTrxNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblItemTerjualNilai.Text = totalItem.ToString("N0", BudayaIndonesia);
            lblItemTerjualNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblRataNilai.Text = "Rp " + rataRata.ToString("N0", BudayaIndonesia);
            lblRataNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblRingkasan.Text = BuatRingkasanPenjualan(transaksi, detail);

            AturKolomLaporan();
            gridLaporan.DataSource = transaksi
                .OrderByDescending(data => data.Tanggal)
                .Select(data => new
                {
                    Faktur = data.Id,
                    Waktu = data.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                    data.Kasir,
                    Item = detail.Where(rincian => rincian.IdTransaksi == data.Id).Sum(rincian => rincian.Jumlah),
                    Total = "Rp " + data.Total.ToString("N0", BudayaIndonesia)
                })
                .ToList();

            if (gridLaporan.Columns.Contains("Faktur"))
                gridLaporan.Columns["Faktur"].FillWeight = 175F;
            if (gridLaporan.Columns.Contains("Waktu"))
                gridLaporan.Columns["Waktu"].FillWeight = 110F;
            if (gridLaporan.Columns.Contains("Kasir"))
                gridLaporan.Columns["Kasir"].FillWeight = 75F;
        }

        /// <summary>
        /// Menghitung analisis laba per produk berdasarkan harga beli dan harga jual saat transaksi dilakukan.
        /// </summary>
        private void TerapkanLaporanLaba()
        {
            lblJudul.Text = "Analisis Laba Penjualan";
            lblCard1Judul.Text = "TOTAL PENDAPATAN";
            lblCard2Judul.Text = "TOTAL MODAL";
            lblCard3Judul.Text = "LABA KOTOR";
            lblCard4Judul.Text = "MARGIN LABA";

            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);

            List<Transaksi> transaksi = semuaTransaksi.Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai).ToList();
            HashSet<string> idTransaksi = transaksi.Select(data => data.Id).ToHashSet();
            List<DetailTransaksi> detail = semuaDetail.Where(data => idTransaksi.Contains(data.IdTransaksi)).ToList();

            var rincianProduk = detail
                .GroupBy(d => new { d.KodeBarang, d.NamaBarang })
                .Select(g =>
                {
                    int terjual = g.Sum(x => x.Jumlah);
                    long pendapatan = g.Sum(x => (long)x.HargaSatuan * x.Jumlah);
                    long totalModal = g.Sum(x => (long)x.HargaBeli * x.Jumlah);
                    long labaKotor = pendapatan - totalModal;

                    return new ItemLabaProduk
                    {
                        Kode = g.Key.KodeBarang,
                        Nama = g.Key.NamaBarang,
                        Terjual = terjual.ToString("N0", BudayaIndonesia),
                        Pendapatan = "Rp " + pendapatan.ToString("N0", BudayaIndonesia),
                        TotalModal = "Rp " + totalModal.ToString("N0", BudayaIndonesia),
                        LabaKotor = "Rp " + labaKotor.ToString("N0", BudayaIndonesia),
                        RawTerjual = terjual,
                        RawPendapatan = pendapatan,
                        RawModal = totalModal,
                        RawLaba = labaKotor
                    };
                })
                .ToList();

            long totalPendapatan = rincianProduk.Sum(x => x.RawPendapatan);
            long totalModal = rincianProduk.Sum(x => x.RawModal);
            long totalLabaKotor = totalPendapatan - totalModal;
            int totalTerjual = rincianProduk.Sum(x => x.RawTerjual);

            // Perbarui 4 Kartu KPI
            lblOmzetNilai.Text = "Rp " + totalPendapatan.ToString("N0", BudayaIndonesia);
            lblOmzetNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblTrxNilai.Text = "Rp " + totalModal.ToString("N0", BudayaIndonesia);
            lblTrxNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblItemTerjualNilai.Text = "Rp " + totalLabaKotor.ToString("N0", BudayaIndonesia);
            lblItemTerjualNilai.ForeColor = Color.FromArgb(16, 149, 102);

            if (totalPendapatan > 0)
            {
                double margin = ((double)totalLabaKotor / totalPendapatan) * 100.0;
                lblRataNilai.Text = margin.ToString("0.0", BudayaIndonesia) + "%";
            }
            else
            {
                lblRataNilai.Text = "0,0%";
            }
            lblRataNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblRingkasan.Text = $"Laba kotor dihitung dari (harga jual saat transaksi − harga beli saat transaksi) × jumlah terjual. Periode: {mulai:dd/MM/yyyy} s/d {dtpSelesai.Value:dd/MM/yyyy}.";

            // Update Ringkasan Total di Bawah DataGridView
            lblTotalTerjualNilai.Text = totalTerjual.ToString("N0", BudayaIndonesia);
            lblTotalPendapatanNilai.Text = "Rp " + totalPendapatan.ToString("N0", BudayaIndonesia);
            lblTotalModalNilai.Text = "Rp " + totalModal.ToString("N0", BudayaIndonesia);
            lblTotalLabaNilai.Text = "Rp " + totalLabaKotor.ToString("N0", BudayaIndonesia);

            daftarLabaSaatIni = rincianProduk;
            UrutkanDanTampilkanDataLaba();
        }

        // Pengurutan kolom interaktif pada grid laba
        private void gridLaba_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= gridLaba.Columns.Count) return;
            if (daftarLabaSaatIni == null || daftarLabaSaatIni.Count == 0) return;

            var kolom = gridLaba.Columns[e.ColumnIndex];
            if (kolom == colLabaKotor)
            {
                kolomUrutLaba = "LabaKotor";
                urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (kolom == colLabaPendapatan)
            {
                kolomUrutLaba = "Pendapatan";
                urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (kolom == colLabaModal)
            {
                kolomUrutLaba = "TotalModal";
                urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (kolom == colLabaTerjual)
            {
                kolomUrutLaba = "Terjual";
                urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (kolom == colLabaNama)
            {
                kolomUrutLaba = "Nama";
                urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else if (kolom == colLabaKode)
            {
                kolomUrutLaba = "Kode";
                urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }

            UrutkanDanTampilkanDataLaba();
        }

        private void UrutkanDanTampilkanDataLaba()
        {
            if (daftarLabaSaatIni == null || daftarLabaSaatIni.Count == 0) return;

            IEnumerable<ItemLabaProduk> terurut;
            switch (kolomUrutLaba)
            {
                case "LabaKotor":
                    terurut = (urutanSortLaba == SortOrder.Ascending)
                        ? daftarLabaSaatIni.OrderBy(x => x.RawLaba).ThenBy(x => x.Kode)
                        : daftarLabaSaatIni.OrderByDescending(x => x.RawLaba).ThenBy(x => x.Kode);
                    break;
                case "Pendapatan":
                    terurut = (urutanSortLaba == SortOrder.Ascending)
                        ? daftarLabaSaatIni.OrderBy(x => x.RawPendapatan)
                        : daftarLabaSaatIni.OrderByDescending(x => x.RawPendapatan);
                    break;
                case "TotalModal":
                    terurut = (urutanSortLaba == SortOrder.Ascending)
                        ? daftarLabaSaatIni.OrderBy(x => x.RawModal)
                        : daftarLabaSaatIni.OrderByDescending(x => x.RawModal);
                    break;
                case "Terjual":
                    terurut = (urutanSortLaba == SortOrder.Ascending)
                        ? daftarLabaSaatIni.OrderBy(x => x.RawTerjual)
                        : daftarLabaSaatIni.OrderByDescending(x => x.RawTerjual);
                    break;
                case "Nama":
                    terurut = (urutanSortLaba == SortOrder.Ascending)
                        ? daftarLabaSaatIni.OrderBy(x => x.Nama)
                        : daftarLabaSaatIni.OrderByDescending(x => x.Nama);
                    break;
                case "Kode":
                    terurut = (urutanSortLaba == SortOrder.Ascending)
                        ? daftarLabaSaatIni.OrderBy(x => x.Kode)
                        : daftarLabaSaatIni.OrderByDescending(x => x.Kode);
                    break;
                default:
                    terurut = daftarLabaSaatIni.OrderByDescending(x => x.RawLaba);
                    break;
            }

            daftarLabaSaatIni = terurut.ToList();
            gridLaba.DataSource = null;
            gridLaba.DataSource = daftarLabaSaatIni;
        }

        /// <summary>
        /// Menghitung statistik inventaris gudang (stok aman/minimum/habis, mutasi masuk/keluar).
        /// </summary>
        private void TerapkanLaporanGudang()
        {
            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);

            List<Barang> barang = PenyimpananData.BacaBarang();
            List<BarangMasuk> masuk = PenyimpananData.BacaBarangMasuk()
                .Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai)
                .ToList();
            List<BarangKeluar> keluar = PenyimpananData.BacaBarangKeluar()
                .Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai)
                .ToList();

            int minimum = barang.Count(data => data.Stok > 0 && data.Stok <= data.StokMinimum);
            int habis = barang.Count(data => data.Stok == 0);
            int aman = barang.Count - minimum - habis;
            int totalMasuk = masuk.Sum(data => data.Jumlah);
            int totalKeluar = keluar.Sum(data => data.Jumlah);

            lblJudul.Text = "Laporan Inventaris Gudang";
            lblCard1Judul.Text = "Total Barang Terdaftar";
            lblCard2Judul.Text = "Stok Kritis (Min/Habis)";
            lblCard3Judul.Text = "Total Barang Masuk";
            lblCard4Judul.Text = "Total Barang Keluar";

            lblOmzetNilai.Text = barang.Count.ToString("N0", BudayaIndonesia);
            lblTrxNilai.Text = $"{minimum} min / {habis} habis";
            lblItemTerjualNilai.Text = totalMasuk.ToString("N0", BudayaIndonesia);
            lblRataNilai.Text = totalKeluar.ToString("N0", BudayaIndonesia);

            lblRingkasan.Text = $"Status inventaris: {aman} Aman, {minimum} Mencapai Batas Minimum, {habis} Habis. Total unit masuk: {totalMasuk}, unit keluar: {totalKeluar}.";

            AturKolomLaporan();
            gridLaporan.DataSource = barang
                .OrderBy(data => data.Stok)
                .Select(data => new
                {
                    Faktur = data.Kode,
                    Waktu = data.Nama,
                    data.Kategori,
                    Item = data.Stok,
                    Total = "Rp " + data.Harga.ToString("N0", BudayaIndonesia),
                    Status = data.Stok == 0 ? "HABIS" : (data.Stok <= data.StokMinimum ? "MINIMUM" : "AMAN")
                })
                .ToList();

            if (gridLaporan.Columns.Contains("Faktur"))
                gridLaporan.Columns["Faktur"].FillWeight = 80F;
            if (gridLaporan.Columns.Contains("Waktu"))
                gridLaporan.Columns["Waktu"].FillWeight = 160F;
            if (gridLaporan.Columns.Contains("Kasir"))
                gridLaporan.Columns["Kasir"].FillWeight = 100F;
        }

        private void AturKolomLaporan()
        {
            if (jenisLaporan == "gudang")
            {
                colFaktur.HeaderText = "Kode";
                colWaktu.HeaderText = "Nama Barang";
                colKasir.HeaderText = "Kategori";
                colItemQty.HeaderText = "Stok";
                colTotalOmzet.HeaderText = "Harga";
                colStatus.Visible = true;
            }
            else
            {
                colFaktur.HeaderText = "No. Faktur";
                colWaktu.HeaderText = "Waktu Transaksi";
                colKasir.HeaderText = "Kasir";
                colItemQty.HeaderText = "Item Qty";
                colTotalOmzet.HeaderText = "Total Belanja";
                colStatus.Visible = false;
            }
        }

        private static string BuatRingkasanPenjualan(List<Transaksi> transaksi, List<DetailTransaksi> detail)
        {
            if (transaksi.Count == 0)
            {
                return "Tidak ada transaksi pada periode tanggal yang dipilih.";
            }

            var terlaris = detail
                .GroupBy(data => data.NamaBarang)
                .Select(g => new { Nama = g.Key, Jumlah = g.Sum(x => x.Jumlah) })
                .OrderByDescending(x => x.Jumlah)
                .Take(5)
                .Select(x => $"{x.Nama} ({x.Jumlah})");

            var kasirOmzet = transaksi
                .GroupBy(data => data.Kasir)
                .Select(g => $"{g.Key}: Rp {g.Sum(x => x.Total).ToString("N0", BudayaIndonesia)}");

            return $"5 Terlaris: {string.Join(", ", terlaris)} | Kasir: {string.Join(", ", kasirOmzet)}";
        }

        /// <summary>
        /// Mengekspor seluruh rincian laporan yang sedang aktif ke dalam format berkas JSON di folder laporan/
        /// </summary>
        private void SimpanLaporanKeJson()
        {
            try
            {
                DateTime mulai = dtpMulai.Value.Date;
                DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);

                if (mulai > selesai)
                {
                    MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string namaFile;
                object kontenLaporan;

                if (jenisLaporan == "penjualan")
                {
                    if (subJenisPenjualan == "laba")
                    {
                        namaFile = $"laporan_laba_{timestamp}.json";
                        kontenLaporan = new
                        {
                            jenis = "Laporan Analisis Laba Penjualan",
                            periode_mulai = mulai.ToString("yyyy-MM-dd"),
                            periode_selesai = selesai.ToString("yyyy-MM-dd"),
                            dibuat_pada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            dibuat_oleh = Navigasi.PenggunaAktif,
                            total_produk = daftarLabaSaatIni.Count,
                            total_terjual = daftarLabaSaatIni.Sum(x => x.RawTerjual),
                            total_pendapatan = daftarLabaSaatIni.Sum(x => x.RawPendapatan),
                            total_modal = daftarLabaSaatIni.Sum(x => x.RawModal),
                            total_laba_kotor = daftarLabaSaatIni.Sum(x => x.RawLaba),
                            rincian_laba_produk = daftarLabaSaatIni.Select(x => new
                            {
                                kode = x.Kode,
                                nama = x.Nama,
                                terjual = x.RawTerjual,
                                pendapatan = x.RawPendapatan,
                                total_modal = x.RawModal,
                                laba_kotor = x.RawLaba
                            })
                        };
                    }
                    else
                    {
                        namaFile = $"laporan_penjualan_{timestamp}.json";
                        List<Transaksi> transaksi = semuaTransaksi
                            .Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai)
                            .ToList();

                        kontenLaporan = new
                        {
                            jenis = "Laporan Penjualan",
                            periode_mulai = mulai.ToString("yyyy-MM-dd"),
                            periode_selesai = selesai.ToString("yyyy-MM-dd"),
                            dibuat_pada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            dibuat_oleh = Navigasi.PenggunaAktif,
                            jumlah_transaksi = transaksi.Count,
                            total_omzet = transaksi.Sum(t => t.Total),
                            ringkasan = BuatRingkasanPenjualan(transaksi, semuaDetail),
                            transaksi = transaksi.Select(t => new
                            {
                                no_transaksi = t.Id,
                                tanggal = t.Tanggal.ToString("yyyy-MM-dd HH:mm"),
                                kasir = t.Kasir,
                                total = t.Total
                            })
                        };
                    }
                }
                else
                {
                    namaFile = $"laporan_gudang_{timestamp}.json";
                    List<Barang> barang = PenyimpananData.BacaBarang();
                    List<BarangMasuk> masuk = PenyimpananData.BacaBarangMasuk()
                        .Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai)
                        .ToList();
                    List<BarangKeluar> keluar = PenyimpananData.BacaBarangKeluar()
                        .Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai)
                        .ToList();

                    kontenLaporan = new
                    {
                        jenis = "Laporan Stok dan Aktivitas Gudang",
                        periode_mulai = mulai.ToString("yyyy-MM-dd"),
                        periode_selesai = selesai.ToString("yyyy-MM-dd"),
                        dibuat_pada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        dibuat_oleh = Navigasi.PenggunaAktif,
                        total_jenis_barang = barang.Count,
                        total_unit_masuk = masuk.Sum(m => m.Jumlah),
                        total_unit_keluar = keluar.Sum(k => k.Jumlah),
                        barang_masuk = masuk,
                        barang_keluar = keluar,
                        daftar_stok = barang
                    };
                }

                // Simpan laporan ke folder laporan/ (Kasus Uji Laporan)
                PenyimpananData.SimpanLaporanJson(namaFile, kontenLaporan);
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, $"Simpan laporan ke {namaFile}");
                MessageBox.Show($"Laporan berhasil disimpan ke file JSON:\n{namaFile}\n\nFolder: laporan/", "Laporan Tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan laporan ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
