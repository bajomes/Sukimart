namespace Sukimart
{
    partial class FormDetailOpname
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
            pnlHeader = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            lblJudul = new Label();
            lblNomorOpname = new Label();
            lblTanggal = new Label();
            lblPembuat = new Label();
            lblStatusBadge = new Label();
            pnlBanner = new Panel();
            lblBannerText = new Label();
            txtCari = new TextBox();
            chkHanyaSelisih = new CheckBox();
            lblProgresHitung = new Label();
            gridDetail = new DataGridView();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colStokSistem = new DataGridViewTextBoxColumn();
            colStokFisik = new DataGridViewTextBoxColumn();
            colSelisih = new DataGridViewTextBoxColumn();
            colKeterangan = new DataGridViewTextBoxColumn();
            colAlasanRevisi = new DataGridViewTextBoxColumn();
            pnlBawah = new Panel();
            lblTotalProduk = new Label();
            lblProdukSelisih = new Label();
            lblTotalPlus = new Label();
            lblTotalMinus = new Label();
            btnSimpanDraft = new Button();
            btnAjukan = new Button();
            btnSetujui = new Button();
            btnMintaRevisi = new Button();
            btnBatalkan = new Button();
            btnRiwayatRevisi = new Button();
            btnKembali = new Button();
            pnlHeader.SuspendLayout();
            pnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDetail).BeginInit();
            pnlBawah.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(nightControlBox1);
            pnlHeader.Controls.Add(lblJudul);
            pnlHeader.Controls.Add(lblNomorOpname);
            pnlHeader.Controls.Add(lblTanggal);
            pnlHeader.Controls.Add(lblPembuat);
            pnlHeader.Controls.Add(lblStatusBadge);
            pnlHeader.Controls.Add(pnlBanner);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 115);
            pnlHeader.TabIndex = 0;
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
            nightControlBox1.Location = new Point(961, 0);
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
            lblJudul.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(24, 16);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(328, 26);
            lblJudul.TabIndex = 1;
            lblJudul.Text = "Hasil Penghitungan Stok Opname";
            // 
            // lblNomorOpname
            // 
            lblNomorOpname.AutoSize = true;
            lblNomorOpname.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblNomorOpname.ForeColor = Color.FromArgb(55, 65, 81);
            lblNomorOpname.Location = new Point(24, 48);
            lblNomorOpname.Name = "lblNomorOpname";
            lblNomorOpname.Size = new Size(111, 16);
            lblNomorOpname.TabIndex = 2;
            lblNomorOpname.Text = "Nomor: OP001";
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Font = new Font("Inter", 9.5F);
            lblTanggal.ForeColor = Color.FromArgb(107, 114, 128);
            lblTanggal.Location = new Point(170, 48);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(160, 16);
            lblTanggal.TabIndex = 3;
            lblTanggal.Text = "Tanggal: 23/11/2026 18:30";
            // 
            // lblPembuat
            // 
            lblPembuat.AutoSize = true;
            lblPembuat.Font = new Font("Inter", 9.5F);
            lblPembuat.ForeColor = Color.FromArgb(107, 114, 128);
            lblPembuat.Location = new Point(360, 48);
            lblPembuat.Name = "lblPembuat";
            lblPembuat.Size = new Size(134, 16);
            lblPembuat.TabIndex = 4;
            lblPembuat.Text = "Dibuat Oleh: gudang1";
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.AutoSize = true;
            lblStatusBadge.BackColor = Color.FromArgb(254, 243, 199);
            lblStatusBadge.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblStatusBadge.ForeColor = Color.FromArgb(180, 83, 9);
            lblStatusBadge.Location = new Point(530, 46);
            lblStatusBadge.Padding = new Padding(8, 4, 8, 4);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Size = new Size(67, 23);
            lblStatusBadge.TabIndex = 5;
            lblStatusBadge.Text = "DRAFT";
            // 
            // pnlBanner
            // 
            pnlBanner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBanner.BackColor = Color.FromArgb(249, 250, 251);
            pnlBanner.Controls.Add(lblBannerText);
            pnlBanner.Location = new Point(24, 76);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new Size(1052, 28);
            pnlBanner.TabIndex = 6;
            // 
            // lblBannerText
            // 
            lblBannerText.AutoSize = true;
            lblBannerText.Font = new Font("Inter", 8.5F);
            lblBannerText.ForeColor = Color.FromArgb(75, 85, 99);
            lblBannerText.Location = new Point(8, 6);
            lblBannerText.Name = "lblBannerText";
            lblBannerText.Size = new Size(590, 15);
            lblBannerText.TabIndex = 0;
            lblBannerText.Text = "Isi nilai stok fisik berdasarkan penghitungan riil. Selisih dan status akan dihitung secara otomatis.";
            // 
            // txtCari
            // 
            txtCari.BorderStyle = BorderStyle.FixedSingle;
            txtCari.Font = new Font("Inter", 9.5F);
            txtCari.Location = new Point(24, 126);
            txtCari.Name = "txtCari";
            txtCari.PlaceholderText = "Cari kode atau nama produk...";
            txtCari.Size = new Size(320, 23);
            txtCari.TabIndex = 1;
            // 
            // chkHanyaSelisih
            // 
            chkHanyaSelisih.AutoSize = true;
            chkHanyaSelisih.Cursor = Cursors.Hand;
            chkHanyaSelisih.Font = new Font("Inter", 9F);
            chkHanyaSelisih.ForeColor = Color.FromArgb(55, 65, 81);
            chkHanyaSelisih.Location = new Point(360, 128);
            chkHanyaSelisih.Name = "chkHanyaSelisih";
            chkHanyaSelisih.Size = new Size(198, 19);
            chkHanyaSelisih.TabIndex = 2;
            chkHanyaSelisih.Text = "Hanya tampilkan yang berselisih";
            chkHanyaSelisih.UseVisualStyleBackColor = true;
            // 
            // lblProgresHitung
            // 
            lblProgresHitung.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProgresHitung.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblProgresHitung.ForeColor = Color.FromArgb(75, 85, 99);
            lblProgresHitung.Location = new Point(720, 128);
            lblProgresHitung.Name = "lblProgresHitung";
            lblProgresHitung.Size = new Size(356, 18);
            lblProgresHitung.TabIndex = 3;
            lblProgresHitung.Text = "Progres: 0 / 0 Produk (0%)";
            lblProgresHitung.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gridDetail
            // 
            gridDetail.AllowUserToAddRows = false;
            gridDetail.AllowUserToDeleteRows = false;
            gridDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDetail.BackgroundColor = Color.White;
            gridDetail.BorderStyle = BorderStyle.None;
            gridDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridDetail.ColumnHeadersHeight = 38;
            gridDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridDetail.Columns.AddRange(new DataGridViewColumn[] { colKode, colNama, colStokSistem, colStokFisik, colSelisih, colKeterangan, colAlasanRevisi });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Inter", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(254, 243, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridDetail.DefaultCellStyle = dataGridViewCellStyle2;
            gridDetail.EnableHeadersVisualStyles = false;
            gridDetail.GridColor = Color.FromArgb(229, 231, 235);
            gridDetail.Location = new Point(24, 160);
            gridDetail.MultiSelect = false;
            gridDetail.Name = "gridDetail";
            gridDetail.RowHeadersVisible = false;
            gridDetail.RowTemplate.Height = 34;
            gridDetail.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridDetail.Size = new Size(1052, 450);
            gridDetail.TabIndex = 4;
            // 
            // colKode
            // 
            colKode.FillWeight = 75F;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.FillWeight = 160F;
            colNama.HeaderText = "Nama Produk";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            // 
            // colStokSistem
            // 
            colStokSistem.FillWeight = 70F;
            colStokSistem.HeaderText = "Stok Sistem";
            colStokSistem.Name = "colStokSistem";
            colStokSistem.ReadOnly = true;
            // 
            // colStokFisik
            // 
            colStokFisik.FillWeight = 75F;
            colStokFisik.HeaderText = "Stok Fisik";
            colStokFisik.Name = "colStokFisik";
            // 
            // colSelisih
            // 
            colSelisih.FillWeight = 70F;
            colSelisih.HeaderText = "Selisih";
            colSelisih.Name = "colSelisih";
            colSelisih.ReadOnly = true;
            // 
            // colKeterangan
            // 
            colKeterangan.FillWeight = 140F;
            colKeterangan.HeaderText = "Keterangan";
            colKeterangan.Name = "colKeterangan";
            // 
            // colAlasanRevisi
            // 
            colAlasanRevisi.FillWeight = 140F;
            colAlasanRevisi.HeaderText = "Catatan Revisi Admin";
            colAlasanRevisi.Name = "colAlasanRevisi";
            colAlasanRevisi.ReadOnly = true;
            // 
            // pnlBawah
            // 
            pnlBawah.BackColor = Color.White;
            pnlBawah.Controls.Add(lblTotalProduk);
            pnlBawah.Controls.Add(lblProdukSelisih);
            pnlBawah.Controls.Add(lblTotalPlus);
            pnlBawah.Controls.Add(lblTotalMinus);
            pnlBawah.Controls.Add(btnSimpanDraft);
            pnlBawah.Controls.Add(btnAjukan);
            pnlBawah.Controls.Add(btnSetujui);
            pnlBawah.Controls.Add(btnMintaRevisi);
            pnlBawah.Controls.Add(btnBatalkan);
            pnlBawah.Controls.Add(btnRiwayatRevisi);
            pnlBawah.Controls.Add(btnKembali);
            pnlBawah.Dock = DockStyle.Bottom;
            pnlBawah.Location = new Point(0, 620);
            pnlBawah.Name = "pnlBawah";
            pnlBawah.Size = new Size(1100, 70);
            pnlBawah.TabIndex = 5;
            // 
            // lblTotalProduk
            // 
            lblTotalProduk.AutoSize = true;
            lblTotalProduk.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblTotalProduk.ForeColor = Color.FromArgb(55, 65, 81);
            lblTotalProduk.Location = new Point(24, 14);
            lblTotalProduk.Name = "lblTotalProduk";
            lblTotalProduk.Size = new Size(100, 15);
            lblTotalProduk.TabIndex = 0;
            lblTotalProduk.Text = "Total Produk: 0";
            // 
            // lblProdukSelisih
            // 
            lblProdukSelisih.AutoSize = true;
            lblProdukSelisih.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblProdukSelisih.ForeColor = Color.FromArgb(217, 119, 6);
            lblProdukSelisih.Location = new Point(24, 38);
            lblProdukSelisih.Name = "lblProdukSelisih";
            lblProdukSelisih.Size = new Size(105, 15);
            lblProdukSelisih.TabIndex = 1;
            lblProdukSelisih.Text = "Produk Selisih: 0";
            // 
            // lblTotalPlus
            // 
            lblTotalPlus.AutoSize = true;
            lblTotalPlus.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblTotalPlus.ForeColor = Color.FromArgb(16, 149, 102);
            lblTotalPlus.Location = new Point(160, 14);
            lblTotalPlus.Name = "lblTotalPlus";
            lblTotalPlus.Size = new Size(107, 15);
            lblTotalPlus.TabIndex = 2;
            lblTotalPlus.Text = "Selisih Lebih (+): 0";
            // 
            // lblTotalMinus
            // 
            lblTotalMinus.AutoSize = true;
            lblTotalMinus.Font = new Font("Inter", 8.5F, FontStyle.Bold);
            lblTotalMinus.ForeColor = Color.FromArgb(220, 38, 38);
            lblTotalMinus.Location = new Point(160, 38);
            lblTotalMinus.Name = "lblTotalMinus";
            lblTotalMinus.Size = new Size(117, 15);
            lblTotalMinus.TabIndex = 3;
            lblTotalMinus.Text = "Selisih Kurang (-): 0";
            // 
            // btnKembali
            // 
            btnKembali.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKembali.BackColor = Color.White;
            btnKembali.Cursor = Cursors.Hand;
            btnKembali.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnKembali.ForeColor = Color.FromArgb(75, 85, 99);
            btnKembali.Location = new Point(980, 17);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(96, 36);
            btnKembali.TabIndex = 10;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            // 
            // btnRiwayatRevisi
            // 
            btnRiwayatRevisi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRiwayatRevisi.BackColor = Color.White;
            btnRiwayatRevisi.Cursor = Cursors.Hand;
            btnRiwayatRevisi.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnRiwayatRevisi.FlatStyle = FlatStyle.Flat;
            btnRiwayatRevisi.Font = new Font("Inter", 9F);
            btnRiwayatRevisi.ForeColor = Color.FromArgb(55, 65, 81);
            btnRiwayatRevisi.Location = new Point(840, 17);
            btnRiwayatRevisi.Name = "btnRiwayatRevisi";
            btnRiwayatRevisi.Size = new Size(130, 36);
            btnRiwayatRevisi.TabIndex = 9;
            btnRiwayatRevisi.Text = "Riwayat Revisi";
            btnRiwayatRevisi.UseVisualStyleBackColor = false;
            // 
            // btnBatalkan
            // 
            btnBatalkan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBatalkan.BackColor = Color.White;
            btnBatalkan.Cursor = Cursors.Hand;
            btnBatalkan.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnBatalkan.FlatStyle = FlatStyle.Flat;
            btnBatalkan.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnBatalkan.ForeColor = Color.FromArgb(220, 38, 38);
            btnBatalkan.Location = new Point(710, 17);
            btnBatalkan.Name = "btnBatalkan";
            btnBatalkan.Size = new Size(120, 36);
            btnBatalkan.TabIndex = 8;
            btnBatalkan.Text = "Batalkan Sesi";
            btnBatalkan.UseVisualStyleBackColor = false;
            // 
            // btnMintaRevisi
            // 
            btnMintaRevisi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMintaRevisi.BackColor = Color.FromArgb(245, 158, 11);
            btnMintaRevisi.Cursor = Cursors.Hand;
            btnMintaRevisi.FlatAppearance.BorderSize = 0;
            btnMintaRevisi.FlatStyle = FlatStyle.Flat;
            btnMintaRevisi.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnMintaRevisi.ForeColor = Color.White;
            btnMintaRevisi.Location = new Point(570, 17);
            btnMintaRevisi.Name = "btnMintaRevisi";
            btnMintaRevisi.Size = new Size(130, 36);
            btnMintaRevisi.TabIndex = 7;
            btnMintaRevisi.Text = "Minta Revisi";
            btnMintaRevisi.UseVisualStyleBackColor = false;
            // 
            // btnSetujui
            // 
            btnSetujui.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSetujui.BackColor = Color.FromArgb(16, 149, 102);
            btnSetujui.Cursor = Cursors.Hand;
            btnSetujui.FlatAppearance.BorderSize = 0;
            btnSetujui.FlatStyle = FlatStyle.Flat;
            btnSetujui.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnSetujui.ForeColor = Color.White;
            btnSetujui.Location = new Point(420, 17);
            btnSetujui.Name = "btnSetujui";
            btnSetujui.Size = new Size(140, 36);
            btnSetujui.TabIndex = 6;
            btnSetujui.Text = "Setujui Opname";
            btnSetujui.UseVisualStyleBackColor = false;
            // 
            // btnAjukan
            // 
            btnAjukan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAjukan.BackColor = Color.FromArgb(255, 196, 0);
            btnAjukan.Cursor = Cursors.Hand;
            btnAjukan.FlatAppearance.BorderSize = 0;
            btnAjukan.FlatStyle = FlatStyle.Flat;
            btnAjukan.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnAjukan.ForeColor = Color.FromArgb(31, 41, 55);
            btnAjukan.Location = new Point(550, 17);
            btnAjukan.Name = "btnAjukan";
            btnAjukan.Size = new Size(150, 36);
            btnAjukan.TabIndex = 5;
            btnAjukan.Text = "Ajukan Opname";
            btnAjukan.UseVisualStyleBackColor = false;
            // 
            // btnSimpanDraft
            // 
            btnSimpanDraft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSimpanDraft.BackColor = Color.White;
            btnSimpanDraft.Cursor = Cursors.Hand;
            btnSimpanDraft.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnSimpanDraft.FlatStyle = FlatStyle.Flat;
            btnSimpanDraft.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnSimpanDraft.ForeColor = Color.FromArgb(55, 65, 81);
            btnSimpanDraft.Location = new Point(410, 17);
            btnSimpanDraft.Name = "btnSimpanDraft";
            btnSimpanDraft.Size = new Size(130, 36);
            btnSimpanDraft.TabIndex = 4;
            btnSimpanDraft.Text = "Simpan Draft";
            btnSimpanDraft.UseVisualStyleBackColor = false;
            // 
            // FormDetailOpname
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            ClientSize = new Size(1100, 690);
            Controls.Add(pnlBawah);
            Controls.Add(gridDetail);
            Controls.Add(lblProgresHitung);
            Controls.Add(chkHanyaSelisih);
            Controls.Add(txtCari);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetailOpname";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detail Stok Opname";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBanner.ResumeLayout(false);
            pnlBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridDetail).EndInit();
            pnlBawah.ResumeLayout(false);
            pnlBawah.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Label lblJudul;
        private Label lblNomorOpname;
        private Label lblTanggal;
        private Label lblPembuat;
        private Label lblStatusBadge;
        private Panel pnlBanner;
        private Label lblBannerText;
        private TextBox txtCari;
        private CheckBox chkHanyaSelisih;
        private Label lblProgresHitung;
        private DataGridView gridDetail;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colStokSistem;
        private DataGridViewTextBoxColumn colStokFisik;
        private DataGridViewTextBoxColumn colSelisih;
        private DataGridViewTextBoxColumn colKeterangan;
        private DataGridViewTextBoxColumn colAlasanRevisi;
        private Panel pnlBawah;
        private Label lblTotalProduk;
        private Label lblProdukSelisih;
        private Label lblTotalPlus;
        private Label lblTotalMinus;
        private Button btnSimpanDraft;
        private Button btnAjukan;
        private Button btnSetujui;
        private Button btnMintaRevisi;
        private Button btnBatalkan;
        private Button btnRiwayatRevisi;
        private Button btnKembali;
    }
}