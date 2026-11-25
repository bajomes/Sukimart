namespace Sukimart
{
    partial class FormBatalkanOpname
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
            lblJudul = new Label();
            lblPetunjuk = new Label();
            lblAlasan = new Label();
            txtAlasan = new TextBox();
            btnBatal = new Button();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(220, 38, 38);
            lblJudul.Location = new Point(24, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(223, 23);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Batalkan Sesi Opname";
            // 
            // lblPetunjuk
            // 
            lblPetunjuk.Font = new Font("Inter", 9F);
            lblPetunjuk.ForeColor = Color.FromArgb(75, 85, 99);
            lblPetunjuk.Location = new Point(24, 52);
            lblPetunjuk.Name = "lblPetunjuk";
            lblPetunjuk.Size = new Size(470, 36);
            lblPetunjuk.TabIndex = 1;
            lblPetunjuk.Text = "Sesi opname yang dibatalkan tidak dapat diajukan atau disetujui kembali. Stok sistem tidak akan berubah dan penguncian stok akan dilepas.";
            // 
            // lblAlasan
            // 
            lblAlasan.AutoSize = true;
            lblAlasan.Font = new Font("Inter", 9F, FontStyle.Bold);
            lblAlasan.ForeColor = Color.FromArgb(55, 65, 81);
            lblAlasan.Location = new Point(24, 98);
            lblAlasan.Name = "lblAlasan";
            lblAlasan.Size = new Size(160, 15);
            lblAlasan.TabIndex = 2;
            lblAlasan.Text = "Alasan Pembatalan (Wajib):";
            // 
            // txtAlasan
            // 
            txtAlasan.BorderStyle = BorderStyle.FixedSingle;
            txtAlasan.Font = new Font("Inter", 9.5F);
            txtAlasan.Location = new Point(24, 120);
            txtAlasan.Multiline = true;
            txtAlasan.Name = "txtAlasan";
            txtAlasan.PlaceholderText = "Tuliskan alasan pembatalan sesi opname ini secara jelas...";
            txtAlasan.ScrollBars = ScrollBars.Vertical;
            txtAlasan.Size = new Size(470, 80);
            txtAlasan.TabIndex = 3;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.White;
            btnBatal.Cursor = Cursors.Hand;
            btnBatal.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnBatal.ForeColor = Color.FromArgb(75, 85, 99);
            btnBatal.Location = new Point(280, 216);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(100, 34);
            btnBatal.TabIndex = 5;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(220, 38, 38);
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Inter", 9F, FontStyle.Bold);
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(390, 216);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(104, 34);
            btnSimpan.TabIndex = 4;
            btnSimpan.Text = "Batalkan Sesi";
            btnSimpan.UseVisualStyleBackColor = false;
            // 
            // FormBatalkanOpname
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(518, 270);
            Controls.Add(btnSimpan);
            Controls.Add(btnBatal);
            Controls.Add(txtAlasan);
            Controls.Add(lblAlasan);
            Controls.Add(lblPetunjuk);
            Controls.Add(lblJudul);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBatalkanOpname";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Konfirmasi Pembatalan Opname";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Label lblPetunjuk;
        private Label lblAlasan;
        private TextBox txtAlasan;
        private Button btnBatal;
        private Button btnSimpan;
    }
}