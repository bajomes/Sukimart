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
            gridGudang.AllowUserToResizeRows = false;
            cmbJenisStok.SelectedIndex = 0;
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
                btnPengguna.Visible = false;
            }
            else
            {
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
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
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            txtCariGudang.TextChanged += (s, e) => FilterDaftarGudang();
            btnFilterMenipis.Click += (s, e) => { hanyaMenipis = true; FilterDaftarGudang(); };
            btnSemuaStok.Click += (s, e) => { hanyaMenipis = false; FilterDaftarGudang(); };

            gridGudang.SelectionChanged += GridGudang_SelectionChanged;
            btnSimpanStok.Click += BtnSimpanStok_Click;
            btnRiwayatStok.Click += (s, e) =>
            {
                using FormRiwayatStok formRiwayat = new FormRiwayatStok();
                formRiwayat.ShowDialog(this);
            };
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
                MessageBox.Show("Pilih barang pada tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int jumlah = (int)nudJumlahMasuk.Value;
            if (jumlah <= 0)
            {
                MessageBox.Show("Jumlah stok harus lebih dari 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool stokKeluar = cmbJenisStok.SelectedIndex == 1;
            if (stokKeluar && jumlah > barangTerpilih.Stok)
            {
                MessageBox.Show($"Stok keluar tidak boleh melebihi stok saat ini ({barangTerpilih.Stok}).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stokSebelum = barangTerpilih.Stok;
            int stokSesudah = stokKeluar ? stokSebelum - jumlah : stokSebelum + jumlah;
            string jenis = stokKeluar ? "Stok Keluar" : "Stok Masuk";

            try
            {
                barangTerpilih.Stok = stokSesudah;
                PenyimpananData.SimpanBarang(daftarBarang);
            }
            catch (Exception ex)
            {
                barangTerpilih.Stok = stokSebelum;
                MessageBox.Show("Gagal menyimpan perubahan stok: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PenyimpananData.TambahRiwayatStok(new RiwayatStok
                {
                    Tanggal = DateTime.Now,
                    KodeBarang = barangTerpilih.Kode,
                    NamaBarang = barangTerpilih.Nama,
                    Jenis = jenis,
                    Jumlah = jumlah,
                    StokSebelum = stokSebelum,
                    StokSesudah = stokSesudah,
                    Keterangan = txtKeterangan.Text.Trim(),
                    Pengguna = Navigasi.PenggunaAktif
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok sudah tersimpan, tetapi riwayat stok gagal dicatat: " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show(
                $"{jenis} {jumlah} untuk '{barangTerpilih.Nama}' berhasil disimpan.\nStok sekarang: {stokSesudah}",
                "Stok Diperbarui",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            string kodeTerakhir = barangTerpilih.Kode;
            MuatDataGudang();
            PilihBaris(kodeTerakhir);
            nudJumlahMasuk.Value = 10;
            txtKeterangan.Clear();
        }

        private void PilihBaris(string kode)
        {
            foreach (DataGridViewRow baris in gridGudang.Rows)
            {
                var item = baris.DataBoundItem;
                if (item?.GetType().GetProperty("Kode")?.GetValue(item, null) as string == kode)
                {
                    gridGudang.CurrentCell = baris.Cells[0];
                    return;
                }
            }
        }
    }
}
