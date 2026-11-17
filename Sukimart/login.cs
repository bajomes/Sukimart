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
            txtUsername.TextChanged += (s, e) => lblUsnSalah.Text = "";
            txtPassword.TextChanged += (s, e) => lblPassSalah.Text = "";
            txtUsername.KeyDown += TxtInput_KeyDown;
            txtPassword.KeyDown += TxtInput_KeyDown;
        }

        private void TxtInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMasuk.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            lblUsnSalah.Text = "";
            lblPassSalah.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            bool adaError = false;

            if (string.IsNullOrEmpty(username))
            {
                lblUsnSalah.Text = "Nama pengguna wajib diisi";
                adaError = true;
            }

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
                akun = PenyimpananData.BacaPengguna()
                    .FirstOrDefault(p => string.Equals(p.NamaPengguna, username, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pengguna tidak dapat dibaca: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            if (!KeamananSandi.Cocok(akun, password))
            {
                jumlahSandiSalah++;
                lblPassSalah.Text = $"Kata sandi salah ({jumlahSandiSalah}/3)";
                try
                {
                    PenyimpananData.CatatAktivitas(username, "Login Gagal", $"Percobaan masuk gagal: Kata sandi salah untuk pengguna '{username}' ({jumlahSandiSalah}/3).");
                }
                catch { }

                if (jumlahSandiSalah >= 3)
                {
                    MessageBox.Show("Akses ditolak karena kata sandi salah tiga kali.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                return;
            }

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
