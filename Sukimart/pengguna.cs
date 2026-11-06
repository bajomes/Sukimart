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
            MaximizeBox = false;
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);
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
                .OrderBy(p => p.Peran == "admin" ? 0 : 1)
                .ThenBy(p => p.NamaPengguna)
                .Select(p => new
                {
                    p.NamaPengguna,
                    Peran = NamaPeran(p.Peran),
                    Dibuat = p.Dibuat == default ? "-" : p.Dibuat.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia)
                }).ToList();
            gridPengguna.ClearSelection();
            lblInfo.Text = $"{daftarPengguna.Count} pengguna";
        }

        private static string NamaPeran(string peran)
        {
            return peran == "admin" ? "Admin" : "Kasir";
        }

        private void BersihkanForm()
        {
            penggunaTerpilih = null;
            txtNamaPengguna.Text = "";
            txtNamaPengguna.ReadOnly = false;
            cmbPeran.SelectedIndex = 1;
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
            cmbPeran.SelectedIndex = akun.Peran == "admin" ? 0 : 1;
            txtKataSandi.Text = "";
            txtKonfirmasi.Text = "";
            lblPetunjukSandi.Text = "Kosongkan jika kata sandi tidak diubah";
        }

        private string PeranDipilih()
        {
            return cmbPeran.SelectedIndex == 0 ? "admin" : "kasir";
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

            Pengguna akun = new Pengguna { NamaPengguna = nama, Peran = PeranDipilih(), Dibuat = DateTime.Now };
            KeamananSandi.IsiSandi(akun, txtKataSandi.Text);
            daftarPengguna.Add(akun);

            if (!Simpan())
            {
                daftarPengguna.Remove(akun);
                return;
            }

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
            if (akun.Peran == "admin" && peranBaru != "admin" && daftarPengguna.Count(p => p.Peran == "admin") <= 1)
            {
                Peringatan("Harus ada minimal satu akun Admin.", cmbPeran);
                return;
            }

            if (string.Equals(akun.NamaPengguna, Navigasi.PenggunaAktif, StringComparison.OrdinalIgnoreCase) && peranBaru != akun.Peran)
            {
                Peringatan("Peran akun yang sedang dipakai tidak dapat diubah.", cmbPeran);
                return;
            }

            if (!ValidasiSandi(false))
            {
                return;
            }

            string peranLama = akun.Peran;
            string hashLama = akun.HashSandi;
            string garamLama = akun.Garam;
            int iterasiLama = akun.Iterasi;

            akun.Peran = peranBaru;
            if (txtKataSandi.Text.Length > 0)
            {
                KeamananSandi.IsiSandi(akun, txtKataSandi.Text);
            }

            if (!Simpan())
            {
                akun.Peran = peranLama;
                akun.HashSandi = hashLama;
                akun.Garam = garamLama;
                akun.Iterasi = iterasiLama;
                return;
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

            if (akun.Peran == "admin" && daftarPengguna.Count(p => p.Peran == "admin") <= 1)
            {
                Peringatan("Harus ada minimal satu akun Admin.", gridPengguna);
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

            MuatPengguna();
            BersihkanForm();
        }
    }
}
