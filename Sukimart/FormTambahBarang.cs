using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    /// <summary>
    /// Window popup form terpisah khusus untuk menambah barang baru ke katalog.
    /// Memisahkan proses input barang baru dari form pengeditan produk.
    /// Tidak otomatis menutup setelah menyimpan sehingga user bisa input banyak barang sekaligus.
    /// </summary>
    public partial class FormTambahBarang : Form
    {
        private bool sudahAdaTambahan = false;

        public FormTambahBarang()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
            {
                return;
            }
            MuatKategori();
            FontInter.Terapkan(this);
        }

        private void BtnKelolaKat_Click(object? sender, EventArgs e)
        {
            string katDipilih = cmbKategori.SelectedItem?.ToString() ?? "";
            using (FormKelolaKategori formKat = new FormKelolaKategori(katDipilih))
            {
                formKat.ShowDialog(this);
            }
            MuatKategori();
        }

        private void BtnBatal_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MuatKategori()
        {
            string saatIni = cmbKategori.SelectedItem?.ToString() ?? "";
            cmbKategori.Items.Clear();

            var daftarKategori = PenyimpananData.BacaKategori();
            foreach (string k in daftarKategori)
            {
                cmbKategori.Items.Add(k);
            }

            if (!string.IsNullOrEmpty(saatIni) && cmbKategori.Items.Contains(saatIni))
            {
                cmbKategori.SelectedItem = saatIni;
            }
            else if (cmbKategori.Items.Count > 0)
            {
                cmbKategori.SelectedIndex = 0;
            }
        }

        private void BtnSimpan_Click(object? sender, EventArgs e)
        {
            string kode = txtKode.Text.Trim();
            string nama = txtNama.Text.Trim();
            string kategori = cmbKategori.SelectedItem?.ToString() ?? "Lainnya";
            int harga = (int)nudHarga.Value;
            int stok = (int)nudStok.Value;
            int stokMin = (int)nudStokMinimum.Value;

            if (string.IsNullOrWhiteSpace(kode))
            {
                MessageBox.Show("Kode barang wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama barang wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus();
                return;
            }

            if (harga <= 0)
            {
                MessageBox.Show("Harga barang harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudHarga.Focus();
                return;
            }

            try
            {
                var daftarBarang = PenyimpananData.BacaBarang();

                if (daftarBarang.Any(b => b.Kode.Equals(kode, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"Kode barang '{kode}' sudah digunakan oleh produk lain!\nSilakan gunakan kode barang yang berbeda.", "Kode Sudah Digunakan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKode.Focus();
                    return;
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

                daftarBarang.Add(baru);
                PenyimpananData.SimpanBarang(daftarBarang);

                MessageBox.Show($"Produk '{nama}' ({kode}) berhasil ditambahkan ke katalog!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tandai bahwa ada barang yang telah ditambahkan
                sudahAdaTambahan = true;

                // Reset form agar user siap mengetik barang berikutnya tanpa form tertutup
                txtKode.Clear();
                txtNama.Clear();
                nudHarga.Value = 0;
                nudStok.Value = 10;
                nudStokMinimum.Value = 5;
                txtKode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data barang ke JSON: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Saat user selesai dan menutup popup (klik Batal / X / Esc),
            // DialogResult diset OK jika sebelumnya sudah ada barang yang disimpan
            if (sudahAdaTambahan)
            {
                this.DialogResult = DialogResult.OK;
            }
            base.OnFormClosing(e);
        }
    }
}
