using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sukimart
{
    /// <summary>
    /// Helper utilitas UI Sukimart:
    /// 1. Format tanggal, waktu, uang, serta status stok terpusat.
    /// 2. Fitur drag/geser form ketika FormBorderStyle = None.
    /// 3. Pewarnaan DataGridView, badge status stok, dan penataan sidebar.
    /// </summary>
    public static class UIHelper
    {
        public static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        // Palet Visual Terpusat Sukimart (Toko Kelontong / Minimarket Modern Indonesia)
        public static readonly Color WarnaSidebar = Color.FromArgb(30, 42, 68);          // #12372A
        public static readonly Color WarnaSidebarAktif = Color.FromArgb(43, 59, 94);     // #1B4D3C
        public static readonly Color WarnaSidebarHover = Color.FromArgb(37, 52, 79);     // #174233
        public static readonly Color WarnaTeksSidebar = Color.FromArgb(246, 241, 231);   // #F6F1E7
        public static readonly Color WarnaTeksSidebarSekunder = Color.FromArgb(200, 208, 224); // #C8D6CD

        public static readonly Color WarnaLatarKonten = Color.FromArgb(246, 241, 231);   // #F6F1E7
        public static readonly Color WarnaKartu = Color.FromArgb(255, 253, 248);         // #FFFDF8
        public static readonly Color WarnaHeaderTabel = Color.FromArgb(239, 231, 216);   // #EFE7D8
        public static readonly Color WarnaGarisTepi = Color.FromArgb(227, 218, 200);     // #E3DAC8

        public static readonly Color WarnaAksen = Color.FromArgb(232, 131, 58);          // #E8833A
        public static readonly Color WarnaAksenHover = Color.FromArgb(214, 114, 41);     // #D67229
        public static readonly Color WarnaSeleksi = Color.FromArgb(252, 236, 217);       // #FCECD9
        public static readonly Color WarnaSeleksiKuning = WarnaSeleksi;

        public static readonly Color WarnaTeksUtama = Color.FromArgb(31, 42, 36);        // #1F2A24
        public static readonly Color WarnaTeksSeleksi = WarnaTeksUtama;
        public static readonly Color WarnaTeksSekunder = Color.FromArgb(107, 116, 104);  // #6B7468

        public static readonly Color WarnaStatusHabis = Color.FromArgb(179, 38, 30);     // #B3261E
        public static readonly Color WarnaStatusHabisBg = Color.FromArgb(253, 236, 234);
        public static readonly Color WarnaStatusHabisBorder = Color.FromArgb(245, 198, 195);

        public static readonly Color WarnaStatusMinimum = Color.FromArgb(183, 121, 31);  // #B7791F
        public static readonly Color WarnaStatusMinimumBg = Color.FromArgb(254, 245, 231);
        public static readonly Color WarnaStatusMinimumBorder = Color.FromArgb(246, 221, 180);

        public static readonly Color WarnaStatusAman = Color.FromArgb(46, 125, 79);      // #2E7D4F
        public static readonly Color WarnaStatusAmanBg = Color.FromArgb(234, 245, 238);
        public static readonly Color WarnaStatusAmanBorder = Color.FromArgb(195, 230, 208);

        public static string FormatTanggal(DateTime tanggal) =>
            tanggal.ToString("dd-MM-yyyy", BudayaIndonesia);

        public static string FormatWaktu(DateTime waktu) =>
            waktu.ToString("HH:mm:ss", BudayaIndonesia);

        public static string FormatTanggalWaktu(DateTime waktu, bool denganDetik = true) =>
            waktu.ToString(denganDetik ? "dd-MM-yyyy HH:mm:ss" : "dd-MM-yyyy HH:mm", BudayaIndonesia);

        public static string FormatUang(long nominal) =>
            nominal < 0
                ? "- Rp " + Math.Abs(nominal).ToString("N0", BudayaIndonesia)
                : "Rp " + nominal.ToString("N0", BudayaIndonesia);

        public static string FormatAngka(long angka) =>
            angka.ToString("N0", BudayaIndonesia);

        public static string TentukanStatusStok(int stok, int stokMinimum)
        {
            if (stok <= 0) return "HABIS";
            if (stok <= stokMinimum) return "MINIMUM";
            return "AMAN";
        }

        public static (Color ForeColor, Color BackColor, Color BorderColor) WarnaStatusStok(string? status)
        {
            return (status ?? "").Trim().ToUpperInvariant() switch
            {
                "HABIS" => (WarnaStatusHabis, WarnaStatusHabisBg, WarnaStatusHabisBorder),
                "MINIMUM" => (WarnaStatusMinimum, WarnaStatusMinimumBg, WarnaStatusMinimumBorder),
                _ => (WarnaStatusAman, WarnaStatusAmanBg, WarnaStatusAmanBorder)
            };
        }

        public static void GayaTombolPrimer(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = WarnaAksenHover;
            btn.BackColor = WarnaAksen;
            btn.ForeColor = WarnaKartu;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        public static void GayaTombolSekunder(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = WarnaGarisTepi;
            btn.FlatAppearance.MouseOverBackColor = WarnaHeaderTabel;
            btn.BackColor = WarnaKartu;
            btn.ForeColor = WarnaTeksUtama;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        public static void GayaTombolBahaya(Button btn, bool padat = false)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
            if (padat)
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = WarnaStatusHabis;
                btn.ForeColor = WarnaKartu;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 30, 24);
            }
            else
            {
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = WarnaStatusHabisBorder;
                btn.FlatAppearance.MouseOverBackColor = WarnaStatusHabisBg;
                btn.BackColor = WarnaKartu;
                btn.ForeColor = WarnaStatusHabis;
            }
        }

        private static string HapusEmoji(string? teks)
        {
            if (string.IsNullOrEmpty(teks)) return teks ?? "";
            var sb = new System.Text.StringBuilder(teks.Length);
            for (int i = 0; i < teks.Length; i++)
            {
                char c = teks[i];
                if (char.IsSurrogate(c)) continue;
                if (c >= 0x2600 && c <= 0x27BF && c != '\u2715') continue; // skip dingbats/emoji kecuali ✕
                sb.Append(c);
            }
            return sb.ToString().Trim();
        }

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
        private static readonly ConditionalWeakTable<Button, object> StripSidebarTerpasang = new ConditionalWeakTable<Button, object>();

        private static void TerapkanTemaSidebar(Panel pnlKiri, Form? formInduk)
        {
            string aktifNama = NamaTombolAktif(formInduk);
            foreach (Control c in pnlKiri.Controls)
            {
                if (c is Label lbl && lbl.Name == "lblNama")
                {
                    lbl.ForeColor = WarnaTeksSidebar;
                }
                else if (c is Button btn)
                {
                    float ukuranFont = btn.Font.SizeInPoints;
                    bool aktif = btn.Name == aktifNama;
                    GayaTombolSidebar(btn, aktif, ukuranFont, btn.Padding);
                    if (btn.Name == "btnKeluar" || btn.Name == "btnKeluarBenar")
                    {
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 72);
                    }
                }
            }
        }

        private static string NamaTombolAktif(Form? form)
        {
            return form switch
            {
                FormDashboardAdmin or FormDashboardKasir => "btnDashboard",
                FormKasir => "btnKasir",
                FormKatalog => "btnKatalog",
                FormRiwayatTransaksi => "btnRiwayat",
                FormGudang => "btnGudang",
                FormLaporan => "btnLaporan",
                FormLaporanInventaris => "btnLaporanInventaris",
                FormPengguna => "btnPengguna",
                FormLogAktivitas => "btnLogAktivitas",
                _ => ""
            };
        }

        private static void GayaTombolSidebar(Button btn, bool aktif, float ukuranFont, Padding padding)
        {
            btn.Padding = padding;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Tag = aktif ? "sidebar-aktif" : null;

            if (aktif)
            {
                btn.BackColor = WarnaSidebarAktif;
                btn.ForeColor = WarnaTeksSidebar;
                btn.Font = FontInter.Buat(ukuranFont, FontStyle.Bold);
                btn.FlatAppearance.MouseOverBackColor = WarnaSidebarAktif;
            }
            else
            {
                btn.BackColor = WarnaSidebar;
                btn.ForeColor = WarnaTeksSidebarSekunder;
                btn.Font = FontInter.Buat(ukuranFont, FontStyle.Regular);
                btn.FlatAppearance.MouseOverBackColor = WarnaSidebarHover;
            }

            if (!StripSidebarTerpasang.TryGetValue(btn, out _))
            {
                StripSidebarTerpasang.Add(btn, new object());
                btn.Paint += (s, e) =>
                {
                    if (btn.Tag as string != "sidebar-aktif") return;
                    using SolidBrush br = new SolidBrush(WarnaAksen);
                    e.Graphics.FillRectangle(br, 0, 4, 4, Math.Max(8, btn.Height - 8));
                };
            }
            btn.Invalidate();
        }

        public static void SusunTombolSidebar(Panel pnlKiri)
        {
            if (pnlKiri == null) return;

            Form? formInduk = pnlKiri.FindForm();
            if (formInduk is FormLogin) return;

            pnlKiri.BackColor = WarnaSidebar;
            foreach (Control c in pnlKiri.Controls)
            {
                if (c is Label lbl && lbl.Name == "lblNama")
                {
                    lbl.ForeColor = WarnaTeksSidebar;
                }
            }

            if (!pnlKiri.Visible)
            {
                pnlKiri.VisibleChanged -= SusunSaatTampil;
                pnlKiri.VisibleChanged += SusunSaatTampil;
                return;
            }

            PastikanTombolLogAktivitas(pnlKiri);

            // Dapatkan tombol acuan (seperti btnPengguna atau btnDashboard) untuk memastikan ukuran & padding seragam
            Control[] acuanArr = pnlKiri.Controls.Find("btnPengguna", false);
            if (acuanArr.Length == 0) acuanArr = pnlKiri.Controls.Find("btnDashboard", false);
            Button? acuan = acuanArr.Length > 0 ? acuanArr[0] as Button : null;

            int x = acuan != null ? acuan.Location.X : 16;
            int lebar = acuan != null ? acuan.Width : 208;
            int tinggi = acuan != null ? acuan.Height : 40;
            Padding padding = acuan != null ? acuan.Padding : new Padding(16, 0, 0, 0);
            float ukuranFont = acuan != null ? acuan.Font.SizeInPoints : 10F;

            Control[] btnDashArr = pnlKiri.Controls.Find("btnDashboard", false);
            int y = btnDashArr.Length > 0 ? btnDashArr[0].Location.Y : 112;
            int jarak = 8;
            if (tinggi != 40)
            {
                jarak = Math.Max(6, (int)Math.Round(tinggi * 0.2));
            }

            string aktifNama = NamaTombolAktif(formInduk);
            string[] urutanTombol = { "btnDashboard", "btnKasir", "btnKatalog", "btnRiwayat", "btnGudang", "btnLaporan", "btnLaporanInventaris", "btnPengguna", "btnLogAktivitas" };

            foreach (string nama in urutanTombol)
            {
                Control[] ditemukan = pnlKiri.Controls.Find(nama, false);
                if (ditemukan.Length > 0 && ditemukan[0] is Button btn && btn.Visible)
                {
                    btn.Size = new Size(lebar, tinggi);
                    btn.Location = new Point(x, y);
                    GayaTombolSidebar(btn, nama == aktifNama, ukuranFont, padding);
                    y += btn.Height + jarak;
                }
            }

            PastikanTombolBawah(pnlKiri);
        }

        public static void PastikanTombolBawah(Panel pnlKiri)
        {
            if (pnlKiri == null) return;

            Form? formInduk = pnlKiri.FindForm();
            if (formInduk is FormLogin) return;

            Control[] acuanArr = pnlKiri.Controls.Find("btnPengguna", false);
            if (acuanArr.Length == 0) acuanArr = pnlKiri.Controls.Find("btnDashboard", false);
            Button? acuan = acuanArr.Length > 0 ? acuanArr[0] as Button : null;

            int x = acuan != null ? acuan.Location.X : 16;
            int lebar = acuan != null ? acuan.Width : 208;
            int tinggi = acuan != null ? acuan.Height : 40;
            Padding padding = acuan != null ? acuan.Padding : new Padding(16, 0, 0, 0);
            float ukuranFont = acuan != null ? acuan.Font.SizeInPoints : 10F;
            int jarak = tinggi != 40 ? Math.Max(6, (int)Math.Round(tinggi * 0.2)) : 8;

            // Cari tombol Keluar
            Control[] keluarArr = pnlKiri.Controls.Find("btnKeluar", false);
            if (keluarArr.Length == 0) keluarArr = pnlKiri.Controls.Find("btnKeluarBenar", false);
            Button? btnKeluar = keluarArr.Length > 0 ? keluarArr[0] as Button : null;

            if (btnKeluar != null)
            {
                btnKeluar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                btnKeluar.Size = new Size(lebar, tinggi);
                btnKeluar.Location = new Point(x, btnKeluar.Location.Y);
                GayaTombolSidebar(btnKeluar, false, ukuranFont, padding);
                btnKeluar.FlatAppearance.BorderSize = 1;
                btnKeluar.FlatAppearance.BorderColor = Color.FromArgb(40, 90, 72);
            }

            // Cari atau buat tombol Ganti Kata Sandi
            Control[] gantiArr = pnlKiri.Controls.Find("btnGantiSandi", false);
            Button btnGanti;
            if (gantiArr.Length > 0 && gantiArr[0] is Button btnAda)
            {
                btnGanti = btnAda;
            }
            else
            {
                btnGanti = new Button
                {
                    Name = "btnGantiSandi",
                    Text = "Ganti Kata Sandi",
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Left
                };

                btnGanti.Click += (s, e) =>
                {
                    Form? f = btnGanti.FindForm();
                    if (f != null)
                    {
                        Navigasi.BukaGantiKataSandi(f);
                    }
                };

                pnlKiri.Controls.Add(btnGanti);
            }

            btnGanti.Size = new Size(lebar, tinggi);
            GayaTombolSidebar(btnGanti, false, ukuranFont, padding);
            btnGanti.Visible = true;

            if (btnKeluar != null)
            {
                int yGanti = btnKeluar.Location.Y - tinggi - jarak;
                btnGanti.Location = new Point(x, yGanti);
                btnGanti.BringToFront();
                btnKeluar.BringToFront();
            }
        }

        public static void PastikanTombolLogAktivitas(Panel pnlKiri)
        {
            if (pnlKiri == null) return;

            Form? formInduk = pnlKiri.FindForm();
            bool isAdmin = string.Equals(Navigasi.PeranAktif, "admin", StringComparison.OrdinalIgnoreCase);

            Control[] acuanArr = pnlKiri.Controls.Find("btnPengguna", false);
            if (acuanArr.Length == 0) acuanArr = pnlKiri.Controls.Find("btnDashboard", false);
            Button? acuan = acuanArr.Length > 0 ? acuanArr[0] as Button : null;

            int lebar = acuan != null ? acuan.Width : 208;
            int tinggi = acuan != null ? acuan.Height : 40;
            int x = acuan != null ? acuan.Location.X : 16;
            Padding padding = acuan != null ? acuan.Padding : new Padding(16, 0, 0, 0);
            float ukuranFont = acuan != null ? acuan.Font.SizeInPoints : 10F;

            Control[] ditemukan = pnlKiri.Controls.Find("btnLogAktivitas", false);
            if (ditemukan.Length > 0 && ditemukan[0] is Button btnAda)
            {
                btnAda.Visible = isAdmin;
                btnAda.Size = new Size(lebar, tinggi);
                btnAda.Location = new Point(x, btnAda.Location.Y);
                GayaTombolSidebar(btnAda, formInduk is FormLogAktivitas, ukuranFont, padding);
                return;
            }

            Button btnLog = new Button
            {
                Name = "btnLogAktivitas",
                Text = "Log Aktivitas",
                Size = new Size(lebar, tinggi),
                Location = new Point(x, 448),
                Visible = isAdmin
            };
            GayaTombolSidebar(btnLog, formInduk is FormLogAktivitas, ukuranFont, padding);

            btnLog.Click += (s, e) =>
            {
                Form? f = btnLog.FindForm();
                if (f != null)
                {
                    Navigasi.BukaLogAktivitas(f);
                }
            };

            pnlKiri.Controls.Add(btnLog);
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

            grid.BackgroundColor = WarnaKartu;
            grid.GridColor = WarnaGarisTepi;
            grid.RowTemplate.Height = Math.Max(36, grid.RowTemplate.Height);
            grid.ColumnHeadersHeight = 40;

            // Baris data (DefaultCellStyle)
            grid.DefaultCellStyle.BackColor = WarnaKartu;
            grid.DefaultCellStyle.ForeColor = WarnaTeksUtama;
            grid.DefaultCellStyle.SelectionBackColor = WarnaSeleksi;
            grid.DefaultCellStyle.SelectionForeColor = WarnaTeksUtama;

            // Header Kolom
            grid.ColumnHeadersDefaultCellStyle.BackColor = WarnaHeaderTabel;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = WarnaTeksUtama;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = WarnaHeaderTabel;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = WarnaTeksUtama;

            // Header Baris
            grid.RowHeadersDefaultCellStyle.SelectionBackColor = WarnaSeleksi;
            grid.RowHeadersDefaultCellStyle.SelectionForeColor = WarnaTeksUtama;

            // Tampilan lebih modern: tanpa kisi vertikal, hanya garis tipis antarbaris
            grid.EnableHeadersVisualStyles = false;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
        }

        /// <summary>
        /// Inisialisasi otomatis untuk satu form:
        /// 1. Menerapkan font Inter dan palet terpusat Sukimart.
        /// 2. Memasang fitur drag pada area kosong (Panel, Label, Logo).
        /// 3. Memastikan seluruh DataGridView memiliki tema, grid rapi, dan kolom ID tidak terpotong.
        /// </summary>
        public static void InisialisasiForm(Form form)
        {
            if (form == null) return;

            // Pasang font Inter & drag pada form itu sendiri
            FontInter.Terapkan(form);

            if (form is FormLogin)
            {
                // FormLogin ditata khusus: panel kiri krem, panel kanan hijau tua
                form.BackColor = WarnaLatarKonten;
            }
            else if (form.BackColor == Color.FromArgb(247, 247, 245) || form.BackColor == SystemColors.Control)
            {
                form.BackColor = WarnaLatarKonten;
            }

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

            // Kunci posisi NightControlBox agar tidak miring/terpotong di display scale 125% / DPI tinggi
            PerbaikiNightControlBox(form);

            // Pasang drag dan tema palet terpusat secara menyeluruh ke semua kontrol di form
            PasangRekursif(form, form);
        }

        public static void PerbaikiNightControlBox(Form form)
        {
            if (form == null) return;
            AturNightControlBoxRekursif(form);
        }

        private static void AturNightControlBoxRekursif(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is ReaLTaiizor.Controls.NightControlBox ncb)
                {
                    bool parentGelap = parent.FindForm() is FormLogin && parent.Name == "pnlKanan";
                    ncb.CloseHoverColor = WarnaStatusHabis;
                    ncb.CloseHoverForeColor = WarnaKartu;
                    ncb.EnableCloseColor = parentGelap ? WarnaTeksSidebarSekunder : WarnaTeksSekunder;
                    ncb.EnableMaximizeColor = parentGelap ? WarnaTeksSidebarSekunder : WarnaTeksSekunder;
                    ncb.EnableMinimizeColor = parentGelap ? WarnaTeksSidebarSekunder : WarnaTeksSekunder;
                    ncb.MaximizeHoverColor = parentGelap ? WarnaSidebarHover : WarnaHeaderTabel;
                    ncb.MaximizeHoverForeColor = parentGelap ? WarnaTeksSidebar : WarnaTeksUtama;
                    ncb.MinimizeHoverColor = parentGelap ? WarnaSidebarHover : WarnaHeaderTabel;
                    ncb.MinimizeHoverForeColor = parentGelap ? WarnaTeksSidebar : WarnaTeksUtama;

                    ncb.DefaultLocation = false;
                    ncb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    if (ncb.Parent != null)
                    {
                        ncb.Location = new Point(ncb.Parent.ClientSize.Width - ncb.Width, 0);
                        ncb.Parent.Resize += (s, e) =>
                        {
                            if (ncb.Parent != null)
                            {
                                ncb.Location = new Point(ncb.Parent.ClientSize.Width - ncb.Width, 0);
                                ncb.BringToFront();
                            }
                        };
                    }
                    ncb.BringToFront();
                }

                if (child.HasChildren)
                {
                    AturNightControlBoxRekursif(child);
                }
            }
        }

        private static void PasangRekursif(Form targetForm, Control induk)
        {
            foreach (Control ctrl in induk.Controls)
            {
                // Kontrol yang aman untuk drag: Panel, Label, PictureBox
                if (ctrl is Panel || ctrl is Label || ctrl is PictureBox)
                {
                    if (!ctrl.GetType().Name.Contains("NightControlBox") && !ctrl.GetType().Name.Contains("ControlBox"))
                    {
                        PasangDrag(targetForm, ctrl);
                    }
                }

                bool adalahLogin = targetForm is FormLogin;
                if (ctrl is Panel pnl)
                {
                    if (!adalahLogin && pnl.Name == "pnlKiri")
                    {
                        pnl.BackColor = WarnaSidebar;
                        TerapkanTemaSidebar(pnl, targetForm);
                    }
                    else if (!adalahLogin && pnl.Name == "pnlKanan")
                    {
                        pnl.BackColor = WarnaLatarKonten;
                    }
                    else if (adalahLogin && pnl.Name == "pnlKiri")
                    {
                        pnl.BackColor = WarnaLatarKonten;
                    }
                    else if (adalahLogin && pnl.Name == "pnlKanan")
                    {
                        pnl.BackColor = WarnaSidebar;
                    }
                    else if (pnl.Name == "pnlGaris" || pnl.Height == 1)
                    {
                        pnl.BackColor = WarnaGarisTepi;
                    }
                    else if (pnl.BackColor.ToArgb() == Color.FromArgb(247, 247, 245).ToArgb() ||
                             (pnl.BackColor.ToArgb() == Color.FromArgb(249, 250, 251).ToArgb() && pnl.Name.StartsWith("pnlSub")))
                    {
                        pnl.BackColor = WarnaLatarKonten;
                    }
                    else if (pnl.BackColor.ToArgb() == Color.White.ToArgb() ||
                             pnl.BackColor.ToArgb() == Color.FromArgb(249, 250, 251).ToArgb())
                    {
                        pnl.BackColor = WarnaKartu;
                    }
                }
                else if (ctrl is DataGridView grid)
                {
                    TerapkanWarnaGrid(grid);
                    RapikanGrid(grid);
                }
                else if (ctrl is ListBox lst)
                {
                    if (lst.BackColor.ToArgb() == Color.White.ToArgb())
                    {
                        lst.BackColor = WarnaKartu;
                    }
                    if (lst.ForeColor.ToArgb() == Color.FromArgb(180, 35, 24).ToArgb())
                    {
                        lst.ForeColor = WarnaStatusHabis;
                    }
                }
                else if (ctrl is Button btn && (induk.Name != "pnlKiri" || adalahLogin))
                {
                    btn.Text = HapusEmoji(btn.Text);
                    int bg = btn.BackColor.ToArgb();
                    int fg = btn.ForeColor.ToArgb();

                    if (bg == Color.FromArgb(255, 196, 0).ToArgb() || bg == WarnaAksen.ToArgb())
                    {
                        GayaTombolPrimer(btn);
                    }
                    else if (bg == Color.FromArgb(220, 38, 38).ToArgb())
                    {
                        GayaTombolBahaya(btn, true);
                    }
                    else if (fg == Color.FromArgb(220, 38, 38).ToArgb() || fg == Color.FromArgb(153, 27, 27).ToArgb() ||
                             bg == Color.FromArgb(254, 226, 226).ToArgb())
                    {
                        GayaTombolBahaya(btn, false);
                    }
                    else if (bg == Color.FromArgb(16, 149, 102).ToArgb())
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.BackColor = WarnaStatusAman;
                        btn.ForeColor = WarnaKartu;
                    }
                    else if (bg == Color.FromArgb(245, 158, 11).ToArgb() || bg == Color.FromArgb(217, 119, 6).ToArgb())
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.BackColor = WarnaStatusMinimum;
                        btn.ForeColor = WarnaKartu;
                    }
                    else if (bg == Color.White.ToArgb() || bg == Color.FromArgb(243, 244, 246).ToArgb())
                    {
                        GayaTombolSekunder(btn);
                    }
                }
                else if (ctrl is Label lbl)
                {
                    if (!adalahLogin && induk.Name == "pnlKiri")
                    {
                        lbl.ForeColor = WarnaTeksSidebar;
                    }
                    else if (!(adalahLogin && induk.Name == "pnlKanan"))
                    {
                        int fg = lbl.ForeColor.ToArgb();
                        if (fg == Color.FromArgb(31, 41, 55).ToArgb() || fg == Color.FromArgb(55, 65, 81).ToArgb() || fg == Color.Black.ToArgb())
                        {
                            lbl.ForeColor = WarnaTeksUtama;
                        }
                        else if (fg == Color.FromArgb(107, 114, 128).ToArgb() || fg == Color.FromArgb(75, 85, 99).ToArgb() || fg == Color.FromArgb(156, 163, 175).ToArgb())
                        {
                            lbl.ForeColor = WarnaTeksSekunder;
                        }
                        else if (fg == Color.FromArgb(16, 149, 102).ToArgb())
                        {
                            lbl.ForeColor = WarnaStatusAman;
                        }
                        else if (fg == Color.FromArgb(180, 35, 24).ToArgb() || fg == Color.FromArgb(220, 38, 38).ToArgb())
                        {
                            lbl.ForeColor = WarnaStatusHabis;
                        }
                        else if (fg == Color.FromArgb(217, 119, 6).ToArgb())
                        {
                            lbl.ForeColor = WarnaStatusMinimum;
                        }
                    }
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
        private static bool PerluGarisTepi(Control ctrl)
        {
            if (ctrl is DataGridView)
            {
                return true;
            }
            return ctrl is Panel && ctrl.Dock == DockStyle.None &&
                   ctrl.Name != "pnlGaris" && ctrl.Name != "pnlAksenLogin" &&
                   (ctrl.BackColor.ToArgb() == WarnaKartu.ToArgb() || ctrl.BackColor.ToArgb() == Color.White.ToArgb());
        }

        private static readonly ConditionalWeakTable<Control, object> IndukBergaris = new ConditionalWeakTable<Control, object>();
        private static readonly ConditionalWeakTable<DataGridView, string> GridBadgeTerpasang = new ConditionalWeakTable<DataGridView, string>();

        public static void PasangBadgeStatusGrid(DataGridView grid, DataGridViewColumn kolomStatus)
        {
            if (grid == null || kolomStatus == null) return;

            kolomStatus.MinimumWidth = Math.Max(kolomStatus.MinimumWidth, 100);
            kolomStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            kolomStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (GridBadgeTerpasang.TryGetValue(grid, out _)) return;
            GridBadgeTerpasang.Add(grid, kolomStatus.Name);

            grid.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null) return;
                if (grid.Columns[e.ColumnIndex].Name != kolomStatus.Name) return;

                string status = (e.FormattedValue?.ToString() ?? e.Value?.ToString() ?? "").Trim().ToUpperInvariant();
                if (string.IsNullOrEmpty(status)) return;

                e.PaintBackground(e.ClipBounds, true);
                using (Pen penGrid = new Pen(grid.GridColor))
                {
                    e.Graphics.DrawLine(penGrid, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }

                var (fore, back, border) = WarnaStatusStok(status);
                int lebarBadge = Math.Min(Math.Max(72, e.CellBounds.Width - 16), 92);
                int tinggiBadge = Math.Min(24, Math.Max(18, e.CellBounds.Height - 10));
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - lebarBadge) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - tinggiBadge) / 2,
                    lebarBadge,
                    tinggiBadge);

                using (SolidBrush brBack = new SolidBrush(back))
                using (Pen penBorder = new Pen(border))
                {
                    e.Graphics.FillRectangle(brBack, rect);
                    e.Graphics.DrawRectangle(penBorder, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                }

                using Font fontBadge = FontInter.Buat(8.5F, FontStyle.Bold);
                TextRenderer.DrawText(
                    e.Graphics,
                    status,
                    fontBadge,
                    rect,
                    fore,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

                e.Handled = true;
            };
        }

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
                kolom.MinimumWidth = Math.Max(kolom.MinimumWidth, 64);
            }

            string gabungan = (kolom.Name ?? "") + "|" + (kolom.DataPropertyName ?? "") + "|" + (kolom.HeaderText ?? "");

            if (gabungan.IndexOf("Faktur", StringComparison.OrdinalIgnoreCase) >= 0 ||
                gabungan.IndexOf("Nomor", StringComparison.OrdinalIgnoreCase) >= 0 ||
                string.Equals(kolom.Name, "colId", StringComparison.OrdinalIgnoreCase))
            {
                kolom.MinimumWidth = Math.Max(kolom.MinimumWidth, 175);
            }

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
