using System.Globalization;

namespace Sukimart
{
    /// <summary>
    /// FormKatalog: Formulir untuk melihat daftar katalog produk, melakukan pencarian barang,
    /// menambah produk baru, mengedit data produk, menghapus/menonaktifkan produk, dan mengelola kategori.
    /// Mendukung pemisahan tab Barang Aktif dan Barang Nonaktif serta harga beli untuk Admin.
    /// </summary>
    public partial class FormKatalog : Form
    {
        // Format angka dan mata uang Indonesia (Rp x.xxx)
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        // Peran pengguna yang sedang login (admin, kasir, atau gudang)
        private readonly string peran;

        // Daftar produk yang dimuat dari file barang.json
        private List<Barang> daftarBarang = new List<Barang>();

        // Status tab katalog yang sedang aktif ("aktif" atau "nonaktif")
        private string tabAktif = "aktif";

        public FormKatalog() : this(Navigasi.PeranAktif)
        {
        }

        public FormKatalog(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;

            // Atur perataan teks pada kolom stok tabel (rata tengah)
            UIHelper.RatakanTengah(colStok, colStokMin);
            gridBarang.AllowUserToResizeRows = false;

            // Pasang event double click pada tabel dengan metode bernama eksplisit (bebas lambda)
            gridBarang.CellDoubleClick += gridBarang_CellDoubleClick;

            // Sesuaikan hak akses tombol berdasarkan peran pengguna
            SesuaikanPeran();

            // Muat data barang dari file barang.json
            MuatDataBarang();
        }

        // =========================================================================
        // PENGATURAN HAK AKSES PERAN
        // =========================================================================

        /// <summary>
        /// Menyesuaikan visibilitas dan hak akses tombol berdasarkan peran pengguna:
        /// - Admin: Dapat menambah, mengedit, menghapus/menonaktifkan barang, melihat tab aktif/nonaktif, dan melihat Harga Beli.
        /// - Gudang: Dapat menambah, mengedit, mengelola kategori, dan melihat Harga Beli.
        /// - Kasir: Hanya memiliki akses baca harga jual dan stok; Harga Beli disembunyikan.
        /// </summary>
        private void SesuaikanPeran()
        {
            bool isAdmin = this.peran == "admin";
            bool bolehKelola = this.peran != "kasir";

            // Tab Aktif / Nonaktif hanya ditampilkan untuk Admin
            btnTabAktif.Visible = isAdmin;
            btnTabNonaktif.Visible = isAdmin;
            if (!isAdmin)
            {
                txtCari.Width = gridBarang.Width;
                tabAktif = "aktif";
            }

            btnTambahItem.Visible = bolehKelola;
            btnEditProduk.Visible = bolehKelola;
            btnKelolaKategori.Visible = bolehKelola;

            // Tombol aksi Hapus / Aktifkan hanya untuk Admin
            btnHapusBarang.Visible = isAdmin;

            // Jika kasir, perlebar tabel hingga ke bawah karena tombol aksi disembunyikan
            if (!bolehKelola)
            {
                gridBarang.Height += btnTambahItem.Bottom - gridBarang.Bottom;
            }

            // Atur visibilitas kolom Harga Beli: kasir tidak boleh melihat modal/harga beli
            if (this.peran == "kasir")
            {
                colHargaBeli.Visible = false;
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                colHargaBeli.Visible = true;
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
                btnLogAktivitas.Visible = false;
            }
            else
            {
                colHargaBeli.Visible = true;
                btnKasir.Visible = true;
                btnRiwayat.Visible = true;
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
                btnLogAktivitas.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        // =========================================================================
        // TAB FILTER AKTIF / NONAKTIF
        // =========================================================================

        // Event handler klik tab Barang Aktif
        private void btnTabAktif_Click(object? sender, EventArgs e)
        {
            UbahTabKatalog("aktif");
        }

        // Event handler klik tab Barang Nonaktif
        private void btnTabNonaktif_Click(object? sender, EventArgs e)
        {
            UbahTabKatalog("nonaktif");
        }

        /// <summary>
        /// Mengubah tampilan tab katalog antara barang aktif dan barang nonaktif,
        /// serta memperbarui teks dan warna tombol aksi hapus/aktifkan.
        /// </summary>
        private void UbahTabKatalog(string tab)
        {
            if (this.peran != "admin")
            {
                tab = "aktif";
            }

            tabAktif = tab;
            bool isAktif = tabAktif == "aktif";

            AturTombolTab(btnTabAktif, "Barang Aktif", isAktif);
            AturTombolTab(btnTabNonaktif, "Nonaktif", !isAktif);

            if (isAktif)
            {
                btnHapusBarang.Text = "Hapus";
                btnHapusBarang.ForeColor = Color.FromArgb(220, 38, 38);
                btnHapusBarang.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            }
            else
            {
                btnHapusBarang.Text = "Aktifkan";
                btnHapusBarang.ForeColor = Color.FromArgb(16, 149, 102);
                btnHapusBarang.FlatAppearance.BorderColor = Color.FromArgb(167, 243, 208);
            }

            FilterDaftarBarang();
        }

        // Mengatur gaya visual tombol tab terpilih dan tidak terpilih
        private static void AturTombolTab(Button tombol, string teks, bool aktif)
        {
            tombol.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
            tombol.Cursor = Cursors.Hand;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            tombol.FlatAppearance.BorderSize = aktif ? 0 : 1;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.Font = new Font("Inter", 9.5F, aktif ? FontStyle.Bold : FontStyle.Regular);
            tombol.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(107, 114, 128);
            tombol.Text = teks;
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
            // Sedang di form katalog
        }

        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
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
        // EVENT HANDLER KONTROL FORM KATALOG
        // =========================================================================

        // Double click pada baris tabel untuk mengedit data produk terpilih
        private void gridBarang_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && btnEditProduk.Visible)
            {
                btnEditProduk_Click(sender, e);
            }
        }

        // Pencarian live saat teks pada kotak cari berubah (nama, kode, atau kategori)
        private void txtCari_TextChanged(object? sender, EventArgs e)
        {
            FilterDaftarBarang();
        }

        // Membuka form tambah item baru
        private void btnTambahItem_Click(object? sender, EventArgs e)
        {
            using FormTambahBarang formTambah = new FormTambahBarang(daftarBarang, null);
            bool tersimpan = formTambah.ShowDialog(this) == DialogResult.OK || !string.IsNullOrEmpty(formTambah.KodeTersimpan);
            MuatDataBarang();
            if (tersimpan && !string.IsNullOrEmpty(formTambah.KodeTersimpan))
            {
                PilihBarang(formTambah.KodeTersimpan);
            }
        }

        // Membuka form edit produk untuk barang yang sedang dipilih
        private void btnEditProduk_Click(object? sender, EventArgs e)
        {
            Barang? barang = BarangTerpilih();
            if (barang == null)
            {
                MessageBox.Show("Pilih barang dari tabel yang ingin diedit terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridBarang.Focus();
                return;
            }

            using FormTambahBarang formEdit = new FormTambahBarang(daftarBarang, barang);
            bool tersimpan = formEdit.ShowDialog(this) == DialogResult.OK;
            MuatDataBarang();
            if (tersimpan)
            {
                PilihBarang(formEdit.KodeTersimpan);
            }
        }

        // Membuka form kelola kategori produk
        private void btnKelolaKategori_Click(object? sender, EventArgs e)
        {
            string kategoriAwal = BarangTerpilih()?.Kategori ?? "";
            using FormKelolaKategori formKategori = new FormKelolaKategori(kategoriAwal);
            formKategori.ShowDialog(this);
            MuatDataBarang();
        }

        /// <summary>
        /// Menangani aksi tombol Hapus / Aktifkan Barang:
        /// - Jika pada tab aktif: Jika produk sudah pernah terjual atau ada riwayat mutasi gudang,
        ///   aplikasi menawarkan opsi untuk menonaktifkan produk agar data audit tetap utuh (Kasus Uji 12).
        ///   Jika produk belum memiliki catatan, produk dapat dihapus permanen.
        /// - Jika pada tab nonaktif: Mengaktifkan kembali produk agar dapat dijual di kasir.
        /// </summary>
        private void btnHapusBarang_Click(object? sender, EventArgs e)
        {
            if (this.peran != "admin")
            {
                MessageBox.Show("Hanya Admin yang memiliki hak akses untuk tindakan ini.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Barang? barang = BarangTerpilih();
            if (barang == null)
            {
                string pesanPilih = tabAktif == "aktif"
                    ? "Pilih barang dari tabel yang ingin dihapus terlebih dahulu."
                    : "Pilih barang dari tabel yang ingin diaktifkan terlebih dahulu.";
                MessageBox.Show(pesanPilih, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridBarang.Focus();
                return;
            }

            if (tabAktif == "aktif")
            {
                ProsesHapusAtauNonaktifkanBarang(barang);
            }
            else
            {
                ProsesAktifkanBarang(barang);
            }
        }

        // Memproses penghapusan atau penonaktifan barang yang sedang aktif
        private void ProsesHapusAtauNonaktifkanBarang(Barang barang)
        {
            // 1. Cek apakah barang pernah terjual di detail transaksi (Kasus Uji 12)
            List<DetailTransaksi> daftarDetail = PenyimpananData.BacaDetailTransaksi();
            bool pernahTerjual = daftarDetail.Any(d => d.KodeBarang == barang.Kode);

            // 2. Cek apakah barang pernah ada riwayat mutasi di kartu stok gudang
            List<RiwayatStok> daftarRiwayat = PenyimpananData.BacaRiwayatStok();
            bool adaRiwayatStok = daftarRiwayat.Any(r => r.KodeBarang == barang.Kode);

            bool adaBarangMasuk = PenyimpananData.BacaBarangMasuk().Any(m => m.KodeBarang == barang.Kode);
            bool adaBarangKeluar = PenyimpananData.BacaBarangKeluar().Any(k => k.KodeBarang == barang.Kode);

            bool adaCatatan = pernahTerjual || adaRiwayatStok || adaBarangMasuk || adaBarangKeluar;

            if (adaCatatan)
            {
                // Tawarkan penonaktifan barang untuk menjaga integritas riwayat
                DialogResult pilihan = MessageBox.Show(
                    "Tidak bisa dihapus, produk ini sudah ada catatan transaksi, apakah kamu ingin menonaktifkan barang?",
                    "Konfirmasi Nonaktifkan",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (pilihan == DialogResult.Yes)
                {
                    try
                    {
                        barang.Aktif = false;
                        PenyimpananData.SimpanBarang(daftarBarang);
                        try
                        {
                            PenyimpananData.CatatAktivitas(
                                Navigasi.PenggunaAktif,
                                "Nonaktifkan Barang",
                                $"Menonaktifkan barang '{barang.Nama}' ({barang.Kode})."
                            );
                        }
                        catch { }

                        MessageBox.Show($"Barang '{barang.Nama}' berhasil dinonaktifkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MuatDataBarang();
                    }
                    catch (Exception ex)
                    {
                        barang.Aktif = true;
                        MessageBox.Show("Gagal menonaktifkan barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }

            // Jika belum memiliki riwayat: Hapus permanen
            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus barang '{barang.Nama}' ({barang.Kode})?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                int posisi = daftarBarang.IndexOf(barang);
                try
                {
                    daftarBarang.Remove(barang);
                    PenyimpananData.SimpanBarang(daftarBarang);

                    try
                    {
                        PenyimpananData.CatatAktivitas(
                            Navigasi.PenggunaAktif,
                            "Hapus Barang",
                            $"Menghapus barang '{barang.Nama}' ({barang.Kode}) dari katalog."
                        );
                    }
                    catch { }

                    MessageBox.Show("Barang berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataBarang();
                }
                catch (Exception ex)
                {
                    daftarBarang.Insert(posisi, barang);
                    MessageBox.Show("Gagal menghapus barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Mengaktifkan kembali barang nonaktif agar dapat dijual kembali
        private void ProsesAktifkanBarang(Barang barang)
        {
            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin mengaktifkan kembali barang '{barang.Nama}' ({barang.Kode})?",
                "Konfirmasi Aktifkan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    barang.Aktif = true;
                    PenyimpananData.SimpanBarang(daftarBarang);
                    try
                    {
                        PenyimpananData.CatatAktivitas(
                            Navigasi.PenggunaAktif,
                            "Aktifkan Barang",
                            $"Mengaktifkan kembali barang '{barang.Nama}' ({barang.Kode})."
                        );
                    }
                    catch { }

                    MessageBox.Show($"Barang '{barang.Nama}' berhasil diaktifkan kembali.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataBarang();
                }
                catch (Exception ex)
                {
                    barang.Aktif = false;
                    MessageBox.Show("Gagal mengaktifkan barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // PENGAMBILAN & PENYARINGAN DATA
        // =========================================================================

        /// <summary>
        /// Membaca data barang dari file barang.json dan memperbarui tabel.
        /// </summary>
        public void MuatDataBarang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                FilterDaftarBarang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca data katalog: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Menyaring daftar barang berdasarkan tab aktif/nonaktif dan kata kunci pencarian.
        /// </summary>
        private void FilterDaftarBarang()
        {
            string keyword = txtCari.Text.Trim().ToLower();
            bool tampilkanAktif = (this.peran != "admin") || (tabAktif == "aktif");

            var hasil = daftarBarang.Where(b => b.Aktif == tampilkanAktif);

            if (!string.IsNullOrEmpty(keyword))
            {
                hasil = hasil.Where(b =>
                    (b.Nama ?? "").ToLower().Contains(keyword) ||
                    (b.Kode ?? "").ToLower().Contains(keyword) ||
                    (b.Kategori ?? "").ToLower().Contains(keyword));
            }

            var listHasil = hasil.ToList();

            gridBarang.AutoGenerateColumns = false;
            gridBarang.DataSource = listHasil.Select(b => new
            {
                b.Kode,
                b.Nama,
                b.Kategori,
                HargaBeliFormat = "Rp " + b.HargaBeli.ToString("N0", BudayaIndonesia),
                b.HargaBeli,
                HargaFormat = "Rp " + b.Harga.ToString("N0", BudayaIndonesia),
                b.Harga,
                b.Stok,
                b.StokMinimum
            }).ToList();
            gridBarang.ClearSelection();
        }

        /// <summary>
        /// Mengembalikan objek Barang yang sedang dipilih pada baris DataGridView.
        /// </summary>
        private Barang? BarangTerpilih()
        {
            if (gridBarang.SelectedRows.Count == 0)
            {
                return null;
            }

            object? item = gridBarang.SelectedRows[0].DataBoundItem;
            string? kode = item?.GetType().GetProperty("Kode")?.GetValue(item, null) as string;
            return daftarBarang.FirstOrDefault(b => b.Kode == kode);
        }

        /// <summary>
        /// Memilih dan menyorot baris tertentu pada tabel berdasarkan kode barang.
        /// </summary>
        private void PilihBarang(string kode)
        {
            gridBarang.ClearSelection();
            foreach (DataGridViewRow baris in gridBarang.Rows)
            {
                object? item = baris.DataBoundItem;
                if (item?.GetType().GetProperty("Kode")?.GetValue(item, null) as string == kode)
                {
                    baris.Selected = true;
                    gridBarang.CurrentCell = baris.Cells[0];
                    break;
                }
            }
        }
    }
}
