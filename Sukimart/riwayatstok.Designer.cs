namespace Sukimart
{
    partial class FormRiwayatStok
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
            DataGridViewCellStyle gayaJudulKolom = new DataGridViewCellStyle();
            DataGridViewCellStyle gayaSel = new DataGridViewCellStyle();
            lblJudul = new Label();
            lblInfo = new Label();
            gridRiwayat = new DataGridView();
            colTanggal = new DataGridViewTextBoxColumn();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colJenis = new DataGridViewTextBoxColumn();
            colJumlah = new DataGridViewTextBoxColumn();
            colStokAkhir = new DataGridViewTextBoxColumn();
            colKeterangan = new DataGridViewTextBoxColumn();
            colPengguna = new DataGridViewTextBoxColumn();
            btnTutup = new Button();
            ((System.ComponentModel.ISupportInitialize)gridRiwayat).BeginInit();
            SuspendLayout();
            lblJudul.AutoSize = true;
            lblJudul.BackColor = Color.Transparent;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(24, 24);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(130, 24);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Riwayat Stok";
            gridRiwayat.AllowUserToAddRows = false;
            gridRiwayat.AllowUserToDeleteRows = false;
            gridRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRiwayat.BackgroundColor = Color.White;
            gridRiwayat.BorderStyle = BorderStyle.None;
            gridRiwayat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridRiwayat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gayaJudulKolom.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gayaJudulKolom.BackColor = Color.FromArgb(243, 244, 246);
            gayaJudulKolom.Font = new Font("Inter", 9F, FontStyle.Bold);
            gayaJudulKolom.ForeColor = Color.FromArgb(55, 65, 81);
            gayaJudulKolom.SelectionBackColor = Color.FromArgb(243, 244, 246);
            gayaJudulKolom.SelectionForeColor = Color.FromArgb(55, 65, 81);
            gayaJudulKolom.WrapMode = DataGridViewTriState.True;
            gridRiwayat.ColumnHeadersDefaultCellStyle = gayaJudulKolom;
            gridRiwayat.ColumnHeadersHeight = 40;
            gridRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridRiwayat.Columns.AddRange(new DataGridViewColumn[] { colTanggal, colKode, colNama, colJenis, colJumlah, colStokAkhir, colKeterangan, colPengguna });
            gayaSel.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gayaSel.BackColor = Color.White;
            gayaSel.Font = new Font("Inter", 10F);
            gayaSel.ForeColor = Color.FromArgb(31, 41, 55);
            gayaSel.SelectionBackColor = Color.FromArgb(255, 244, 204);
            gayaSel.SelectionForeColor = Color.FromArgb(31, 41, 55);
            gayaSel.WrapMode = DataGridViewTriState.False;
            gridRiwayat.DefaultCellStyle = gayaSel;
            gridRiwayat.EnableHeadersVisualStyles = false;
            gridRiwayat.GridColor = Color.FromArgb(229, 231, 235);
            gridRiwayat.Location = new Point(24, 68);
            gridRiwayat.MultiSelect = false;
            gridRiwayat.Name = "gridRiwayat";
            gridRiwayat.ReadOnly = true;
            gridRiwayat.RowHeadersVisible = false;
            gridRiwayat.RowTemplate.Height = 36;
            gridRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRiwayat.Size = new Size(832, 404);
            gridRiwayat.TabIndex = 1;
            colTanggal.DataPropertyName = "Tanggal";
            colTanggal.FillWeight = 150F;
            colTanggal.HeaderText = "Tanggal";
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            colKode.DataPropertyName = "KodeBarang";
            colKode.FillWeight = 76F;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.ReadOnly = true;
            colNama.DataPropertyName = "NamaBarang";
            colNama.FillWeight = 160F;
            colNama.HeaderText = "Nama Barang";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            colJenis.DataPropertyName = "Jenis";
            colJenis.FillWeight = 96F;
            colJenis.HeaderText = "Jenis";
            colJenis.Name = "colJenis";
            colJenis.ReadOnly = true;
            colJumlah.DataPropertyName = "JumlahFormat";
            colJumlah.FillWeight = 72F;
            colJumlah.HeaderText = "Jumlah";
            colJumlah.Name = "colJumlah";
            colJumlah.ReadOnly = true;
            colStokAkhir.DataPropertyName = "StokSesudah";
            colStokAkhir.FillWeight = 96F;
            colStokAkhir.HeaderText = "Stok Akhir";
            colStokAkhir.Name = "colStokAkhir";
            colStokAkhir.ReadOnly = true;
            colKeterangan.DataPropertyName = "Keterangan";
            colKeterangan.FillWeight = 140F;
            colKeterangan.HeaderText = "Keterangan";
            colKeterangan.Name = "colKeterangan";
            colKeterangan.ReadOnly = true;
            colPengguna.DataPropertyName = "Pengguna";
            colPengguna.FillWeight = 64F;
            colPengguna.HeaderText = "Oleh";
            colPengguna.Name = "colPengguna";
            colPengguna.ReadOnly = true;
            lblInfo.AutoSize = true;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Inter", 9F);
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(24, 500);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(80, 15);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "0 catatan";
            btnTutup.BackColor = Color.White;
            btnTutup.Cursor = Cursors.Hand;
            btnTutup.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.Font = new Font("Inter", 10F);
            btnTutup.ForeColor = Color.FromArgb(55, 65, 81);
            btnTutup.Location = new Point(688, 488);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(168, 40);
            btnTutup.TabIndex = 2;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            ClientSize = new Size(880, 552);
            Controls.Add(lblJudul);
            Controls.Add(gridRiwayat);
            Controls.Add(btnTutup);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRiwayatStok";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Riwayat Stok";
            ((System.ComponentModel.ISupportInitialize)gridRiwayat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblJudul;
        private Label lblInfo;
        private DataGridView gridRiwayat;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colJenis;
        private DataGridViewTextBoxColumn colJumlah;
        private DataGridViewTextBoxColumn colStokAkhir;
        private DataGridViewTextBoxColumn colKeterangan;
        private DataGridViewTextBoxColumn colPengguna;
        private Button btnTutup;
    }
}
