namespace Sukimart
{
    partial class FormTambahBarang
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
            lblJudul = new Label();
            lblKode = new Label();
            txtKode = new TextBox();
            lblNama = new Label();
            txtNama = new TextBox();
            lblKategori = new Label();
            cmbKategori = new ComboBox();
            btnKelolaKategori = new Button();
            lblHargaBeli = new Label();
            nudHargaBeli = new NumericUpDown();
            lblHarga = new Label();
            nudHarga = new NumericUpDown();
            lblStokMin = new Label();
            nudStokMinimum = new NumericUpDown();
            lblInfo = new Label();
            btnBatal = new Button();
            btnSimpan = new Button();
            ((System.ComponentModel.ISupportInitialize)nudHargaBeli).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStokMinimum).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.BackColor = Color.Transparent;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(24, 24);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(130, 23);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Tambah Item";
            // 
            // lblKode
            // 
            lblKode.AutoSize = true;
            lblKode.BackColor = Color.Transparent;
            lblKode.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKode.ForeColor = Color.FromArgb(75, 85, 99);
            lblKode.Location = new Point(24, 72);
            lblKode.Name = "lblKode";
            lblKode.Size = new Size(84, 15);
            lblKode.TabIndex = 1;
            lblKode.Text = "Kode Barang";
            // 
            // txtKode
            // 
            txtKode.BackColor = Color.White;
            txtKode.Font = new Font("Inter", 10F);
            txtKode.ForeColor = Color.FromArgb(31, 41, 55);
            txtKode.Location = new Point(24, 92);
            txtKode.Name = "txtKode";
            txtKode.Size = new Size(432, 24);
            txtKode.TabIndex = 2;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.BackColor = Color.Transparent;
            lblNama.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblNama.ForeColor = Color.FromArgb(75, 85, 99);
            lblNama.Location = new Point(24, 132);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(88, 15);
            lblNama.TabIndex = 3;
            lblNama.Text = "Nama Barang";
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.White;
            txtNama.Font = new Font("Inter", 10F);
            txtNama.ForeColor = Color.FromArgb(31, 41, 55);
            txtNama.Location = new Point(24, 152);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(432, 24);
            txtNama.TabIndex = 4;
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.BackColor = Color.Transparent;
            lblKategori.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblKategori.ForeColor = Color.FromArgb(75, 85, 99);
            lblKategori.Location = new Point(24, 192);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(57, 15);
            lblKategori.TabIndex = 5;
            lblKategori.Text = "Kategori";
            // 
            // cmbKategori
            // 
            cmbKategori.BackColor = Color.White;
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.Font = new Font("Inter", 10F);
            cmbKategori.ForeColor = Color.FromArgb(31, 41, 55);
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(24, 212);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(288, 24);
            cmbKategori.TabIndex = 6;
            // 
            // btnKelolaKategori
            // 
            btnKelolaKategori.BackColor = Color.White;
            btnKelolaKategori.Cursor = Cursors.Hand;
            btnKelolaKategori.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnKelolaKategori.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnKelolaKategori.FlatStyle = FlatStyle.Flat;
            btnKelolaKategori.Font = new Font("Inter", 9F);
            btnKelolaKategori.ForeColor = Color.FromArgb(55, 65, 81);
            btnKelolaKategori.Location = new Point(328, 211);
            btnKelolaKategori.Name = "btnKelolaKategori";
            btnKelolaKategori.Size = new Size(128, 27);
            btnKelolaKategori.TabIndex = 7;
            btnKelolaKategori.Text = "Kelola Kategori";
            btnKelolaKategori.UseVisualStyleBackColor = false;
            btnKelolaKategori.Click += btnKelolaKategori_Click;
            // 
            // lblHargaBeli
            // 
            lblHargaBeli.AutoSize = true;
            lblHargaBeli.BackColor = Color.Transparent;
            lblHargaBeli.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblHargaBeli.ForeColor = Color.FromArgb(75, 85, 99);
            lblHargaBeli.Location = new Point(24, 252);
            lblHargaBeli.Name = "lblHargaBeli";
            lblHargaBeli.Size = new Size(95, 15);
            lblHargaBeli.TabIndex = 8;
            lblHargaBeli.Text = "Harga Beli (Rp)";
            // 
            // nudHargaBeli
            // 
            nudHargaBeli.BackColor = Color.White;
            nudHargaBeli.Font = new Font("Inter", 10F);
            nudHargaBeli.ForeColor = Color.FromArgb(31, 41, 55);
            nudHargaBeli.Location = new Point(24, 272);
            nudHargaBeli.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudHargaBeli.Name = "nudHargaBeli";
            nudHargaBeli.Size = new Size(208, 24);
            nudHargaBeli.TabIndex = 9;
            nudHargaBeli.ThousandsSeparator = true;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.BackColor = Color.Transparent;
            lblHarga.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblHarga.ForeColor = Color.FromArgb(75, 85, 99);
            lblHarga.Location = new Point(248, 252);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(98, 15);
            lblHarga.TabIndex = 10;
            lblHarga.Text = "Harga Jual (Rp)";
            // 
            // nudHarga
            // 
            nudHarga.BackColor = Color.White;
            nudHarga.Font = new Font("Inter", 10F);
            nudHarga.ForeColor = Color.FromArgb(31, 41, 55);
            nudHarga.Location = new Point(248, 272);
            nudHarga.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudHarga.Name = "nudHarga";
            nudHarga.Size = new Size(208, 24);
            nudHarga.TabIndex = 11;
            nudHarga.ThousandsSeparator = true;
            // 
            // lblStokMin
            // 
            lblStokMin.AutoSize = true;
            lblStokMin.BackColor = Color.Transparent;
            lblStokMin.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblStokMin.ForeColor = Color.FromArgb(75, 85, 99);
            lblStokMin.Location = new Point(24, 312);
            lblStokMin.Name = "lblStokMin";
            lblStokMin.Size = new Size(130, 15);
            lblStokMin.TabIndex = 12;
            lblStokMin.Text = "Batas Stok Minimum";
            // 
            // nudStokMinimum
            // 
            nudStokMinimum.BackColor = Color.White;
            nudStokMinimum.Font = new Font("Inter", 10F);
            nudStokMinimum.ForeColor = Color.FromArgb(31, 41, 55);
            nudStokMinimum.Location = new Point(24, 332);
            nudStokMinimum.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStokMinimum.Name = "nudStokMinimum";
            nudStokMinimum.Size = new Size(208, 24);
            nudStokMinimum.TabIndex = 13;
            nudStokMinimum.ThousandsSeparator = true;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = false;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Inter", 9F);
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(24, 372);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(432, 20);
            lblInfo.TabIndex = 14;
            lblInfo.Text = "Stok awal 0. Tambah stok melalui menu Gudang.";
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.White;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatal.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 244, 204);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Inter", 10F);
            btnBatal.ForeColor = Color.FromArgb(55, 65, 81);
            btnBatal.Location = new Point(200, 416);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(120, 40);
            btnBatal.TabIndex = 16;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(255, 196, 0);
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 210, 64);
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnSimpan.ForeColor = Color.FromArgb(31, 41, 55);
            btnSimpan.Location = new Point(336, 416);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(120, 40);
            btnSimpan.TabIndex = 15;
            btnSimpan.Text = "Tambah Item";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // FormTambahBarang
            // 
            AcceptButton = btnSimpan;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            CancelButton = btnBatal;
            ClientSize = new Size(480, 480);
            Controls.Add(lblJudul);
            Controls.Add(lblKode);
            Controls.Add(txtKode);
            Controls.Add(lblNama);
            Controls.Add(txtNama);
            Controls.Add(lblKategori);
            Controls.Add(cmbKategori);
            Controls.Add(btnKelolaKategori);
            Controls.Add(lblHargaBeli);
            Controls.Add(nudHargaBeli);
            Controls.Add(lblHarga);
            Controls.Add(nudHarga);
            Controls.Add(lblStokMin);
            Controls.Add(nudStokMinimum);
            Controls.Add(lblInfo);
            Controls.Add(btnBatal);
            Controls.Add(btnSimpan);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTambahBarang";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tambah Item";
            Paint += FormTambahBarang_Paint;
            ((System.ComponentModel.ISupportInitialize)nudHargaBeli).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStokMinimum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblJudul;
        private Label lblKode;
        private TextBox txtKode;
        private Label lblNama;
        private TextBox txtNama;
        private Label lblKategori;
        private ComboBox cmbKategori;
        private Button btnKelolaKategori;
        private Label lblHargaBeli;
        private NumericUpDown nudHargaBeli;
        private Label lblHarga;
        private NumericUpDown nudHarga;
        private Label lblStokMin;
        private NumericUpDown nudStokMinimum;
        private Label lblInfo;
        private Button btnBatal;
        private Button btnSimpan;
    }
}
