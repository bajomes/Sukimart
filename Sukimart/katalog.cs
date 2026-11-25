using System.Globalization;

namespace Sukimart
{
    public partial class FormKatalog : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
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
            UIHelper.RatakanTengah(colStok, colStokMin);
            UIHelper.PasangBadgeStatusGrid(gridBarang, colStatus);
            gridBarang.AllowUserToResizeRows = false;
            SesuaikanPeran();
            PasangEventHandlers();
            UbahTabKatalog("aktif");
            MuatDataBarang();
        }

        private void SesuaikanPeran()
        {
            bool isAdmin = this.peran == "admin";
            bool bolehKelola = this.peran != "kasir";

            btnTabAktif.Visible = isAdmin;
            btnTabNonaktif.Visible = isAdmin;
            if (!isAdmin)
            {
                txtCari.Width = gridBarang.Right - txtCari.Left;
                tabAktif = "aktif";
            }

            btnTambahItem.Visible = bolehKelola;
            btnEditProduk.Visible = bolehKelola;
            btnKelolaKategori.Visible = bolehKelola;

            // Tombol aksi (Hapus / Aktifkan) HANYA untuk Admin
            btnHapusBarang.Visible = isAdmin;

            if (!bolehKelola)
            {
                gridBarang.Height += btnTambahItem.Bottom - gridBarang.Bottom;
            }

            if (this.peran == "kasir")
            {
                colHargaBeli.Visible = false;
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnLaporanInventaris.Visible = false;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                colHargaBeli.Visible = true;
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
                colHargaBeli.Visible = true;
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

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => { /* Sedang di form katalog */ };
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnLaporanInventaris.Click += (s, e) => Navigasi.BukaLaporanInventaris(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);

            btnTabAktif.Click += (s, e) => UbahTabKatalog("aktif");
            btnTabNonaktif.Click += (s, e) => UbahTabKatalog("nonaktif");

            txtCari.TextChanged += (s, e) => FilterDaftarBarang();

            btnTambahItem.Click += BtnTambahItem_Click;
            btnEditProduk.Click += BtnEditProduk_Click;
            btnHapusBarang.Click += BtnHapusBarang_Click;
            btnKelolaKategori.Click += BtnKelolaKategori_Click;
            gridBarang.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && btnEditProduk.Visible)
                {
                    BtnEditProduk_Click(s, e);
                }
            };
        }

        private void UbahTabKatalog(string tab)
        {
            if (this.peran != "admin")
            {
                tab = "aktif";
            }

            tabAktif = tab;
            bool isAktif = tabAktif == "aktif";

            AturTombolTab(btnTabAktif, "Barang Aktif", isAktif);
            AturTombolTab(btnTabNonaktif, "Barang Nonaktif", !isAktif);

            if (isAktif)
            {
                btnHapusBarang.Text = "Hapus Barang";
                btnHapusBarang.ForeColor = Color.FromArgb(220, 38, 38);
                btnHapusBarang.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
                btnHapusBarang.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 242, 242);
            }
            else
            {
                btnHapusBarang.Text = "Aktifkan Barang";
                btnHapusBarang.ForeColor = Color.FromArgb(16, 149, 102);
                btnHapusBarang.FlatAppearance.BorderColor = Color.FromArgb(167, 243, 208);
                btnHapusBarang.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 253, 245);
            }

            FilterDaftarBarang();
        }

        private static void AturTombolTab(Button tombol, string teks, bool aktif)
        {
            tombol.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
            tombol.Cursor = Cursors.Hand;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            tombol.FlatAppearance.BorderSize = aktif ? 0 : 1;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.Font = FontInter.Buat(9.5F, aktif ? FontStyle.Bold : FontStyle.Regular);
            tombol.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
            tombol.Text = teks;
        }

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
                b.StokMinimum,
                StatusStok = UIHelper.TentukanStatusStok(b.Stok, b.StokMinimum)
            }).ToList();
            gridBarang.ClearSelection();
        }

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

        private void BtnTambahItem_Click(object? sender, EventArgs e)
        {
            using FormTambahBarang formTambah = new FormTambahBarang(daftarBarang, null);
            bool tersimpan = formTambah.ShowDialog(this) == DialogResult.OK || !string.IsNullOrEmpty(formTambah.KodeTersimpan);
            MuatDataBarang();
            if (tersimpan && !string.IsNullOrEmpty(formTambah.KodeTersimpan))
            {
                PilihBarang(formTambah.KodeTersimpan);
            }
        }

        private void BtnKelolaKategori_Click(object? sender, EventArgs e)
        {
            string kategoriAwal = BarangTerpilih()?.Kategori ?? "";
            using FormKelolaKategori formKategori = new FormKelolaKategori(kategoriAwal);
            formKategori.ShowDialog(this);
            MuatDataBarang();
        }

        private void BtnEditProduk_Click(object? sender, EventArgs e)
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

        private void BtnHapusBarang_Click(object? sender, EventArgs e)
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

        private void ProsesHapusAtauNonaktifkanBarang(Barang barang)
        {
            if (PenyimpananData.ApakahBarangTerkunciOpname(barang.Kode, out string nomorOpn))
            {
                MessageBox.Show(
                    $"Produk '{barang.Nama}' ({barang.Kode}) sedang dalam proses Stok Opname ({nomorOpn}) dan tidak dapat dihapus atau dinonaktifkan sampai sesi opname selesai.",
                    "Stok Terkunci Opname",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah barang pernah terjual (ada di detail transaksi)
            List<DetailTransaksi> daftarDetail = PenyimpananData.BacaDetailTransaksi();
            bool pernahTerjual = daftarDetail.Any(d => d.KodeBarang == barang.Kode);

            // Cek apakah barang pernah ada riwayat stok (barang masuk/keluar)
            List<RiwayatStok> daftarRiwayat = PenyimpananData.BacaRiwayatStok();
            bool adaRiwayatStok = daftarRiwayat.Any(r => r.KodeBarang == barang.Kode);

            bool adaBarangMasuk = PenyimpananData.BacaBarangMasuk().Any(m => m.KodeBarang == barang.Kode);
            bool adaBarangKeluar = PenyimpananData.BacaBarangKeluar().Any(k => k.KodeBarang == barang.Kode);

            bool adaCatatan = pernahTerjual || adaRiwayatStok || adaBarangMasuk || adaBarangKeluar;

            if (adaCatatan)
            {
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
                            $"Menghapus barang '{barang.Nama}' ({barang.Kode}) dari katalog (Kategori: {barang.Kategori}, Stok: {barang.Stok})."
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

        private void ProsesAktifkanBarang(Barang barang)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin mengaktifkan kembali barang ini?",
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
    }
}
