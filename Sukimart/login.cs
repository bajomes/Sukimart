using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormLogin : Form
    {
        private int jumlahSandiSalah;

        public FormLogin()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
        }

        // Menghapus pesan kesalahan username saat pengguna mulai mengetik kembali
        private void txtUsername_TextChanged(object? sender, EventArgs e)
        {
            lblUsnSalah.Text = "";
        }

        // Menghapus pesan kesalahan kata sandi saat pengguna mulai mengetik kembali
        private void txtPassword_TextChanged(object? sender, EventArgs e)
        {
            lblPassSalah.Text = "";
        }

        // Menekan Enter pada kolom nama pengguna langsung memicu tombol Masuk
        private void txtUsername_KeyDown(object? sender, KeyEventArgs e)
        {
            TxtInput_KeyDown(sender, e);
        }

        // Menekan Enter pada kolom kata sandi langsung memicu tombol Masuk
        private void txtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            TxtInput_KeyDown(sender, e);
        }

        // Pintasan keyboard: Tombol Enter menjalankan proses login
        private void TxtInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMasuk.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Memproses autentikasi pengguna, validasi status aktif, verifikasi hash PBKDF2, dan batasan 3 kali percobaan (Kasus Uji 1 & 2)
        private void btnMasuk_Click(object sender, EventArgs e)
        {
            lblUsnSalah.Text = "";
            lblPassSalah.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            bool adaError = false;

            // Validasi: Nama pengguna wajib diisi
            if (string.IsNullOrEmpty(username))
            {
                lblUsnSalah.Text = "Nama pengguna wajib diisi";
                adaError = true;
            }

            // Validasi: Kata sandi wajib diisi
            if (string.IsNullOrEmpty(password))
            {
                lblPassSalah.Text = "Kata sandi wajib diisi";
                adaError = true;
            }

            if (adaError)
            {
                return;
            }

            Pengguna? akun;
            try
            {
                // Cari akun berdasarkan nama pengguna tanpa membedakan huruf besar/kecil (case-insensitive)
                akun = PenyimpananData.BacaPengguna()
                    .FirstOrDefault(p => string.Equals(p.NamaPengguna, username, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pengguna tidak dapat dibaca: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validasi: Akun tidak ditemukan
            if (akun == null)
            {
                lblUsnSalah.Text = "Nama pengguna tidak ditemukan";
                try
                {
                    PenyimpananData.CatatAktivitas(username, "Login Gagal", $"Percobaan masuk gagal: Nama pengguna '{username}' tidak ditemukan.");
                }
                catch { }
                return;
            }

            // Validasi: Status akun harus aktif (Kasus Uji 2)
            if (!akun.Aktif)
            {
                lblUsnSalah.Text = "Akun ini tidak aktif";
                try
                {
                    PenyimpananData.CatatAktivitas(username, "Login Gagal", $"Percobaan masuk gagal: Akun '{username}' berstatus nonaktif.");
                }
                catch { }
                return;
            }

            // Validasi keamanan: Cocokkan hash password PBKDF2 (Kasus Uji 1)
            if (!KeamananSandi.Cocok(akun, password))
            {
                jumlahSandiSalah++;
                lblPassSalah.Text = $"Kata sandi salah ({jumlahSandiSalah}/3)";
                try
                {
                    PenyimpananData.CatatAktivitas(username, "Login Gagal", $"Percobaan masuk gagal: Kata sandi salah untuk pengguna '{username}' ({jumlahSandiSalah}/3).");
                }
                catch { }

                // Kasus Uji 1: Jika kata sandi salah 3 kali, aplikasi akan tertutup demi keamanan
                if (jumlahSandiSalah >= 3)
                {
                    MessageBox.Show("Akses ditolak karena kata sandi salah tiga kali.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                return;
            }

            // Berhasil login: reset counter percobaan salah dan buka sesi baru sesuai peran pengguna
            ResetErrorLabels();
            jumlahSandiSalah = 0;
            try
            {
                PenyimpananData.CatatAktivitas(akun.NamaPengguna, "Login", $"Pengguna '{akun.NamaPengguna}' ({akun.Peran}) berhasil masuk ke sistem.");
            }
            catch { }
            Navigasi.MulaiSesi(this, akun.NamaPengguna, akun.Peran);
        }

        private void ResetErrorLabels()
        {
            lblUsnSalah.Text = "";
            lblPassSalah.Text = "";
        }

        public void ResetInput()
        {
            txtPassword.Clear();
            txtUsername.Clear();
            ResetErrorLabels();
            jumlahSandiSalah = 0;
            txtUsername.Focus();
        }
    }
}
