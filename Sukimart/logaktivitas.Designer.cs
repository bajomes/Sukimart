namespace Sukimart
{
    partial class FormLogAktivitas
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

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            lblStatusTabel = new Label();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblJudul = new Label();
            pnlFilter = new Panel();
            btnBersihkan = new Button();
            btnSegarkan = new Button();
            cmbFilterWaktu = new ComboBox();
            lblFilterWaktu = new Label();
            cmbFilterJenis = new ComboBox();
            lblFilterJenis = new Label();
            txtCari = new TextBox();
            gridLog = new DataGridView();
            colNo = new DataGridViewTextBoxColumn();
            colWaktu = new DataGridViewTextBoxColumn();
            colPengguna = new DataGridViewTextBoxColumn();
            colJenis = new DataGridViewTextBoxColumn();
            colAksi = new DataGridViewTextBoxColumn();
            pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlKanan.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLog).BeginInit();
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
            pnlKiri.Name = "pnlKiri";
            pnlKiri.Size = new Size(240, 720);
            pnlKiri.TabIndex = 1;
            // 
            // btnKeluar
            // 
            btnKeluar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnKeluar.BackColor = Color.White;
            btnKeluar.Cursor = Cursors.Hand;
            btnKeluar.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnKeluar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Inter", 10F);
            btnKeluar.ForeColor = Color.FromArgb(75, 85, 99);
            btnKeluar.Location = new Point(16, 640);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Padding = new Padding(16, 0, 0, 0);
            btnKeluar.Size = new Size(208, 40);
            btnKeluar.TabIndex = 13;
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
            btnGantiSandi.Location = new Point(16, 592);
            btnGantiSandi.Name = "btnGantiSandi";
            btnGantiSandi.Padding = new Padding(16, 0, 0, 0);
            btnGantiSandi.Size = new Size(208, 40);
            btnGantiSandi.TabIndex = 14;
            btnGantiSandi.Text = "Ganti Kata Sandi";
            btnGantiSandi.TextAlign = ContentAlignment.MiddleLeft;
            btnGantiSandi.UseVisualStyleBackColor = false;
            // 
            // btnLogAktivitas
            // 
            btnLogAktivitas.BackColor = Color.FromArgb(255, 196, 0);
            btnLogAktivitas.Cursor = Cursors.Hand;
            btnLogAktivitas.FlatAppearance.BorderSize = 0;
            btnLogAktivitas.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnLogAktivitas.FlatStyle = FlatStyle.Flat;
            btnLogAktivitas.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnLogAktivitas.ForeColor = Color.FromArgb(31, 41, 55);
            btnLogAktivitas.Location = new Point(16, 496);
            btnLogAktivitas.Name = "btnLogAktivitas";
            btnLogAktivitas.Padding = new Padding(16, 0, 0, 0);
            btnLogAktivitas.Size = new Size(208, 40);
            btnLogAktivitas.TabIndex = 12;
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
            btnPengguna.Location = new Point(16, 448);
            btnPengguna.Name = "btnPengguna";
            btnPengguna.Padding = new Padding(16, 0, 0, 0);
            btnPengguna.Size = new Size(208, 40);
            btnPengguna.TabIndex = 11;
            btnPengguna.Text = "Pengguna";
            btnPengguna.TextAlign = ContentAlignment.MiddleLeft;
            btnPengguna.UseVisualStyleBackColor = false;
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
            btnRiwayat.TabIndex = 8;
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
            btnKatalog.TabIndex = 7;
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
            btnKasir.TabIndex = 6;
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
            btnDashboard.TabIndex = 5;
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
            lblNama.Location = new Point(72, 42);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(113, 24);
            lblNama.TabIndex = 1;
            lblNama.Text = "SUKIMART";
            // 
            // pnlKanan
            // 
            pnlKanan.BackColor = Color.FromArgb(247, 247, 245);
            pnlKanan.Controls.Add(lblStatusTabel);
            pnlKanan.Controls.Add(nightControlBox1);
            pnlKanan.Controls.Add(lblJudul);
            pnlKanan.Controls.Add(pnlFilter);
            pnlKanan.Controls.Add(gridLog);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(240, 0);
            pnlKanan.Name = "pnlKanan";
            pnlKanan.Size = new Size(1040, 720);
            pnlKanan.TabIndex = 2;
            // 
            // lblStatusTabel
            // 
            lblStatusTabel.AutoSize = true;
            lblStatusTabel.Font = new Font("Inter", 8.5F);
            lblStatusTabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatusTabel.Location = new Point(40, 672);
            lblStatusTabel.Name = "lblStatusTabel";
            lblStatusTabel.Size = new Size(139, 15);
            lblStatusTabel.TabIndex = 9;
            lblStatusTabel.Text = "Menampilkan 0 aktivitas";
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
            nightControlBox1.Location = new Point(919, 0);
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
            lblJudul.Size = new Size(182, 31);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Log Aktivitas";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(btnBersihkan);
            pnlFilter.Controls.Add(btnSegarkan);
            pnlFilter.Controls.Add(cmbFilterWaktu);
            pnlFilter.Controls.Add(lblFilterWaktu);
            pnlFilter.Controls.Add(cmbFilterJenis);
            pnlFilter.Controls.Add(lblFilterJenis);
            pnlFilter.Controls.Add(txtCari);
            pnlFilter.Location = new Point(40, 96);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(960, 56);
            pnlFilter.TabIndex = 7;
            // 
            // btnBersihkan
            // 
            btnBersihkan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBersihkan.BackColor = Color.FromArgb(254, 226, 226);
            btnBersihkan.Cursor = Cursors.Hand;
            btnBersihkan.FlatAppearance.BorderSize = 0;
            btnBersihkan.FlatStyle = FlatStyle.Flat;
            btnBersihkan.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            btnBersihkan.ForeColor = Color.FromArgb(153, 27, 27);
            btnBersihkan.Location = new Point(851, 10);
            btnBersihkan.Name = "btnBersihkan";
            btnBersihkan.Size = new Size(98, 25);
            btnBersihkan.TabIndex = 7;
            btnBersihkan.Text = "Bersihkan log";
            btnBersihkan.UseVisualStyleBackColor = false;
            // 
            // btnSegarkan
            // 
            btnSegarkan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSegarkan.BackColor = Color.FromArgb(243, 244, 246);
            btnSegarkan.Cursor = Cursors.Hand;
            btnSegarkan.FlatAppearance.BorderSize = 0;
            btnSegarkan.FlatStyle = FlatStyle.Flat;
            btnSegarkan.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnSegarkan.ForeColor = Color.FromArgb(55, 65, 81);
            btnSegarkan.Location = new Point(761, 10);
            btnSegarkan.Name = "btnSegarkan";
            btnSegarkan.Size = new Size(75, 25);
            btnSegarkan.TabIndex = 5;
            btnSegarkan.Text = "Refresh";
            btnSegarkan.UseVisualStyleBackColor = false;
            // 
            // cmbFilterWaktu
            // 
            cmbFilterWaktu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterWaktu.Font = new Font("Inter", 9F);
            cmbFilterWaktu.FormattingEnabled = true;
            cmbFilterWaktu.Items.AddRange(new object[] { "Semua Waktu", "Hari Ini", "7 Hari Terakhir", "30 Hari Terakhir" });
            cmbFilterWaktu.Location = new Point(532, 16);
            cmbFilterWaktu.Name = "cmbFilterWaktu";
            cmbFilterWaktu.Size = new Size(124, 23);
            cmbFilterWaktu.TabIndex = 4;
            // 
            // lblFilterWaktu
            // 
            lblFilterWaktu.AutoSize = true;
            lblFilterWaktu.Font = new Font("Inter", 8.5F);
            lblFilterWaktu.ForeColor = Color.FromArgb(75, 85, 99);
            lblFilterWaktu.Location = new Point(474, 20);
            lblFilterWaktu.Name = "lblFilterWaktu";
            lblFilterWaktu.Size = new Size(53, 15);
            lblFilterWaktu.TabIndex = 3;
            lblFilterWaktu.Text = "Periode:";
            // 
            // cmbFilterJenis
            // 
            cmbFilterJenis.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterJenis.Font = new Font("Inter", 9F);
            cmbFilterJenis.FormattingEnabled = true;
            cmbFilterJenis.Location = new Point(328, 16);
            cmbFilterJenis.Name = "cmbFilterJenis";
            cmbFilterJenis.Size = new Size(136, 23);
            cmbFilterJenis.TabIndex = 2;
            // 
            // lblFilterJenis
            // 
            lblFilterJenis.AutoSize = true;
            lblFilterJenis.Font = new Font("Inter", 8.5F);
            lblFilterJenis.ForeColor = Color.FromArgb(75, 85, 99);
            lblFilterJenis.Location = new Point(284, 20);
            lblFilterJenis.Name = "lblFilterJenis";
            lblFilterJenis.Size = new Size(39, 15);
            lblFilterJenis.TabIndex = 1;
            lblFilterJenis.Text = "Jenis:";
            // 
            // txtCari
            // 
            txtCari.Font = new Font("Inter", 9F);
            txtCari.Location = new Point(14, 16);
            txtCari.Name = "txtCari";
            txtCari.PlaceholderText = "Cari kata kunci, akun, detail...";
            txtCari.Size = new Size(256, 21);
            txtCari.TabIndex = 0;
            // 
            // gridLog
            // 
            gridLog.AllowUserToAddRows = false;
            gridLog.AllowUserToDeleteRows = false;
            gridLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLog.BackgroundColor = Color.White;
            gridLog.BorderStyle = BorderStyle.None;
            gridLog.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridLog.ColumnHeadersHeight = 40;
            gridLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridLog.Columns.AddRange(new DataGridViewColumn[] { colNo, colWaktu, colPengguna, colJenis, colAksi });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Inter", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridLog.DefaultCellStyle = dataGridViewCellStyle4;
            gridLog.EnableHeadersVisualStyles = false;
            gridLog.GridColor = Color.FromArgb(229, 231, 235);
            gridLog.Location = new Point(40, 164);
            gridLog.MultiSelect = false;
            gridLog.Name = "gridLog";
            gridLog.ReadOnly = true;
            gridLog.RowHeadersVisible = false;
            gridLog.RowHeadersWidth = 51;
            gridLog.RowTemplate.Height = 36;
            gridLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLog.Size = new Size(960, 496);
            gridLog.TabIndex = 8;
            // 
            // colNo
            // 
            colNo.DataPropertyName = "No";
            colNo.FillWeight = 40F;
            colNo.HeaderText = "No";
            colNo.MinimumWidth = 6;
            colNo.Name = "colNo";
            colNo.ReadOnly = true;
            // 
            // colWaktu
            // 
            colWaktu.DataPropertyName = "Waktu";
            colWaktu.FillWeight = 140F;
            colWaktu.HeaderText = "Waktu (Presisi)";
            colWaktu.MinimumWidth = 6;
            colWaktu.Name = "colWaktu";
            colWaktu.ReadOnly = true;
            // 
            // colPengguna
            // 
            colPengguna.DataPropertyName = "Pengguna";
            colPengguna.HeaderText = "Pengguna";
            colPengguna.MinimumWidth = 6;
            colPengguna.Name = "colPengguna";
            colPengguna.ReadOnly = true;
            // 
            // colJenis
            // 
            colJenis.DataPropertyName = "Jenis";
            colJenis.FillWeight = 120F;
            colJenis.HeaderText = "Jenis Aktivitas";
            colJenis.MinimumWidth = 6;
            colJenis.Name = "colJenis";
            colJenis.ReadOnly = true;
            // 
            // colAksi
            // 
            colAksi.DataPropertyName = "Aksi";
            colAksi.FillWeight = 360F;
            colAksi.HeaderText = "Keterangan / Detail Aktivitas";
            colAksi.MinimumWidth = 6;
            colAksi.Name = "colAksi";
            colAksi.ReadOnly = true;
            // 
            // FormLogAktivitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogAktivitas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log Aktivitas";
            pnlKiri.ResumeLayout(false);
            pnlKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlKanan.ResumeLayout(false);
            pnlKanan.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLog).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlKiri;
        private Button btnKeluar;
        private Button btnLogAktivitas;
        private Button btnPengguna;
        private Button btnLaporanInventaris;
        private Button btnLaporan;
        private Button btnGudang;
        private Button btnRiwayat;
        private Button btnKatalog;
        private Button btnKasir;
        private Button btnDashboard;
        private PictureBox pictureLogo;
        private Label lblNama;
        private Panel pnlKanan;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblJudul;
        private Panel pnlFilter;
        private TextBox txtCari;
        private Label lblFilterJenis;
        private ComboBox cmbFilterJenis;
        private Label lblFilterWaktu;
        private ComboBox cmbFilterWaktu;
        private Button btnSegarkan;
        private Button btnBersihkan;
        private DataGridView gridLog;
        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colWaktu;
        private DataGridViewTextBoxColumn colPengguna;
        private DataGridViewTextBoxColumn colJenis;
        private DataGridViewTextBoxColumn colAksi;
        private Label lblStatusTabel;
        private Button btnGantiSandi;
    }
}
