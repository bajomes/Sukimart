using System.Globalization;

namespace Sukimart
{
    public partial class FormDashboardAdmin : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");

        public FormDashboardAdmin()
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            btnKasir.Click += btnKasir_Click;
            btnGudang.Click += btnGudang_Click;
            btnLaporan.Click += btnLaporan_Click;

            IsiDashboard();
        }

        private void IsiDashboard()
        {
            lblTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");

            try
            {
                List<Transaksi> daftarTransaksi = PenyimpananData.BacaTransaksi();
                List<Barang> daftarBarang = PenyimpananData.BacaBarang();

                List<Transaksi> transaksiHariIni = daftarTransaksi
                    .Where(transaksi => transaksi.Tanggal.Date == DateTime.Today)
                    .ToList();

                lblNilaiTransaksi.Text = HitungTransaksiHariIni(transaksiHariIni).ToString();
                lblNilaiPenjualan.Text = "Rp " + HitungPenjualanHariIni(transaksiHariIni)
                    .ToString("N0", BudayaIndonesia);

                IsiStokMenipis(daftarBarang);
                IsiTransaksiTerbaru(daftarTransaksi);
            }
            catch (Exception ex)
            {
                lblNilaiTransaksi.Text = "0";
                lblNilaiPenjualan.Text = "Rp 0";
                lblNilaiStok.Text = "0";
                lstStokMenipis.Items.Clear();
                dataGridView1.DataSource = null;

                MessageBox.Show(
                    "Data dashboard gagal dibaca. Pastikan file JSON tersedia dan formatnya benar.\n\n" + ex.Message,
                    "Kesalahan Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int HitungTransaksiHariIni(List<Transaksi> transaksiHariIni)
        {
            return transaksiHariIni.Count;
        }

        private int HitungPenjualanHariIni(List<Transaksi> transaksiHariIni)
        {
            return transaksiHariIni.Sum(transaksi => transaksi.Total);
        }

        private void IsiStokMenipis(List<Barang> daftarBarang)
        {
            lstStokMenipis.Items.Clear();

            foreach (Barang barang in daftarBarang)
            {
                if (barang.Stok <= barang.StokMinimum)
                {
                    lstStokMenipis.Items.Add(
                        barang.Nama + " (sisa " + barang.Stok + ")");
                }
            }

            lblNilaiStok.Text = lstStokMenipis.Items.Count.ToString();
        }

        private void IsiTransaksiTerbaru(List<Transaksi> daftarTransaksi)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.DataSource = daftarTransaksi
                .OrderByDescending(transaksi => transaksi.Tanggal)
                .Take(10)
                .Select(transaksi => new
                {
                    Nomor = transaksi.Id,
                    Tanggal = transaksi.Tanggal.ToString("dd/MM/yyyy HH:mm"),
                    Kasir = transaksi.Kasir,
                    Total = "Rp " + transaksi.Total.ToString("N0", BudayaIndonesia)
                })
                .ToList();

            UIHelper.TerapkanWarnaGrid(dataGridView1);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            Navigasi.KeluarKeLogin(this);
        }

        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        private void btnKasir_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKasir(this);
        }

        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }
    }
}
