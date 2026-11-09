using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sukimart
{
    public partial class FormKatalog : Form
    {
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private readonly string peran;
        private List<Barang> daftarBarang = new List<Barang>();
        private string? kodeTerpilih;
        private bool sedangBersihkan = false;

        public FormKatalog() : this(Navigasi.PeranAktif)
        {
        }

        public FormKatalog(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();

            // Cegah error saat form dibuka di Visual Studio Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
            {
                return;
            }

            UIHelper.InisialisasiForm(this);
            MaximizeBox = false;
            gridBarang.AllowUserToResizeRows = false;
            SesuaikanPeran();
            MuatKategoriKeComboBox();
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

                btnSimpanBarang.Visible = false;
                btnUbahBarang.Visible = false;
                btnHapusBarang.Visible = false;
                btnBersihkanBarang.Visible = false;
                btnKelolaKategori.Visible = false;
                

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
                btnSimpanBarang.Visible = true;
                btnUbahBarang.Visible = true;
                btnHapusBarang.Visible = true;
                btnBersihkanBarang.Visible = true;
                btnKelolaKategori.Visible = true;
                

                txtKode.ReadOnly = true;
                txtNamaBarang.ReadOnly = false;
                cmbKategori.Enabled = true;
                nudHarga.ReadOnly = false;
                nudStok.ReadOnly = false;
                nudStokMinimum.ReadOnly = false;
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
            btnKeluar.Click += (s, e) => Navigasi.KeluarKeLogin(this);

            txtCari.TextChanged += (s, e) => FilterDaftarBarang();
            gridBarang.SelectionChanged += GridBarang_SelectionChanged;

            btnSimpanBarang.Click += BtnSimpanBarang_Click;
            btnUbahBarang.Click += BtnUbahBarang_Click;
            btnHapusBarang.Click += BtnHapusBarang_Click;
            btnBersihkanBarang.Click += (s, e) => BersihkanForm();
            btnKelolaKategori.Click += BtnKelolaKategori_Click;
            
        }

        public void MuatKategoriKeComboBox(string? pilihanTerpilih = null)
        {
            try
            {
                string saatIni = pilihanTerpilih ?? cmbKategori.SelectedItem?.ToString() ?? "";
                cmbKategori.Items.Clear();

                var daftarKategori = PenyimpananData.BacaKategori();
                foreach (string kat in daftarKategori)
                {
                    cmbKategori.Items.Add(kat);
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
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kategori: " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnKelolaKategori_Click(object? sender, EventArgs e)
        {
            string katDipilih = cmbKategori.SelectedItem?.ToString() ?? "";
            using (FormKelolaKategori formKat = new FormKelolaKategori(katDipilih))
            {
                formKat.ShowDialog(this);
            }
            MuatKategoriKeComboBox();
            MuatDataBarang();
        }

        private void BtnSimpanBarang_Click(object? sender, EventArgs e)
        {
            using (FormTambahBarang formTambah = new FormTambahBarang())
            {
                DialogResult hasil = formTambah.ShowDialog(this);
                if (hasil == DialogResult.OK)
                {
                    MuatKategoriKeComboBox();
                    MuatDataBarang();
                }
            }
        }

        private void BtnUbahBarang_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kodeTerpilih))
            {
                MessageBox.Show("Pilih barang dari tabel terlebih dahulu untuk diubah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaBaru = txtNamaBarang.Text.Trim();
            string kategoriBaru = cmbKategori.SelectedItem?.ToString() ?? "Lainnya";
            int hargaBaru = (int)nudHarga.Value;
            int stokBaru = (int)nudStok.Value;
            int stokMinBaru = (int)nudStokMinimum.Value;

            if (string.IsNullOrWhiteSpace(namaBaru))
            {
                MessageBox.Show("Nama barang tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaBarang.Focus();
                return;
            }

            if (hargaBaru <= 0)
            {
                MessageBox.Show("Harga barang harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudHarga.Focus();
                return;
            }

            try
            {
                var barangTarget = daftarBarang.FirstOrDefault(b => b.Kode.Equals(kodeTerpilih, StringComparison.OrdinalIgnoreCase));
                if (barangTarget == null)
                {
                    MessageBox.Show("Data barang tidak ditemukan di katalog!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                barangTarget.Nama = namaBaru;
                barangTarget.Kategori = kategoriBaru;
                barangTarget.Harga = hargaBaru;
                barangTarget.Stok = stokBaru;
                barangTarget.StokMinimum = stokMinBaru;

                PenyimpananData.SimpanBarang(daftarBarang);
                MessageBox.Show($"Barang '{namaBaru}' ({kodeTerpilih}) berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuatDataBarang();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan perubahan barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapusBarang_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kodeTerpilih))
            {
                MessageBox.Show("Pilih barang yang ingin dihapus dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var barangTarget = daftarBarang.FirstOrDefault(b => b.Kode.Equals(kodeTerpilih, StringComparison.OrdinalIgnoreCase));
            if (barangTarget == null)
            {
                MessageBox.Show("Data barang tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus barang berikut?\n\nKode: {barangTarget.Kode}\nNama: {barangTarget.Nama}\nKategori: {barangTarget.Kategori}",
                "Konfirmasi Hapus Barang",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (konfirmasi != DialogResult.Yes) return;

            try
            {
                daftarBarang.RemoveAll(b => b.Kode.Equals(kodeTerpilih, StringComparison.OrdinalIgnoreCase));
                PenyimpananData.SimpanBarang(daftarBarang);
                MessageBox.Show($"Barang '{barangTarget.Nama}' berhasil dihapus dari katalog!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuatDataBarang();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatDataBarang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();
                FilterDaftarBarang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca data barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDaftarBarang()
        {
            string kataKunci = txtCari.Text.Trim().ToLower(BudayaIndonesia);
            var hasil = string.IsNullOrEmpty(kataKunci)
                ? daftarBarang
                : daftarBarang.Where(b =>
                    b.Nama.ToLower(BudayaIndonesia).Contains(kataKunci) ||
                    b.Kode.ToLower(BudayaIndonesia).Contains(kataKunci) ||
                    b.Kategori.ToLower(BudayaIndonesia).Contains(kataKunci)).ToList();

            gridBarang.Rows.Clear();
            foreach (var b in hasil)
            {
                int index = gridBarang.Rows.Add(
                    b.Kode,
                    b.Nama,
                    b.Kategori,
                    b.Harga.ToString("C0", BudayaIndonesia),
                    b.Stok,
                    b.StokMinimum);

                // Tandai baris jika stok berada di bawah atau sama dengan stok minimum
                if (b.Stok <= b.StokMinimum)
                {
                    gridBarang.Rows[index].DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    gridBarang.Rows[index].DefaultCellStyle.Font = new Font(gridBarang.Font, FontStyle.Bold);
                }
            }
        }

        private void GridBarang_SelectionChanged(object? sender, EventArgs e)
        {
            if (sedangBersihkan) return;

            if (gridBarang.CurrentRow != null && gridBarang.CurrentRow.Index >= 0)
            {
                var baris = gridBarang.CurrentRow;
                kodeTerpilih = baris.Cells["colKode"].Value?.ToString();

                txtKode.Text = kodeTerpilih ?? "";
                txtNamaBarang.Text = baris.Cells["colNama"].Value?.ToString() ?? "";

                string kategori = baris.Cells["colKategori"].Value?.ToString() ?? "";
                if (cmbKategori.Items.Contains(kategori))
                {
                    cmbKategori.SelectedItem = kategori;
                }
                else
                {
                    cmbKategori.Text = kategori;
                }

                // Ambil data asli dari daftarBarang agar nilainya akurat numerik
                var barang = daftarBarang.FirstOrDefault(b => b.Kode == kodeTerpilih);
                if (barang != null)
                {
                    nudHarga.Value = Math.Min(nudHarga.Maximum, Math.Max(nudHarga.Minimum, barang.Harga));
                    nudStok.Value = Math.Min(nudStok.Maximum, Math.Max(nudStok.Minimum, barang.Stok));
                    nudStokMinimum.Value = Math.Min(nudStokMinimum.Maximum, Math.Max(nudStokMinimum.Minimum, barang.StokMinimum));
                }

                txtKode.ReadOnly = true;
                txtNamaBarang.ReadOnly = this.peran == "kasir";
            }
        }

        private void BersihkanForm()
        {
            sedangBersihkan = true;
            try
            {
                kodeTerpilih = null;
                txtKode.ReadOnly = true;
                txtNamaBarang.ReadOnly = this.peran == "kasir";
                txtKode.Clear();
                txtNamaBarang.Clear();
                cmbKategori.SelectedIndex = -1;
                cmbKategori.Text = "";
                nudHarga.Value = 0;
                nudStok.Value = 0;
                nudStokMinimum.Value = 5;
                gridBarang.ClearSelection();
                gridBarang.CurrentCell = null;
            }
            finally
            {
                sedangBersihkan = false;
            }
        }
    }
}
