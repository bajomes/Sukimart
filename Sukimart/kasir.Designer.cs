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
            btnNolkanBayar = new Button();
            btnUang20 = new Button();
            btnUang10 = new Button();
            lblPintasanKet5 = new Label();
            lblPintasanTombol5 = new Label();
            lblPintasanKet4 = new Label();
            lblPintasanTombol4 = new Label();
            lblPintasanKet3 = new Label();
            lblPintasanTombol3 = new Label();
            lblPintasanKet2 = new Label();
            lblPintasanTombol2 = new Label();
            lblPintasanKet1 = new Label();
            lblPintasanTombol1 = new Label();
            lblPintasanJudul = new Label();
            btnUang50 = new Button();
            btnUang100 = new Button();
            pnlGaris = new Panel();
            lblInfoKasir = new Label();
            lblInfoKeranjang = new Label();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblJudul = new Label();
            lblPilihBarang = new Label();
            cmbBarang = new ComboBox();
            lblJumlah = new Label();
            nudJumlah = new NumericUpDown();
            btnTambahKeranjang = new Button();
            gridKeranjang = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            colKurang = new DataGridViewTextBoxColumn();
            colTambah = new DataGridViewTextBoxColumn();
            colHapus = new DataGridViewTextBoxColumn();
            pnlCheckout = new Panel();
            lblTotalLabel = new Label();
            lblTotalNilai = new Label();
            lblBayarLabel = new Label();
            nudBayar = new NumericUpDown();
            lblKembalianLabel = new Label();
            lblKembalianNilai = new Label();
            btnProsesBayar = new Button();
            btnBatalKeranjang = new Button();
            btnUangPas = new Button();
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
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Padding = new Padding(16, 0, 0, 0);
            btnKeluar.Size = new Size(208, 40);
            btnKeluar.TabIndex = 11;
            btnKeluar.Text = "Keluar";
            btnKeluar.TextAlign = ContentAlignment.MiddleLeft;
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
            btnKasir.BackColor = Color.FromArgb(255, 196, 0);
            btnKasir.Cursor = Cursors.Hand;
            btnKasir.FlatAppearance.BorderSize = 0;
            btnKasir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKasir.FlatStyle = FlatStyle.Flat;
            btnKasir.Font = new Font("Inter", 10F, FontStyle.Bold);
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
            pnlKanan.Controls.Add(lblPilihBarang);
            pnlKanan.Controls.Add(cmbBarang);
            pnlKanan.Controls.Add(lblJumlah);
            pnlKanan.Controls.Add(nudJumlah);
            pnlKanan.Controls.Add(btnTambahKeranjang);
            pnlKanan.Controls.Add(gridKeranjang);
            pnlKanan.Controls.Add(pnlCheckout);
            pnlKanan.Controls.Add(lblInfoKeranjang);
            pnlKanan.Controls.Add(lblInfoKasir);
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
            lblJudul.Location = new Point(40, 32);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(162, 33);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Kasir / POS";
            // 
            // lblPilihBarang
            // 
            lblPilihBarang.AutoSize = true;
            lblPilihBarang.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPilihBarang.ForeColor = Color.FromArgb(75, 85, 99);
            lblPilihBarang.Location = new Point(40, 112);
            lblPilihBarang.Name = "lblPilihBarang";
            lblPilihBarang.Size = new Size(76, 15);
            lblPilihBarang.TabIndex = 3;
            lblPilihBarang.Text = "Cari Produk";
            // 
            // cmbBarang
            // 
            cmbBarang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBarang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBarang.DropDownStyle = ComboBoxStyle.DropDown;
            cmbBarang.Font = new Font("Inter", 10F);
            cmbBarang.FormattingEnabled = true;
            cmbBarang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbBarang.Location = new Point(40, 136);
            cmbBarang.Name = "cmbBarang";
            cmbBarang.Size = new Size(448, 25);
            cmbBarang.TabIndex = 4;
            // 
            // lblJumlah
            // 
            lblJumlah.AutoSize = true;
            lblJumlah.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJumlah.ForeColor = Color.FromArgb(75, 85, 99);
            lblJumlah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblJumlah.Location = new Point(504, 112);
            lblJumlah.Name = "lblJumlah";
            lblJumlah.Size = new Size(49, 15);
            lblJumlah.TabIndex = 5;
            lblJumlah.Text = "Jumlah";
            // 
            // nudJumlah
            // 
            nudJumlah.Font = new Font("Inter", 10F);
            nudJumlah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudJumlah.Location = new Point(504, 136);
            nudJumlah.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudJumlah.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudJumlah.TextAlign = HorizontalAlignment.Center;
            nudJumlah.Name = "nudJumlah";
            nudJumlah.Size = new Size(64, 24);
            nudJumlah.TabIndex = 6;
            nudJumlah.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnTambahKeranjang
            // 
            btnTambahKeranjang.BackColor = Color.FromArgb(255, 196, 0);
            btnTambahKeranjang.Cursor = Cursors.Hand;
            btnTambahKeranjang.FlatAppearance.BorderSize = 0;
            btnTambahKeranjang.FlatStyle = FlatStyle.Flat;
            btnTambahKeranjang.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnTambahKeranjang.ForeColor = Color.FromArgb(31, 41, 55);
            btnTambahKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambahKeranjang.Location = new Point(584, 132);
            btnTambahKeranjang.Name = "btnTambahKeranjang";
            btnTambahKeranjang.Size = new Size(88, 32);
            btnTambahKeranjang.TabIndex = 7;
            btnTambahKeranjang.Text = "+ Tambah";
            btnTambahKeranjang.UseVisualStyleBackColor = false;
            // 
            // gridKeranjang
            // 
            gridKeranjang.AllowUserToAddRows = false;
            gridKeranjang.AllowUserToDeleteRows = false;
            gridKeranjang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridKeranjang.BackgroundColor = Color.White;
            gridKeranjang.BorderStyle = BorderStyle.None;
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
            gridKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridKeranjang.Location = new Point(40, 176);
            gridKeranjang.MultiSelect = false;
            gridKeranjang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridKeranjang.GridColor = Color.FromArgb(229, 231, 235);
            gridKeranjang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridKeranjang.Name = "gridKeranjang";
            gridKeranjang.ReadOnly = true;
            gridKeranjang.RowHeadersVisible = false;
            gridKeranjang.RowTemplate.Height = 36;
            gridKeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKeranjang.Size = new Size(632, 464);
            gridKeranjang.TabIndex = 9;
            // 
            // colKode
            // 
            colKode.DataPropertyName = "KodeBarang";
            colKode.FillWeight = 70F;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.DataPropertyName = "NamaBarang";
            colNama.FillWeight = 170F;
            colNama.HeaderText = "Produk";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.DataPropertyName = "HargaFormat";
            colHarga.FillWeight = 90F;
            colHarga.HeaderText = "Harga";
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colQty
            // 
            colQty.DataPropertyName = "Jumlah";
            colQty.FillWeight = 40F;
            colQty.HeaderText = "Qty";
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            // 
            // colSubtotal
            // 
            colSubtotal.DataPropertyName = "SubtotalFormat";
            colSubtotal.FillWeight = 100F;
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            // 
            // pnlCheckout
            // 
            pnlCheckout.BackColor = Color.White;
            pnlCheckout.BorderStyle = BorderStyle.None;
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
            pnlCheckout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlCheckout.Location = new Point(696, 112);
            pnlCheckout.Name = "pnlCheckout";
            pnlCheckout.Size = new Size(304, 568);
            pnlCheckout.TabIndex = 10;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Inter", 9F);
            lblTotalLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalLabel.Location = new Point(24, 24);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(83, 15);
            lblTotalLabel.TabIndex = 1;
            lblTotalLabel.Text = "Total Belanja";
            // 
            // lblTotalNilai
            // 
            lblTotalNilai.AutoSize = true;
            lblTotalNilai.Font = new Font("Inter", 28F, FontStyle.Bold);
            lblTotalNilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblTotalNilai.Location = new Point(24, 44);
            lblTotalNilai.Name = "lblTotalNilai";
            lblTotalNilai.Size = new Size(66, 29);
            lblTotalNilai.TabIndex = 2;
            lblTotalNilai.Text = "Rp 0";
            // 
            // lblBayarLabel
            // 
            lblBayarLabel.AutoSize = true;
            lblBayarLabel.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblBayarLabel.ForeColor = Color.FromArgb(75, 85, 99);
            lblBayarLabel.Location = new Point(24, 128);
            lblBayarLabel.Name = "lblBayarLabel";
            lblBayarLabel.Size = new Size(123, 15);
            lblBayarLabel.TabIndex = 3;
            lblBayarLabel.Text = "Uang Diterima";
            // 
            // btnUangPas
            // 
            btnUangPas.BackColor = Color.FromArgb(243, 244, 246);
            btnUangPas.Cursor = Cursors.Hand;
            btnUangPas.FlatAppearance.BorderSize = 0;
            btnUangPas.FlatStyle = FlatStyle.Flat;
            btnUangPas.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUangPas.ForeColor = Color.FromArgb(31, 41, 55);
            btnUangPas.Location = new Point(24, 192);
            btnUangPas.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUangPas.Name = "btnUangPas";
            btnUangPas.Size = new Size(80, 28);
            btnUangPas.TabIndex = 12;
            btnUangPas.Text = "Uang Pas";
            btnUangPas.UseVisualStyleBackColor = false;
            // 
            // nudBayar
            // 
            nudBayar.Font = new Font("Inter", 14F, FontStyle.Bold);
            nudBayar.Location = new Point(24, 152);
            nudBayar.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudBayar.TextAlign = HorizontalAlignment.Right;
            nudBayar.Name = "nudBayar";
            nudBayar.Size = new Size(256, 30);
            nudBayar.TabIndex = 4;
            nudBayar.ThousandsSeparator = true;
            // 
            // lblKembalianLabel
            // 
            lblKembalianLabel.AutoSize = true;
            lblKembalianLabel.Font = new Font("Inter", 9F);
            lblKembalianLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblKembalianLabel.Location = new Point(24, 264);
            lblKembalianLabel.Name = "lblKembalianLabel";
            lblKembalianLabel.Size = new Size(70, 15);
            lblKembalianLabel.TabIndex = 5;
            lblKembalianLabel.Text = "Kembalian";
            // 
            // lblKembalianNilai
            // 
            lblKembalianNilai.AutoSize = true;
            lblKembalianNilai.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblKembalianNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblKembalianNilai.Location = new Point(24, 282);
            lblKembalianNilai.Name = "lblKembalianNilai";
            lblKembalianNilai.Size = new Size(60, 26);
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
            btnProsesBayar.Location = new Point(24, 448);
            btnProsesBayar.Name = "btnProsesBayar";
            btnProsesBayar.Size = new Size(256, 48);
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
            btnBatalKeranjang.Location = new Point(24, 504);
            btnBatalKeranjang.Name = "btnBatalKeranjang";
            btnBatalKeranjang.Size = new Size(256, 40);
            btnBatalKeranjang.TabIndex = 8;
            btnBatalKeranjang.Text = "Kosongkan Keranjang";
            btnBatalKeranjang.UseVisualStyleBackColor = false;
            // 
            // FormKasir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKasir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kasir / POS";
            colHapus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colHapus.DataPropertyName = "Hapus";
            colHapus.HeaderText = "";
            colHapus.ReadOnly = true;
            colHapus.Resizable = DataGridViewTriState.False;
            colHapus.SortMode = DataGridViewColumnSortMode.NotSortable;
            colHapus.Width = 36;
            colHapus.Name = "colHapus";
            colTambah.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTambah.DataPropertyName = "Tambah";
            colTambah.HeaderText = "";
            colTambah.ReadOnly = true;
            colTambah.Resizable = DataGridViewTriState.False;
            colTambah.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTambah.Width = 36;
            colTambah.Name = "colTambah";
            colKurang.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colKurang.DataPropertyName = "Kurang";
            colKurang.HeaderText = "";
            colKurang.ReadOnly = true;
            colKurang.Resizable = DataGridViewTriState.False;
            colKurang.SortMode = DataGridViewColumnSortMode.NotSortable;
            colKurang.Width = 36;
            colKurang.Name = "colKurang";
            lblInfoKeranjang.AutoSize = true;
            lblInfoKeranjang.BackColor = Color.Transparent;
            lblInfoKeranjang.Font = new Font("Inter", 9F);
            lblInfoKeranjang.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfoKeranjang.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblInfoKeranjang.Location = new Point(40, 652);
            lblInfoKeranjang.TabIndex = 0;
            lblInfoKeranjang.Text = "0 produk · 0 item";
            lblInfoKeranjang.Name = "lblInfoKeranjang";
            lblInfoKasir.BackColor = Color.Transparent;
            lblInfoKasir.Font = new Font("Inter", 9F);
            lblInfoKasir.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfoKasir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInfoKasir.Location = new Point(600, 40);
            lblInfoKasir.Size = new Size(400, 24);
            lblInfoKasir.TextAlign = ContentAlignment.MiddleRight;
            lblInfoKasir.TabIndex = 0;
            lblInfoKasir.Text = "Kasir";
            lblInfoKasir.Name = "lblInfoKasir";
            pnlGaris.BackColor = Color.FromArgb(229, 231, 235);
            pnlGaris.Location = new Point(24, 104);
            pnlGaris.Size = new Size(256, 1);
            pnlGaris.TabIndex = 0;
            pnlGaris.Name = "pnlGaris";
            btnUang100.BackColor = Color.FromArgb(243, 244, 246);
            btnUang100.Cursor = Cursors.Hand;
            btnUang100.FlatAppearance.BorderSize = 0;
            btnUang100.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang100.FlatStyle = FlatStyle.Flat;
            btnUang100.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang100.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang100.Location = new Point(112, 224);
            btnUang100.Size = new Size(80, 28);
            btnUang100.TabIndex = 13;
            btnUang100.Text = "+100.000";
            btnUang100.UseVisualStyleBackColor = false;
            btnUang100.Name = "btnUang100";
            btnUang50.BackColor = Color.FromArgb(243, 244, 246);
            btnUang50.Cursor = Cursors.Hand;
            btnUang50.FlatAppearance.BorderSize = 0;
            btnUang50.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang50.FlatStyle = FlatStyle.Flat;
            btnUang50.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang50.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang50.Location = new Point(24, 224);
            btnUang50.Size = new Size(80, 28);
            btnUang50.TabIndex = 13;
            btnUang50.Text = "+50.000";
            btnUang50.UseVisualStyleBackColor = false;
            btnUang50.Name = "btnUang50";
            lblPintasanJudul.AutoSize = true;
            lblPintasanJudul.BackColor = Color.Transparent;
            lblPintasanJudul.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanJudul.ForeColor = Color.FromArgb(75, 85, 99);
            lblPintasanJudul.Location = new Point(24, 324);
            lblPintasanJudul.TabIndex = 0;
            lblPintasanJudul.Text = "Pintasan Keyboard";
            lblPintasanJudul.Name = "lblPintasanJudul";
            lblPintasanTombol1.AutoSize = true;
            lblPintasanTombol1.BackColor = Color.Transparent;
            lblPintasanTombol1.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol1.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol1.Location = new Point(24, 344);
            lblPintasanTombol1.TabIndex = 0;
            lblPintasanTombol1.Text = "Enter";
            lblPintasanTombol1.Name = "lblPintasanTombol1";
            lblPintasanKet1.AutoSize = true;
            lblPintasanKet1.BackColor = Color.Transparent;
            lblPintasanKet1.Font = new Font("Inter", 9F);
            lblPintasanKet1.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet1.Location = new Point(96, 344);
            lblPintasanKet1.TabIndex = 0;
            lblPintasanKet1.Text = "Tambah / lanjut bayar";
            lblPintasanKet1.Name = "lblPintasanKet1";
            lblPintasanTombol2.AutoSize = true;
            lblPintasanTombol2.BackColor = Color.Transparent;
            lblPintasanTombol2.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol2.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol2.Location = new Point(24, 362);
            lblPintasanTombol2.TabIndex = 0;
            lblPintasanTombol2.Text = "3  *";
            lblPintasanTombol2.Name = "lblPintasanTombol2";
            lblPintasanKet2.AutoSize = true;
            lblPintasanKet2.BackColor = Color.Transparent;
            lblPintasanKet2.Font = new Font("Inter", 9F);
            lblPintasanKet2.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet2.Location = new Point(96, 362);
            lblPintasanKet2.TabIndex = 0;
            lblPintasanKet2.Text = "Atur jumlah, lalu cari";
            lblPintasanKet2.Name = "lblPintasanKet2";
            lblPintasanTombol3.AutoSize = true;
            lblPintasanTombol3.BackColor = Color.Transparent;
            lblPintasanTombol3.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol3.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol3.Location = new Point(24, 380);
            lblPintasanTombol3.TabIndex = 0;
            lblPintasanTombol3.Text = "+  −";
            lblPintasanTombol3.Name = "lblPintasanTombol3";
            lblPintasanKet3.AutoSize = true;
            lblPintasanKet3.BackColor = Color.Transparent;
            lblPintasanKet3.Font = new Font("Inter", 9F);
            lblPintasanKet3.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet3.Location = new Point(96, 380);
            lblPintasanKet3.TabIndex = 0;
            lblPintasanKet3.Text = "Ubah qty baris terpilih";
            lblPintasanKet3.Name = "lblPintasanKet3";
            lblPintasanTombol4.AutoSize = true;
            lblPintasanTombol4.BackColor = Color.Transparent;
            lblPintasanTombol4.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol4.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol4.Location = new Point(24, 398);
            lblPintasanTombol4.TabIndex = 0;
            lblPintasanTombol4.Text = "↑  ↓";
            lblPintasanTombol4.Name = "lblPintasanTombol4";
            lblPintasanKet4.AutoSize = true;
            lblPintasanKet4.BackColor = Color.Transparent;
            lblPintasanKet4.Font = new Font("Inter", 9F);
            lblPintasanKet4.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet4.Location = new Point(96, 398);
            lblPintasanKet4.TabIndex = 0;
            lblPintasanKet4.Text = "Pilih baris keranjang";
            lblPintasanKet4.Name = "lblPintasanKet4";
            lblPintasanTombol5.AutoSize = true;
            lblPintasanTombol5.BackColor = Color.Transparent;
            lblPintasanTombol5.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblPintasanTombol5.ForeColor = Color.FromArgb(31, 41, 55);
            lblPintasanTombol5.Location = new Point(24, 416);
            lblPintasanTombol5.TabIndex = 0;
            lblPintasanTombol5.Text = "Del";
            lblPintasanTombol5.Name = "lblPintasanTombol5";
            lblPintasanKet5.AutoSize = true;
            lblPintasanKet5.BackColor = Color.Transparent;
            lblPintasanKet5.Font = new Font("Inter", 9F);
            lblPintasanKet5.ForeColor = Color.FromArgb(107, 114, 128);
            lblPintasanKet5.Location = new Point(96, 416);
            lblPintasanKet5.TabIndex = 0;
            lblPintasanKet5.Text = "Hapus baris terpilih";
            lblPintasanKet5.Name = "lblPintasanKet5";
            btnUang10.BackColor = Color.FromArgb(243, 244, 246);
            btnUang10.Cursor = Cursors.Hand;
            btnUang10.FlatAppearance.BorderSize = 0;
            btnUang10.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang10.FlatStyle = FlatStyle.Flat;
            btnUang10.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang10.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang10.Location = new Point(112, 192);
            btnUang10.Size = new Size(80, 28);
            btnUang10.Text = "+10.000";
            btnUang10.UseVisualStyleBackColor = false;
            btnUang10.Name = "btnUang10";
            btnUang20.BackColor = Color.FromArgb(243, 244, 246);
            btnUang20.Cursor = Cursors.Hand;
            btnUang20.FlatAppearance.BorderSize = 0;
            btnUang20.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnUang20.FlatStyle = FlatStyle.Flat;
            btnUang20.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnUang20.ForeColor = Color.FromArgb(31, 41, 55);
            btnUang20.Location = new Point(200, 192);
            btnUang20.Size = new Size(80, 28);
            btnUang20.Text = "+20.000";
            btnUang20.UseVisualStyleBackColor = false;
            btnUang20.Name = "btnUang20";
            btnNolkanBayar.BackColor = Color.FromArgb(243, 244, 246);
            btnNolkanBayar.Cursor = Cursors.Hand;
            btnNolkanBayar.FlatAppearance.BorderSize = 0;
            btnNolkanBayar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnNolkanBayar.FlatStyle = FlatStyle.Flat;
            btnNolkanBayar.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnNolkanBayar.ForeColor = Color.FromArgb(220, 38, 38);
            btnNolkanBayar.Location = new Point(200, 224);
            btnNolkanBayar.Size = new Size(80, 28);
            btnNolkanBayar.Text = "Hapus";
            btnNolkanBayar.UseVisualStyleBackColor = false;
            btnNolkanBayar.Name = "btnNolkanBayar";
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
        private ComboBox cmbBarang;
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
