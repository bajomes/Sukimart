using System.Globalization;

namespace Sukimart
{
    public partial class FormLaporan : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Transaksi> semuaTransaksi = new List<Transaksi>();
        private List<DetailTransaksi> semuaDetail = new List<DetailTransaksi>();
        private readonly Button btnPenjualan = new Button();
        private readonly Button btnGudangReport = new Button();
        private readonly DateTimePicker dtpMulai = new DateTimePicker();
        private readonly DateTimePicker dtpSelesai = new DateTimePicker();
        private readonly Button btnTerapkanTanggal = new Button();
        private readonly Label lblRingkasan = new Label();
        private string jenisLaporan = "penjualan";

        public FormLaporan() : this("admin") { }

        public FormLaporan(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            if (this.peran == "gudang")
            {
                jenisLaporan = "gudang";
            }
            gridLaporan.AllowUserToResizeRows = false;
            SiapkanFilterLaporan();
            SesuaikanPeran();
            PasangEventHandlers();
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();
            MuatDataLaporan();
        }

        private void SiapkanFilterLaporan()
        {
            btnHariIni.Visible = false;
            btnBulanIni.Visible = false;
            btnSemuaWaktu.Visible = false;
            pnlKanan.Controls.Add(btnPenjualan);
            pnlKanan.Controls.Add(btnGudangReport);
            pnlKanan.Controls.Add(dtpMulai);
            pnlKanan.Controls.Add(dtpSelesai);
            pnlKanan.Controls.Add(btnTerapkanTanggal);
            pnlKanan.Controls.Add(lblRingkasan);
            AturTombolMode(btnPenjualan, "Penjualan", new Point(40, 248), true, 120);
            AturTombolMode(btnGudangReport, "Inventaris Gudang", new Point(168, 248), false, 152);
            AturTanggalPicker(dtpMulai, new Point(336, 252), DateTime.Today.AddDays(-30));
            AturTanggalPicker(dtpSelesai, new Point(462, 252), DateTime.Today);
            btnTerapkanTanggal.BackColor = Color.White;
            btnTerapkanTanggal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTerapkanTanggal.FlatStyle = FlatStyle.Flat;
            btnTerapkanTanggal.Font = FontInter.Buat(10F, FontStyle.Bold);
            btnTerapkanTanggal.ForeColor = Color.FromArgb(55, 65, 81);
            btnTerapkanTanggal.Location = new Point(588, 248);
            btnTerapkanTanggal.Size = new Size(108, 32);
            btnTerapkanTanggal.Text = "Terapkan";
            lblRingkasan.Font = FontInter.Buat(9F);
            lblRingkasan.ForeColor = Color.FromArgb(75, 85, 99);
            lblRingkasan.Location = new Point(40, 292);
            lblRingkasan.Size = new Size(960, 42);
        }

        private static void AturTanggalPicker(DateTimePicker picker, Point lokasi, DateTime nilai)
        {
            picker.Format = DateTimePickerFormat.Short;
            picker.Font = FontInter.Buat(10F);
            picker.Location = lokasi;
            picker.Size = new Size(118, 23);
            picker.Value = nilai;
        }

        private static void AturTombolMode(Button tombol, string teks, Point lokasi, bool aktif, int lebar)
        {
            tombol.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
            tombol.Cursor = Cursors.Hand;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            tombol.FlatAppearance.BorderSize = aktif ? 0 : 1;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.Font = FontInter.Buat(10F, aktif ? FontStyle.Bold : FontStyle.Regular);
            tombol.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            tombol.Location = lokasi;
            tombol.Size = new Size(lebar, 32);
            tombol.Text = teks;
        }

        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;
            int jarak = 20;
            int lebarKartu = (lebarTersedia - 3 * jarak) / 4;
            pnlCard1.Location = new Point(margin, 112);
            pnlCard1.Size = new Size(lebarKartu, 112);
            pnlCard2.Location = new Point(margin + lebarKartu + jarak, 112);
            pnlCard2.Size = new Size(lebarKartu, 112);
            pnlCard3.Location = new Point(margin + 2 * (lebarKartu + jarak), 112);
            pnlCard3.Size = new Size(lebarKartu, 112);
            pnlCard4.Location = new Point(margin + 3 * (lebarKartu + jarak), 112);
            pnlCard4.Size = new Size(lebarKartu, 112);
            gridLaporan.Location = new Point(margin, 344);
            gridLaporan.Size = new Size(lebarTersedia, Math.Max(180, pnlKanan.ClientSize.Height - 388));
            lblRingkasan.Size = new Size(lebarTersedia, 42);
        }

        private void SesuaikanPeran()
        {
            bool admin = peran == "admin";
            btnGudang.Visible = admin;
            btnLaporan.Visible = admin;
            btnPengguna.Visible = admin;
            btnPenjualan.Visible = admin;
            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);
            btnHariIni.Click += (s, e) => AturTanggal(DateTime.Today, DateTime.Today);
            btnBulanIni.Click += (s, e) => AturTanggal(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Today);
            btnSemuaWaktu.Click += (s, e) => AturTanggal(DateTime.Today.AddYears(-10), DateTime.Today);
            btnPenjualan.Click += (s, e) => UbahJenisLaporan("penjualan");
            btnGudangReport.Click += (s, e) => UbahJenisLaporan("gudang");
            btnTerapkanTanggal.Click += (s, e) => TerapkanLaporan();
        }

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
            AturTombolMode(btnPenjualan, "Penjualan", new Point(40, 248), jenis == "penjualan", 120);
            AturTombolMode(btnGudangReport, "Inventaris Gudang", new Point(168, 248), jenis == "gudang", 152);
            TerapkanLaporan();
        }

        private void TerapkanLaporan()
        {
            if (dtpMulai.Value.Date > dtpSelesai.Value.Date)
            {
                MessageBox.Show("Tanggal mulai tidak boleh setelah tanggal selesai.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (jenisLaporan == "gudang") TerapkanLaporanGudang();
            else TerapkanLaporanPenjualan();
        }

        private void TerapkanLaporanPenjualan()
        {
            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);
            List<Transaksi> transaksi = semuaTransaksi.Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai).ToList();
            HashSet<string> idTransaksi = transaksi.Select(data => data.Id).ToHashSet();
            List<DetailTransaksi> detail = semuaDetail.Where(data => idTransaksi.Contains(data.IdTransaksi)).ToList();
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
            lblTrxNilai.Text = totalTransaksi.ToString("N0", BudayaIndonesia);
            lblItemTerjualNilai.Text = totalItem.ToString("N0", BudayaIndonesia);
            lblRataNilai.Text = "Rp " + rataRata.ToString("N0", BudayaIndonesia);
            lblRingkasan.Text = BuatRingkasanPenjualan(transaksi, detail);
            AturKolomLaporan();
            gridLaporan.DataSource = transaksi.OrderByDescending(data => data.Tanggal).Select(data => new { Faktur = data.Id, Waktu = data.Tanggal.ToString("dd/MM/yyyy HH:mm"), data.Kasir, Item = detail.Where(rincian => rincian.IdTransaksi == data.Id).Sum(rincian => rincian.Jumlah), Total = "Rp " + data.Total.ToString("N0", BudayaIndonesia) }).ToList();
        }

        private void TerapkanLaporanGudang()
        {
            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);
            List<Barang> barang = PenyimpananData.BacaBarang();
            List<BarangMasuk> masuk = PenyimpananData.BacaBarangMasuk().Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai).ToList();
            List<BarangKeluar> keluar = PenyimpananData.BacaBarangKeluar().Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai).ToList();
            int minimum = barang.Count(data => data.Stok > 0 && data.Stok <= data.StokMinimum);
            int habis = barang.Count(data => data.Stok == 0);
            lblJudul.Text = "Laporan Inventaris Gudang";
            lblCard1Judul.Text = "Jenis Barang";
            lblCard2Judul.Text = "Minimum / Habis";
            lblCard3Judul.Text = "Unit Masuk";
            lblCard4Judul.Text = "Unit Keluar";
            lblOmzetNilai.Text = barang.Count.ToString("N0", BudayaIndonesia);
            lblTrxNilai.Text = $"{minimum} / {habis}";
            lblItemTerjualNilai.Text = masuk.Sum(data => data.Jumlah).ToString("N0", BudayaIndonesia);
            lblRataNilai.Text = keluar.Sum(data => data.Jumlah).ToString("N0", BudayaIndonesia);
            lblRingkasan.Text = $"Stok saat ini ditampilkan untuk semua barang. Pergerakan dicatat dari {mulai:dd/MM/yyyy} sampai {selesai:dd/MM/yyyy}.";
            AturKolomLaporan();
            var dataStok = barang.Select(data => new { Jenis = "STOK", Tanggal = "-", Kode = data.Kode, Nama = data.Nama, Jumlah = data.Stok.ToString("N0", BudayaIndonesia), Keterangan = data.Stok == 0 ? "HABIS" : data.Stok <= data.StokMinimum ? "MINIMUM" : "AMAN" });
            var dataMasuk = masuk.Select(data => new { Jenis = "MASUK", Tanggal = data.Tanggal.ToString("dd/MM/yyyy"), Kode = data.KodeBarang, Nama = data.NamaBarang, Jumlah = "+" + data.Jumlah.ToString("N0", BudayaIndonesia), Keterangan = $"{data.Id} · {data.Pemasok}" });
            var dataKeluar = keluar.Select(data => new { Jenis = "KELUAR", Tanggal = data.Tanggal.ToString("dd/MM/yyyy"), Kode = data.KodeBarang, Nama = data.NamaBarang, Jumlah = "−" + data.Jumlah.ToString("N0", BudayaIndonesia), Keterangan = $"{data.Id} · {data.Alasan}" });
            gridLaporan.DataSource = dataStok.Concat(dataMasuk).Concat(dataKeluar).ToList();
        }

        private void AturKolomLaporan()
        {
            gridLaporan.DataSource = null;
            gridLaporan.Columns.Clear();
            gridLaporan.AutoGenerateColumns = true;
        }

        private string BuatRingkasanPenjualan(List<Transaksi> transaksi, List<DetailTransaksi> detail)
        {
            string barangTerlaris = string.Join(", ", detail.GroupBy(data => new { data.KodeBarang, data.NamaBarang }).OrderByDescending(grup => grup.Sum(data => data.Jumlah)).ThenBy(grup => grup.Key.KodeBarang).Take(5).Select(grup => $"{grup.Key.KodeBarang} ({grup.Sum(data => data.Jumlah)})"));
            string perKasir = string.Join(", ", transaksi.GroupBy(data => data.Kasir).OrderBy(grup => grup.Key).Select(grup => $"{grup.Key}: Rp {grup.Sum(data => data.Total).ToString("N0", BudayaIndonesia)}"));
            return $"5 barang terlaris: {(barangTerlaris.Length == 0 ? "Tidak ada data" : barangTerlaris)}\nPenjualan per kasir: {(perKasir.Length == 0 ? "Tidak ada data" : perKasir)}";
        }
    }
}
