namespace Sukimart
{
    partial class FormKelolaKategori
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
            lblDaftar = new Label();
            lstKategori = new ListBox();
            lblInput = new Label();
            txtNamaKategori = new TextBox();
            btnTambah = new Button();
            btnGantiNama = new Button();
            btnHapus = new Button();
            lblInfo = new Label();
            btnTutup = new Button();
            SuspendLayout();
            lblJudul.AutoSize = true;
            lblJudul.BackColor = Color.Transparent;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(24, 24);
            lblJudul.Name = "lblJudul";
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Kelola Kategori";
            lblDaftar.AutoSize = true;
            lblDaftar.BackColor = Color.Transparent;
            lblDaftar.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblDaftar.ForeColor = Color.FromArgb(75, 85, 99);
            lblDaftar.Location = new Point(24, 72);
            lblDaftar.Name = "lblDaftar";
            lblDaftar.TabIndex = 1;
            lblDaftar.Text = "Daftar Kategori";
            lstKategori.BackColor = Color.White;
            lstKategori.BorderStyle = BorderStyle.FixedSingle;
            lstKategori.Font = new Font("Inter", 10F);
            lstKategori.ForeColor = Color.FromArgb(31, 41, 55);
            lstKategori.FormattingEnabled = true;
            lstKategori.IntegralHeight = false;
            lstKategori.ItemHeight = 17;
            lstKategori.Location = new Point(24, 92);
            lstKategori.Name = "lstKategori";
            lstKategori.Size = new Size(240, 300);
            lstKategori.TabIndex = 2;
            lstKategori.SelectedIndexChanged += LstKategori_SelectedIndexChanged;
            lblInput.AutoSize = true;
            lblInput.BackColor = Color.Transparent;
            lblInput.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblInput.ForeColor = Color.FromArgb(75, 85, 99);
            lblInput.Location = new Point(288, 72);
            lblInput.Name = "lblInput";
            lblInput.TabIndex = 3;
            lblInput.Text = "Nama Kategori";
            txtNamaKategori.BackColor = Color.White;
            txtNamaKategori.Font = new Font("Inter", 10F);
            txtNamaKategori.ForeColor = Color.FromArgb(31, 41, 55);
            txtNamaKategori.Location = new Point(288, 92);
            txtNamaKategori.Name = "txtNamaKategori";
            txtNamaKategori.PlaceholderText = "Ketik nama kategori";
            txtNamaKategori.Size = new Size(248, 24);
            txtNamaKategori.TabIndex = 4;
            btnTambah.BackColor = Color.FromArgb(255, 196, 0);
            btnTambah.Cursor = Cursors.Hand;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 210, 64);
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnTambah.ForeColor = Color.FromArgb(31, 41, 55);
            btnTambah.Location = new Point(288, 132);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(248, 40);
            btnTambah.TabIndex = 5;
            btnTambah.Text = "+ Tambah Kategori";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += BtnTambah_Click;
            btnGantiNama.BackColor = Color.White;
            btnGantiNama.Cursor = Cursors.Hand;
            btnGantiNama.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnGantiNama.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnGantiNama.FlatStyle = FlatStyle.Flat;
            btnGantiNama.Font = new Font("Inter", 10F);
            btnGantiNama.ForeColor = Color.FromArgb(55, 65, 81);
            btnGantiNama.Location = new Point(288, 180);
            btnGantiNama.Name = "btnGantiNama";
            btnGantiNama.Size = new Size(248, 40);
            btnGantiNama.TabIndex = 6;
            btnGantiNama.Text = "Ganti Nama";
            btnGantiNama.UseVisualStyleBackColor = false;
            btnGantiNama.Click += BtnGantiNama_Click;
            btnHapus.BackColor = Color.White;
            btnHapus.Cursor = Cursors.Hand;
            btnHapus.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnHapus.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 242, 242);
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnHapus.ForeColor = Color.FromArgb(220, 38, 38);
            btnHapus.Location = new Point(288, 228);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(248, 40);
            btnHapus.TabIndex = 7;
            btnHapus.Text = "Hapus Kategori";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += BtnHapus_Click;
            lblInfo.AutoSize = false;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Inter", 9F);
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(288, 280);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(248, 64);
            lblInfo.TabIndex = 8;
            lblInfo.Text = "Pilih kategori di daftar untuk mengganti nama atau menghapusnya.";
            btnTutup.BackColor = Color.White;
            btnTutup.Cursor = Cursors.Hand;
            btnTutup.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTutup.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.Font = new Font("Inter", 10F);
            btnTutup.ForeColor = Color.FromArgb(55, 65, 81);
            btnTutup.Location = new Point(288, 352);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(248, 40);
            btnTutup.TabIndex = 9;
            btnTutup.Text = "Selesai";
            btnTutup.UseVisualStyleBackColor = false;
            btnTutup.Click += BtnTutup_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            ClientSize = new Size(560, 416);
            Controls.Add(lblJudul);
            Controls.Add(lblDaftar);
            Controls.Add(lstKategori);
            Controls.Add(lblInput);
            Controls.Add(txtNamaKategori);
            Controls.Add(btnTambah);
            Controls.Add(btnGantiNama);
            Controls.Add(btnHapus);
            Controls.Add(lblInfo);
            Controls.Add(btnTutup);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormKelolaKategori";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kelola Kategori";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblJudul;
        private Label lblDaftar;
        private ListBox lstKategori;
        private Label lblInput;
        private TextBox txtNamaKategori;
        private Button btnTambah;
        private Button btnGantiNama;
        private Button btnHapus;
        private Label lblInfo;
        private Button btnTutup;
    }
}
