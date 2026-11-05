using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sukimart
{
    /// <summary>
    /// Helper utilitas UI Sukimart:
    /// 1. Fitur drag/geser form ketika FormBorderStyle = None.
    /// 2. Menjaga warna seleksi DataGridView tetap kuning khas Sukimart (bukan biru bawaan Windows).
    /// </summary>
    public static class UIHelper
    {
        // Warna seleksi kuning muda & teks gelap serasi dengan tema Sukimart
        public static readonly Color WarnaSeleksiKuning = Color.FromArgb(255, 244, 204);
        public static readonly Color WarnaTeksSeleksi = Color.FromArgb(31, 41, 55);

        // Win32 API resmi untuk memindahkan jendela tanpa title bar secara halus dan responsif
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        /// <summary>
        /// Mendaftarkan kontrol agar ketika diklik dan digeser (drag),
        /// form utama akan bergerak mengikuti mouse.
        /// </summary>
        public static void PasangDrag(Form targetForm, Control kontrol)
        {
            if (targetForm == null || kontrol == null) return;

            kontrol.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(targetForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        /// <summary>
        /// Menerapkan warna latar belakang seleksi kuning pada DataGridView.
        /// </summary>
        public static void TerapkanWarnaGrid(DataGridView grid)
        {
            if (grid == null) return;

            // Baris data (DefaultCellStyle)
            grid.DefaultCellStyle.SelectionBackColor = WarnaSeleksiKuning;
            grid.DefaultCellStyle.SelectionForeColor = WarnaTeksSeleksi;

            // Header Kolom
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = grid.ColumnHeadersDefaultCellStyle.BackColor.IsEmpty ? Color.FromArgb(243, 244, 246) : grid.ColumnHeadersDefaultCellStyle.BackColor;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = grid.ColumnHeadersDefaultCellStyle.ForeColor.IsEmpty ? Color.FromArgb(55, 65, 81) : grid.ColumnHeadersDefaultCellStyle.ForeColor;

            // Header Baris
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = WarnaSeleksiKuning;
            grid.RowHeadersDefaultCellStyle.SelectionForeColor = WarnaTeksSeleksi;
        }

        /// <summary>
        /// Inisialisasi otomatis untuk satu form:
        /// 1. Memasang fitur drag pada area kosong (Panel, Label, Logo).
        /// 2. Memastikan seluruh DataGridView memiliki warna seleksi kuning.
        /// </summary>
        public static void InisialisasiForm(Form form)
        {
            if (form == null) return;

            // Pasang drag pada form itu sendiri
            FontInter.Terapkan(form);

            PasangDrag(form, form);

            // Pasang drag dan tema grid secara menyeluruh ke semua kontrol di form
            PasangRekursif(form, form);
        }

        private static void PasangRekursif(Form targetForm, Control induk)
        {
            foreach (Control ctrl in induk.Controls)
            {
                // Kontrol yang aman untuk drag: Panel, Label, PictureBox
                // Tidak mengganggu tombol (Button), input (TextBox, ComboBox, NumericUpDown), maupun tabel (DataGridView)
                if (ctrl is Panel || ctrl is Label || ctrl is PictureBox)
                {
                    // Hindari kontrol box ReaLTaiizor (tombol close/minimize di pojok kanan atas)
                    if (!ctrl.GetType().Name.Contains("NightControlBox") && !ctrl.GetType().Name.Contains("ControlBox"))
                    {
                        PasangDrag(targetForm, ctrl);
                    }
                }

                // Jika kontrol adalah tabel DataGridView, set warna seleksi ke kuning
                if (ctrl is DataGridView grid)
                {
                    TerapkanWarnaGrid(grid);
                    RapikanGrid(grid);
                }

                if (PerluGarisTepi(ctrl))
                {
                    PasangGarisTepi(induk);
                }

                // Telusuri kontrol di dalam container (panel di dalam panel)
                if (ctrl.HasChildren)
                {
                    PasangRekursif(targetForm, ctrl);
                }
            }
        }
        public static readonly Color WarnaGarisTepi = Color.FromArgb(229, 231, 235);

        private static readonly string[] KataKolomAngka =
        {
            "Harga", "Total", "Subtotal", "Stok", "Qty", "Jumlah", "Omzet", "Bayar", "Kembalian", "Terjual"
        };

        private static readonly ConditionalWeakTable<Control, object> IndukBergaris = new ConditionalWeakTable<Control, object>();

        public static void RapikanGrid(DataGridView grid)
        {
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            foreach (DataGridViewColumn kolom in grid.Columns)
            {
                RapikanKolom(kolom);
            }
            grid.ColumnAdded += (s, e) => RapikanKolom(e.Column);
        }

        private static void RapikanKolom(DataGridViewColumn kolom)
        {
            if (kolom.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
            {
                kolom.MinimumWidth = 64;
            }

            if (KolomAngka(kolom))
            {
                kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                kolom.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private static bool KolomAngka(DataGridViewColumn kolom)
        {
            string gabungan = (kolom.Name ?? "") + "|" + (kolom.DataPropertyName ?? "") + "|" + (kolom.HeaderText ?? "");
            foreach (string kata in KataKolomAngka)
            {
                if (gabungan.IndexOf(kata, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool PerluGarisTepi(Control ctrl)
        {
            if (ctrl is DataGridView)
            {
                return true;
            }
            return ctrl is Panel && ctrl.Dock == DockStyle.None && ctrl.BackColor.ToArgb() == Color.White.ToArgb();
        }

        private static void PasangGarisTepi(Control induk)
        {
            if (IndukBergaris.TryGetValue(induk, out _))
            {
                return;
            }
            IndukBergaris.Add(induk, new object());

            induk.Paint += (s, e) =>
            {
                using Pen pena = new Pen(WarnaGarisTepi);
                foreach (Control anak in induk.Controls)
                {
                    if (!anak.Visible || !PerluGarisTepi(anak))
                    {
                        continue;
                    }
                    Rectangle r = anak.Bounds;
                    r.Inflate(1, 1);
                    e.Graphics.DrawRectangle(pena, r.X, r.Y, r.Width - 1, r.Height - 1);
                }
            };

            foreach (Control anak in induk.Controls)
            {
                if (PerluGarisTepi(anak))
                {
                    anak.VisibleChanged += (s, e) => induk.Invalidate();
                    anak.LocationChanged += (s, e) => induk.Invalidate();
                    anak.SizeChanged += (s, e) => induk.Invalidate();
                }
            }
            induk.Invalidate();
        }
    }
}
