using System.Globalization;

namespace Sukimart
{
    public partial class FormGantiKataSandi : Form
    {
        public FormGantiKataSandi()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
        }

        // Menggambar garis batas (border) di sekeliling jendela dialog
        private void FormGantiKataSandi_Paint(object? sender, PaintEventArgs e)
        {
            using Pen pena = new Pen(UIHelper.WarnaGarisTepi);
            e.Graphics.DrawRectangle(pena, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

        // Menutup formulir dialog ganti kata sandi tanpa menyimpan
        private void btnBatal_Click(object? sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static bool ValidasiDanSimpan(string sandiLama, string sandiBaru, string konfirmasiSandi, out string pesan)
        {
            pesan = "";

            // 1. Pastikan semua kolom sudah diisi
            if (string.IsNullOrEmpty(sandiLama))
            {
                pesan = "Kata sandi lama wajib diisi.";
                return false;
            }

            if (string.IsNullOrEmpty(sandiBaru))
            {
                pesan = "Kata sandi baru wajib diisi.";
                return false;
            }

            if (string.IsNullOrEmpty(konfirmasiSandi))
            {
                pesan = "Konfirmasi kata sandi baru wajib diisi.";
                return false;
            }

            if (sandiBaru.Length < 6)
            {
                pesan = "Kata sandi baru minimal 6 karakter.";
                return false;
            }

            // 2. Periksa kesesuaian kata sandi lama dengan akun yang sedang login
            string username = Navigasi.PenggunaAktif;
            List<Pengguna> daftarPengguna;
            try
            {
                daftarPengguna = PenyimpananData.BacaPengguna();
            }
            catch (Exception ex)
            {
                pesan = "Gagal membaca data akun: " + ex.Message;
                return false;
            }

            Pengguna? akun = daftarPengguna.FirstOrDefault(p => string.Equals(p.NamaPengguna, username, StringComparison.OrdinalIgnoreCase));
            if (akun == null)
            {
                pesan = "Akun pengguna tidak ditemukan.";
                return false;
            }

            if (!KeamananSandi.Cocok(akun, sandiLama))
            {
                pesan = "Kata sandi lama tidak sesuai.";
                return false;
            }

            // 3. Pastikan kata sandi baru berbeda dari kata sandi lama
            if (sandiBaru == sandiLama)
            {
                pesan = "Kata sandi baru harus berbeda dari kata sandi lama.";
                return false;
            }

            // 4. Pastikan kata sandi baru dan konfirmasinya sama
            if (sandiBaru != konfirmasiSandi)
            {
                pesan = "Konfirmasi kata sandi baru tidak cocok.";
                return false;
            }

            // 5. Jika semua validasi berhasil, simpan kata sandi baru
            KeamananSandi.IsiSandi(akun, sandiBaru);
            try
            {
                PenyimpananData.SimpanPengguna(daftarPengguna);
            }
            catch (Exception ex)
            {
                pesan = "Gagal menyimpan kata sandi baru: " + ex.Message;
                return false;
            }

            // 6. Integrasi dengan Log Aktivitas Admin
            string detailAktivitas = "Pengguna berhasil mengganti kata sandi akunnya sendiri.";

            try
            {
                PenyimpananData.CatatAktivitas(akun.NamaPengguna, "Ubah Password", detailAktivitas);
            }
            catch (Exception ex)
            {
                pesan = "LOG_GAGAL:" + ex.Message;
                return true;
            }

            return true;
        }

        // Memvalidasi data input dan menyimpan kata sandi baru (PBKDF2) serta mencatat log audit
        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            string sandiLama = txtSandiLama.Text;
            string sandiBaru = txtSandiBaru.Text;
            string konfirmasiSandi = txtKonfirmasiSandi.Text;

            bool berhasil = ValidasiDanSimpan(sandiLama, sandiBaru, konfirmasiSandi, out string pesan);
            if (!berhasil)
            {
                MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (pesan.Contains("lama"))
                {
                    txtSandiLama.SelectAll();
                    txtSandiLama.Focus();
                }
                else if (pesan.Contains("cocok"))
                {
                    txtKonfirmasiSandi.SelectAll();
                    txtKonfirmasiSandi.Focus();
                }
                else
                {
                    txtSandiBaru.SelectAll();
                    txtSandiBaru.Focus();
                }
                return;
            }

            if (pesan.StartsWith("LOG_GAGAL:"))
            {
                MessageBox.Show(
                    "Kata sandi berhasil disimpan, namun sistem gagal mencatat aktivitas ke dalam log: " + pesan.Substring(10),
                    "Peringatan Log",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show("Kata sandi berhasil diubah.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
