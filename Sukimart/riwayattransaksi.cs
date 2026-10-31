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
            MaximizeBox = false;
            gridTransaksi.AllowUserToResizeColumns = true;
            gridTransaksi.AllowUserToResizeRows = false;
            gridDetail.AllowUserToResizeColumns = true;
            gridDetail.AllowUserToResizeRows = false;
            SesuaikanPeran();
            dtpMulai.Value = DateTime.Today.AddDays(-30);
            dtpSelesai.Value = DateTime.Today;

            PasangEventHandlers();
            MuatData();
        }

        private void SesuaikanPeran()
        {
            if (this.peran == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
            }
            else
            {
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
            }
        }

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => { /* Sedang di form riwayat */ };
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            btnFilter.Click += (s, e) => TerapkanFilter();
            btnReset.Click += (s, e) => ResetFilter();
            txtCari.TextChanged += (s, e) => TerapkanFilter();

            gridTransaksi.SelectionChanged += GridTransaksi_SelectionChanged;
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

            if (hasil.Count == 0)
            {
                gridDetail.DataSource = null;
                lblDetailJudul.Text = "Rincian Item Barang (Tidak ada transaksi dipilih)";
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

    /// <summary>
    /// Kelas kompatibilitas untuk referensi lama FormRiwayat.
    /// </summary>
    public class FormRiwayat : FormRiwayatTransaksi
    {
    }
}
