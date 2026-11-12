using System.Globalization;

namespace Sukimart
{
    public partial class FormKatalog : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();

        public FormKatalog() : this(Navigasi.PeranAktif)
        {
        }

        public FormKatalog(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            UIHelper.RatakanTengah(colStok, colStokMin);
            gridBarang.AllowUserToResizeRows = false;
            SesuaikanPeran();
            PasangEventHandlers();
            MuatDataBarang();
        }

        private void SesuaikanPeran()
        {
            bool bolehKelola = this.peran != "kasir";
            btnTambahItem.Visible = bolehKelola;
            btnEditProduk.Visible = bolehKelola;
            btnHapusBarang.Visible = bolehKelola;
            if (!bolehKelola)
            {
                gridBarang.Height += btnTambahItem.Bottom - gridBarang.Bottom;
            }

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
                btnKasir.Visible = true;
                btnRiwayat.Visible = true;
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
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

            btnTambahItem.Click += BtnTambahItem_Click;
            btnEditProduk.Click += BtnEditProduk_Click;
            btnHapusBarang.Click += BtnHapusBarang_Click;
            gridBarang.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && btnEditProduk.Visible)
                {
                    BtnEditProduk_Click(s, e);
                }
            };
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
            gridBarang.ClearSelection();
        }

        private Barang? BarangTerpilih()
        {
            if (gridBarang.SelectedRows.Count == 0)
            {
                return null;
            }

            object? item = gridBarang.SelectedRows[0].DataBoundItem;
            string? kode = item?.GetType().GetProperty("Kode")?.GetValue(item, null) as string;
            return daftarBarang.FirstOrDefault(b => b.Kode == kode);
        }

        private void BtnTambahItem_Click(object? sender, EventArgs e)
        {
            using FormTambahBarang formTambah = new FormTambahBarang(daftarBarang, null);
            bool tersimpan = formTambah.ShowDialog(this) == DialogResult.OK;
            MuatDataBarang();
            if (tersimpan)
            {
                PilihBarang(formTambah.KodeTersimpan);
            }
        }

        private void BtnEditProduk_Click(object? sender, EventArgs e)
        {
            Barang? barang = BarangTerpilih();
            if (barang == null)
            {
                MessageBox.Show("Pilih barang dari tabel yang ingin diedit terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridBarang.Focus();
                return;
            }

            using FormTambahBarang formEdit = new FormTambahBarang(daftarBarang, barang);
            bool tersimpan = formEdit.ShowDialog(this) == DialogResult.OK;
            MuatDataBarang();
            if (tersimpan)
            {
                PilihBarang(formEdit.KodeTersimpan);
            }
        }

        private void PilihBarang(string kode)
        {
            gridBarang.ClearSelection();
            foreach (DataGridViewRow baris in gridBarang.Rows)
            {
                object? item = baris.DataBoundItem;
                if (item?.GetType().GetProperty("Kode")?.GetValue(item, null) as string == kode)
                {
                    baris.Selected = true;
                    gridBarang.CurrentCell = baris.Cells[0];
                    break;
                }
            }
        }

        private void BtnHapusBarang_Click(object? sender, EventArgs e)
        {
            Barang? barang = BarangTerpilih();
            if (barang == null)
            {
                MessageBox.Show("Pilih barang dari tabel yang ingin dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridBarang.Focus();
                return;
            }

            // Cek apakah barang pernah terjual (ada di detail transaksi)
            List<DetailTransaksi> daftarDetail = PenyimpananData.BacaDetailTransaksi();
            bool pernahTerjual = daftarDetail.Any(d => d.KodeBarang == barang.Kode);
            if (pernahTerjual)
            {
                MessageBox.Show(
                    $"Barang '{barang.Nama}' ({barang.Kode}) tidak dapat dihapus karena pernah terjual.\n" +
                    "Data transaksi harus tetap terjaga.",
                    "Tidak Dapat Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek apakah barang pernah ada riwayat stok (barang masuk/keluar)
            List<RiwayatStok> daftarRiwayat = PenyimpananData.BacaRiwayatStok();
            bool adaRiwayat = daftarRiwayat.Any(r => r.KodeBarang == barang.Kode);
            if (adaRiwayat)
            {
                MessageBox.Show(
                    $"Barang '{barang.Nama}' ({barang.Kode}) tidak dapat dihapus karena sudah pernah dicatat masuk atau keluar di gudang.",
                    "Tidak Dapat Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus barang '{barang.Nama}' ({barang.Kode})?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                int posisi = daftarBarang.IndexOf(barang);
                try
                {
                    daftarBarang.Remove(barang);
                    PenyimpananData.SimpanBarang(daftarBarang);
                    MessageBox.Show("Barang berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataBarang();
                }
                catch (Exception ex)
                {
                    daftarBarang.Insert(posisi, barang);
                    MessageBox.Show("Gagal menghapus barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
