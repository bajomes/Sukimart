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
                lblUsnSalah.Text = "Username wajib diisi";
                adaError = true;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblPassSalah.Text = "Password wajib diisi";
                adaError = true;
            }

            if (adaError)
            {
                return;
            }

            if (username == "admin" && password == "admin123")
            {
                ResetErrorLabels();
                Navigasi.MulaiSesi(this, username, "admin");
            }
            else if (username == "kasir" && password == "kasir123")
            {
                ResetErrorLabels();
                Navigasi.MulaiSesi(this, username, "kasir");
            }
            else
            {
                if (username != "admin" && username != "kasir")
                {
                    lblUsnSalah.Text = "Username tidak ditemukan";
                }
                else
                {
                    lblPassSalah.Text = "Password salah";
                }
            }
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
