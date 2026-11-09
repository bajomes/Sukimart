namespace Sukimart
{
    partial class FormRiwayatTransaksi
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
            btnLihatStruk = new Button();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblJudul = new Label();
            pnlFilter = new Panel();
            txtCari = new TextBox();
            lblDari = new Label();
            dtpMulai = new DateTimePicker();
            lblSampai = new Label();
            dtpSelesai = new DateTimePicker();
            btnFilter = new Button();
            btnReset = new Button();
            pnlRingkasan = new Panel();
            lblStatTransaksi = new Label();
            lblValTransaksi = new Label();
            lblStatOmzet = new Label();
            lblValOmzet = new Label();
            lblStatRata = new Label();
            lblValRata = new Label();
            lblDaftarJudul = new Label();
            gridTransaksi = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colKasir = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colBayar = new DataGridViewTextBoxColumn();
            colKembalian = new DataGridViewTextBoxColumn();
            lblDetailJudul = new Label();
            gridDetail = new DataGridView();
            colDetKode = new DataGridViewTextBoxColumn();
            colDetNama = new DataGridViewTextBoxColumn();
            colDetHarga = new DataGridViewTextBoxColumn();
            colDetJumlah = new DataGridViewTextBoxColumn();
            colDetSubtotal = new DataGridViewTextBoxColumn();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlRingkasan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTransaksi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridDetail).BeginInit();
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
            btnRiwayat.BackColor = Color.FromArgb(255, 196, 0);
            btnRiwayat.Cursor = Cursors.Hand;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Inter", 10F, FontStyle.Bold);
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
            pnlKanan.Controls.Add(pnlFilter);
            pnlKanan.Controls.Add(pnlRingkasan);
            pnlKanan.Controls.Add(lblDaftarJudul);
            pnlKanan.Controls.Add(gridTransaksi);
            pnlKanan.Controls.Add(lblDetailJudul);
            pnlKanan.Controls.Add(gridDetail);
            pnlKanan.Controls.Add(btnLihatStruk);
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
            lblJudul.Size = new Size(256, 33);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Riwayat Transaksi";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.BorderStyle = BorderStyle.None;
            pnlFilter.Controls.Add(txtCari);
            pnlFilter.Controls.Add(lblDari);
            pnlFilter.Controls.Add(dtpMulai);
            pnlFilter.Controls.Add(lblSampai);
            pnlFilter.Controls.Add(dtpSelesai);
            pnlFilter.Controls.Add(btnFilter);
            pnlFilter.Controls.Add(btnReset);
            pnlFilter.Location = new Point(40, 112);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(960, 56);
            pnlFilter.TabIndex = 3;
            // 
            // txtCari
            // 
            txtCari.Font = new Font("Inter", 10F);
            txtCari.Location = new Point(16, 16);
            txtCari.Name = "txtCari";
            txtCari.PlaceholderText = "Cari ID Transaksi atau Kasir...";
            txtCari.Size = new Size(280, 23);
            txtCari.TabIndex = 0;
            // 
            // lblDari
            // 
            lblDari.AutoSize = true;
            lblDari.Font = new Font("Inter", 9F);
            lblDari.ForeColor = Color.FromArgb(75, 85, 99);
            lblDari.Location = new Point(312, 20);
            lblDari.Name = "lblDari";
            lblDari.Size = new Size(34, 15);
            lblDari.TabIndex = 1;
            lblDari.Text = "Dari:";
            // 
            // dtpMulai
            // 
            dtpMulai.Font = new Font("Inter", 10F);
            dtpMulai.Format = DateTimePickerFormat.Short;
            dtpMulai.Location = new Point(352, 16);
            dtpMulai.Name = "dtpMulai";
            dtpMulai.Size = new Size(140, 22);
            dtpMulai.TabIndex = 2;
            // 
            // lblSampai
            // 
            lblSampai.AutoSize = true;
            lblSampai.Font = new Font("Inter", 9F);
            lblSampai.ForeColor = Color.FromArgb(75, 85, 99);
            lblSampai.Location = new Point(508, 20);
            lblSampai.Name = "lblSampai";
            lblSampai.Size = new Size(53, 15);
            lblSampai.TabIndex = 3;
            lblSampai.Text = "Sampai:";
            // 
            // dtpSelesai
            // 
            dtpSelesai.Font = new Font("Inter", 10F);
            dtpSelesai.Format = DateTimePickerFormat.Short;
            dtpSelesai.Location = new Point(568, 16);
            dtpSelesai.Name = "dtpSelesai";
            dtpSelesai.Size = new Size(140, 22);
            dtpSelesai.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(255, 196, 0);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.FromArgb(31, 41, 55);
            btnFilter.Location = new Point(728, 12);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(104, 32);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.White;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Inter", 10F);
            btnReset.ForeColor = Color.FromArgb(107, 114, 128);
            btnReset.Location = new Point(840, 12);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(104, 32);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // pnlRingkasan
            // 
            pnlRingkasan.BackColor = Color.White;
            pnlRingkasan.BorderStyle = BorderStyle.None;
            pnlRingkasan.Controls.Add(lblStatTransaksi);
            pnlRingkasan.Controls.Add(lblValTransaksi);
            pnlRingkasan.Controls.Add(lblStatOmzet);
            pnlRingkasan.Controls.Add(lblValOmzet);
            pnlRingkasan.Controls.Add(lblStatRata);
            pnlRingkasan.Controls.Add(lblValRata);
            pnlRingkasan.Location = new Point(40, 184);
            pnlRingkasan.Name = "pnlRingkasan";
            pnlRingkasan.Size = new Size(960, 64);
            pnlRingkasan.TabIndex = 4;
            // 
            // lblStatTransaksi
            // 
            lblStatTransaksi.AutoSize = true;
            lblStatTransaksi.Font = new Font("Inter", 9F);
            lblStatTransaksi.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatTransaksi.Location = new Point(24, 12);
            lblStatTransaksi.Name = "lblStatTransaksi";
            lblStatTransaksi.Size = new Size(93, 15);
            lblStatTransaksi.TabIndex = 0;
            lblStatTransaksi.Text = "Total Transaksi";
            // 
            // lblValTransaksi
            // 
            lblValTransaksi.AutoSize = true;
            lblValTransaksi.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblValTransaksi.ForeColor = Color.FromArgb(31, 41, 55);
            lblValTransaksi.Location = new Point(24, 32);
            lblValTransaksi.Name = "lblValTransaksi";
            lblValTransaksi.Size = new Size(20, 20);
            lblValTransaksi.TabIndex = 1;
            lblValTransaksi.Text = "0";
            // 
            // lblStatOmzet
            // 
            lblStatOmzet.AutoSize = true;
            lblStatOmzet.Font = new Font("Inter", 9F);
            lblStatOmzet.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatOmzet.Location = new Point(344, 12);
            lblStatOmzet.Name = "lblStatOmzet";
            lblStatOmzet.Size = new Size(76, 15);
            lblStatOmzet.TabIndex = 2;
            lblStatOmzet.Text = "Total Omzet";
            // 
            // lblValOmzet
            // 
            lblValOmzet.AutoSize = true;
            lblValOmzet.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblValOmzet.ForeColor = Color.FromArgb(16, 149, 102);
            lblValOmzet.Location = new Point(344, 32);
            lblValOmzet.Name = "lblValOmzet";
            lblValOmzet.Size = new Size(45, 20);
            lblValOmzet.TabIndex = 3;
            lblValOmzet.Text = "Rp 0";
            // 
            // lblStatRata
            // 
            lblStatRata.AutoSize = true;
            lblStatRata.Font = new Font("Inter", 9F);
            lblStatRata.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatRata.Location = new Point(664, 12);
            lblStatRata.Name = "lblStatRata";
            lblStatRata.Size = new Size(121, 15);
            lblStatRata.TabIndex = 4;
            lblStatRata.Text = "Rata-rata/Transaksi";
            // 
            // lblValRata
            // 
            lblValRata.AutoSize = true;
            lblValRata.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblValRata.ForeColor = Color.FromArgb(31, 41, 55);
            lblValRata.Location = new Point(664, 32);
            lblValRata.Name = "lblValRata";
            lblValRata.Size = new Size(45, 20);
            lblValRata.TabIndex = 5;
            lblValRata.Text = "Rp 0";
            // 
            // lblDaftarJudul
            // 
            lblDaftarJudul.AutoSize = true;
            lblDaftarJudul.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblDaftarJudul.ForeColor = Color.FromArgb(55, 65, 81);
            lblDaftarJudul.Location = new Point(40, 272);
            lblDaftarJudul.Name = "lblDaftarJudul";
            lblDaftarJudul.Size = new Size(148, 16);
            lblDaftarJudul.TabIndex = 5;
            lblDaftarJudul.Text = "Daftar Transaksi Kasir";
            // 
            // gridTransaksi
            // 
            gridTransaksi.AllowUserToAddRows = false;
            gridTransaksi.AllowUserToDeleteRows = false;
            gridTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTransaksi.BackgroundColor = Color.White;
            gridTransaksi.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridTransaksi.ColumnHeadersHeight = 40;
            gridTransaksi.Columns.AddRange(new DataGridViewColumn[] { colId, colTanggal, colKasir, colTotal, colBayar, colKembalian });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Inter", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridTransaksi.DefaultCellStyle = dataGridViewCellStyle2;
            gridTransaksi.EnableHeadersVisualStyles = false;
            gridTransaksi.Location = new Point(40, 304);
            gridTransaksi.MultiSelect = false;
            gridTransaksi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridTransaksi.GridColor = Color.FromArgb(229, 231, 235);
            gridTransaksi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridTransaksi.Name = "gridTransaksi";
            gridTransaksi.ReadOnly = true;
            gridTransaksi.RowHeadersVisible = false;
            gridTransaksi.RowTemplate.Height = 36;
            gridTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTransaksi.Size = new Size(960, 176);
            gridTransaksi.TabIndex = 6;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.FillWeight = 110F;
            colId.HeaderText = "No. Faktur";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.DataPropertyName = "TanggalFormat";
            colTanggal.FillWeight = 115F;
            colTanggal.HeaderText = "Waktu";
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colKasir
            // 
            colKasir.DataPropertyName = "Kasir";
            colKasir.FillWeight = 80F;
            colKasir.HeaderText = "Kasir";
            colKasir.Name = "colKasir";
            colKasir.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "TotalFormat";
            colTotal.FillWeight = 95F;
            colTotal.HeaderText = "Total Belanja";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colBayar
            // 
            colBayar.DataPropertyName = "BayarFormat";
            colBayar.FillWeight = 90F;
            colBayar.HeaderText = "Dibayar";
            colBayar.Name = "colBayar";
            colBayar.ReadOnly = true;
            // 
            // colKembalian
            // 
            colKembalian.DataPropertyName = "KembalianFormat";
            colKembalian.FillWeight = 85F;
            colKembalian.HeaderText = "Kembalian";
            colKembalian.Name = "colKembalian";
            colKembalian.ReadOnly = true;
            // 
            // lblDetailJudul
            // 
            lblDetailJudul.AutoSize = true;
            lblDetailJudul.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblDetailJudul.ForeColor = Color.FromArgb(55, 65, 81);
            lblDetailJudul.Location = new Point(40, 496);
            lblDetailJudul.Name = "lblDetailJudul";
            lblDetailJudul.Size = new Size(223, 16);
            lblDetailJudul.TabIndex = 7;
            lblDetailJudul.Text = "Rincian Item Barang (Pilih Faktur)";
            // 
            // gridDetail
            // 
            gridDetail.AllowUserToAddRows = false;
            gridDetail.AllowUserToDeleteRows = false;
            gridDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDetail.BackgroundColor = Color.White;
            gridDetail.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridDetail.ColumnHeadersHeight = 40;
            gridDetail.Columns.AddRange(new DataGridViewColumn[] { colDetKode, colDetNama, colDetHarga, colDetJumlah, colDetSubtotal });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Inter", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridDetail.DefaultCellStyle = dataGridViewCellStyle4;
            gridDetail.EnableHeadersVisualStyles = false;
            gridDetail.Location = new Point(40, 528);
            gridDetail.MultiSelect = false;
            gridDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridDetail.GridColor = Color.FromArgb(229, 231, 235);
            gridDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridDetail.Name = "gridDetail";
            gridDetail.ReadOnly = true;
            gridDetail.RowHeadersVisible = false;
            gridDetail.RowTemplate.Height = 36;
            gridDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridDetail.Size = new Size(960, 152);
            gridDetail.TabIndex = 8;
            // 
            // colDetKode
            // 
            colDetKode.DataPropertyName = "KodeBarang";
            colDetKode.FillWeight = 85F;
            colDetKode.HeaderText = "Kode";
            colDetKode.Name = "colDetKode";
            colDetKode.ReadOnly = true;
            // 
            // colDetNama
            // 
            colDetNama.DataPropertyName = "NamaBarang";
            colDetNama.FillWeight = 200F;
            colDetNama.HeaderText = "Nama Barang";
            colDetNama.Name = "colDetNama";
            colDetNama.ReadOnly = true;
            // 
            // colDetHarga
            // 
            colDetHarga.DataPropertyName = "HargaFormat";
            colDetHarga.FillWeight = 95F;
            colDetHarga.HeaderText = "Harga Satuan";
            colDetHarga.Name = "colDetHarga";
            colDetHarga.ReadOnly = true;
            // 
            // colDetJumlah
            // 
            colDetJumlah.DataPropertyName = "Jumlah";
            colDetJumlah.FillWeight = 50F;
            colDetJumlah.HeaderText = "Qty";
            colDetJumlah.Name = "colDetJumlah";
            colDetJumlah.ReadOnly = true;
            // 
            // colDetSubtotal
            // 
            colDetSubtotal.DataPropertyName = "SubtotalFormat";
            colDetSubtotal.HeaderText = "Subtotal";
            colDetSubtotal.Name = "colDetSubtotal";
            colDetSubtotal.ReadOnly = true;
            // 
            // FormRiwayatTransaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRiwayatTransaksi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Riwayat Transaksi";
            btnLihatStruk.BackColor = Color.White;
            btnLihatStruk.Cursor = Cursors.Hand;
            btnLihatStruk.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnLihatStruk.FlatStyle = FlatStyle.Flat;
            btnLihatStruk.Font = new Font("Inter", 10F);
            btnLihatStruk.ForeColor = Color.FromArgb(55, 65, 81);
            btnLihatStruk.Location = new Point(856, 488);
            btnLihatStruk.Size = new Size(144, 32);
            btnLihatStruk.TabIndex = 20;
            btnLihatStruk.Text = "Lihat Struk";
            btnLihatStruk.UseVisualStyleBackColor = false;
            btnLihatStruk.Name = "btnLihatStruk";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlRingkasan.ResumeLayout(false);
            pnlRingkasan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridTransaksi).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridDetail).EndInit();
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
        private Button btnLihatStruk;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblJudul;
        private Panel pnlFilter;
        private TextBox txtCari;
        private Label lblDari;
        private DateTimePicker dtpMulai;
        private Label lblSampai;
        private DateTimePicker dtpSelesai;
        private Button btnFilter;
        private Button btnReset;
        private Panel pnlRingkasan;
        private Label lblStatTransaksi;
        private Label lblValTransaksi;
        private Label lblStatOmzet;
        private Label lblValOmzet;
        private Label lblStatRata;
        private Label lblValRata;
        private Label lblDaftarJudul;
        private DataGridView gridTransaksi;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colKasir;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colBayar;
        private DataGridViewTextBoxColumn colKembalian;
        private Label lblDetailJudul;
        private DataGridView gridDetail;
        private DataGridViewTextBoxColumn colDetKode;
        private DataGridViewTextBoxColumn colDetNama;
        private DataGridViewTextBoxColumn colDetHarga;
        private DataGridViewTextBoxColumn colDetJumlah;
        private DataGridViewTextBoxColumn colDetSubtotal;
    }
}
