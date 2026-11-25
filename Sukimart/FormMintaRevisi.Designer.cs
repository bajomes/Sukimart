namespace Sukimart
{
    partial class FormMintaRevisi
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
            lblJudul = new Label();
            lblPetunjuk = new Label();
            gridRevisi = new DataGridView();
            colPilih = new DataGridViewCheckBoxColumn();
            colKode = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colStokSistem = new DataGridViewTextBoxColumn();
            colStokFisik = new DataGridViewTextBoxColumn();
            colSelisih = new DataGridViewTextBoxColumn();
            colAlasan = new DataGridViewTextBoxColumn();
            lblInfo = new Label();
            btnBatal = new Button();
            btnKirim = new Button();
            ((System.ComponentModel.ISupportInitialize)gridRevisi).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(217, 119, 6);
            lblJudul.Location = new Point(24, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(318, 23);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Permintaan Revisi Stok Opname";
            // 
            // lblPetunjuk
            // 
            lblPetunjuk.Font = new Font("Inter", 9F);
            lblPetunjuk.ForeColor = Color.FromArgb(75, 85, 99);
            lblPetunjuk.Location = new Point(24, 48);
            lblPetunjuk.Name = "lblPetunjuk";
            lblPetunjuk.Size = new Size(736, 36);
            lblPetunjuk.TabIndex = 1;
            lblPetunjuk.Text = "Centang produk yang perlu diperiksa atau dihitung ulang oleh Gudang, lalu ketik alasan revisi pada kolom yang disediakan. Produk yang tidak dicentang tidak perlu dihitung ulang.";
            // 
            // gridRevisi
            // 
            gridRevisi.AllowUserToAddRows = false;
            gridRevisi.AllowUserToDeleteRows = false;
            gridRevisi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRevisi.BackgroundColor = Color.White;
            gridRevisi.BorderStyle = BorderStyle.FixedSingle;
            gridRevisi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridRevisi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridRevisi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridRevisi.ColumnHeadersHeight = 38;
            gridRevisi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridRevisi.Columns.AddRange(new DataGridViewColumn[] { colPilih, colKode, colNama, colStokSistem, colStokFisik, colSelisih, colAlasan });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Inter", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(254, 243, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridRevisi.DefaultCellStyle = dataGridViewCellStyle2;
            gridRevisi.EnableHeadersVisualStyles = false;
            gridRevisi.GridColor = Color.FromArgb(229, 231, 235);
            gridRevisi.Location = new Point(24, 90);
            gridRevisi.MultiSelect = false;
            gridRevisi.Name = "gridRevisi";
            gridRevisi.RowHeadersVisible = false;
            gridRevisi.RowTemplate.Height = 36;
            gridRevisi.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridRevisi.Size = new Size(750, 360);
            gridRevisi.TabIndex = 2;
            // 
            // colPilih
            // 
            colPilih.FillWeight = 40F;
            colPilih.HeaderText = "Pilih";
            colPilih.Name = "colPilih";
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
            colNama.FillWeight = 140F;
            colNama.HeaderText = "Nama Produk";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            // 
            // colStokSistem
            // 
            colStokSistem.FillWeight = 65F;
            colStokSistem.HeaderText = "Sistem";
            colStokSistem.Name = "colStokSistem";
            colStokSistem.ReadOnly = true;
            // 
            // colStokFisik
            // 
            colStokFisik.FillWeight = 65F;
            colStokFisik.HeaderText = "Fisik";
            colStokFisik.Name = "colStokFisik";
            colStokFisik.ReadOnly = true;
            // 
            // colSelisih
            // 
            colSelisih.FillWeight = 65F;
            colSelisih.HeaderText = "Selisih";
            colSelisih.Name = "colSelisih";
            colSelisih.ReadOnly = true;
            // 
            // colAlasan
            // 
            colAlasan.FillWeight = 180F;
            colAlasan.HeaderText = "Alasan Revisi (Wajib Diisi)";
            colAlasan.Name = "colAlasan";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Inter", 8.5F);
            lblInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblInfo.Location = new Point(24, 465);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(346, 15);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Centang minimal 1 produk dan lengkapi alasan revisinya.";
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.White;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnBatal.ForeColor = Color.FromArgb(75, 85, 99);
            btnBatal.Location = new Point(500, 460);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(110, 36);
            btnBatal.TabIndex = 5;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            // 
            // btnKirim
            // 
            btnKirim.BackColor = Color.FromArgb(217, 119, 6);
            btnKirim.Cursor = Cursors.Hand;
            btnKirim.FlatAppearance.BorderSize = 0;
            btnKirim.FlatStyle = FlatStyle.Flat;
            btnKirim.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnKirim.ForeColor = Color.White;
            btnKirim.Location = new Point(620, 460);
            btnKirim.Name = "btnKirim";
            btnKirim.Size = new Size(154, 36);
            btnKirim.TabIndex = 4;
            btnKirim.Text = "Kirim Permintaan";
            btnKirim.UseVisualStyleBackColor = false;
            // 
            // FormMintaRevisi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 515);
            Controls.Add(btnKirim);
            Controls.Add(btnBatal);
            Controls.Add(lblInfo);
            Controls.Add(gridRevisi);
            Controls.Add(lblPetunjuk);
            Controls.Add(lblJudul);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMintaRevisi";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Permintaan Revisi Opname";
            ((System.ComponentModel.ISupportInitialize)gridRevisi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Label lblPetunjuk;
        private DataGridView gridRevisi;
        private DataGridViewCheckBoxColumn colPilih;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colStokSistem;
        private DataGridViewTextBoxColumn colStokFisik;
        private DataGridViewTextBoxColumn colSelisih;
        private DataGridViewTextBoxColumn colAlasan;
        private Label lblInfo;
        private Button btnBatal;
        private Button btnKirim;
    }
}