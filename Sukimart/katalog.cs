using System.Globalization;

namespace Sukimart
{
    public partial class FormKatalog : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
        private string? kodeTerpilih;

        public FormKatalog() : this(Navigasi.PeranAktif)
        {
        }

        public FormKatalog(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            gridBarang.AllowUserToResizeRows = false;
            SesuaikanPeran();
            PasangEventHandlers();
            MuatDataBarang();
            BersihkanForm();
        }

        private void SesuaikanPeran()
        {
            if (this.peran == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;

                btnSimpanBarang.Visible = false;
                btnUbahBarang.Visible = false;
                btnHapusBarang.Visible = false;
                btnBersihkanBarang.Visible = false;

                txtKode.ReadOnly = true;
                txtNamaBarang.ReadOnly = true;
                cmbKategori.Enabled = false;
                nudHarga.ReadOnly = true;
                nudStok.ReadOnly = true;
                nudStokMinimum.ReadOnly = true;
            }
            else
            {
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
                btnSimpanBarang.Visible = true;
                btnUbahBarang.Visible = true;
                btnHapusBarang.Visible = true;
                btnBersihkanBarang.Visible = true;
            }
        }

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => Navigasi.BukaKasir(this);
            btnKatalog.Click += (s, e) => { /* Sedang di form katalog */ };
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            txtCari.TextChanged += (s, e) => FilterDaftarBarang();
            gridBarang.SelectionChanged += GridBarang_SelectionChanged;

            btnSimpanBarang.Click += BtnSimpanBarang_Click;
            btnUbahBarang.Click += BtnUbahBarang_Click;
            btnHapusBarang.Click += BtnHapusBarang_Click;
            btnBersihkanBarang.Click += (s, e) => BersihkanForm();
        }

        public void MuatDataBarang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                FilterDaftarBarang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca data katalog: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDaftarBarang()
        {
            string keyword = txtCari.Text.Trim().ToLower();
            var hasil = string.IsNullOrEmpty(keyword)
                ? daftarBarang
                : daftarBarang.Where(b =>
                    b.Nama.ToLower().Contains(keyword) ||
                    b.Kode.ToLower().Contains(keyword) ||
                    b.Kategori.ToLower().Contains(keyword)).ToList();

            gridBarang.AutoGenerateColumns = false;
            gridBarang.DataSource = hasil.Select(b => new
            {
                b.Kode,
                b.Nama,
                b.Kategori,
                HargaFormat = "Rp " + b.Harga.ToString("N0", BudayaIndonesia),
                b.Harga,
                b.Stok,
                b.StokMinimum
            }).ToList();
        }

        private void GridBarang_SelectionChanged(object? sender, EventArgs e)
        {
            if (gridBarang.CurrentRow == null || gridBarang.CurrentRow.Index < 0)
            {
                return;
            }

            var item = gridBarang.CurrentRow.DataBoundItem;
            if (item == null) return;

            string kode = (string)item.GetType().GetProperty("Kode")?.GetValue(item, null)!;
            var barang = daftarBarang.FirstOrDefault(b => b.Kode == kode);
            if (barang != null)
            {
                kodeTerpilih = barang.Kode;
                txtKode.Text = barang.Kode;
                txtKode.ReadOnly = this.peran == "kasir";
                txtNamaBarang.Text = barang.Nama;
                if (!string.IsNullOrEmpty(barang.Kategori) && !cmbKategori.Items.Contains(barang.Kategori))
                {
                    cmbKategori.Items.Add(barang.Kategori);
                }
                cmbKategori.SelectedItem = barang.Kategori;
                if (cmbKategori.SelectedIndex < 0)
                {
                    cmbKategori.Text = barang.Kategori;
                }
                nudHarga.Value = Math.Min(nudHarga.Maximum, Math.Max(0, (decimal)barang.Harga));
                nudStok.Value = Math.Min(nudStok.Maximum, Math.Max(0, barang.Stok));
                nudStok.Enabled = false;
                lblStok.Text = "Stok (ubah lewat Gudang)";
                nudStokMinimum.Value = Math.Min(nudStokMinimum.Maximum, Math.Max(0, barang.StokMinimum));
            }
        }

        private void BtnSimpanBarang_Click(object? sender, EventArgs e)
        {
            string kode = txtKode.Text.Trim();
            string nama = txtNamaBarang.Text.Trim();
            string kategori = cmbKategori.Text.Trim();
            int harga = (int)nudHarga.Value;
            int stok = (int)nudStok.Value;
            int stokMin = (int)nudStokMinimum.Value;

            if (string.IsNullOrWhiteSpace(kode) || string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Kode dan Nama barang wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrWhiteSpace(kode)) txtKode.Focus(); else txtNamaBarang.Focus();
                return;
            }

            if (daftarBarang.Any(b => b.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Kode barang '{kode}' sudah digunakan! Gunakan kode lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKode.Focus();
                txtKode.SelectAll();
                return;
            }

            if (harga <= 0)
            {
                MessageBox.Show("Harga jual harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudHarga.Focus();
                nudHarga.Select(0, nudHarga.Text.Length);
                return;
            }

            if (string.IsNullOrWhiteSpace(kategori))
            {
                kategori = "Lainnya";
            }

            Barang baru = new Barang
            {
                Kode = kode,
                Nama = nama,
                Kategori = kategori,
                Harga = harga,
                Stok = stok,
                StokMinimum = stokMin
            };

            try
            {
                daftarBarang.Add(baru);
                PenyimpananData.SimpanBarang(daftarBarang);
                if (stok > 0)
                {
                    CatatStokAwal(baru);
                }
                MessageBox.Show($"Barang '{nama}' berhasil ditambahkan ke katalog!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatDataBarang();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                daftarBarang.Remove(baru);
                MessageBox.Show("Gagal menyimpan data barang ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUbahBarang_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kodeTerpilih))
            {
                MessageBox.Show("Pilih barang dari tabel yang ingin diubah terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var barang = daftarBarang.FirstOrDefault(b => b.Kode == kodeTerpilih);
            if (barang == null) return;

            string kodeBaru = txtKode.Text.Trim();
            string nama = txtNamaBarang.Text.Trim();
            string kategori = cmbKategori.Text.Trim();

            if (string.IsNullOrWhiteSpace(kodeBaru))
            {
                MessageBox.Show("Kode barang tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama barang tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaBarang.Focus();
                return;
            }

            if (nudHarga.Value <= 0)
            {
                MessageBox.Show("Harga jual harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudHarga.Focus();
                nudHarga.Select(0, nudHarga.Text.Length);
                return;
            }

            // Jika kode diubah, periksa apakah kode baru sudah digunakan oleh barang lain
            if (!kodeBaru.Equals(kodeTerpilih, StringComparison.OrdinalIgnoreCase))
            {
                if (daftarBarang.Any(b => b.Kode.Equals(kodeBaru, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"Kode barang '{kodeBaru}' sudah digunakan oleh barang lain! Gunakan kode yang berbeda.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKode.Focus();
                    txtKode.SelectAll();
                    return;
                }
            }

            string kodeLama = barang.Kode;
            string namaLama = barang.Nama;
            string kategoriLama = barang.Kategori;
            int hargaLama = barang.Harga;
            int stokMinimumLama = barang.StokMinimum;

            try
            {
                barang.Kode = kodeBaru;
                barang.Nama = nama;
                barang.Kategori = string.IsNullOrWhiteSpace(kategori) ? "Lainnya" : kategori;
                barang.Harga = (int)nudHarga.Value;
                barang.StokMinimum = (int)nudStokMinimum.Value;

                PenyimpananData.SimpanBarang(daftarBarang);
                MessageBox.Show($"Data barang '{nama}' ({kodeBaru}) berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatDataBarang();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                barang.Kode = kodeLama;
                barang.Nama = namaLama;
                barang.Kategori = kategoriLama;
                barang.Harga = hargaLama;
                barang.StokMinimum = stokMinimumLama;
                MessageBox.Show("Gagal memperbarui data barang di JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapusBarang_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kodeTerpilih))
            {
                MessageBox.Show("Pilih barang dari tabel yang ingin dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var barang = daftarBarang.FirstOrDefault(b => b.Kode == kodeTerpilih);
            if (barang == null) return;

            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus barang '{barang.Nama}' ({barang.Kode})?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    daftarBarang.Remove(barang);
                    PenyimpananData.SimpanBarang(daftarBarang);
                    MessageBox.Show("Barang berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataBarang();
                    BersihkanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus barang dari JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CatatStokAwal(Barang barang)
        {
            try
            {
                PenyimpananData.TambahRiwayatStok(new RiwayatStok
                {
                    Tanggal = DateTime.Now,
                    KodeBarang = barang.Kode,
                    NamaBarang = barang.Nama,
                    Jenis = "Stok Masuk",
                    Jumlah = barang.Stok,
                    StokSebelum = 0,
                    StokSesudah = barang.Stok,
                    Keterangan = "Stok awal",
                    Pengguna = peran
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Barang tersimpan, tetapi riwayat stok gagal dicatat: " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BersihkanForm()
        {
            kodeTerpilih = null;
            txtKode.ReadOnly = this.peran == "kasir";
            txtKode.Clear();
            txtNamaBarang.Clear();
            cmbKategori.SelectedIndex = -1;
            cmbKategori.Text = "";
            nudHarga.Value = 0;
            nudStok.Value = 0;
            nudStok.Enabled = true;
            lblStok.Text = "Stok Awal";
            nudStokMinimum.Value = 5;
            gridBarang.ClearSelection();
        }
    }
}
