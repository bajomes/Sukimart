namespace Sukimart
{
    partial class FormGudang
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
            lblJudul = new Label();
            txtCariGudang = new TextBox();
            btnFilterMenipis = new Button();
            btnSemuaStok = new Button();
            gridGudang = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colKategori = new DataGridViewTextBoxColumn();
            colStok = new DataGridViewTextBoxColumn();
            colMinStok = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlRestock = new Panel();
            lblPilihBarangRestock = new Label();
            txtBarangTerpilih = new TextBox();
            lblJumlahMasuk = new Label();
            nudJumlahMasuk = new NumericUpDown();
            btnSimpanStok = new Button();
            btnRiwayatStok = new Button();
            lblJenisStok = new Label();
            cmbJenisStok = new ComboBox();
            lblKeterangan = new Label();
            txtKeterangan = new TextBox();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridGudang).BeginInit();
            pnlRestock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudJumlahMasuk).BeginInit();
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
            pnlKiri.TabIndex = 1;
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
            btnGudang.BackColor = Color.FromArgb(255, 196, 0);
            btnGudang.Cursor = Cursors.Hand;
            btnGudang.FlatAppearance.BorderSize = 0;
            btnGudang.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnGudang.FlatStyle = FlatStyle.Flat;
            btnGudang.Font = new Font("Inter", 10F, FontStyle.Bold);
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
            btnKatalog.BackColor = Color.White;
            btnKatalog.Cursor = Cursors.Hand;
            btnKatalog.FlatAppearance.BorderSize = 0;
            btnKatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKatalog.FlatStyle = FlatStyle.Flat;
            btnKatalog.Font = new Font("Inter", 10F);
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
            pnlKanan.Controls.Add(lblJudul);
            pnlKanan.Controls.Add(txtCariGudang);
            pnlKanan.Controls.Add(btnFilterMenipis);
            pnlKanan.Controls.Add(btnSemuaStok);
            pnlKanan.Controls.Add(btnRiwayatStok);
            pnlKanan.Controls.Add(gridGudang);
            pnlKanan.Controls.Add(pnlRestock);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(240, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(1040, 720);
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
            nightControlBox1.Location = new Point(901, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 0;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(40, 32);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(280, 33);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Manajemen Gudang";
            // 
            // txtCariGudang
            // 
            txtCariGudang.Font = new Font("Inter", 10F);
            txtCariGudang.Location = new Point(40, 116);
            txtCariGudang.Name = "txtCariGudang";
            txtCariGudang.PlaceholderText = "Cari kode, nama, atau kategori produk...";
            txtCariGudang.Size = new Size(504, 23);
            txtCariGudang.TabIndex = 3;
            // 
            // btnFilterMenipis
            // 
            btnFilterMenipis.BackColor = Color.White;
            btnFilterMenipis.Cursor = Cursors.Hand;
            btnFilterMenipis.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnFilterMenipis.FlatStyle = FlatStyle.Flat;
            btnFilterMenipis.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnFilterMenipis.ForeColor = Color.FromArgb(220, 38, 38);
            btnFilterMenipis.Location = new Point(712, 112);
            btnFilterMenipis.Name = "btnFilterMenipis";
            btnFilterMenipis.Size = new Size(136, 32);
            btnFilterMenipis.TabIndex = 4;
            btnFilterMenipis.Text = "Stok Menipis";
            btnFilterMenipis.UseVisualStyleBackColor = false;
            // 
            // btnSemuaStok
            // 
            btnSemuaStok.BackColor = Color.White;
            btnSemuaStok.Cursor = Cursors.Hand;
            btnSemuaStok.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSemuaStok.FlatStyle = FlatStyle.Flat;
            btnSemuaStok.Font = new Font("Inter", 10F);
            btnSemuaStok.ForeColor = Color.FromArgb(75, 85, 99);
            btnSemuaStok.Location = new Point(864, 112);
            btnSemuaStok.Name = "btnSemuaStok";
            btnSemuaStok.Size = new Size(136, 32);
            btnSemuaStok.TabIndex = 5;
            btnSemuaStok.Text = "Semua Stok";
            btnSemuaStok.UseVisualStyleBackColor = false;
            // 
            // gridGudang
            // 
            gridGudang.AllowUserToAddRows = false;
            gridGudang.AllowUserToDeleteRows = false;
            gridGudang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridGudang.BackgroundColor = Color.White;
            gridGudang.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridGudang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridGudang.ColumnHeadersHeight = 40;
            gridGudang.Columns.AddRange(new DataGridViewColumn[] { colKode, colNama, colKategori, colStok, colMinStok, colStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Inter", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridGudang.DefaultCellStyle = dataGridViewCellStyle2;
            gridGudang.EnableHeadersVisualStyles = false;
            gridGudang.Location = new Point(40, 160);
            gridGudang.MultiSelect = false;
            gridGudang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridGudang.GridColor = Color.FromArgb(229, 231, 235);
            gridGudang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridGudang.Name = "gridGudang";
            gridGudang.ReadOnly = true;
            gridGudang.RowHeadersVisible = false;
            gridGudang.RowTemplate.Height = 36;
            gridGudang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridGudang.Size = new Size(960, 392);
            gridGudang.TabIndex = 6;
            // 
            // colKode
            // 
            colKode.DataPropertyName = "Kode";
            colKode.FillWeight = 80F;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.DataPropertyName = "Nama";
            colNama.FillWeight = 180F;
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
            // colStok
            // 
            colStok.DataPropertyName = "Stok";
            colStok.FillWeight = 70F;
            colStok.HeaderText = "Stok Saat Ini";
            colStok.Name = "colStok";
            colStok.ReadOnly = true;
            // 
            // colMinStok
            // 
            colMinStok.DataPropertyName = "StokMinimum";
            colMinStok.FillWeight = 70F;
            colMinStok.HeaderText = "Min. Stok";
            colMinStok.Name = "colMinStok";
            colMinStok.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "StatusStok";
            colStatus.FillWeight = 85F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // pnlRestock
            // 
            pnlRestock.BackColor = Color.White;
            pnlRestock.BorderStyle = BorderStyle.None;
            pnlRestock.Controls.Add(lblPilihBarangRestock);
            pnlRestock.Controls.Add(txtBarangTerpilih);
            pnlRestock.Controls.Add(lblJumlahMasuk);
            pnlRestock.Controls.Add(nudJumlahMasuk);
            pnlRestock.Controls.Add(btnSimpanStok);
            pnlRestock.Controls.Add(lblJenisStok);
            pnlRestock.Controls.Add(cmbJenisStok);
            pnlRestock.Controls.Add(lblKeterangan);
            pnlRestock.Controls.Add(txtKeterangan);
            pnlRestock.Location = new Point(40, 576);
            pnlRestock.Name = "pnlRestock";
            pnlRestock.Size = new Size(960, 104);
            pnlRestock.TabIndex = 7;
            // 
            // lblPilihBarangRestock
            // 
            lblPilihBarangRestock.AutoSize = true;
            lblPilihBarangRestock.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPilihBarangRestock.ForeColor = Color.FromArgb(75, 85, 99);
            lblPilihBarangRestock.Location = new Point(24, 24);
            lblPilihBarangRestock.Name = "lblPilihBarangRestock";
            lblPilihBarangRestock.Size = new Size(209, 15);
            lblPilihBarangRestock.TabIndex = 1;
            lblPilihBarangRestock.Text = "Produk Terpilih";
            // 
            // txtBarangTerpilih
            // 
            txtBarangTerpilih.BackColor = Color.FromArgb(249, 250, 251);
            txtBarangTerpilih.Font = new Font("Inter", 10F);
            txtBarangTerpilih.Location = new Point(24, 48);
            txtBarangTerpilih.Name = "txtBarangTerpilih";
            txtBarangTerpilih.PlaceholderText = "Klik baris pada tabel di atas";
            txtBarangTerpilih.ReadOnly = true;
            txtBarangTerpilih.Size = new Size(296, 23);
            txtBarangTerpilih.TabIndex = 2;
            // 
            // lblJumlahMasuk
            // 
            lblJumlahMasuk.AutoSize = true;
            lblJumlahMasuk.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJumlahMasuk.ForeColor = Color.FromArgb(75, 85, 99);
            lblJumlahMasuk.Location = new Point(488, 24);
            lblJumlahMasuk.Name = "lblJumlahMasuk";
            lblJumlahMasuk.Size = new Size(150, 15);
            lblJumlahMasuk.TabIndex = 3;
            lblJumlahMasuk.Text = "Jumlah";
            // 
            // nudJumlahMasuk
            // 
            nudJumlahMasuk.Font = new Font("Inter", 10F);
            nudJumlahMasuk.Location = new Point(488, 48);
            nudJumlahMasuk.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudJumlahMasuk.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudJumlahMasuk.Name = "nudJumlahMasuk";
            nudJumlahMasuk.Size = new Size(104, 24);
            nudJumlahMasuk.TabIndex = 4;
            nudJumlahMasuk.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnSimpanStok
            // 
            btnSimpanStok.BackColor = Color.FromArgb(255, 196, 0);
            btnSimpanStok.Cursor = Cursors.Hand;
            btnSimpanStok.FlatAppearance.BorderSize = 0;
            btnSimpanStok.FlatStyle = FlatStyle.Flat;
            btnSimpanStok.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnSimpanStok.ForeColor = Color.FromArgb(31, 41, 55);
            btnSimpanStok.Location = new Point(808, 44);
            btnSimpanStok.Name = "btnSimpanStok";
            btnSimpanStok.Size = new Size(128, 32);
            btnSimpanStok.TabIndex = 6;
            btnSimpanStok.Text = "Simpan";
            btnSimpanStok.UseVisualStyleBackColor = false;
            // 
            // FormGudang
            // 
            btnRiwayatStok.BackColor = Color.White;
            btnRiwayatStok.Cursor = Cursors.Hand;
            btnRiwayatStok.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnRiwayatStok.FlatStyle = FlatStyle.Flat;
            btnRiwayatStok.Font = new Font("Inter", 10F);
            btnRiwayatStok.ForeColor = Color.FromArgb(75, 85, 99);
            btnRiwayatStok.Location = new Point(560, 112);
            btnRiwayatStok.Name = "btnRiwayatStok";
            btnRiwayatStok.Size = new Size(136, 32);
            btnRiwayatStok.TabIndex = 8;
            btnRiwayatStok.Text = "Riwayat Stok";
            btnRiwayatStok.UseVisualStyleBackColor = false;
            lblJenisStok.AutoSize = true;
            lblJenisStok.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJenisStok.ForeColor = Color.FromArgb(75, 85, 99);
            lblJenisStok.Location = new Point(336, 24);
            lblJenisStok.Name = "lblJenisStok";
            lblJenisStok.Size = new Size(34, 15);
            lblJenisStok.TabIndex = 7;
            lblJenisStok.Text = "Jenis";
            cmbJenisStok.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenisStok.Font = new Font("Inter", 10F);
            cmbJenisStok.Items.AddRange(new object[] { "Stok Masuk", "Stok Keluar" });
            cmbJenisStok.Location = new Point(336, 48);
            cmbJenisStok.Name = "cmbJenisStok";
            cmbJenisStok.Size = new Size(136, 24);
            cmbJenisStok.TabIndex = 3;
            lblKeterangan.AutoSize = true;
            lblKeterangan.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKeterangan.ForeColor = Color.FromArgb(75, 85, 99);
            lblKeterangan.Location = new Point(608, 24);
            lblKeterangan.Name = "lblKeterangan";
            lblKeterangan.Size = new Size(72, 15);
            lblKeterangan.TabIndex = 8;
            lblKeterangan.Text = "Keterangan";
            txtKeterangan.Font = new Font("Inter", 10F);
            txtKeterangan.Location = new Point(608, 48);
            txtKeterangan.MaxLength = 100;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.PlaceholderText = "Opsional";
            txtKeterangan.Size = new Size(184, 23);
            txtKeterangan.TabIndex = 5;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGudang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gudang";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridGudang).EndInit();
            pnlRestock.ResumeLayout(false);
            pnlRestock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudJumlahMasuk).EndInit();
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
        private Label lblJudul;
        private TextBox txtCariGudang;
        private Button btnFilterMenipis;
        private Button btnSemuaStok;
        private DataGridView gridGudang;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colKategori;
        private DataGridViewTextBoxColumn colStok;
        private DataGridViewTextBoxColumn colMinStok;
        private DataGridViewTextBoxColumn colStatus;
        private Panel pnlRestock;
        private Label lblPilihBarangRestock;
        private TextBox txtBarangTerpilih;
        private Label lblJumlahMasuk;
        private NumericUpDown nudJumlahMasuk;
        private Button btnSimpanStok;
        private Button btnRiwayatStok;
        private Label lblJenisStok;
        private ComboBox cmbJenisStok;
        private Label lblKeterangan;
        private TextBox txtKeterangan;
    }
}
