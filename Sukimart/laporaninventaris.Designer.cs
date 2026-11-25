namespace Sukimart
{
    partial class FormLaporanInventaris
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

        #region Windows Form Designer generated code

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
            btnLogAktivitas = new Button();
            btnPengguna = new Button();
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
            btnSubJumlahStok = new Button();
            btnSubRiwayatStok = new Button();
            pnlCard1 = new Panel();
            lblCard1Judul = new Label();
            lblCard1Nilai = new Label();
            pnlCard2 = new Panel();
            lblCard2Judul = new Label();
            lblCard2Nilai = new Label();
            pnlCard3 = new Panel();
            lblCard3Judul = new Label();
            lblCard3Nilai = new Label();
            pnlCard4 = new Panel();
            lblCard4Judul = new Label();
            lblCard4Nilai = new Label();
            btnSimpanJson = new Button();
            pnlSubJumlahStok = new Panel();
            txtCariJumlah = new TextBox();
            cmbFilterStatus = new ComboBox();
            gridJumlahStok = new DataGridView();
            colJumlahKode = new DataGridViewTextBoxColumn();
            colJumlahNama = new DataGridViewTextBoxColumn();
            colJumlahStok = new DataGridViewTextBoxColumn();
            colJumlahMin = new DataGridViewTextBoxColumn();
            colJumlahStatus = new DataGridViewTextBoxColumn();
            pnlSubRiwayatStok = new Panel();
            dtpMulai = new DateTimePicker();
            lblSampai = new Label();
            dtpSelesai = new DateTimePicker();
            btnTerapkanRiwayat = new Button();
            txtCariRiwayat = new TextBox();
            cmbJenisPergerakan = new ComboBox();
            gridRiwayatStok = new DataGridView();
            colRiwayatTanggal = new DataGridViewTextBoxColumn();
            colRiwayatKode = new DataGridViewTextBoxColumn();
            colRiwayatNama = new DataGridViewTextBoxColumn();
            colRiwayatJenis = new DataGridViewTextBoxColumn();
            colRiwayatJumlah = new DataGridViewTextBoxColumn();
            colRiwayatKet = new DataGridViewTextBoxColumn();
            colRiwayatOleh = new DataGridViewTextBoxColumn();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlSubJumlahStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridJumlahStok).BeginInit();
            pnlSubRiwayatStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRiwayatStok).BeginInit();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.White;
            pnlKiri.Controls.Add(btnKeluar);
            pnlKiri.Controls.Add(btnGantiSandi);
            pnlKiri.Controls.Add(btnLogAktivitas);
            pnlKiri.Controls.Add(btnPengguna);
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
            btnKeluar.Cursor = Cursors.Hand;
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
            btnKeluar.TabIndex = 15;
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
            // btnLaporanInventaris
            // 
            btnLaporanInventaris.BackColor = Color.FromArgb(255, 196, 0);
            btnLaporanInventaris.Cursor = Cursors.Hand;
            btnLaporanInventaris.FlatAppearance.BorderSize = 0;
            btnLaporanInventaris.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLaporanInventaris.FlatStyle = FlatStyle.Flat;
            btnLaporanInventaris.Font = new Font("Inter", 10F, FontStyle.Bold);
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
            btnKasir.BackColor = Color.White;
            btnKasir.Cursor = Cursors.Hand;
            btnKasir.FlatAppearance.BorderSize = 0;
            btnKasir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKasir.FlatStyle = FlatStyle.Flat;
            btnKasir.Font = new Font("Inter", 10F);
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
            pnlKanan.Controls.Add(btnSubJumlahStok);
            pnlKanan.Controls.Add(btnSubRiwayatStok);
            pnlKanan.Controls.Add(pnlCard1);
            pnlKanan.Controls.Add(pnlCard2);
            pnlKanan.Controls.Add(pnlCard3);
            pnlKanan.Controls.Add(pnlCard4);
            pnlKanan.Controls.Add(btnSimpanJson);
            pnlKanan.Controls.Add(pnlSubJumlahStok);
            pnlKanan.Controls.Add(pnlSubRiwayatStok);
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
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
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
            lblJudul.Location = new Point(40, 24);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(260, 33);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Laporan Inventaris";
            // 
            // btnSubJumlahStok
            // 
            btnSubJumlahStok.BackColor = Color.FromArgb(255, 196, 0);
            btnSubJumlahStok.Cursor = Cursors.Hand;
            btnSubJumlahStok.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSubJumlahStok.FlatAppearance.BorderSize = 0;
            btnSubJumlahStok.FlatStyle = FlatStyle.Flat;
            btnSubJumlahStok.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnSubJumlahStok.ForeColor = Color.FromArgb(31, 41, 55);
            btnSubJumlahStok.Location = new Point(40, 68);
            btnSubJumlahStok.Name = "btnSubJumlahStok";
            btnSubJumlahStok.Size = new Size(130, 32);
            btnSubJumlahStok.TabIndex = 2;
            btnSubJumlahStok.Text = "Jumlah Stok";
            btnSubJumlahStok.UseVisualStyleBackColor = false;
            // 
            // btnSubRiwayatStok
            // 
            btnSubRiwayatStok.BackColor = Color.White;
            btnSubRiwayatStok.Cursor = Cursors.Hand;
            btnSubRiwayatStok.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSubRiwayatStok.FlatStyle = FlatStyle.Flat;
            btnSubRiwayatStok.Font = new Font("Inter", 9.5F);
            btnSubRiwayatStok.ForeColor = Color.FromArgb(75, 85, 99);
            btnSubRiwayatStok.Location = new Point(178, 68);
            btnSubRiwayatStok.Name = "btnSubRiwayatStok";
            btnSubRiwayatStok.Size = new Size(130, 32);
            btnSubRiwayatStok.TabIndex = 3;
            btnSubRiwayatStok.Text = "Riwayat Stok";
            btnSubRiwayatStok.UseVisualStyleBackColor = false;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(lblCard1Judul);
            pnlCard1.Controls.Add(lblCard1Nilai);
            pnlCard1.Location = new Point(40, 112);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Padding = new Padding(16, 12, 16, 12);
            pnlCard1.Size = new Size(250, 104);
            pnlCard1.TabIndex = 4;
            // 
            // lblCard1Judul
            // 
            lblCard1Judul.AutoSize = true;
            lblCard1Judul.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblCard1Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard1Judul.Location = new Point(14, 12);
            lblCard1Judul.Name = "lblCard1Judul";
            lblCard1Judul.Size = new Size(149, 19);
            lblCard1Judul.TabIndex = 0;
            lblCard1Judul.Text = "TOTAL JENIS BARANG";
            // 
            // lblCard1Nilai
            // 
            lblCard1Nilai.AutoSize = true;
            lblCard1Nilai.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblCard1Nilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblCard1Nilai.Location = new Point(14, 46);
            lblCard1Nilai.Name = "lblCard1Nilai";
            lblCard1Nilai.Size = new Size(32, 33);
            lblCard1Nilai.TabIndex = 1;
            lblCard1Nilai.Text = "0";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(lblCard2Judul);
            pnlCard2.Controls.Add(lblCard2Nilai);
            pnlCard2.Location = new Point(310, 112);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Padding = new Padding(16, 12, 16, 12);
            pnlCard2.Size = new Size(250, 104);
            pnlCard2.TabIndex = 5;
            // 
            // lblCard2Judul
            // 
            lblCard2Judul.AutoSize = true;
            lblCard2Judul.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblCard2Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard2Judul.Location = new Point(14, 12);
            lblCard2Judul.Name = "lblCard2Judul";
            lblCard2Judul.Size = new Size(95, 19);
            lblCard2Judul.TabIndex = 0;
            lblCard2Judul.Text = "STOK AMAN";
            // 
            // lblCard2Nilai
            // 
            lblCard2Nilai.AutoSize = true;
            lblCard2Nilai.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblCard2Nilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblCard2Nilai.Location = new Point(14, 46);
            lblCard2Nilai.Name = "lblCard2Nilai";
            lblCard2Nilai.Size = new Size(32, 33);
            lblCard2Nilai.TabIndex = 1;
            lblCard2Nilai.Text = "0";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(lblCard3Judul);
            pnlCard3.Controls.Add(lblCard3Nilai);
            pnlCard3.Location = new Point(580, 112);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Padding = new Padding(16, 12, 16, 12);
            pnlCard3.Size = new Size(250, 104);
            pnlCard3.TabIndex = 6;
            // 
            // lblCard3Judul
            // 
            lblCard3Judul.AutoSize = true;
            lblCard3Judul.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblCard3Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard3Judul.Location = new Point(14, 12);
            lblCard3Judul.Name = "lblCard3Judul";
            lblCard3Judul.Size = new Size(116, 19);
            lblCard3Judul.TabIndex = 0;
            lblCard3Judul.Text = "STOK MINIMUM";
            // 
            // lblCard3Nilai
            // 
            lblCard3Nilai.AutoSize = true;
            lblCard3Nilai.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblCard3Nilai.ForeColor = Color.FromArgb(217, 119, 6);
            lblCard3Nilai.Location = new Point(14, 46);
            lblCard3Nilai.Name = "lblCard3Nilai";
            lblCard3Nilai.Size = new Size(32, 33);
            lblCard3Nilai.TabIndex = 1;
            lblCard3Nilai.Text = "0";
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(lblCard4Judul);
            pnlCard4.Controls.Add(lblCard4Nilai);
            pnlCard4.Location = new Point(850, 112);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Padding = new Padding(16, 12, 16, 12);
            pnlCard4.Size = new Size(250, 104);
            pnlCard4.TabIndex = 7;
            // 
            // lblCard4Judul
            // 
            lblCard4Judul.AutoSize = true;
            lblCard4Judul.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblCard4Judul.ForeColor = Color.FromArgb(107, 114, 128);
            lblCard4Judul.Location = new Point(14, 12);
            lblCard4Judul.Name = "lblCard4Judul";
            lblCard4Judul.Size = new Size(95, 19);
            lblCard4Judul.TabIndex = 0;
            lblCard4Judul.Text = "STOK HABIS";
            // 
            // lblCard4Nilai
            // 
            lblCard4Nilai.AutoSize = true;
            lblCard4Nilai.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblCard4Nilai.ForeColor = Color.FromArgb(220, 38, 38);
            lblCard4Nilai.Location = new Point(14, 46);
            lblCard4Nilai.Name = "lblCard4Nilai";
            lblCard4Nilai.Size = new Size(32, 33);
            lblCard4Nilai.TabIndex = 1;
            lblCard4Nilai.Text = "0";
            // 
            // pnlSubJumlahStok
            // 
            pnlSubJumlahStok.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSubJumlahStok.BackColor = Color.FromArgb(247, 247, 245);
            pnlSubJumlahStok.Controls.Add(txtCariJumlah);
            pnlSubJumlahStok.Controls.Add(cmbFilterStatus);
            pnlSubJumlahStok.Controls.Add(gridJumlahStok);
            pnlSubJumlahStok.Location = new Point(0, 224);
            pnlSubJumlahStok.Name = "pnlSubJumlahStok";
            pnlSubJumlahStok.Size = new Size(1189, 736);
            pnlSubJumlahStok.TabIndex = 8;
            // 
            // txtCariJumlah
            // 
            txtCariJumlah.BorderStyle = BorderStyle.FixedSingle;
            txtCariJumlah.Font = new Font("Inter", 9.5F);
            txtCariJumlah.Location = new Point(40, 8);
            txtCariJumlah.Name = "txtCariJumlah";
            txtCariJumlah.PlaceholderText = "Cari kode atau nama barang...";
            txtCariJumlah.Size = new Size(300, 27);
            txtCariJumlah.TabIndex = 0;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Font = new Font("Inter", 9.5F);
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "Semua Status", "Aman", "Minimum", "Kritis", "Habis" });
            cmbFilterStatus.Location = new Point(352, 8);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(160, 27);
            cmbFilterStatus.TabIndex = 1;
            // 
            // gridJumlahStok
            // 
            gridJumlahStok.AllowUserToAddRows = false;
            gridJumlahStok.AllowUserToDeleteRows = false;
            gridJumlahStok.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridJumlahStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridJumlahStok.BackgroundColor = Color.White;
            gridJumlahStok.BorderStyle = BorderStyle.None;
            gridJumlahStok.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridJumlahStok.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridJumlahStok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridJumlahStok.ColumnHeadersHeight = 40;
            gridJumlahStok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridJumlahStok.Columns.AddRange(new DataGridViewColumn[] { colJumlahKode, colJumlahNama, colJumlahStok, colJumlahMin, colJumlahStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Inter", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(254, 243, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridJumlahStok.DefaultCellStyle = dataGridViewCellStyle2;
            gridJumlahStok.EnableHeadersVisualStyles = false;
            gridJumlahStok.GridColor = Color.FromArgb(243, 244, 246);
            gridJumlahStok.Location = new Point(40, 56);
            gridJumlahStok.MultiSelect = false;
            gridJumlahStok.Name = "gridJumlahStok";
            gridJumlahStok.ReadOnly = true;
            gridJumlahStok.RowHeadersVisible = false;
            gridJumlahStok.RowHeadersWidth = 51;
            gridJumlahStok.RowTemplate.Height = 40;
            gridJumlahStok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridJumlahStok.Size = new Size(1109, 652);
            gridJumlahStok.TabIndex = 2;
            // 
            // colJumlahKode
            // 
            colJumlahKode.FillWeight = 18F;
            colJumlahKode.HeaderText = "Kode Barang";
            colJumlahKode.MinimumWidth = 80;
            colJumlahKode.Name = "colJumlahKode";
            colJumlahKode.ReadOnly = true;
            // 
            // colJumlahNama
            // 
            colJumlahNama.FillWeight = 37F;
            colJumlahNama.HeaderText = "Nama Barang";
            colJumlahNama.MinimumWidth = 140;
            colJumlahNama.Name = "colJumlahNama";
            colJumlahNama.ReadOnly = true;
            // 
            // colJumlahStok
            // 
            colJumlahStok.FillWeight = 15F;
            colJumlahStok.HeaderText = "Stok Saat Ini";
            colJumlahStok.MinimumWidth = 70;
            colJumlahStok.Name = "colJumlahStok";
            colJumlahStok.ReadOnly = true;
            // 
            // colJumlahMin
            // 
            colJumlahMin.FillWeight = 15F;
            colJumlahMin.HeaderText = "Stok Minimum";
            colJumlahMin.MinimumWidth = 70;
            colJumlahMin.Name = "colJumlahMin";
            colJumlahMin.ReadOnly = true;
            // 
            // colJumlahStatus
            // 
            colJumlahStatus.FillWeight = 15F;
            colJumlahStatus.HeaderText = "Status";
            colJumlahStatus.MinimumWidth = 70;
            colJumlahStatus.Name = "colJumlahStatus";
            colJumlahStatus.ReadOnly = true;
            // 
            // pnlSubRiwayatStok
            // 
            pnlSubRiwayatStok.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSubRiwayatStok.BackColor = Color.FromArgb(247, 247, 245);
            pnlSubRiwayatStok.Controls.Add(dtpMulai);
            pnlSubRiwayatStok.Controls.Add(lblSampai);
            pnlSubRiwayatStok.Controls.Add(dtpSelesai);
            pnlSubRiwayatStok.Controls.Add(btnTerapkanRiwayat);
            pnlSubRiwayatStok.Controls.Add(txtCariRiwayat);
            pnlSubRiwayatStok.Controls.Add(cmbJenisPergerakan);
            pnlSubRiwayatStok.Controls.Add(gridRiwayatStok);
            pnlSubRiwayatStok.Location = new Point(0, 224);
            pnlSubRiwayatStok.Name = "pnlSubRiwayatStok";
            pnlSubRiwayatStok.Size = new Size(1189, 736);
            pnlSubRiwayatStok.TabIndex = 9;
            pnlSubRiwayatStok.Visible = false;
            // 
            // dtpMulai
            // 
            dtpMulai.CustomFormat = "dd/MM/yyyy";
            dtpMulai.Font = new Font("Inter", 9.5F);
            dtpMulai.Format = DateTimePickerFormat.Custom;
            dtpMulai.Location = new Point(40, 10);
            dtpMulai.Name = "dtpMulai";
            dtpMulai.Size = new Size(130, 27);
            dtpMulai.TabIndex = 0;
            // 
            // lblSampai
            // 
            lblSampai.AutoSize = true;
            lblSampai.Font = new Font("Inter", 9F);
            lblSampai.ForeColor = Color.FromArgb(107, 114, 128);
            lblSampai.Location = new Point(178, 15);
            lblSampai.Name = "lblSampai";
            lblSampai.Size = new Size(28, 19);
            lblSampai.TabIndex = 1;
            lblSampai.Text = "s/d";
            // 
            // dtpSelesai
            // 
            dtpSelesai.CustomFormat = "dd/MM/yyyy";
            dtpSelesai.Font = new Font("Inter", 9.5F);
            dtpSelesai.Format = DateTimePickerFormat.Custom;
            dtpSelesai.Location = new Point(212, 10);
            dtpSelesai.Name = "dtpSelesai";
            dtpSelesai.Size = new Size(130, 27);
            dtpSelesai.TabIndex = 2;
            // 
            // btnTerapkanRiwayat
            // 
            btnTerapkanRiwayat.BackColor = Color.White;
            btnTerapkanRiwayat.Cursor = Cursors.Hand;
            btnTerapkanRiwayat.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTerapkanRiwayat.FlatStyle = FlatStyle.Flat;
            btnTerapkanRiwayat.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnTerapkanRiwayat.ForeColor = Color.FromArgb(55, 65, 81);
            btnTerapkanRiwayat.Location = new Point(352, 8);
            btnTerapkanRiwayat.Name = "btnTerapkanRiwayat";
            btnTerapkanRiwayat.Size = new Size(92, 32);
            btnTerapkanRiwayat.TabIndex = 3;
            btnTerapkanRiwayat.Text = "Terapkan";
            btnTerapkanRiwayat.UseVisualStyleBackColor = false;
            // 
            // txtCariRiwayat
            // 
            txtCariRiwayat.BorderStyle = BorderStyle.FixedSingle;
            txtCariRiwayat.Font = new Font("Inter", 9.5F);
            txtCariRiwayat.Location = new Point(456, 8);
            txtCariRiwayat.Name = "txtCariRiwayat";
            txtCariRiwayat.PlaceholderText = "Cari kode, nama, atau keterangan...";
            txtCariRiwayat.Size = new Size(340, 27);
            txtCariRiwayat.TabIndex = 4;
            // 
            // cmbJenisPergerakan
            // 
            cmbJenisPergerakan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenisPergerakan.Font = new Font("Inter", 9.5F);
            cmbJenisPergerakan.FormattingEnabled = true;
            cmbJenisPergerakan.Items.AddRange(new object[] { "Semua Jenis", "Masuk", "Keluar", "Penjualan", "Penyesuaian Opname" });
            cmbJenisPergerakan.Location = new Point(808, 8);
            cmbJenisPergerakan.Name = "cmbJenisPergerakan";
            cmbJenisPergerakan.Size = new Size(150, 27);
            cmbJenisPergerakan.TabIndex = 5;
            // 
            // btnSimpanJson
            // 
            btnSimpanJson.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSimpanJson.BackColor = Color.White;
            btnSimpanJson.Cursor = Cursors.Hand;
            btnSimpanJson.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSimpanJson.FlatStyle = FlatStyle.Flat;
            btnSimpanJson.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnSimpanJson.ForeColor = Color.FromArgb(55, 65, 81);
            btnSimpanJson.Location = new Point(989, 232);
            btnSimpanJson.Name = "btnSimpanJson";
            btnSimpanJson.Size = new Size(160, 32);
            btnSimpanJson.TabIndex = 17;
            btnSimpanJson.Text = "💾 Simpan JSON";
            btnSimpanJson.UseVisualStyleBackColor = false;
            // 
            // gridRiwayatStok
            // 
            gridRiwayatStok.AllowUserToAddRows = false;
            gridRiwayatStok.AllowUserToDeleteRows = false;
            gridRiwayatStok.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridRiwayatStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRiwayatStok.BackgroundColor = Color.White;
            gridRiwayatStok.BorderStyle = BorderStyle.None;
            gridRiwayatStok.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridRiwayatStok.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridRiwayatStok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridRiwayatStok.ColumnHeadersHeight = 40;
            gridRiwayatStok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridRiwayatStok.Columns.AddRange(new DataGridViewColumn[] { colRiwayatTanggal, colRiwayatKode, colRiwayatNama, colRiwayatJenis, colRiwayatJumlah, colRiwayatKet, colRiwayatOleh });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Inter", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(254, 243, 199);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridRiwayatStok.DefaultCellStyle = dataGridViewCellStyle4;
            gridRiwayatStok.EnableHeadersVisualStyles = false;
            gridRiwayatStok.GridColor = Color.FromArgb(243, 244, 246);
            gridRiwayatStok.Location = new Point(40, 56);
            gridRiwayatStok.MultiSelect = false;
            gridRiwayatStok.Name = "gridRiwayatStok";
            gridRiwayatStok.ReadOnly = true;
            gridRiwayatStok.RowHeadersVisible = false;
            gridRiwayatStok.RowHeadersWidth = 51;
            gridRiwayatStok.RowTemplate.Height = 40;
            gridRiwayatStok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRiwayatStok.Size = new Size(1109, 652);
            gridRiwayatStok.TabIndex = 6;
            // 
            // colRiwayatTanggal
            // 
            colRiwayatTanggal.FillWeight = 16F;
            colRiwayatTanggal.HeaderText = "Tanggal";
            colRiwayatTanggal.MinimumWidth = 90;
            colRiwayatTanggal.Name = "colRiwayatTanggal";
            colRiwayatTanggal.ReadOnly = true;
            // 
            // colRiwayatKode
            // 
            colRiwayatKode.FillWeight = 13F;
            colRiwayatKode.HeaderText = "Kode Barang";
            colRiwayatKode.MinimumWidth = 70;
            colRiwayatKode.Name = "colRiwayatKode";
            colRiwayatKode.ReadOnly = true;
            // 
            // colRiwayatNama
            // 
            colRiwayatNama.FillWeight = 23F;
            colRiwayatNama.HeaderText = "Nama Barang";
            colRiwayatNama.MinimumWidth = 120;
            colRiwayatNama.Name = "colRiwayatNama";
            colRiwayatNama.ReadOnly = true;
            // 
            // colRiwayatJenis
            // 
            colRiwayatJenis.FillWeight = 12F;
            colRiwayatJenis.HeaderText = "Jenis";
            colRiwayatJenis.MinimumWidth = 60;
            colRiwayatJenis.Name = "colRiwayatJenis";
            colRiwayatJenis.ReadOnly = true;
            // 
            // colRiwayatJumlah
            // 
            colRiwayatJumlah.FillWeight = 10F;
            colRiwayatJumlah.HeaderText = "Jumlah";
            colRiwayatJumlah.MinimumWidth = 50;
            colRiwayatJumlah.Name = "colRiwayatJumlah";
            colRiwayatJumlah.ReadOnly = true;
            // 
            // colRiwayatKet
            // 
            colRiwayatKet.FillWeight = 16F;
            colRiwayatKet.HeaderText = "Keterangan";
            colRiwayatKet.MinimumWidth = 80;
            colRiwayatKet.Name = "colRiwayatKet";
            colRiwayatKet.ReadOnly = true;
            // 
            // colRiwayatOleh
            // 
            colRiwayatOleh.FillWeight = 10F;
            colRiwayatOleh.HeaderText = "Oleh";
            colRiwayatOleh.MinimumWidth = 50;
            colRiwayatOleh.Name = "colRiwayatOleh";
            colRiwayatOleh.ReadOnly = true;
            // 
            // FormLaporanInventaris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 960);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLaporanInventaris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Laporan Inventaris - SUKIMART";
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
            pnlSubJumlahStok.ResumeLayout(false);
            pnlSubJumlahStok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridJumlahStok).EndInit();
            pnlSubRiwayatStok.ResumeLayout(false);
            pnlSubRiwayatStok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRiwayatStok).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKiri;
        private Button btnLaporanInventaris;
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
        private Button btnGantiSandi;
        private Button btnLogAktivitas;
        private Panel pnlKanan;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblJudul;
        private Button btnSubJumlahStok;
        private Button btnSubRiwayatStok;
        private Panel pnlCard1;
        private Label lblCard1Judul;
        private Label lblCard1Nilai;
        private Panel pnlCard2;
        private Label lblCard2Judul;
        private Label lblCard2Nilai;
        private Panel pnlCard3;
        private Label lblCard3Judul;
        private Label lblCard3Nilai;
        private Panel pnlCard4;
        private Label lblCard4Judul;
        private Label lblCard4Nilai;
        private Panel pnlSubJumlahStok;
        private Panel pnlSubRiwayatStok;
        private TextBox txtCariJumlah;
        private ComboBox cmbFilterStatus;
        private DataGridView gridJumlahStok;
        private DataGridViewTextBoxColumn colJumlahKode;
        private DataGridViewTextBoxColumn colJumlahNama;
        private DataGridViewTextBoxColumn colJumlahStok;
        private DataGridViewTextBoxColumn colJumlahMin;
        private DataGridViewTextBoxColumn colJumlahStatus;
        private DateTimePicker dtpMulai;
        private Label lblSampai;
        private DateTimePicker dtpSelesai;
        private Button btnTerapkanRiwayat;
        private Button btnSimpanJson;
        private TextBox txtCariRiwayat;
        private ComboBox cmbJenisPergerakan;
        private DataGridView gridRiwayatStok;
        private DataGridViewTextBoxColumn colRiwayatTanggal;
        private DataGridViewTextBoxColumn colRiwayatKode;
        private DataGridViewTextBoxColumn colRiwayatNama;
        private DataGridViewTextBoxColumn colRiwayatJenis;
        private DataGridViewTextBoxColumn colRiwayatJumlah;
        private DataGridViewTextBoxColumn colRiwayatKet;
        private DataGridViewTextBoxColumn colRiwayatOleh;
    }
}