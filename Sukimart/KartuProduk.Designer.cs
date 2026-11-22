namespace Sukimart
{
    partial class KartuProduk
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
            lblNama = new Label();
            lblStok = new Label();
            lblHarga = new Label();
            SuspendLayout();
            // 
            // lblNama
            // 
            lblNama.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            lblNama.ForeColor = Color.FromArgb(31, 41, 55);
            lblNama.Location = new Point(10, 8);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(174, 34);
            lblNama.TabIndex = 0;
            lblNama.Text = "Nama Produk";
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Font = new Font("Inter", 8.5F);
            lblStok.ForeColor = Color.FromArgb(107, 114, 128);
            lblStok.Location = new Point(10, 46);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(47, 15);
            lblStok.TabIndex = 1;
            lblStok.Text = "Stok: 0";
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Font = new Font("Inter", 10F, FontStyle.Bold);
            lblHarga.ForeColor = Color.FromArgb(16, 149, 102);
            lblHarga.Location = new Point(10, 66);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(40, 17);
            lblHarga.TabIndex = 2;
            lblHarga.Text = "Rp 0";
            // 
            // KartuProduk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblNama);
            Controls.Add(lblStok);
            Controls.Add(lblHarga);
            Cursor = Cursors.Hand;
            Margin = new Padding(4);
            Name = "KartuProduk";
            Size = new Size(194, 92);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNama;
        private Label lblStok;
        private Label lblHarga;
    }
}
