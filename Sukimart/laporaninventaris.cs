using System.Data;
using System.Globalization;
using System.Reflection;

namespace Sukimart
{
    public partial class FormLaporanInventaris : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private string subHalamanAktif = "jumlah"; // "jumlah" atau "riwayat"

        // Cache data
        private List<Barang> daftarBarang = new List<Barang>();
        private List<ItemMutasiStok> daftarMutasi = new List<ItemMutasiStok>();

        public FormLaporanInventaris() : this("admin") { }

        public FormLaporanInventaris(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            AktifkanBebasFlicker();
            MaximizeBox = true;

            gridJumlahStok.AllowUserToResizeRows = false;
            gridRiwayatStok.AllowUserToResizeRows = false;

            InisialisasiKomponenKustom();
            SesuaikanPeran();
            PasangEventHandlers();

            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            MuatDataSemua();
        }

        private void AktifkanBebasFlicker()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            try
            {
                var flag = BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic;
                typeof(Panel).InvokeMember("DoubleBuffered", flag, null, pnlKanan, new object[] { true });
                typeof(DataGridView).InvokeMember("DoubleBuffered", flag, null, gridJumlahStok, new object[] { true });
                typeof(DataGridView).InvokeMember("DoubleBuffered", flag, null, gridRiwayatStok, new object[] { true });
            }
            catch
            {
            }
        }

        private void InisialisasiKomponenKustom()
        {
            dtpMulai.Format = DateTimePickerFormat.Custom;
            dtpMulai.CustomFormat = "dd/MM/yyyy";
            dtpSelesai.Format = DateTimePickerFormat.Custom;
            dtpSelesai.CustomFormat = "dd/MM/yyyy";

            dtpMulai.Value = DateTime.Today.AddDays(-30);
            dtpSelesai.Value = DateTime.Today;

            cmbFilterStatus.SelectedIndex = 0;
            cmbJenisPergerakan.SelectedIndex = 0;

            btnLaporanInventaris.BackColor = Color.FromArgb(255, 196, 0);
            btnLaporanInventaris.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporanInventaris.Font = FontInter.Buat(10F, FontStyle.Bold);

            btnLaporan.BackColor = Color.White;
            btnLaporan.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporan.Font = FontInter.Buat(10F, FontStyle.Regular);

            AturTombolSub(btnSubJumlahStok, "Jumlah Stok", true);
            AturTombolSub(btnSubRiwayatStok, "Riwayat Stok", false);

            lblJudul.Font = FontInter.Buat(20F, FontStyle.Bold);
            lblCard1Judul.Font = FontInter.Buat(8.5F, FontStyle.Bold);
            lblCard2Judul.Font = FontInter.Buat(8.5F, FontStyle.Bold);
            lblCard3Judul.Font = FontInter.Buat(8.5F, FontStyle.Bold);
            lblCard4Judul.Font = FontInter.Buat(8.5F, FontStyle.Bold);

            lblCard1Nilai.Font = FontInter.Buat(16F, FontStyle.Bold);
            lblCard2Nilai.Font = FontInter.Buat(16F, FontStyle.Bold);
            lblCard3Nilai.Font = FontInter.Buat(16F, FontStyle.Bold);
            lblCard4Nilai.Font = FontInter.Buat(16F, FontStyle.Bold);

            txtCariJumlah.Font = FontInter.Buat(9.5F);
            cmbFilterStatus.Font = FontInter.Buat(9.5F);

            dtpMulai.Font = FontInter.Buat(9.5F);
            dtpSelesai.Font = FontInter.Buat(9.5F);
            lblSampai.Font = FontInter.Buat(9F);
            btnTerapkanRiwayat.Font = FontInter.Buat(9.5F, FontStyle.Bold);
            txtCariRiwayat.Font = FontInter.Buat(9.5F);
            cmbJenisPergerakan.Font = FontInter.Buat(9.5F);

            gridJumlahStok.AutoGenerateColumns = false;
            colJumlahKode.DataPropertyName = "Kode";
            colJumlahNama.DataPropertyName = "Nama";
            colJumlahStok.DataPropertyName = "Stok";
            colJumlahMin.DataPropertyName = "StokMinimum";
            colJumlahStatus.DataPropertyName = "Status";

            gridRiwayatStok.AutoGenerateColumns = false;
            colRiwayatTanggal.DataPropertyName = "TanggalFormat";
            colRiwayatKode.DataPropertyName = "KodeBarang";
            colRiwayatNama.DataPropertyName = "NamaBarang";
            colRiwayatJenis.DataPropertyName = "Jenis";
            colRiwayatJumlah.DataPropertyName = "JumlahFormat";
            colRiwayatKet.DataPropertyName = "Keterangan";
            colRiwayatOleh.DataPropertyName = "Pengguna";

            colJumlahStok.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colJumlahMin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colJumlahStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colRiwayatJenis.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRiwayatJumlah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridJumlahStok.CellFormatting += GridJumlahStok_CellFormatting;
            gridRiwayatStok.CellFormatting += GridRiwayatStok_CellFormatting;
            gridJumlahStok.CellDoubleClick += GridJumlahStok_CellDoubleClick;
            gridJumlahStok.KeyDown += GridJumlahStok_KeyDown;
        }

        private static void AturTombolSub(Button tombol, string teks, bool aktif, int lebar = 130)
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
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporanPenjualan(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);

            btnSubJumlahStok.Click += (s, e) => BeralihSubHalaman("jumlah");
            btnSubRiwayatStok.Click += (s, e) => BeralihSubHalaman("riwayat");

            txtCariJumlah.TextChanged += (s, e) => TerapkanFilterJumlahStok();
            cmbFilterStatus.SelectedIndexChanged += (s, e) => TerapkanFilterJumlahStok();

            btnTerapkanRiwayat.Click += (s, e) => TerapkanFilterRiwayatStok();
            txtCariRiwayat.TextChanged += (s, e) => TerapkanFilterRiwayatStok();
            cmbJenisPergerakan.SelectedIndexChanged += (s, e) => TerapkanFilterRiwayatStok();
            btnSimpanJson.Click += (s, e) => SimpanLaporanGudangKeJson();

            dtpMulai.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TerapkanFilterRiwayatStok(); } };
            dtpSelesai.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TerapkanFilterRiwayatStok(); } };
        }

        private void BeralihSubHalaman(string sub)
        {
            if (subHalamanAktif == sub) return;
            subHalamanAktif = sub;

            AturTombolSub(btnSubJumlahStok, "Jumlah Stok", sub == "jumlah");
            AturTombolSub(btnSubRiwayatStok, "Riwayat Stok", sub == "riwayat");

            pnlKanan.SuspendLayout();
            try
            {
                bool isJumlah = sub == "jumlah";

                pnlSubJumlahStok.Visible = isJumlah;
                pnlSubRiwayatStok.Visible = !isJumlah;

                AturTataLetakResponsif();

                if (isJumlah)
                {
                    TerapkanFilterJumlahStok();
                }
                else
                {
                    TerapkanFilterRiwayatStok();
                }
            }
            finally
            {
                pnlKanan.ResumeLayout();
            }
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

            // 1. Header & Sub-Navigasi (Jumlah Stok & Riwayat Stok)
            lblJudul.Location = new Point(margin, 24);
            btnSubJumlahStok.Location = new Point(margin, 68);
            btnSubJumlahStok.Size = new Size(130, 32);
            btnSubRiwayatStok.Location = new Point(margin + 138, 68);
            btnSubRiwayatStok.Size = new Size(130, 32);

            // 2. 4 Kartu KPI
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

            // 3. Filter Section & Panel Sub-Halaman
            int yPanel = 224;
            int tinggiPanel = Math.Max(260, pnlKanan.ClientSize.Height - yPanel);
            pnlSubJumlahStok.Bounds = new Rectangle(0, yPanel, pnlKanan.ClientSize.Width, tinggiPanel);
            pnlSubRiwayatStok.Bounds = new Rectangle(0, yPanel, pnlKanan.ClientSize.Width, tinggiPanel);

            int yFilter = 8;
            int xBtnSimpan = margin + lebarTersedia - 140;
            btnSimpanJson.Location = new Point(xBtnSimpan, yPanel + yFilter);
            btnSimpanJson.Size = new Size(140, 32);
            btnSimpanJson.BringToFront();

            int tinggiGrid = Math.Max(180, tinggiPanel - 56 - 24);

            if (subHalamanAktif == "jumlah")
            {
                txtCariJumlah.Location = new Point(margin, yFilter);
                txtCariJumlah.Size = new Size(300, 27);
                cmbFilterStatus.Location = new Point(margin + 312, yFilter);
                cmbFilterStatus.Size = new Size(160, 27);

                gridJumlahStok.Location = new Point(margin, 56);
                gridJumlahStok.Size = new Size(lebarTersedia, tinggiGrid);
            }
            else
            {
                dtpMulai.Location = new Point(margin, yFilter + 2);
                dtpMulai.Size = new Size(130, 27);
                lblSampai.Location = new Point(margin + 138, yFilter + 7);
                lblSampai.Size = new Size(28, 20);
                dtpSelesai.Location = new Point(margin + 172, yFilter + 2);
                dtpSelesai.Size = new Size(130, 27);
                btnTerapkanRiwayat.Location = new Point(margin + 312, yFilter);
                btnTerapkanRiwayat.Size = new Size(92, 32);

                int xSisa = margin + 416;
                int lebarSisa = xBtnSimpan - xSisa - 12;
                int lebarCombo = 150;
                int lebarSearch = Math.Max(150, lebarSisa - lebarCombo - 12);

                txtCariRiwayat.Location = new Point(xSisa, yFilter);
                txtCariRiwayat.Size = new Size(lebarSearch, 27);
                cmbJenisPergerakan.Location = new Point(xSisa + lebarSearch + 12, yFilter);
                cmbJenisPergerakan.Size = new Size(lebarCombo, 27);

                gridRiwayatStok.Location = new Point(margin, 56);
                gridRiwayatStok.Size = new Size(lebarTersedia, tinggiGrid);
            }
        }

        public void MuatDataSemua()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                daftarMutasi = MuatSeluruhRiwayatMutasi();

                if (subHalamanAktif == "jumlah")
                {
                    TerapkanFilterJumlahStok();
                }
                else
                {
                    TerapkanFilterRiwayatStok();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data inventaris: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Subhalaman Jumlah Stok

        public static string TentukanStatusStok(int stok, int stokMinimum)
        {
            if (stok == 0) return "HABIS";
            if (stok < stokMinimum) return "KRITIS";
            if (stok == stokMinimum) return "MINIMUM";
            return "AMAN";
        }

        private void TerapkanFilterJumlahStok()
        {
            var dataAktif = daftarBarang.Where(b => b.Aktif).ToList();

            // Hitung 4 Kartu KPI Jumlah Stok
            int totalJenis = dataAktif.Count;
            int totalAman = dataAktif.Count(b => b.Stok > b.StokMinimum);
            int totalMinimum = dataAktif.Count(b => b.Stok == b.StokMinimum && b.StokMinimum > 0);
            int totalHabis = dataAktif.Count(b => b.Stok == 0);

            lblCard1Judul.Text = "TOTAL JENIS BARANG";
            lblCard1Nilai.Text = totalJenis.ToString("N0", BudayaIndonesia);
            lblCard1Nilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblCard2Judul.Text = "STOK AMAN";
            lblCard2Nilai.Text = totalAman.ToString("N0", BudayaIndonesia);
            lblCard2Nilai.ForeColor = Color.FromArgb(16, 149, 102);

            lblCard3Judul.Text = "STOK MINIMUM";
            lblCard3Nilai.Text = totalMinimum.ToString("N0", BudayaIndonesia);
            lblCard3Nilai.ForeColor = Color.FromArgb(217, 119, 6);

            lblCard4Judul.Text = "STOK HABIS";
            lblCard4Nilai.Text = totalHabis.ToString("N0", BudayaIndonesia);
            lblCard4Nilai.ForeColor = Color.FromArgb(220, 38, 38);

            // Filter Tabel
            string cari = txtCariJumlah.Text.Trim().ToLower();
            string filterStatus = cmbFilterStatus.SelectedItem?.ToString() ?? "Semua Status";

            var hasil = dataAktif.Select(b => new ItemTabelJumlahStok
            {
                Kode = b.Kode,
                Nama = b.Nama,
                Stok = b.Stok,
                StokMinimum = b.StokMinimum,
                Status = TentukanStatusStok(b.Stok, b.StokMinimum)
            }).Where(item =>
            {
                bool cocokCari = string.IsNullOrEmpty(cari) ||
                                 item.Kode.ToLower().Contains(cari) ||
                                 item.Nama.ToLower().Contains(cari);

                bool cocokStatus = true;
                if (filterStatus == "Aman") cocokStatus = item.Status == "AMAN";
                else if (filterStatus == "Minimum") cocokStatus = item.Status == "MINIMUM";
                else if (filterStatus == "Kritis") cocokStatus = item.Status == "KRITIS";
                else if (filterStatus == "Habis") cocokStatus = item.Status == "HABIS";

                return cocokCari && cocokStatus;
            }).OrderBy(item =>
            {
                // Urutan prioritas: Habis (1), Kritis (2), Minimum (3), Aman (4)
                return item.Status switch
                {
                    "HABIS" => 1,
                    "KRITIS" => 2,
                    "MINIMUM" => 3,
                    _ => 4
                };
            }).ThenBy(item => item.Nama).ToList();

            gridJumlahStok.DataSource = null;
            gridJumlahStok.DataSource = hasil;
        }

        private void GridJumlahStok_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = gridJumlahStok;
            if (e.ColumnIndex == colJumlahStok.Index || e.ColumnIndex == colJumlahMin.Index)
            {
                if (e.Value is int angka)
                {
                    e.Value = angka.ToString("N0", BudayaIndonesia);
                    e.FormattingApplied = true;
                }
            }
            else if (e.ColumnIndex == colJumlahStatus.Index && e.CellStyle != null)
            {
                string status = e.Value?.ToString() ?? "";
                e.CellStyle.Font = FontInter.Buat(9.5F, FontStyle.Bold);
                switch (status)
                {
                    case "HABIS":
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                        break;
                    case "KRITIS":
                        e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12);
                        break;
                    case "MINIMUM":
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                        break;
                    case "AMAN":
                        e.CellStyle.ForeColor = Color.FromArgb(16, 149, 102);
                        break;
                }
            }
        }

        private void GridJumlahStok_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridJumlahStok.Rows.Count)
            {
                BukaKartuStokTerpilih();
            }
        }

        private void GridJumlahStok_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BukaKartuStokTerpilih();
            }
        }

        private void BukaKartuStokTerpilih()
        {
            if (gridJumlahStok.CurrentRow?.DataBoundItem is ItemTabelJumlahStok item)
            {
                using FormRiwayatStok formKartu = new FormRiwayatStok(item.Kode);
                formKartu.ShowDialog(this);
                // Muat ulang data jika terjadi perubahan saat di kartu stok
                daftarBarang = PenyimpananData.BacaBarang();
                daftarMutasi = MuatSeluruhRiwayatMutasi();
                TerapkanFilterJumlahStok();
            }
        }

        #endregion

        #region Subhalaman Riwayat Stok

        private List<ItemMutasiStok> MuatSeluruhRiwayatMutasi()
        {
            List<ItemMutasiStok> hasil = new List<ItemMutasiStok>();
            HashSet<string> signatureUnik = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // 1. Data dari RiwayatStok (tercatat dari form kasir / gudang)
            List<RiwayatStok> listRiwayat = PenyimpananData.BacaRiwayatStok();
            foreach (var r in listRiwayat)
            {
                string jenis = NormalisasiJenis(r.Jenis);
                hasil.Add(new ItemMutasiStok
                {
                    Tanggal = r.Tanggal,
                    KodeBarang = r.KodeBarang,
                    NamaBarang = r.NamaBarang,
                    Jenis = jenis,
                    Jumlah = r.Jumlah,
                    Keterangan = !string.IsNullOrWhiteSpace(r.Keterangan) ? r.Keterangan : "-",
                    Pengguna = !string.IsNullOrWhiteSpace(r.Pengguna) ? r.Pengguna : "-"
                });

                // Buat tanda pengenal agar tidak terduplikasi dengan data transaksi / barang masuk / barang keluar
                signatureUnik.Add($"{r.KodeBarang}_{r.Tanggal:yyyyMMddHHmmss}_{r.Jumlah}");
                if (!string.IsNullOrWhiteSpace(r.Keterangan))
                {
                    signatureUnik.Add(r.Keterangan.Trim());
                }
            }

            // 2. Data BarangMasuk jika ada catatan yang belum masuk ke RiwayatStok
            List<BarangMasuk> listMasuk = PenyimpananData.BacaBarangMasuk();
            foreach (var bm in listMasuk)
            {
                if (signatureUnik.Contains(bm.Id) || signatureUnik.Contains($"{bm.KodeBarang}_{bm.Tanggal:yyyyMMddHHmmss}_{bm.Jumlah}"))
                {
                    continue;
                }

                hasil.Add(new ItemMutasiStok
                {
                    Tanggal = bm.Tanggal,
                    KodeBarang = bm.KodeBarang,
                    NamaBarang = bm.NamaBarang,
                    Jenis = "MASUK",
                    Jumlah = bm.Jumlah,
                    Keterangan = !string.IsNullOrWhiteSpace(bm.Pemasok) ? $"{bm.Id} · {bm.Pemasok}" : bm.Id,
                    Pengguna = !string.IsNullOrWhiteSpace(bm.Petugas) ? bm.Petugas : "-"
                });
            }

            // 3. Data BarangKeluar jika ada catatan yang belum masuk ke RiwayatStok
            List<BarangKeluar> listKeluar = PenyimpananData.BacaBarangKeluar();
            foreach (var bk in listKeluar)
            {
                if (signatureUnik.Contains(bk.Id) || signatureUnik.Contains($"{bk.KodeBarang}_{bk.Tanggal:yyyyMMddHHmmss}_{bk.Jumlah}"))
                {
                    continue;
                }

                hasil.Add(new ItemMutasiStok
                {
                    Tanggal = bk.Tanggal,
                    KodeBarang = bk.KodeBarang,
                    NamaBarang = bk.NamaBarang,
                    Jenis = "KELUAR",
                    Jumlah = bk.Jumlah,
                    Keterangan = !string.IsNullOrWhiteSpace(bk.Alasan) ? $"{bk.Id} · {bk.Alasan}" : bk.Id,
                    Pengguna = !string.IsNullOrWhiteSpace(bk.Petugas) ? bk.Petugas : "-"
                });
            }

            // 4. Data DetailTransaksi (Penjualan Kasir) historis lama jika belum ada di RiwayatStok
            List<Transaksi> listTrx = PenyimpananData.BacaTransaksi();
            List<DetailTransaksi> listDetail = PenyimpananData.BacaDetailTransaksi();
            var dictTrx = listTrx.ToDictionary(t => t.Id, t => t);

            foreach (var det in listDetail)
            {
                if (signatureUnik.Contains(det.IdTransaksi))
                {
                    continue;
                }

                DateTime tglTrx = DateTime.MinValue;
                string kasir = "-";
                if (dictTrx.TryGetValue(det.IdTransaksi, out var trx))
                {
                    tglTrx = trx.Tanggal;
                    kasir = trx.Kasir;
                }

                string sig = $"{det.KodeBarang}_{tglTrx:yyyyMMddHHmmss}_{det.Jumlah}";
                if (signatureUnik.Contains(sig))
                {
                    continue;
                }

                hasil.Add(new ItemMutasiStok
                {
                    Tanggal = tglTrx != DateTime.MinValue ? tglTrx : DateTime.Today,
                    KodeBarang = det.KodeBarang,
                    NamaBarang = det.NamaBarang,
                    Jenis = "PENJUALAN",
                    Jumlah = det.Jumlah,
                    Keterangan = $"Transaksi {det.IdTransaksi}",
                    Pengguna = kasir
                });
            }

            return hasil.OrderByDescending(m => m.Tanggal).ToList();
        }

        private static string NormalisasiJenis(string? jenisRaw)
        {
            if (string.IsNullOrWhiteSpace(jenisRaw)) return "MASUK";
            string j = jenisRaw.Trim().ToUpperInvariant();
            if (j.Contains("OPNAME")) return "PENYESUAIAN OPNAME";
            if (j.Contains("MASUK")) return "MASUK";
            if (j.Contains("KELUAR")) return "KELUAR";
            if (j.Contains("JUAL") || j.Contains("PENJUALAN")) return "PENJUALAN";
            return j;
        }

        private void TerapkanFilterRiwayatStok()
        {
            if (dtpMulai.Value.Date > dtpSelesai.Value.Date)
            {
                MessageBox.Show("Tanggal mulai tidak boleh setelah tanggal selesai.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime mulai = dtpMulai.Value.Date;
            DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);
            string cari = txtCariRiwayat.Text.Trim().ToLower();
            string jenisFilter = cmbJenisPergerakan.SelectedItem?.ToString() ?? "Semua Jenis";

            // Saring berdasarkan tanggal, cari, dan jenis
            var hasil = daftarMutasi.Where(m =>
            {
                bool cocokTanggal = m.Tanggal >= mulai && m.Tanggal <= selesai;
                if (!cocokTanggal) return false;

                bool cocokJenis = true;
                if (jenisFilter == "Masuk") cocokJenis = m.Jenis == "MASUK";
                else if (jenisFilter == "Keluar") cocokJenis = m.Jenis == "KELUAR";
                else if (jenisFilter == "Penjualan") cocokJenis = m.Jenis == "PENJUALAN";
                else if (jenisFilter.Contains("Opname", StringComparison.OrdinalIgnoreCase)) cocokJenis = m.Jenis == "PENYESUAIAN OPNAME";
                if (!cocokJenis) return false;

                bool cocokCari = string.IsNullOrEmpty(cari) ||
                                 m.KodeBarang.ToLower().Contains(cari) ||
                                 m.NamaBarang.ToLower().Contains(cari) ||
                                 m.Keterangan.ToLower().Contains(cari) ||
                                 m.Pengguna.ToLower().Contains(cari);

                return cocokCari;
            }).OrderByDescending(m => m.Tanggal).ToList();

            // Hitung 4 Kartu KPI Riwayat Stok (sinkron dengan filter tanggal)
            var mutasiDalamPeriode = daftarMutasi.Where(m => m.Tanggal >= mulai && m.Tanggal <= selesai).ToList();
            int unitMasuk = mutasiDalamPeriode.Where(m => m.Jenis == "MASUK").Sum(m => m.Jumlah);
            int unitKeluar = mutasiDalamPeriode.Where(m => m.Jenis == "KELUAR" || m.Jenis == "PENJUALAN").Sum(m => m.Jumlah);
            int trxMasuk = mutasiDalamPeriode.Count(m => m.Jenis == "MASUK");
            int trxKeluar = mutasiDalamPeriode.Count(m => m.Jenis == "KELUAR" || m.Jenis == "PENJUALAN");

            lblCard1Judul.Text = "TOTAL UNIT MASUK";
            lblCard1Nilai.Text = unitMasuk.ToString("N0", BudayaIndonesia);
            lblCard1Nilai.ForeColor = Color.FromArgb(16, 149, 102);

            lblCard2Judul.Text = "TOTAL UNIT KELUAR";
            lblCard2Nilai.Text = unitKeluar.ToString("N0", BudayaIndonesia);
            lblCard2Nilai.ForeColor = Color.FromArgb(220, 38, 38);

            lblCard3Judul.Text = "TRANSAKSI MASUK";
            lblCard3Nilai.Text = trxMasuk.ToString("N0", BudayaIndonesia);
            lblCard3Nilai.ForeColor = Color.FromArgb(31, 41, 55);

            lblCard4Judul.Text = "TRANSAKSI KELUAR";
            lblCard4Nilai.Text = trxKeluar.ToString("N0", BudayaIndonesia);
            lblCard4Nilai.ForeColor = Color.FromArgb(31, 41, 55);

            gridRiwayatStok.DataSource = null;
            gridRiwayatStok.DataSource = hasil;
        }

        private void GridRiwayatStok_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle == null) return;

            if (e.ColumnIndex == colRiwayatJumlah.Index)
            {
                string val = e.Value?.ToString() ?? "";
                e.CellStyle.Font = FontInter.Buat(9.5F, FontStyle.Bold);
                if (val.StartsWith("+"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(16, 149, 102);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                }
            }
            else if (e.ColumnIndex == colRiwayatJenis.Index)
            {
                string jenis = e.Value?.ToString() ?? "";
                e.CellStyle.Font = FontInter.Buat(9.5F, FontStyle.Bold);
                if (jenis == "MASUK")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(16, 149, 102);
                }
                else if (jenis == "PENJUALAN")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(59, 130, 246);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                }
            }
        }

        private void SimpanLaporanGudangKeJson()
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string namaFile;
                object kontenLaporan;

                if (subHalamanAktif == "jumlah")
                {
                    namaFile = $"laporan_stok_{timestamp}.json";
                    var dataAktif = daftarBarang.Where(b => b.Aktif).ToList();
                    kontenLaporan = new
                    {
                        jenis = "Laporan Stok Barang",
                        dibuat_pada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        dibuat_oleh = Navigasi.PenggunaAktif,
                        total_jenis_barang = dataAktif.Count,
                        total_unit_stok = dataAktif.Sum(b => b.Stok),
                        total_nilai_aset = dataAktif.Sum(b => (long)b.Stok * b.HargaBeli),
                        stok_aman = dataAktif.Count(b => b.Stok > b.StokMinimum),
                        stok_minimum = dataAktif.Count(b => b.Stok == b.StokMinimum && b.StokMinimum > 0),
                        stok_kritis = dataAktif.Count(b => b.Stok > 0 && b.Stok < b.StokMinimum),
                        stok_habis = dataAktif.Count(b => b.Stok == 0),
                        daftar_barang = dataAktif.Select(b => new
                        {
                            kode = b.Kode,
                            nama = b.Nama,
                            kategori = b.Kategori,
                            stok = b.Stok,
                            stok_minimum = b.StokMinimum,
                            harga_beli = b.HargaBeli,
                            harga_jual = b.HargaJual,
                            status = TentukanStatusStok(b.Stok, b.StokMinimum)
                        })
                    };
                }
                else
                {
                    DateTime mulai = dtpMulai.Value.Date;
                    DateTime selesai = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);

                    if (mulai > selesai)
                    {
                        MessageBox.Show("Tanggal mulai tidak boleh setelah tanggal selesai.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    namaFile = $"laporan_gudang_{timestamp}.json";
                    var mutasiDalamPeriode = daftarMutasi.Where(m => m.Tanggal >= mulai && m.Tanggal <= selesai).ToList();

                    kontenLaporan = new
                    {
                        jenis = "Laporan Aktivitas dan Riwayat Stok Gudang",
                        periode_mulai = mulai.ToString("yyyy-MM-dd"),
                        periode_selesai = dtpSelesai.Value.ToString("yyyy-MM-dd"),
                        dibuat_pada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        dibuat_oleh = Navigasi.PenggunaAktif,
                        total_aktivitas = mutasiDalamPeriode.Count,
                        total_unit_masuk = mutasiDalamPeriode.Where(m => m.Jenis == "MASUK").Sum(m => m.Jumlah),
                        total_unit_keluar = mutasiDalamPeriode.Where(m => m.Jenis == "KELUAR" || m.Jenis == "PENJUALAN").Sum(m => m.Jumlah),
                        total_unit_penyesuaian_opname = mutasiDalamPeriode.Where(m => m.Jenis == "PENYESUAIAN OPNAME").Sum(m => m.Jumlah),
                        rincian_mutasi = mutasiDalamPeriode.Select(m => new
                        {
                            tanggal = m.Tanggal.ToString("yyyy-MM-dd HH:mm"),
                            kode_barang = m.KodeBarang,
                            nama_barang = m.NamaBarang,
                            jenis = m.Jenis,
                            jumlah = m.Jumlah,
                            keterangan = m.Keterangan,
                            petugas = m.Pengguna
                        })
                    };
                }

                PenyimpananData.SimpanLaporanJson(namaFile, kontenLaporan);
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Laporan Inventaris", $"Menyimpan {namaFile}");
                MessageBox.Show($"Laporan berhasil disimpan ke file JSON:\n{namaFile}\n\nFolder: laporan/", "Laporan Tersimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan laporan ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }

    #region Data Transfer Classes

    public class ItemTabelJumlahStok
    {
        public string Kode { get; set; } = "";
        public string Nama { get; set; } = "";
        public int Stok { get; set; }
        public int StokMinimum { get; set; }
        public string Status { get; set; } = "";
    }

    public class ItemMutasiStok
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public DateTime Tanggal { get; set; }
        public string TanggalFormat => Tanggal.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia);
        public string KodeBarang { get; set; } = "";
        public string NamaBarang { get; set; } = "";
        public string Jenis { get; set; } = "";
        public int Jumlah { get; set; }
        public string JumlahFormat => (Jenis == "MASUK" ? "+" : "−") + Jumlah.ToString("N0", BudayaIndonesia);
        public string Keterangan { get; set; } = "";
        public string Pengguna { get; set; } = "";
    }

    #endregion
}