namespace Sukimart
{
    partial class FormTambahBarang
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
            lblJudul = new Label();
            lblKode = new Label();
            txtKode = new TextBox();
            lblNama = new Label();
            txtNama = new TextBox();
            lblKategori = new Label();
            cmbKategori = new ComboBox();
            btnKelolaKat = new Button();
            lblHarga = new Label();
            nudHarga = new NumericUpDown();
            lblStok = new Label();
            nudStok = new NumericUpDown();
            lblStokMin = new Label();
            nudStokMinimum = new NumericUpDown();
            btnSimpan = new Button();
            btnBatal = new Button();
            ((System.ComponentModel.ISupportInitialize)nudHarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStokMinimum).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(34, 27);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(260, 35);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Tambah Produk Baru";
            // 
            // lblKode
            // 
            lblKode.AutoSize = true;
            lblKode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKode.ForeColor = Color.FromArgb(75, 85, 99);
            lblKode.Location = new Point(34, 120);
            lblKode.Name = "lblKode";
            lblKode.Size = new Size(110, 20);
            lblKode.TabIndex = 2;
            lblKode.Text = "Kode Barang *";
            // 
            // txtKode
            // 
            txtKode.Font = new Font("Segoe UI", 10F);
            txtKode.Location = new Point(34, 149);
            txtKode.Margin = new Padding(3, 4, 3, 4);
            txtKode.Name = "txtKode";
            txtKode.Size = new Size(502, 30);
            txtKode.TabIndex = 3;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNama.ForeColor = Color.FromArgb(75, 85, 99);
            lblNama.Location = new Point(34, 200);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(116, 20);
            lblNama.TabIndex = 4;
            lblNama.Text = "Nama Barang *";
            // 
            // txtNama
            // 
            txtNama.Font = new Font("Segoe UI", 10F);
            txtNama.Location = new Point(34, 229);
            txtNama.Margin = new Padding(3, 4, 3, 4);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(502, 30);
            txtNama.TabIndex = 5;
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKategori.ForeColor = Color.FromArgb(75, 85, 99);
            lblKategori.Location = new Point(34, 280);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(123, 20);
            lblKategori.TabIndex = 6;
            lblKategori.Text = "Kategori Produk";
            // 
            // cmbKategori
            // 
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.Font = new Font("Segoe UI", 10F);
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(34, 309);
            cmbKategori.Margin = new Padding(3, 4, 3, 4);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(377, 31);
            cmbKategori.TabIndex = 7;
            // 
            // btnKelolaKat
            // 
            btnKelolaKat.BackColor = Color.White;
            btnKelolaKat.Cursor = Cursors.Hand;
            btnKelolaKat.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnKelolaKat.FlatStyle = FlatStyle.Flat;
            btnKelolaKat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKelolaKat.ForeColor = Color.FromArgb(55, 65, 81);
            btnKelolaKat.Location = new Point(423, 308);
            btnKelolaKat.Margin = new Padding(3, 4, 3, 4);
            btnKelolaKat.Name = "btnKelolaKat";
            btnKelolaKat.Size = new Size(114, 37);
            btnKelolaKat.TabIndex = 8;
            btnKelolaKat.Text = "⚙️ Kelola";
            btnKelolaKat.UseVisualStyleBackColor = false;
            btnKelolaKat.Click += BtnKelolaKat_Click;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHarga.ForeColor = Color.FromArgb(75, 85, 99);
            lblHarga.Location = new Point(34, 360);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(129, 20);
            lblHarga.TabIndex = 9;
            lblHarga.Text = "Harga Jual (Rp) *";
            // 
            // nudHarga
            // 
            nudHarga.Font = new Font("Segoe UI", 10F);
            nudHarga.Location = new Point(34, 389);
            nudHarga.Margin = new Padding(3, 4, 3, 4);
            nudHarga.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudHarga.Name = "nudHarga";
            nudHarga.Size = new Size(503, 30);
            nudHarga.TabIndex = 10;
            nudHarga.ThousandsSeparator = true;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStok.ForeColor = Color.FromArgb(75, 85, 99);
            lblStok.Location = new Point(34, 440);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(79, 20);
            lblStok.TabIndex = 11;
            lblStok.Text = "Stok Awal";
            // 
            // nudStok
            // 
            nudStok.Font = new Font("Segoe UI", 10F);
            nudStok.Location = new Point(34, 469);
            nudStok.Margin = new Padding(3, 4, 3, 4);
            nudStok.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStok.Name = "nudStok";
            nudStok.Size = new Size(234, 30);
            nudStok.TabIndex = 12;
            nudStok.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblStokMin
            // 
            lblStokMin.AutoSize = true;
            lblStokMin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStokMin.ForeColor = Color.FromArgb(75, 85, 99);
            lblStokMin.Location = new Point(303, 440);
            lblStokMin.Name = "lblStokMin";
            lblStokMin.Size = new Size(155, 20);
            lblStokMin.TabIndex = 13;
            lblStokMin.Text = "Batas Minimum Stok";
            // 
            // nudStokMinimum
            // 
            nudStokMinimum.Font = new Font("Segoe UI", 10F);
            nudStokMinimum.Location = new Point(303, 469);
            nudStokMinimum.Margin = new Padding(3, 4, 3, 4);
            nudStokMinimum.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStokMinimum.Name = "nudStokMinimum";
            nudStokMinimum.Size = new Size(234, 30);
            nudStokMinimum.TabIndex = 14;
            nudStokMinimum.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(255, 196, 0);
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSimpan.ForeColor = Color.FromArgb(31, 41, 55);
            btnSimpan.Location = new Point(34, 553);
            btnSimpan.Margin = new Padding(3, 4, 3, 4);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(309, 56);
            btnSimpan.TabIndex = 15;
            btnSimpan.Text = "➕ Simpan Barang";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += BtnSimpan_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.White;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBatal.ForeColor = Color.FromArgb(75, 85, 99);
            btnBatal.Location = new Point(360, 553);
            btnBatal.Margin = new Padding(3, 4, 3, 4);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(177, 56);
            btnBatal.TabIndex = 16;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += BtnBatal_Click;
            // 
            // FormTambahBarang
            // 
            AcceptButton = btnSimpan;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            CancelButton = btnBatal;
            ClientSize = new Size(576, 668);
            Controls.Add(btnBatal);
            Controls.Add(btnSimpan);
            Controls.Add(nudStokMinimum);
            Controls.Add(lblStokMin);
            Controls.Add(nudStok);
            Controls.Add(lblStok);
            Controls.Add(nudHarga);
            Controls.Add(lblHarga);
            Controls.Add(btnKelolaKat);
            Controls.Add(cmbKategori);
            Controls.Add(lblKategori);
            Controls.Add(txtNama);
            Controls.Add(lblNama);
            Controls.Add(txtKode);
            Controls.Add(lblKode);
            Controls.Add(lblJudul);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTambahBarang";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tambah Produk Baru - Sukimart";
            ((System.ComponentModel.ISupportInitialize)nudHarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStokMinimum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Label lblKode;
        private TextBox txtKode;
        private Label lblNama;
        private TextBox txtNama;
        private Label lblKategori;
        private ComboBox cmbKategori;
        private Button btnKelolaKat;
        private Label lblHarga;
        private NumericUpDown nudHarga;
        private Label lblStok;
        private NumericUpDown nudStok;
        private Label lblStokMin;
        private NumericUpDown nudStokMinimum;
        private Button btnSimpan;
        private Button btnBatal;
    }
}
