using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;

namespace Sukimart
{
    public partial class FormStruk : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private static readonly Color WarnaTeks = Color.FromArgb(31, 41, 55);
        private static readonly Color WarnaTeksRedup = Color.FromArgb(107, 114, 128);
        private static readonly Color WarnaGaris = Color.FromArgb(209, 213, 219);
        private const int LebarKertasCetak = 315;
        private const int MarginCetak = 16;
        private const int JarakTepi = 24;

        private readonly Transaksi transaksi;
        private readonly List<DetailTransaksi> rincian;

        public FormStruk(Transaksi transaksi, List<DetailTransaksi> rincian, bool transaksiBaru = true)
        {
            this.transaksi = transaksi;
            this.rincian = rincian;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);

            if (!transaksiBaru)
            {
                lblJudul.Text = "Struk Transaksi";
            }

            pnlStruk.Paint += PnlStruk_Paint;
            pnlStruk.Scroll += (s, e) => pnlStruk.Invalidate();
            pnlStruk.MouseWheel += (s, e) => pnlStruk.Invalidate();
            Paint += (s, e) =>
            {
                using Pen pena = new Pen(UIHelper.WarnaGarisTepi);
                e.Graphics.DrawRectangle(pena, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            };
            btnTutup.Click += (s, e) => Close();
            btnCetak.Click += (s, e) => CetakStruk();
            Shown += (s, e) => btnTutup.Focus();

            using Graphics g = pnlStruk.CreateGraphics();
            float tinggi = GambarStruk(g, 0, 0, LebarIsiLayar(), false, true);
            pnlStruk.AutoScrollMinSize = new Size(0, (int)Math.Ceiling(tinggi) + JarakTepi * 2);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            if (keyData == (Keys.Control | Keys.P))
            {
                CetakStruk();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int LebarIsiLayar()
        {
            return pnlStruk.ClientSize.Width - JarakTepi * 2;
        }

        private void PnlStruk_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.TranslateTransform(0, pnlStruk.AutoScrollPosition.Y);
            GambarStruk(e.Graphics, JarakTepi, JarakTepi, LebarIsiLayar(), false, false);
        }

        private void CetakStruk()
        {
            try
            {
                using PrintDocument dokumen = new PrintDocument();
                dokumen.DocumentName = "Struk " + transaksi.Id;

                using PrintDialog dialog = new PrintDialog();
                dialog.Document = dokumen;
                dialog.UseEXDialog = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                int lebarIsi = LebarKertasCetak - MarginCetak * 2;
                float tinggiIsi;
                using (Graphics ukur = dokumen.PrinterSettings.CreateMeasurementGraphics())
                {
                    tinggiIsi = GambarStruk(ukur, 0, 0, lebarIsi, true, true);
                }

                dokumen.DefaultPageSettings.PaperSize = new PaperSize("Struk 80mm", LebarKertasCetak, (int)Math.Ceiling(tinggiIsi) + MarginCetak * 2);
                dokumen.DefaultPageSettings.Margins = new Margins(MarginCetak, MarginCetak, MarginCetak, MarginCetak);
                dokumen.PrintPage += (s, e) =>
                {
                    int lebar = Math.Min(lebarIsi, e.MarginBounds.Width);
                    GambarStruk(e.Graphics!, e.MarginBounds.Left, e.MarginBounds.Top, lebar, true, false);
                    e.HasMorePages = false;
                };
                dokumen.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak struk: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private float GambarStruk(Graphics g, float kiri, float atas, float lebar, bool cetak, bool ukurSaja)
        {
            Color teks = cetak ? Color.Black : WarnaTeks;
            Color redup = cetak ? Color.Black : WarnaTeksRedup;
            float y = atas;

            using Font fontNamaToko = FontInter.Buat(14F, FontStyle.Bold);
            using Font fontKecil = FontInter.Buat(9F);
            using Font fontIsi = FontInter.Buat(10F);
            using Font fontTotal = FontInter.Buat(12F, FontStyle.Bold);

            using StringFormat tengah = new StringFormat { Alignment = StringAlignment.Center };
            using StringFormat kanan = new StringFormat { Alignment = StringAlignment.Far };
            using StringFormat potong = new StringFormat(StringFormatFlags.NoWrap) { Trimming = StringTrimming.EllipsisCharacter };

            void Tulis(string isi, Font font, Color warna, StringFormat format, float tambahan = 4)
            {
                float tinggi = font.GetHeight(g);
                if (!ukurSaja)
                {
                    using SolidBrush kuas = new SolidBrush(warna);
                    g.DrawString(isi, font, kuas, new RectangleF(kiri, y, lebar, tinggi), format);
                }
                y += tinggi + tambahan;
            }

            void TulisBungkus(string isi, Font font, Color warna, float tambahan = 4)
            {
                float tinggi = (float)Math.Ceiling(g.MeasureString(isi, font, (int)lebar).Height);
                if (!ukurSaja)
                {
                    using SolidBrush kuas = new SolidBrush(warna);
                    g.DrawString(isi, font, kuas, new RectangleF(kiri, y, lebar, tinggi));
                }
                y += tinggi + tambahan;
            }

            void Baris(string label, string nilai, Font font, Color warnaLabel, float tambahan = 4)
            {
                float tinggi = font.GetHeight(g);
                if (!ukurSaja)
                {
                    using SolidBrush kuasLabel = new SolidBrush(warnaLabel);
                    using SolidBrush kuasNilai = new SolidBrush(teks);
                    g.DrawString(label, font, kuasLabel, new RectangleF(kiri, y, lebar, tinggi), potong);
                    g.DrawString(nilai, font, kuasNilai, new RectangleF(kiri, y, lebar, tinggi), kanan);
                }
                y += tinggi + tambahan;
            }

            void Garis()
            {
                y += 6;
                if (!ukurSaja)
                {
                    using Pen pena = new Pen(cetak ? Color.Black : WarnaGaris) { DashStyle = DashStyle.Dash };
                    g.DrawLine(pena, kiri, y, kiri + lebar, y);
                }
                y += 10;
            }

            Tulis("SUKIMART", fontNamaToko, teks, tengah, 8);
            Garis();

            Baris("No. Faktur", transaksi.Id, fontKecil, redup);
            Baris("Tanggal", transaksi.Tanggal.ToString("dd/MM/yyyy HH:mm", BudayaIndonesia), fontKecil, redup);
            Baris("Kasir", transaksi.Kasir, fontKecil, redup, 0);
            Garis();

            foreach (DetailTransaksi item in rincian)
            {
                TulisBungkus(item.NamaBarang, fontIsi, teks, 2);
                Baris($"{item.Jumlah} x Rp {item.HargaSatuan.ToString("N0", BudayaIndonesia)}", "Rp " + item.Subtotal.ToString("N0", BudayaIndonesia), fontKecil, redup, 8);
            }
            y -= 4;
            Garis();

            Baris("Total", "Rp " + transaksi.Total.ToString("N0", BudayaIndonesia), fontTotal, teks, 6);
            Baris("Tunai", "Rp " + transaksi.Bayar.ToString("N0", BudayaIndonesia), fontIsi, redup);
            Baris("Kembalian", "Rp " + transaksi.Kembalian.ToString("N0", BudayaIndonesia), fontIsi, redup, 0);
            Garis();

            Tulis("Terima kasih telah berbelanja", fontKecil, redup, tengah, 0);

            return y - atas;
        }
    }
}
