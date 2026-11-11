namespace Sukimart
{
    partial class FormKatalog
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlKiri = new Panel();
            btnKeluar = new Button();
            btnLaporan = new Button();
            btnPengguna = new Button();
            btnGudang = new Button();
            btnRiwayat = new Button();
            btnKatalog = new Button();
            btnKasir = new Button();
            btnDashboard = new Button();
            pictureLogo = new PictureBox();
            lblNama = new Label();
            pnlKanan = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblJudulKatalog = new Label();
            txtCari = new TextBox();
            gridBarang = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colKategori = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colStok = new DataGridViewTextBoxColumn();
            colStokMin = new DataGridViewTextBoxColumn();
            btnTambahItem = new Button();
            btnEditProduk = new Button();
            btnHapusBarang = new Button();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBarang).BeginInit();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.White;
            pnlKiri.Controls.Add(btnKeluar);
            pnlKiri.Controls.Add(btnPengguna);
            pnlKiri.Controls.Add(btnLaporan);
            pnlKiri.Controls.Add(btnGudang);
            pnlKiri.Controls.Add(btnRiwayat);
            pnlKiri.Controls.Add(btnKatalog);
            pnlKiri.Controls.Add(btnKasir);
            pnlKiri.Controls.Add(btnDashboard);
            pnlKiri.Controls.Add(pictureLogo);
            pnlKiri.Controls.Add(lblNama);
            pnlKiri.Dock = DockStyle.Left;
            pnlKiri.Location = new Point(0, 0);
            pnlKiri.Name = "pnlKiri";
            pnlKiri.Size = new Size(240, 720);
            pnlKiri.TabIndex = 2;
            // 
            // btnKeluar
            // 
            btnKeluar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKeluar.BackColor = Color.White;
            btnKeluar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnKeluar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Inter", 10F);
            btnKeluar.ForeColor = Color.FromArgb(75, 85, 99);
            btnKeluar.Location = new Point(16, 640);
            btnKeluar.Padding = new Padding(16, 0, 0, 0);
            btnKeluar.TextAlign = ContentAlignment.MiddleLeft;
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(208, 40);
            btnKeluar.TabIndex = 11;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = false;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.White;
            btnLaporan.Cursor = Cursors.Hand;
            btnLaporan.FlatAppearance.BorderSize = 0;
            btnLaporan.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.Font = new Font("Inter", 10F);
            btnLaporan.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporan.Location = new Point(16, 352);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Padding = new Padding(16, 0, 0, 0);
            btnLaporan.Size = new Size(208, 40);
            btnLaporan.TabIndex = 10;
            btnLaporan.Text = "Laporan";
            btnLaporan.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporan.UseVisualStyleBackColor = false;
            btnPengguna.BackColor = Color.White;
            btnPengguna.Cursor = Cursors.Hand;
            btnPengguna.FlatAppearance.BorderSize = 0;
            btnPengguna.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnPengguna.FlatStyle = FlatStyle.Flat;
            btnPengguna.Font = new Font("Inter", 10F);
            btnPengguna.ForeColor = Color.FromArgb(31, 41, 55);
            btnPengguna.Location = new Point(16, 400);
            btnPengguna.Name = "btnPengguna";
            btnPengguna.Padding = new Padding(16, 0, 0, 0);
            btnPengguna.Size = new Size(208, 40);
            btnPengguna.TabIndex = 12;
            btnPengguna.Text = "Pengguna";
            btnPengguna.TextAlign = ContentAlignment.MiddleLeft;
            btnPengguna.UseVisualStyleBackColor = false;
            // 
            // btnGudang
            // 
            btnGudang.BackColor = Color.White;
            btnGudang.Cursor = Cursors.Hand;
            btnGudang.FlatAppearance.BorderSize = 0;
            btnGudang.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnGudang.FlatStyle = FlatStyle.Flat;
            btnGudang.Font = new Font("Inter", 10F);
            btnGudang.ForeColor = Color.FromArgb(31, 41, 55);
            btnGudang.Location = new Point(16, 304);
            btnGudang.Name = "btnGudang";
            btnGudang.Padding = new Padding(16, 0, 0, 0);
            btnGudang.Size = new Size(208, 40);
            btnGudang.TabIndex = 9;
            btnGudang.Text = "Gudang";
            btnGudang.TextAlign = ContentAlignment.MiddleLeft;
            btnGudang.UseVisualStyleBackColor = false;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.White;
            btnRiwayat.Cursor = Cursors.Hand;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Inter", 10F);
            btnRiwayat.ForeColor = Color.FromArgb(31, 41, 55);
            btnRiwayat.Location = new Point(16, 256);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Padding = new Padding(16, 0, 0, 0);
            btnRiwayat.Size = new Size(208, 40);
            btnRiwayat.TabIndex = 6;
            btnRiwayat.Text = "Riwayat Transaksi";
            btnRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btnRiwayat.UseVisualStyleBackColor = false;
            // 
            // btnKatalog
            // 
            btnKatalog.BackColor = Color.FromArgb(255, 196, 0);
            btnKatalog.Cursor = Cursors.Hand;
            btnKatalog.FlatAppearance.BorderSize = 0;
            btnKatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKatalog.FlatStyle = FlatStyle.Flat;
            btnKatalog.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnKatalog.ForeColor = Color.FromArgb(31, 41, 55);
            btnKatalog.Location = new Point(16, 208);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Padding = new Padding(16, 0, 0, 0);
            btnKatalog.Size = new Size(208, 40);
            btnKatalog.TabIndex = 5;
            btnKatalog.Text = "Katalog Produk";
            btnKatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnKatalog.UseVisualStyleBackColor = false;
            // 
            // btnKasir
            // 
            btnKasir.BackColor = Color.White;
            btnKasir.Cursor = Cursors.Hand;
            btnKasir.FlatAppearance.BorderSize = 0;
            btnKasir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKasir.FlatStyle = FlatStyle.Flat;
            btnKasir.Font = new Font("Inter", 10F);
            btnKasir.ForeColor = Color.FromArgb(31, 41, 55);
            btnKasir.Location = new Point(16, 160);
            btnKasir.Name = "btnKasir";
            btnKasir.Padding = new Padding(16, 0, 0, 0);
            btnKasir.Size = new Size(208, 40);
            btnKasir.TabIndex = 4;
            btnKasir.Text = "Kasir / POS";
            btnKasir.TextAlign = ContentAlignment.MiddleLeft;
            btnKasir.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Inter", 10F);
            btnDashboard.ForeColor = Color.FromArgb(31, 41, 55);
            btnDashboard.Location = new Point(16, 112);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(16, 0, 0, 0);
            btnDashboard.Size = new Size(208, 40);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pictureLogo
            // 
            pictureLogo.Image = Properties.Resources.logo;
            pictureLogo.Location = new Point(24, 32);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(40, 40);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 2;
            pictureLogo.TabStop = false;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblNama.Location = new Point(72, 40);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(112, 23);
            lblNama.TabIndex = 1;
            lblNama.Text = "SUKIMART";
            // 
            // pnlKanan
            // 
            pnlKanan.BackColor = Color.FromArgb(247, 247, 245);
            pnlKanan.Controls.Add(nightControlBox1);
            pnlKanan.Controls.Add(lblJudulKatalog);
            pnlKanan.Controls.Add(txtCari);
            pnlKanan.Controls.Add(gridBarang);
            pnlKanan.Controls.Add(btnTambahItem);
            pnlKanan.Controls.Add(btnEditProduk);
            pnlKanan.Controls.Add(btnHapusBarang);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(240, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(1040, 720);
            pnlKanan.TabIndex = 4;
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
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(901, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 0;
            // 
            // lblJudulKatalog
            // 
            lblJudulKatalog.AutoSize = true;
            lblJudulKatalog.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblJudulKatalog.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudulKatalog.Location = new Point(40, 32);
            lblJudulKatalog.Name = "lblJudulKatalog";
            lblJudulKatalog.Size = new Size(218, 33);
            lblJudulKatalog.TabIndex = 1;
            lblJudulKatalog.Text = "Katalog Produk";
            // 
            // txtCari
            // 
            txtCari.BackColor = Color.White;
            txtCari.Font = new Font("Inter", 10F);
            txtCari.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCari.Location = new Point(40, 116);
            txtCari.Name = "txtCari";
            txtCari.PlaceholderText = "Cari berdasarkan nama, kode, atau kategori barang...";
            txtCari.Size = new Size(960, 24);
            txtCari.TabIndex = 3;
            // 
            // gridBarang
            // 
            gridBarang.AllowUserToAddRows = false;
            gridBarang.AllowUserToDeleteRows = false;
            gridBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridBarang.BackgroundColor = Color.White;
            gridBarang.BorderStyle = BorderStyle.None;
            gridBarang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridBarang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridBarang.ColumnHeadersHeight = 40;
            gridBarang.Columns.AddRange(new DataGridViewColumn[] { colKode, colNama, colKategori, colHarga, colStok, colStokMin });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Inter", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridBarang.DefaultCellStyle = dataGridViewCellStyle2;
            gridBarang.EnableHeadersVisualStyles = false;
            gridBarang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridBarang.Location = new Point(40, 160);
            gridBarang.MultiSelect = false;
            gridBarang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridBarang.GridColor = Color.FromArgb(229, 231, 235);
            gridBarang.Name = "gridBarang";
            gridBarang.ReadOnly = true;
            gridBarang.RowHeadersVisible = false;
            gridBarang.RowTemplate.Height = 36;
            gridBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridBarang.Size = new Size(960, 456);
            gridBarang.TabIndex = 4;
            // 
            // colKode
            // 
            colKode.DataPropertyName = "Kode";
            colKode.FillWeight = 75F;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.DataPropertyName = "Nama";
            colNama.FillWeight = 160F;
            colNama.HeaderText = "Nama Barang";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            // 
            // colKategori
            // 
            colKategori.DataPropertyName = "Kategori";
            colKategori.HeaderText = "Kategori";
            colKategori.Name = "colKategori";
            colKategori.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.DataPropertyName = "HargaFormat";
            colHarga.FillWeight = 95F;
            colHarga.HeaderText = "Harga (Rp)";
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colStok
            // 
            colStok.DataPropertyName = "Stok";
            colStok.FillWeight = 55F;
            colStok.HeaderText = "Stok";
            colStok.Name = "colStok";
            colStok.ReadOnly = true;
            // 
            // colStokMin
            // 
            colStokMin.DataPropertyName = "StokMinimum";
            colStokMin.FillWeight = 65F;
            colStokMin.HeaderText = "Min Stok";
            colStokMin.Name = "colStokMin";
            colStokMin.ReadOnly = true;
            btnTambahItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTambahItem.BackColor = Color.FromArgb(255, 196, 0);
            btnTambahItem.Cursor = Cursors.Hand;
            btnTambahItem.FlatAppearance.BorderSize = 0;
            btnTambahItem.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 210, 64);
            btnTambahItem.FlatStyle = FlatStyle.Flat;
            btnTambahItem.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnTambahItem.ForeColor = Color.FromArgb(31, 41, 55);
            btnTambahItem.Location = new Point(40, 640);
            btnTambahItem.Name = "btnTambahItem";
            btnTambahItem.Size = new Size(152, 40);
            btnTambahItem.TabIndex = 5;
            btnTambahItem.Text = "+ Tambah Item";
            btnTambahItem.UseVisualStyleBackColor = false;
            btnEditProduk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditProduk.BackColor = Color.White;
            btnEditProduk.Cursor = Cursors.Hand;
            btnEditProduk.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnEditProduk.FlatStyle = FlatStyle.Flat;
            btnEditProduk.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnEditProduk.ForeColor = Color.FromArgb(55, 65, 81);
            btnEditProduk.Location = new Point(208, 640);
            btnEditProduk.Name = "btnEditProduk";
            btnEditProduk.Size = new Size(144, 40);
            btnEditProduk.TabIndex = 6;
            btnEditProduk.Text = "Edit Produk";
            btnEditProduk.UseVisualStyleBackColor = false;
            // 
            // btnHapusBarang
            // 
            btnHapusBarang.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHapusBarang.BackColor = Color.White;
            btnHapusBarang.Cursor = Cursors.Hand;
            btnHapusBarang.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnHapusBarang.FlatStyle = FlatStyle.Flat;
            btnHapusBarang.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnHapusBarang.ForeColor = Color.FromArgb(220, 38, 38);
            btnHapusBarang.Location = new Point(368, 640);
            btnHapusBarang.Name = "btnHapusBarang";
            btnHapusBarang.Size = new Size(120, 40);
            btnHapusBarang.TabIndex = 7;
            btnHapusBarang.Text = "Hapus";
            btnHapusBarang.UseVisualStyleBackColor = false;
            // 
            // FormKatalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKatalog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Katalog Produk";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridBarang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKiri;
        private Button btnLaporan;
        private Button btnPengguna;
        private Button btnGudang;
        private Button btnRiwayat;
        private Button btnKatalog;
        private Button btnKasir;
        private Button btnDashboard;
        private PictureBox pictureLogo;
        private Label lblNama;
        private Button btnKeluar;
        private Panel pnlKanan;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblJudulKatalog;
        private TextBox txtCari;
        private DataGridView gridBarang;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colKategori;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colStok;
        private DataGridViewTextBoxColumn colStokMin;
        private Button btnTambahItem;
        private Button btnEditProduk;
        private Button btnHapusBarang;
    }
}