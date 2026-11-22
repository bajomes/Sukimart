namespace Sukimart
{
    partial class FormGantiKataSandi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblJudul = new Label();
            lblInfo = new Label();
            lblSandiLama = new Label();
            txtSandiLama = new TextBox();
            lblSandiBaru = new Label();
            txtSandiBaru = new TextBox();
            lblKonfirmasiSandi = new Label();
            txtKonfirmasiSandi = new TextBox();
            lblPetunjukSandi = new Label();
            btnBatal = new Button();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.BackColor = Color.Transparent;
            lblJudul.Font = new Font("Inter", 13F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(28, 22);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(160, 21);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Ganti Kata Sandi";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Inter", 9F);
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(28, 48);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(295, 15);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Perbarui kata sandi akun Anda untuk menjaga keamanan.";
            // 
            // lblSandiLama
            // 
            lblSandiLama.AutoSize = true;
            lblSandiLama.BackColor = Color.Transparent;
            lblSandiLama.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblSandiLama.ForeColor = Color.FromArgb(75, 85, 99);
            lblSandiLama.Location = new Point(28, 80);
            lblSandiLama.Name = "lblSandiLama";
            lblSandiLama.Size = new Size(106, 15);
            lblSandiLama.TabIndex = 2;
            lblSandiLama.Text = "Kata Sandi Lama";
            // 
            // txtSandiLama
            // 
            txtSandiLama.BackColor = Color.White;
            txtSandiLama.Font = new Font("Inter", 10F);
            txtSandiLama.ForeColor = Color.FromArgb(31, 41, 55);
            txtSandiLama.Location = new Point(28, 102);
            txtSandiLama.MaxLength = 64;
            txtSandiLama.Name = "txtSandiLama";
            txtSandiLama.Size = new Size(404, 24);
            txtSandiLama.TabIndex = 3;
            txtSandiLama.UseSystemPasswordChar = true;
            // 
            // lblSandiBaru
            // 
            lblSandiBaru.AutoSize = true;
            lblSandiBaru.BackColor = Color.Transparent;
            lblSandiBaru.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblSandiBaru.ForeColor = Color.FromArgb(75, 85, 99);
            lblSandiBaru.Location = new Point(28, 138);
            lblSandiBaru.Name = "lblSandiBaru";
            lblSandiBaru.Size = new Size(102, 15);
            lblSandiBaru.TabIndex = 4;
            lblSandiBaru.Text = "Kata Sandi Baru";
            // 
            // txtSandiBaru
            // 
            txtSandiBaru.BackColor = Color.White;
            txtSandiBaru.Font = new Font("Inter", 10F);
            txtSandiBaru.ForeColor = Color.FromArgb(31, 41, 55);
            txtSandiBaru.Location = new Point(28, 160);
            txtSandiBaru.MaxLength = 64;
            txtSandiBaru.Name = "txtSandiBaru";
            txtSandiBaru.Size = new Size(404, 24);
            txtSandiBaru.TabIndex = 5;
            txtSandiBaru.UseSystemPasswordChar = true;
            // 
            // lblKonfirmasiSandi
            // 
            lblKonfirmasiSandi.AutoSize = true;
            lblKonfirmasiSandi.BackColor = Color.Transparent;
            lblKonfirmasiSandi.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKonfirmasiSandi.ForeColor = Color.FromArgb(75, 85, 99);
            lblKonfirmasiSandi.Location = new Point(28, 196);
            lblKonfirmasiSandi.Name = "lblKonfirmasiSandi";
            lblKonfirmasiSandi.Size = new Size(168, 15);
            lblKonfirmasiSandi.TabIndex = 6;
            lblKonfirmasiSandi.Text = "Konfirmasi Kata Sandi Baru";
            // 
            // txtKonfirmasiSandi
            // 
            txtKonfirmasiSandi.BackColor = Color.White;
            txtKonfirmasiSandi.Font = new Font("Inter", 10F);
            txtKonfirmasiSandi.ForeColor = Color.FromArgb(31, 41, 55);
            txtKonfirmasiSandi.Location = new Point(28, 218);
            txtKonfirmasiSandi.MaxLength = 64;
            txtKonfirmasiSandi.Name = "txtKonfirmasiSandi";
            txtKonfirmasiSandi.Size = new Size(404, 24);
            txtKonfirmasiSandi.TabIndex = 7;
            txtKonfirmasiSandi.UseSystemPasswordChar = true;
            // 
            // lblPetunjukSandi
            // 
            lblPetunjukSandi.AutoSize = true;
            lblPetunjukSandi.BackColor = Color.Transparent;
            lblPetunjukSandi.Font = new Font("Inter", 8.5F);
            lblPetunjukSandi.ForeColor = Color.FromArgb(156, 163, 175);
            lblPetunjukSandi.Location = new Point(28, 248);
            lblPetunjukSandi.Name = "lblPetunjukSandi";
            lblPetunjukSandi.Size = new Size(313, 15);
            lblPetunjukSandi.TabIndex = 8;
            lblPetunjukSandi.Text = "Minimal 6 karakter, harus berbeda dari kata sandi lama";
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.White;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatal.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Inter", 10F);
            btnBatal.ForeColor = Color.FromArgb(55, 65, 81);
            btnBatal.Location = new Point(148, 330);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(116, 42);
            btnBatal.TabIndex = 9;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(255, 196, 0);
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 210, 64);
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnSimpan.ForeColor = Color.FromArgb(31, 41, 55);
            btnSimpan.Location = new Point(272, 330);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(160, 42);
            btnSimpan.TabIndex = 10;
            btnSimpan.Text = "Simpan Perubahan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // FormGantiKataSandi
            // 
            AcceptButton = btnSimpan;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            CancelButton = btnBatal;
            ClientSize = new Size(460, 396);
            Controls.Add(lblJudul);
            Controls.Add(lblInfo);
            Controls.Add(lblSandiLama);
            Controls.Add(txtSandiLama);
            Controls.Add(lblSandiBaru);
            Controls.Add(txtSandiBaru);
            Controls.Add(lblKonfirmasiSandi);
            Controls.Add(txtKonfirmasiSandi);
            Controls.Add(lblPetunjukSandi);
            Controls.Add(btnBatal);
            Controls.Add(btnSimpan);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormGantiKataSandi";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ganti Kata Sandi";
            Paint += FormGantiKataSandi_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblJudul;
        private Label lblInfo;
        private Label lblSandiLama;
        private TextBox txtSandiLama;
        private Label lblSandiBaru;
        private TextBox txtSandiBaru;
        private Label lblKonfirmasiSandi;
        private TextBox txtKonfirmasiSandi;
        private Label lblPetunjukSandi;
        private Button btnBatal;
        private Button btnSimpan;
    }
}
