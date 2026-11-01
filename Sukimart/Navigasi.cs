using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sukimart
{
    public static class Navigasi
    {
        public static string PeranAktif { get; set; } = "kasir";
        public static string PenggunaAktif { get; set; } = "kasir";
        public static FormLogin? FormLoginUtama { get; set; }
        private static bool sedangBeralih = false;

        public static void MulaiSesi(FormLogin loginForm, string peran)
        {
            MulaiSesi(loginForm, peran, peran);
        }

        public static void MulaiSesi(FormLogin loginForm, string pengguna, string peran)
        {
            FormLoginUtama = loginForm;
            PenggunaAktif = string.IsNullOrEmpty(pengguna) ? "kasir" : pengguna;
            PeranAktif = string.IsNullOrEmpty(peran) ? "kasir" : peran;
            loginForm.Hide();

            Form formAwal = (PeranAktif == "admin")
                ? (Form)new FormDashboardAdmin()
                : (Form)new FormDashboardKasir();

            formAwal.StartPosition = FormStartPosition.CenterScreen;
            formAwal.WindowState = FormWindowState.Normal;
            formAwal.MaximizeBox = false;
            PasangHandlerTutup(formAwal);
            formAwal.Show();
        }

        public static void BeralihKe(Form formBaru, Form formLama)
        {
            if (formBaru == null || formLama == null || formLama.IsDisposed)
            {
                return;
            }

            sedangBeralih = true;

            formBaru.StartPosition = FormStartPosition.Manual;
            formBaru.Location = formLama.Location;
            formBaru.Size = formLama.Size;
            formBaru.WindowState = FormWindowState.Normal;
            formBaru.MaximizeBox = false;

            PasangHandlerTutup(formBaru);

            formBaru.Show();

            formLama.Hide();
            formLama.Close();
            formLama.Dispose();

            sedangBeralih = false;
        }

        private static void PasangHandlerTutup(Form form)
        {
            form.FormClosed += (s, e) =>
            {
                if (!sedangBeralih)
                {
                    KeluarKeLogin(null);
                }
            };
        }

        public static void BukaDashboard(Form formSaatIni)
        {
            if (PeranAktif == "admin")
            {
                if (formSaatIni is FormDashboardAdmin) return;
                BeralihKe(new FormDashboardAdmin(), formSaatIni);
            }
            else
            {
                if (formSaatIni is FormDashboardKasir) return;
                BeralihKe(new FormDashboardKasir(), formSaatIni);
            }
        }

        public static void BukaKasir(Form formSaatIni)
        {
            if (formSaatIni is FormKasir) return;
            BeralihKe(new FormKasir(PeranAktif), formSaatIni);
        }

        public static void BukaKatalog(Form formSaatIni)
        {
            if (formSaatIni is FormKatalog) return;
            BeralihKe(new FormKatalog(PeranAktif), formSaatIni);
        }

        public static void BukaRiwayat(Form formSaatIni)
        {
            if (formSaatIni is FormRiwayatTransaksi) return;
            BeralihKe(new FormRiwayatTransaksi(PeranAktif), formSaatIni);
        }

        public static void BukaGudang(Form formSaatIni)
        {
            if (PeranAktif != "admin")
            {
                MessageBox.Show("Menu Gudang hanya dapat diakses oleh Admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (formSaatIni is FormGudang) return;
            BeralihKe(new FormGudang("admin"), formSaatIni);
        }

        public static void BukaLaporan(Form formSaatIni)
        {
            if (PeranAktif != "admin")
            {
                MessageBox.Show("Menu Laporan hanya dapat diakses oleh Admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (formSaatIni is FormLaporan) return;
            BeralihKe(new FormLaporan("admin"), formSaatIni);
        }

        public static void KeluarKeLogin(Form? formSaatIni)
        {
            sedangBeralih = true;
            if (formSaatIni != null && !formSaatIni.IsDisposed)
            {
                formSaatIni.Hide();
                formSaatIni.Close();
                formSaatIni.Dispose();
            }

            if (FormLoginUtama != null && !FormLoginUtama.IsDisposed)
            {
                FormLoginUtama.ResetInput();
                FormLoginUtama.Show();
                FormLoginUtama.BringToFront();
            }
            else
            {
                Application.Exit();
            }
            sedangBeralih = false;
        }
    }
}
