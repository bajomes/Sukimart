namespace Sukimart
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlKiri = new Panel();
            pnlKartuLogin = new Panel();
            lblSubMasuk = new Label();
            lblPassSalah = new Label();
            lblUsnSalah = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            btnMasuk = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblJudul = new Label();
            pictureLogo = new PictureBox();
            lblMerk = new Label();
            lblTaglineKiri = new Label();
            pnlKanan = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblIdentitasToko = new Label();
            pnlAksenLogin = new Panel();
            lblKecil = new Label();
            lblBesar = new Label();
            pnlKiri.SuspendLayout();
            pnlKartuLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.FromArgb(246, 241, 231);
            pnlKiri.Controls.Add(pnlKartuLogin);
            pnlKiri.Controls.Add(pictureLogo);
            pnlKiri.Controls.Add(lblMerk);
            pnlKiri.Controls.Add(lblTaglineKiri);
            pnlKiri.Dock = DockStyle.Left;
            pnlKiri.Location = new Point(0, 0);
            pnlKiri.Name = "pnlKiri";
            pnlKiri.Size = new Size(560, 720);
            pnlKiri.TabIndex = 1;
            // 
            // pnlKartuLogin
            // 
            pnlKartuLogin.BackColor = Color.FromArgb(255, 253, 248);
            pnlKartuLogin.Controls.Add(lblSubMasuk);
            pnlKartuLogin.Controls.Add(lblPassSalah);
            pnlKartuLogin.Controls.Add(lblUsnSalah);
            pnlKartuLogin.Controls.Add(lblPassword);
            pnlKartuLogin.Controls.Add(lblUsername);
            pnlKartuLogin.Controls.Add(btnMasuk);
            pnlKartuLogin.Controls.Add(txtPassword);
            pnlKartuLogin.Controls.Add(txtUsername);
            pnlKartuLogin.Controls.Add(lblJudul);
            pnlKartuLogin.Location = new Point(48, 160);
            pnlKartuLogin.Name = "pnlKartuLogin";
            pnlKartuLogin.Size = new Size(464, 416);
            pnlKartuLogin.TabIndex = 3;
            // 
            // lblSubMasuk
            // 
            lblSubMasuk.AutoSize = true;
            lblSubMasuk.Font = new Font("Inter", 8.5F);
            lblSubMasuk.ForeColor = Color.FromArgb(107, 116, 104);
            lblSubMasuk.Location = new Point(32, 352);
            lblSubMasuk.Name = "lblSubMasuk";
            lblSubMasuk.Size = new Size(274, 15);
            lblSubMasuk.TabIndex = 10;
            lblSubMasuk.Text = "Masuk menggunakan akun kasir, gudang, atau admin.";
            // 
            // lblPassSalah
            // 
            lblPassSalah.AutoSize = true;
            lblPassSalah.Font = new Font("Inter", 9F);
            lblPassSalah.ForeColor = Color.FromArgb(179, 38, 30);
            lblPassSalah.Location = new Point(32, 240);
            lblPassSalah.Name = "lblPassSalah";
            lblPassSalah.Size = new Size(0, 15);
            lblPassSalah.TabIndex = 9;
            // 
            // lblUsnSalah
            // 
            lblUsnSalah.AutoSize = true;
            lblUsnSalah.Font = new Font("Inter", 9F);
            lblUsnSalah.ForeColor = Color.FromArgb(179, 38, 30);
            lblUsnSalah.Location = new Point(32, 160);
            lblUsnSalah.Name = "lblUsnSalah";
            lblUsnSalah.Size = new Size(0, 15);
            lblUsnSalah.TabIndex = 8;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(31, 42, 36);
            lblPassword.Location = new Point(32, 184);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(69, 16);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Kata Sandi";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(31, 42, 36);
            lblUsername.Location = new Point(32, 104);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 16);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Nama Pengguna";
            // 
            // btnMasuk
            // 
            btnMasuk.BackColor = Color.FromArgb(232, 131, 58);
            btnMasuk.Cursor = Cursors.Hand;
            btnMasuk.FlatAppearance.BorderSize = 0;
            btnMasuk.FlatStyle = FlatStyle.Flat;
            btnMasuk.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnMasuk.ForeColor = Color.FromArgb(255, 253, 248);
            btnMasuk.Location = new Point(32, 280);
            btnMasuk.Name = "btnMasuk";
            btnMasuk.Size = new Size(400, 48);
            btnMasuk.TabIndex = 5;
            btnMasuk.Text = "Masuk";
            btnMasuk.UseVisualStyleBackColor = false;
            btnMasuk.Click += btnMasuk_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(255, 253, 248);
            txtPassword.Font = new Font("Inter", 10F);
            txtPassword.ForeColor = Color.FromArgb(31, 42, 36);
            txtPassword.Location = new Point(32, 208);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Masukkan kata sandi";
            txtPassword.Size = new Size(400, 25);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(255, 253, 248);
            txtUsername.Font = new Font("Inter", 10F);
            txtUsername.ForeColor = Color.FromArgb(31, 42, 36);
            txtUsername.Location = new Point(32, 128);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Masukkan nama pengguna";
            txtUsername.Size = new Size(400, 25);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += txtUsername_TextChanged;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 42, 36);
            lblJudul.Location = new Point(32, 32);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(116, 36);
            lblJudul.TabIndex = 2;
            lblJudul.Text = "Masuk";
            // 
            // pictureLogo
            // 
            pictureLogo.BackColor = Color.Transparent;
            pictureLogo.Image = Properties.Resources.logo;
            pictureLogo.Location = new Point(48, 48);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(40, 40);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 1;
            pictureLogo.TabStop = false;
            // 
            // lblMerk
            // 
            lblMerk.AutoSize = true;
            lblMerk.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblMerk.ForeColor = Color.FromArgb(30, 42, 68);
            lblMerk.Location = new Point(96, 48);
            lblMerk.Name = "lblMerk";
            lblMerk.Size = new Size(126, 25);
            lblMerk.TabIndex = 0;
            lblMerk.Text = "SUKIMART";
            // 
            // lblTaglineKiri
            // 
            lblTaglineKiri.AutoSize = true;
            lblTaglineKiri.Font = new Font("Inter", 8.5F);
            lblTaglineKiri.ForeColor = Color.FromArgb(107, 116, 104);
            lblTaglineKiri.Location = new Point(96, 72);
            lblTaglineKiri.Name = "lblTaglineKiri";
            lblTaglineKiri.Size = new Size(146, 15);
            lblTaglineKiri.TabIndex = 2;
            lblTaglineKiri.Text = "Sistem Kasir & Inventaris";
            // 
            // pnlKanan
            // 
            pnlKanan.BackColor = Color.FromArgb(30, 42, 68);
            pnlKanan.Controls.Add(nightControlBox1);
            pnlKanan.Controls.Add(lblIdentitasToko);
            pnlKanan.Controls.Add(pnlAksenLogin);
            pnlKanan.Controls.Add(lblKecil);
            pnlKanan.Controls.Add(lblBesar);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(560, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(720, 720);
            pnlKanan.TabIndex = 2;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(179, 38, 30);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = false;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(200, 208, 224);
            nightControlBox1.EnableMaximizeButton = false;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(200, 208, 224);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(200, 208, 224);
            nightControlBox1.Location = new Point(581, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(37, 52, 79);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(37, 52, 79);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 3;
            // 
            // lblIdentitasToko
            // 
            lblIdentitasToko.AutoSize = true;
            lblIdentitasToko.Font = new Font("Inter", 10F, FontStyle.Bold);
            lblIdentitasToko.ForeColor = Color.FromArgb(232, 131, 58);
            lblIdentitasToko.Location = new Point(64, 248);
            lblIdentitasToko.Name = "lblIdentitasToko";
            lblIdentitasToko.Size = new Size(260, 18);
            lblIdentitasToko.TabIndex = 4;
            lblIdentitasToko.Text = "MINIMARKET & TOKO KELONTONG MODERN";
            // 
            // pnlAksenLogin
            // 
            pnlAksenLogin.BackColor = Color.FromArgb(232, 131, 58);
            pnlAksenLogin.Location = new Point(64, 280);
            pnlAksenLogin.Name = "pnlAksenLogin";
            pnlAksenLogin.Size = new Size(64, 4);
            pnlAksenLogin.TabIndex = 5;
            // 
            // lblKecil
            // 
            lblKecil.AutoSize = true;
            lblKecil.Font = new Font("Inter", 12F);
            lblKecil.ForeColor = Color.FromArgb(200, 208, 224);
            lblKecil.Location = new Point(64, 368);
            lblKecil.Name = "lblKecil";
            lblKecil.Size = new Size(430, 22);
            lblKecil.TabIndex = 2;
            lblKecil.Text = "Kasir cepat, stok terpantau, dan laporan rapi dalam satu aplikasi.";
            // 
            // lblBesar
            // 
            lblBesar.AutoSize = true;
            lblBesar.Font = new Font("Inter", 28F, FontStyle.Bold);
            lblBesar.ForeColor = Color.FromArgb(246, 241, 231);
            lblBesar.Location = new Point(64, 304);
            lblBesar.Name = "lblBesar";
            lblBesar.Size = new Size(436, 45);
            lblBesar.TabIndex = 1;
            lblBesar.Text = "Kelola toko lebih mudah";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 241, 231);
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Masuk";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            pnlKartuLogin.ResumeLayout(false);
            pnlKartuLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlKiri;
        private Panel pnlKartuLogin;
        private Label lblSubMasuk;
        private Label lblTaglineKiri;
        private Label lblMerk;
        private Panel pnlKanan;
        private Panel pnlAksenLogin;
        private Label lblIdentitasToko;
        private PictureBox pictureLogo;
        private Label lblJudul;
        private TextBox txtUsername;
        private Button btnMasuk;
        private TextBox txtPassword;
        private Label lblKecil;
        private Label lblBesar;
        private Label lblPassword;
        private Label lblUsername;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblPassSalah;
        private Label lblUsnSalah;
    }
}