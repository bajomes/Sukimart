namespace Sukimart
{
    /// <summary>
    /// FormGudang: Formulir untuk manajemen stok barang, pencatatan mutasi barang masuk (restock),
    /// pencatatan mutasi barang keluar (rusak/kadaluarsa/retur), dan akses kartu stok.
    /// </summary>
    public partial class FormGudang : Form
    {
        // Peran pengguna yang sedang aktif (admin atau gudang)
        private readonly string peran;

        // Data barang dari file barang.json
        private List<Barang> daftarBarang = new List<Barang>();

        // Barang yang sedang dipilih pada tabel
        private Barang? barangTerpilih;

        // Status filter: apakah hanya menampilkan barang yang stoknya menipis/habis
        private bool hanyaMenipis = false;

        public FormGudang() : this("admin")
        {
        }

        public FormGudang(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;

            // Atur perataan teks pada kolom tabel (stok rata tengah)
            UIHelper.RatakanTengah(colStok, colMinStok);
            gridGudang.AllowUserToResizeRows = false;

            // Default jenis mutasi: Stok Masuk (index 0)
            cmbJenisStok.SelectedIndex = 0;

            // Konfigurasi layout panel restock di bagian bawah
            InisialisasiTataLetakRestock();

            // Sesuaikan hak akses navigasi berdasarkan peran
            SesuaikanPeran();

            // Muat data barang dari file barang.json
            MuatDataGudang();
        }

        // =========================================================================
        // PENGATURAN TATA LETAK & HAK AKSES PERAN
        // =========================================================================

        /// <summary>
        /// Menyesuaikan visibilitas tombol navigasi sesuai hak akses pengguna.
        /// </summary>
        private void SesuaikanPeran()
        {
            if (this.peran == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
                btnLogAktivitas.Visible = false;
            }
            else
            {
                btnKasir.Visible = true;
                btnRiwayat.Visible = true;
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
                btnLogAktivitas.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        /// <summary>
        /// Mengatur tata letak responsif untuk panel input pergerakan stok.
        /// </summary>
        private void InisialisasiTataLetakRestock()
        {
            pnlRestock.Height = 152;
            txtKeterangan.Location = new Point(24, 116);
            txtKeterangan.Size = new Size(768, 23);
            lblKeterangan.Location = new Point(24, 92);
            lblKeterangan.Text = "Keterangan";
            txtKeterangan.PlaceholderText = "Opsional";
            btnSimpanStok.Location = new Point(808, 104);

            AturTataLetakPergerakanStok();
            pnlKanan.Resize += (s, e) => AturTataLetakPergerakanStok();
            AturInputPergerakanStok();
        }

        /// <summary>
        /// Menyesuaikan ukuran dan posisi panel pergerakan stok agar proporsional saat form di-resize.
        /// </summary>
        private void AturTataLetakPergerakanStok()
        {
            int margin = 40;
            int lebar = pnlKanan.ClientSize.Width - (margin * 2);
            int tinggiPanel = pnlRestock.Height;
            int yPanel = pnlKanan.ClientSize.Height - margin - tinggiPanel;

            pnlRestock.Location = new Point(margin, yPanel);
            pnlRestock.Size = new Size(lebar, tinggiPanel);
            gridGudang.Size = new Size(lebar, Math.Max(160, yPanel - gridGudang.Top - 24));
            btnSimpanStok.Location = new Point(Math.Max(808, lebar - 152), 104);

            int lebarInput = Math.Max(160, btnSimpanStok.Left - 624);
            txtPemasok.Size = new Size(lebarInput, 23);
            cmbAlasan.Size = new Size(lebarInput, 24);
            txtKeterangan.Size = new Size(Math.Max(300, btnSimpanStok.Left - 40), 23);
        }

        /// <summary>
        /// Mengatur kontrol input sesuai jenis mutasi:
        /// - Jika "Stok Masuk": menampilkan input Pemasok.
        /// - Jika "Stok Keluar": menampilkan dropdown Alasan (RUSAK, KADALUARSA, RETUR, LAINNYA).
        /// </summary>
        private void AturInputPergerakanStok()
        {
            bool stokKeluar = cmbJenisStok.SelectedIndex == 1;

            lblPemasok.Visible = !stokKeluar;
            txtPemasok.Visible = !stokKeluar;

            lblAlasan.Visible = stokKeluar;
            cmbAlasan.Visible = stokKeluar;

            if (stokKeluar)
            {
                txtPemasok.Text = "";
            }
            else
            {
                cmbAlasan.SelectedIndex = -1;
            }
        }

        // =========================================================================
        // EVENT HANDLER NAVIGASI SIDEBAR
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
            // Sedang di form gudang
        }

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
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
        // EVENT HANDLER KONTROL FORM GUDANG
        // =========================================================================

        // Pencarian live saat teks pada kolom cari berubah
        private void txtCariGudang_TextChanged(object? sender, EventArgs e)
        {
            FilterDaftarGudang();
        }

        // Tombol filter untuk hanya menampilkan barang stok menipis/habis (Kasus Uji 18)
        private void btnFilterMenipis_Click(object? sender, EventArgs e)
        {
            hanyaMenipis = true;
            FilterDaftarGudang();
        }

        // Tombol filter untuk menampilkan seluruh barang
        private void btnSemuaStok_Click(object? sender, EventArgs e)
        {
            hanyaMenipis = false;
            FilterDaftarGudang();
        }

        // Beralih jenis mutasi antara "Stok Masuk" dan "Stok Keluar"
        private void cmbJenisStok_SelectedIndexChanged(object? sender, EventArgs e)
        {
            AturInputPergerakanStok();
        }

        // Membuka form Kartu Stok untuk barang yang sedang dipilih (Kasus Uji 15)
        private void btnRiwayatStok_Click(object? sender, EventArgs e)
        {
            if (barangTerpilih == null)
            {
                MessageBox.Show("Pilih barang pada tabel terlebih dahulu untuk melihat kartu stok.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using FormRiwayatStok formRiwayat = new FormRiwayatStok(barangTerpilih.Kode);
            formRiwayat.ShowDialog(this);
        }

        // Event saat baris pada tabel gudang dipilih oleh pengguna
        private void gridGudang_SelectionChanged(object? sender, EventArgs e)
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

        // =========================================================================
        // LOGIKA PENYIMPANAN MUTASI STOK (BARANG MASUK / BARANG KELUAR)
        // =========================================================================

        /// <summary>
        /// Menyimpan mutasi stok masuk atau keluar sesuai input pengguna,
        /// memperbarui stok barang, mencatat kartu stok, dan mencatat log aktivitas.
        /// </summary>
        private void btnSimpanStok_Click(object? sender, EventArgs e)
        {
            // Validasi: Harus memilih barang dari tabel terlebih dahulu
            if (barangTerpilih == null)
            {
                MessageBox.Show("Pilih barang pada tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi: Jumlah harus lebih dari 0
            int jumlah = (int)nudJumlahMasuk.Value;
            if (jumlah <= 0)
            {
                MessageBox.Show("Jumlah stok harus lebih dari 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool stokKeluar = cmbJenisStok.SelectedIndex == 1;
            string pemasok = txtPemasok.Text.Trim();
            string alasan = cmbAlasan.SelectedItem?.ToString() ?? "";

            // Validasi Kasus Uji 13: Pemasok wajib diisi saat barang masuk
            if (!stokKeluar && string.IsNullOrEmpty(pemasok))
            {
                MessageBox.Show("Pemasok wajib diisi untuk barang masuk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPemasok.Focus();
                return;
            }

            // Validasi Kasus Uji 14: Alasan wajib dipilih saat barang keluar
            if (stokKeluar && string.IsNullOrEmpty(alasan))
            {
                MessageBox.Show("Pilih alasan untuk barang keluar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAlasan.Focus();
                return;
            }

            // Validasi Kasus Uji 14: Jumlah barang keluar tidak boleh melebihi stok yang ada
            if (stokKeluar && jumlah > barangTerpilih.Stok)
            {
                MessageBox.Show($"Stok keluar tidak boleh melebihi stok saat ini ({barangTerpilih.Stok}).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hitung stok sebelum dan sesudah mutasi
            int stokSebelum = barangTerpilih.Stok;
            int stokSesudah = stokKeluar ? stokSebelum - jumlah : stokSebelum + jumlah;
            string jenis = stokKeluar ? "KELUAR" : "MASUK";
            string id = stokKeluar ? PenyimpananData.BuatIdBarangKeluar() : PenyimpananData.BuatIdBarangMasuk();

            // 1. Perbarui stok barang di barang.json dan simpan berkas mutasi
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
                // Rollback nilai stok jika penyimpanan gagal
                barangTerpilih.Stok = stokSebelum;
                try { PenyimpananData.SimpanBarang(daftarBarang); } catch { }
                MessageBox.Show("Gagal menyimpan perubahan stok: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Catat ke Kartu Stok (riwayat_stok.json) dan Log Aktivitas (log_aktivitas.json)
            try
            {
                PenyimpananData.TambahRiwayatStok(new RiwayatStok
                {
                    Tanggal = DateTime.Now,
                    KodeBarang = barangTerpilih.Kode,
                    NamaBarang = barangTerpilih.Nama,
                    Jenis = jenis,
                    Jumlah = jumlah,
                    StokSebelum = stokSebelum,
                    StokSesudah = stokSesudah,
                    Keterangan = stokKeluar ? $"{id} · {alasan}" : $"{id} · {pemasok}",
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

            // Tampilkan pesan sukses kepada pengguna
            MessageBox.Show(
                $"{jenis} {id} untuk '{barangTerpilih.Nama}' berhasil disimpan.\nStok sekarang: {stokSesudah}",
                "Stok Diperbarui",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Muat ulang data tabel dan reset kolom input
            string kodeTerakhir = barangTerpilih.Kode;
            MuatDataGudang();
            PilihBaris(kodeTerakhir);
            nudJumlahMasuk.Value = 10;
            txtPemasok.Clear();
            cmbAlasan.SelectedIndex = -1;
            txtKeterangan.Clear();
        }

        // =========================================================================
        // PENGAMBILAN & PENYARINGAN DATA
        // =========================================================================

        /// <summary>
        /// Memuat seluruh data barang dari file barang.json dan menerapkan filter.
        /// </summary>
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

        /// <summary>
        /// Menyaring daftar barang berdasarkan kata kunci pencarian dan status stok minimum/habis.
        /// </summary>
        private void FilterDaftarGudang()
        {
            string keyword = txtCariGudang.Text.Trim().ToLower();
            var query = daftarBarang.AsEnumerable();

            // Filter status stok menipis jika tombol "Stok Menipis" aktif
            if (hanyaMenipis)
            {
                query = query.Where(b => b.Stok <= b.StokMinimum);
            }

            // Filter kata kunci pencarian (nama, kode, atau kategori barang)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(b =>
                    b.Nama.ToLower().Contains(keyword) ||
                    b.Kode.ToLower().Contains(keyword) ||
                    b.Kategori.ToLower().Contains(keyword));
            }

            var hasil = query.ToList();

            // Tampilkan ke DataGridView dengan status: HABIS, MINIMUM, atau AMAN
            gridGudang.AutoGenerateColumns = false;
            gridGudang.DataSource = hasil.Select(b => new
            {
                b.Kode,
                b.Nama,
                b.Kategori,
                b.Stok,
                b.StokMinimum,
                StatusStok = b.Stok == 0 ? "HABIS" : b.Stok <= b.StokMinimum ? "MINIMUM" : "AMAN"
            }).ToList();

            gridGudang.ClearSelection();
            barangTerpilih = null;
            txtBarangTerpilih.Clear();
        }

        /// <summary>
        /// Memilih baris tertentu pada tabel gudang berdasarkan kode barang.
        /// </summary>
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
