using System.Globalization;
using System.Reflection;

namespace Sukimart
{
    public partial class FormLaporan : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Transaksi> semuaTransaksi = new List<Transaksi>();
        private List<DetailTransaksi> semuaDetail = new List<DetailTransaksi>();
        private string subJenisPenjualan = "transaksi";
        private List<ItemLabaProduk> daftarLabaSaatIni = new List<ItemLabaProduk>();
        private string kolomUrutLaba = "LabaKotor";
        private SortOrder urutanSortLaba = SortOrder.Descending;

        public FormLaporan() : this("admin") { }

        public FormLaporan(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            AktifkanBebasFlicker();
            MaximizeBox = true;
            gridLaporan.AllowUserToResizeRows = false;
            gridLaba.AllowUserToResizeRows = false;
            SiapkanFilterLaporan();
            SesuaikanPeran();
            PasangEventHandlers();
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();
            MuatDataLaporan();
        }

        private void AktifkanBebasFlicker()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            try
            {
                var flag = BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic;
                typeof(Panel).InvokeMember("DoubleBuffered", flag, null, pnlKanan, new object[] { true });
                typeof(DataGridView).InvokeMember("DoubleBuffered", flag, null, gridLaporan, new object[] { true });
                typeof(DataGridView).InvokeMember("DoubleBuffered", flag, null, gridLaba, new object[] { true });
            }
            catch
            {
            }
        }

        private void SiapkanFilterLaporan()
        {
            dtpMulai.Format = DateTimePickerFormat.Custom;
            dtpMulai.CustomFormat = "dd/MM/yyyy";
            dtpSelesai.Format = DateTimePickerFormat.Custom;
            dtpSelesai.CustomFormat = "dd/MM/yyyy";

            dtpMulai.Value = DateTime.Today.AddDays(-30);
            dtpSelesai.Value = DateTime.Today;

            btnLaporan.BackColor = Color.FromArgb(255, 196, 0);
            btnLaporan.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporan.Font = FontInter.Buat(10F, FontStyle.Bold);

            btnLaporanInventaris.BackColor = Color.White;
            btnLaporanInventaris.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporanInventaris.Font = FontInter.Buat(10F, FontStyle.Regular);

            AturTombolSub(btnSubTransaksi, "Transaksi", true, 110);
            AturTombolSub(btnSubLaba, "Laba", false, 110);

            lblRingkasan.Font = FontInter.Buat(9F);
            lblRingkasan.ForeColor = Color.FromArgb(75, 85, 99);

            lblJudulTabel.Font = FontInter.Buat(11F, FontStyle.Bold);
            lblJudulTabel.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudulTabel.Text = "Rincian Laba per Produk";

            lblSampai.Font = FontInter.Buat(9F);
            dtpMulai.Font = FontInter.Buat(9.5F);
            dtpSelesai.Font = FontInter.Buat(9.5F);
            btnTerapkanTanggal.Font = FontInter.Buat(9.5F, FontStyle.Bold);

            lblTotalJudul.Font = FontInter.Buat(9.5F, FontStyle.Bold);
            lblTotalJudul.ForeColor = Color.FromArgb(55, 65, 81);
            lblTotalTerjualLabel.Font = FontInter.Buat(9F);
            lblTotalTerjualLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalTerjualNilai.Font = FontInter.Buat(9.5F, FontStyle.Bold);
            lblTotalTerjualNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalPendapatanLabel.Font = FontInter.Buat(9F);
            lblTotalPendapatanLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalPendapatanNilai.Font = FontInter.Buat(9.5F, FontStyle.Bold);
            lblTotalPendapatanNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalModalLabel.Font = FontInter.Buat(9F);
            lblTotalModalLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalModalNilai.Font = FontInter.Buat(9.5F, FontStyle.Bold);
            lblTotalModalNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalLabaLabel.Font = FontInter.Buat(9F);
            lblTotalLabaLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalLabaNilai.Font = FontInter.Buat(9.5F, FontStyle.Bold);
            lblTotalLabaNilai.ForeColor = Color.FromArgb(16, 149, 102);

            pnlTotalLaba.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawLine(pen, 0, 0, pnlTotalLaba.Width, 0);
            };
        }

        private static void AturTombolSub(Button tombol, string teks, bool aktif, int lebar = 110)
        {
            tombol.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
            tombol.Cursor = Cursors.Hand;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            tombol.FlatAppearance.BorderSize = aktif ? 0 : 1;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.Font = FontInter.Buat(9.5F, aktif ? FontStyle.Bold : FontStyle.Regular);
            tombol.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            tombol.Size = new Size(lebar, 32);
            tombol.Text = teks;
        }

        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;

            if (nightControlBox1 != null)
            {
                nightControlBox1.Location = new Point(pnlKanan.ClientSize.Width - nightControlBox1.Width, 0);
                nightControlBox1.BringToFront();
            }

            int jarak = 20;
            int lebarKartu = (lebarTersedia - 3 * jarak) / 4;

            // 1. Header & Sub-Navigasi (Transaksi & Laba) di atas 4 kartu
            lblJudul.Location = new Point(margin, 24);
            btnSubTransaksi.Location = new Point(margin, 68);
            btnSubTransaksi.Size = new Size(110, 32);
            btnSubTransaksi.Visible = true;
            btnSubLaba.Location = new Point(margin + 118, 68);
            btnSubLaba.Size = new Size(110, 32);
            btnSubLaba.Visible = true;

            // 2. 4 Panel KPI Cards (tersusun horizontal di bawah tombol sub-navigasi)
            int yCards = 112;
            int tinggiKartu = 104;
            pnlCard1.Location = new Point(margin, yCards);
            pnlCard1.Size = new Size(lebarKartu, tinggiKartu);
            pnlCard2.Location = new Point(margin + lebarKartu + jarak, yCards);
            pnlCard2.Size = new Size(lebarKartu, tinggiKartu);
            pnlCard3.Location = new Point(margin + 2 * (lebarKartu + jarak), yCards);
            pnlCard3.Size = new Size(lebarKartu, tinggiKartu);
            pnlCard4.Location = new Point(margin + 3 * (lebarKartu + jarak), yCards);
            pnlCard4.Size = new Size(lebarKartu, tinggiKartu);

            // 3. Filter Tanggal (di bawah 4 panel card)
            int yFilter = 232;
            dtpMulai.Location = new Point(margin, yFilter + 2);
            dtpMulai.Size = new Size(130, 27);
            lblSampai.Location = new Point(margin + 138, yFilter + 7);
            lblSampai.Size = new Size(28, 20);
            dtpSelesai.Location = new Point(margin + 172, yFilter + 2);
            dtpSelesai.Size = new Size(130, 27);
            btnTerapkanTanggal.Location = new Point(margin + 312, yFilter);
            btnTerapkanTanggal.Size = new Size(96, 32);
            btnSimpanJson.Location = new Point(margin + 418, yFilter);
            btnSimpanJson.Size = new Size(130, 32);

            // 4. Panel Sub-Halaman (Transaksi / Laba)
            int yPanel = 272;
            int tinggiPanel = Math.Max(260, pnlKanan.ClientSize.Height - yPanel);
            bool isLaba = subJenisPenjualan == "laba";

            pnlSubTransaksi.Bounds = new Rectangle(0, yPanel, pnlKanan.ClientSize.Width, tinggiPanel);
            pnlSubLaba.Bounds = new Rectangle(0, yPanel, pnlKanan.ClientSize.Width, tinggiPanel);
            pnlSubTransaksi.Visible = !isLaba;
            pnlSubLaba.Visible = isLaba;

            int tinggiTotal = 46;

            if (!isLaba)
            {
                lblRingkasan.Location = new Point(margin, 4);
                lblRingkasan.Size = new Size(lebarTersedia, 44);
                gridLaporan.Location = new Point(margin, 54);
                gridLaporan.Size = new Size(lebarTersedia, Math.Max(180, tinggiPanel - 54 - 20));
            }
            else
            {
                lblJudulTabel.Location = new Point(margin, 4);
                int yGridLaba = 34;
                int tinggiGridLaba = Math.Max(180, tinggiPanel - yGridLaba - tinggiTotal - 26);
                gridLaba.Location = new Point(margin, yGridLaba);
                gridLaba.Size = new Size(lebarTersedia, tinggiGridLaba);

                int yTotal = yGridLaba + tinggiGridLaba + 8;
                pnlTotalLaba.Location = new Point(margin, yTotal);
                pnlTotalLaba.Size = new Size(lebarTersedia, tinggiTotal);

                // Kolom pembagian: Kode 13%, Nama 23%, Terjual 10%, Pendapatan 18%, Total Modal 18%, Laba Kotor 18%
                int col1W = (int)(lebarTersedia * 0.13);
                int col2W = (int)(lebarTersedia * 0.23);
                int col3W = (int)(lebarTersedia * 0.10);
                int col4W = (int)(lebarTersedia * 0.18);
                int col5W = (int)(lebarTersedia * 0.18);

                int xCol3 = col1W + col2W;
                int xCol4 = xCol3 + col3W;
                int xCol5 = xCol4 + col4W;
                int xCol6 = xCol5 + col5W;

                lblTotalJudul.Location = new Point(14, 13);

                // Terjual
                lblTotalTerjualLabel.Location = new Point(Math.Max(xCol3 - 60, 200), 14);
                lblTotalTerjualNilai.Location = new Point(lblTotalTerjualLabel.Right + 4, 13);

                // Pendapatan
                lblTotalPendapatanLabel.Location = new Point(xCol4, 14);
                lblTotalPendapatanNilai.Location = new Point(lblTotalPendapatanLabel.Right + 4, 13);

                // Modal
                lblTotalModalLabel.Location = new Point(xCol5, 14);
                lblTotalModalNilai.Location = new Point(lblTotalModalLabel.Right + 4, 13);

                // Laba Kotor
                lblTotalLabaLabel.Location = new Point(xCol6, 14);
                lblTotalLabaNilai.Location = new Point(lblTotalLabaLabel.Right + 4, 13);
            }
        }

        private void SesuaikanPeran()
        {
            bool admin = peran == "admin";
            bool gudang = peran == "gudang";
            btnGudang.Visible = admin || gudang;
            btnLaporan.Visible = admin || gudang;
            btnLaporanInventaris.Visible = admin || gudang;
            btnPengguna.Visible = admin;
            btnLogAktivitas.Visible = admin;
            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporanInventaris.Click += (s, e) => Navigasi.BukaLaporanInventaris(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);
            btnSubTransaksi.Click += (s, e) => UbahSubJenisPenjualan("transaksi");
            btnSubLaba.Click += (s, e) => UbahSubJenisPenjualan("laba");
            btnTerapkanTanggal.Click += (s, e) => TerapkanLaporan();
            btnSimpanJson.Click += (s, e) => SimpanLaporanKeJson();
            gridLaba.ColumnHeaderMouseClick += GridLaba_ColumnHeaderMouseClick;

            dtpMulai.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TerapkanLaporan(); } };
            dtpSelesai.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TerapkanLaporan(); } };
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

        private void UbahSubJenisPenjualan(string subJenis)
        {
            subJenisPenjualan = subJenis;
            AturTombolSub(btnSubTransaksi, "Transaksi", subJenis == "transaksi", 110);
            AturTombolSub(btnSubLaba, "Laba", subJenis == "laba", 110);
            TerapkanLaporan();
        }

        private void TerapkanLaporan()
        {
            if (dtpMulai.Value.Date > dtpSelesai.Value.Date)
            {
                MessageBox.Show("Tanggal mulai tidak boleh setelah tanggal selesai.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                semuaTransaksi = PenyimpananData.BacaTransaksi();
                semuaDetail = PenyimpananData.BacaDetailTransaksi();
            }
            catch
            {
            }

            pnlKanan.SuspendLayout();
            try
            {
                AturTataLetakResponsif();

                if (subJenisPenjualan == "laba")
                {
                    TerapkanLaporanLaba();
                }
                else
                {
                    TerapkanLaporanPenjualan();
                }
            }
            finally
            {
                pnlKanan.ResumeLayout();
            }
        }

        private void TerapkanLaporanPenjualan()
        {
            lblJudul.Text = "Laporan Penjualan";
            lblCard1Judul.Text = "Total Pendapatan";
            lblCard2Judul.Text = "Jumlah Transaksi";
            lblCard3Judul.Text = "Item Terjual";
            lblCard4Judul.Text = "Rata-rata Transaksi";

            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);
            List<Transaksi> transaksi = semuaTransaksi.Where(data => data.Tanggal >= mulai && data.Tanggal <= selesai).ToList();
            HashSet<string> idTransaksi = transaksi.Select(data => data.Id).ToHashSet();
            List<DetailTransaksi> detail = semuaDetail.Where(data => idTransaksi.Contains(data.IdTransaksi)).ToList();
            int totalOmzet = transaksi.Sum(data => data.Total);
            int totalTransaksi = transaksi.Count;
            int totalItem = detail.Sum(data => data.Jumlah);
            int rataRata = totalTransaksi > 0 ? totalOmzet / totalTransaksi : 0;

            lblOmzetNilai.Text = "Rp " + totalOmzet.ToString("N0", BudayaIndonesia);
            lblOmzetNilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblTrxNilai.Text = totalTransaksi.ToString("N0", BudayaIndonesia);
            lblTrxNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblItemTerjualNilai.Text = totalItem.ToString("N0", BudayaIndonesia);
            lblItemTerjualNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblRataNilai.Text = "Rp " + rataRata.ToString("N0", BudayaIndonesia);
            lblRataNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblRingkasan.Text = BuatRingkasanPenjualan(transaksi, detail);
            AturKolomLaporan();
            gridLaporan.DataSource = transaksi.OrderByDescending(data => data.Tanggal).Select(data => new { Faktur = data.Id, Waktu = data.Tanggal.ToString("dd/MM/yyyy HH:mm"), data.Kasir, Item = detail.Where(rincian => rincian.IdTransaksi == data.Id).Sum(rincian => rincian.Jumlah), Total = "Rp " + data.Total.ToString("N0", BudayaIndonesia) }).ToList();
        }

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
                    long pendapatan = g.Sum(x => (long)x.Harga * x.Jumlah);
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

            // Update 4 KPI Cards
            lblOmzetNilai.Text = "Rp " + totalPendapatan.ToString("N0", BudayaIndonesia);
            lblOmzetNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblTrxNilai.Text = "Rp " + totalModal.ToString("N0", BudayaIndonesia);
            lblTrxNilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblItemTerjualNilai.Text = "Rp " + totalLabaKotor.ToString("N0", BudayaIndonesia);
            lblItemTerjualNilai.ForeColor = Color.FromArgb(16, 149, 102); // Hijau untuk Laba Kotor

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

            // Update Ringkasan Total Keseluruhan di Bawah DataGridView
            lblTotalTerjualNilai.Text = totalTerjual.ToString("N0", BudayaIndonesia);
            lblTotalPendapatanNilai.Text = "Rp " + totalPendapatan.ToString("N0", BudayaIndonesia);
            lblTotalModalNilai.Text = "Rp " + totalModal.ToString("N0", BudayaIndonesia);
            lblTotalLabaNilai.Text = "Rp " + totalLabaKotor.ToString("N0", BudayaIndonesia);

            daftarLabaSaatIni = rincianProduk;
            UrutkanDanTampilkanDataLaba();
        }

        private void GridLaba_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= gridLaba.Columns.Count) return;
            if (daftarLabaSaatIni == null || daftarLabaSaatIni.Count == 0) return;

            var kolom = gridLaba.Columns[e.ColumnIndex];
            if (kolom == colLabaKotor)
            {
                if (kolomUrutLaba == "LabaKotor")
                    urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                else
                {
                    kolomUrutLaba = "LabaKotor";
                    urutanSortLaba = SortOrder.Descending;
                }
                UrutkanDanTampilkanDataLaba();
            }
            else if (kolom == colLabaPendapatan)
            {
                if (kolomUrutLaba == "Pendapatan")
                    urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                else
                {
                    kolomUrutLaba = "Pendapatan";
                    urutanSortLaba = SortOrder.Descending;
                }
                UrutkanDanTampilkanDataLaba();
            }
            else if (kolom == colLabaModal)
            {
                if (kolomUrutLaba == "TotalModal")
                    urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                else
                {
                    kolomUrutLaba = "TotalModal";
                    urutanSortLaba = SortOrder.Descending;
                }
                UrutkanDanTampilkanDataLaba();
            }
            else if (kolom == colLabaTerjual)
            {
                if (kolomUrutLaba == "Terjual")
                    urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                else
                {
                    kolomUrutLaba = "Terjual";
                    urutanSortLaba = SortOrder.Descending;
                }
                UrutkanDanTampilkanDataLaba();
            }
            else if (kolom == colLabaNama)
            {
                if (kolomUrutLaba == "Nama")
                    urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                else
                {
                    kolomUrutLaba = "Nama";
                    urutanSortLaba = SortOrder.Ascending;
                }
                UrutkanDanTampilkanDataLaba();
            }
            else if (kolom == colLabaKode)
            {
                if (kolomUrutLaba == "Kode")
                    urutanSortLaba = (urutanSortLaba == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                else
                {
                    kolomUrutLaba = "Kode";
                    urutanSortLaba = SortOrder.Ascending;
                }
                UrutkanDanTampilkanDataLaba();
            }
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

            foreach (DataGridViewColumn col in gridLaba.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            if (kolomUrutLaba == "LabaKotor") colLabaKotor.HeaderCell.SortGlyphDirection = urutanSortLaba;
            else if (kolomUrutLaba == "Pendapatan") colLabaPendapatan.HeaderCell.SortGlyphDirection = urutanSortLaba;
            else if (kolomUrutLaba == "TotalModal") colLabaModal.HeaderCell.SortGlyphDirection = urutanSortLaba;
            else if (kolomUrutLaba == "Terjual") colLabaTerjual.HeaderCell.SortGlyphDirection = urutanSortLaba;
            else if (kolomUrutLaba == "Nama") colLabaNama.HeaderCell.SortGlyphDirection = urutanSortLaba;
            else if (kolomUrutLaba == "Kode") colLabaKode.HeaderCell.SortGlyphDirection = urutanSortLaba;
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

                PenyimpananData.SimpanLaporanJson(namaFile, kontenLaporan);
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Laporan", $"Menyimpan {namaFile}");
                MessageBox.Show($"Laporan berhasil disimpan ke file JSON:\n{namaFile}\n\nFolder: laporan/", "Laporan Tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan laporan ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
