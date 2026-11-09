namespace Sukimart
{
    partial class FormKelolaKategori
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
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(23, 21);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(263, 31);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Kelola Kategori Produk";
            // 
            // lblDaftar
            // 
            lblDaftar.AutoSize = true;
            lblDaftar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDaftar.ForeColor = Color.FromArgb(75, 85, 99);
            lblDaftar.Location = new Point(23, 96);
            lblDaftar.Name = "lblDaftar";
            lblDaftar.Size = new Size(122, 20);
            lblDaftar.TabIndex = 2;
            lblDaftar.Text = "Daftar Kategori:";
            // 
            // lstKategori
            // 
            lstKategori.BorderStyle = BorderStyle.FixedSingle;
            lstKategori.Font = new Font("Segoe UI", 10F);
            lstKategori.FormattingEnabled = true;
            lstKategori.ItemHeight = 23;
            lstKategori.Location = new Point(23, 127);
            lstKategori.Margin = new Padding(3, 4, 3, 4);
            lstKategori.Name = "lstKategori";
            lstKategori.Size = new Size(251, 301);
            lstKategori.TabIndex = 3;
            lstKategori.SelectedIndexChanged += LstKategori_SelectedIndexChanged;
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInput.ForeColor = Color.FromArgb(75, 85, 99);
            lblInput.Location = new Point(297, 96);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(119, 20);
            lblInput.TabIndex = 4;
            lblInput.Text = "Nama Kategori:";
            // 
            // txtNamaKategori
            // 
            txtNamaKategori.Font = new Font("Segoe UI", 10F);
            txtNamaKategori.Location = new Point(297, 127);
            txtNamaKategori.Margin = new Padding(3, 4, 3, 4);
            txtNamaKategori.Name = "txtNamaKategori";
            txtNamaKategori.PlaceholderText = "Ketik nama kategori...";
            txtNamaKategori.Size = new Size(239, 30);
            txtNamaKategori.TabIndex = 5;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.FromArgb(255, 196, 0);
            btnTambah.Cursor = Cursors.Hand;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTambah.ForeColor = Color.FromArgb(31, 41, 55);
            btnTambah.Location = new Point(297, 173);
            btnTambah.Margin = new Padding(3, 4, 3, 4);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(240, 45);
            btnTambah.TabIndex = 6;
            btnTambah.Text = "+ Tambah Kategori";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += BtnTambah_Click;
            // 
            // btnGantiNama
            // 
            btnGantiNama.BackColor = Color.White;
            btnGantiNama.Cursor = Cursors.Hand;
            btnGantiNama.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnGantiNama.FlatStyle = FlatStyle.Flat;
            btnGantiNama.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGantiNama.ForeColor = Color.FromArgb(55, 65, 81);
            btnGantiNama.Location = new Point(297, 229);
            btnGantiNama.Margin = new Padding(3, 4, 3, 4);
            btnGantiNama.Name = "btnGantiNama";
            btnGantiNama.Size = new Size(240, 45);
            btnGantiNama.TabIndex = 7;
            btnGantiNama.Text = "✏️ Ganti Nama Kategori";
            btnGantiNama.UseVisualStyleBackColor = false;
            btnGantiNama.Click += BtnGantiNama_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.White;
            btnHapus.Cursor = Cursors.Hand;
            btnHapus.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHapus.ForeColor = Color.FromArgb(220, 38, 38);
            btnHapus.Location = new Point(297, 285);
            btnHapus.Margin = new Padding(3, 4, 3, 4);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(240, 45);
            btnHapus.TabIndex = 8;
            btnHapus.Text = "🗑️ Hapus Kategori";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += BtnHapus_Click;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 8.25F);
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(297, 341);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(240, 64);
            lblInfo.TabIndex = 9;
            lblInfo.Text = "Pilih kategori dari daftar di sebelah kiri untuk mengganti nama atau menghapusnya.";
            // 
            // btnTutup
            // 
            btnTutup.BackColor = Color.FromArgb(229, 231, 235);
            btnTutup.Cursor = Cursors.Hand;
            btnTutup.FlatAppearance.BorderSize = 0;
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTutup.ForeColor = Color.FromArgb(55, 65, 81);
            btnTutup.Location = new Point(297, 405);
            btnTutup.Margin = new Padding(3, 4, 3, 4);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(240, 45);
            btnTutup.TabIndex = 10;
            btnTutup.Text = "Selesai";
            btnTutup.UseVisualStyleBackColor = false;
            btnTutup.Click += BtnTutup_Click;
            // 
            // FormKelolaKategori
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            ClientSize = new Size(565, 481);
            Controls.Add(btnTutup);
            Controls.Add(lblInfo);
            Controls.Add(btnHapus);
            Controls.Add(btnGantiNama);
            Controls.Add(btnTambah);
            Controls.Add(txtNamaKategori);
            Controls.Add(lblInput);
            Controls.Add(lstKategori);
            Controls.Add(lblDaftar);
            Controls.Add(lblJudul);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormKelolaKategori";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kelola Kategori Produk";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
