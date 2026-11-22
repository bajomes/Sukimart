using System.Globalization;
using System.Text.RegularExpressions;

namespace Sukimart
{
    /// <summary>
    /// FormPengguna: Formulir untuk manajemen akun pengguna (Khusus Administrator).
    /// Mengelola CRUD akun (tambah pengguna baru, edit nama/peran/status, reset kata sandi,
    /// serta proteksi akun admin aktif).
    /// </summary>
    public partial class FormPengguna : Form
    {
        // Format tanggal dan budaya Indonesia
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        // Daftar akun yang dimuat dari pengguna.json
        private List<Pengguna> daftarPengguna = new List<Pengguna>();

        // Menyimpan nama pengguna yang sedang dipilih dari tabel untuk diedit
        private string? penggunaTerpilih;

        public FormPengguna()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            UIHelper.SusunTombolSidebar(pnlKiri);
            MaximizeBox = true;

            // Tangani event resize agar form input dan tabel tetap proporsional
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            Shown += (s, e) => gridPengguna.ClearSelection();

            // Muat data dari file pengguna.json dan bersihkan form input
            MuatPengguna();
            BersihkanForm();
        }

        // =========================================================================
        // PENGATURAN TATA LETAK RESPONSIF
        // =========================================================================

        /// <summary>
        /// Menyesuaikan tata letak grid pengguna dan panel input samping.
        /// </summary>
        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int gap = 24;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;

            if (nightControlBox1 != null)
            {
                nightControlBox1.Location = new Point(pnlKanan.ClientSize.Width - nightControlBox1.Width, 0);
                nightControlBox1.BringToFront();
            }

            lblJudul.Location = new Point(margin, 32);
            lblInfo.Location = new Point(margin, 72);

            int lebarForm = 336;
            int lebarGrid = lebarTersedia - lebarForm - gap;
            int yKonten = 112;
            int tinggiKonten = Math.Max(300, pnlKanan.ClientSize.Height - yKonten - margin);

            gridPengguna.Location = new Point(margin, yKonten);
            gridPengguna.Size = new Size(lebarGrid, tinggiKonten);

            pnlForm.Location = new Point(gridPengguna.Right + gap, yKonten);
            pnlForm.Size = new Size(lebarForm, tinggiKonten);
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
            Navigasi.BukaGudang(this);
        }

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }

        private void btnPengguna_Click(object? sender, EventArgs e)
        {
            // Sedang berada di form pengguna
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }

        // =========================================================================
        // EVENT HANDLER KONTROL CRUD PENGGUNA
        // =========================================================================

        /// <summary>
        /// Menambahkan akun pengguna baru ke sistem (Kasus Uji 1–3).
        /// </summary>
        private void btnTambah_Click(object? sender, EventArgs e)
        {
            if (penggunaTerpilih != null)
            {
                Peringatan("Klik Bersihkan terlebih dahulu untuk menambah pengguna baru.", btnBersihkan);
                return;
            }

            // Validasi format username (3-20 karakter, huruf kecil/angka)
            string nama = txtNamaPengguna.Text.Trim().ToLowerInvariant();
            if (!Regex.IsMatch(nama, "^[a-z0-9]{3,20}$"))
            {
                Peringatan("Nama pengguna harus 3–20 karakter berupa huruf atau angka tanpa spasi.", txtNamaPengguna);
                return;
            }

            // Validasi: Username tidak boleh duplikat
            if (daftarPengguna.Any(p => string.Equals(p.NamaPengguna, nama, StringComparison.OrdinalIgnoreCase)))
            {
                Peringatan("Nama pengguna sudah dipakai.", txtNamaPengguna);
                return;
            }

            // Validasi kata sandi (minimal 6 karakter dan cocok dengan konfirmasi)
            if (!ValidasiSandi(true))
            {
                return;
            }

            // Buat objek pengguna baru dan amankan kata sandi dengan PBKDF2 Hashing (Fitur Bonus)
            Pengguna akun = new Pengguna
            {
                NamaPengguna = nama,
                NamaLengkap = txtNamaLengkap.Text.Trim(),
                Peran = PeranDipilih(),
                Aktif = chkAktif.Checked,
                Dibuat = DateTime.Now
            };
            KeamananSandi.IsiSandi(akun, txtKataSandi.Text);
            daftarPengguna.Add(akun);

            if (!Simpan())
            {
                daftarPengguna.Remove(akun);
                return;
            }

            // Catat ke log aktivitas
            try
            {
                PenyimpananData.CatatAktivitas(
                    Navigasi.PenggunaAktif,
                    "Tambah Akun",
                    $"Menambahkan akun pengguna baru: '{akun.NamaPengguna}' (Nama: '{akun.NamaLengkap}', Peran: {NamaPeran(akun.Peran)}, Status: {(akun.Aktif ? "Aktif" : "Nonaktif")})."
                );
            }
            catch { }

            MuatPengguna();
            BersihkanForm();
        }

        /// <summary>
        /// Memperbarui informasi akun pengguna yang sedang dipilih (nama lengkap, peran, status, sandi).
        /// </summary>
        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            Pengguna? akun = daftarPengguna.FirstOrDefault(p => p.NamaPengguna == penggunaTerpilih);
            if (akun == null)
            {
                Peringatan("Pilih pengguna di tabel terlebih dahulu.", gridPengguna);
                return;
            }

            string peranBaru = PeranDipilih();
            bool aktifBaru = chkAktif.Checked;

            // Proteksi sistem: Tidak boleh menonaktifkan atau mengubah peran admin terakhir
            if (akun.Peran == "admin" && (peranBaru != "admin" || !aktifBaru) && daftarPengguna.Count(p => p.Peran == "admin" && p.Aktif) <= 1)
            {
                Peringatan("Harus ada minimal satu akun Admin yang aktif.", cmbPeran);
                return;
            }

            // Proteksi: Akun yang sedang dipakai login tidak boleh diedit sendiri dari menu ini
            if (string.Equals(akun.NamaPengguna, Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase))
            {
                Peringatan("Akun yang sedang dipakai tidak dapat diedit dari halaman ini.", cmbPeran);
                return;
            }

            // Validasi kata sandi jika diisi (opsional saat edit)
            if (!ValidasiSandi(false))
            {
                return;
            }

            string peranLama = akun.Peran;
            string namaLengkapLama = akun.NamaLengkap ?? "";
            string namaLengkapBaru = txtNamaLengkap.Text.Trim();
            string hashLama = akun.HashSandi;
            string garamLama = akun.Garam;
            int iterasiLama = akun.Iterasi;
            bool aktifLama = akun.Aktif;
            bool sandiDiubah = txtKataSandi.Text.Length > 0;

            akun.NamaLengkap = namaLengkapBaru;
            akun.Peran = peranBaru;
            akun.Aktif = aktifBaru;
            if (sandiDiubah)
            {
                KeamananSandi.IsiSandi(akun, txtKataSandi.Text);
            }

            if (!Simpan())
            {
                // Rollback jika gagal simpan ke file
                akun.NamaLengkap = namaLengkapLama;
                akun.Peran = peranLama;
                akun.HashSandi = hashLama;
                akun.Garam = garamLama;
                akun.Iterasi = iterasiLama;
                akun.Aktif = aktifLama;
                return;
            }

            // Catat log aktivitas perubahan sandi
            if (sandiDiubah)
            {
                try
                {
                    PenyimpananData.CatatAktivitas(
                        Navigasi.PenggunaAktif,
                        "Ubah Password",
                        $"Mengubah kata sandi untuk akun pengguna '{akun.NamaPengguna}'."
                    );
                }
                catch { }
            }

            // Catat log aktivitas perubahan profil
            List<string> perubahanLain = new List<string>();
            if (peranLama != peranBaru) perubahanLain.Add($"Peran: {NamaPeran(peranLama)} -> {NamaPeran(peranBaru)}");
            if (aktifLama != aktifBaru) perubahanLain.Add($"Status: {(aktifLama ? "Aktif" : "Nonaktif")} -> {(aktifBaru ? "Aktif" : "Nonaktif")}");
            if (perubahanLain.Count > 0)
            {
                try
                {
                    PenyimpananData.CatatAktivitas(
                        Navigasi.PenggunaAktif,
                        "Ubah Akun",
                        $"Mengubah profil akun '{akun.NamaPengguna}': {string.Join(", ", perubahanLain)}."
                    );
                }
                catch { }
            }

            MessageBox.Show("Data pengguna berhasil disimpan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MuatPengguna();
            BersihkanForm();
        }

        /// <summary>
        /// Menghapus akun pengguna dari sistem.
        /// </summary>
        private void btnHapus_Click(object? sender, EventArgs e)
        {
            Pengguna? akun = daftarPengguna.FirstOrDefault(p => p.NamaPengguna == penggunaTerpilih);
            if (akun == null)
            {
                Peringatan("Pilih pengguna di tabel terlebih dahulu.", gridPengguna);
                return;
            }

            // Proteksi: Tidak boleh menghapus akun yang sedang dipakai login
            if (string.Equals(akun.NamaPengguna, Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase))
            {
                Peringatan("Akun yang sedang dipakai tidak dapat dihapus.", gridPengguna);
                return;
            }

            // Proteksi: Tidak boleh menghapus admin terakhir yang aktif
            if (akun.Peran == "admin" && akun.Aktif && daftarPengguna.Count(p => p.Peran == "admin" && p.Aktif) <= 1)
            {
                Peringatan("Harus ada minimal satu akun Admin yang aktif.", gridPengguna);
                return;
            }

            if (MessageBox.Show($"Hapus pengguna \"{akun.NamaPengguna}\"?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int posisi = daftarPengguna.IndexOf(akun);
            daftarPengguna.Remove(akun);
            if (!Simpan())
            {
                daftarPengguna.Insert(posisi, akun);
                return;
            }

            // Catat log aktivitas penghapusan akun
            try
            {
                PenyimpananData.CatatAktivitas(
                    Navigasi.PenggunaAktif,
                    "Hapus Akun",
                    $"Menghapus akun pengguna: '{akun.NamaPengguna}' (Peran: {NamaPeran(akun.Peran)})."
                );
            }
            catch { }

            MuatPengguna();
            BersihkanForm();
        }

        /// <summary>
        /// Mengosongkan form input agar siap untuk input data baru.
        /// </summary>
        private void btnBersihkan_Click(object? sender, EventArgs e)
        {
            BersihkanForm();
        }

        /// <summary>
        /// Memilih pengguna dari tabel dan menampilkan detailnya ke form samping.
        /// </summary>
        private void gridPengguna_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string nama = gridPengguna.Rows[e.RowIndex].Cells["colNamaPengguna"].Value?.ToString() ?? "";
            Pengguna? akun = daftarPengguna.FirstOrDefault(p => p.NamaPengguna == nama);
            if (akun == null)
            {
                return;
            }

            penggunaTerpilih = akun.NamaPengguna;
            txtNamaPengguna.Text = akun.NamaPengguna;
            txtNamaPengguna.ReadOnly = true;
            txtNamaLengkap.Text = akun.NamaLengkap ?? "";
            cmbPeran.SelectedIndex = akun.Peran switch
            {
                "admin" => 0,
                "gudang" => 2,
                _ => 1
            };
            chkAktif.Checked = akun.Aktif;
            txtKataSandi.Text = "";
            txtKonfirmasi.Text = "";
            lblPetunjukSandi.Text = "Kosongkan jika kata sandi tidak diubah";
        }

        // =========================================================================
        // METODE BANTU & VALIDASI
        // =========================================================================

        /// <summary>
        /// Memuat daftar seluruh pengguna dari file pengguna.json dan mengikatnya ke DataGridView.
        /// </summary>
        private void MuatPengguna()
        {
            try
            {
                daftarPengguna = PenyimpananData.BacaPengguna();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data pengguna: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daftarPengguna = new List<Pengguna>();
            }

            gridPengguna.AutoGenerateColumns = false;
            gridPengguna.DataSource = daftarPengguna
                .Where(p => !string.Equals(p.NamaPengguna, Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Peran == "admin" ? 0 : 1)
                .ThenBy(p => p.NamaPengguna)
                .Select(p => new
                {
                    p.NamaPengguna,
                    NamaLengkap = string.IsNullOrWhiteSpace(p.NamaLengkap) ? "-" : p.NamaLengkap,
                    Peran = NamaPeran(p.Peran),
                    Status = p.Aktif ? "Aktif" : "Tidak Aktif",
                    Dibuat = p.Dibuat == default ? "-" : p.Dibuat.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia)
                }).ToList();
            gridPengguna.ClearSelection();
            lblInfo.Text = $"{daftarPengguna.Count} pengguna, {daftarPengguna.Count(p => p.Aktif)} aktif";
        }

        /// <summary>
        /// Mengembalikan teks label peran pengguna yang ramah pengguna.
        /// </summary>
        private static string NamaPeran(string peran)
        {
            return peran == "admin" ? "Admin" : (peran == "gudang" ? "Gudang" : "Kasir");
        }

        /// <summary>
        /// Mengembalikan string peran teknis berdasarkan pilihan ComboBox.
        /// </summary>
        private string PeranDipilih()
        {
            return cmbPeran.SelectedIndex switch
            {
                0 => "admin",
                2 => "gudang",
                _ => "kasir"
            };
        }

        /// <summary>
        /// Mengosongkan isian form dan mereset status seleksi.
        /// </summary>
        private void BersihkanForm()
        {
            penggunaTerpilih = null;
            txtNamaPengguna.Text = "";
            txtNamaPengguna.ReadOnly = false;
            txtNamaLengkap.Text = "";
            cmbPeran.SelectedIndex = 1;
            chkAktif.Checked = true;
            txtKataSandi.Text = "";
            txtKonfirmasi.Text = "";
            lblPetunjukSandi.Text = "Minimal 6 karakter";
            gridPengguna.ClearSelection();
            txtNamaPengguna.Focus();
        }

        /// <summary>
        /// Memvalidasi panjang dan kesamaan konfirmasi kata sandi.
        /// </summary>
        private bool ValidasiSandi(bool wajib)
        {
            string sandi = txtKataSandi.Text;
            if (!wajib && sandi.Length == 0 && txtKonfirmasi.Text.Length == 0)
            {
                return true;
            }

            if (sandi.Length < 6)
            {
                Peringatan("Kata sandi minimal 6 karakter.", txtKataSandi);
                return false;
            }

            if (sandi != txtKonfirmasi.Text)
            {
                Peringatan("Ulangi kata sandi belum sama.", txtKonfirmasi);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Menampilkan kotak dialog peringatan dan memfokuskan ke kontrol yang bersangkutan.
        /// </summary>
        private static void Peringatan(string pesan, Control kontrol)
        {
            MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            kontrol.Focus();
        }

        /// <summary>
        /// Menyimpan seluruh list daftar pengguna ke file pengguna.json.
        /// </summary>
        private bool Simpan()
        {
            try
            {
                PenyimpananData.SimpanPengguna(daftarPengguna);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data pengguna: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
