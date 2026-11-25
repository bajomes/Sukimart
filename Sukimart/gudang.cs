namespace Sukimart
{
    public partial class FormGudang : Form
    {
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
        private Barang? barangTerpilih;
        private bool hanyaMinimum = false;
        private List<SesiOpname> daftarSesiOpname = new List<SesiOpname>();
        private int activeSubTabIndex = 0;

        public FormGudang() : this("admin")
        {
        }

        public FormGudang(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            SiapkanFormPergerakanStok();
            UIHelper.RatakanTengah(colStok, colMinStok);
            UIHelper.PasangBadgeStatusGrid(gridGudang, colStatus);
            gridGudang.AllowUserToResizeRows = false;
            cmbJenisStok.SelectedIndex = 0;

            dtpOpnameMulai.Value = DateTime.Today.AddDays(-30);
            dtpOpnameSelesai.Value = DateTime.Today;
            if (cmbFilterStatusOpname.Items.Count > 0)
                cmbFilterStatusOpname.SelectedIndex = 0;
            gridSesiOpname.AutoGenerateColumns = false;
            gridRiwayatOpname.AutoGenerateColumns = false;
            gridSesiOpname.AllowUserToResizeRows = false;
            gridRiwayatOpname.AllowUserToResizeRows = false;
            UIHelper.RatakanTengah(colSesiJumlahProduk, colSesiSelisih, colSesiSelisihPositif, colSesiSelisihNegatif, colSesiStatus);
            UIHelper.RatakanTengah(colRiwJumlah, colRiwSelisih, colRiwStatus);

            SesuaikanPeran();
            PasangEventHandlers();
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();
            GantiSubTab(0);
            MuatDataGudang();
        }

        private void AturTataLetakResponsif()
        {
            if (pnlKanan.ClientSize.Width < 500 || pnlKanan.ClientSize.Height < 300) return;

            if (nightControlBox1 != null)
            {
                nightControlBox1.Location = new Point(pnlKanan.ClientSize.Width - nightControlBox1.Width, 0);
                nightControlBox1.BringToFront();
            }

            Size ukuranPanel = new Size(pnlKanan.ClientSize.Width, Math.Max(200, pnlKanan.ClientSize.Height - 115));
            pnlSubStokGudang.Bounds = new Rectangle(new Point(0, 115), ukuranPanel);
            pnlSubStokOpname.Bounds = new Rectangle(new Point(0, 115), ukuranPanel);
            pnlSubRiwayatOpname.Bounds = new Rectangle(new Point(0, 115), ukuranPanel);
        }

        private void SesuaikanPeran()
        {
            if (this.peran == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnLaporanInventaris.Visible = false;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnLaporanInventaris.Visible = true;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
                btnGudang.Visible = true;
            }
            else
            {
                btnKasir.Visible = true;
                btnRiwayat.Visible = true;
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnLaporanInventaris.Visible = true;
                btnPengguna.Visible = true;
                btnLogAktivitas.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        private void GantiSubTab(int tabIndex)
        {
            activeSubTabIndex = tabIndex;

            btnSubStokGudang.BackColor = tabIndex == 0 ? Color.FromArgb(255, 196, 0) : Color.White;
            btnSubStokGudang.ForeColor = tabIndex == 0 ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            btnSubStokGudang.Font = tabIndex == 0 ? FontInter.Buat(10, FontStyle.Bold) : FontInter.Buat(10, FontStyle.Regular);

            btnSubStokOpname.BackColor = tabIndex == 1 ? Color.FromArgb(255, 196, 0) : Color.White;
            btnSubStokOpname.ForeColor = tabIndex == 1 ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            btnSubStokOpname.Font = tabIndex == 1 ? FontInter.Buat(10, FontStyle.Bold) : FontInter.Buat(10, FontStyle.Regular);

            btnSubRiwayatOpname.BackColor = tabIndex == 2 ? Color.FromArgb(255, 196, 0) : Color.White;
            btnSubRiwayatOpname.ForeColor = tabIndex == 2 ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            btnSubRiwayatOpname.Font = tabIndex == 2 ? FontInter.Buat(10, FontStyle.Bold) : FontInter.Buat(10, FontStyle.Regular);

            pnlSubStokGudang.Visible = (tabIndex == 0);
            pnlSubStokOpname.Visible = (tabIndex == 1);
            pnlSubRiwayatOpname.Visible = (tabIndex == 2);
            AturTataLetakResponsif();

            if (tabIndex == 0)
            {
                MuatDataGudang();
            }
            else if (tabIndex == 1)
            {
                MuatDataSesiOpname();
            }
            else if (tabIndex == 2)
            {
                MuatDataRiwayatOpname();
            }
        }

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => { /* Sedang di form gudang */ };
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnLaporanInventaris.Click += (s, e) => Navigasi.BukaLaporanInventaris(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);

            btnSubStokGudang.Click += (s, e) => GantiSubTab(0);
            btnSubStokOpname.Click += (s, e) => GantiSubTab(1);
            btnSubRiwayatOpname.Click += (s, e) => GantiSubTab(2);

            txtCariGudang.TextChanged += (s, e) => FilterDaftarGudang();
            btnFilterMenipis.Click += (s, e) => { hanyaMinimum = true; FilterDaftarGudang(); };
            btnSemuaStok.Click += (s, e) => { hanyaMinimum = false; FilterDaftarGudang(); };
            cmbJenisStok.SelectedIndexChanged += (s, e) => AturInputPergerakanStok();

            gridGudang.SelectionChanged += GridGudang_SelectionChanged;
            btnSimpanStok.Click += BtnSimpanStok_Click;
            btnRiwayatStok.Click += (s, e) =>
            {
                if (barangTerpilih == null)
                {
                    MessageBox.Show("Pilih barang pada tabel terlebih dahulu untuk melihat kartu stok.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using FormRiwayatStok formRiwayat = new FormRiwayatStok(barangTerpilih.Kode);
                formRiwayat.ShowDialog(this);
            };

            // Stok Opname Events
            btnBuatOpnameBaru.Click += BtnBuatOpnameBaru_Click;
            btnBukaOpname.Click += BtnBukaOpname_Click;
            btnBatalkanOpname.Click += BtnBatalkanOpname_Click;
            btnSegarkanOpname.Click += (s, e) => MuatDataSesiOpname();
            txtCariSesi.TextChanged += (s, e) => FilterDataSesiOpname();
            gridSesiOpname.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    BtnBukaOpname_Click(s, e);
                }
            };

            // Riwayat Opname Events
            btnTerapkanFilterRiwayat.Click += (s, e) => FilterDataRiwayatOpname();
            cmbFilterStatusOpname.SelectedIndexChanged += (s, e) => FilterDataRiwayatOpname();
            txtCariRiwayatOpname.TextChanged += (s, e) => FilterDataRiwayatOpname();
            btnBukaDetailRiwayat.Click += BtnBukaDetailRiwayat_Click;
            gridRiwayatOpname.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    BtnBukaDetailRiwayat_Click(s, e);
                }
            };
        }

        private void BtnBuatOpnameBaru_Click(object? sender, EventArgs e)
        {
            if (peran == "kasir")
            {
                MessageBox.Show("Kasir tidak memiliki akses ke fitur Stok Opname.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sesiAktif = PenyimpananData.AmbilSesiOpnameAktif();
            if (sesiAktif != null)
            {
                MessageBox.Show(
                    $"Masih terdapat sesi opname aktif ({sesiAktif.Id}) dengan status '{sesiAktif.Status}'.\n" +
                    "Selesaikan atau batalkan sesi tersebut terlebih dahulu sebelum membuat sesi baru.",
                    "Sesi Opname Aktif",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin memulai sesi Stok Opname baru?\n\n" +
                "Seluruh produk aktif akan dibekukan sementara untuk transaksi kasir dan perubahan stok manual hingga sesi selesai.",
                "Konfirmasi Mulai Opname",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi != DialogResult.Yes) return;

            try
            {
                var sesiBaru = PenyimpananData.BuatSesiOpnameBaru(Navigasi.PenggunaAktif);
                MuatDataSesiOpname();
                using var formDetail = new FormDetailOpname(sesiBaru.Id, peran);
                formDetail.ShowDialog(this);
                MuatDataSesiOpname();
                MuatDataGudang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat sesi opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBukaOpname_Click(object? sender, EventArgs e)
        {
            if (gridSesiOpname.CurrentRow == null || gridSesiOpname.CurrentRow.Tag is not SesiOpname sesi)
            {
                MessageBox.Show("Pilih sesi opname terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var formDetail = new FormDetailOpname(sesi.Id, peran);
            formDetail.ShowDialog(this);
            MuatDataSesiOpname();
            MuatDataGudang();
        }

        private void BtnBatalkanOpname_Click(object? sender, EventArgs e)
        {
            if (gridSesiOpname.CurrentRow == null || gridSesiOpname.CurrentRow.Tag is not SesiOpname sesi)
            {
                MessageBox.Show("Pilih sesi opname yang ingin dibatalkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sesi.Status == "Disetujui" || sesi.Status == "Dibatalkan")
            {
                MessageBox.Show($"Sesi opname {sesi.Id} sudah berstatus '{sesi.Status}' dan tidak dapat dibatalkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (peran == "gudang" && !sesi.DibuatOleh.Equals(Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Gudang hanya dapat membatalkan sesi opname miliknya sendiri.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var formBatal = new FormBatalkanOpname(sesi.Id);
            if (formBatal.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    PenyimpananData.BatalkanSesiOpname(sesi.Id, Navigasi.PenggunaAktif, formBatal.Alasan);
                    MessageBox.Show($"Sesi opname {sesi.Id} berhasil dibatalkan. Kunci stok telah dibuka.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataSesiOpname();
                    MuatDataGudang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membatalkan sesi: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBukaDetailRiwayat_Click(object? sender, EventArgs e)
        {
            if (gridRiwayatOpname.CurrentRow == null || gridRiwayatOpname.CurrentRow.Tag is not SesiOpname sesi)
            {
                MessageBox.Show("Pilih sesi opname pada tabel riwayat terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var formDetail = new FormDetailOpname(sesi.Id, peran);
            formDetail.ShowDialog(this);
        }

        public void MuatDataSesiOpname()
        {
            try
            {
                daftarSesiOpname = PenyimpananData.BacaSesiOpname();
                FilterDataSesiOpname();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat sesi stok opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDataSesiOpname()
        {
            string cari = txtCariSesi.Text.Trim().ToLowerInvariant();
            var hasil = daftarSesiOpname
                .Where(s => s.Status != "Disetujui" && s.Status != "Dibatalkan")
                .Where(s => string.IsNullOrEmpty(cari) ||
                            s.Id.ToLowerInvariant().Contains(cari) ||
                            s.DibuatOleh.ToLowerInvariant().Contains(cari) ||
                            s.Status.ToLowerInvariant().Contains(cari))
                .OrderByDescending(s => s.TanggalDibuat)
                .ToList();

            gridSesiOpname.Rows.Clear();
            foreach (var s in hasil)
            {
                int totalProduk = s.Items.Count;
                int totalSelisih = s.Items.Sum(i => i.Selisih);
                int positif = s.Items.Where(i => i.Selisih > 0).Sum(i => i.Selisih);
                int negatif = s.Items.Where(i => i.Selisih < 0).Sum(i => i.Selisih);

                int rowIndex = gridSesiOpname.Rows.Add(
                    s.Id,
                    s.TanggalDibuat.ToString("dd/MM/yyyy HH:mm"),
                    s.DibuatOleh,
                    totalProduk,
                    (totalSelisih > 0 ? "+" : "") + totalSelisih,
                    positif > 0 ? "+" + positif : "0",
                    negatif < 0 ? negatif.ToString() : "0",
                    s.Status
                );

                gridSesiOpname.Rows[rowIndex].Tag = s;
                FormatStatusSesiBaris(gridSesiOpname.Rows[rowIndex], s.Status, totalSelisih, positif, negatif);
            }
        }

        public void MuatDataRiwayatOpname()
        {
            try
            {
                daftarSesiOpname = PenyimpananData.BacaSesiOpname();
                FilterDataRiwayatOpname();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat stok opname: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDataRiwayatOpname()
        {
            DateTime mulai = dtpOpnameMulai.Value.Date;
            DateTime selesai = dtpOpnameSelesai.Value.Date.AddDays(1).AddTicks(-1);
            string filterStatus = cmbFilterStatusOpname.SelectedItem?.ToString() ?? "Semua Status";
            string cari = txtCariRiwayatOpname.Text.Trim().ToLowerInvariant();

            var hasil = daftarSesiOpname
                .Where(s => s.Status == "Disetujui" || s.Status == "Dibatalkan")
                .Where(s => s.TanggalDibuat >= mulai && s.TanggalDibuat <= selesai)
                .Where(s => filterStatus == "Semua Status" || s.Status.Equals(filterStatus, StringComparison.OrdinalIgnoreCase))
                .Where(s => string.IsNullOrEmpty(cari) ||
                            s.Id.ToLowerInvariant().Contains(cari) ||
                            s.DibuatOleh.ToLowerInvariant().Contains(cari) ||
                            (s.DisetujuiOleh ?? "").ToLowerInvariant().Contains(cari) ||
                            (s.DibatalkanOleh ?? "").ToLowerInvariant().Contains(cari))
                .OrderByDescending(s => s.TanggalSelesai ?? s.TanggalDibuat)
                .ToList();

            gridRiwayatOpname.Rows.Clear();
            foreach (var s in hasil)
            {
                int totalProduk = s.Items.Count;
                int totalSelisih = s.Items.Sum(i => i.Selisih);
                string waktuSelesaiStr = s.TanggalSelesai.HasValue ? s.TanggalSelesai.Value.ToString("dd/MM/yyyy HH:mm") : "-";
                string penyetujuStr = s.Status == "Disetujui" ? (s.DisetujuiOleh ?? "-") : (s.DibatalkanOleh ?? "-");

                int rowIndex = gridRiwayatOpname.Rows.Add(
                    s.Id,
                    s.TanggalDibuat.ToString("dd/MM/yyyy HH:mm"),
                    s.DibuatOleh,
                    penyetujuStr,
                    totalProduk,
                    (totalSelisih > 0 ? "+" : "") + totalSelisih,
                    s.Status,
                    waktuSelesaiStr
                );

                gridRiwayatOpname.Rows[rowIndex].Tag = s;
                FormatStatusSesiBaris(gridRiwayatOpname.Rows[rowIndex], s.Status, totalSelisih, 0, 0);
            }
        }

        private static void FormatStatusSesiBaris(DataGridViewRow row, string status, int totalSelisih, int positif, int negatif)
        {
            // Status coloring
            var cellStatus = row.Cells[row.Cells.Count - (row.DataGridView?.Columns.Contains("colRiwWaktuSelesai") == true ? 2 : 1)];
            if (cellStatus != null)
            {
                switch (status)
                {
                    case "Draft":
                        cellStatus.Style.ForeColor = Color.FromArgb(107, 114, 128);
                        break;
                    case "Menunggu Persetujuan":
                        cellStatus.Style.ForeColor = Color.FromArgb(217, 119, 6);
                        cellStatus.Style.Font = FontInter.Buat(9, FontStyle.Bold);
                        break;
                    case "Perlu Revisi":
                        cellStatus.Style.ForeColor = Color.FromArgb(220, 38, 38);
                        cellStatus.Style.Font = FontInter.Buat(9, FontStyle.Bold);
                        break;
                    case "Disetujui":
                        cellStatus.Style.ForeColor = Color.FromArgb(16, 185, 129);
                        cellStatus.Style.Font = FontInter.Buat(9, FontStyle.Bold);
                        break;
                    case "Dibatalkan":
                        cellStatus.Style.ForeColor = Color.FromArgb(156, 163, 175);
                        break;
                }
            }

            // Selisih coloring
            if (row.DataGridView?.Columns.Contains("colSesiSelisih") == true)
            {
                var cellSelisih = row.Cells["colSesiSelisih"];
                if (totalSelisih > 0)
                {
                    cellSelisih.Style.ForeColor = Color.FromArgb(16, 185, 129);
                    cellSelisih.Style.Font = FontInter.Buat(9, FontStyle.Bold);
                }
                else if (totalSelisih < 0)
                {
                    cellSelisih.Style.ForeColor = Color.FromArgb(220, 38, 38);
                    cellSelisih.Style.Font = FontInter.Buat(9, FontStyle.Bold);
                }
            }
        }

        private void SiapkanFormPergerakanStok()
        {
            AturInputPergerakanStok();
        }

        private void AturInputPergerakanStok()
        {
            bool stokKeluar = cmbJenisStok.SelectedIndex == 1;
            lblPemasok.Visible = !stokKeluar;
            txtPemasok.Visible = !stokKeluar;
            lblAlasan.Visible = stokKeluar;
            cmbAlasan.Visible = stokKeluar;
            txtPemasok.Text = stokKeluar ? "" : txtPemasok.Text;
            cmbAlasan.SelectedIndex = stokKeluar ? cmbAlasan.SelectedIndex : -1;
        }

        public void MuatDataGudang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                FilterDaftarGudang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data stok gudang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDaftarGudang()
        {
            string keyword = txtCariGudang.Text.Trim().ToLower();

            var query = daftarBarang.Where(b => b.Aktif).AsEnumerable();

            if (hanyaMinimum)
            {
                query = query.Where(b => b.Stok <= b.StokMinimum);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(b =>
                    b.Nama.ToLower().Contains(keyword) ||
                    b.Kode.ToLower().Contains(keyword) ||
                    b.Kategori.ToLower().Contains(keyword));
            }

            var hasil = query.ToList();

            gridGudang.AutoGenerateColumns = false;
            gridGudang.DataSource = hasil.Select(b => new
            {
                b.Kode,
                b.Nama,
                b.Kategori,
                b.Stok,
                b.StokMinimum,
                StatusStok = UIHelper.TentukanStatusStok(b.Stok, b.StokMinimum)
            }).ToList();
            gridGudang.ClearSelection();
            barangTerpilih = null;
            txtBarangTerpilih.Clear();
        }

        private void GridGudang_SelectionChanged(object? sender, EventArgs e)
        {
            if (gridGudang.CurrentRow == null || gridGudang.CurrentRow.Index < 0)
            {
                barangTerpilih = null;
                txtBarangTerpilih.Clear();
                return;
            }

            var item = gridGudang.CurrentRow.DataBoundItem;
            if (item == null) return;

            string kode = (string)item.GetType().GetProperty("Kode")?.GetValue(item, null)!;
            barangTerpilih = daftarBarang.FirstOrDefault(b => b.Kode == kode);

            if (barangTerpilih != null)
            {
                txtBarangTerpilih.Text = $"{barangTerpilih.Kode} - {barangTerpilih.Nama} (Stok Saat Ini: {barangTerpilih.Stok})";
            }
        }

        private void BtnSimpanStok_Click(object? sender, EventArgs e)
        {
            if (barangTerpilih == null)
            {
                MessageBox.Show("Pilih barang pada tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (PenyimpananData.ApakahBarangTerkunciOpname(barangTerpilih.Kode, out string nomorOpn))
            {
                MessageBox.Show(
                    $"Produk '{barangTerpilih.Nama}' ({barangTerpilih.Kode}) sedang dalam proses Stok Opname ({nomorOpn}) dan stoknya terkunci.\nPerubahan stok masuk/keluar untuk produk ini tidak diperkenankan sampai sesi opname disetujui atau dibatalkan demi menjaga keakuratan penghitungan fisik.",
                    "Stok Terkunci Opname",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int jumlah = (int)nudJumlahMasuk.Value;
            if (jumlah <= 0)
            {
                MessageBox.Show("Jumlah stok harus lebih dari 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool stokKeluar = cmbJenisStok.SelectedIndex == 1;
            string pemasok = txtPemasok.Text.Trim();
            string alasan = cmbAlasan.SelectedItem?.ToString() ?? "";
            if (!stokKeluar && string.IsNullOrEmpty(pemasok))
            {
                MessageBox.Show("Pemasok wajib diisi untuk barang masuk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPemasok.Focus();
                return;
            }

            if (stokKeluar && string.IsNullOrEmpty(alasan))
            {
                MessageBox.Show("Pilih alasan untuk barang keluar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAlasan.Focus();
                return;
            }

            if (stokKeluar && jumlah > barangTerpilih.Stok)
            {
                MessageBox.Show($"Stok keluar tidak boleh melebihi stok saat ini ({barangTerpilih.Stok}).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stokSebelum = barangTerpilih.Stok;
            int stokSesudah = stokKeluar ? stokSebelum - jumlah : stokSebelum + jumlah;
            string jenis = stokKeluar ? "KELUAR" : "MASUK";
            string id = stokKeluar ? PenyimpananData.BuatIdBarangKeluar() : PenyimpananData.BuatIdBarangMasuk();

            try
            {
                barangTerpilih.Stok = stokSesudah;
                PenyimpananData.SimpanBarang(daftarBarang);
                if (stokKeluar)
                {
                    PenyimpananData.TambahBarangKeluar(new BarangKeluar
                    {
                        Id = id,
                        Tanggal = DateTime.Now,
                        KodeBarang = barangTerpilih.Kode,
                        NamaBarang = barangTerpilih.Nama,
                        Jumlah = jumlah,
                        Alasan = alasan,
                        Keterangan = txtKeterangan.Text.Trim(),
                        Petugas = Navigasi.PenggunaAktif
                    });
                }
                else
                {
                    PenyimpananData.TambahBarangMasuk(new BarangMasuk
                    {
                        Id = id,
                        Tanggal = DateTime.Now,
                        KodeBarang = barangTerpilih.Kode,
                        NamaBarang = barangTerpilih.Nama,
                        Jumlah = jumlah,
                        Pemasok = pemasok,
                        Keterangan = txtKeterangan.Text.Trim(),
                        Petugas = Navigasi.PenggunaAktif
                    });
                }
            }
            catch (Exception ex)
            {
                barangTerpilih.Stok = stokSebelum;
                try
                {
                    PenyimpananData.SimpanBarang(daftarBarang);
                }
                catch
                {
                }
                MessageBox.Show("Gagal menyimpan perubahan stok: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string keteranganRiwayat;
                if (stokKeluar)
                {
                    string ketTambahan = txtKeterangan.Text.Trim();
                    string alasanBersih = alasan.Trim();
                    if (!string.IsNullOrWhiteSpace(alasanBersih) && !string.IsNullOrWhiteSpace(ketTambahan))
                    {
                        keteranganRiwayat = $"{alasanBersih} \u2022 {ketTambahan}";
                    }
                    else if (!string.IsNullOrWhiteSpace(alasanBersih))
                    {
                        keteranganRiwayat = alasanBersih;
                    }
                    else if (!string.IsNullOrWhiteSpace(ketTambahan))
                    {
                        keteranganRiwayat = ketTambahan;
                    }
                    else
                    {
                        keteranganRiwayat = "-";
                    }
                }
                else
                {
                    string ketTambahan = txtKeterangan.Text.Trim();
                    keteranganRiwayat = !string.IsNullOrWhiteSpace(ketTambahan) ? ketTambahan : "-";
                }

                PenyimpananData.TambahRiwayatStok(new RiwayatStok
                {
                    Tanggal = DateTime.Now,
                    KodeBarang = barangTerpilih.Kode,
                    NamaBarang = barangTerpilih.Nama,
                    Jenis = jenis,
                    Jumlah = jumlah,
                    StokSebelum = stokSebelum,
                    StokSesudah = stokSesudah,
                    Pemasok = stokKeluar ? "" : pemasok,
                    Keterangan = keteranganRiwayat,
                    Pengguna = Navigasi.PenggunaAktif
                });
                string jenisLog = stokKeluar ? "Stok Keluar" : "Stok Masuk";
                string detailLog = stokKeluar
                    ? $"{jenis} {id}: '{barangTerpilih.Nama}' ({barangTerpilih.Kode}) keluar sejumlah -{jumlah}. Alasan: '{alasan}'. Stok: {stokSebelum} -> {stokSesudah}."
                    : $"{jenis} {id}: '{barangTerpilih.Nama}' ({barangTerpilih.Kode}) masuk sejumlah +{jumlah} dari '{pemasok}'. Stok: {stokSebelum} -> {stokSesudah}.";
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, jenisLog, detailLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Perubahan stok tersimpan, tetapi riwayat atau log gagal dicatat: " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show(
                $"{jenis} {id} untuk '{barangTerpilih.Nama}' berhasil disimpan.\nStok sekarang: {stokSesudah}",
                "Stok Diperbarui",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            string kodeTerakhir = barangTerpilih.Kode;
            MuatDataGudang();
            PilihBaris(kodeTerakhir);
            nudJumlahMasuk.Value = 10;
            txtPemasok.Clear();
            cmbAlasan.SelectedIndex = -1;
            txtKeterangan.Clear();
        }

        private void PilihBaris(string kode)
        {
            foreach (DataGridViewRow baris in gridGudang.Rows)
            {
                var item = baris.DataBoundItem;
                if (item?.GetType().GetProperty("Kode")?.GetValue(item, null) as string == kode)
                {
                    gridGudang.CurrentCell = baris.Cells[0];
                    return;
                }
            }
        }
    }
}
