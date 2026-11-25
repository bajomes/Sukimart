namespace Sukimart
{
    partial class FormRiwayatRevisiOpname
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
            lblJudul = new Label();
            lblSubJudul = new Label();
            tabRiwayat = new TabControl();
            tabItemRevisi = new TabPage();
            gridRevisi = new DataGridView();
            colRevWaktu = new DataGridViewTextBoxColumn();
            colRevAdmin = new DataGridViewTextBoxColumn();
            colRevProduk = new DataGridViewTextBoxColumn();
            colRevFisikLama = new DataGridViewTextBoxColumn();
            colRevAlasan = new DataGridViewTextBoxColumn();
            colRevFisikBaru = new DataGridViewTextBoxColumn();
            colRevWaktuPerbaikan = new DataGridViewTextBoxColumn();
            tabItemTimeline = new TabPage();
            gridTimeline = new DataGridView();
            colTimeWaktu = new DataGridViewTextBoxColumn();
            colTimeStatus = new DataGridViewTextBoxColumn();
            colTimeOleh = new DataGridViewTextBoxColumn();
            colTimeCatatan = new DataGridViewTextBoxColumn();
            btnTutup = new Button();
            tabRiwayat.SuspendLayout();
            tabItemRevisi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRevisi).BeginInit();
            tabItemTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTimeline).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(24, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(292, 23);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Riwayat Revisi & Status Opname";
            // 
            // lblSubJudul
            // 
            lblSubJudul.AutoSize = true;
            lblSubJudul.Font = new Font("Inter", 9F);
            lblSubJudul.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubJudul.Location = new Point(24, 48);
            lblSubJudul.Name = "lblSubJudul";
            lblSubJudul.Size = new Size(330, 15);
            lblSubJudul.TabIndex = 1;
            lblSubJudul.Text = "Catatan kronologis permintaan revisi dan perubahan status sesi.";
            // 
            // tabRiwayat
            // 
            tabRiwayat.Controls.Add(tabItemRevisi);
            tabRiwayat.Controls.Add(tabItemTimeline);
            tabRiwayat.Font = new Font("Inter", 9.5F);
            tabRiwayat.Location = new Point(24, 80);
            tabRiwayat.Name = "tabRiwayat";
            tabRiwayat.SelectedIndex = 0;
            tabRiwayat.Size = new Size(850, 420);
            tabRiwayat.TabIndex = 2;
            // 
            // tabItemRevisi
            // 
            tabItemRevisi.Controls.Add(gridRevisi);
            tabItemRevisi.Location = new Point(4, 25);
            tabItemRevisi.Name = "tabItemRevisi";
            tabItemRevisi.Padding = new Padding(3);
            tabItemRevisi.Size = new Size(842, 391);
            tabItemRevisi.TabIndex = 0;
            tabItemRevisi.Text = "Catatan Revisi Produk";
            tabItemRevisi.UseVisualStyleBackColor = true;
            // 
            // gridRevisi
            // 
            gridRevisi.AllowUserToAddRows = false;
            gridRevisi.AllowUserToDeleteRows = false;
            gridRevisi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRevisi.BackgroundColor = Color.White;
            gridRevisi.BorderStyle = BorderStyle.None;
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
            gridRevisi.ColumnHeadersHeight = 36;
            gridRevisi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridRevisi.Columns.AddRange(new DataGridViewColumn[] { colRevWaktu, colRevAdmin, colRevProduk, colRevFisikLama, colRevAlasan, colRevFisikBaru, colRevWaktuPerbaikan });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Inter", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(254, 243, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridRevisi.DefaultCellStyle = dataGridViewCellStyle2;
            gridRevisi.Dock = DockStyle.Fill;
            gridRevisi.EnableHeadersVisualStyles = false;
            gridRevisi.GridColor = Color.FromArgb(229, 231, 235);
            gridRevisi.Location = new Point(3, 3);
            gridRevisi.MultiSelect = false;
            gridRevisi.Name = "gridRevisi";
            gridRevisi.ReadOnly = true;
            gridRevisi.RowHeadersVisible = false;
            gridRevisi.RowTemplate.Height = 34;
            gridRevisi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRevisi.Size = new Size(836, 385);
            gridRevisi.TabIndex = 0;
            // 
            // colRevWaktu
            // 
            colRevWaktu.FillWeight = 85F;
            colRevWaktu.HeaderText = "Waktu Revisi";
            colRevWaktu.Name = "colRevWaktu";
            colRevWaktu.ReadOnly = true;
            // 
            // colRevAdmin
            // 
            colRevAdmin.FillWeight = 65F;
            colRevAdmin.HeaderText = "Diminta Oleh";
            colRevAdmin.Name = "colRevAdmin";
            colRevAdmin.ReadOnly = true;
            // 
            // colRevProduk
            // 
            colRevProduk.FillWeight = 120F;
            colRevProduk.HeaderText = "Produk";
            colRevProduk.Name = "colRevProduk";
            colRevProduk.ReadOnly = true;
            // 
            // colRevFisikLama
            // 
            colRevFisikLama.FillWeight = 55F;
            colRevFisikLama.HeaderText = "Fisik Lama";
            colRevFisikLama.Name = "colRevFisikLama";
            colRevFisikLama.ReadOnly = true;
            // 
            // colRevAlasan
            // 
            colRevAlasan.FillWeight = 130F;
            colRevAlasan.HeaderText = "Alasan Revisi";
            colRevAlasan.Name = "colRevAlasan";
            colRevAlasan.ReadOnly = true;
            // 
            // colRevFisikBaru
            // 
            colRevFisikBaru.FillWeight = 55F;
            colRevFisikBaru.HeaderText = "Fisik Baru";
            colRevFisikBaru.Name = "colRevFisikBaru";
            colRevFisikBaru.ReadOnly = true;
            // 
            // colRevWaktuPerbaikan
            // 
            colRevWaktuPerbaikan.FillWeight = 85F;
            colRevWaktuPerbaikan.HeaderText = "Diperbaiki Pada";
            colRevWaktuPerbaikan.Name = "colRevWaktuPerbaikan";
            colRevWaktuPerbaikan.ReadOnly = true;
            // 
            // tabItemTimeline
            // 
            tabItemTimeline.Controls.Add(gridTimeline);
            tabItemTimeline.Location = new Point(4, 25);
            tabItemTimeline.Name = "tabItemTimeline";
            tabItemTimeline.Padding = new Padding(3);
            tabItemTimeline.Size = new Size(842, 391);
            tabItemTimeline.TabIndex = 1;
            tabItemTimeline.Text = "Timeline Perubahan Status";
            tabItemTimeline.UseVisualStyleBackColor = true;
            // 
            // gridTimeline
            // 
            gridTimeline.AllowUserToAddRows = false;
            gridTimeline.AllowUserToDeleteRows = false;
            gridTimeline.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTimeline.BackgroundColor = Color.White;
            gridTimeline.BorderStyle = BorderStyle.None;
            gridTimeline.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridTimeline.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("Inter", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 244, 204);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridTimeline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridTimeline.ColumnHeadersHeight = 36;
            gridTimeline.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridTimeline.Columns.AddRange(new DataGridViewColumn[] { colTimeWaktu, colTimeStatus, colTimeOleh, colTimeCatatan });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Inter", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(254, 243, 199);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridTimeline.DefaultCellStyle = dataGridViewCellStyle4;
            gridTimeline.Dock = DockStyle.Fill;
            gridTimeline.EnableHeadersVisualStyles = false;
            gridTimeline.GridColor = Color.FromArgb(229, 231, 235);
            gridTimeline.Location = new Point(3, 3);
            gridTimeline.MultiSelect = false;
            gridTimeline.Name = "gridTimeline";
            gridTimeline.ReadOnly = true;
            gridTimeline.RowHeadersVisible = false;
            gridTimeline.RowTemplate.Height = 34;
            gridTimeline.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTimeline.Size = new Size(836, 385);
            gridTimeline.TabIndex = 0;
            // 
            // colTimeWaktu
            // 
            colTimeWaktu.FillWeight = 85F;
            colTimeWaktu.HeaderText = "Waktu";
            colTimeWaktu.Name = "colTimeWaktu";
            colRevWaktu.ReadOnly = true;
            // 
            // colTimeStatus
            // 
            colTimeStatus.FillWeight = 70F;
            colTimeStatus.HeaderText = "Status";
            colTimeStatus.Name = "colTimeStatus";
            colTimeStatus.ReadOnly = true;
            // 
            // colTimeOleh
            // 
            colTimeOleh.FillWeight = 65F;
            colTimeOleh.HeaderText = "Oleh";
            colTimeOleh.Name = "colTimeOleh";
            colTimeOleh.ReadOnly = true;
            // 
            // colTimeCatatan
            // 
            colTimeCatatan.FillWeight = 180F;
            colTimeCatatan.HeaderText = "Catatan";
            colTimeCatatan.Name = "colTimeCatatan";
            colTimeCatatan.ReadOnly = true;
            // 
            // btnTutup
            // 
            btnTutup.BackColor = Color.White;
            btnTutup.Cursor = Cursors.Hand;
            btnTutup.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnTutup.ForeColor = Color.FromArgb(75, 85, 99);
            btnTutup.Location = new Point(764, 514);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(110, 36);
            btnTutup.TabIndex = 3;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            // 
            // FormRiwayatRevisiOpname
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(898, 565);
            Controls.Add(btnTutup);
            Controls.Add(tabRiwayat);
            Controls.Add(lblSubJudul);
            Controls.Add(lblJudul);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRiwayatRevisiOpname";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Riwayat Revisi Opname";
            tabRiwayat.ResumeLayout(false);
            tabItemRevisi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridRevisi).EndInit();
            tabItemTimeline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridTimeline).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Label lblSubJudul;
        private TabControl tabRiwayat;
        private TabPage tabItemRevisi;
        private DataGridView gridRevisi;
        private DataGridViewTextBoxColumn colRevWaktu;
        private DataGridViewTextBoxColumn colRevAdmin;
        private DataGridViewTextBoxColumn colRevProduk;
        private DataGridViewTextBoxColumn colRevFisikLama;
        private DataGridViewTextBoxColumn colRevAlasan;
        private DataGridViewTextBoxColumn colRevFisikBaru;
        private DataGridViewTextBoxColumn colRevWaktuPerbaikan;
        private TabPage tabItemTimeline;
        private DataGridView gridTimeline;
        private DataGridViewTextBoxColumn colTimeWaktu;
        private DataGridViewTextBoxColumn colTimeStatus;
        private DataGridViewTextBoxColumn colTimeOleh;
        private DataGridViewTextBoxColumn colTimeCatatan;
        private Button btnTutup;
    }
}