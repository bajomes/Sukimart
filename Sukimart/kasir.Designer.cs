namespace Sukimart
{
    partial class FormKasir
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
            btnGantiSandi = new Button();
            btnPengguna = new Button();
            btnLogAktivitas = new Button();
            btnLaporanInventaris = new Button();
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
            lblJudul = new Label();
            lblPilihBarang = new Label();
            txtCariProduk = new TextBox();
            btnHapusCari = new Button();
            lblJumlah = new Label();
            nudJumlah = new NumericUpDown();
            btnTambahKeranjang = new Button();
            flowKategori = new FlowLayoutPanel();
            flowProduk = new FlowLayoutPanel();
            lblHeaderKeranjang = new Label();
            gridKeranjang = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colKurang = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colTambah = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            colHapus = new DataGridViewTextBoxColumn();
            pnlCheckout = new Panel();
            lblTotalLabel = new Label();
            lblTotalNilai = new Label();
            lblBayarLabel = new Label();
            btnUangPas = new Button();
            nudBayar = new NumericUpDown();
            lblKembalianLabel = new Label();
            lblKembalianNilai = new Label();
            btnProsesBayar = new Button();
            btnBatalKeranjang = new Button();
            pnlGaris = new Panel();
            btnUang100 = new Button();
            btnUang50 = new Button();
            lblPintasanJudul = new Label();
            lblPintasanTombol1 = new Label();
            lblPintasanKet1 = new Label();
            lblPintasanTombol2 = new Label();
            lblPintasanKet2 = new Label();
            lblPintasanTombol3 = new Label();
            lblPintasanKet3 = new Label();
            lblPintasanTombol4 = new Label();
            lblPintasanKet4 = new Label();
            lblPintasanTombol5 = new Label();
            lblPintasanKet5 = new Label();
            btnUang10 = new Button();
            btnUang20 = new Button();
            btnNolkanBayar = new Button();
            lblInfoKeranjang = new Label();
            lblInfoKasir = new Label();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudJumlah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridKeranjang).BeginInit();
            pnlCheckout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBayar).BeginInit();
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
            pnlKiri.Margin = new Padding(3, 4, 3, 4);
            pnlKiri.Name = "pnlKiri";
            pnlKiri.Size = new Size(274, 960);
            pnlKiri.TabIndex = 1;
            // 
            // btnKeluar
            // 
            btnKeluar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKeluar.BackColor = Color.White;
            btnKeluar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnKeluar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKeluar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKeluar.BackColor = Color.White;
            btnKeluar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnKeluar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Inter", 10F);
            btnKeluar.ForeColor = Color.FromArgb(75, 85, 99);
            btnKeluar.Location = new Point(18, 853);
            btnKeluar.Margin = new Padding(3, 4, 3, 4);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Padding = new Padding(18, 0, 0, 0);
            btnKeluar.Size = new Size(238, 53);
            btnKeluar.TabIndex = 11;
            btnKeluar.Text = "Keluar";
            btnKeluar.TextAlign = ContentAlignment.MiddleLeft;
            btnKeluar.UseVisualStyleBackColor = false;
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
            btnGantiSandi.Location = new Point(18, 789);
            btnGantiSandi.Margin = new Padding(3, 4, 3, 4);
            btnGantiSandi.Name = "btnGantiSandi";
            btnGantiSandi.Padding = new Padding(18, 0, 0, 0);
            btnGantiSandi.Size = new Size(238, 53);
            btnGantiSandi.TabIndex = 14;
            btnGantiSandi.Text = "Ganti Kata Sandi";
            btnGantiSandi.TextAlign = ContentAlignment.MiddleLeft;
            btnGantiSandi.UseVisualStyleBackColor = false;
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
            btnPengguna.Location = new Point(18, 597);
            btnPengguna.Margin = new Padding(3, 4, 3, 4);
            btnPengguna.Name = "btnPengguna";
            btnPengguna.Padding = new Padding(18, 0, 0, 0);
            btnPengguna.Size = new Size(238, 53);
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
            btnLogAktivitas.Location = new Point(18, 661);
            btnLogAktivitas.Margin = new Padding(3, 4, 3, 4);
            btnLogAktivitas.Name = "btnLogAktivitas";
            btnLogAktivitas.Padding = new Padding(18, 0, 0, 0);
            btnLogAktivitas.Size = new Size(238, 53);
            btnLogAktivitas.TabIndex = 13;
            btnLogAktivitas.Text = "Log Aktivitas";
            btnLogAktivitas.TextAlign = ContentAlignment.MiddleLeft;
            btnLogAktivitas.UseVisualStyleBackColor = false;
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
            btnLaporan.Location = new Point(18, 469);
            btnLaporan.Margin = new Padding(3, 4, 3, 4);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Padding = new Padding(18, 0, 0, 0);
            btnLaporan.Size = new Size(238, 53);
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
            btnLaporanInventaris.Location = new Point(18, 533);
            btnLaporanInventaris.Margin = new Padding(3, 4, 3, 4);
            btnLaporanInventaris.Name = "btnLaporanInventaris";
            btnLaporanInventaris.Padding = new Padding(18, 0, 0, 0);
            btnLaporanInventaris.Size = new Size(238, 53);
            btnLaporanInventaris.TabIndex = 11;
            btnLaporanInventaris.Text = "Laporan Inventaris";
            btnLaporanInventaris.TextAlign = ContentAlignment.MiddleLeft;
            btnLaporanInventaris.UseVisualStyleBackColor = false;
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
            btnGudang.Location = new Point(18, 405);
            btnGudang.Margin = new Padding(3, 4, 3, 4);
            btnGudang.Name = "btnGudang";
            btnGudang.Padding = new Padding(18, 0, 0, 0);
            btnGudang.Size = new Size(238, 53);
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
            btnRiwayat.Location = new Point(18, 341);
            btnRiwayat.Margin = new Padding(3, 4, 3, 4);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Padding = new Padding(18, 0, 0, 0);
            btnRiwayat.Size = new Size(238, 53);
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
            btnKatalog.Location = new Point(18, 277);
            btnKatalog.Margin = new Padding(3, 4, 3, 4);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Padding = new Padding(18, 0, 0, 0);
            btnKatalog.Size = new Size(238, 53);
            btnKatalog.TabIndex = 5;
            btnKatalog.Text = "Katalog Produk";
            btnKatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnKatalog.UseVisualStyleBackColor = false;
            // 
            // btnKasir
            // 
            btnKasir.BackColor = Color.FromArgb(255, 196, 0);
            btnKasir.Cursor = Cursors.Hand;
            btnKasir.FlatAppearance.BorderSize = 0;
            btnKasir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKasir.FlatStyle = FlatStyle.Flat;
            btnKasir.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnKasir.ForeColor = Color.FromArgb(31, 41, 55);
            btnKasir.Location = new Point(18, 213);
            btnKasir.Margin = new Padding(3, 4, 3, 4);
            btnKasir.Name = "btnKasir";
            btnKasir.Padding = new Padding(18, 0, 0, 0);
            btnKasir.Size = new Size(238, 53);
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
            btnDashboard.Location = new Point(18, 149);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(18, 0, 0, 0);
            btnDashboard.Size = new Size(238, 53);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // pictureLogo
            // 
            pictureLogo.Image = Properties.Resources.logo;
            pictureLogo.Location = new Point(27, 43);
            pictureLogo.Margin = new Padding(3, 4, 3, 4);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(46, 53);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 2;
            pictureLogo.TabStop = false;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblNama.Location = new Point(82, 53);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(144, 29);
            lblNama.TabIndex = 1;
            lblNama.Text = "SUKIMART";
            // 
            // pnlKanan
            // 
            pnlKanan.BackColor = Color.FromArgb(247, 247, 245);
            pnlKanan.Controls.Add(nightControlBox1);
            pnlKanan.Controls.Add(lblJudul);
            pnlKanan.Controls.Add(lblPilihBarang);
            pnlKanan.Controls.Add(txtCariProduk);
            pnlKanan.Controls.Add(btnHapusCari);
            pnlKanan.Controls.Add(lblJumlah);
            pnlKanan.Controls.Add(nudJumlah);
            pnlKanan.Controls.Add(btnTambahKeranjang);
            pnlKanan.Controls.Add(flowKategori);
            pnlKanan.Controls.Add(flowProduk);
            pnlKanan.Controls.Add(lblHeaderKeranjang);
            pnlKanan.Controls.Add(gridKeranjang);
            pnlKanan.Controls.Add(pnlCheckout);
            pnlKanan.Controls.Add(lblInfoKeranjang);
            pnlKanan.Controls.Add(lblInfoKasir);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(274, 0);
            pnlKanan.Margin = new Padding(3, 4, 3, 4);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(1189, 960);
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
            nightControlBox1.Location = new Point(1050, 0);
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
            lblJudul.Location = new Point(46, 43);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(205, 39);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Kasir / POS";
            // 
            // lblPilihBarang
            // 
            lblPilihBarang.AutoSize = true;
            lblPilihBarang.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPilihBarang.ForeColor = Color.FromArgb(75, 85, 99);
            lblPilihBarang.Location = new Point(46, 107);
            lblPilihBarang.Name = "lblPilihBarang";
            lblPilihBarang.Size = new Size(98, 18);
            lblPilihBarang.TabIndex = 3;
            lblPilihBarang.Text = "Cari Produk";
            // 
            // txtCariProduk
            // 
            txtCariProduk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCariProduk.BorderStyle = BorderStyle.FixedSingle;
            txtCariProduk.Font = new Font("Inter", 10F);
            txtCariProduk.Location = new Point(46, 133);
            txtCariProduk.Margin = new Padding(3, 4, 3, 4);
            txtCariProduk.Name = "txtCariProduk";
            txtCariProduk.PlaceholderText = "Cari kode atau nama barang...";
            txtCariProduk.Size = new Size(448, 26);
            txtCariProduk.TabIndex = 4;
            // 
            // btnHapusCari
            // 
            btnHapusCari.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHapusCari.BackColor = Color.White;
            btnHapusCari.Cursor = Cursors.Hand;
            btnHapusCari.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnHapusCari.FlatStyle = FlatStyle.Flat;
            btnHapusCari.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnHapusCari.ForeColor = Color.FromArgb(107, 114, 128);
            btnHapusCari.Location = new Point(494, 131);
            btnHapusCari.Margin = new Padding(3, 4, 3, 4);
            btnHapusCari.Name = "btnHapusCari";
            btnHapusCari.Size = new Size(30, 30);
            btnHapusCari.TabIndex = 5;
            btnHapusCari.Text = "✕";
            btnHapusCari.UseVisualStyleBackColor = false;
            // 
            // lblJumlah
            // 
            lblJumlah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblJumlah.AutoSize = true;
            lblJumlah.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJumlah.ForeColor = Color.FromArgb(75, 85, 99);
            lblJumlah.Location = new Point(530, 107);
            lblJumlah.Name = "lblJumlah";
            lblJumlah.Size = new Size(62, 18);
            lblJumlah.TabIndex = 6;
            lblJumlah.Text = "Jumlah";
            // 
            // nudJumlah
            // 
            nudJumlah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudJumlah.BorderStyle = BorderStyle.FixedSingle;
            nudJumlah.Font = new Font("Inter", 10F);
            nudJumlah.Location = new Point(530, 133);
            nudJumlah.Margin = new Padding(3, 4, 3, 4);
            nudJumlah.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudJumlah.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudJumlah.Name = "nudJumlah";
            nudJumlah.Size = new Size(94, 26);
            nudJumlah.TabIndex = 7;
            nudJumlah.TextAlign = HorizontalAlignment.Center;
            nudJumlah.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnTambahKeranjang
            // 
            btnTambahKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambahKeranjang.BackColor = Color.FromArgb(255, 196, 0);
            btnTambahKeranjang.Cursor = Cursors.Hand;
            btnTambahKeranjang.FlatAppearance.BorderSize = 0;
            btnTambahKeranjang.FlatStyle = FlatStyle.Flat;
            btnTambahKeranjang.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnTambahKeranjang.ForeColor = Color.FromArgb(31, 41, 55);
            btnTambahKeranjang.Location = new Point(635, 128);
            btnTambahKeranjang.Margin = new Padding(3, 4, 3, 4);
            btnTambahKeranjang.Name = "btnTambahKeranjang";
            btnTambahKeranjang.Size = new Size(133, 40);
            btnTambahKeranjang.TabIndex = 8;
            btnTambahKeranjang.Text = "+ Tambah";
            btnTambahKeranjang.UseVisualStyleBackColor = false;
            // 
            // flowKategori
            // 
            flowKategori.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowKategori.AutoScroll = true;
            flowKategori.Location = new Point(46, 184);
            flowKategori.Margin = new Padding(3, 4, 3, 4);
            flowKategori.Name = "flowKategori";
            flowKategori.Size = new Size(722, 53);
            flowKategori.TabIndex = 9;
            flowKategori.WrapContents = false;
            // 
            // flowProduk
            // 
            flowProduk.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowProduk.AutoScroll = true;
            flowProduk.Location = new Point(46, 245);
            flowProduk.Margin = new Padding(3, 4, 3, 4);
            flowProduk.Name = "flowProduk";
            flowProduk.Size = new Size(722, 307);
            flowProduk.TabIndex = 10;
            // 
            // lblHeaderKeranjang
            // 
            lblHeaderKeranjang.AutoSize = true;
            lblHeaderKeranjang.Font = new Font("Inter", 10F, FontStyle.Bold);
            lblHeaderKeranjang.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeaderKeranjang.Location = new Point(46, 565);
            lblHeaderKeranjang.Name = "lblHeaderKeranjang";
            lblHeaderKeranjang.Size = new Size(162, 20);
            lblHeaderKeranjang.TabIndex = 11;
            lblHeaderKeranjang.Text = "Keranjang Belanja";
            // 
            // gridKeranjang
            // 
            gridKeranjang.AllowUserToAddRows = false;
            gridKeranjang.AllowUserToDeleteRows = false;
            gridKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridKeranjang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridKeranjang.BackgroundColor = Color.White;
            gridKeranjang.BorderStyle = BorderStyle.None;
            gridKeranjang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridKeranjang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridKeranjang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridKeranjang.ColumnHeadersHeight = 40;
            gridKeranjang.Columns.AddRange(new DataGridViewColumn[] { colKode, colNama, colHarga, colKurang, colQty, colTambah, colSubtotal, colHapus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Inter", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridKeranjang.DefaultCellStyle = dataGridViewCellStyle2;
            gridKeranjang.EnableHeadersVisualStyles = false;
            gridKeranjang.GridColor = Color.FromArgb(229, 231, 235);
            gridKeranjang.Location = new Point(46, 597);
            gridKeranjang.Margin = new Padding(3, 4, 3, 4);
            gridKeranjang.MultiSelect = false;
            gridKeranjang.Name = "gridKeranjang";
            gridKeranjang.ReadOnly = true;
            gridKeranjang.RowHeadersVisible = false;
            gridKeranjang.RowHeadersWidth = 51;
            gridKeranjang.RowTemplate.Height = 36;
            gridKeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKeranjang.Size = new Size(722, 298);
            gridKeranjang.TabIndex = 12;
            // 
            // colKode
            // 
            colKode.DataPropertyName = "KodeBarang";
            colKode.FillWeight = 70F;
            colKode.HeaderText = "Kode";
            colKode.MinimumWidth = 6;
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.DataPropertyName = "NamaBarang";
            colNama.FillWeight = 170F;
            colNama.HeaderText = "Produk";
            colNama.MinimumWidth = 6;
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.DataPropertyName = "HargaFormat";
            colHarga.FillWeight = 90F;
            colHarga.HeaderText = "Harga";
            colHarga.MinimumWidth = 6;
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colKurang
            // 
            colKurang.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colKurang.DataPropertyName = "Kurang";
            colKurang.HeaderText = "";
            colKurang.MinimumWidth = 6;
            colKurang.Name = "colKurang";
            colKurang.ReadOnly = true;
            colKurang.Resizable = DataGridViewTriState.False;
            colKurang.SortMode = DataGridViewColumnSortMode.NotSortable;
            colKurang.Width = 36;
            // 
            // colQty
            // 
            colQty.DataPropertyName = "Jumlah";
            colQty.FillWeight = 40F;
            colQty.HeaderText = "Qty";
            colQty.MinimumWidth = 6;
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            // 
            // colTambah
            // 
            colTambah.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTambah.DataPropertyName = "Tambah";
            colTambah.HeaderText = "";
            colTambah.MinimumWidth = 6;
            colTambah.Name = "colTambah";
            colTambah.ReadOnly = true;
            colTambah.Resizable = DataGridViewTriState.False;
            colTambah.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTambah.Width = 36;
            // 
            // colSubtotal
            // 
            colSubtotal.DataPropertyName = "SubtotalFormat";
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.MinimumWidth = 6;
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            // 
            // colHapus
            // 
            colHapus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colHapus.DataPropertyName = "Hapus";
            colHapus.HeaderText = "";
            colHapus.MinimumWidth = 6;
            colHapus.Name = "colHapus";
            colHapus.ReadOnly = true;
            colHapus.Resizable = DataGridViewTriState.False;
            colHapus.SortMode = DataGridViewColumnSortMode.NotSortable;
            colHapus.Width = 36;
            // 
            // pnlCheckout
            // 
            pnlCheckout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlCheckout.BackColor = Color.White;
            pnlCheckout.Controls.Add(lblTotalLabel);
            pnlCheckout.Controls.Add(lblTotalNilai);
            pnlCheckout.Controls.Add(lblBayarLabel);
            pnlCheckout.Controls.Add(btnUangPas);
            pnlCheckout.Controls.Add(nudBayar);
            pnlCheckout.Controls.Add(lblKembalianLabel);
            pnlCheckout.Controls.Add(lblKembalianNilai);
            pnlCheckout.Controls.Add(btnProsesBayar);
            pnlCheckout.Controls.Add(btnBatalKeranjang);
            pnlCheckout.Controls.Add(pnlGaris);
            pnlCheckout.Controls.Add(btnUang100);
            pnlCheckout.Controls.Add(btnUang50);
            pnlCheckout.Controls.Add(lblPintasanJudul);
            pnlCheckout.Controls.Add(lblPintasanTombol1);
            pnlCheckout.Controls.Add(lblPintasanKet1);
            pnlCheckout.Controls.Add(lblPintasanTombol2);
            pnlCheckout.Controls.Add(lblPintasanKet2);
            pnlCheckout.Controls.Add(lblPintasanTombol3);
            pnlCheckout.Controls.Add(lblPintasanKet3);
            pnlCheckout.Controls.Add(lblPintasanTombol4);
            pnlCheckout.Controls.Add(lblPintasanKet4);
            pnlCheckout.Controls.Add(lblPintasanTombol5);
            pnlCheckout.Controls.Add(lblPintasanKet5);
            pnlCheckout.Controls.Add(btnUang10);
            pnlCheckout.Controls.Add(btnUang20);
            pnlCheckout.Controls.Add(btnNolkanBayar);
            pnlCheckout.Location = new Point(796, 128);
            pnlCheckout.Margin = new Padding(3, 4, 3, 4);
            pnlCheckout.Name = "pnlCheckout";
            pnlCheckout.Size = new Size(347, 767);
            pnlCheckout.TabIndex = 10;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Inter", 9F);
            lblTotalLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalLabel.Location = new Point(27, 32);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(93, 18);
            lblTotalLabel.TabIndex = 1;
            lblTotalLabel.Text = "Total Belanja";
            // 
            // lblTotalNilai
            // 
            lblTotalNilai.AutoSize = true;
            lblTotalNilai.Font = new Font("Inter", 28F, FontStyle.Bold);
            lblTotalNilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblTotalNilai.Location = new Point(27, 59);
            lblTotalNilai.Name = "lblTotalNilai";
            lblTotalNilai.Size = new Size(125, 54);
            lblTotalNilai.TabIndex = 2;
            lblTotalNilai.Text = "Rp 0";
            // 
            // lblBayarLabel
            // 
            lblBayarLabel.AutoSize = true;
            lblBayarLabel.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblBayarLabel.ForeColor = Color.FromArgb(75, 85, 99);
            lblBayarLabel.Location = new Point(27, 171);
            lblBayarLabel.Name = "lblBayarLabel";
            lblBayarLabel.Size = new Size(115, 18);
            lblBayarLabel.TabIndex = 3;
            lblBayarLabel.Text = "Uang Diterima";
            // 
            // btnUangPas
            // 
            btnUangPas.BackColor = Color.FromArgb(243, 244, 246);
            btnUangPas.Cursor = Cursors.Hand;
            btnUangPas.FlatAppearance.BorderSize = 0;
            btnUangPas.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUangPas.FlatStyle = FlatStyle.Flat;
            btnUangPas.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUangPas.ForeColor = Color.FromArgb(31, 41, 55);
            btnUangPas.Location = new Point(27, 256);
            btnUangPas.Margin = new Padding(3, 4, 3, 4);
            btnUangPas.Name = "btnUangPas";
            btnUangPas.Size = new Size(91, 37);
            btnUangPas.TabIndex = 12;
            btnUangPas.Text = "Uang Pas";
            btnUangPas.UseVisualStyleBackColor = false;
            // 
            // nudBayar
            // 
            nudBayar.Font = new Font("Inter", 14F, FontStyle.Bold);
            nudBayar.Location = new Point(27, 203);
            nudBayar.Margin = new Padding(3, 4, 3, 4);
            nudBayar.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudBayar.Name = "nudBayar";
            nudBayar.Size = new Size(293, 34);
            nudBayar.TabIndex = 4;
            nudBayar.TextAlign = HorizontalAlignment.Right;
            nudBayar.ThousandsSeparator = true;
            // 
            // lblKembalianLabel
            // 
            lblKembalianLabel.AutoSize = true;
            lblKembalianLabel.Font = new Font("Inter", 9F);
            lblKembalianLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblKembalianLabel.Location = new Point(27, 352);
            lblKembalianLabel.Name = "lblKembalianLabel";
            lblKembalianLabel.Size = new Size(77, 18);
            lblKembalianLabel.TabIndex = 5;
            lblKembalianLabel.Text = "Kembalian";
            // 
            // lblKembalianNilai
            // 
            lblKembalianNilai.AutoSize = true;
            lblKembalianNilai.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblKembalianNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblKembalianNilai.Location = new Point(27, 376);
            lblKembalianNilai.Name = "lblKembalianNilai";
            lblKembalianNilai.Size = new Size(93, 39);
            lblKembalianNilai.TabIndex = 6;
            lblKembalianNilai.Text = "Rp 0";
            // 
            // btnProsesBayar
            // 
            btnProsesBayar.BackColor = Color.FromArgb(255, 196, 0);
            btnProsesBayar.Cursor = Cursors.Hand;
            btnProsesBayar.FlatAppearance.BorderSize = 0;
            btnProsesBayar.FlatStyle = FlatStyle.Flat;
            btnProsesBayar.Font = new Font("Inter", 12F, FontStyle.Bold);
            btnProsesBayar.ForeColor = Color.FromArgb(31, 41, 55);
            btnProsesBayar.Location = new Point(27, 597);
            btnProsesBayar.Margin = new Padding(3, 4, 3, 4);
            btnProsesBayar.Name = "btnProsesBayar";
            btnProsesBayar.Size = new Size(293, 64);
            btnProsesBayar.TabIndex = 7;
            btnProsesBayar.Text = "Bayar";
            btnProsesBayar.UseVisualStyleBackColor = false;
            // 
            // btnBatalKeranjang
            // 
            btnBatalKeranjang.BackColor = Color.White;
            btnBatalKeranjang.Cursor = Cursors.Hand;
            btnBatalKeranjang.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatalKeranjang.FlatStyle = FlatStyle.Flat;
            btnBatalKeranjang.Font = new Font("Inter", 10F);
            btnBatalKeranjang.ForeColor = Color.FromArgb(107, 114, 128);
            btnBatalKeranjang.Location = new Point(27, 672);
            btnBatalKeranjang.Margin = new Padding(3, 4, 3, 4);
            btnBatalKeranjang.Name = "btnBatalKeranjang";
            btnBatalKeranjang.Size = new Size(293, 53);
            btnBatalKeranjang.TabIndex = 8;
            btnBatalKeranjang.Text = "Kosongkan Keranjang";
            btnBatalKeranjang.UseVisualStyleBackColor = false;
            // 
            // pnlGaris
            // 
            pnlGaris.BackColor = Color.FromArgb(229, 231, 235);
            pnlGaris.Location = new Point(27, 139);
            pnlGaris.Margin = new Padding(3, 4, 3, 4);
            pnlGaris.Name = "pnlGaris";
            pnlGaris.Size = new Size(293, 1);
            pnlGaris.TabIndex = 0;
            // 
            // btnUang100
            // 
            btnUang100.BackColor = Color.FromArgb(243, 244, 246);
            btnUang100.Cursor = Cursors.Hand;
            btnUang100.FlatAppearance.BorderSize = 0;
            btnUang100.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang100.FlatStyle = FlatStyle.Flat;
            btnUang100.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang100.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang100.Location = new Point(128, 299);
            btnUang100.Margin = new Padding(3, 4, 3, 4);
            btnUang100.Name = "btnUang100";
            btnUang100.Size = new Size(91, 37);
            btnUang100.TabIndex = 13;
            btnUang100.Text = "+100.000";
            btnUang100.UseVisualStyleBackColor = false;
            // 
            // btnUang50
            // 
            btnUang50.BackColor = Color.FromArgb(243, 244, 246);
            btnUang50.Cursor = Cursors.Hand;
            btnUang50.FlatAppearance.BorderSize = 0;
            btnUang50.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang50.FlatStyle = FlatStyle.Flat;
            btnUang50.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang50.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang50.Location = new Point(27, 299);
            btnUang50.Margin = new Padding(3, 4, 3, 4);
            btnUang50.Name = "btnUang50";
            btnUang50.Size = new Size(91, 37);
            btnUang50.TabIndex = 13;
            btnUang50.Text = "+50.000";
            btnUang50.UseVisualStyleBackColor = false;
            // 
            // lblPintasanJudul
            // 
            lblPintasanJudul.AutoSize = true;
            lblPintasanJudul.BackColor = Color.Transparent;
            lblPintasanJudul.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanJudul.ForeColor = Color.FromArgb(75, 85, 99);
            lblPintasanJudul.Location = new Point(27, 432);
            lblPintasanJudul.Name = "lblPintasanJudul";
            lblPintasanJudul.Size = new Size(149, 18);
            lblPintasanJudul.TabIndex = 0;
            lblPintasanJudul.Text = "Pintasan Keyboard";
            // 
            // lblPintasanTombol1
            // 
            lblPintasanTombol1.AutoSize = true;
            lblPintasanTombol1.BackColor = Color.Transparent;
            lblPintasanTombol1.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol1.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol1.Location = new Point(27, 459);
            lblPintasanTombol1.Name = "lblPintasanTombol1";
            lblPintasanTombol1.Size = new Size(48, 18);
            lblPintasanTombol1.TabIndex = 0;
            lblPintasanTombol1.Text = "Enter";
            // 
            // lblPintasanKet1
            // 
            lblPintasanKet1.AutoSize = true;
            lblPintasanKet1.BackColor = Color.Transparent;
            lblPintasanKet1.Font = new Font("Inter", 9F);
            lblPintasanKet1.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet1.Location = new Point(110, 459);
            lblPintasanKet1.Name = "lblPintasanKet1";
            lblPintasanKet1.Size = new Size(148, 18);
            lblPintasanKet1.TabIndex = 0;
            lblPintasanKet1.Text = "Tambah / lanjut bayar";
            // 
            // lblPintasanTombol2
            // 
            lblPintasanTombol2.AutoSize = true;
            lblPintasanTombol2.BackColor = Color.Transparent;
            lblPintasanTombol2.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol2.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol2.Location = new Point(27, 483);
            lblPintasanTombol2.Name = "lblPintasanTombol2";
            lblPintasanTombol2.Size = new Size(34, 18);
            lblPintasanTombol2.TabIndex = 0;
            lblPintasanTombol2.Text = "3  *";
            // 
            // lblPintasanKet2
            // 
            lblPintasanKet2.AutoSize = true;
            lblPintasanKet2.BackColor = Color.Transparent;
            lblPintasanKet2.Font = new Font("Inter", 9F);
            lblPintasanKet2.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet2.Location = new Point(110, 483);
            lblPintasanKet2.Name = "lblPintasanKet2";
            lblPintasanKet2.Size = new Size(139, 18);
            lblPintasanKet2.TabIndex = 0;
            lblPintasanKet2.Text = "Atur jumlah, lalu cari";
            // 
            // lblPintasanTombol3
            // 
            lblPintasanTombol3.AutoSize = true;
            lblPintasanTombol3.BackColor = Color.Transparent;
            lblPintasanTombol3.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol3.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol3.Location = new Point(27, 507);
            lblPintasanTombol3.Name = "lblPintasanTombol3";
            lblPintasanTombol3.Size = new Size(38, 18);
            lblPintasanTombol3.TabIndex = 0;
            lblPintasanTombol3.Text = "+  −";
            // 
            // lblPintasanKet3
            // 
            lblPintasanKet3.AutoSize = true;
            lblPintasanKet3.BackColor = Color.Transparent;
            lblPintasanKet3.Font = new Font("Inter", 9F);
            lblPintasanKet3.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet3.Location = new Point(110, 507);
            lblPintasanKet3.Name = "lblPintasanKet3";
            lblPintasanKet3.Size = new Size(148, 18);
            lblPintasanKet3.TabIndex = 0;
            lblPintasanKet3.Text = "Ubah qty baris terpilih";
            // 
            // lblPintasanTombol4
            // 
            lblPintasanTombol4.AutoSize = true;
            lblPintasanTombol4.BackColor = Color.Transparent;
            lblPintasanTombol4.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol4.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol4.Location = new Point(27, 531);
            lblPintasanTombol4.Name = "lblPintasanTombol4";
            lblPintasanTombol4.Size = new Size(36, 18);
            lblPintasanTombol4.TabIndex = 0;
            lblPintasanTombol4.Text = "↑  ↓";
            // 
            // lblPintasanKet4
            // 
            lblPintasanKet4.AutoSize = true;
            lblPintasanKet4.BackColor = Color.Transparent;
            lblPintasanKet4.Font = new Font("Inter", 9F);
            lblPintasanKet4.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet4.Location = new Point(110, 531);
            lblPintasanKet4.Name = "lblPintasanKet4";
            lblPintasanKet4.Size = new Size(139, 18);
            lblPintasanKet4.TabIndex = 0;
            lblPintasanKet4.Text = "Pilih baris keranjang";
            // 
            // lblPintasanTombol5
            // 
            lblPintasanTombol5.AutoSize = true;
            lblPintasanTombol5.BackColor = Color.Transparent;
            lblPintasanTombol5.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol5.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol5.Location = new Point(27, 555);
            lblPintasanTombol5.Name = "lblPintasanTombol5";
            lblPintasanTombol5.Size = new Size(33, 18);
            lblPintasanTombol5.TabIndex = 0;
            lblPintasanTombol5.Text = "Del";
            // 
            // lblPintasanKet5
            // 
            lblPintasanKet5.AutoSize = true;
            lblPintasanKet5.BackColor = Color.Transparent;
            lblPintasanKet5.Font = new Font("Inter", 9F);
            lblPintasanKet5.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet5.Location = new Point(110, 555);
            lblPintasanKet5.Name = "lblPintasanKet5";
            lblPintasanKet5.Size = new Size(133, 18);
            lblPintasanKet5.TabIndex = 0;
            lblPintasanKet5.Text = "Hapus baris terpilih";
            // 
            // btnUang10
            // 
            btnUang10.BackColor = Color.FromArgb(243, 244, 246);
            btnUang10.Cursor = Cursors.Hand;
            btnUang10.FlatAppearance.BorderSize = 0;
            btnUang10.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang10.FlatStyle = FlatStyle.Flat;
            btnUang10.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang10.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang10.Location = new Point(128, 256);
            btnUang10.Margin = new Padding(3, 4, 3, 4);
            btnUang10.Name = "btnUang10";
            btnUang10.Size = new Size(91, 37);
            btnUang10.TabIndex = 14;
            btnUang10.Text = "+10.000";
            btnUang10.UseVisualStyleBackColor = false;
            // 
            // btnUang20
            // 
            btnUang20.BackColor = Color.FromArgb(243, 244, 246);
            btnUang20.Cursor = Cursors.Hand;
            btnUang20.FlatAppearance.BorderSize = 0;
            btnUang20.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang20.FlatStyle = FlatStyle.Flat;
            btnUang20.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang20.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang20.Location = new Point(229, 256);
            btnUang20.Margin = new Padding(3, 4, 3, 4);
            btnUang20.Name = "btnUang20";
            btnUang20.Size = new Size(91, 37);
            btnUang20.TabIndex = 15;
            btnUang20.Text = "+20.000";
            btnUang20.UseVisualStyleBackColor = false;
            // 
            // btnNolkanBayar
            // 
            btnNolkanBayar.BackColor = Color.FromArgb(243, 244, 246);
            btnNolkanBayar.Cursor = Cursors.Hand;
            btnNolkanBayar.FlatAppearance.BorderSize = 0;
            btnNolkanBayar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnNolkanBayar.FlatStyle = FlatStyle.Flat;
            btnNolkanBayar.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnNolkanBayar.ForeColor = Color.FromArgb(220, 38, 38);
            btnNolkanBayar.Location = new Point(229, 299);
            btnNolkanBayar.Margin = new Padding(3, 4, 3, 4);
            btnNolkanBayar.Name = "btnNolkanBayar";
            btnNolkanBayar.Size = new Size(91, 37);
            btnNolkanBayar.TabIndex = 16;
            btnNolkanBayar.Text = "Hapus";
            btnNolkanBayar.UseVisualStyleBackColor = false;
            // 
            // lblInfoKeranjang
            // 
            lblInfoKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInfoKeranjang.AutoSize = true;
            lblInfoKeranjang.BackColor = Color.Transparent;
            lblInfoKeranjang.Font = new Font("Inter", 9F);
            lblInfoKeranjang.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfoKeranjang.Location = new Point(650, 568);
            lblInfoKeranjang.Name = "lblInfoKeranjang";
            lblInfoKeranjang.Size = new Size(118, 18);
            lblInfoKeranjang.TabIndex = 0;
            lblInfoKeranjang.Text = "0 produk · 0 item";
            // 
            // lblInfoKasir
            // 
            lblInfoKasir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInfoKasir.BackColor = Color.Transparent;
            lblInfoKasir.Font = new Font("Inter", 9F);
            lblInfoKasir.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfoKasir.Location = new Point(686, 53);
            lblInfoKasir.Name = "lblInfoKasir";
            lblInfoKasir.Size = new Size(457, 32);
            lblInfoKasir.TabIndex = 0;
            lblInfoKasir.Text = "Kasir";
            lblInfoKasir.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormKasir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 960);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1257, 867);
            Name = "FormKasir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kasir / POS";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudJumlah).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridKeranjang).EndInit();
            pnlCheckout.ResumeLayout(false);
            pnlCheckout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBayar).EndInit();
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
        private Button btnNolkanBayar;
        private Button btnUang20;
        private Button btnUang10;
        private Label lblPintasanKet5;
        private Label lblPintasanTombol5;
        private Label lblPintasanKet4;
        private Label lblPintasanTombol4;
        private Label lblPintasanKet3;
        private Label lblPintasanTombol3;
        private Label lblPintasanKet2;
        private Label lblPintasanTombol2;
        private Label lblPintasanKet1;
        private Label lblPintasanTombol1;
        private Label lblPintasanJudul;
        private Button btnUang50;
        private Button btnUang100;
        private Panel pnlGaris;
        private Label lblInfoKasir;
        private Label lblInfoKeranjang;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblJudul;
        private Label lblPilihBarang;
        private TextBox txtCariProduk;
        private Button btnHapusCari;
        private FlowLayoutPanel flowKategori;
        private FlowLayoutPanel flowProduk;
        private Label lblHeaderKeranjang;
        private Label lblJumlah;
        private NumericUpDown nudJumlah;
        private Button btnTambahKeranjang;
        private DataGridView gridKeranjang;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colSubtotal;
        private DataGridViewTextBoxColumn colKurang;
        private DataGridViewTextBoxColumn colTambah;
        private DataGridViewTextBoxColumn colHapus;
        private Panel pnlCheckout;
        private Label lblTotalLabel;
        private Label lblTotalNilai;
        private Label lblBayarLabel;
        private NumericUpDown nudBayar;
        private Label lblKembalianLabel;
        private Label lblKembalianNilai;
        private Button btnProsesBayar;
        private Button btnBatalKeranjang;
        private Button btnUangPas;
    }
}
