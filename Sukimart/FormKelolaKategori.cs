using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    /// <summary>
    /// Window popup kecil dan interaktif untuk mengelola kategori:
    /// Tambah kategori baru, ganti nama kategori, dan hapus kategori.
    /// </summary>
    public partial class FormKelolaKategori : Form
    {
        private List<string> daftarKategori = new List<string>();
        private List<Barang> daftarBarang = new List<Barang>();

        public FormKelolaKategori() : this("")
        {
        }

        public FormKelolaKategori(string kategoriAwal)
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode)
            {
                return;
            }
            MuatData(kategoriAwal);
            FontInter.Terapkan(this);
        }

        private void BtnTutup_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MuatData(string? kategoriPilihan = null)
        {
            try
            {
                daftarKategori = PenyimpananData.BacaKategori();
                daftarBarang = PenyimpananData.BacaBarang();

                lstKategori.Items.Clear();
                foreach (string k in daftarKategori)
                {
                    lstKategori.Items.Add(k);
                }

                if (!string.IsNullOrEmpty(kategoriPilihan) && lstKategori.Items.Contains(kategoriPilihan))
                {
                    lstKategori.SelectedItem = kategoriPilihan;
                }
                else if (lstKategori.Items.Count > 0)
                {
                    lstKategori.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat daftar kategori: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstKategori_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstKategori.SelectedItem == null)
            {
                txtNamaKategori.Clear();
                lblInfo.Text = "Pilih kategori dari daftar di sebelah kiri untuk mengganti nama atau menghapusnya.";
                return;
            }

            string terpilih = lstKategori.SelectedItem.ToString() ?? "";
            txtNamaKategori.Text = terpilih;

            int pemakai = daftarBarang.Count(b => b.Kategori.Equals(terpilih, StringComparison.OrdinalIgnoreCase));
            lblInfo.Text = $"Kategori '{terpilih}' saat ini digunakan oleh {pemakai} barang di katalog.";
        }

        private void BtnTambah_Click(object? sender, EventArgs e)
        {
            string namaBaru = txtNamaKategori.Text.Trim();

            if (string.IsNullOrWhiteSpace(namaBaru))
            {
                MessageBox.Show("Masukkan nama kategori baru pada kotak input!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaKategori.Focus();
                return;
            }

            if (daftarKategori.Any(k => k.Equals(namaBaru, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Kategori '{namaBaru}' sudah ada di dalam daftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaKategori.Focus();
                return;
            }

            try
            {
                daftarKategori.Add(namaBaru);
                PenyimpananData.SimpanKategori(daftarKategori);

                MessageBox.Show($"Kategori baru '{namaBaru}' berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatData(namaBaru);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan kategori baru: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGantiNama_Click(object? sender, EventArgs e)
        {
            if (lstKategori.SelectedItem == null)
            {
                MessageBox.Show("Pilih kategori yang ingin diganti namanya dari daftar di sebelah kiri.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaLama = lstKategori.SelectedItem.ToString() ?? "";
            string namaBaru = txtNamaKategori.Text.Trim();

            if (string.IsNullOrWhiteSpace(namaBaru))
            {
                MessageBox.Show("Nama kategori baru tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaKategori.Focus();
                return;
            }

            if (namaBaru.Equals(namaLama, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Nama kategori tidak berubah.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (daftarKategori.Any(k => k.Equals(namaBaru, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Kategori dengan nama '{namaBaru}' sudah ada di daftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaKategori.Focus();
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin mengubah nama kategori dari '{namaLama}' menjadi '{namaBaru}'?\n\nSemua barang yang menggunakan kategori ini akan otomatis diperbarui.",
                "Konfirmasi Ganti Nama Kategori",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi != DialogResult.Yes) return;

            try
            {
                // Update nama kategori di daftar kategori
                int idx = daftarKategori.FindIndex(k => k.Equals(namaLama, StringComparison.OrdinalIgnoreCase));
                if (idx >= 0)
                {
                    daftarKategori[idx] = namaBaru;
                }
                PenyimpananData.SimpanKategori(daftarKategori);

                // Update semua barang yang memakai nama kategori lama
                int terpengaruh = 0;
                foreach (var b in daftarBarang)
                {
                    if (b.Kategori.Equals(namaLama, StringComparison.OrdinalIgnoreCase))
                    {
                        b.Kategori = namaBaru;
                        terpengaruh++;
                    }
                }

                if (terpengaruh > 0)
                {
                    PenyimpananData.SimpanBarang(daftarBarang);
                }

                MessageBox.Show(
                    $"Nama kategori berhasil diubah menjadi '{namaBaru}'!\nSebanyak {terpengaruh} barang di katalog telah disesuaikan.",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MuatData(namaBaru);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah nama kategori: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapus_Click(object? sender, EventArgs e)
        {
            if (lstKategori.SelectedItem == null)
            {
                MessageBox.Show("Pilih kategori yang ingin dihapus dari daftar di sebelah kiri.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaHapus = lstKategori.SelectedItem.ToString() ?? "";

            if (daftarKategori.Count <= 1)
            {
                MessageBox.Show("Tidak bisa menghapus kategori. Minimal harus ada 1 kategori di katalog!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int terpengaruh = daftarBarang.Count(b => b.Kategori.Equals(namaHapus, StringComparison.OrdinalIgnoreCase));

            string pesan = (terpengaruh > 0)
                ? $"Kategori '{namaHapus}' saat ini digunakan oleh {terpengaruh} barang di katalog.\n\nJika kategori ini dihapus, kategori barang-barang tersebut akan dipindahkan ke kategori 'Lainnya'.\n\nApakah Anda yakin ingin menghapus kategori ini?"
                : $"Apakah Anda yakin ingin menghapus kategori '{namaHapus}' dari katalog?";

            DialogResult konfirmasi = MessageBox.Show(pesan, "Konfirmasi Hapus Kategori", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi != DialogResult.Yes) return;

            try
            {
                // Jika ada barang yang memakai kategori ini, ubah ke "Lainnya"
                if (terpengaruh > 0)
                {
                    if (!daftarKategori.Any(k => k.Equals("Lainnya", StringComparison.OrdinalIgnoreCase)))
                    {
                        daftarKategori.Add("Lainnya");
                    }

                    foreach (var b in daftarBarang)
                    {
                        if (b.Kategori.Equals(namaHapus, StringComparison.OrdinalIgnoreCase))
                        {
                            b.Kategori = "Lainnya";
                        }
                    }
                    PenyimpananData.SimpanBarang(daftarBarang);
                }

                daftarKategori.RemoveAll(k => k.Equals(namaHapus, StringComparison.OrdinalIgnoreCase));
                PenyimpananData.SimpanKategori(daftarKategori);

                MessageBox.Show($"Kategori '{namaHapus}' berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus kategori: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
