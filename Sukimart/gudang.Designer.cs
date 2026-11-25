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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlKiri = new Panel();
            btnKeluar = new Button();
            btnGantiSandi = new Button();
            btnLaporanInventaris = new Button();
            btnLaporan = new Button();
            btnPengguna = new Button();
            btnLogAktivitas = new Button();
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
            btnSubStokGudang = new Button();
            btnSubStokOpname = new Button();
            btnSubRiwayatOpname = new Button();
            pnlSubStokGudang = new Panel();
            txtCariGudang = new TextBox();
            btnRiwayatStok = new Button();
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
            lblJenisStok = new Label();
            cmbJenisStok = new ComboBox();
            lblPemasok = new Label();
            txtPemasok = new TextBox();
            lblAlasan = new Label();
            cmbAlasan = new ComboBox();
            lblKeterangan = new Label();
            txtKeterangan = new TextBox();
            pnlSubStokOpname = new Panel();
            btnBuatOpnameBaru = new Button();
            btnBukaOpname = new Button();
            btnBatalkanOpname = new Button();
            btnSegarkanOpname = new Button();
            txtCariSesi = new TextBox();
            gridSesiOpname = new DataGridView();
            colSesiNo = new DataGridViewTextBoxColumn();
            colSesiTanggal = new DataGridViewTextBoxColumn();
            colSesiPembuat = new DataGridViewTextBoxColumn();
            colSesiJumlahProduk = new DataGridViewTextBoxColumn();
            colSesiSelisih = new DataGridViewTextBoxColumn();
            colSesiSelisihPositif = new DataGridViewTextBoxColumn();
            colSesiSelisihNegatif = new DataGridViewTextBoxColumn();
            colSesiStatus = new DataGridViewTextBoxColumn();
            pnlSubRiwayatOpname = new Panel();
            dtpOpnameMulai = new DateTimePicker();
            lblOpnameSampai = new Label();
            dtpOpnameSelesai = new DateTimePicker();
            btnTerapkanFilterRiwayat = new Button();
            cmbFilterStatusOpname = new ComboBox();
            txtCariRiwayatOpname = new TextBox();
            btnBukaDetailRiwayat = new Button();
            gridRiwayatOpname = new DataGridView();
            colRiwNo = new DataGridViewTextBoxColumn();
            colRiwTanggal = new DataGridViewTextBoxColumn();
            colRiwPembuat = new DataGridViewTextBoxColumn();
            colRiwPenyetuju = new DataGridViewTextBoxColumn();
            colRiwJumlah = new DataGridViewTextBoxColumn();
            colRiwSelisih = new DataGridViewTextBoxColumn();
            colRiwStatus = new DataGridViewTextBoxColumn();
            colRiwWaktuSelesai = new DataGridViewTextBoxColumn();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            pnlSubStokGudang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridGudang).BeginInit();
            pnlRestock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudJumlahMasuk).BeginInit();
            pnlSubStokOpname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSesiOpname).BeginInit();
            pnlSubRiwayatOpname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRiwayatOpname).BeginInit();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.White;
            pnlKiri.Controls.Add(btnKeluar);
            pnlKiri.Controls.Add(btnGantiSandi);
            pnlKiri.Controls.Add(btnPengguna);
            pnlKiri.Controls.Add(btnLogAktivitas);
            pnlKiri.Controls.Add(btnLaporanInventaris);
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
            btnLaporan.Text = "Laporan Penjualan";
            btnLaporan.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporan.UseVisualStyleBackColor = false;
            // 
            // btnLaporanInventaris
            // 
            btnLaporanInventaris.BackColor = Color.White;
            btnLaporanInventaris.Cursor = Cursors.Hand;
            btnLaporanInventaris.FlatAppearance.BorderSize = 0;
            btnLaporanInventaris.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLaporanInventaris.FlatStyle = FlatStyle.Flat;
            btnLaporanInventaris.Font = new Font("Inter", 10F);
            btnLaporanInventaris.ForeColor = Color.FromArgb(31, 41, 55);
            btnLaporanInventaris.Location = new Point(16, 400);
            btnLaporanInventaris.Name = "btnLaporanInventaris";
            btnLaporanInventaris.Padding = new Padding(16, 0, 0, 0);
            btnLaporanInventaris.Size = new Size(208, 40);
            btnLaporanInventaris.TabIndex = 11;
            btnLaporanInventaris.Text = "Laporan Inventaris";
            btnLaporanInventaris.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanInventaris.UseVisualStyleBackColor = false;
            btnPengguna.BackColor = Color.White;
            btnPengguna.Cursor = Cursors.Hand;
            btnPengguna.FlatAppearance.BorderSize = 0;
            btnPengguna.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnPengguna.FlatStyle = FlatStyle.Flat;
            btnPengguna.Font = new Font("Inter", 10F);
            btnPengguna.ForeColor = Color.FromArgb(31, 41, 55);
            btnPengguna.Location = new Point(16, 448);
            btnPengguna.Name = "btnPengguna";
            btnPengguna.Padding = new Padding(16, 0, 0, 0);
            btnPengguna.Size = new Size(208, 40);
            btnPengguna.TabIndex = 12;
            btnPengguna.Text = "Pengguna";
            btnPengguna.TextAlign = ContentAlignment.MiddleLeft;
            btnPengguna.UseVisualStyleBackColor = false;
            // 
            // btnLogAktivitas
            // 
            btnLogAktivitas.BackColor = Color.White;
            btnLogAktivitas.Cursor = Cursors.Hand;
            btnLogAktivitas.FlatAppearance.BorderSize = 0;
            btnLogAktivitas.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLogAktivitas.FlatStyle = FlatStyle.Flat;
            btnLogAktivitas.Font = new Font("Inter", 10F);
            btnLogAktivitas.ForeColor = Color.FromArgb(31, 41, 55);
            btnLogAktivitas.Location = new Point(16, 496);
            btnLogAktivitas.Name = "btnLogAktivitas";
            btnLogAktivitas.Padding = new Padding(16, 0, 0, 0);
            btnLogAktivitas.Size = new Size(208, 40);
            btnLogAktivitas.TabIndex = 13;
            btnLogAktivitas.Text = "Log Aktivitas";
            btnLogAktivitas.TextAlign = ContentAlignment.MiddleLeft;
            btnLogAktivitas.UseVisualStyleBackColor = false;
            // 
            // btnGantiSandi
            // 
            btnGantiSandi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGantiSandi.BackColor = Color.White;
            btnGantiSandi.Cursor = Cursors.Hand;
            btnGantiSandi.FlatAppearance.BorderSize = 0;
            btnGantiSandi.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnGantiSandi.FlatStyle = FlatStyle.Flat;
            btnGantiSandi.Font = new Font("Inter", 10F);
            btnGantiSandi.ForeColor = Color.FromArgb(75, 85, 99);
            btnGantiSandi.Location = new Point(16, 592);
            btnGantiSandi.Name = "btnGantiSandi";
            btnGantiSandi.Padding = new Padding(16, 0, 0, 0);
            btnGantiSandi.Size = new Size(208, 40);
            btnGantiSandi.TabIndex = 14;
            btnGantiSandi.Text = "Ganti Kata Sandi";
            btnGantiSandi.TextAlign = ContentAlignment.MiddleLeft;
            btnGantiSandi.UseVisualStyleBackColor = false;
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
            pnlKanan.Controls.Add(btnSubStokGudang);
            pnlKanan.Controls.Add(btnSubStokOpname);
            pnlKanan.Controls.Add(btnSubRiwayatOpname);
            pnlKanan.Controls.Add(pnlSubStokGudang);
            pnlKanan.Controls.Add(pnlSubStokOpname);
            pnlKanan.Controls.Add(pnlSubRiwayatOpname);
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
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(40, 24);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(280, 33);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Manajemen Gudang";
            // 
            // btnSubStokGudang
            // 
            btnSubStokGudang.BackColor = Color.FromArgb(255, 196, 0);
            btnSubStokGudang.Cursor = Cursors.Hand;
            btnSubStokGudang.FlatAppearance.BorderSize = 0;
            btnSubStokGudang.FlatStyle = FlatStyle.Flat;
            btnSubStokGudang.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnSubStokGudang.ForeColor = Color.FromArgb(31, 41, 55);
            btnSubStokGudang.Location = new Point(40, 72);
            btnSubStokGudang.Name = "btnSubStokGudang";
            btnSubStokGudang.Size = new Size(140, 34);
            btnSubStokGudang.TabIndex = 2;
            btnSubStokGudang.Text = "Stok Gudang";
            btnSubStokGudang.UseVisualStyleBackColor = false;
            // 
            // btnSubStokOpname
            // 
            btnSubStokOpname.BackColor = Color.White;
            btnSubStokOpname.Cursor = Cursors.Hand;
            btnSubStokOpname.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSubStokOpname.FlatStyle = FlatStyle.Flat;
            btnSubStokOpname.Font = new Font("Inter", 10F);
            btnSubStokOpname.ForeColor = Color.FromArgb(75, 85, 99);
            btnSubStokOpname.Location = new Point(188, 72);
            btnSubStokOpname.Name = "btnSubStokOpname";
            btnSubStokOpname.Size = new Size(140, 34);
            btnSubStokOpname.TabIndex = 3;
            btnSubStokOpname.Text = "Stok Opname";
            btnSubStokOpname.UseVisualStyleBackColor = false;
            // 
            // btnSubRiwayatOpname
            // 
            btnSubRiwayatOpname.BackColor = Color.White;
            btnSubRiwayatOpname.Cursor = Cursors.Hand;
            btnSubRiwayatOpname.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSubRiwayatOpname.FlatStyle = FlatStyle.Flat;
            btnSubRiwayatOpname.Font = new Font("Inter", 10F);
            btnSubRiwayatOpname.ForeColor = Color.FromArgb(75, 85, 99);
            btnSubRiwayatOpname.Location = new Point(336, 72);
            btnSubRiwayatOpname.Name = "btnSubRiwayatOpname";
            btnSubRiwayatOpname.Size = new Size(160, 34);
            btnSubRiwayatOpname.TabIndex = 4;
            btnSubRiwayatOpname.Text = "Riwayat Opname";
            btnSubRiwayatOpname.UseVisualStyleBackColor = false;
            // 
            // pnlSubStokGudang
            // 
            pnlSubStokGudang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSubStokGudang.Controls.Add(txtCariGudang);
            pnlSubStokGudang.Controls.Add(btnRiwayatStok);
            pnlSubStokGudang.Controls.Add(btnFilterMenipis);
            pnlSubStokGudang.Controls.Add(btnSemuaStok);
            pnlSubStokGudang.Controls.Add(gridGudang);
            pnlSubStokGudang.Controls.Add(pnlRestock);
            pnlSubStokGudang.Location = new Point(0, 115);
            pnlSubStokGudang.Name = "pnlSubStokGudang";
            pnlSubStokGudang.Size = new Size(1040, 605);
            pnlSubStokGudang.TabIndex = 5;
            // 
            // txtCariGudang
            // 
            txtCariGudang.Font = new Font("Inter", 10F);
            txtCariGudang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCariGudang.Location = new Point(40, 5);
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
            btnFilterMenipis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilterMenipis.Location = new Point(712, 1);
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
            btnSemuaStok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSemuaStok.Location = new Point(864, 1);
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
            gridGudang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridGudang.Location = new Point(40, 42);
            gridGudang.MultiSelect = false;
            gridGudang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridGudang.GridColor = Color.FromArgb(229, 231, 235);
            gridGudang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridGudang.Name = "gridGudang";
            gridGudang.ReadOnly = true;
            gridGudang.RowHeadersVisible = false;
            gridGudang.RowTemplate.Height = 36;
            gridGudang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridGudang.Size = new Size(960, 360);
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
            pnlRestock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlRestock.BackColor = Color.White;
            pnlRestock.BorderStyle = BorderStyle.None;
            pnlRestock.Controls.Add(lblPilihBarangRestock);
            pnlRestock.Controls.Add(txtBarangTerpilih);
            pnlRestock.Controls.Add(lblJenisStok);
            pnlRestock.Controls.Add(cmbJenisStok);
            pnlRestock.Controls.Add(lblJumlahMasuk);
            pnlRestock.Controls.Add(nudJumlahMasuk);
            pnlRestock.Controls.Add(lblPemasok);
            pnlRestock.Controls.Add(txtPemasok);
            pnlRestock.Controls.Add(lblAlasan);
            pnlRestock.Controls.Add(cmbAlasan);
            pnlRestock.Controls.Add(lblKeterangan);
            pnlRestock.Controls.Add(txtKeterangan);
            pnlRestock.Controls.Add(btnSimpanStok);
            pnlRestock.Location = new Point(40, 412);
            pnlRestock.Name = "pnlRestock";
            pnlRestock.Size = new Size(960, 165);
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
            // lblJenisStok
            // 
            lblJenisStok.AutoSize = true;
            lblJenisStok.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJenisStok.ForeColor = Color.FromArgb(75, 85, 99);
            lblJenisStok.Location = new Point(336, 24);
            lblJenisStok.Name = "lblJenisStok";
            lblJenisStok.Size = new Size(34, 15);
            lblJenisStok.TabIndex = 3;
            lblJenisStok.Text = "Jenis";
            // 
            // cmbJenisStok
            // 
            cmbJenisStok.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenisStok.Font = new Font("Inter", 10F);
            cmbJenisStok.Items.AddRange(new object[] { "Stok Masuk", "Stok Keluar" });
            cmbJenisStok.Location = new Point(336, 48);
            cmbJenisStok.Name = "cmbJenisStok";
            cmbJenisStok.Size = new Size(136, 24);
            cmbJenisStok.TabIndex = 4;
            // 
            // lblJumlahMasuk
            // 
            lblJumlahMasuk.AutoSize = true;
            lblJumlahMasuk.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJumlahMasuk.ForeColor = Color.FromArgb(75, 85, 99);
            lblJumlahMasuk.Location = new Point(488, 24);
            lblJumlahMasuk.Name = "lblJumlahMasuk";
            lblJumlahMasuk.Size = new Size(150, 15);
            lblJumlahMasuk.TabIndex = 5;
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
            nudJumlahMasuk.TabIndex = 6;
            nudJumlahMasuk.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblPemasok
            // 
            lblPemasok.AutoSize = true;
            lblPemasok.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPemasok.ForeColor = Color.FromArgb(75, 85, 99);
            lblPemasok.Location = new Point(608, 24);
            lblPemasok.Name = "lblPemasok";
            lblPemasok.Size = new Size(61, 15);
            lblPemasok.TabIndex = 7;
            lblPemasok.Text = "Pemasok";
            // 
            // txtPemasok
            // 
            txtPemasok.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPemasok.Font = new Font("Inter", 10F);
            txtPemasok.Location = new Point(608, 48);
            txtPemasok.MaxLength = 100;
            txtPemasok.Name = "txtPemasok";
            txtPemasok.PlaceholderText = "Nama pemasok...";
            txtPemasok.Size = new Size(328, 23);
            txtPemasok.TabIndex = 8;
            // 
            // lblAlasan
            // 
            lblAlasan.AutoSize = true;
            lblAlasan.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblAlasan.ForeColor = Color.FromArgb(75, 85, 99);
            lblAlasan.Location = new Point(608, 24);
            lblAlasan.Name = "lblAlasan";
            lblAlasan.Size = new Size(47, 15);
            lblAlasan.TabIndex = 9;
            lblAlasan.Text = "Alasan";
            lblAlasan.Visible = false;
            // 
            // cmbAlasan
            // 
            cmbAlasan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbAlasan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlasan.Font = new Font("Inter", 10F);
            cmbAlasan.FormattingEnabled = true;
            cmbAlasan.Items.AddRange(new object[] { "RUSAK", "KEDALUWARSA", "DIKEMBALIKAN", "LAINNYA" });
            cmbAlasan.Location = new Point(608, 48);
            cmbAlasan.Name = "cmbAlasan";
            cmbAlasan.Size = new Size(328, 24);
            cmbAlasan.TabIndex = 10;
            cmbAlasan.Visible = false;
            // 
            // lblKeterangan
            // 
            lblKeterangan.AutoSize = true;
            lblKeterangan.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKeterangan.ForeColor = Color.FromArgb(75, 85, 99);
            lblKeterangan.Location = new Point(24, 92);
            lblKeterangan.Name = "lblKeterangan";
            lblKeterangan.Size = new Size(75, 15);
            lblKeterangan.TabIndex = 11;
            lblKeterangan.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            txtKeterangan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeterangan.Font = new Font("Inter", 10F);
            txtKeterangan.Location = new Point(24, 114);
            txtKeterangan.MaxLength = 100;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.PlaceholderText = "Opsional";
            txtKeterangan.Size = new Size(768, 23);
            txtKeterangan.TabIndex = 12;
            // 
            // btnSimpanStok
            // 
            btnSimpanStok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSimpanStok.BackColor = Color.FromArgb(255, 196, 0);
            btnSimpanStok.Cursor = Cursors.Hand;
            btnSimpanStok.FlatAppearance.BorderSize = 0;
            btnSimpanStok.FlatStyle = FlatStyle.Flat;
            btnSimpanStok.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnSimpanStok.ForeColor = Color.FromArgb(31, 41, 55);
            btnSimpanStok.Location = new Point(808, 108);
            btnSimpanStok.Name = "btnSimpanStok";
            btnSimpanStok.Size = new Size(128, 32);
            btnSimpanStok.TabIndex = 13;
            btnSimpanStok.Text = "Simpan";
            btnSimpanStok.UseVisualStyleBackColor = false;
            // 
            // btnRiwayatStok
            // 
            btnRiwayatStok.BackColor = Color.White;
            btnRiwayatStok.Cursor = Cursors.Hand;
            btnRiwayatStok.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnRiwayatStok.FlatStyle = FlatStyle.Flat;
            btnRiwayatStok.Font = new Font("Inter", 10F);
            btnRiwayatStok.ForeColor = Color.FromArgb(75, 85, 99);
            btnRiwayatStok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRiwayatStok.Location = new Point(560, 1);
            btnRiwayatStok.Name = "btnRiwayatStok";
            btnRiwayatStok.Size = new Size(136, 32);
            btnRiwayatStok.TabIndex = 8;
            btnRiwayatStok.Text = "Kartu Stok";
            btnRiwayatStok.UseVisualStyleBackColor = false;
            // 
            // pnlSubStokOpname
            // 
            pnlSubStokOpname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSubStokOpname.Controls.Add(btnBuatOpnameBaru);
            pnlSubStokOpname.Controls.Add(btnBukaOpname);
            pnlSubStokOpname.Controls.Add(btnBatalkanOpname);
            pnlSubStokOpname.Controls.Add(btnSegarkanOpname);
            pnlSubStokOpname.Controls.Add(txtCariSesi);
            pnlSubStokOpname.Controls.Add(gridSesiOpname);
            pnlSubStokOpname.Location = new Point(0, 115);
            pnlSubStokOpname.Name = "pnlSubStokOpname";
            pnlSubStokOpname.Size = new Size(1040, 605);
            pnlSubStokOpname.TabIndex = 7;
            pnlSubStokOpname.Visible = false;
            // 
            // btnBuatOpnameBaru
            // 
            btnBuatOpnameBaru.BackColor = Color.FromArgb(255, 196, 0);
            btnBuatOpnameBaru.Cursor = Cursors.Hand;
            btnBuatOpnameBaru.FlatAppearance.BorderSize = 0;
            btnBuatOpnameBaru.FlatStyle = FlatStyle.Flat;
            btnBuatOpnameBaru.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnBuatOpnameBaru.ForeColor = Color.FromArgb(31, 41, 55);
            btnBuatOpnameBaru.Location = new Point(40, 5);
            btnBuatOpnameBaru.Name = "btnBuatOpnameBaru";
            btnBuatOpnameBaru.Size = new Size(180, 32);
            btnBuatOpnameBaru.TabIndex = 0;
            btnBuatOpnameBaru.Text = "+ Mulai Sesi Opname";
            btnBuatOpnameBaru.UseVisualStyleBackColor = false;
            // 
            // btnBukaOpname
            // 
            btnBukaOpname.BackColor = Color.White;
            btnBukaOpname.Cursor = Cursors.Hand;
            btnBukaOpname.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBukaOpname.FlatStyle = FlatStyle.Flat;
            btnBukaOpname.Font = new Font("Inter", 10F);
            btnBukaOpname.ForeColor = Color.FromArgb(31, 41, 55);
            btnBukaOpname.Location = new Point(230, 5);
            btnBukaOpname.Name = "btnBukaOpname";
            btnBukaOpname.Size = new Size(150, 32);
            btnBukaOpname.TabIndex = 1;
            btnBukaOpname.Text = "Buka Detail / Hitung";
            btnBukaOpname.UseVisualStyleBackColor = false;
            // 
            // btnBatalkanOpname
            // 
            btnBatalkanOpname.BackColor = Color.White;
            btnBatalkanOpname.Cursor = Cursors.Hand;
            btnBatalkanOpname.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnBatalkanOpname.FlatStyle = FlatStyle.Flat;
            btnBatalkanOpname.Font = new Font("Inter", 10F);
            btnBatalkanOpname.ForeColor = Color.FromArgb(220, 38, 38);
            btnBatalkanOpname.Location = new Point(390, 5);
            btnBatalkanOpname.Name = "btnBatalkanOpname";
            btnBatalkanOpname.Size = new Size(130, 32);
            btnBatalkanOpname.TabIndex = 2;
            btnBatalkanOpname.Text = "Batalkan Sesi";
            btnBatalkanOpname.UseVisualStyleBackColor = false;
            // 
            // btnSegarkanOpname
            // 
            btnSegarkanOpname.BackColor = Color.White;
            btnSegarkanOpname.Cursor = Cursors.Hand;
            btnSegarkanOpname.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSegarkanOpname.FlatStyle = FlatStyle.Flat;
            btnSegarkanOpname.Font = new Font("Inter", 10F);
            btnSegarkanOpname.ForeColor = Color.FromArgb(75, 85, 99);
            btnSegarkanOpname.Location = new Point(530, 5);
            btnSegarkanOpname.Name = "btnSegarkanOpname";
            btnSegarkanOpname.Size = new Size(100, 32);
            btnSegarkanOpname.TabIndex = 3;
            btnSegarkanOpname.Text = "Segarkan";
            btnSegarkanOpname.UseVisualStyleBackColor = false;
            // 
            // txtCariSesi
            // 
            txtCariSesi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCariSesi.Font = new Font("Inter", 10F);
            txtCariSesi.Location = new Point(640, 10);
            txtCariSesi.Name = "txtCariSesi";
            txtCariSesi.PlaceholderText = "Cari ID Sesi / Pembuat...";
            txtCariSesi.Size = new Size(360, 23);
            txtCariSesi.TabIndex = 4;
            // 
            // gridSesiOpname
            // 
            gridSesiOpname.AllowUserToAddRows = false;
            gridSesiOpname.AllowUserToDeleteRows = false;
            gridSesiOpname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridSesiOpname.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSesiOpname.BackgroundColor = Color.White;
            gridSesiOpname.BorderStyle = BorderStyle.None;
            gridSesiOpname.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridSesiOpname.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridSesiOpname.ColumnHeadersHeight = 40;
            gridSesiOpname.Columns.AddRange(new DataGridViewColumn[] { colSesiNo, colSesiTanggal, colSesiPembuat, colSesiJumlahProduk, colSesiSelisih, colSesiSelisihPositif, colSesiSelisihNegatif, colSesiStatus });
            gridSesiOpname.EnableHeadersVisualStyles = false;
            gridSesiOpname.GridColor = Color.FromArgb(229, 231, 235);
            gridSesiOpname.Location = new Point(40, 50);
            gridSesiOpname.MultiSelect = false;
            gridSesiOpname.Name = "gridSesiOpname";
            gridSesiOpname.ReadOnly = true;
            gridSesiOpname.RowHeadersVisible = false;
            gridSesiOpname.RowTemplate.Height = 36;
            gridSesiOpname.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSesiOpname.Size = new Size(960, 530);
            gridSesiOpname.TabIndex = 5;
            // 
            // colSesiNo
            // 
            colSesiNo.DataPropertyName = "IdSesi";
            colSesiNo.FillWeight = 85F;
            colSesiNo.HeaderText = "ID Sesi";
            colSesiNo.Name = "colSesiNo";
            colSesiNo.ReadOnly = true;
            // 
            // colSesiTanggal
            // 
            colSesiTanggal.DataPropertyName = "TanggalMulai";
            colSesiTanggal.FillWeight = 110F;
            colSesiTanggal.HeaderText = "Waktu Mulai";
            colSesiTanggal.Name = "colSesiTanggal";
            colSesiTanggal.ReadOnly = true;
            // 
            // colSesiPembuat
            // 
            colSesiPembuat.DataPropertyName = "Pembuat";
            colSesiPembuat.FillWeight = 85F;
            colSesiPembuat.HeaderText = "Pembuat";
            colSesiPembuat.Name = "colSesiPembuat";
            colSesiPembuat.ReadOnly = true;
            // 
            // colSesiJumlahProduk
            // 
            colSesiJumlahProduk.FillWeight = 80F;
            colSesiJumlahProduk.HeaderText = "Total Produk";
            colSesiJumlahProduk.Name = "colSesiJumlahProduk";
            colSesiJumlahProduk.ReadOnly = true;
            // 
            // colSesiSelisih
            // 
            colSesiSelisih.FillWeight = 80F;
            colSesiSelisih.HeaderText = "Total Selisih";
            colSesiSelisih.Name = "colSesiSelisih";
            colSesiSelisih.ReadOnly = true;
            // 
            // colSesiSelisihPositif
            // 
            colSesiSelisihPositif.FillWeight = 85F;
            colSesiSelisihPositif.HeaderText = "Selisih Lebih (+)";
            colSesiSelisihPositif.Name = "colSesiSelisihPositif";
            colSesiSelisihPositif.ReadOnly = true;
            // 
            // colSesiSelisihNegatif
            // 
            colSesiSelisihNegatif.FillWeight = 85F;
            colSesiSelisihNegatif.HeaderText = "Selisih Kurang (-)";
            colSesiSelisihNegatif.Name = "colSesiSelisihNegatif";
            colSesiSelisihNegatif.ReadOnly = true;
            // 
            // colSesiStatus
            // 
            colSesiStatus.DataPropertyName = "Status";
            colSesiStatus.FillWeight = 110F;
            colSesiStatus.HeaderText = "Status";
            colSesiStatus.Name = "colSesiStatus";
            colSesiStatus.ReadOnly = true;
            // 
            // pnlSubRiwayatOpname
            // 
            pnlSubRiwayatOpname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSubRiwayatOpname.Controls.Add(dtpOpnameMulai);
            pnlSubRiwayatOpname.Controls.Add(lblOpnameSampai);
            pnlSubRiwayatOpname.Controls.Add(dtpOpnameSelesai);
            pnlSubRiwayatOpname.Controls.Add(cmbFilterStatusOpname);
            pnlSubRiwayatOpname.Controls.Add(txtCariRiwayatOpname);
            pnlSubRiwayatOpname.Controls.Add(btnTerapkanFilterRiwayat);
            pnlSubRiwayatOpname.Controls.Add(btnBukaDetailRiwayat);
            pnlSubRiwayatOpname.Controls.Add(gridRiwayatOpname);
            pnlSubRiwayatOpname.Location = new Point(0, 115);
            pnlSubRiwayatOpname.Name = "pnlSubRiwayatOpname";
            pnlSubRiwayatOpname.Size = new Size(1040, 605);
            pnlSubRiwayatOpname.TabIndex = 8;
            pnlSubRiwayatOpname.Visible = false;
            // 
            // dtpOpnameMulai
            // 
            dtpOpnameMulai.Font = new Font("Inter", 10F);
            dtpOpnameMulai.Format = DateTimePickerFormat.Short;
            dtpOpnameMulai.Location = new Point(40, 9);
            dtpOpnameMulai.Name = "dtpOpnameMulai";
            dtpOpnameMulai.Size = new Size(130, 23);
            dtpOpnameMulai.TabIndex = 0;
            // 
            // lblOpnameSampai
            // 
            lblOpnameSampai.AutoSize = true;
            lblOpnameSampai.Font = new Font("Inter", 9F);
            lblOpnameSampai.Location = new Point(176, 13);
            lblOpnameSampai.Name = "lblOpnameSampai";
            lblOpnameSampai.Size = new Size(25, 15);
            lblOpnameSampai.TabIndex = 1;
            lblOpnameSampai.Text = "s/d";
            // 
            // dtpOpnameSelesai
            // 
            dtpOpnameSelesai.Font = new Font("Inter", 10F);
            dtpOpnameSelesai.Format = DateTimePickerFormat.Short;
            dtpOpnameSelesai.Location = new Point(208, 9);
            dtpOpnameSelesai.Name = "dtpOpnameSelesai";
            dtpOpnameSelesai.Size = new Size(130, 23);
            dtpOpnameSelesai.TabIndex = 2;
            // 
            // cmbFilterStatusOpname
            // 
            cmbFilterStatusOpname.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatusOpname.Font = new Font("Inter", 10F);
            cmbFilterStatusOpname.FormattingEnabled = true;
            cmbFilterStatusOpname.Items.AddRange(new object[] { "Semua Status", "Disetujui", "Dibatalkan" });
            cmbFilterStatusOpname.Location = new Point(348, 8);
            cmbFilterStatusOpname.Name = "cmbFilterStatusOpname";
            cmbFilterStatusOpname.Size = new Size(140, 24);
            cmbFilterStatusOpname.TabIndex = 3;
            // 
            // txtCariRiwayatOpname
            // 
            txtCariRiwayatOpname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCariRiwayatOpname.Font = new Font("Inter", 10F);
            txtCariRiwayatOpname.Location = new Point(498, 9);
            txtCariRiwayatOpname.Name = "txtCariRiwayatOpname";
            txtCariRiwayatOpname.PlaceholderText = "Cari ID / Pengguna...";
            txtCariRiwayatOpname.Size = new Size(200, 23);
            txtCariRiwayatOpname.TabIndex = 4;
            // 
            // btnTerapkanFilterRiwayat
            // 
            btnTerapkanFilterRiwayat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTerapkanFilterRiwayat.BackColor = Color.White;
            btnTerapkanFilterRiwayat.Cursor = Cursors.Hand;
            btnTerapkanFilterRiwayat.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTerapkanFilterRiwayat.FlatStyle = FlatStyle.Flat;
            btnTerapkanFilterRiwayat.Font = new Font("Inter", 10F);
            btnTerapkanFilterRiwayat.ForeColor = Color.FromArgb(75, 85, 99);
            btnTerapkanFilterRiwayat.Location = new Point(708, 5);
            btnTerapkanFilterRiwayat.Name = "btnTerapkanFilterRiwayat";
            btnTerapkanFilterRiwayat.Size = new Size(120, 32);
            btnTerapkanFilterRiwayat.TabIndex = 5;
            btnTerapkanFilterRiwayat.Text = "Terapkan";
            btnTerapkanFilterRiwayat.UseVisualStyleBackColor = false;
            // 
            // btnBukaDetailRiwayat
            // 
            btnBukaDetailRiwayat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBukaDetailRiwayat.BackColor = Color.White;
            btnBukaDetailRiwayat.Cursor = Cursors.Hand;
            btnBukaDetailRiwayat.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBukaDetailRiwayat.FlatStyle = FlatStyle.Flat;
            btnBukaDetailRiwayat.Font = new Font("Inter", 10F);
            btnBukaDetailRiwayat.ForeColor = Color.FromArgb(31, 41, 55);
            btnBukaDetailRiwayat.Location = new Point(838, 5);
            btnBukaDetailRiwayat.Name = "btnBukaDetailRiwayat";
            btnBukaDetailRiwayat.Size = new Size(162, 32);
            btnBukaDetailRiwayat.TabIndex = 6;
            btnBukaDetailRiwayat.Text = "Lihat Detail Selesai";
            btnBukaDetailRiwayat.UseVisualStyleBackColor = false;
            // 
            // gridRiwayatOpname
            // 
            gridRiwayatOpname.AllowUserToAddRows = false;
            gridRiwayatOpname.AllowUserToDeleteRows = false;
            gridRiwayatOpname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridRiwayatOpname.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRiwayatOpname.BackgroundColor = Color.White;
            gridRiwayatOpname.BorderStyle = BorderStyle.None;
            gridRiwayatOpname.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridRiwayatOpname.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridRiwayatOpname.ColumnHeadersHeight = 40;
            gridRiwayatOpname.Columns.AddRange(new DataGridViewColumn[] { colRiwNo, colRiwTanggal, colRiwPembuat, colRiwPenyetuju, colRiwJumlah, colRiwSelisih, colRiwStatus, colRiwWaktuSelesai });
            gridRiwayatOpname.EnableHeadersVisualStyles = false;
            gridRiwayatOpname.GridColor = Color.FromArgb(229, 231, 235);
            gridRiwayatOpname.Location = new Point(40, 50);
            gridRiwayatOpname.MultiSelect = false;
            gridRiwayatOpname.Name = "gridRiwayatOpname";
            gridRiwayatOpname.ReadOnly = true;
            gridRiwayatOpname.RowHeadersVisible = false;
            gridRiwayatOpname.RowTemplate.Height = 36;
            gridRiwayatOpname.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRiwayatOpname.Size = new Size(960, 530);
            gridRiwayatOpname.TabIndex = 7;
            // 
            // colRiwNo
            // 
            colRiwNo.DataPropertyName = "IdSesi";
            colRiwNo.FillWeight = 85F;
            colRiwNo.HeaderText = "ID Sesi";
            colRiwNo.Name = "colRiwNo";
            colRiwNo.ReadOnly = true;
            // 
            // colRiwTanggal
            // 
            colRiwTanggal.DataPropertyName = "TanggalMulai";
            colRiwTanggal.FillWeight = 100F;
            colRiwTanggal.HeaderText = "Waktu Mulai";
            colRiwTanggal.Name = "colRiwTanggal";
            colRiwTanggal.ReadOnly = true;
            // 
            // colRiwPembuat
            // 
            colRiwPembuat.DataPropertyName = "Pembuat";
            colRiwPembuat.FillWeight = 80F;
            colRiwPembuat.HeaderText = "Pembuat";
            colRiwPembuat.Name = "colRiwPembuat";
            colRiwPembuat.ReadOnly = true;
            // 
            // colRiwPenyetuju
            // 
            colRiwPenyetuju.DataPropertyName = "DisetujuiOleh";
            colRiwPenyetuju.FillWeight = 80F;
            colRiwPenyetuju.HeaderText = "Penyetuju";
            colRiwPenyetuju.Name = "colRiwPenyetuju";
            colRiwPenyetuju.ReadOnly = true;
            // 
            // colRiwJumlah
            // 
            colRiwJumlah.FillWeight = 75F;
            colRiwJumlah.HeaderText = "Jml Produk";
            colRiwJumlah.Name = "colRiwJumlah";
            colRiwJumlah.ReadOnly = true;
            // 
            // colRiwSelisih
            // 
            colRiwSelisih.FillWeight = 75F;
            colRiwSelisih.HeaderText = "Total Selisih";
            colRiwSelisih.Name = "colRiwSelisih";
            colRiwSelisih.ReadOnly = true;
            // 
            // colRiwStatus
            // 
            colRiwStatus.DataPropertyName = "Status";
            colRiwStatus.FillWeight = 95F;
            colRiwStatus.HeaderText = "Status";
            colRiwStatus.Name = "colRiwStatus";
            colRiwStatus.ReadOnly = true;
            // 
            // colRiwWaktuSelesai
            // 
            colRiwWaktuSelesai.DataPropertyName = "TanggalSelesai";
            colRiwWaktuSelesai.FillWeight = 100F;
            colRiwWaktuSelesai.HeaderText = "Waktu Selesai";
            colRiwWaktuSelesai.Name = "colRiwWaktuSelesai";
            colRiwWaktuSelesai.ReadOnly = true;
            // 
            // FormGudang
            // 
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
            pnlSubStokGudang.ResumeLayout(false);
            pnlSubStokGudang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridGudang).EndInit();
            pnlRestock.ResumeLayout(false);
            pnlRestock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudJumlahMasuk).EndInit();
            pnlSubStokOpname.ResumeLayout(false);
            pnlSubStokOpname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSesiOpname).EndInit();
            pnlSubRiwayatOpname.ResumeLayout(false);
            pnlSubRiwayatOpname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRiwayatOpname).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKiri;
        private Button btnLaporanInventaris;
        private Button btnLaporan;
        private Button btnPengguna;
        private Button btnLogAktivitas;
        private Button btnGantiSandi;
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
        private Button btnSubStokGudang;
        private Button btnSubStokOpname;
        private Button btnSubRiwayatOpname;
        private Panel pnlSubStokGudang;
        private TextBox txtCariGudang;
        private Button btnFilterMenipis;
        private Button btnSemuaStok;
        private Button btnRiwayatStok;
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
        private Label lblJenisStok;
        private ComboBox cmbJenisStok;
        private Label lblPemasok;
        private TextBox txtPemasok;
        private Label lblAlasan;
        private ComboBox cmbAlasan;
        private Label lblKeterangan;
        private TextBox txtKeterangan;
        private Panel pnlSubStokOpname;
        private Button btnBuatOpnameBaru;
        private Button btnBukaOpname;
        private Button btnBatalkanOpname;
        private Button btnSegarkanOpname;
        private TextBox txtCariSesi;
        private DataGridView gridSesiOpname;
        private DataGridViewTextBoxColumn colSesiNo;
        private DataGridViewTextBoxColumn colSesiTanggal;
        private DataGridViewTextBoxColumn colSesiPembuat;
        private DataGridViewTextBoxColumn colSesiJumlahProduk;
        private DataGridViewTextBoxColumn colSesiSelisih;
        private DataGridViewTextBoxColumn colSesiSelisihPositif;
        private DataGridViewTextBoxColumn colSesiSelisihNegatif;
        private DataGridViewTextBoxColumn colSesiStatus;
        private Panel pnlSubRiwayatOpname;
        private DateTimePicker dtpOpnameMulai;
        private Label lblOpnameSampai;
        private DateTimePicker dtpOpnameSelesai;
        private ComboBox cmbFilterStatusOpname;
        private TextBox txtCariRiwayatOpname;
        private Button btnTerapkanFilterRiwayat;
        private Button btnBukaDetailRiwayat;
        private DataGridView gridRiwayatOpname;
        private DataGridViewTextBoxColumn colRiwNo;
        private DataGridViewTextBoxColumn colRiwTanggal;
        private DataGridViewTextBoxColumn colRiwPembuat;
        private DataGridViewTextBoxColumn colRiwPenyetuju;
        private DataGridViewTextBoxColumn colRiwJumlah;
        private DataGridViewTextBoxColumn colRiwSelisih;
        private DataGridViewTextBoxColumn colRiwStatus;
        private DataGridViewTextBoxColumn colRiwWaktuSelesai;
    }
}
