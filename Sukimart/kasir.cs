using System.Globalization;

namespace Sukimart
{
    public partial class FormKasir : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
        private readonly List<ItemKeranjang> keranjang = new List<ItemKeranjang>();

        public FormKasir() : this(Navigasi.PeranAktif)
        {
        }

        public FormKasir(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            gridKeranjang.AllowUserToResizeColumns = true;
            gridKeranjang.AllowUserToResizeRows = false;
            SesuaikanPeran();
            PasangEventHandlers();
            MuatDataBarang();
            PerbaruiTampilanKeranjang();
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
            btnKasir.Click += (s, e) => { /* Sedang di form kasir */ };
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            btnTambahKeranjang.Click += BtnTambahKeranjang_Click;
            btnHapusKeranjang.Click += BtnHapusKeranjang_Click;
            btnBatalKeranjang.Click += (s, e) => { keranjang.Clear(); PerbaruiTampilanKeranjang(); };
            btnProsesBayar.Click += BtnProsesBayar_Click;

            nudBayar.ValueChanged += (s, e) => HitungKembalian();
            nudBayar.KeyUp += (s, e) => HitungKembalian();
        }

        public void MuatDataBarang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                cmbBarang.Items.Clear();
                foreach (Barang b in daftarBarang.Where(b => b.Stok > 0))
                {
                    cmbBarang.Items.Add($"{b.Kode} - {b.Nama} (Rp {b.Harga:N0} | Stok: {b.Stok})");
                }

                if (cmbBarang.Items.Count > 0)
                {
                    cmbBarang.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTambahKeranjang_Click(object? sender, EventArgs e)
        {
            if (cmbBarang.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih produk terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string teks = cmbBarang.SelectedItem?.ToString() ?? "";
            string kode = teks.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
            Barang? barang = daftarBarang.FirstOrDefault(b => b.Kode == kode);

            if (barang == null)
            {
                MessageBox.Show("Produk tidak ditemukan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int qtyBeli = (int)nudJumlah.Value;
            var itemAda = keranjang.FirstOrDefault(k => k.KodeBarang == barang.Kode);
            int qtySekarang = itemAda?.Jumlah ?? 0;

            if (qtySekarang + qtyBeli > barang.Stok)
            {
                MessageBox.Show(
                    $"Stok produk '{barang.Nama}' tidak mencukupi!\nStok tersedia: {barang.Stok}\nSudah di keranjang: {qtySekarang}",
                    "Stok Terbatas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (itemAda != null)
            {
                itemAda.Jumlah += qtyBeli;
            }
            else
            {
                keranjang.Add(new ItemKeranjang
                {
                    KodeBarang = barang.Kode,
                    NamaBarang = barang.Nama,
                    Harga = barang.Harga,
                    Jumlah = qtyBeli
                });
            }

            nudJumlah.Value = 1;
            PerbaruiTampilanKeranjang();
        }

        private void BtnHapusKeranjang_Click(object? sender, EventArgs e)
        {
            if (gridKeranjang.CurrentRow == null || gridKeranjang.CurrentRow.Index < 0)
            {
                MessageBox.Show("Pilih baris item keranjang yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = gridKeranjang.CurrentRow.DataBoundItem;
            if (item == null) return;

            string kode = (string)item.GetType().GetProperty("KodeBarang")?.GetValue(item, null)!;
            var target = keranjang.FirstOrDefault(k => k.KodeBarang == kode);
            if (target != null)
            {
                keranjang.Remove(target);
                PerbaruiTampilanKeranjang();
            }
        }

        private void PerbaruiTampilanKeranjang()
        {
            if (keranjang.Count == 0)
            {
                nudBayar.Value = 0;
            }

            gridKeranjang.AutoGenerateColumns = false;
            gridKeranjang.DataSource = keranjang.Select(k => new
            {
                k.KodeBarang,
                k.NamaBarang,
                HargaFormat = "Rp " + k.Harga.ToString("N0", BudayaIndonesia),
                k.Jumlah,
                SubtotalFormat = "Rp " + k.Subtotal.ToString("N0", BudayaIndonesia)
            }).ToList();

            int total = keranjang.Sum(k => k.Subtotal);
            lblTotalNilai.Text = "Rp " + total.ToString("N0", BudayaIndonesia);

            if (nudBayar.Value < (decimal)total)
            {
                nudBayar.Value = (decimal)total;
            }

            HitungKembalian();
        }

        private void HitungKembalian()
        {
            int total = keranjang.Sum(k => k.Subtotal);
            int bayar = (int)nudBayar.Value;
            int kembalian = bayar - total;

            if (kembalian >= 0)
            {
                lblKembalianNilai.ForeColor = Color.FromArgb(16, 149, 102);
                lblKembalianNilai.Text = "Rp " + kembalian.ToString("N0", BudayaIndonesia);
            }
            else
            {
                lblKembalianNilai.ForeColor = Color.FromArgb(220, 38, 38);
                lblKembalianNilai.Text = "- Rp " + Math.Abs(kembalian).ToString("N0", BudayaIndonesia);
            }
        }

        private void BtnProsesBayar_Click(object? sender, EventArgs e)
        {
            if (keranjang.Count == 0)
            {
                MessageBox.Show("Keranjang belanja masih kosong! Tambahkan produk terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total = keranjang.Sum(k => k.Subtotal);
            int bayar = (int)nudBayar.Value;

            if (bayar < total)
            {
                MessageBox.Show($"Uang pembayaran kurang! Total: Rp {total:N0}, Uang diterima: Rp {bayar:N0}", "Pembayaran Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kembalian = bayar - total;
            string idTransaksi = "TRX-" + DateTime.Now.ToString("yyyyMMdd-HHmmssfff");

            Transaksi trx = new Transaksi
            {
                Id = idTransaksi,
                Tanggal = DateTime.Now,
                Kasir = Navigasi.PenggunaAktif,
                Total = total,
                Bayar = bayar,
                Kembalian = kembalian
            };

            List<DetailTransaksi> details = keranjang.Select(k => new DetailTransaksi
            {
                IdTransaksi = idTransaksi,
                KodeBarang = k.KodeBarang,
                NamaBarang = k.NamaBarang,
                HargaSatuan = k.Harga,
                Jumlah = k.Jumlah,
                Subtotal = k.Subtotal,
                Tanggal = DateTime.Now
            }).ToList();

            try
            {
                // Potong stok produk di memori setelah validasi pembayaran lolos
                foreach (var item in keranjang)
                {
                    var brg = daftarBarang.FirstOrDefault(b => b.Kode == item.KodeBarang);
                    if (brg != null)
                    {
                        brg.Stok = Math.Max(0, brg.Stok - item.Jumlah);
                    }
                }

                // Simpan ke file JSON
                PenyimpananData.TambahTransaksi(trx, details);
                PenyimpananData.SimpanBarang(daftarBarang);

                string struk = $"=== STRUK TRANSAKSI SUKIMART ===\n" +
                               $"No. Faktur : {idTransaksi}\n" +
                               $"Tanggal    : {trx.Tanggal:dd/MM/yyyy HH:mm}\n" +
                               $"Kasir      : {trx.Kasir}\n" +
                               $"--------------------------------\n";
                foreach (var item in keranjang)
                {
                    struk += $"{item.NamaBarang} x{item.Jumlah} = Rp {item.Subtotal:N0}\n";
                }
                struk += $"--------------------------------\n" +
                         $"TOTAL      : Rp {total:N0}\n" +
                         $"BAYAR      : Rp {bayar:N0}\n" +
                         $"KEMBALIAN  : Rp {kembalian:N0}\n" +
                         $"================================";

                MessageBox.Show("Transaksi berhasil diproses dan disimpan ke JSON!\n\n" + struk, "Transaksi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                keranjang.Clear();
                MuatDataBarang();
                PerbaruiTampilanKeranjang();
            }
            catch (Exception ex)
            {
                // Muat ulang data barang jika penyimpanan gagal agar stok di memori tetap sinkron
                MuatDataBarang();
                MessageBox.Show("Gagal menyimpan transaksi ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Kelas kompatibilitas untuk referensi lama FormTransaksi.
    /// </summary>
    public class FormTransaksi : FormKasir
    {
        public FormTransaksi() : base("kasir") { }
        public FormTransaksi(string peran) : base(peran) { }
    }
}
