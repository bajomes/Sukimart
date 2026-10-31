using System;
using System.Drawing;
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
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = WarnaSeleksiKuning;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = WarnaTeksSeleksi;

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
                }

                // Telusuri kontrol di dalam container (panel di dalam panel)
                if (ctrl.HasChildren)
                {
                    PasangRekursif(targetForm, ctrl);
                }
            }
        }
    }
}
