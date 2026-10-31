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
            cmbBarang = new ComboBox();
            lblJumlah = new Label();
            nudJumlah = new NumericUpDown();
            btnTambahKeranjang = new Button();
            btnHapusKeranjang = new Button();
            gridKeranjang = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            pnlCheckout = new Panel();
            lblRingkasan = new Label();
            lblTotalLabel = new Label();
            lblTotalNilai = new Label();
            lblBayarLabel = new Label();
            nudBayar = new NumericUpDown();
            lblKembalianLabel = new Label();
            lblKembalianNilai = new Label();
            btnProsesBayar = new Button();
            btnBatalKeranjang = new Button();
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
            pnlKiri.TabIndex = 1;
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
            btnKatalog.BackColor = Color.White;
            btnKatalog.Cursor = Cursors.Hand;
            btnKatalog.FlatAppearance.BorderSize = 0;
            btnKatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKatalog.FlatStyle = FlatStyle.Flat;
            btnKatalog.Font = new Font("Inter", 12F);
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
            btnKasir.BackColor = Color.FromArgb(255, 196, 0);
            btnKasir.Cursor = Cursors.Hand;
            btnKasir.FlatAppearance.BorderSize = 0;
            btnKasir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKasir.FlatStyle = FlatStyle.Flat;
            btnKasir.Font = new Font("Inter", 12F, FontStyle.Bold);
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
            btnDashboard.Font = new Font("Inter", 12F);
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
            lblNama.Font = new Font("Inter", 14.25F, FontStyle.Bold);
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
            pnlKanan.Controls.Add(lblJudul);
            pnlKanan.Controls.Add(lblPilihBarang);
            pnlKanan.Controls.Add(cmbBarang);
            pnlKanan.Controls.Add(lblJumlah);
            pnlKanan.Controls.Add(nudJumlah);
            pnlKanan.Controls.Add(btnTambahKeranjang);
            pnlKanan.Controls.Add(btnHapusKeranjang);
            pnlKanan.Controls.Add(gridKeranjang);
            pnlKanan.Controls.Add(pnlCheckout);
            pnlKanan.Dock = DockStyle.Fill;
            pnlKanan.Location = new Point(220, 0);
            pnlKanan.Name = "pnlKanan";
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
            nightControlBox1.TabIndex = 0;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 20F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(30, 20);
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
            lblPilihBarang.Location = new Point(30, 85);
            lblPilihBarang.Name = "lblPilihBarang";
            lblPilihBarang.Size = new Size(76, 15);
            lblPilihBarang.TabIndex = 3;
            lblPilihBarang.Text = "Pilih Produk";
            // 
            // cmbBarang
            // 
            cmbBarang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbBarang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBarang.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBarang.Font = new Font("Inter", 10F);
            cmbBarang.FormattingEnabled = true;
            cmbBarang.Location = new Point(30, 105);
            cmbBarang.Name = "cmbBarang";
            cmbBarang.Size = new Size(280, 24);
            cmbBarang.TabIndex = 4;
            // 
            // lblJumlah
            // 
            lblJumlah.AutoSize = true;
            lblJumlah.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblJumlah.ForeColor = Color.FromArgb(75, 85, 99);
            lblJumlah.Location = new Point(325, 85);
            lblJumlah.Name = "lblJumlah";
            lblJumlah.Size = new Size(49, 15);
            lblJumlah.TabIndex = 5;
            lblJumlah.Text = "Jumlah";
            // 
            // nudJumlah
            // 
            nudJumlah.Font = new Font("Inter", 10F);
            nudJumlah.Location = new Point(325, 105);
            nudJumlah.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudJumlah.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudJumlah.Name = "nudJumlah";
            nudJumlah.Size = new Size(75, 24);
            nudJumlah.TabIndex = 6;
            nudJumlah.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnTambahKeranjang
            // 
            btnTambahKeranjang.BackColor = Color.FromArgb(255, 196, 0);
            btnTambahKeranjang.Cursor = Cursors.Hand;
            btnTambahKeranjang.FlatAppearance.BorderSize = 0;
            btnTambahKeranjang.FlatStyle = FlatStyle.Flat;
            btnTambahKeranjang.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnTambahKeranjang.ForeColor = Color.FromArgb(31, 41, 55);
            btnTambahKeranjang.Location = new Point(415, 103);
            btnTambahKeranjang.Name = "btnTambahKeranjang";
            btnTambahKeranjang.Size = new Size(85, 28);
            btnTambahKeranjang.TabIndex = 7;
            btnTambahKeranjang.Text = "+ Tambah";
            btnTambahKeranjang.UseVisualStyleBackColor = false;
            // 
            // btnHapusKeranjang
            // 
            btnHapusKeranjang.BackColor = Color.White;
            btnHapusKeranjang.Cursor = Cursors.Hand;
            btnHapusKeranjang.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnHapusKeranjang.FlatStyle = FlatStyle.Flat;
            btnHapusKeranjang.Font = new Font("Inter", 9F);
            btnHapusKeranjang.ForeColor = Color.FromArgb(220, 38, 38);
            btnHapusKeranjang.Location = new Point(505, 103);
            btnHapusKeranjang.Name = "btnHapusKeranjang";
            btnHapusKeranjang.Size = new Size(70, 28);
            btnHapusKeranjang.TabIndex = 8;
            btnHapusKeranjang.Text = "Hapus";
            btnHapusKeranjang.UseVisualStyleBackColor = false;
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
            dataGridViewCellStyle1.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridKeranjang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridKeranjang.ColumnHeadersHeight = 32;
            gridKeranjang.Columns.AddRange(new DataGridViewColumn[] { colKode, colNama, colHarga, colQty, colSubtotal });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Inter", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridKeranjang.DefaultCellStyle = dataGridViewCellStyle2;
            gridKeranjang.EnableHeadersVisualStyles = false;
            gridKeranjang.Location = new Point(30, 145);
            gridKeranjang.MultiSelect = false;
            gridKeranjang.Name = "gridKeranjang";
            gridKeranjang.ReadOnly = true;
            gridKeranjang.RowHeadersVisible = false;
            gridKeranjang.RowTemplate.Height = 28;
            gridKeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKeranjang.Size = new Size(545, 500);
            gridKeranjang.TabIndex = 9;
            // 
            // colKode
            // 
            colKode.DataPropertyName = "KodeBarang";
            colKode.FillWeight = 75F;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.DataPropertyName = "NamaBarang";
            colNama.FillWeight = 160F;
            colNama.HeaderText = "Nama Barang";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.DataPropertyName = "HargaFormat";
            colHarga.FillWeight = 90F;
            colHarga.HeaderText = "Harga (Rp)";
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colQty
            // 
            colQty.DataPropertyName = "Jumlah";
            colQty.FillWeight = 50F;
            colQty.HeaderText = "Qty";
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            // 
            // colSubtotal
            // 
            colSubtotal.DataPropertyName = "SubtotalFormat";
            colSubtotal.FillWeight = 95F;
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            // 
            // pnlCheckout
            // 
            pnlCheckout.BackColor = Color.White;
            pnlCheckout.BorderStyle = BorderStyle.FixedSingle;
            pnlCheckout.Controls.Add(lblRingkasan);
            pnlCheckout.Controls.Add(lblTotalLabel);
            pnlCheckout.Controls.Add(lblTotalNilai);
            pnlCheckout.Controls.Add(lblBayarLabel);
            pnlCheckout.Controls.Add(nudBayar);
            pnlCheckout.Controls.Add(lblKembalianLabel);
            pnlCheckout.Controls.Add(lblKembalianNilai);
            pnlCheckout.Controls.Add(btnProsesBayar);
            pnlCheckout.Controls.Add(btnBatalKeranjang);
            pnlCheckout.Location = new Point(595, 145);
            pnlCheckout.Name = "pnlCheckout";
            pnlCheckout.Size = new Size(250, 500);
            pnlCheckout.TabIndex = 10;
            // 
            // lblRingkasan
            // 
            lblRingkasan.AutoSize = true;
            lblRingkasan.Font = new Font("Inter", 12F, FontStyle.Bold);
            lblRingkasan.ForeColor = Color.FromArgb(31, 41, 55);
            lblRingkasan.Location = new Point(16, 16);
            lblRingkasan.Name = "lblRingkasan";
            lblRingkasan.Size = new Size(193, 20);
            lblRingkasan.TabIndex = 0;
            lblRingkasan.Text = "Ringkasan Pembayaran";
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Inter", 9F);
            lblTotalLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalLabel.Location = new Point(16, 60);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(83, 15);
            lblTotalLabel.TabIndex = 1;
            lblTotalLabel.Text = "Total Belanja:";
            // 
            // lblTotalNilai
            // 
            lblTotalNilai.AutoSize = true;
            lblTotalNilai.Font = new Font("Inter", 18F, FontStyle.Bold);
            lblTotalNilai.ForeColor = Color.FromArgb(16, 149, 102);
            lblTotalNilai.Location = new Point(16, 80);
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
            lblBayarLabel.Location = new Point(16, 140);
            lblBayarLabel.Name = "lblBayarLabel";
            lblBayarLabel.Size = new Size(123, 15);
            lblBayarLabel.TabIndex = 3;
            lblBayarLabel.Text = "Uang Diterima (Rp):";
            // 
            // nudBayar
            // 
            nudBayar.Font = new Font("Inter", 11F, FontStyle.Bold);
            nudBayar.Location = new Point(16, 165);
            nudBayar.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudBayar.Name = "nudBayar";
            nudBayar.Size = new Size(215, 25);
            nudBayar.TabIndex = 4;
            nudBayar.ThousandsSeparator = true;
            // 
            // lblKembalianLabel
            // 
            lblKembalianLabel.AutoSize = true;
            lblKembalianLabel.Font = new Font("Inter", 9F);
            lblKembalianLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblKembalianLabel.Location = new Point(16, 215);
            lblKembalianLabel.Name = "lblKembalianLabel";
            lblKembalianLabel.Size = new Size(70, 15);
            lblKembalianLabel.TabIndex = 5;
            lblKembalianLabel.Text = "Kembalian:";
            // 
            // lblKembalianNilai
            // 
            lblKembalianNilai.AutoSize = true;
            lblKembalianNilai.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblKembalianNilai.ForeColor = Color.FromArgb(31, 41, 55);
            lblKembalianNilai.Location = new Point(16, 235);
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
            btnProsesBayar.Font = new Font("Inter", 11F, FontStyle.Bold);
            btnProsesBayar.ForeColor = Color.FromArgb(31, 41, 55);
            btnProsesBayar.Location = new Point(16, 320);
            btnProsesBayar.Name = "btnProsesBayar";
            btnProsesBayar.Size = new Size(215, 48);
            btnProsesBayar.TabIndex = 7;
            btnProsesBayar.Text = "PROSES TRANSAKSI";
            btnProsesBayar.UseVisualStyleBackColor = false;
            // 
            // btnBatalKeranjang
            // 
            btnBatalKeranjang.BackColor = Color.White;
            btnBatalKeranjang.Cursor = Cursors.Hand;
            btnBatalKeranjang.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatalKeranjang.FlatStyle = FlatStyle.Flat;
            btnBatalKeranjang.Font = new Font("Inter", 9.5F);
            btnBatalKeranjang.ForeColor = Color.FromArgb(107, 114, 128);
            btnBatalKeranjang.Location = new Point(16, 380);
            btnBatalKeranjang.Name = "btnBatalKeranjang";
            btnBatalKeranjang.Size = new Size(215, 36);
            btnBatalKeranjang.TabIndex = 8;
            btnBatalKeranjang.Text = "Kosongkan Keranjang";
            btnBatalKeranjang.UseVisualStyleBackColor = false;
            // 
            // FormKasir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 680);
            Controls.Add(pnlKanan);
            Controls.Add(pnlKiri);
            FormBorderStyle = FormBorderStyle.None;
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
        private Label lblJudul;
        private Label lblPilihBarang;
        private ComboBox cmbBarang;
        private Label lblJumlah;
        private NumericUpDown nudJumlah;
        private Button btnTambahKeranjang;
        private Button btnHapusKeranjang;
        private DataGridView gridKeranjang;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colSubtotal;
        private Panel pnlCheckout;
        private Label lblRingkasan;
        private Label lblTotalLabel;
        private Label lblTotalNilai;
        private Label lblBayarLabel;
        private NumericUpDown nudBayar;
        private Label lblKembalianLabel;
        private Label lblKembalianNilai;
        private Button btnProsesBayar;
        private Button btnBatalKeranjang;
    }
}
