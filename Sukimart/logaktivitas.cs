using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormLogAktivitas : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private List<Aktivitas> daftarAktivitas = new List<Aktivitas>();
        private List<Aktivitas> daftarTerfilter = new List<Aktivitas>();

        public FormLogAktivitas()
        {
            InitializeComponent();

            if (Navigasi.PeranAktif != "admin")
            {
                MessageBox.Show("Menu Log Aktivitas hanya dapat diakses oleh Admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load += (s, e) => BeginInvoke(new Action(() => Navigasi.BukaDashboard(this)));
                return;
            }

            UIHelper.InisialisasiForm(this);
            UIHelper.SusunTombolSidebar(pnlKiri);
            MaximizeBox = true;

            UIHelper.RatakanTengah(colNo, colWaktu, colPengguna, colJenis);
            gridLog.AllowUserToResizeRows = false;
            colNo.FillWeight = 50F;
            colNo.MinimumWidth = 45;
            colWaktu.FillWeight = 160F;
            colWaktu.MinimumWidth = 150;
            colPengguna.FillWeight = 110F;
            colPengguna.MinimumWidth = 90;
            colJenis.FillWeight = 130F;
            colJenis.MinimumWidth = 110;
            colAksi.FillWeight = 350F;
            colAksi.MinimumWidth = 250;
            colAksi.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            PasangNavigasi();
            InisialisasiFilter();

            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            MuatLogAktivitas();
        }

        private void PasangNavigasi()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => { /* Sedang di form Log Aktivitas */ };
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);

            btnSegarkan.Click += (s, e) => MuatLogAktivitas();
            btnBersihkan.Click += (s, e) => BersihkanLog();

            txtCari.TextChanged += (s, e) => TerapkanFilter();
            cmbFilterJenis.SelectedIndexChanged += (s, e) => TerapkanFilter();
            cmbFilterWaktu.SelectedIndexChanged += (s, e) => TerapkanFilter();

            gridLog.CellDoubleClick += GridLog_CellDoubleClick;
        }

        private void InisialisasiFilter()
        {
            cmbFilterJenis.Items.Clear();
            cmbFilterJenis.Items.AddRange(new object[]
            {
                "Semua Jenis",
                "Login",
                "Logout",
                "Login Gagal",
                "Tambah Barang",
                "Ubah Barang",
                "Hapus Barang",
                "Tambah Kategori",
                "Ubah Kategori",
                "Hapus Kategori",
                "Tambah Akun",
                "Ubah Password",
                "Ubah Nama",
                "Ubah Akun",
                "Hapus Akun",
                "Transaksi",
                "Stok Masuk",
                "Stok Keluar"
            });
            cmbFilterJenis.SelectedIndex = 0;

            if (cmbFilterWaktu.SelectedIndex < 0)
            {
                cmbFilterWaktu.SelectedIndex = 0;
            }
        }

        private void AturTataLetakResponsif()
        {
            int margin = 40;
            int lebarTersedia = pnlKanan.ClientSize.Width - (margin * 2);
            if (lebarTersedia < 500) return;

            if (nightControlBox1 != null)
            {
                nightControlBox1.Location = new Point(pnlKanan.ClientSize.Width - nightControlBox1.Width, 0);
                nightControlBox1.BringToFront();
            }

            lblJudul.Location = new Point(margin, 32);

            // Panel filter tepat di bawah judul pada Y = 112
            pnlFilter.Location = new Point(margin, 112);
            pnlFilter.Size = new Size(lebarTersedia, 56);

            // Posisikan tombol Refresh dan Bersihkan log di kanan secara presisi agar tidak menumpuk
            btnBersihkan.Location = new Point(pnlFilter.ClientSize.Width - btnBersihkan.Width - 16, 12);
            btnSegarkan.Location = new Point(btnBersihkan.Left - btnSegarkan.Width - 8, 12);

            // Grid di bawah panel filter
            int yGrid = pnlFilter.Bottom + 12;
            int tinggiGrid = Math.Max(200, pnlKanan.ClientSize.Height - yGrid - 68);
            gridLog.Location = new Point(margin, yGrid);
            gridLog.Size = new Size(lebarTersedia, tinggiGrid);

            lblStatusTabel.Location = new Point(margin, gridLog.Bottom + 8);
        }

        public void MuatLogAktivitas()
        {
            try
            {
                daftarAktivitas = PenyimpananData.BacaAktivitas();
                TerapkanFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat log aktivitas: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daftarAktivitas = new List<Aktivitas>();
            }
        }

        private void TerapkanFilter()
        {
            string keyword = txtCari.Text.Trim().ToLowerInvariant();
            string jenisPilihan = cmbFilterJenis.SelectedItem?.ToString() ?? "Semua Jenis";
            int indexWaktu = cmbFilterWaktu.SelectedIndex;

            DateTime batasWaktu = indexWaktu switch
            {
                1 => DateTime.Today,                           // Hari Ini
                2 => DateTime.Today.AddDays(-7),                // 7 Hari Terakhir
                3 => DateTime.Today.AddDays(-30),               // 30 Hari Terakhir
                _ => DateTime.MinValue                          // Semua Waktu
            };

            daftarTerfilter = daftarAktivitas
                .Where(a =>
                {
                    // Filter Waktu
                    if (indexWaktu > 0 && a.Tanggal < batasWaktu)
                    {
                        return false;
                    }

                    // Filter Jenis Aktivitas
                    if (jenisPilihan != "Semua Jenis")
                    {
                        if (!string.Equals(a.JenisAktivitas, jenisPilihan, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }

                    // Filter Pencarian Teks
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        bool cocokUser = (a.NamaPengguna ?? "").ToLowerInvariant().Contains(keyword);
                        bool cocokJenis = (a.JenisAktivitas ?? "").ToLowerInvariant().Contains(keyword);
                        bool cocokAksi = (a.Aksi ?? "").ToLowerInvariant().Contains(keyword);
                        bool cocokWaktu = a.Tanggal.ToString("dd/MM/yyyy HH:mm:ss").Contains(keyword);

                        if (!cocokUser && !cocokJenis && !cocokAksi && !cocokWaktu)
                        {
                            return false;
                        }
                    }

                    return true;
                })
                .OrderByDescending(a => a.Tanggal)
                .ToList();

            // Tampilkan dengan format waktu yang presisi hingga detik
            int nomor = 1;
            gridLog.AutoGenerateColumns = false;
            gridLog.DataSource = daftarTerfilter.Select(a =>
            {
                string aksiBersih = BersihkanDetailAksi(a.Aksi);
                return new
                {
                    No = nomor++,
                    Waktu = a.Tanggal.ToString("dd/MM/yyyy HH:mm:ss", BudayaIndonesia),
                    Pengguna = string.IsNullOrEmpty(a.NamaPengguna) ? "sistem" : a.NamaPengguna,
                    Jenis = string.IsNullOrEmpty(a.JenisAktivitas) ? PenyimpananData.TentukanJenisAktivitas(a.Aksi) : a.JenisAktivitas,
                    Aksi = aksiBersih,
                    DetailAktivitas = aksiBersih
                };
            }).ToList();

            gridLog.ClearSelection();
            lblStatusTabel.Text = $"Menampilkan {daftarTerfilter.Count} dari total {daftarAktivitas.Count} aktivitas tercatat.";
        }

        private static string BersihkanDetailAksi(string? aksi)
        {
            if (string.IsNullOrWhiteSpace(aksi)) return "-";
            if (aksi.StartsWith("Aktivitas: Mengganti Kata Sandi", StringComparison.OrdinalIgnoreCase))
            {
                return "Pengguna berhasil mengganti kata sandi akunnya sendiri.";
            }
            return aksi;
        }

        private void GridLog_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= daftarTerfilter.Count)
            {
                return;
            }

            var item = daftarTerfilter[e.RowIndex];
            string waktuPresisi = item.Tanggal.ToString("dddd, dd MMMM yyyy HH:mm:ss", BudayaIndonesia);
            string aksiBersih = BersihkanDetailAksi(item.Aksi);
            string pesan = $"Rincian Log Aktivitas:\n\n" +
                           $"• Waktu Presisi: {waktuPresisi}\n" +
                           $"• Akun Pengguna: {item.NamaPengguna}\n" +
                           $"• Jenis Aktivitas: {item.JenisAktivitas}\n\n" +
                           $"• Keterangan Lengkap:\n{aksiBersih}";

            MessageBox.Show(pesan, "Detail Aktivitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BersihkanLog()
        {
            if (Navigasi.PeranAktif != "admin")
            {
                MessageBox.Show("Hanya akun dengan peran Admin yang dapat membersihkan log aktivitas.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin membersihkan (mengosongkan) seluruh catatan log aktivitas?\n\nTindakan ini tidak dapat dibatalkan.",
                "Konfirmasi Bersihkan Log",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (konfirmasi != DialogResult.Yes)
            {
                return;
            }

            try
            {
                PenyimpananData.BersihkanAktivitas();
                PenyimpananData.CatatAktivitas(
                    Navigasi.PenggunaAktif,
                    "Bersihkan Log",
                    $"Seluruh riwayat log aktivitas telah dibersihkan oleh Admin ({Navigasi.PenggunaAktif})."
                );

                MessageBox.Show("Seluruh catatan log aktivitas berhasil dibersihkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatLogAktivitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membersihkan log aktivitas: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
