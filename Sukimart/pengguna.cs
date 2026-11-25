using System.Globalization;
using System.Text.RegularExpressions;

namespace Sukimart
{
    public partial class FormPengguna : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private List<Pengguna> daftarPengguna = new List<Pengguna>();
        private string? penggunaTerpilih;

        public FormPengguna()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            UIHelper.SusunTombolSidebar(pnlKiri);
            MaximizeBox = true;
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnLaporanInventaris.Click += (s, e) => Navigasi.BukaLaporanInventaris(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);
            btnTambah.Click += BtnTambah_Click;
            btnSimpan.Click += BtnSimpan_Click;
            btnHapus.Click += BtnHapus_Click;
            btnBersihkan.Click += (s, e) => BersihkanForm();
            gridPengguna.CellClick += GridPengguna_CellClick;
            Shown += (s, e) => gridPengguna.ClearSelection();
            MuatPengguna();
            BersihkanForm();
        }

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
                .OrderBy(p => p.Peran == "admin" ? 0 : (p.Peran == "gudang" ? 1 : 2))
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

        private static string NamaPeran(string peran)
        {
            return peran == "admin" ? "Admin" : (peran == "gudang" ? "Gudang" : "Kasir");
        }

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

        private void GridPengguna_CellClick(object? sender, DataGridViewCellEventArgs e)
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

        private string PeranDipilih()
        {
            return cmbPeran.SelectedIndex switch
            {
                0 => "admin",
                2 => "gudang",
                _ => "kasir"
            };
        }

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

        private static void Peringatan(string pesan, Control kontrol)
        {
            MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            kontrol.Focus();
        }

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

        private void BtnTambah_Click(object? sender, EventArgs e)
        {
            if (penggunaTerpilih != null)
            {
                Peringatan("Klik Bersihkan terlebih dahulu untuk menambah pengguna baru.", btnBersihkan);
                return;
            }

            string nama = txtNamaPengguna.Text.Trim().ToLowerInvariant();
            if (!Regex.IsMatch(nama, "^[a-z0-9]{3,20}$"))
            {
                Peringatan("Nama pengguna harus 3–20 karakter berupa huruf atau angka tanpa spasi.", txtNamaPengguna);
                return;
            }

            if (daftarPengguna.Any(p => string.Equals(p.NamaPengguna, nama, StringComparison.OrdinalIgnoreCase)))
            {
                Peringatan("Nama pengguna sudah dipakai.", txtNamaPengguna);
                return;
            }

            if (!ValidasiSandi(true))
            {
                return;
            }

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

        private void BtnSimpan_Click(object? sender, EventArgs e)
        {
            Pengguna? akun = daftarPengguna.FirstOrDefault(p => p.NamaPengguna == penggunaTerpilih);
            if (akun == null)
            {
                Peringatan("Pilih pengguna di tabel terlebih dahulu.", gridPengguna);
                return;
            }

            string peranBaru = PeranDipilih();
            bool aktifBaru = chkAktif.Checked;
            if (akun.Peran == "admin" && (peranBaru != "admin" || !aktifBaru) && daftarPengguna.Count(p => p.Peran == "admin" && p.Aktif) <= 1)
            {
                Peringatan("Harus ada minimal satu akun Admin yang aktif.", cmbPeran);
                return;
            }

            if (string.Equals(akun.NamaPengguna, Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase))
            {
                Peringatan("Akun yang sedang dipakai tidak dapat diedit.", cmbPeran);
                return;
            }

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
                akun.NamaLengkap = namaLengkapLama;
                akun.Peran = peranLama;
                akun.HashSandi = hashLama;
                akun.Garam = garamLama;
                akun.Iterasi = iterasiLama;
                akun.Aktif = aktifLama;
                return;
            }

            // Catat perubahan sandi jika ada
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

            // Catat perubahan nama lengkap jika ada
            if (!string.Equals(namaLengkapLama, namaLengkapBaru, StringComparison.Ordinal))
            {
                try
                {
                    PenyimpananData.CatatAktivitas(
                        Navigasi.PenggunaAktif,
                        "Ubah Nama",
                        $"Mengubah nama pengguna '{akun.NamaPengguna}' dari '{namaLengkapLama}' menjadi '{namaLengkapBaru}'."
                    );
                }
                catch { }
            }

            // Catat perubahan peran atau status jika ada
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

        private void BtnHapus_Click(object? sender, EventArgs e)
        {
            Pengguna? akun = daftarPengguna.FirstOrDefault(p => p.NamaPengguna == penggunaTerpilih);
            if (akun == null)
            {
                Peringatan("Pilih pengguna di tabel terlebih dahulu.", gridPengguna);
                return;
            }

            if (string.Equals(akun.NamaPengguna, Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase))
            {
                Peringatan("Akun yang sedang dipakai tidak dapat dihapus.", gridPengguna);
                return;
            }

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
    }
}
