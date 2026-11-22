namespace Sukimart
{
    partial class FormLaporan
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
            btnPenjualan = new Button();
            btnGudangReport = new Button();
            dtpMulai = new DateTimePicker();
            dtpSelesai = new DateTimePicker();
            btnTerapkanTanggal = new Button();
            btnSimpanJson = new Button();
            lblRingkasan = new Label();
            pnlCard1 = new Panel();
            lblCard1Judul = new Label();
            lblOmzetNilai = new Label();
            pnlCard2 = new Panel();
            lblCard2Judul = new Label();
            lblTrxNilai = new Label();
            pnlCard3 = new Panel();
            lblCard3Judul = new Label();
            lblItemTerjualNilai = new Label();
            pnlCard4 = new Panel();
            lblCard4Judul = new Label();
            lblRataNilai = new Label();
            btnHariIni = new Button();
            btnBulanIni = new Button();
            btnSemuaWaktu = new Button();
            gridLaporan = new DataGridView();
            colFaktur = new DataGridViewTextBoxColumn();
            colWaktu = new DataGridViewTextBoxColumn();
            colKasir = new DataGridViewTextBoxColumn();
            colItemQty = new DataGridViewTextBoxColumn();
            colTotalOmzet = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnSubTransaksi = new Button();
            btnSubLaba = new Button();
            gridLaba = new DataGridView();
            colLabaKode = new DataGridViewTextBoxColumn();
            colLabaNama = new DataGridViewTextBoxColumn();
            colLabaTerjual = new DataGridViewTextBoxColumn();
            colLabaPendapatan = new DataGridViewTextBoxColumn();
            colLabaModal = new DataGridViewTextBoxColumn();
            colLabaKotor = new DataGridViewTextBoxColumn();
            pnlTotalLaba = new Panel();
            lblTotalJudul = new Label();
            lblTotalTerjualLabel = new Label();
            lblTotalTerjualNilai = new Label();
            lblTotalPendapatanLabel = new Label();
            lblTotalPendapatanNilai = new Label();
            lblTotalModalLabel = new Label();
            lblTotalModalNilai = new Label();
            lblTotalLabaLabel = new Label();
            lblTotalLabaNilai = new Label();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLaporan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridLaba).BeginInit();
            pnlTotalLaba.SuspendLayout();
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
            btnKeluar.Click += btnKeluar_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.FromArgb(255, 196, 0);
            btnLaporan.Cursor = Cursors.Hand;
            btnLaporan.FlatAppearance.BorderSize = 0;
            btnLaporan.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.Font = new Font("Inter", 10F, FontStyle.Bold);
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
            // btnPengguna
            // 
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
            btnPengguna.Click += btnPengguna_Click;
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
            btnGudang.Click += btnGudang_Click;
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
            btnRiwayat.Click += btnRiwayat_Click;
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
            btnKatalog.Click += btnKatalog_Click;
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
            btnKasir.Click += btnKasir_Click;
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
            btnDashboard.Click += btnDashboard_Click;
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
            pnlKanan.Controls.Add(pnlCard1);
            pnlKanan.Controls.Add(pnlCard2);
            pnlKanan.Controls.Add(pnlCard3);
            pnlKanan.Controls.Add(pnlCard4);
            pnlKanan.Controls.Add(btnPenjualan);
            pnlKanan.Controls.Add(btnGudangReport);
            pnlKanan.Controls.Add(btnSubTransaksi);
            pnlKanan.Controls.Add(btnSubLaba);
            pnlKanan.Controls.Add(dtpMulai);
            pnlKanan.Controls.Add(dtpSelesai);
            pnlKanan.Controls.Add(btnTerapkanTanggal);
            pnlKanan.Controls.Add(btnSimpanJson);
            pnlKanan.Controls.Add(btnHariIni);
            pnlKanan.Controls.Add(btnBulanIni);
            pnlKanan.Controls.Add(btnSemuaWaktu);
            pnlKanan.Controls.Add(lblRingkasan);
            pnlKanan.Controls.Add(gridLaporan);
            pnlKanan.Controls.Add(gridLaba);
            pnlKanan.Controls.Add(pnlTotalLaba);
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
            nightControlBox1.DefaultLocation = false;
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
            lblJudul.Location = new Point(40, 32);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(261, 33);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Laporan Penjualan";
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.BorderStyle = BorderStyle.None;
            pnlCard1.Controls.Add(lblCard1Judul);
            pnlCard1.Controls.Add(lblOmzetNilai);
            pnlCard1.Location = new Point(40, 112);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(222, 112);
            pnlCard1.TabIndex = 3;
            // 
            // lblCard1Judul
            // 
            lblCard1Judul.AutoSize = true;
            lblCard1Judul.Font = new Font("Inter", 9F);
            lblCard1Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard1Judul.Location = new Point(24, 20);
            lblCard1Judul.Name = "lblCard1Judul";
            lblCard1Judul.Size = new Size(106, 15);
            lblCard1Judul.TabIndex = 0;
            lblCard1Judul.Text = "Total Pendapatan";
            // 
            // lblOmzetNilai
            // 
            lblOmzetNilai.AutoSize = true;
            lblOmzetNilai.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblOmzetNilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblOmzetNilai.Location = new Point(24, 48);
            lblOmzetNilai.Name = "lblOmzetNilai";
            lblOmzetNilai.Size = new Size(49, 21);
            lblOmzetNilai.TabIndex = 1;
            lblOmzetNilai.Text = "Rp 0";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.BorderStyle = BorderStyle.None;
            pnlCard2.Controls.Add(lblCard2Judul);
            pnlCard2.Controls.Add(lblTrxNilai);
            pnlCard2.Location = new Point(286, 112);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(222, 112);
            pnlCard2.TabIndex = 4;
            // 
            // lblCard2Judul
            // 
            lblCard2Judul.AutoSize = true;
            lblCard2Judul.Font = new Font("Inter", 9F);
            lblCard2Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard2Judul.Location = new Point(24, 20);
            lblCard2Judul.Name = "lblCard2Judul";
            lblCard2Judul.Size = new Size(93, 15);
            lblCard2Judul.TabIndex = 0;
            lblCard2Judul.Text = "Total Transaksi";
            // 
            // lblTrxNilai
            // 
            lblTrxNilai.AutoSize = true;
            lblTrxNilai.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblTrxNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTrxNilai.Location = new Point(24, 48);
            lblTrxNilai.Name = "lblTrxNilai";
            lblTrxNilai.Size = new Size(22, 21);
            lblTrxNilai.TabIndex = 1;
            lblTrxNilai.Text = "0";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.BorderStyle = BorderStyle.None;
            pnlCard3.Controls.Add(lblCard3Judul);
            pnlCard3.Controls.Add(lblItemTerjualNilai);
            pnlCard3.Location = new Point(532, 112);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(222, 112);
            pnlCard3.TabIndex = 5;
            // 
            // lblCard3Judul
            // 
            lblCard3Judul.AutoSize = true;
            lblCard3Judul.Font = new Font("Inter", 9F);
            lblCard3Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard3Judul.Location = new Point(24, 20);
            lblCard3Judul.Name = "lblCard3Judul";
            lblCard3Judul.Size = new Size(105, 15);
            lblCard3Judul.TabIndex = 0;
            lblCard3Judul.Text = "Total Item Terjual";
            // 
            // lblItemTerjualNilai
            // 
            lblItemTerjualNilai.AutoSize = true;
            lblItemTerjualNilai.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblItemTerjualNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblItemTerjualNilai.Location = new Point(24, 48);
            lblItemTerjualNilai.Name = "lblItemTerjualNilai";
            lblItemTerjualNilai.Size = new Size(58, 21);
            lblItemTerjualNilai.TabIndex = 1;
            lblItemTerjualNilai.Text = "0 pcs";
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.BorderStyle = BorderStyle.None;
            pnlCard4.Controls.Add(lblCard4Judul);
            pnlCard4.Controls.Add(lblRataNilai);
            pnlCard4.Location = new Point(778, 112);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(222, 112);
            pnlCard4.TabIndex = 6;
            // 
            // lblCard4Judul
            // 
            lblCard4Judul.AutoSize = true;
            lblCard4Judul.Font = new Font("Inter", 9F);
            lblCard4Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard4Judul.Location = new Point(24, 20);
            lblCard4Judul.Name = "lblCard4Judul";
            lblCard4Judul.Size = new Size(121, 15);
            lblCard4Judul.TabIndex = 0;
            lblCard4Judul.Text = "Rata-rata/Transaksi";
            // 
            // lblRataNilai
            // 
            lblRataNilai.AutoSize = true;
            lblRataNilai.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblRataNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblRataNilai.Location = new Point(24, 48);
            lblRataNilai.Name = "lblRataNilai";
            lblRataNilai.Size = new Size(49, 21);
            lblRataNilai.TabIndex = 1;
            lblRataNilai.Text = "Rp 0";
            // 
            // btnHariIni
            // 
            btnHariIni.BackColor = Color.FromArgb(255, 196, 0);
            btnHariIni.Cursor = Cursors.Hand;
            btnHariIni.FlatAppearance.BorderSize = 0;
            btnHariIni.FlatStyle = FlatStyle.Flat;
            btnHariIni.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnHariIni.ForeColor = Color.FromArgb(31, 41, 55);
            btnHariIni.Location = new Point(40, 248);
            btnHariIni.Name = "btnHariIni";
            btnHariIni.Size = new Size(120, 32);
            btnHariIni.TabIndex = 7;
            btnHariIni.Text = "Hari Ini";
            btnHariIni.UseVisualStyleBackColor = false;
            btnHariIni.Click += btnHariIni_Click;
            // 
            // btnBulanIni
            // 
            btnBulanIni.BackColor = Color.White;
            btnBulanIni.Cursor = Cursors.Hand;
            btnBulanIni.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBulanIni.FlatStyle = FlatStyle.Flat;
            btnBulanIni.Font = new Font("Inter", 10F);
            btnBulanIni.ForeColor = Color.FromArgb(75, 85, 99);
            btnBulanIni.Location = new Point(168, 248);
            btnBulanIni.Name = "btnBulanIni";
            btnBulanIni.Size = new Size(120, 32);
            btnBulanIni.TabIndex = 8;
            btnBulanIni.Text = "Bulan Ini";
            btnBulanIni.UseVisualStyleBackColor = false;
            btnBulanIni.Click += btnBulanIni_Click;
            // 
            // btnSemuaWaktu
            // 
            btnSemuaWaktu.BackColor = Color.White;
            btnSemuaWaktu.Cursor = Cursors.Hand;
            btnSemuaWaktu.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSemuaWaktu.FlatStyle = FlatStyle.Flat;
            btnSemuaWaktu.Font = new Font("Inter", 10F);
            btnSemuaWaktu.ForeColor = Color.FromArgb(75, 85, 99);
            btnSemuaWaktu.Location = new Point(296, 248);
            btnSemuaWaktu.Name = "btnSemuaWaktu";
            btnSemuaWaktu.Size = new Size(120, 32);
            btnSemuaWaktu.TabIndex = 9;
            btnSemuaWaktu.Text = "Semua Waktu";
            btnSemuaWaktu.UseVisualStyleBackColor = false;
            btnSemuaWaktu.Click += btnSemuaWaktu_Click;
            // 
            // gridLaporan
            // 
            gridLaporan.AllowUserToAddRows = false;
            gridLaporan.AllowUserToDeleteRows = false;
            gridLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLaporan.BackgroundColor = Color.White;
            gridLaporan.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridLaporan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridLaporan.ColumnHeadersHeight = 40;
            gridLaporan.Columns.AddRange(new DataGridViewColumn[] { colFaktur, colWaktu, colKasir, colItemQty, colTotalOmzet, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Inter", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridLaporan.DefaultCellStyle = dataGridViewCellStyle4;
            gridLaporan.EnableHeadersVisualStyles = false;
            gridLaporan.Location = new Point(40, 296);
            gridLaporan.MultiSelect = false;
            gridLaporan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridLaporan.GridColor = Color.FromArgb(229, 231, 235);
            gridLaporan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridLaporan.Name = "gridLaporan";
            gridLaporan.ReadOnly = true;
            gridLaporan.RowHeadersVisible = false;
            gridLaporan.RowTemplate.Height = 36;
            gridLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLaporan.Size = new Size(960, 384);
            gridLaporan.TabIndex = 10;
            // 
            // colFaktur
            // 
            colFaktur.DataPropertyName = "Id";
            colFaktur.FillWeight = 110F;
            colFaktur.HeaderText = "No. Faktur";
            colFaktur.Name = "colFaktur";
            colFaktur.ReadOnly = true;
            // 
            // colWaktu
            // 
            colWaktu.DataPropertyName = "WaktuFormat";
            colWaktu.FillWeight = 110F;
            colWaktu.HeaderText = "Waktu Transaksi";
            colWaktu.Name = "colWaktu";
            colWaktu.ReadOnly = true;
            // 
            // colKasir
            // 
            colKasir.DataPropertyName = "Kasir";
            colKasir.FillWeight = 75F;
            colKasir.HeaderText = "Kasir";
            colKasir.Name = "colKasir";
            colKasir.ReadOnly = true;
            // 
            // colItemQty
            // 
            colItemQty.DataPropertyName = "ItemQty";
            colItemQty.FillWeight = 65F;
            colItemQty.HeaderText = "Item Qty";
            colItemQty.Name = "colItemQty";
            colItemQty.ReadOnly = true;
            // 
            // colTotalOmzet
            // 
            colTotalOmzet.DataPropertyName = "TotalFormat";
            colTotalOmzet.HeaderText = "Total Belanja";
            colTotalOmzet.Name = "colTotalOmzet";
            colTotalOmzet.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 65F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnPenjualan - Tombol untuk memilih mode Laporan Penjualan
            // 
            btnPenjualan.BackColor = Color.FromArgb(255, 196, 0);
            btnPenjualan.Cursor = Cursors.Hand;
            btnPenjualan.FlatAppearance.BorderSize = 0;
            btnPenjualan.FlatStyle = FlatStyle.Flat;
            btnPenjualan.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnPenjualan.ForeColor = Color.FromArgb(31, 41, 55);
            btnPenjualan.Location = new Point(40, 248);
            btnPenjualan.Name = "btnPenjualan";
            btnPenjualan.Size = new Size(120, 32);
            btnPenjualan.TabIndex = 11;
            btnPenjualan.Text = "Penjualan";
            btnPenjualan.UseVisualStyleBackColor = false;
            btnPenjualan.Click += btnPenjualan_Click;
            // 
            // btnGudangReport - Tombol untuk memilih mode Laporan Inventaris Gudang
            // 
            btnGudangReport.BackColor = Color.White;
            btnGudangReport.Cursor = Cursors.Hand;
            btnGudangReport.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnGudangReport.FlatAppearance.BorderSize = 1;
            btnGudangReport.FlatStyle = FlatStyle.Flat;
            btnGudangReport.Font = new Font("Inter", 10F);
            btnGudangReport.ForeColor = Color.FromArgb(75, 85, 99);
            btnGudangReport.Location = new Point(168, 248);
            btnGudangReport.Name = "btnGudangReport";
            btnGudangReport.Size = new Size(152, 32);
            btnGudangReport.TabIndex = 12;
            btnGudangReport.Text = "Inventaris Gudang";
            btnGudangReport.UseVisualStyleBackColor = false;
            btnGudangReport.Click += btnGudangReport_Click;
            // 
            // dtpMulai - Pemilih tanggal awal periode laporan
            // 
            dtpMulai.Format = DateTimePickerFormat.Short;
            dtpMulai.Font = new Font("Inter", 10F);
            dtpMulai.Location = new Point(336, 252);
            dtpMulai.Name = "dtpMulai";
            dtpMulai.Size = new Size(118, 23);
            dtpMulai.TabIndex = 13;
            // 
            // dtpSelesai - Pemilih tanggal akhir periode laporan
            // 
            dtpSelesai.Format = DateTimePickerFormat.Short;
            dtpSelesai.Font = new Font("Inter", 10F);
            dtpSelesai.Location = new Point(462, 252);
            dtpSelesai.Name = "dtpSelesai";
            dtpSelesai.Size = new Size(118, 23);
            dtpSelesai.TabIndex = 14;
            // 
            // btnTerapkanTanggal - Tombol untuk menerapkan filter tanggal
            // 
            btnTerapkanTanggal.BackColor = Color.White;
            btnTerapkanTanggal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTerapkanTanggal.FlatStyle = FlatStyle.Flat;
            btnTerapkanTanggal.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnTerapkanTanggal.ForeColor = Color.FromArgb(55, 65, 81);
            btnTerapkanTanggal.Location = new Point(588, 248);
            btnTerapkanTanggal.Name = "btnTerapkanTanggal";
            btnTerapkanTanggal.Size = new Size(108, 32);
            btnTerapkanTanggal.TabIndex = 15;
            btnTerapkanTanggal.Text = "Terapkan";
            btnTerapkanTanggal.Click += btnTerapkanTanggal_Click;
            // 
            // btnSimpanJson - Tombol untuk menyimpan laporan ke file JSON
            // 
            btnSimpanJson.BackColor = Color.White;
            btnSimpanJson.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSimpanJson.FlatStyle = FlatStyle.Flat;
            btnSimpanJson.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnSimpanJson.ForeColor = Color.FromArgb(55, 65, 81);
            btnSimpanJson.Location = new Point(704, 248);
            btnSimpanJson.Name = "btnSimpanJson";
            btnSimpanJson.Size = new Size(128, 32);
            btnSimpanJson.TabIndex = 16;
            btnSimpanJson.Text = "💾 Simpan JSON";
            btnSimpanJson.Click += btnSimpanJson_Click;
            // 
            // lblRingkasan - Label untuk menampilkan ringkasan laporan
            // 
            lblRingkasan.Font = new Font("Inter", 9F);
            lblRingkasan.ForeColor = Color.FromArgb(75, 85, 99);
            lblRingkasan.Location = new Point(40, 292);
            lblRingkasan.Name = "lblRingkasan";
            lblRingkasan.Size = new Size(960, 42);
            lblRingkasan.TabIndex = 17;
            // 
            // btnSubTransaksi
            // 
            btnSubTransaksi.BackColor = Color.FromArgb(255, 196, 0);
            btnSubTransaksi.Cursor = Cursors.Hand;
            btnSubTransaksi.FlatAppearance.BorderSize = 0;
            btnSubTransaksi.FlatStyle = FlatStyle.Flat;
            btnSubTransaksi.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnSubTransaksi.ForeColor = Color.FromArgb(31, 41, 55);
            btnSubTransaksi.Location = new Point(40, 248);
            btnSubTransaksi.Name = "btnSubTransaksi";
            btnSubTransaksi.Size = new Size(110, 32);
            btnSubTransaksi.TabIndex = 18;
            btnSubTransaksi.Text = "Transaksi";
            btnSubTransaksi.UseVisualStyleBackColor = false;
            btnSubTransaksi.Click += btnSubTransaksi_Click;
            // 
            // btnSubLaba
            // 
            btnSubLaba.BackColor = Color.White;
            btnSubLaba.Cursor = Cursors.Hand;
            btnSubLaba.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSubLaba.FlatAppearance.BorderSize = 1;
            btnSubLaba.FlatStyle = FlatStyle.Flat;
            btnSubLaba.Font = new Font("Inter", 9.5F);
            btnSubLaba.ForeColor = Color.FromArgb(75, 85, 99);
            btnSubLaba.Location = new Point(158, 248);
            btnSubLaba.Name = "btnSubLaba";
            btnSubLaba.Size = new Size(110, 32);
            btnSubLaba.TabIndex = 19;
            btnSubLaba.Text = "Laba";
            btnSubLaba.UseVisualStyleBackColor = false;
            btnSubLaba.Click += btnSubLaba_Click;
            // 
            // gridLaba
            // 
            gridLaba.AllowUserToAddRows = false;
            gridLaba.AllowUserToDeleteRows = false;
            gridLaba.AutoGenerateColumns = false;
            gridLaba.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLaba.BackgroundColor = Color.White;
            gridLaba.BorderStyle = BorderStyle.None;
            gridLaba.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridLaba.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridLaba.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridLaba.ColumnHeadersHeight = 40;
            gridLaba.Columns.AddRange(new DataGridViewColumn[] { colLabaKode, colLabaNama, colLabaTerjual, colLabaPendapatan, colLabaModal, colLabaKotor });
            gridLaba.DefaultCellStyle = dataGridViewCellStyle4;
            gridLaba.EnableHeadersVisualStyles = false;
            gridLaba.GridColor = Color.FromArgb(229, 231, 235);
            gridLaba.Location = new Point(40, 344);
            gridLaba.MultiSelect = false;
            gridLaba.Name = "gridLaba";
            gridLaba.ReadOnly = true;
            gridLaba.RowHeadersVisible = false;
            gridLaba.RowTemplate.Height = 36;
            gridLaba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLaba.Size = new Size(960, 276);
            gridLaba.TabIndex = 20;
            gridLaba.Visible = false;
            gridLaba.ColumnHeaderMouseClick += gridLaba_ColumnHeaderMouseClick;
            // 
            // colLabaKode
            // 
            colLabaKode.DataPropertyName = "Kode";
            colLabaKode.FillWeight = 13F;
            colLabaKode.HeaderText = "Kode";
            colLabaKode.Name = "colLabaKode";
            colLabaKode.ReadOnly = true;
            // 
            // colLabaNama
            // 
            colLabaNama.DataPropertyName = "Nama";
            colLabaNama.FillWeight = 23F;
            colLabaNama.HeaderText = "Nama Barang";
            colLabaNama.Name = "colLabaNama";
            colLabaNama.ReadOnly = true;
            // 
            // colLabaTerjual
            // 
            colLabaTerjual.DataPropertyName = "Terjual";
            colLabaTerjual.FillWeight = 10F;
            colLabaTerjual.HeaderText = "Terjual";
            colLabaTerjual.Name = "colLabaTerjual";
            colLabaTerjual.ReadOnly = true;
            // 
            // colLabaPendapatan
            // 
            colLabaPendapatan.DataPropertyName = "Pendapatan";
            colLabaPendapatan.FillWeight = 18F;
            colLabaPendapatan.HeaderText = "Pendapatan";
            colLabaPendapatan.Name = "colLabaPendapatan";
            colLabaPendapatan.ReadOnly = true;
            // 
            // colLabaModal
            // 
            colLabaModal.DataPropertyName = "TotalModal";
            colLabaModal.FillWeight = 18F;
            colLabaModal.HeaderText = "Total Modal";
            colLabaModal.Name = "colLabaModal";
            colLabaModal.ReadOnly = true;
            // 
            // colLabaKotor
            // 
            colLabaKotor.DataPropertyName = "LabaKotor";
            colLabaKotor.FillWeight = 18F;
            colLabaKotor.HeaderText = "Laba Kotor";
            colLabaKotor.Name = "colLabaKotor";
            colLabaKotor.ReadOnly = true;
            // 
            // pnlTotalLaba
            // 
            pnlTotalLaba.BackColor = Color.FromArgb(249, 250, 251);
            pnlTotalLaba.Controls.Add(lblTotalJudul);
            pnlTotalLaba.Controls.Add(lblTotalTerjualLabel);
            pnlTotalLaba.Controls.Add(lblTotalTerjualNilai);
            pnlTotalLaba.Controls.Add(lblTotalPendapatanLabel);
            pnlTotalLaba.Controls.Add(lblTotalPendapatanNilai);
            pnlTotalLaba.Controls.Add(lblTotalModalLabel);
            pnlTotalLaba.Controls.Add(lblTotalModalNilai);
            pnlTotalLaba.Controls.Add(lblTotalLabaLabel);
            pnlTotalLaba.Controls.Add(lblTotalLabaNilai);
            pnlTotalLaba.Location = new Point(40, 626);
            pnlTotalLaba.Name = "pnlTotalLaba";
            pnlTotalLaba.Size = new Size(960, 48);
            pnlTotalLaba.TabIndex = 21;
            pnlTotalLaba.Visible = false;
            // 
            // lblTotalJudul
            // 
            lblTotalJudul.AutoSize = true;
            lblTotalJudul.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblTotalJudul.ForeColor = Color.FromArgb(55, 65, 81);
            lblTotalJudul.Location = new Point(14, 14);
            lblTotalJudul.Name = "lblTotalJudul";
            lblTotalJudul.Size = new Size(45, 16);
            lblTotalJudul.TabIndex = 0;
            lblTotalJudul.Text = "TOTAL";
            // 
            // lblTotalTerjualLabel
            // 
            lblTotalTerjualLabel.AutoSize = true;
            lblTotalTerjualLabel.Font = new Font("Inter", 8.5F);
            lblTotalTerjualLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalTerjualLabel.Location = new Point(270, 15);
            lblTotalTerjualLabel.Name = "lblTotalTerjualLabel";
            lblTotalTerjualLabel.Size = new Size(48, 15);
            lblTotalTerjualLabel.TabIndex = 1;
            lblTotalTerjualLabel.Text = "Terjual:";
            // 
            // lblTotalTerjualNilai
            // 
            lblTotalTerjualNilai.AutoSize = true;
            lblTotalTerjualNilai.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblTotalTerjualNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalTerjualNilai.Location = new Point(322, 14);
            lblTotalTerjualNilai.Name = "lblTotalTerjualNilai";
            lblTotalTerjualNilai.Size = new Size(16, 16);
            lblTotalTerjualNilai.TabIndex = 2;
            lblTotalTerjualNilai.Text = "0";
            // 
            // lblTotalPendapatanLabel
            // 
            lblTotalPendapatanLabel.AutoSize = true;
            lblTotalPendapatanLabel.Font = new Font("Inter", 8.5F);
            lblTotalPendapatanLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalPendapatanLabel.Location = new Point(410, 15);
            lblTotalPendapatanLabel.Name = "lblTotalPendapatanLabel";
            lblTotalPendapatanLabel.Size = new Size(77, 15);
            lblTotalPendapatanLabel.TabIndex = 3;
            lblTotalPendapatanLabel.Text = "Pendapatan:";
            // 
            // lblTotalPendapatanNilai
            // 
            lblTotalPendapatanNilai.AutoSize = true;
            lblTotalPendapatanNilai.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblTotalPendapatanNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalPendapatanNilai.Location = new Point(491, 14);
            lblTotalPendapatanNilai.Name = "lblTotalPendapatanNilai";
            lblTotalPendapatanNilai.Size = new Size(38, 16);
            lblTotalPendapatanNilai.TabIndex = 4;
            lblTotalPendapatanNilai.Text = "Rp 0";
            // 
            // lblTotalModalLabel
            // 
            lblTotalModalLabel.AutoSize = true;
            lblTotalModalLabel.Font = new Font("Inter", 8.5F);
            lblTotalModalLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalModalLabel.Location = new Point(590, 15);
            lblTotalModalLabel.Name = "lblTotalModalLabel";
            lblTotalModalLabel.Size = new Size(46, 15);
            lblTotalModalLabel.TabIndex = 5;
            lblTotalModalLabel.Text = "Modal:";
            // 
            // lblTotalModalNilai
            // 
            lblTotalModalNilai.AutoSize = true;
            lblTotalModalNilai.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblTotalModalNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalModalNilai.Location = new Point(640, 14);
            lblTotalModalNilai.Name = "lblTotalModalNilai";
            lblTotalModalNilai.Size = new Size(38, 16);
            lblTotalModalNilai.TabIndex = 6;
            lblTotalModalNilai.Text = "Rp 0";
            // 
            // lblTotalLabaLabel
            // 
            lblTotalLabaLabel.AutoSize = true;
            lblTotalLabaLabel.Font = new Font("Inter", 8.5F);
            lblTotalLabaLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalLabaLabel.Location = new Point(740, 15);
            lblTotalLabaLabel.Name = "lblTotalLabaLabel";
            lblTotalLabaLabel.Size = new Size(71, 15);
            lblTotalLabaLabel.TabIndex = 7;
            lblTotalLabaLabel.Text = "Laba Kotor:";
            // 
            // lblTotalLabaNilai
            // 
            lblTotalLabaNilai.AutoSize = true;
            lblTotalLabaNilai.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblTotalLabaNilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblTotalLabaNilai.Location = new Point(815, 14);
            lblTotalLabaNilai.Name = "lblTotalLabaNilai";
            lblTotalLabaNilai.Size = new Size(38, 16);
            lblTotalLabaNilai.TabIndex = 8;
            lblTotalLabaNilai.Text = "Rp 0";
            // 
            // FormLaporan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLaporan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Laporan";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLaporan).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridLaba).EndInit();
            pnlTotalLaba.ResumeLayout(false);
            pnlTotalLaba.PerformLayout();
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
        private Panel pnlCard1;
        private Label lblCard1Judul;
        private Label lblOmzetNilai;
        private Panel pnlCard2;
        private Label lblCard2Judul;
        private Label lblTrxNilai;
        private Panel pnlCard3;
        private Label lblCard3Judul;
        private Label lblItemTerjualNilai;
        private Panel pnlCard4;
        private Label lblCard4Judul;
        private Label lblRataNilai;
        private Button btnHariIni;
        private Button btnBulanIni;
        private Button btnSemuaWaktu;
        private DataGridView gridLaporan;
        private DataGridViewTextBoxColumn colFaktur;
        private DataGridViewTextBoxColumn colWaktu;
        private DataGridViewTextBoxColumn colKasir;
        private DataGridViewTextBoxColumn colItemQty;
        private DataGridViewTextBoxColumn colTotalOmzet;
        private DataGridViewTextBoxColumn colStatus;
        private Button btnPenjualan;
        private Button btnGudangReport;
        private Button btnSubTransaksi;
        private Button btnSubLaba;
        private DataGridView gridLaba;
        private DataGridViewTextBoxColumn colLabaKode;
        private DataGridViewTextBoxColumn colLabaNama;
        private DataGridViewTextBoxColumn colLabaTerjual;
        private DataGridViewTextBoxColumn colLabaPendapatan;
        private DataGridViewTextBoxColumn colLabaModal;
        private DataGridViewTextBoxColumn colLabaKotor;
        private Panel pnlTotalLaba;
        private Label lblTotalJudul;
        private Label lblTotalTerjualLabel;
        private Label lblTotalTerjualNilai;
        private Label lblTotalPendapatanLabel;
        private Label lblTotalPendapatanNilai;
        private Label lblTotalModalLabel;
        private Label lblTotalModalNilai;
        private Label lblTotalLabaLabel;
        private Label lblTotalLabaNilai;
        private DateTimePicker dtpMulai;
        private DateTimePicker dtpSelesai;
        private Button btnTerapkanTanggal;
        private Button btnSimpanJson;
        private Label lblRingkasan;
    }
}
