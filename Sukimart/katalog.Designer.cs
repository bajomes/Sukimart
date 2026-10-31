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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlKiri = new Panel();
            btnKeluar = new Button();
            btnLaporan = new Button();
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
            lblKode = new Label();
            txtKode = new TextBox();
            lblNamaBarang = new Label();
            txtNamaBarang = new TextBox();
            lblKategori = new Label();
            cmbKategori = new ComboBox();
            lblHarga = new Label();
            nudHarga = new NumericUpDown();
            lblStok = new Label();
            nudStok = new NumericUpDown();
            lblStokMin = new Label();
            nudStokMinimum = new NumericUpDown();
            btnSimpanBarang = new Button();
            btnUbahBarang = new Button();
            btnHapusBarang = new Button();
            btnBersihkanBarang = new Button();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridBarang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStokMinimum).BeginInit();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.White;
            pnlKiri.Controls.Add(btnKeluar);
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
            pnlKiri.Size = new Size(220, 680);
            pnlKiri.TabIndex = 2;
            // 
            // btnKeluar
            // 
            btnKeluar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKeluar.BackColor = Color.White;
            btnKeluar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnKeluar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Inter", 12F);
            btnKeluar.ForeColor = Color.FromArgb(75, 85, 99);
            btnKeluar.Location = new Point(16, 620);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(188, 44);
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
            btnLaporan.Font = new Font("Inter", 12F);
            btnLaporan.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporan.Location = new Point(16, 350);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Padding = new Padding(12, 0, 0, 0);
            btnLaporan.Size = new Size(188, 44);
            btnLaporan.TabIndex = 10;
            btnLaporan.Text = "Laporan";
            btnLaporan.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporan.UseVisualStyleBackColor = false;
            // 
            // btnGudang
            // 
            btnGudang.BackColor = Color.White;
            btnGudang.Cursor = Cursors.Hand;
            btnGudang.FlatAppearance.BorderSize = 0;
            btnGudang.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnGudang.FlatStyle = FlatStyle.Flat;
            btnGudang.Font = new Font("Inter", 12F);
            btnGudang.ForeColor = Color.FromArgb(31, 41, 55);
            btnGudang.Location = new Point(16, 300);
            btnGudang.Name = "btnGudang";
            btnGudang.Padding = new Padding(12, 0, 0, 0);
            btnGudang.Size = new Size(188, 44);
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
            btnRiwayat.Font = new Font("Inter", 12F);
            btnRiwayat.ForeColor = Color.FromArgb(31, 41, 55);
            btnRiwayat.Location = new Point(16, 250);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Padding = new Padding(12, 0, 0, 0);
            btnRiwayat.Size = new Size(188, 44);
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
            btnKatalog.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKatalog.ForeColor = Color.FromArgb(31, 41, 55);
            btnKatalog.Location = new Point(16, 200);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Padding = new Padding(12, 0, 0, 0);
            btnKatalog.Size = new Size(188, 44);
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
            btnKasir.Font = new Font("Inter", 12F);
            btnKasir.ForeColor = Color.FromArgb(31, 41, 55);
            btnKasir.Location = new Point(16, 150);
            btnKasir.Name = "btnKasir";
            btnKasir.Padding = new Padding(12, 0, 0, 0);
            btnKasir.Size = new Size(188, 44);
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
            btnDashboard.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.FromArgb(31, 41, 55);
            btnDashboard.Location = new Point(16, 100);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(12, 0, 0, 0);
            btnDashboard.Size = new Size(188, 44);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pictureLogo
            // 
            pictureLogo.Image = Properties.Resources.logo;
            pictureLogo.Location = new Point(15, 15);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(50, 50);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 2;
            pictureLogo.TabStop = false;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Inter", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNama.Location = new Point(65, 30);
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
            pnlKanan.Controls.Add(lblKode);
            pnlKanan.Controls.Add(txtKode);
            pnlKanan.Controls.Add(lblNamaBarang);
            pnlKanan.Controls.Add(txtNamaBarang);
            pnlKanan.Controls.Add(lblKategori);
            pnlKanan.Controls.Add(cmbKategori);
            pnlKanan.Controls.Add(lblHarga);
            pnlKanan.Controls.Add(nudHarga);
            pnlKanan.Controls.Add(lblStok);
            pnlKanan.Controls.Add(nudStok);
            pnlKanan.Controls.Add(lblStokMin);
            pnlKanan.Controls.Add(nudStokMinimum);
            pnlKanan.Controls.Add(btnSimpanBarang);
            pnlKanan.Controls.Add(btnUbahBarang);
            pnlKanan.Controls.Add(btnHapusBarang);
            pnlKanan.Controls.Add(btnBersihkanBarang);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(220, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(880, 680);
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
            nightControlBox1.EnableMaximizeButton = false;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(741, 0);
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
            lblJudulKatalog.Location = new Point(30, 20);
            lblJudulKatalog.Name = "lblJudulKatalog";
            lblJudulKatalog.Size = new Size(218, 33);
            lblJudulKatalog.TabIndex = 1;
            lblJudulKatalog.Text = "Katalog Produk";
            // 
            // txtCari
            // 
            txtCari.BackColor = Color.White;
            txtCari.Font = new Font("Inter", 10F);
            txtCari.Location = new Point(30, 85);
            txtCari.Name = "txtCari";
            txtCari.PlaceholderText = "Cari berdasarkan nama, kode, atau kategori barang...";
            txtCari.Size = new Size(815, 24);
            txtCari.TabIndex = 3;
            // 
            // gridBarang
            // 
            gridBarang.AllowUserToAddRows = false;
            gridBarang.AllowUserToDeleteRows = false;
            gridBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridBarang.BackgroundColor = Color.White;
            gridBarang.BorderStyle = BorderStyle.None;
            gridBarang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridBarang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridBarang.ColumnHeadersHeight = 35;
            gridBarang.Columns.AddRange(new DataGridViewColumn[] { colKode, colNama, colKategori, colHarga, colStok, colStokMin });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Inter", 9.5F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridBarang.DefaultCellStyle = dataGridViewCellStyle4;
            gridBarang.EnableHeadersVisualStyles = false;
            gridBarang.Location = new Point(30, 120);
            gridBarang.MultiSelect = false;
            gridBarang.Name = "gridBarang";
            gridBarang.ReadOnly = true;
            gridBarang.RowHeadersVisible = false;
            gridBarang.RowTemplate.Height = 28;
            gridBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridBarang.Size = new Size(815, 230);
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
            // 
            // lblKode
            // 
            lblKode.AutoSize = true;
            lblKode.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKode.ForeColor = Color.FromArgb(75, 85, 99);
            lblKode.Location = new Point(30, 365);
            lblKode.Name = "lblKode";
            lblKode.Size = new Size(83, 15);
            lblKode.TabIndex = 5;
            lblKode.Text = "Kode Barang";
            // 
            // txtKode
            // 
            txtKode.Font = new Font("Inter", 10F);
            txtKode.Location = new Point(30, 385);
            txtKode.Name = "txtKode";
            txtKode.Size = new Size(250, 24);
            txtKode.TabIndex = 6;
            // 
            // lblNamaBarang
            // 
            lblNamaBarang.AutoSize = true;
            lblNamaBarang.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblNamaBarang.ForeColor = Color.FromArgb(75, 85, 99);
            lblNamaBarang.Location = new Point(310, 365);
            lblNamaBarang.Name = "lblNamaBarang";
            lblNamaBarang.Size = new Size(86, 15);
            lblNamaBarang.TabIndex = 7;
            lblNamaBarang.Text = "Nama Barang";
            // 
            // txtNamaBarang
            // 
            txtNamaBarang.Font = new Font("Inter", 10F);
            txtNamaBarang.Location = new Point(310, 385);
            txtNamaBarang.Name = "txtNamaBarang";
            txtNamaBarang.Size = new Size(260, 24);
            txtNamaBarang.TabIndex = 8;
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKategori.ForeColor = Color.FromArgb(75, 85, 99);
            lblKategori.Location = new Point(600, 365);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(57, 15);
            lblKategori.TabIndex = 9;
            lblKategori.Text = "Kategori";
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.Font = new Font("Inter", 10F);
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Items.AddRange(new object[] { "Makanan", "Minuman", "Perlengkapan", "Lainnya" });
            cmbKategori.Location = new Point(600, 385);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(245, 24);
            cmbKategori.TabIndex = 10;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblHarga.ForeColor = Color.FromArgb(75, 85, 99);
            lblHarga.Location = new Point(30, 425);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(72, 15);
            lblHarga.TabIndex = 11;
            lblHarga.Text = "Harga (Rp)";
            // 
            // nudHarga
            // 
            nudHarga.Font = new Font("Inter", 10F);
            nudHarga.Location = new Point(30, 445);
            nudHarga.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudHarga.Name = "nudHarga";
            nudHarga.Size = new Size(250, 24);
            nudHarga.TabIndex = 12;
            nudHarga.ThousandsSeparator = true;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblStok.ForeColor = Color.FromArgb(75, 85, 99);
            lblStok.Location = new Point(310, 425);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(92, 15);
            lblStok.TabIndex = 13;
            lblStok.Text = "Stok Sekarang";
            // 
            // nudStok
            // 
            nudStok.Font = new Font("Inter", 10F);
            nudStok.Location = new Point(310, 445);
            nudStok.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStok.Name = "nudStok";
            nudStok.Size = new Size(260, 24);
            nudStok.TabIndex = 14;
            // 
            // lblStokMin
            // 
            lblStokMin.AutoSize = true;
            lblStokMin.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblStokMin.ForeColor = Color.FromArgb(75, 85, 99);
            lblStokMin.Location = new Point(600, 425);
            lblStokMin.Name = "lblStokMin";
            lblStokMin.Size = new Size(93, 15);
            lblStokMin.TabIndex = 15;
            lblStokMin.Text = "Batas Min Stok";
            // 
            // nudStokMinimum
            // 
            nudStokMinimum.Font = new Font("Inter", 10F);
            nudStokMinimum.Location = new Point(600, 445);
            nudStokMinimum.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStokMinimum.Name = "nudStokMinimum";
            nudStokMinimum.Size = new Size(245, 24);
            nudStokMinimum.TabIndex = 16;
            // 
            // btnSimpanBarang
            // 
            btnSimpanBarang.BackColor = Color.FromArgb(255, 196, 0);
            btnSimpanBarang.Cursor = Cursors.Hand;
            btnSimpanBarang.FlatAppearance.BorderSize = 0;
            btnSimpanBarang.FlatStyle = FlatStyle.Flat;
            btnSimpanBarang.Font = new Font("Inter", 10.5F, FontStyle.Bold);
            btnSimpanBarang.ForeColor = Color.FromArgb(31, 41, 55);
            btnSimpanBarang.Location = new Point(30, 500);
            btnSimpanBarang.Name = "btnSimpanBarang";
            btnSimpanBarang.Size = new Size(160, 40);
            btnSimpanBarang.TabIndex = 17;
            btnSimpanBarang.Text = "+ Tambah Barang";
            btnSimpanBarang.UseVisualStyleBackColor = false;
            // 
            // btnUbahBarang
            // 
            btnUbahBarang.BackColor = Color.White;
            btnUbahBarang.Cursor = Cursors.Hand;
            btnUbahBarang.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnUbahBarang.FlatStyle = FlatStyle.Flat;
            btnUbahBarang.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnUbahBarang.ForeColor = Color.FromArgb(55, 65, 81);
            btnUbahBarang.Location = new Point(205, 500);
            btnUbahBarang.Name = "btnUbahBarang";
            btnUbahBarang.Size = new Size(160, 40);
            btnUbahBarang.TabIndex = 18;
            btnUbahBarang.Text = "Simpan Perubahan";
            btnUbahBarang.UseVisualStyleBackColor = false;
            // 
            // btnHapusBarang
            // 
            btnHapusBarang.BackColor = Color.White;
            btnHapusBarang.Cursor = Cursors.Hand;
            btnHapusBarang.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnHapusBarang.FlatStyle = FlatStyle.Flat;
            btnHapusBarang.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnHapusBarang.ForeColor = Color.FromArgb(220, 38, 38);
            btnHapusBarang.Location = new Point(380, 500);
            btnHapusBarang.Name = "btnHapusBarang";
            btnHapusBarang.Size = new Size(110, 40);
            btnHapusBarang.TabIndex = 19;
            btnHapusBarang.Text = "Hapus";
            btnHapusBarang.UseVisualStyleBackColor = false;
            // 
            // btnBersihkanBarang
            // 
            btnBersihkanBarang.BackColor = Color.White;
            btnBersihkanBarang.Cursor = Cursors.Hand;
            btnBersihkanBarang.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBersihkanBarang.FlatStyle = FlatStyle.Flat;
            btnBersihkanBarang.Font = new Font("Inter", 10F);
            btnBersihkanBarang.ForeColor = Color.FromArgb(107, 114, 128);
            btnBersihkanBarang.Location = new Point(505, 500);
            btnBersihkanBarang.Name = "btnBersihkanBarang";
            btnBersihkanBarang.Size = new Size(110, 40);
            btnBersihkanBarang.TabIndex = 20;
            btnBersihkanBarang.Text = "Bersihkan";
            btnBersihkanBarang.UseVisualStyleBackColor = false;
            // 
            // FormKatalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 680);
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
            ((System.ComponentModel.ISupportInitialize)nudHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStokMinimum).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKiri;
        private Button btnLaporan;
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
        private Label lblKode;
        private TextBox txtKode;
        private Label lblNamaBarang;
        private TextBox txtNamaBarang;
        private Label lblKategori;
        private ComboBox cmbKategori;
        private Label lblHarga;
        private NumericUpDown nudHarga;
        private Label lblStok;
        private NumericUpDown nudStok;
        private Label lblStokMin;
        private NumericUpDown nudStokMinimum;
        private Button btnSimpanBarang;
        private Button btnUbahBarang;
        private Button btnHapusBarang;
        private Button btnBersihkanBarang;
    }
}