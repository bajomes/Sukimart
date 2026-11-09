using System.Globalization;

namespace Sukimart
{
    public partial class FormLaporan : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Transaksi> semuaTransaksi = new List<Transaksi>();
        private List<DetailTransaksi> semuaDetail = new List<DetailTransaksi>();
        private string periodeAktif = "hari_ini";

        public FormLaporan() : this("admin")
        {
        }

        public FormLaporan(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            gridLaporan.AllowUserToResizeRows = false;
            SesuaikanPeran();
            PasangEventHandlers();
            MuatDataLaporan();
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
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => { /* Sedang di form laporan */ };
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            btnHariIni.Click += (s, e) => AturPeriode("hari_ini");
            btnBulanIni.Click += (s, e) => AturPeriode("bulan_ini");
            btnSemuaWaktu.Click += (s, e) => AturPeriode("semua");
        }

        public void MuatDataLaporan()
        {
            try
            {
                semuaTransaksi = PenyimpananData.BacaTransaksi();
                semuaDetail = PenyimpananData.BacaDetailTransaksi();
                TerapkanLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data laporan: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AturPeriode(string periode)
        {
            periodeAktif = periode;

            btnHariIni.BackColor = Color.White;
            btnHariIni.Font = FontInter.Buat(10F);
            btnHariIni.ForeColor = Color.FromArgb(75, 85, 99);

            btnBulanIni.BackColor = Color.White;
            btnBulanIni.Font = FontInter.Buat(10F);
            btnBulanIni.ForeColor = Color.FromArgb(75, 85, 99);

            btnSemuaWaktu.BackColor = Color.White;
            btnSemuaWaktu.Font = FontInter.Buat(10F);
            btnSemuaWaktu.ForeColor = Color.FromArgb(75, 85, 99);

            if (periode == "hari_ini")
            {
                btnHariIni.BackColor = Color.FromArgb(255, 196, 0);
                btnHariIni.Font = FontInter.Buat(10F, FontStyle.Bold);
                btnHariIni.ForeColor = Color.FromArgb(31, 41, 55);
            }
            else if (periode == "bulan_ini")
            {
                btnBulanIni.BackColor = Color.FromArgb(255, 196, 0);
                btnBulanIni.Font = FontInter.Buat(10F, FontStyle.Bold);
                btnBulanIni.ForeColor = Color.FromArgb(31, 41, 55);
            }
            else
            {
                btnSemuaWaktu.BackColor = Color.FromArgb(255, 196, 0);
                btnSemuaWaktu.Font = FontInter.Buat(10F, FontStyle.Bold);
                btnSemuaWaktu.ForeColor = Color.FromArgb(31, 41, 55);
            }

            TerapkanLaporan();
        }

        private void TerapkanLaporan()
        {
            DateTime sekarang = DateTime.Now;
            List<Transaksi> terfilter;

            if (periodeAktif == "hari_ini")
            {
                terfilter = semuaTransaksi.Where(t => t.Tanggal.Date == DateTime.Today).ToList();
            }
            else if (periodeAktif == "bulan_ini")
            {
                terfilter = semuaTransaksi.Where(t => t.Tanggal.Year == sekarang.Year && t.Tanggal.Month == sekarang.Month).ToList();
            }
            else
            {
                terfilter = semuaTransaksi.ToList();
            }

            var idTerfilter = terfilter.Select(t => t.Id).ToHashSet();
            var detailTerfilter = semuaDetail.Where(d => idTerfilter.Contains(d.IdTransaksi)).ToList();

            double totalOmzet = terfilter.Sum(t => t.Total);
            int totalTrx = terfilter.Count;
            int totalItem = detailTerfilter.Sum(d => d.Jumlah);
            double rataRata = totalTrx > 0 ? (totalOmzet / totalTrx) : 0;

            lblOmzetNilai.Text = "Rp " + totalOmzet.ToString("N0", BudayaIndonesia);
            lblTrxNilai.Text = totalTrx.ToString("N0", BudayaIndonesia);
            lblItemTerjualNilai.Text = totalItem.ToString("N0", BudayaIndonesia) + " pcs";
            lblRataNilai.Text = "Rp " + rataRata.ToString("N0", BudayaIndonesia);

            gridLaporan.AutoGenerateColumns = false;
            gridLaporan.DataSource = terfilter
                .OrderByDescending(t => t.Tanggal)
                .Select(t => new
                {
                    t.Id,
                    WaktuFormat = t.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                    t.Kasir,
                    ItemQty = detailTerfilter.Where(d => d.IdTransaksi == t.Id).Sum(d => d.Jumlah) + " item",
                    TotalFormat = "Rp " + t.Total.ToString("N0", BudayaIndonesia),
                    Status = "Lunas"
                }).ToList();
        }
    }
}
