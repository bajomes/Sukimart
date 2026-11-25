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
        private Barang? barangTerpilih;
        private readonly List<Button> daftarTombolKategori = new List<Button>();
        private string kategoriTerpilih = "Semua";

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
                btnLaporanInventaris.Visible = false;
                btnPengguna.Visible = false;
                btnLogAktivitas.Visible = false;
            }
            else if (this.peran == "gudang")
            {
                btnKasir.Visible = false;
                btnRiwayat.Visible = false;
                btnLaporan.Visible = false;
                btnLaporanInventaris.Visible = true;
                btnPengguna.Visible = false;
                btnGudang.Visible = true;
                btnLogAktivitas.Visible = false;
            }
            else
            {
                btnGudang.Visible = true;
                btnLaporan.Visible = true;
                btnLaporanInventaris.Visible = true;
                btnPengguna.Visible = true;
                btnLogAktivitas.Visible = true;
            }

            UIHelper.SusunTombolSidebar(pnlKiri);
        }

        private void PasangEventHandlers()
        {
            btnDashboard.Click += (s, e) => Navigasi.BukaDashboard(this);
            btnKasir.Click += (s, e) => { /* Sedang di form kasir */ };
            btnKatalog.Click += (s, e) => Navigasi.BukaKatalog(this);
            btnRiwayat.Click += (s, e) => Navigasi.BukaRiwayat(this);
            btnGudang.Click += (s, e) => Navigasi.BukaGudang(this);
            btnLaporan.Click += (s, e) => Navigasi.BukaLaporan(this);
            btnLaporanInventaris.Click += (s, e) => Navigasi.BukaLaporanInventaris(this);
            btnPengguna.Click += (s, e) => Navigasi.BukaPengguna(this);
            btnLogAktivitas.Click += (s, e) => Navigasi.BukaLogAktivitas(this);
            btnGantiSandi.Click += (s, e) => Navigasi.BukaGantiKataSandi(this);
            btnKeluar.Click += (s, e) => Navigasi.KonfirmasiDanKeluar(this);

            btnTambahKeranjang.Click += BtnTambahKeranjang_Click;
            txtCariProduk.TextChanged += (s, e) => TampilkanKartuProduk();
            btnHapusCari.Click += (s, e) =>
            {
                txtCariProduk.Clear();
                txtCariProduk.Focus();
            };
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
            btnUang10.Click += (s, e) => TambahUangDiterima(10000);
            btnUang20.Click += (s, e) => TambahUangDiterima(20000);
            btnUang50.Click += (s, e) => TambahUangDiterima(50000);
            btnUang100.Click += (s, e) => TambahUangDiterima(100000);
            btnNolkanBayar.Click += (s, e) =>
            {
                nudBayar.Value = 0;
                bayarDiisiManual = true;
                HitungKembalian();
            };
            btnBatalKeranjang.Click += (s, e) => { keranjang.Clear(); PerbaruiTampilanKeranjang(); FokusPencarian(); };
            btnProsesBayar.Click += BtnProsesBayar_Click;

            btnUangPas.Click += (s, e) =>
            {
                int total = keranjang.Sum(k => k.Subtotal);
                if (total > 0)
                {
                    AturBayarOtomatis(total);
                    bayarDiisiManual = false;
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
                MuatDaftarKategori();
                TampilkanKartuProduk();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat barang: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatDaftarKategori()
        {
            flowKategori.SuspendLayout();
            flowKategori.Controls.Clear();
            daftarTombolKategori.Clear();

            List<string> listKategori = new List<string> { "Semua" };
            var kategoriUnik = daftarBarang
                .Where(b => b.Aktif)
                .Select(b => b.Kategori?.Trim())
                .Where(k => !string.IsNullOrEmpty(k))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(k => k)
                .ToList();

            foreach (var kat in kategoriUnik)
            {
                if (kat != null && !listKategori.Any(k => string.Equals(k, kat, StringComparison.OrdinalIgnoreCase)))
                {
                    listKategori.Add(kat);
                }
            }

            foreach (var kat in listKategori)
            {
                string tagKategori = kat;
                Button btn = new Button
                {
                    Text = tagKategori,
                    Height = 32,
                    AutoSize = true,
                    MinimumSize = new Size(68, 32),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(0, 0, 8, 0),
                    Tag = tagKategori
                };
                btn.FlatAppearance.BorderSize = 1;
                btn.Click += (s, e) =>
                {
                    kategoriTerpilih = tagKategori;
                    PerbaruiWarnaTombolKategori();
                    TampilkanKartuProduk();
                };

                daftarTombolKategori.Add(btn);
                flowKategori.Controls.Add(btn);
            }

            PerbaruiWarnaTombolKategori();
            flowKategori.ResumeLayout();
        }

        private void PerbaruiWarnaTombolKategori()
        {
            foreach (var btn in daftarTombolKategori)
            {
                bool aktif = string.Equals(btn.Tag?.ToString(), kategoriTerpilih, StringComparison.OrdinalIgnoreCase);
                if (aktif)
                {
                    btn.BackColor = UIHelper.WarnaAksen;
                    btn.ForeColor = UIHelper.WarnaAksen;
                    btn.FlatAppearance.BorderColor = UIHelper.WarnaAksen;
                    btn.Font = FontInter.Buat(9F, FontStyle.Bold);
                }
                else
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = UIHelper.WarnaTeksSekunder;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
                    btn.Font = FontInter.Buat(9F, FontStyle.Regular);
                }
            }
        }

        private void TampilkanKartuProduk()
        {
            flowProduk.SuspendLayout();
            flowProduk.Controls.Clear();

            string kataKunci = txtCariProduk.Text.Trim();

            var hasil = daftarBarang.Where(b => b.Aktif).AsEnumerable();

            if (!string.Equals(kategoriTerpilih, "Semua", StringComparison.OrdinalIgnoreCase))
            {
                hasil = hasil.Where(b => string.Equals(b.Kategori, kategoriTerpilih, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(kataKunci))
            {
                hasil = hasil.Where(b =>
                    (b.Nama != null && b.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase)) ||
                    (b.Kode != null && b.Kode.Contains(kataKunci, StringComparison.OrdinalIgnoreCase)));
            }

            var listHasil = hasil.ToList();

            if (listHasil.Count == 0)
            {
                Label lblKosong = new Label
                {
                    Text = "Tidak ada produk yang sesuai",
                    Font = FontInter.Buat(10F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(156, 163, 175),
                    AutoSize = false,
                    Size = new Size(580, 80),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                flowProduk.Controls.Add(lblKosong);
            }
            else
            {
                foreach (var b in listHasil)
                {
                    bool isDipilih = barangTerpilih != null && barangTerpilih.Kode == b.Kode;
                    KartuProduk kartu = new KartuProduk();
                    kartu.SetBarang(b, isDipilih);
                    kartu.Margin = new Padding(0, 0, 10, 10);

                    kartu.KartuDiklik += (s, e) =>
                    {
                        if (s is KartuProduk kp && kp.Barang != null)
                        {
                            PilihKartuProduk(kp.Barang);
                        }
                    };

                    kartu.KartuDoubleKlik += (s, e) =>
                    {
                        if (s is KartuProduk kp && kp.Barang != null)
                        {
                            PilihKartuProduk(kp.Barang);
                            TambahBarangKeKeranjang(kp.Barang, (int)nudJumlah.Value);
                        }
                    };

                    flowProduk.Controls.Add(kartu);
                }
            }

            flowProduk.ResumeLayout();
        }

        private void PilihKartuProduk(Barang? barang)
        {
            barangTerpilih = barang;
            foreach (Control c in flowProduk.Controls)
            {
                if (c is KartuProduk kartu)
                {
                    kartu.Terpilih = barang != null && kartu.Barang?.Kode == barang.Kode;
                }
            }
        }

        private void BtnTambahKeranjang_Click(object? sender, EventArgs e)
        {
            if (barangTerpilih == null)
            {
                Barang? dicari = CariBarangDariTeks();
                if (dicari != null)
                {
                    PilihKartuProduk(dicari);
                }
            }

            if (barangTerpilih == null)
            {
                MessageBox.Show("Silakan pilih produk terlebih dahulu dari kartu produk!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCariProduk.Focus();
                return;
            }

            TambahBarangKeKeranjang(barangTerpilih, (int)nudJumlah.Value);
        }

        private void TambahBarangKeKeranjang(Barang barang, int qtyBeli)
        {
            if (PenyimpananData.ApakahBarangTerkunciOpname(barang.Kode, out string nomorOpn))
            {
                MessageBox.Show(
                    $"Produk '{barang.Nama}' ({barang.Kode}) tidak dapat ditambahkan ke keranjang karena sedang dalam proses Stok Opname ({nomorOpn}) dan stoknya terkunci.\nTransaksi penjualan untuk produk ini sementara dicegah demi keakuratan penghitungan fisik.",
                    "Stok Terkunci Opname",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (barang.Stok <= 0)
            {
                MessageBox.Show($"Stok produk '{barang.Nama}' sudah habis!", "Stok Habis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    HargaBeli = barang.HargaBeli,
                    Harga = barang.Harga,
                    Jumlah = qtyBeli
                });
            }

            nudJumlah.Value = 1;
            PerbaruiTampilanKeranjang();
            PilihBaris(barang.Kode);
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
            bool diPencarian = txtCariProduk.ContainsFocus;
            bool diBayar = nudBayar.ContainsFocus;
            bool pencarianKosong = txtCariProduk.Text.Trim().Length == 0;

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
                    if (int.TryParse(txtCariProduk.Text.Trim(), out int jumlah) && jumlah > 0)
                    {
                        nudJumlah.Value = Math.Min(jumlah, (int)nudJumlah.Maximum);
                        txtCariProduk.Text = "";
                    }
                    return true;

                case Keys.Add when !diBayar && !nudJumlah.ContainsFocus:
                    UbahJumlahBarisTerpilih(1);
                    return true;

                case Keys.Subtract when !diBayar && !nudJumlah.ContainsFocus:
                    UbahJumlahBarisTerpilih(-1);
                    return true;

                case Keys.Up when diPencarian && pencarianKosong:
                    PindahBaris(-1);
                    return true;

                case Keys.Down when diPencarian && pencarianKosong:
                    PindahBaris(1);
                    return true;

                case Keys.Delete when (diPencarian && pencarianKosong) || gridKeranjang.ContainsFocus:
                    HapusBarisTerpilih();
                    return true;

                case Keys.Escape when diBayar || nudJumlah.ContainsFocus:
                    FokusPencarian();
                    return true;

                case Keys.Escape when diPencarian:
                    txtCariProduk.Text = "";
                    nudJumlah.Value = 1;
                    PilihKartuProduk(null);
                    return true;
            }
            return false;
        }

        private void FokusPencarian()
        {
            txtCariProduk.Focus();
            txtCariProduk.SelectAll();
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
                if (PenyimpananData.ApakahBarangTerkunciOpname(kode, out string nomorOpn))
                {
                    MessageBox.Show(
                        $"Produk ini sedang dalam proses Stok Opname ({nomorOpn}) dan stoknya terkunci.",
                        "Stok Terkunci Opname",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

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

        private Barang? CariBarangDariTeks()
        {
            string teks = txtCariProduk.Text.Trim();
            if (teks.Length == 0)
            {
                return null;
            }

            // 1. Cek apakah teks adalah Kode Barang persis
            Barang? barang = daftarBarang.FirstOrDefault(b => b.Aktif && string.Equals(b.Kode, teks, StringComparison.OrdinalIgnoreCase));
            if (barang != null)
            {
                return barang;
            }

            // 2. Cek apakah teks adalah Nama Barang persis
            barang = daftarBarang.FirstOrDefault(b => b.Aktif && string.Equals(b.Nama, teks, StringComparison.OrdinalIgnoreCase));
            if (barang != null)
            {
                return barang;
            }

            // 3. Cek pencarian parsial Nama Barang
            var cocok = daftarBarang.Where(b => b.Aktif && b.Stok > 0 && b.Nama.Contains(teks, StringComparison.OrdinalIgnoreCase)).ToList();
            if (cocok.Count == 1) return cocok[0];
            if (cocok.Count > 1)
            {
                var awalan = cocok.FirstOrDefault(b => b.Nama.StartsWith(teks, StringComparison.OrdinalIgnoreCase));
                return awalan ?? cocok[0];
            }

            // 4. Cek pencarian parsial Kode Barang
            var cocokKode = daftarBarang.Where(b => b.Aktif && b.Stok > 0 && b.Kode.Contains(teks, StringComparison.OrdinalIgnoreCase)).ToList();
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
                kolom.DefaultCellStyle.ForeColor = UIHelper.WarnaTeksSekunder;
                kolom.DefaultCellStyle.SelectionForeColor = UIHelper.WarnaAksen;
            }
            colHapus.DefaultCellStyle.ForeColor = UIHelper.WarnaStatusHabis;
            colHapus.DefaultCellStyle.SelectionForeColor = UIHelper.WarnaStatusHabis;
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
                lblKembalianNilai.ForeColor = UIHelper.WarnaStatusAman;
                lblKembalianNilai.Text = "Rp " + kembalian.ToString("N0", BudayaIndonesia);
            }
            else
            {
                lblKembalianNilai.ForeColor = UIHelper.WarnaStatusHabis;
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

            var produkTerkunci = keranjang
                .Where(k => PenyimpananData.ApakahBarangTerkunciOpname(k.KodeBarang, out _))
                .ToList();

            if (produkTerkunci.Count > 0)
            {
                string daftarNama = string.Join("\n- ", produkTerkunci.Select(p => $"{p.NamaBarang} ({p.KodeBarang})"));
                MessageBox.Show(
                    $"Transaksi penjualan tidak dapat diproses karena produk berikut sedang dalam proses Stok Opname dan stoknya terkunci:\n- {daftarNama}\n\nSilakan hapus produk tersebut dari keranjang sebelum memproses transaksi.",
                    "Transaksi Ditolak - Stok Terkunci Opname",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
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
            string idTransaksi = PenyimpananData.BuatIdTransaksi();

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
                HargaBeli = k.HargaBeli,
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

                PenyimpananData.TambahTransaksi(trx, details);
                PenyimpananData.SimpanBarang(daftarBarang);
                PenyimpananData.SimpanStrukJson(trx, details);
                PenyimpananData.CatatAktivitas(Navigasi.PenggunaAktif, "Transaksi", $"Transaksi kasir {idTransaksi} selesai: Total Rp {trx.Total:N0}, Bayar Rp {trx.Bayar:N0}, Kembalian Rp {trx.Kembalian:N0} ({details.Count} jenis barang).");

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
}
