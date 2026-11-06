using System.Globalization;

namespace Sukimart
{
    public partial class FormRiwayatStok : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormRiwayatStok()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            Paint += (s, e) =>
            {
                using Pen pena = new Pen(UIHelper.WarnaGarisTepi);
                e.Graphics.DrawRectangle(pena, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            };
            btnTutup.Click += (s, e) => Close();
            gridRiwayat.CellFormatting += GridRiwayat_CellFormatting;
            MuatRiwayat();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MuatRiwayat()
        {
            try
            {
                var daftar = PenyimpananData.BacaRiwayatStok()
                    .OrderByDescending(r => r.Tanggal)
                    .ToList();

                gridRiwayat.AutoGenerateColumns = false;
                gridRiwayat.DataSource = daftar.Select(r => new
                {
                    Tanggal = r.Tanggal.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia),
                    r.KodeBarang,
                    r.NamaBarang,
                    r.Jenis,
                    JumlahFormat = (r.Jenis == "Stok Keluar" ? "−" : "+") + r.Jumlah.ToString("N0", BudayaIndonesia),
                    r.StokSesudah,
                    r.Keterangan,
                    r.Pengguna
                }).ToList();

                lblInfo.Text = daftar.Count == 0 ? "Belum ada catatan perubahan stok" : $"{daftar.Count} catatan";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat stok: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridRiwayat_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || gridRiwayat.Columns[e.ColumnIndex].Name != "colJumlah" || e.CellStyle == null)
            {
                return;
            }

            string teks = e.Value?.ToString() ?? "";
            e.CellStyle.ForeColor = teks.StartsWith("−") ? Color.FromArgb(220, 38, 38) : Color.FromArgb(16, 149, 102);
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }
    }
}
