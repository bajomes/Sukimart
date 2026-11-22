using System.Globalization;

namespace Sukimart
{
    public partial class FormRiwayatTransaksi : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Transaksi> daftarTransaksi = new List<Transaksi>();
        private List<DetailTransaksi> daftarDetail = new List<DetailTransaksi>();

        public FormRiwayatTransaksi() : this(Navigasi.PeranAktif)
        {
        }

        public FormRiwayatTransaksi(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            gridTransaksi.AllowUserToResizeRows = false;
            gridDetail.AllowUserToResizeRows = false;
            SesuaikanPeran();
            dtpMulai.Value = DateTime.Today.AddDays(-30);
            dtpSelesai.Value = DateTime.Today;
            MuatData();
        }

        private void SesuaikanPeran()
        {
            if (this.peran == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
            }
            else
            {
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        // ==========================================
        // EVENT HANDLER NAVIGASI SIDEBAR
        // ==========================================

        // Membuka halaman Dashboard utama
        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaDashboard(this);
        }

        // Membuka halaman Kasir / POS
        private void btnKasir_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKasir(this);
        }

        // Membuka halaman Katalog Produk
        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        // Halaman saat ini sudah riwayat transaksi
        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            // Sudah berada di form riwayat transaksi
        }

        // Membuka halaman Manajemen Gudang
        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        // Membuka halaman Laporan
        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }

        // Membuka halaman Pengguna
        private void btnPengguna_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaPengguna(this);
        }

        // Konfirmasi keluar (Logout) akun aktif
        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }

        // ==========================================
        // EVENT HANDLER FILTER & AKSI TRANSAKSI
        // ==========================================

        // Menerapkan filter rentang tanggal transaksi dengan validasi
        private void btnFilter_Click(object? sender, EventArgs e)
        {
            if (dtpMulai.Value.Date > dtpSelesai.Value.Date)
            {
                MessageBox.Show("Tanggal mulai tidak boleh setelah tanggal selesai!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpMulai.Focus();
                return;
            }
            TerapkanFilter();
        }

        // Mengembalikan filter transaksi ke rentang bawaan 30 hari terakhir
        private void btnReset_Click(object? sender, EventArgs e)
        {
            ResetFilter();
        }

        // Pencarian dinamis transaksi kasir berdasarkan ID faktur atau nama kasir
        private void txtCari_TextChanged(object? sender, EventArgs e)
        {
            TerapkanFilter();
        }

        // Menampilkan rincian detail barang saat baris transaksi dipilih
        private void gridTransaksi_SelectionChanged(object? sender, EventArgs e)
        {
            GridTransaksi_SelectionChanged(sender, e);
        }

        // Klik dua kali pada baris transaksi membuka pratinjau struk transaksi
        private void gridTransaksi_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TampilkanStruk();
            }
        }

        // Membuka struk transaksi yang sedang dipilih (Kasus Uji 7)
        private void btnLihatStruk_Click(object? sender, EventArgs e)
        {
            TampilkanStruk();
        }

        // Merapikan posisi kartu ringkasan omzet saat jendela aplikasi diubah ukurannya
        private void pnlRingkasan_Resize(object? sender, EventArgs e)
        {
            int sepertiga = pnlRingkasan.ClientSize.Width / 3;
            lblStatTransaksi.Location = new Point(24, 12);
            lblValTransaksi.Location = new Point(24, 32);

            lblStatOmzet.Location = new Point(sepertiga + 24, 12);
            lblValOmzet.Location = new Point(sepertiga + 24, 32);

            lblStatRata.Location = new Point(sepertiga * 2 + 24, 12);
            lblValRata.Location = new Point(sepertiga * 2 + 24, 32);
        }

        public void MuatData()
        {
            try
            {
                daftarTransaksi = PenyimpananData.BacaTransaksi();
                daftarDetail = PenyimpananData.BacaDetailTransaksi();
                TerapkanFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data riwayat transaksi: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TerapkanFilter()
        {
            string keyword = txtCari.Text.Trim().ToLower();
            DateTime tglAwal = dtpMulai.Value.Date;
            DateTime tglAkhir = dtpSelesai.Value.Date.AddDays(1).AddTicks(-1);

            var hasil = daftarTransaksi.Where(t =>
                t.Tanggal >= tglAwal && t.Tanggal <= tglAkhir &&
                (string.IsNullOrEmpty(keyword) ||
                 t.Id.ToLower().Contains(keyword) ||
                 t.Kasir.ToLower().Contains(keyword)))
                .OrderByDescending(t => t.Tanggal)
                .ToList();

            // Hitung ringkasan
            int totalTrx = hasil.Count;
            double totalOmzet = hasil.Sum(t => t.Total);
            double rataRata = totalTrx > 0 ? (totalOmzet / totalTrx) : 0;

            lblValTransaksi.Text = totalTrx.ToString("N0", BudayaIndonesia);
            lblValOmzet.Text = "Rp " + totalOmzet.ToString("N0", BudayaIndonesia);
            lblValRata.Text = "Rp " + rataRata.ToString("N0", BudayaIndonesia);

            gridTransaksi.AutoGenerateColumns = false;
            gridTransaksi.DataSource = hasil.Select(t => new
            {
                t.Id,
                TanggalFormat = t.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                t.Kasir,
                TotalFormat = "Rp " + t.Total.ToString("N0", BudayaIndonesia),
                BayarFormat = "Rp " + t.Bayar.ToString("N0", BudayaIndonesia),
                KembalianFormat = "Rp " + t.Kembalian.ToString("N0", BudayaIndonesia)
            }).ToList();

            btnLihatStruk.Enabled = hasil.Count > 0;

            if (hasil.Count == 0)
            {
                gridDetail.DataSource = null;
                lblDetailJudul.Text = "Rincian Item Barang (Tidak ada transaksi dipilih)";
            }
        }

        private string? IdTransaksiTerpilih()
        {
            var item = gridTransaksi.CurrentRow?.DataBoundItem;
            return item?.GetType().GetProperty("Id")?.GetValue(item, null) as string;
        }

        private void TampilkanStruk()
        {
            string? id = IdTransaksiTerpilih();
            Transaksi? trx = daftarTransaksi.FirstOrDefault(t => t.Id == id);
            if (trx == null)
            {
                MessageBox.Show("Pilih transaksi terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var rincian = daftarDetail.Where(d => d.IdTransaksi == trx.Id).ToList();
                using FormStruk formStruk = new FormStruk(trx, rincian, false);
                formStruk.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan struk: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilter()
        {
            txtCari.Clear();
            dtpMulai.Value = DateTime.Today.AddDays(-30);
            dtpSelesai.Value = DateTime.Today;
            TerapkanFilter();
        }

        private void GridTransaksi_SelectionChanged(object? sender, EventArgs e)
        {
            if (gridTransaksi.CurrentRow == null || gridTransaksi.CurrentRow.Index < 0)
            {
                gridDetail.DataSource = null;
                lblDetailJudul.Text = "Rincian Item Barang (Pilih Faktur)";
                return;
            }

            var item = gridTransaksi.CurrentRow.DataBoundItem;
            if (item == null) return;

            string idTransaksi = (string)item.GetType().GetProperty("Id")?.GetValue(item, null)!;
            var details = daftarDetail.Where(d => d.IdTransaksi == idTransaksi).ToList();

            lblDetailJudul.Text = $"Rincian Item Barang - Faktur #{idTransaksi} ({details.Count} produk)";

            gridDetail.AutoGenerateColumns = false;
            gridDetail.DataSource = details.Select(d => new
            {
                d.KodeBarang,
                d.NamaBarang,
                HargaFormat = "Rp " + d.HargaSatuan.ToString("N0", BudayaIndonesia),
                d.Jumlah,
                SubtotalFormat = "Rp " + d.Subtotal.ToString("N0", BudayaIndonesia)
            }).ToList();
        }
    }
}
