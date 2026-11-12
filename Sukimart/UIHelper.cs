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
                    if (e.Clicks == 2 && targetForm.MaximizeBox)
                    {
                        AlihkanMaximize(targetForm);
                        return;
                    }

                    ReleaseCapture();
                    SendMessage(targetForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        public static void AlihkanMaximize(Form form)
        {
            if (form == null || !form.MaximizeBox) return;

            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
                form.Size = new Size(1280, 720);
                PusatkanForm(form);
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        public static void PusatkanForm(Form form)
        {
            if (form == null) return;
            Screen layar = Screen.FromControl(form);
            form.Location = new Point(
                layar.WorkingArea.Left + Math.Max(0, (layar.WorkingArea.Width - form.Width) / 2),
                layar.WorkingArea.Top + Math.Max(0, (layar.WorkingArea.Height - form.Height) / 2)
            );
        }

        /// <summary>
        /// Merapatkan tombol-tombol menu sidebar yang terlihat sehingga tidak ada lubang kosong
        /// ketika sebagian tombol disembunyikan berdasarkan peran pengguna (Kasir / Gudang).
        /// </summary>
        public static void SusunTombolSidebar(Panel pnlKiri)
        {
            if (pnlKiri == null) return;

            if (!pnlKiri.Visible)
            {
                pnlKiri.VisibleChanged -= SusunSaatTampil;
                pnlKiri.VisibleChanged += SusunSaatTampil;
                return;
            }

            int y = 112; // Mulai tepat di bawah logo aplikasi
            int jarak = 8; // Jarak seragam antar-tombol

            string[] urutanTombol = { "btnDashboard", "btnKasir", "btnKatalog", "btnRiwayat", "btnGudang", "btnLaporan", "btnPengguna" };

            foreach (string nama in urutanTombol)
            {
                Control[] ditemukan = pnlKiri.Controls.Find(nama, false);
                if (ditemukan.Length > 0 && ditemukan[0] is Button btn && btn.Visible)
                {
                    btn.Location = new Point(btn.Location.X, y);
                    y += btn.Height + jarak;
                }
            }
        }

        public static void RatakanTengah(params DataGridViewColumn[] daftarKolom)
        {
            foreach (DataGridViewColumn kolom in daftarKolom)
            {
                kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                kolom.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private static void SusunSaatTampil(object? sender, EventArgs e)
        {
            if (sender is Panel pnl && pnl.Visible)
            {
                pnl.VisibleChanged -= SusunSaatTampil;
                SusunTombolSidebar(pnl);
            }
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

            // Jamin ukuran normal kembali ke 1280x720 saat jendela di-restore dari maximize
            form.Resize += (s, e) =>
            {
                if (form.WindowState == FormWindowState.Normal)
                {
                    Screen layar = Screen.FromControl(form);
                    if (form.Width >= layar.WorkingArea.Width - 10 && form.Height >= layar.WorkingArea.Height - 10)
                    {
                        form.Size = new Size(1280, 720);
                        PusatkanForm(form);
                    }
                }
            };

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

        // Kolom mata uang: rata kanan (Harga, Total, Subtotal, dsb.)
        private static readonly string[] KataKolomUang =
            { "Harga", "Total", "Subtotal", "Omzet", "Bayar", "Kembalian" };

        // Kolom angka biasa (Stok, Qty, Jumlah): rata tengah supaya rapi
        private static readonly string[] KataKolomAngka =
            { "Stok", "Qty", "Jumlah", "Terjual", "Min" };

        private static void RapikanKolom(DataGridViewColumn kolom)
        {
            if (kolom.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
            {
                kolom.MinimumWidth = 64;
            }

            string gabungan = (kolom.Name ?? "") + "|" + (kolom.DataPropertyName ?? "") + "|" + (kolom.HeaderText ?? "");

            // Kolom mata uang: rata kanan, header pun rata kanan
            foreach (string kata in KataKolomUang)
            {
                if (gabungan.IndexOf(kata, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    kolom.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    return;
                }
            }

            // Kolom angka stok/qty: rata tengah, header juga tengah
            foreach (string kata in KataKolomAngka)
            {
                if (gabungan.IndexOf(kata, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    kolom.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    return;
                }
            }
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
