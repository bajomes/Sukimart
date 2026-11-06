namespace Sukimart
{
    partial class FormStruk
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
            pnlStruk = new Panel();
            btnTutup = new Button();
            btnCetak = new Button();
            SuspendLayout();
            lblJudul.AutoSize = true;
            lblJudul.BackColor = Color.Transparent;
            lblJudul.Font = new Font("Inter", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(31, 41, 55);
            lblJudul.Location = new Point(24, 24);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(180, 24);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Transaksi Berhasil";
            pnlStruk.AutoScroll = true;
            pnlStruk.BackColor = Color.White;
            pnlStruk.Location = new Point(24, 68);
            pnlStruk.Name = "pnlStruk";
            pnlStruk.Size = new Size(352, 492);
            pnlStruk.TabIndex = 2;
            btnTutup.BackColor = Color.White;
            btnTutup.Cursor = Cursors.Hand;
            btnTutup.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.Font = new Font("Inter", 10F);
            btnTutup.ForeColor = Color.FromArgb(55, 65, 81);
            btnTutup.Location = new Point(24, 576);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(168, 40);
            btnTutup.TabIndex = 3;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            btnCetak.BackColor = Color.FromArgb(255, 196, 0);
            btnCetak.Cursor = Cursors.Hand;
            btnCetak.FlatAppearance.BorderSize = 0;
            btnCetak.FlatStyle = FlatStyle.Flat;
            btnCetak.Font = new Font("Inter", 10F, FontStyle.Bold);
            btnCetak.ForeColor = Color.FromArgb(31, 41, 55);
            btnCetak.Location = new Point(208, 576);
            btnCetak.Name = "btnCetak";
            btnCetak.Size = new Size(168, 40);
            btnCetak.TabIndex = 4;
            btnCetak.Text = "Cetak Struk";
            btnCetak.UseVisualStyleBackColor = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 247, 245);
            ClientSize = new Size(400, 640);
            Controls.Add(lblJudul);
            Controls.Add(pnlStruk);
            Controls.Add(btnTutup);
            Controls.Add(btnCetak);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormStruk";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Struk Belanja";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblJudul;
        private Panel pnlStruk;
        private Button btnTutup;
        private Button btnCetak;
    }
}
