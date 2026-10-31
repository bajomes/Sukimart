namespace Sukimart
{
    public partial class FormGudang : Form
    {
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
        private Barang? barangTerpilih;
        private bool hanyaMenipis = false;

        public FormGudang() : this("admin")
        {
        }

        public FormGudang(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? "admin" : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            gridGudang.AllowUserToResizeColumns = true;
            gridGudang.AllowUserToResizeRows = false;
            SesuaikanPeran();
            PasangEventHandlers();
            MuatDataGudang();
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
            btnGudang.Click += (s, e) => { /* Sedang di form gudang */ };
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            txtCariGudang.TextChanged += (s, e) => FilterDaftarGudang();
            btnFilterMenipis.Click += (s, e) => { hanyaMenipis = true; FilterDaftarGudang(); };
            btnSemuaStok.Click += (s, e) => { hanyaMenipis = false; FilterDaftarGudang(); };

            gridGudang.SelectionChanged += GridGudang_SelectionChanged;
            btnSimpanStok.Click += BtnSimpanStok_Click;
        }

        public void MuatDataGudang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                FilterDaftarGudang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data stok gudang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDaftarGudang()
        {
            string keyword = txtCariGudang.Text.Trim().ToLower();

            var query = daftarBarang.AsEnumerable();

            if (hanyaMenipis)
            {
                query = query.Where(b => b.Stok <= b.StokMinimum);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(b =>
                    b.Nama.ToLower().Contains(keyword) ||
                    b.Kode.ToLower().Contains(keyword) ||
                    b.Kategori.ToLower().Contains(keyword));
            }

            var hasil = query.ToList();

            gridGudang.AutoGenerateColumns = false;
            gridGudang.DataSource = hasil.Select(b => new
            {
                b.Kode,
                b.Nama,
                b.Kategori,
                b.Stok,
                b.StokMinimum,
                StatusStok = b.Stok <= b.StokMinimum ? "⚠️ MENIPIS" : "✅ AMAN"
            }).ToList();
        }

        private void GridGudang_SelectionChanged(object? sender, EventArgs e)
        {
            if (gridGudang.CurrentRow == null || gridGudang.CurrentRow.Index < 0)
            {
                barangTerpilih = null;
                txtBarangTerpilih.Clear();
                return;
            }

            var item = gridGudang.CurrentRow.DataBoundItem;
            if (item == null) return;

            string kode = (string)item.GetType().GetProperty("Kode")?.GetValue(item, null)!;
            barangTerpilih = daftarBarang.FirstOrDefault(b => b.Kode == kode);

            if (barangTerpilih != null)
            {
                txtBarangTerpilih.Text = $"{barangTerpilih.Kode} - {barangTerpilih.Nama} (Stok Saat Ini: {barangTerpilih.Stok})";
            }
        }

        private void BtnSimpanStok_Click(object? sender, EventArgs e)
        {
            if (barangTerpilih == null)
            {
                MessageBox.Show("Pilih baris barang yang ingin ditambah stoknya terlebih dahulu pada tabel di atas.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tambahan = (int)nudJumlahMasuk.Value;
            if (tambahan <= 0)
            {
                MessageBox.Show("Jumlah tambahan stok harus lebih dari 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            barangTerpilih.Stok += tambahan;

            try
            {
                PenyimpananData.SimpanBarang(daftarBarang);
                MessageBox.Show(
                    $"Berhasil menambahkan {tambahan} stok untuk barang '{barangTerpilih.Nama}'!\nStok baru sekarang: {barangTerpilih.Stok}",
                    "Stok Berhasil Ditambahkan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MuatDataGudang();
                nudJumlahMasuk.Value = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan penambahan stok ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
