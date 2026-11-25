using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormBatalkanOpname : Form
    {
        public string AlasanPembatalan { get; private set; } = "";
        public string Alasan => AlasanPembatalan;

        public FormBatalkanOpname(string idSesi)
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);

            lblJudul.Text = $"Batalkan Sesi Opname • {idSesi}";

            btnBatal.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            btnSimpan.Click += (s, e) =>
            {
                string alasan = txtAlasan.Text.Trim();
                if (string.IsNullOrEmpty(alasan))
                {
                    MessageBox.Show("Alasan pembatalan wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlasan.Focus();
                    return;
                }

                DialogResult konfirmasi = MessageBox.Show(
                    "Apakah Anda yakin ingin membatalkan sesi opname ini?\nSesi yang dibatalkan tidak dapat dipulihkan atau diterapkan ke inventaris.",
                    "Konfirmasi Pembatalan",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    AlasanPembatalan = alasan;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}