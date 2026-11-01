namespace Sukimart
{
    partial class FormDashboardAdmin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlKiri = new Panel();
            btnLaporan = new Button();
            btnGudang = new Button();
            btnKeluarBenar = new Button();
            btnRiwayat = new Button();
            btnKatalog = new Button();
            btnKasir = new Button();
            btnDashboard = new Button();
            pictureLogo = new PictureBox();
            lblNama = new Label();
            pnlKanan = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            pnlPeringatan = new Panel();
            lstStokMenipis = new ListBox();
            lblPeringatan = new Label();
            pnlStok = new Panel();
            lblNilaiStok = new Label();
            lblStok = new Label();
            pnlTerjual = new Panel();
            lblNilaiPenjualan = new Label();
            lblPenjualan = new Label();
            pnlTransaksi = new Panel();
            lblNilaiTransaksi = new Label();
            lblTransaksiHariIni = new Label();
            dataGridView1 = new DataGridView();
            lblTanggal = new Label();
            lblJudul = new Label();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            pnlPeringatan.SuspendLayout();
            pnlStok.SuspendLayout();
            pnlTerjual.SuspendLayout();
            pnlTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlKiri
            // 
            pnlKiri.BackColor = Color.White;
            pnlKiri.Controls.Add(btnLaporan);
            pnlKiri.Controls.Add(btnGudang);
            pnlKiri.Controls.Add(btnKeluarBenar);
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
            pnlKiri.TabIndex = 1;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.White;
            btnLaporan.Cursor = Cursors.Hand;
            btnLaporan.FlatAppearance.BorderSize = 0;
            btnLaporan.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.Font = new Font("Segoe UI", 12F);
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
            btnGudang.Font = new Font("Segoe UI", 12F);
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
            // btnKeluarBenar
            // 
            btnKeluarBenar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKeluarBenar.BackColor = Color.White;
            btnKeluarBenar.Cursor = Cursors.Hand;
            btnKeluarBenar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnKeluarBenar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKeluarBenar.FlatStyle = FlatStyle.Flat;
            btnKeluarBenar.Font = new Font("Segoe UI", 12F);
            btnKeluarBenar.ForeColor = Color.FromArgb(75, 85, 99);
            btnKeluarBenar.Location = new Point(16, 620);
            btnKeluarBenar.Name = "btnKeluarBenar";
            btnKeluarBenar.Size = new Size(188, 44);
            btnKeluarBenar.TabIndex = 8;
            btnKeluarBenar.Text = "Keluar";
            btnKeluarBenar.UseVisualStyleBackColor = false;
            btnKeluarBenar.Click += button1_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.White;
            btnRiwayat.Cursor = Cursors.Hand;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI", 12F);
            btnRiwayat.ForeColor = Color.FromArgb(31, 41, 55);
            btnRiwayat.Location = new Point(16, 250);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Padding = new Padding(12, 0, 0, 0);
            btnRiwayat.Size = new Size(188, 44);
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
            btnKatalog.Font = new Font("Segoe UI", 12F);
            btnKatalog.ForeColor = Color.FromArgb(31, 41, 55);
            btnKatalog.Location = new Point(16, 200);
            btnKatalog.Name = "btnKatalog";
            btnKatalog.Padding = new Padding(12, 0, 0, 0);
            btnKatalog.Size = new Size(188, 44);
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
            btnKasir.Font = new Font("Segoe UI", 12F);
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
            btnDashboard.BackColor = Color.FromArgb(255, 196, 0);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblNama.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            pnlKanan.Controls.Add(pnlPeringatan);
            pnlKanan.Controls.Add(pnlStok);
            pnlKanan.Controls.Add(pnlTerjual);
            pnlKanan.Controls.Add(pnlTransaksi);
            pnlKanan.Controls.Add(dataGridView1);
            pnlKanan.Controls.Add(lblTanggal);
            pnlKanan.Controls.Add(lblJudul);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(220, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Padding = new Padding(28);
            pnlKanan.Size = new Size(880, 680);
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
            nightControlBox1.Location = new Point(741, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 16;
            // 
            // pnlPeringatan
            // 
            pnlPeringatan.BackColor = Color.White;
            pnlPeringatan.BorderStyle = BorderStyle.FixedSingle;
            pnlPeringatan.Controls.Add(lstStokMenipis);
            pnlPeringatan.Controls.Add(lblPeringatan);
            pnlPeringatan.Location = new Point(550, 275);
            pnlPeringatan.Name = "pnlPeringatan";
            pnlPeringatan.Size = new Size(265, 375);
            pnlPeringatan.TabIndex = 15;
            // 
            // lstStokMenipis
            // 
            lstStokMenipis.BorderStyle = BorderStyle.None;
            lstStokMenipis.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstStokMenipis.ForeColor = Color.FromArgb(180, 35, 24);
            lstStokMenipis.FormattingEnabled = true;
            lstStokMenipis.Location = new Point(30, 75);
            lstStokMenipis.Name = "lstStokMenipis";
            lstStokMenipis.Size = new Size(200, 272);
            lstStokMenipis.TabIndex = 1;
            // 
            // lblPeringatan
            // 
            lblPeringatan.AutoSize = true;
            lblPeringatan.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeringatan.ForeColor = Color.FromArgb(31, 41, 55);
            lblPeringatan.Location = new Point(25, 25);
            lblPeringatan.Name = "lblPeringatan";
            lblPeringatan.Size = new Size(127, 19);
            lblPeringatan.TabIndex = 0;
            lblPeringatan.Text = "Peringatan Stok";
            // 
            // pnlStok
            // 
            pnlStok.BackColor = Color.White;
            pnlStok.BorderStyle = BorderStyle.FixedSingle;
            pnlStok.Controls.Add(lblNilaiStok);
            pnlStok.Controls.Add(lblStok);
            pnlStok.Location = new Point(565, 100);
            pnlStok.Name = "pnlStok";
            pnlStok.Size = new Size(250, 150);
            pnlStok.TabIndex = 12;
            // 
            // lblNilaiStok
            // 
            lblNilaiStok.AutoSize = true;
            lblNilaiStok.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNilaiStok.ForeColor = Color.FromArgb(180, 35, 24);
            lblNilaiStok.Location = new Point(15, 75);
            lblNilaiStok.Name = "lblNilaiStok";
            lblNilaiStok.Size = new Size(39, 39);
            lblNilaiStok.TabIndex = 17;
            lblNilaiStok.Text = "0";
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStok.ForeColor = Color.FromArgb(107, 114, 128);
            lblStok.Location = new Point(15, 15);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(87, 16);
            lblStok.TabIndex = 15;
            lblStok.Text = "Stok Menipis";
            // 
            // pnlTerjual
            // 
            pnlTerjual.BackColor = Color.White;
            pnlTerjual.BorderStyle = BorderStyle.FixedSingle;
            pnlTerjual.Controls.Add(lblNilaiPenjualan);
            pnlTerjual.Controls.Add(lblPenjualan);
            pnlTerjual.Location = new Point(300, 100);
            pnlTerjual.Name = "pnlTerjual";
            pnlTerjual.Size = new Size(250, 150);
            pnlTerjual.TabIndex = 11;
            // 
            // lblNilaiPenjualan
            // 
            lblNilaiPenjualan.AutoSize = true;
            lblNilaiPenjualan.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNilaiPenjualan.ForeColor = Color.FromArgb(31, 41, 55);
            lblNilaiPenjualan.Location = new Point(15, 75);
            lblNilaiPenjualan.Name = "lblNilaiPenjualan";
            lblNilaiPenjualan.Size = new Size(39, 39);
            lblNilaiPenjualan.TabIndex = 16;
            lblNilaiPenjualan.Text = "0";
            // 
            // lblPenjualan
            // 
            lblPenjualan.AutoSize = true;
            lblPenjualan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPenjualan.ForeColor = Color.FromArgb(107, 114, 128);
            lblPenjualan.Location = new Point(15, 15);
            lblPenjualan.Name = "lblPenjualan";
            lblPenjualan.Size = new Size(114, 16);
            lblPenjualan.TabIndex = 15;
            lblPenjualan.Text = "Penjualan Hari Ini";
            // 
            // pnlTransaksi
            // 
            pnlTransaksi.BackColor = Color.White;
            pnlTransaksi.BorderStyle = BorderStyle.FixedSingle;
            pnlTransaksi.Controls.Add(lblNilaiTransaksi);
            pnlTransaksi.Controls.Add(lblTransaksiHariIni);
            pnlTransaksi.Location = new Point(35, 100);
            pnlTransaksi.Name = "pnlTransaksi";
            pnlTransaksi.Size = new Size(250, 150);
            pnlTransaksi.TabIndex = 10;
            // 
            // lblNilaiTransaksi
            // 
            lblNilaiTransaksi.AutoSize = true;
            lblNilaiTransaksi.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNilaiTransaksi.ForeColor = Color.FromArgb(31, 41, 55);
            lblNilaiTransaksi.Location = new Point(15, 75);
            lblNilaiTransaksi.Name = "lblNilaiTransaksi";
            lblNilaiTransaksi.Size = new Size(39, 39);
            lblNilaiTransaksi.TabIndex = 15;
            lblNilaiTransaksi.Text = "0";
            // 
            // lblTransaksiHariIni
            // 
            lblTransaksiHariIni.AutoSize = true;
            lblTransaksiHariIni.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTransaksiHariIni.ForeColor = Color.FromArgb(107, 114, 128);
            lblTransaksiHariIni.Location = new Point(15, 15);
            lblTransaksiHariIni.Name = "lblTransaksiHariIni";
            lblTransaksiHariIni.Size = new Size(112, 16);
            lblTransaksiHariIni.TabIndex = 14;
            lblTransaksiHariIni.Text = "Transaksi Hari Ini";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(243, 244, 246);
            dataGridView1.Location = new Point(35, 275);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.Size = new Size(475, 375);
            dataGridView1.TabIndex = 9;
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTanggal.ForeColor = Color.FromArgb(107, 114, 128);
            lblTanggal.Location = new Point(35, 60);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(55, 16);
            lblTanggal.TabIndex = 1;
            lblTanggal.Text = "Tanggal";
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(30, 25);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(308, 33);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "DASHBOARD (ADMIN)";
            // 
            // FormDashboardAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 680);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDashboardAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dashboard";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            pnlPeringatan.ResumeLayout(false);
            pnlPeringatan.PerformLayout();
            pnlStok.ResumeLayout(false);
            pnlStok.PerformLayout();
            pnlTerjual.ResumeLayout(false);
            pnlTerjual.PerformLayout();
            pnlTransaksi.ResumeLayout(false);
            pnlTransaksi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKiri;
        private Button btnRiwayat;
        private Button btnKatalog;
        private Button btnKasir;
        private Button btnDashboard;
        private PictureBox pictureLogo;
        private Label lblNama;
        private Button btnKeluarBenar;
        private Panel pnlKanan;
        private Panel pnlStok;
        private Label lblNilaiStok;
        private Label lblStok;
        private Panel pnlTerjual;
        private Label lblPenjualan;
        private Label lblNilaiPenjualan;
        private Panel pnlTransaksi;
        private Label lblNilaiTransaksi;
        private Label lblTransaksiHariIni;
        private DataGridView dataGridView1;
        private Label lblTanggal;
        private Label lblJudul;
        private Button btnLaporan;
        private Button btnGudang;
        private Panel pnlPeringatan;
        private Label lblPeringatan;
        private ListBox lstStokMenipis;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
    }
}