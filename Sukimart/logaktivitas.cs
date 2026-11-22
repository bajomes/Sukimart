using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    /// <summary>
    /// FormLogAktivitas: Formulir untuk memantau audit trail dan catatan riwayat aktivitas sistem
    /// (Fitur Esensial E5: log_aktivitas.json).
    /// Mencatat waktu login/logout, penambahan/perubahan/penghapusan barang dan kategori,
    /// mutasi stok masuk/keluar di gudang, dan transaksi penjualan kasir.
    /// </summary>
    public partial class FormLogAktivitas : Form
    {
        // Format tanggal budaya Indonesia (dd/MM/yyyy HH:mm:ss)
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        // Daftar seluruh aktivitas yang dibaca dari log_aktivitas.json
        private List<Aktivitas> daftarAktivitas = new List<Aktivitas>();

        // Daftar aktivitas yang telah difilter berdasarkan kata kunci, jenis, dan periode
        private List<Aktivitas> daftarTerfilter = new List<Aktivitas>();

        public FormLogAktivitas()
        {
            InitializeComponent();

            // Proteksi hak akses: Menu log aktivitas hanya untuk Administrator
            if (Navigasi.PeranAktif != "admin")
            {
                MessageBox.Show("Menu Log Aktivitas hanya dapat diakses oleh Admin.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load += (s, e) => BeginInvoke(new Action(() => Navigasi.BukaDashboard(this)));
                return;
            }

            UIHelper.InisialisasiForm(this);
            UIHelper.SusunTombolSidebar(pnlKiri);
            MaximizeBox = true;

            // Atur perataan teks dan proporsi kolom DataGridView
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

            gridLog.CellDoubleClick += GridLog_CellDoubleClick;

            // Isi pilihan filter jenis aktivitas dan periode
            InisialisasiFilter();

            // Tangani event resize agar tampilan tetap responsif
            pnlKanan.Resize += (s, e) => AturTataLetakResponsif();
            AturTataLetakResponsif();

            // Muat data dari berkas log_aktivitas.json
            MuatLogAktivitas();
        }

        // =========================================================================
        // PENGATURAN TATA LETAK RESPONSIF & FILTER
        // =========================================================================

        /// <summary>
        /// Mengisi pilihan jenis aktivitas dan periode waktu ke dalam dropdown filter.
        /// </summary>
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

        /// <summary>
        /// Menyesuaikan tata letak panel filter, tombol refresh/bersihkan, dan tabel log.
        /// </summary>
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
            lblStatusTabel.Location = new Point(margin, 72);

            // Panel filter tepat di bawah subjudul pada Y = 112
            pnlFilter.Location = new Point(margin, 112);
            pnlFilter.Size = new Size(lebarTersedia, 56);

            // Posisikan tombol Refresh dan Bersihkan log di kanan secara presisi agar tidak menumpuk
            btnBersihkan.Location = new Point(pnlFilter.ClientSize.Width - btnBersihkan.Width - 16, 12);
            btnSegarkan.Location = new Point(btnBersihkan.Left - btnSegarkan.Width - 8, 12);

            // Grid di bawah panel filter (Y = 180) dan berakhir di Y = 680 agar sejajar dengan formulir lain
            int yGrid = pnlFilter.Bottom + 12;
            int tinggiGrid = Math.Max(200, pnlKanan.ClientSize.Height - yGrid - 40);
            gridLog.Location = new Point(margin, yGrid);
            gridLog.Size = new Size(lebarTersedia, tinggiGrid);
        }

        // =========================================================================
        // EVENT HANDLER NAVIGASI SIDEBAR
        // (Tersambung langsung dengan Designer via Event Click)
        // =========================================================================

        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaDashboard(this);
        }

        private void btnKasir_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKasir(this);
        }

        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }

        private void btnPengguna_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaPengguna(this);
        }

        private void btnLogAktivitas_Click(object? sender, EventArgs e)
        {
            // Sedang di form log aktivitas
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }

        // =========================================================================
        // EVENT HANDLER FILTER & AKSI LOG
        // =========================================================================

        // Tombol Refresh: Membaca ulang log dari file log_aktivitas.json
        private void btnSegarkan_Click(object? sender, EventArgs e)
        {
            MuatLogAktivitas();
        }

        // Tombol Bersihkan Log: Menghapus seluruh riwayat log dengan konfirmasi
        private void btnBersihkan_Click(object? sender, EventArgs e)
        {
            BersihkanLog();
        }

        // Pencarian live saat mengetik kata kunci
        private void txtCari_TextChanged(object? sender, EventArgs e)
        {
            TerapkanFilter();
        }

        // Filter saat jenis aktivitas dipilih
        private void cmbFilterJenis_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TerapkanFilter();
        }

        // Filter saat rentang waktu dipilih
        private void cmbFilterWaktu_SelectedIndexChanged(object? sender, EventArgs e)
        {
            TerapkanFilter();
        }

        // =========================================================================
        // LOGIKA PENYARINGAN & PENGOLAHAN DATA
        // =========================================================================

        /// <summary>
        /// Memuat riwayat aktivitas dari penyimpanan data log_aktivitas.json.
        /// </summary>
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

        /// <summary>
        /// Menerapkan kombinasi filter kata kunci, jenis aktivitas, dan periode waktu.
        /// </summary>
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
                    // Filter rentang waktu
                    if (indexWaktu > 0 && a.Tanggal < batasWaktu)
                    {
                        return false;
                    }

                    // Filter jenis aktivitas
                    if (jenisPilihan != "Semua Jenis")
                    {
                        if (!string.Equals(a.JenisAktivitas, jenisPilihan, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }

                    // Filter kata kunci pencarian (username, jenis, detail keterangan, atau tanggal)
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

            // Tampilkan ke DataGridView dengan format waktu presisi hingga detik
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

        /// <summary>
        /// Membersihkan format teks pesan aksi agar lebih mudah dibaca.
        /// </summary>
        private static string BersihkanDetailAksi(string? aksi)
        {
            if (string.IsNullOrWhiteSpace(aksi)) return "-";
            if (aksi.StartsWith("Aktivitas: Mengganti Kata Sandi", StringComparison.OrdinalIgnoreCase))
            {
                return "Pengguna berhasil mengganti kata sandi akunnya sendiri.";
            }
            return aksi;
        }

        /// <summary>
        /// Menampilkan kotak pesan detail saat baris log diklik dua kali.
        /// </summary>
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

        /// <summary>
        /// Mengosongkan file log_aktivitas.json dan mencatat aktivitas pembersihan.
        /// </summary>
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
