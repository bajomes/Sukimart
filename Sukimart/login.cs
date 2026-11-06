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
                return;
            }

            if (!KeamananSandi.Cocok(akun, password))
            {
                lblPassSalah.Text = "Kata sandi salah";
                return;
            }

            ResetErrorLabels();
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
            txtUsername.Focus();
        }
    }
}
