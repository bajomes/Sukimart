using System.Globalization;

namespace Sukimart
{
    public partial class FormRiwayatStok : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string? kodeBarang;

        public FormRiwayatStok(string? kodeBarang = null)
        {
            this.kodeBarang = kodeBarang;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MuatRiwayat();
        }

        // Menggambar garis batas (border) di sekeliling jendela dialog
        private void FormRiwayatStok_Paint(object? sender, PaintEventArgs e)
        {
            using Pen pena = new Pen(UIHelper.WarnaGarisTepi);
            e.Graphics.DrawRectangle(pena, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

        // Menutup formulir riwayat kartu stok
        private void btnTutup_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Memberikan pewarnaan khusus pada kolom jumlah (+ hijau untuk masuk, - merah untuk keluar)
        private void gridRiwayat_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            GridRiwayat_CellFormatting(sender, e);
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
                List<RiwayatStok> daftar = PenyimpananData.BacaRiwayatStok();
                Barang? barang = null;

                if (!string.IsNullOrEmpty(kodeBarang))
                {
                    barang = PenyimpananData.BacaBarang().FirstOrDefault(data => data.Kode == kodeBarang);
                    daftar = daftar.Where(data => data.KodeBarang == kodeBarang).ToList();
                }

                var riwayat = daftar
                    .OrderByDescending(r => r.Tanggal)
                    .ToList();

                gridRiwayat.AutoGenerateColumns = false;
                gridRiwayat.DataSource = riwayat.Select(r => new
                {
                    Tanggal = r.Tanggal.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia),
                    r.KodeBarang,
                    r.NamaBarang,
                    r.Jenis,
                    JumlahFormat = (r.Jenis == "MASUK" || r.Jenis == "Stok Masuk" ? "+" : "−") + r.Jumlah.ToString("N0", BudayaIndonesia),
                    r.StokSesudah,
                    r.Keterangan,
                    r.Pengguna
                }).ToList();

                if (barang != null)
                {
                    lblJudul.Text = $"Kartu Stok · {barang.Kode}";
                    lblInfo.Text = $"{barang.Nama} · Stok saat ini: {barang.Stok:N0} · {riwayat.Count} catatan";
                }
                else
                {
                    lblInfo.Text = riwayat.Count == 0 ? "Belum ada catatan perubahan stok" : $"{riwayat.Count} catatan";
                }
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
