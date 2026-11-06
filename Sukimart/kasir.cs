using System.Globalization;

namespace Sukimart
{
    public partial class FormKasir : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
        private readonly List<ItemKeranjang> keranjang = new List<ItemKeranjang>();
        private bool bayarDiisiManual;
        private bool bayarDiaturOtomatis;

        public FormKasir() : this(Navigasi.PeranAktif)
        {
        }

        public FormKasir(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            AturGridKeranjang();
            lblInfoKasir.Text = $"Kasir: {Navigasi.PenggunaAktif} · {DateTime.Now.ToString("dd/MM/yyyy", BudayaIndonesia)}";
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
            gridKeranjang.CellClick += GridKeranjang_CellClick;
            gridKeranjang.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && KolomAksi(e.ColumnIndex))
                {
                    gridKeranjang.Cursor = Cursors.Hand;
                }
            };
            gridKeranjang.CellMouseLeave += (s, e) => gridKeranjang.Cursor = Cursors.Default;
            nudJumlah.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTambahKeranjang.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
            Shown += (s, e) => FokusPencarian();
            btnUang50.Click += (s, e) => { nudBayar.Value = 50000; HitungKembalian(); };
            btnUang100.Click += (s, e) => { nudBayar.Value = 100000; HitungKembalian(); };
            btnBatalKeranjang.Click += (s, e) => { keranjang.Clear(); PerbaruiTampilanKeranjang(); FokusPencarian(); };
            btnProsesBayar.Click += BtnProsesBayar_Click;

            btnUangPas.Click += (s, e) =>
            {
                int total = keranjang.Sum(k => k.Subtotal);
                if (total > 0)
                {
                    nudBayar.Value = total;
                    HitungKembalian();
                }
            };

            nudBayar.ValueChanged += (s, e) =>
            {
                if (!bayarDiaturOtomatis)
                {
                    bayarDiisiManual = true;
                }
                HitungKembalian();
            };
            nudBayar.KeyUp += (s, e) =>
            {
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    bayarDiisiManual = true;
                }
                HitungKembalian();
            };
            nudBayar.Enter += (s, e) => nudBayar.Select(0, nudBayar.Text.Length);
            nudBayar.Click += (s, e) => nudBayar.Select(0, nudBayar.Text.Length);
            nudBayar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnProsesBayar.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
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

                cmbBarang.SelectedIndex = -1;
                cmbBarang.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTambahKeranjang_Click(object? sender, EventArgs e)
        {
            Barang? barang = CariBarangDipilih();

            if (barang == null)
            {
                MessageBox.Show("Produk tidak ditemukan! Ketik kode atau nama produk, lalu pilih dari daftar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBarang.Focus();
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
            PilihBaris(barang.Kode);
            cmbBarang.SelectedIndex = -1;
            cmbBarang.Text = "";
            FokusPencarian();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (TanganiPintasan(keyData))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool TanganiPintasan(Keys tombol)
        {
            bool diPencarian = cmbBarang.ContainsFocus;
            bool diBayar = nudBayar.ContainsFocus;
            bool pencarianKosong = cmbBarang.Text.Trim().Length == 0;

            switch (tombol)
            {
                case Keys.Enter when diPencarian:
                    if (pencarianKosong)
                    {
                        if (keranjang.Count > 0)
                        {
                            nudBayar.Focus();
                            nudBayar.Select(0, nudBayar.Text.Length);
                        }
                    }
                    else
                    {
                        btnTambahKeranjang.PerformClick();
                    }
                    return true;

                case Keys.Multiply when diPencarian:
                    if (int.TryParse(cmbBarang.Text.Trim(), out int jumlah) && jumlah > 0)
                    {
                        nudJumlah.Value = Math.Min(jumlah, (int)nudJumlah.Maximum);
                        cmbBarang.Text = "";
                    }
                    return true;

                case Keys.Add when !diBayar && !nudJumlah.ContainsFocus:
                    UbahJumlahBarisTerpilih(1);
                    return true;

                case Keys.Subtract when !diBayar && !nudJumlah.ContainsFocus:
                    UbahJumlahBarisTerpilih(-1);
                    return true;

                case Keys.Up when diPencarian && pencarianKosong && !cmbBarang.DroppedDown:
                    PindahBaris(-1);
                    return true;

                case Keys.Down when diPencarian && pencarianKosong && !cmbBarang.DroppedDown:
                    PindahBaris(1);
                    return true;

                case Keys.Delete when (diPencarian && pencarianKosong) || gridKeranjang.ContainsFocus:
                    HapusBarisTerpilih();
                    return true;

                case Keys.Escape when diBayar || nudJumlah.ContainsFocus:
                    FokusPencarian();
                    return true;

                case Keys.Escape when diPencarian && !cmbBarang.DroppedDown:
                    cmbBarang.SelectedIndex = -1;
                    cmbBarang.Text = "";
                    nudJumlah.Value = 1;
                    return true;
            }
            return false;
        }

        private void FokusPencarian()
        {
            cmbBarang.Focus();
            cmbBarang.SelectAll();
        }

        private string? KodeBarisTerpilih()
        {
            if (gridKeranjang.CurrentRow == null || gridKeranjang.CurrentRow.Index < 0)
            {
                return null;
            }
            return gridKeranjang.CurrentRow.Cells[colKode.Index].Value?.ToString();
        }

        private void PilihBaris(string kode)
        {
            foreach (DataGridViewRow baris in gridKeranjang.Rows)
            {
                if (baris.Cells[colKode.Index].Value?.ToString() == kode)
                {
                    gridKeranjang.CurrentCell = baris.Cells[colNama.Index];
                    return;
                }
            }
        }

        private void PindahBaris(int arah)
        {
            if (gridKeranjang.Rows.Count == 0)
            {
                return;
            }
            int sekarang = gridKeranjang.CurrentRow?.Index ?? 0;
            int tujuan = Math.Max(0, Math.Min(gridKeranjang.Rows.Count - 1, sekarang + arah));
            gridKeranjang.CurrentCell = gridKeranjang.Rows[tujuan].Cells[colNama.Index];
        }

        private void UbahJumlahBarisTerpilih(int perubahan)
        {
            string? kode = KodeBarisTerpilih();
            if (kode != null)
            {
                UbahJumlahItem(kode, perubahan);
            }
        }

        private void HapusBarisTerpilih()
        {
            string? kode = KodeBarisTerpilih();
            if (kode == null)
            {
                return;
            }
            int indeks = gridKeranjang.CurrentRow!.Index;
            keranjang.RemoveAll(k => k.KodeBarang == kode);
            PerbaruiTampilanKeranjang();
            if (gridKeranjang.Rows.Count > 0)
            {
                gridKeranjang.CurrentCell = gridKeranjang.Rows[Math.Min(indeks, gridKeranjang.Rows.Count - 1)].Cells[colNama.Index];
            }
        }

        private void UbahJumlahItem(string kode, int perubahan)
        {
            var item = keranjang.FirstOrDefault(k => k.KodeBarang == kode);
            if (item == null)
            {
                return;
            }

            if (perubahan > 0)
            {
                Barang? barang = daftarBarang.FirstOrDefault(b => b.Kode == kode);
                if (barang != null && item.Jumlah + perubahan > barang.Stok)
                {
                    MessageBox.Show($"Stok produk '{barang.Nama}' tidak mencukupi!\nStok tersedia: {barang.Stok}", "Stok Terbatas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (item.Jumlah + perubahan < 1)
            {
                return;
            }

            item.Jumlah += perubahan;
            PerbaruiTampilanKeranjang();
            PilihBaris(kode);
        }

        private Barang? CariBarangDipilih()
        {
            string teks = cmbBarang.SelectedIndex >= 0 ? cmbBarang.SelectedItem?.ToString() ?? "" : cmbBarang.Text;
            teks = teks.Trim();
            if (teks.Length == 0)
            {
                return null;
            }

            string kode = teks.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
            Barang? barang = daftarBarang.FirstOrDefault(b => string.Equals(b.Kode, kode, StringComparison.OrdinalIgnoreCase));
            if (barang != null)
            {
                return barang;
            }

            var cocok = daftarBarang.Where(b => b.Stok > 0 && b.Nama.Contains(teks, StringComparison.OrdinalIgnoreCase)).ToList();
            return cocok.Count == 1 ? cocok[0] : null;
        }

        private void AturGridKeranjang()
        {
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn kolom in new DataGridViewColumn[] { colKurang, colTambah, colHapus })
            {
                kolom.MinimumWidth = 36;
                kolom.Width = 36;
                kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                kolom.DefaultCellStyle.Font = FontInter.Buat(12F, FontStyle.Bold);
                kolom.DefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
                kolom.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
            }
            colHapus.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
            colHapus.DefaultCellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
        }

        private bool KolomAksi(int indeks)
        {
            return indeks == colKurang.Index || indeks == colTambah.Index || indeks == colHapus.Index;
        }

        private void GridKeranjang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !KolomAksi(e.ColumnIndex))
            {
                return;
            }

            string kode = gridKeranjang.Rows[e.RowIndex].Cells[colKode.Index].Value?.ToString() ?? "";

            if (e.ColumnIndex == colTambah.Index)
            {
                UbahJumlahItem(kode, 1);
            }
            else if (e.ColumnIndex == colKurang.Index)
            {
                UbahJumlahItem(kode, -1);
            }
            else
            {
                gridKeranjang.CurrentCell = gridKeranjang.Rows[e.RowIndex].Cells[colNama.Index];
                HapusBarisTerpilih();
            }
        }

        private void PerbaruiTampilanKeranjang()
        {
            if (keranjang.Count == 0)
            {
                bayarDiisiManual = false;
                AturBayarOtomatis(0);
            }

            gridKeranjang.AutoGenerateColumns = false;
            gridKeranjang.DataSource = keranjang.Select(k => new
            {
                k.KodeBarang,
                k.NamaBarang,
                HargaFormat = "Rp " + k.Harga.ToString("N0", BudayaIndonesia),
                k.Jumlah,
                SubtotalFormat = "Rp " + k.Subtotal.ToString("N0", BudayaIndonesia),
                Kurang = "−",
                Tambah = "+",
                Hapus = "×"
            }).ToList();

            int jumlahItem = keranjang.Sum(k => k.Jumlah);
            lblInfoKeranjang.Text = $"{keranjang.Count} produk · {jumlahItem} item";

            int total = keranjang.Sum(k => k.Subtotal);
            lblTotalNilai.Text = "Rp " + total.ToString("N0", BudayaIndonesia);

            if (!bayarDiisiManual || nudBayar.Value < (decimal)total)
            {
                AturBayarOtomatis(total);
            }

            HitungKembalian();
        }

        private void AturBayarOtomatis(int nilai)
        {
            bayarDiaturOtomatis = true;
            nudBayar.Value = nilai;
            bayarDiaturOtomatis = false;
        }

        private int NilaiBayarDiketik()
        {
            string angka = new string(nudBayar.Text.Where(char.IsDigit).ToArray());
            if (!decimal.TryParse(angka, out decimal nilai))
            {
                return 0;
            }
            return (int)Math.Min(nilai, nudBayar.Maximum);
        }

        private void HitungKembalian()
        {
            int total = keranjang.Sum(k => k.Subtotal);
            int bayar = NilaiBayarDiketik();
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
                foreach (var item in keranjang)
                {
                    var brg = daftarBarang.FirstOrDefault(b => b.Kode == item.KodeBarang);
                    if (brg != null)
                    {
                        brg.Stok = Math.Max(0, brg.Stok - item.Jumlah);
                    }
                }

                PenyimpananData.TambahTransaksi(trx, details);
                PenyimpananData.SimpanBarang(daftarBarang);

                try
                {
                    using FormStruk formStruk = new FormStruk(trx, details);
                    formStruk.ShowDialog(this);
                }
                catch (Exception exStruk)
                {
                    MessageBox.Show("Transaksi sudah tersimpan, tetapi struk gagal ditampilkan: " + exStruk.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                keranjang.Clear();
                MuatDataBarang();
                PerbaruiTampilanKeranjang();
                FokusPencarian();
            }
            catch (Exception ex)
            {
                MuatDataBarang();
                MessageBox.Show("Gagal menyimpan transaksi ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormTransaksi : FormKasir
    {
        public FormTransaksi() : base("kasir") { }
        public FormTransaksi(string peran) : base(peran) { }
    }
}
