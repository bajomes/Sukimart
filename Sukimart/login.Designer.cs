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
            pnlKanan = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblKecil = new Label();
            lblBesar = new Label();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.White;
            pnlKiri.Controls.Add(lblPassSalah);
            pnlKiri.Controls.Add(lblUsnSalah);
            pnlKiri.Controls.Add(lblPassword);
            pnlKiri.Controls.Add(lblUsername);
            pnlKiri.Controls.Add(btnMasuk);
            pnlKiri.Controls.Add(txtPassword);
            pnlKiri.Controls.Add(txtUsername);
            pnlKiri.Controls.Add(lblJudul);
            pnlKiri.Controls.Add(pictureLogo);
            pnlKiri.Controls.Add(lblMerk);
            pnlKiri.Dock = DockStyle.Left;
            pnlKiri.Location = new Point(0, 0);
            pnlKiri.Name = "pnlKiri";
            pnlKiri.Size = new Size(500, 640);
            pnlKiri.TabIndex = 1;
            // 
            // lblPassSalah
            // 
            lblPassSalah.AutoSize = true;
            lblPassSalah.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassSalah.ForeColor = Color.FromArgb(220, 38, 38);
            lblPassSalah.Location = new Point(56, 432);
            lblPassSalah.Name = "lblPassSalah";
            lblPassSalah.Size = new Size(0, 15);
            lblPassSalah.TabIndex = 9;
            // 
            // lblUsnSalah
            // 
            lblUsnSalah.AutoSize = true;
            lblUsnSalah.Font = new Font("Inter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsnSalah.ForeColor = Color.FromArgb(220, 38, 38);
            lblUsnSalah.Location = new Point(56, 332);
            lblUsnSalah.Name = "lblUsnSalah";
            lblUsnSalah.Size = new Size(0, 15);
            lblUsnSalah.TabIndex = 8;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Inter", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(53, 375);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(69, 16);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Inter", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(53, 275);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 16);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Username";
            // 
            // btnMasuk
            // 
            btnMasuk.BackColor = Color.FromArgb(255, 196, 0);
            btnMasuk.Cursor = Cursors.Hand;
            btnMasuk.FlatAppearance.BorderSize = 0;
            btnMasuk.FlatStyle = FlatStyle.Flat;
            btnMasuk.Font = new Font("Inter", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMasuk.ForeColor = Color.Black;
            btnMasuk.Location = new Point(55, 500);
            btnMasuk.Name = "btnMasuk";
            btnMasuk.Size = new Size(375, 30);
            btnMasuk.TabIndex = 5;
            btnMasuk.Text = "Sign in";
            btnMasuk.UseVisualStyleBackColor = false;
            btnMasuk.Click += btnMasuk_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(55, 400);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(375, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(55, 300);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Enter your username";
            txtUsername.Size = new Size(375, 27);
            txtUsername.TabIndex = 3;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJudul.ForeColor = Color.Black;
            lblJudul.Location = new Point(50, 175);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(103, 33);
            lblJudul.TabIndex = 2;
            lblJudul.Text = "Sign in";
            // 
            // pictureLogo
            // 
            pictureLogo.BackColor = Color.Transparent;
            pictureLogo.Image = Properties.Resources.logo;
            pictureLogo.Location = new Point(50, 50);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(50, 50);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 1;
            pictureLogo.TabStop = false;
            // 
            // lblMerk
            // 
            lblMerk.AutoSize = true;
            lblMerk.Font = new Font("Inter", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMerk.ForeColor = Color.Black;
            lblMerk.Location = new Point(100, 65);
            lblMerk.Name = "lblMerk";
            lblMerk.Size = new Size(126, 25);
            lblMerk.TabIndex = 0;
            lblMerk.Text = "SUKIMART";
            // 
            // pnlKanan
            // 
            pnlKanan.BackColor = Color.FromArgb(255, 244, 204);
            pnlKanan.Controls.Add(nightControlBox1);
            pnlKanan.Controls.Add(lblKecil);
            pnlKanan.Controls.Add(lblBesar);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(500, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(500, 640);
            pnlKanan.TabIndex = 2;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = false;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(361, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 3;
            // 
            // lblKecil
            // 
            lblKecil.AutoSize = true;
            lblKecil.Font = new Font("Inter", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKecil.Location = new Point(40, 300);
            lblKecil.Name = "lblKecil";
            lblKecil.Size = new Size(415, 23);
            lblKecil.TabIndex = 2;
            lblKecil.Text = "\"Kasir, stok, dan laporan dalam satu aplikasi\"";
            // 
            // lblBesar
            // 
            lblBesar.AutoSize = true;
            lblBesar.Font = new Font("Inter", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBesar.Location = new Point(30, 225);
            lblBesar.Name = "lblBesar";
            lblBesar.Size = new Size(437, 45);
            lblBesar.TabIndex = 1;
            lblBesar.Text = "Kelola toko lebih mudah";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1000, 640);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log in";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlKiri;
        private Label lblMerk;
        private Panel pnlKanan;
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