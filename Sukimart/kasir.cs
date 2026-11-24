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

        // State filter kategori dan produk terpilih dari kartu visual
        private string kategoriTerpilih = "Semua";
        private List<Button> daftarTombolKategori = new List<Button>();
        private Barang? barangTerpilihKartu;

        public FormKasir() : this(Navigasi.PeranAktif)
        {
        }

        public FormKasir(string peran)
        {
            this.peran = string.IsNullOrEmpty(peran) ? Navigasi.PeranAktif : peran;
            InitializeComponent();
            UIHelper.InisialisasiForm(this);
            MaximizeBox = true;
            AturGridKeranjang();
            lblInfoKasir.Text = $"Kasir: {Navigasi.PenggunaAktif} · {DateTime.Now.ToString("dd/MM/yyyy", BudayaIndonesia)}";
            SesuaikanPeran();
            MuatDataBarang();
            PerbaruiTampilanKeranjang();
        }

        private void SesuaikanPeran()
        {
            if (this.peran == "kasir")
            {
                btnGudang.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
                btnLogAktivitas.Visible = false;
            }
            else
            {
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnPengguna.Visible = true;
                btnLogAktivitas.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        // ==========================================
        // EVENT HANDLER NAVIGASI SIDEBAR
        // ==========================================

        // Berpindah ke tampilan Dashboard utama
        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaDashboard(this);
        }

        // Halaman saat ini sudah kasir/POS, tidak perlu tindakan tambahan
        private void btnKasir_Click(object? sender, EventArgs e)
        {
            // Sudah berada di form kasir
        }

        // Membuka form Katalog Produk
        private void btnKatalog_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaKatalog(this);
        }

        // Membuka form Riwayat Transaksi penjualan
        private void btnRiwayat_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaRiwayat(this);
        }

        // Membuka form Manajemen Gudang (Stok Masuk / Keluar)
        private void btnGudang_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaGudang(this);
        }

        // Membuka form Laporan Penjualan & Gudang
        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLaporan(this);
        }

        // Membuka form Manajemen Akun Pengguna
        private void btnPengguna_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaPengguna(this);
        }

        // Membuka form Log Aktivitas sistem
        private void btnLogAktivitas_Click(object? sender, EventArgs e)
        {
            Navigasi.BukaLogAktivitas(this);
        }

        // Konfirmasi keluar akun (Logout) dan kembali ke form Login
        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            Navigasi.KonfirmasiDanKeluar(this);
        }

        // Fokuskan kursor otomatis ke kolom pencarian produk saat form dibuka
        private void FormKasir_Shown(object? sender, EventArgs e)
        {
            FokusPencarian();
        }

        // Saat teks pencarian berubah, perbarui daftar kartu produk secara live
        private void cmbBarang_TextChanged(object? sender, EventArgs e)
        {
            TampilkanKartuProduk();
        }

        // Menambahkan barang yang dipilih ke keranjang belanja (Kasus Uji 4 & 5)
        private void btnTambahKeranjang_Click(object? sender, EventArgs e)
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

            // Validasi stok barang: jika pembelian melebihi sisa stok, tolak dengan pesan jelas
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
                // Simpan HargaBeli pada saat transaksi terjadi untuk kalkulator laba yang akurat
                keranjang.Add(new ItemKeranjang
                {
                    KodeBarang = barang.Kode,
                    NamaBarang = barang.Nama,
                    HargaBeli = barang.HargaBeli,
                    Harga = barang.Harga,
                    Jumlah = qtyBeli
                });
            }

            nudJumlah.Value = 1;
            PerbaruiTampilanKeranjang();
            PilihBaris(barang.Kode);
            cmbBarang.SelectedIndex = -1;
            cmbBarang.Text = "";
            barangTerpilihKartu = null;
            TampilkanKartuProduk();
            FokusPencarian();
        }

        // Tombol cepat bayar: Nominal pas sesuai total belanja
        private void btnUangPas_Click(object? sender, EventArgs e)
        {
            int total = keranjang.Sum(k => k.Subtotal);
            if (total > 0)
            {
                AturBayarOtomatis(total);
                bayarDiisiManual = false;
                HitungKembalian();
            }
        }

        // Tombol cepat menambah nominal bayar: Rp 10.000
        private void btnUang10_Click(object? sender, EventArgs e)
        {
            TambahUangDiterima(10000);
        }

        // Tombol cepat menambah nominal bayar: Rp 20.000
        private void btnUang20_Click(object? sender, EventArgs e)
        {
            TambahUangDiterima(20000);
        }

        // Tombol cepat menambah nominal bayar: Rp 50.000
        private void btnUang50_Click(object? sender, EventArgs e)
        {
            TambahUangDiterima(50000);
        }

        // Tombol cepat menambah nominal bayar: Rp 100.000
        private void btnUang100_Click(object? sender, EventArgs e)
        {
            TambahUangDiterima(100000);
        }

        // Menolkan / menghapus angka pada input pembayaran
        private void btnNolkanBayar_Click(object? sender, EventArgs e)
        {
            nudBayar.Value = 0;
            bayarDiisiManual = true;
            HitungKembalian();
        }

        // Mengosongkan seluruh isi keranjang belanja
        private void btnBatalKeranjang_Click(object? sender, EventArgs e)
        {
            keranjang.Clear();
            PerbaruiTampilanKeranjang();
            FokusPencarian();
        }

        // Menghitung kembalian setiap nilai nominal pembayaran berubah
        private void nudBayar_ValueChanged(object? sender, EventArgs e)
        {
            if (!bayarDiaturOtomatis)
            {
                bayarDiisiManual = true;
            }
            HitungKembalian();
        }

        // Mendeteksi ketikan angka pada kolom pembayaran
        private void nudBayar_KeyUp(object? sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                bayarDiisiManual = true;
            }
            HitungKembalian();
        }

        // Pilih seluruh teks saat kolom bayar dimasuki agar mudah langsung ditimpa
        private void nudBayar_Enter(object? sender, EventArgs e)
        {
            nudBayar.Select(0, nudBayar.Text.Length);
        }

        private void nudBayar_Click(object? sender, EventArgs e)
        {
            nudBayar.Select(0, nudBayar.Text.Length);
        }

        // Menekan Enter di kolom bayar langsung memproses transaksi
        private void nudBayar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProsesBayar.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Menekan Enter di kolom jumlah barang langsung menambahkan ke keranjang
        private void nudJumlah_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTambahKeranjang.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Mengubah cursor menjadi hand saat mouse berada di kolom aksi (+ / - / x)
        private void gridKeranjang_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && KolomAksi(e.ColumnIndex))
            {
                gridKeranjang.Cursor = Cursors.Hand;
            }
        }

        private void gridKeranjang_CellMouseLeave(object? sender, EventArgs e)
        {
            gridKeranjang.Cursor = Cursors.Default;
        }

        public void MuatDataBarang()
        {
            try
            {
                daftarBarang = PenyimpananData.BacaBarang();

                // Isi ComboBox hanya dengan barang aktif yang masih ada stok (pencarian cepat barcode)
                cmbBarang.Items.Clear();
                foreach (Barang b in daftarBarang.Where(b => b.Aktif && b.Stok > 0))
                {
                    cmbBarang.Items.Add($"{b.Nama} [{b.Kode}] · Rp {b.Harga:N0} (Stok: {b.Stok})");
                }

                cmbBarang.SelectedIndex = -1;
                cmbBarang.Text = "";

                // Muat filter kategori dan tampilkan kartu produk visual
                MuatDaftarKategori();
                TampilkanKartuProduk();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Membangun baris tombol filter kategori di atas panel kartu produk
        private void MuatDaftarKategori()
        {
            flowKategori.SuspendLayout();
            flowKategori.Controls.Clear();
            daftarTombolKategori.Clear();

            // Kumpulkan kategori unik dari barang aktif, diawali dengan "Semua"
            List<string> listKategori = new List<string> { "Semua" };
            foreach (Barang b in daftarBarang.Where(b => b.Aktif))
            {
                if (!string.IsNullOrEmpty(b.Kategori) && !listKategori.Contains(b.Kategori, StringComparer.OrdinalIgnoreCase))
                {
                    listKategori.Add(b.Kategori);
                }
            }

            foreach (string kategori in listKategori)
            {
                string tagKategori = kategori;
                Button btnKat = new Button
                {
                    Text = tagKategori,
                    Tag = tagKategori,
                    FlatStyle = FlatStyle.Flat,
                    Font = FontInter.Buat(9F, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Size = new Size(90, 30),
                    Margin = new Padding(0, 4, 6, 4)
                };
                btnKat.FlatAppearance.BorderSize = 1;

                // Klik tombol kategori untuk memfilter kartu produk
                btnKat.Click += TombolKategori_Click;
                daftarTombolKategori.Add(btnKat);
                flowKategori.Controls.Add(btnKat);
            }

            PerbaruiWarnaTombolKategori();
            flowKategori.ResumeLayout();
        }

        // Memperbarui tampilan warna tombol kategori (aktif = kuning, tidak aktif = abu)
        private void PerbaruiWarnaTombolKategori()
        {
            foreach (Button btn in daftarTombolKategori)
            {
                bool aktif = btn.Tag?.ToString() == kategoriTerpilih;
                btn.BackColor = aktif ? Color.FromArgb(255, 196, 0) : Color.White;
                btn.ForeColor = aktif ? Color.FromArgb(31, 41, 55) : Color.FromArgb(75, 85, 99);
                btn.FlatAppearance.BorderColor = aktif ? Color.FromArgb(255, 196, 0) : Color.FromArgb(209, 213, 219);
            }
        }

        // Handler klik tombol kategori: ganti filter dan tampilkan ulang kartu produk
        private void TombolKategori_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string tagKategori)
            {
                kategoriTerpilih = tagKategori;
                PerbaruiWarnaTombolKategori();
                TampilkanKartuProduk();
            }
        }

        // Membangun grid kartu produk visual berdasarkan filter kategori dan kata kunci pencarian
        private void TampilkanKartuProduk()
        {
            flowProduk.SuspendLayout();
            flowProduk.Controls.Clear();

            string kataKunci = cmbBarang.Text.Trim();

            // Filter: barang aktif, sesuai kategori, sesuai kata kunci pencarian
            IEnumerable<Barang> filter = daftarBarang.Where(b => b.Aktif);
            if (kategoriTerpilih != "Semua")
            {
                filter = filter.Where(b => b.Kategori.Equals(kategoriTerpilih, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(kataKunci))
            {
                filter = filter.Where(b =>
                    b.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) ||
                    b.Kode.Contains(kataKunci, StringComparison.OrdinalIgnoreCase));
            }

            List<Barang> hasilFilter = filter.ToList();

            if (hasilFilter.Count == 0)
            {
                // Pesan kosong jika tidak ada produk ditemukan
                Label lblKosong = new Label
                {
                    Text = string.IsNullOrEmpty(kataKunci) ? "Tidak ada produk dalam kategori ini." : $"Tidak ada produk untuk \"{kataKunci}\".",
                    AutoSize = false,
                    Size = new Size(560, 60),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Font = FontInter.Buat(10F)
                };
                flowProduk.Controls.Add(lblKosong);
            }
            else
            {
                foreach (Barang b in hasilFilter)
                {
                    bool dipilih = barangTerpilihKartu != null && barangTerpilihKartu.Kode == b.Kode;
                    KartuProduk kartu = new KartuProduk();
                    kartu.SetBarang(b, dipilih);
                    kartu.Margin = new Padding(0, 0, 10, 10);

                    // Klik sekali: pilih produk (pindah ke cmbBarang & sorot kartu)
                    kartu.KartuDiklik += KartuProduk_Diklik;

                    // Klik ganda: pilih produk DAN langsung tambah ke keranjang
                    kartu.KartuDoubleKlik += KartuProduk_DoubleKlik;

                    flowProduk.Controls.Add(kartu);
                }
            }

            flowProduk.ResumeLayout();
        }

        // Handler klik sekali pada kartu produk: pilih dan isi cmbBarang
        private void KartuProduk_Diklik(object? sender, EventArgs e)
        {
            if (sender is KartuProduk kp && kp.Barang != null)
            {
                PilihKartuProduk(kp.Barang);
            }
        }

        // Handler klik ganda pada kartu produk: pilih DAN langsung tambah ke keranjang
        private void KartuProduk_DoubleKlik(object? sender, EventArgs e)
        {
            if (sender is KartuProduk kp && kp.Barang != null)
            {
                PilihKartuProduk(kp.Barang);
                TambahBarangKeKeranjang(kp.Barang, (int)nudJumlah.Value);
            }
        }

        // Memilih kartu dan mengisi cmbBarang dengan produk yang dipilih
        private void PilihKartuProduk(Barang? barang)
        {
            barangTerpilihKartu = barang;

            // Perbarui status terpilih pada setiap kartu
            foreach (Control c in flowProduk.Controls)
            {
                if (c is KartuProduk kartu)
                {
                    kartu.Terpilih = barang != null && kartu.Barang?.Kode == barang.Kode;
                }
            }

            // Isi cmbBarang sesuai produk yang dipilih agar pintasan keyboard tetap berfungsi
            if (barang != null)
            {
                cmbBarang.Text = $"{barang.Nama} [{barang.Kode}] · Rp {barang.Harga:N0} (Stok: {barang.Stok})";
            }
        }

        // Menambahkan barang langsung dari kartu (tanpa perlu cmbBarang) ke keranjang belanja
        private void TambahBarangKeKeranjang(Barang barang, int qty)
        {
            if (barang.Stok <= 0)
            {
                MessageBox.Show($"Stok barang '{barang.Nama}' sudah habis!", "Stok Habis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemAda = keranjang.FirstOrDefault(k => k.KodeBarang == barang.Kode);
            int qtySekarang = itemAda?.Jumlah ?? 0;

            if (qtySekarang + qty > barang.Stok)
            {
                MessageBox.Show(
                    $"Stok '{barang.Nama}' tidak cukup!\nTersedia: {barang.Stok}, Di keranjang: {qtySekarang}",
                    "Stok Terbatas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (itemAda != null)
            {
                itemAda.Jumlah += qty;
            }
            else
            {
                // Simpan HargaBeli pada saat transaksi terjadi untuk kalkulator laba yang akurat
                keranjang.Add(new ItemKeranjang
                {
                    KodeBarang = barang.Kode,
                    NamaBarang = barang.Nama,
                    HargaBeli = barang.HargaBeli,
                    Harga = barang.Harga,
                    Jumlah = qty
                });
            }

            nudJumlah.Value = 1;
            PerbaruiTampilanKeranjang();
            PilihBaris(barang.Kode);
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

            // 1. Cek apakah teks adalah Kode Barang persis (misal scan barcode atau ketik kode MNM001)
            Barang? barang = daftarBarang.FirstOrDefault(b => string.Equals(b.Kode, teks, StringComparison.OrdinalIgnoreCase));
            if (barang != null)
            {
                return barang;
            }

            // 2. Cek apakah item dipilih dari format baru "Nama [Kode] ..."
            int kurungBuka = teks.IndexOf('[');
            int kurungTutup = teks.IndexOf(']');
            if (kurungBuka >= 0 && kurungTutup > kurungBuka)
            {
                string kodeDiKurung = teks.Substring(kurungBuka + 1, kurungTutup - kurungBuka - 1).Trim();
                barang = daftarBarang.FirstOrDefault(b => string.Equals(b.Kode, kodeDiKurung, StringComparison.OrdinalIgnoreCase));
                if (barang != null)
                {
                    return barang;
                }
            }

            // 3. Dukung juga format lama "Kode - Nama ..."
            if (teks.Contains(" - "))
            {
                string kodeLama = teks.Split(new[] { " - " }, StringSplitOptions.None)[0].Trim();
                barang = daftarBarang.FirstOrDefault(b => string.Equals(b.Kode, kodeLama, StringComparison.OrdinalIgnoreCase));
                if (barang != null)
                {
                    return barang;
                }
            }

            // 4. Cek pencarian parsial Nama Barang (misal ketik "air" atau "susu")
            var cocok = daftarBarang.Where(b => b.Stok > 0 && b.Nama.Contains(teks, StringComparison.OrdinalIgnoreCase)).ToList();
            if (cocok.Count == 1) return cocok[0];
            if (cocok.Count > 1)
            {
                var awalan = cocok.FirstOrDefault(b => b.Nama.StartsWith(teks, StringComparison.OrdinalIgnoreCase));
                return awalan ?? cocok[0];
            }

            // 5. Cek pencarian parsial Kode Barang
            var cocokKode = daftarBarang.Where(b => b.Stok > 0 && b.Kode.Contains(teks, StringComparison.OrdinalIgnoreCase)).ToList();
            if (cocokKode.Count >= 1) return cocokKode[0];

            return null;
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

        // Menangani klik tombol aksi pada baris keranjang (+ tambah qty, - kurang qty, x hapus baris)
        private void gridKeranjang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !KolomAksi(e.ColumnIndex))
            {
                return;
            }

            string kode = gridKeranjang.Rows[e.RowIndex].Cells[colKode.Index].Value?.ToString() ?? "";

            if (e.ColumnIndex == colTambah.Index)
            {
                // Tambah jumlah barang terpilih sebanyak 1
                UbahJumlahItem(kode, 1);
            }
            else if (e.ColumnIndex == colKurang.Index)
            {
                // Kurangi jumlah barang terpilih sebanyak 1
                UbahJumlahItem(kode, -1);
            }
            else
            {
                // Hapus produk dari keranjang belanja
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

        private void TambahUangDiterima(int nominal)
        {
            decimal dasar = bayarDiisiManual ? NilaiBayarDiketik() : 0;
            nudBayar.Value = Math.Min(nudBayar.Maximum, dasar + nominal);
            bayarDiisiManual = true;
            HitungKembalian();
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

        // Memproses pembayaran transaksi kasir, memotong stok, menyimpan data JSON, dan mencetak struk (Kasus Uji 7, 8, 9)
        private void btnProsesBayar_Click(object? sender, EventArgs e)
        {
            // 1. Validasi: Keranjang tidak boleh kosong saat memproses pembayaran (Kasus Uji 6)
            if (keranjang.Count == 0)
            {
                MessageBox.Show("Keranjang belanja masih kosong! Tambahkan produk terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total = keranjang.Sum(k => k.Subtotal);
            int bayar = (int)nudBayar.Value;

            // 2. Validasi: Uang yang dibayarkan tidak boleh kurang dari total belanja (Kasus Uji 8)
            if (bayar < total)
            {
                MessageBox.Show($"Uang pembayaran kurang! Total: Rp {total:N0}, Uang diterima: Rp {bayar:N0}", "Pembayaran Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kembalian = bayar - total;
            // 2b. Buat nomor transaksi berurutan (TRX001, TRX002, TRX005, dst.) sesuai ketentuan Kasus Uji 8
            string idTransaksi = PenyimpananData.BuatIdTransaksi();

            // 3. Buat objek data transaksi utama
            Transaksi trx = new Transaksi
            {
                Id = idTransaksi,
                Tanggal = DateTime.Now,
                Kasir = Navigasi.PenggunaAktif,
                Total = total,
                Bayar = bayar,
                Kembalian = kembalian
            };

            // 4. Buat daftar rincian barang yang dibeli (DetailTransaksi) lengkap dengan HargaBeli saat transaksi
            List<DetailTransaksi> details = keranjang.Select(k => new DetailTransaksi
            {
                IdTransaksi = idTransaksi,
                KodeBarang = k.KodeBarang,
                NamaBarang = k.NamaBarang,
                HargaBeli = k.HargaBeli,
                HargaSatuan = k.Harga,
                Jumlah = k.Jumlah,
                Subtotal = k.Subtotal,
                Tanggal = DateTime.Now
            }).ToList();

            try
            {
                // 5. Potong stok barang di master data dan catat kartu riwayat stok 'TERJUAL' (Kasus Uji 9 & 15)
                foreach (var item in keranjang)
                {
                    var brg = daftarBarang.FirstOrDefault(b => b.Kode == item.KodeBarang);
                    if (brg != null)
                    {
                        int stokSebelum = brg.Stok;
                        brg.Stok = Math.Max(0, brg.Stok - item.Jumlah);

                        try
                        {
                            PenyimpananData.TambahRiwayatStok(new RiwayatStok
                            {
                                Tanggal = DateTime.Now,
                                KodeBarang = brg.Kode,
                                NamaBarang = brg.Nama,
                                Jenis = "TERJUAL",
                                Jumlah = item.Jumlah,
                                StokSebelum = stokSebelum,
                                StokSesudah = brg.Stok,
                                Keterangan = $"Penjualan {idTransaksi}",
                                Pengguna = Navigasi.PenggunaAktif
                            });
                        }
                        catch { }
                    }
                }

                // 6. Simpan transaksi dan pembaharuan stok ke penyimpanan data JSON
                PenyimpananData.TambahTransaksi(trx, details);
                PenyimpananData.SimpanBarang(daftarBarang);

                // 7. Catat aktivitas kasir ke berkas audit log
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Transaksi", $"Transaksi kasir {idTransaksi} selesai: Total Rp {trx.Total:N0}, Bayar Rp {trx.Bayar:N0}, Kembalian Rp {trx.Kembalian:N0} ({details.Count} jenis barang).");

                // 8. Tampilkan dialog pratinjau struk transaksi (Kasus Uji 7)
                try
                {
                    using FormStruk formStruk = new FormStruk(trx, details);
                    formStruk.ShowDialog(this);
                }
                catch (Exception exStruk)
                {
                    MessageBox.Show("Transaksi sudah tersimpan, tetapi struk gagal ditampilkan: " + exStruk.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 9. Bersihkan keranjang belanja dan refresh data untuk transaksi berikutnya
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
}
