namespace Sukimart
{
    public partial class FormTambahBarang : Form
    {
        private readonly List<Barang> daftarBarang;
        private Barang? barangEdit;

        public string KodeTersimpan { get; private set; } = "";

        public FormTambahBarang(List<Barang> daftarBarang, Barang? barangEdit)
        {
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            this.daftarBarang = daftarBarang;
            this.barangEdit = barangEdit;

            Paint += (s, e) =>
            {
                using Pen pena = new Pen(UIHelper.WarnaGarisTepi);
                e.Graphics.DrawRectangle(pena, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            };
            btnKelolaKategori.Click += BtnKelolaKategori_Click;
            btnSimpan.Click += BtnSimpan_Click;
            btnBatal.Click += (s, e) => Close();

            if (barangEdit == null)
            {
                MuatKategori("", false);
                nudStokMinimum.Value = 5;
            }
            else
            {
                Text = "Edit Produk";
                lblJudul.Text = "Edit Produk";
                btnSimpan.Text = "Simpan";
                txtKode.Text = barangEdit.Kode;
                txtNama.Text = barangEdit.Nama;
                MuatKategori(barangEdit.Kategori, true);
                nudHarga.Value = Math.Min(nudHarga.Maximum, Math.Max(0, barangEdit.Harga));
                nudStokMinimum.Value = Math.Min(nudStokMinimum.Maximum, Math.Max(0, barangEdit.StokMinimum));
                lblInfo.Text = $"Stok saat ini {barangEdit.Stok}. Ubah stok melalui menu Gudang.";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MuatKategori(string kategoriPilihan, bool tambahJikaTidakAda)
        {
            List<string> daftarKategori;
            try
            {
                daftarKategori = PenyimpananData.BacaKategori();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca data kategori: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daftarKategori = new List<string> { "Lainnya" };
            }

            cmbKategori.Items.Clear();
            foreach (string kategori in daftarKategori)
            {
                cmbKategori.Items.Add(kategori);
            }

            if (tambahJikaTidakAda && !string.IsNullOrWhiteSpace(kategoriPilihan) && !cmbKategori.Items.Contains(kategoriPilihan))
            {
                cmbKategori.Items.Add(kategoriPilihan);
            }

            if (cmbKategori.Items.Contains(kategoriPilihan))
            {
                cmbKategori.SelectedItem = kategoriPilihan;
            }
            else if (cmbKategori.Items.Count > 0)
            {
                cmbKategori.SelectedIndex = 0;
            }
        }

        private void BtnKelolaKategori_Click(object? sender, EventArgs e)
        {
            string kategoriSekarang = cmbKategori.SelectedItem?.ToString() ?? "";
            using (FormKelolaKategori formKategori = new FormKelolaKategori(kategoriSekarang))
            {
                formKategori.ShowDialog(this);
            }

            SegarkanBarang();
            MuatKategori(kategoriSekarang, false);
            if (barangEdit != null && cmbKategori.SelectedItem?.ToString() != kategoriSekarang)
            {
                MuatKategori(barangEdit.Kategori, true);
            }
        }

        private void SegarkanBarang()
        {
            try
            {
                List<Barang> terbaru = PenyimpananData.BacaBarang();
                string? kodeEdit = barangEdit?.Kode;
                daftarBarang.Clear();
                daftarBarang.AddRange(terbaru);
                if (kodeEdit != null)
                {
                    barangEdit = daftarBarang.FirstOrDefault(b => b.Kode == kodeEdit);
                    if (barangEdit == null)
                    {
                        MessageBox.Show("Barang ini sudah tidak ada di katalog.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca ulang data barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSimpan_Click(object? sender, EventArgs e)
        {
            string kode = txtKode.Text.Trim();
            string nama = txtNama.Text.Trim();
            string kategori = cmbKategori.SelectedItem?.ToString() ?? "Lainnya";
            int harga = (int)nudHarga.Value;
            int stokMinimum = (int)nudStokMinimum.Value;

            if (string.IsNullOrWhiteSpace(kode))
            {
                Peringatan("Kode barang wajib diisi.", txtKode);
                return;
            }

            if (string.IsNullOrWhiteSpace(nama))
            {
                Peringatan("Nama barang wajib diisi.", txtNama);
                return;
            }

            bool kodeDipakai = daftarBarang.Any(b => b != barangEdit && b.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase));
            if (kodeDipakai)
            {
                Peringatan($"Kode barang '{kode}' sudah digunakan. Gunakan kode lain.", txtKode);
                txtKode.SelectAll();
                return;
            }

            if (harga <= 0)
            {
                Peringatan("Harga jual harus lebih dari 0.", nudHarga);
                nudHarga.Select(0, nudHarga.Text.Length);
                return;
            }

            if (barangEdit == null)
            {
                TambahBarang(kode, nama, kategori, harga, stokMinimum);
            }
            else
            {
                UbahBarang(barangEdit, kode, nama, kategori, harga, stokMinimum);
            }
        }

        private void TambahBarang(string kode, string nama, string kategori, int harga, int stokMinimum)
        {
            Barang baru = new Barang
            {
                Kode = kode,
                Nama = nama,
                Kategori = kategori,
                Harga = harga,
                Stok = 0,
                StokMinimum = stokMinimum
            };

            daftarBarang.Add(baru);
            try
            {
                PenyimpananData.SimpanBarang(daftarBarang);
            }
            catch (Exception ex)
            {
                daftarBarang.Remove(baru);
                MessageBox.Show("Gagal menyimpan data barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Barang '{nama}' berhasil ditambahkan. Isi stoknya melalui menu Gudang.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KodeTersimpan = kode;
            DialogResult = DialogResult.OK;
        }

        private void UbahBarang(Barang barang, string kode, string nama, string kategori, int harga, int stokMinimum)
        {
            string kodeLama = barang.Kode;
            string namaLama = barang.Nama;
            string kategoriLama = barang.Kategori;
            int hargaLama = barang.Harga;
            int stokMinimumLama = barang.StokMinimum;

            barang.Kode = kode;
            barang.Nama = nama;
            barang.Kategori = kategori;
            barang.Harga = harga;
            barang.StokMinimum = stokMinimum;

            try
            {
                PenyimpananData.SimpanBarang(daftarBarang);
            }
            catch (Exception ex)
            {
                barang.Kode = kodeLama;
                barang.Nama = namaLama;
                barang.Kategori = kategoriLama;
                barang.Harga = hargaLama;
                barang.StokMinimum = stokMinimumLama;
                MessageBox.Show("Gagal memperbarui data barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Data barang '{nama}' berhasil diperbarui.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KodeTersimpan = kode;
            DialogResult = DialogResult.OK;
        }

        private static void Peringatan(string pesan, Control kontrol)
        {
            MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            kontrol.Focus();
        }
    }
}
