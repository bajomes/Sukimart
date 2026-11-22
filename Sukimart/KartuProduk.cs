using System.Globalization;

namespace Sukimart
{
    // Komponen UI kustom (UserControl) untuk menampilkan kartu informasi produk visual pada kasir
    public partial class KartuProduk : UserControl
    {
        // Format mata uang Rupiah standar Indonesia
        private static readonly CultureInfo BudayaIndonesia = new CultureInfo("id-ID");
        private bool terpilih;
        private Barang? barang;

        // Peristiwa (event) saat kartu produk diklik satu kali atau dua kali
        public event EventHandler? KartuDiklik;
        public event EventHandler? KartuDoubleKlik;

        // Properti untuk membaca data barang yang diikat pada kartu
        public Barang? Barang => barang;

        // Status penanda apakah kartu ini sedang dipilih oleh kasir
        public bool Terpilih
        {
            get => terpilih;
            set
            {
                if (terpilih != value)
                {
                    terpilih = value;
                    PerbaruiTampilanSeleksi();
                }
            }
        }

        public KartuProduk()
        {
            InitializeComponent();
            DoubleBuffered = true;
            FontInter.Terapkan(this);

            // Menghubungkan klik komponen anak ke event handler eksplisit kartu (tanpa lambda)
            lblNama.Click += Komponen_Click;
            lblStok.Click += Komponen_Click;
            lblHarga.Click += Komponen_Click;
            Click += Komponen_Click;

            lblNama.DoubleClick += Komponen_DoubleClick;
            lblStok.DoubleClick += Komponen_DoubleClick;
            lblHarga.DoubleClick += Komponen_DoubleClick;
            DoubleClick += Komponen_DoubleClick;
        }

        // Handler saat elemen kartu diklik sekali
        private void Komponen_Click(object? sender, EventArgs e)
        {
            KartuDiklik?.Invoke(this, EventArgs.Empty);
        }

        // Handler saat elemen kartu diklik ganda (langsung masuk ke keranjang)
        private void Komponen_DoubleClick(object? sender, EventArgs e)
        {
            KartuDoubleKlik?.Invoke(this, EventArgs.Empty);
        }

        // Mengisi data produk ke label nama, stok, dan harga pada kartu
        public void SetBarang(Barang b, bool isTerpilih = false)
        {
            this.barang = b;
            this.terpilih = isTerpilih;

            lblNama.Text = b.Nama;
            lblHarga.Text = "Rp " + b.Harga.ToString("N0", BudayaIndonesia);

            // Peringatan visual jika stok habis (warna merah) atau masih tersedia (warna hijau)
            if (b.Stok <= 0)
            {
                lblStok.Text = "Stok: Habis";
                lblStok.ForeColor = Color.FromArgb(220, 38, 38);
                lblNama.ForeColor = Color.FromArgb(156, 163, 175);
                lblHarga.ForeColor = Color.FromArgb(156, 163, 175);
            }
            else
            {
                lblStok.Text = $"Stok: {b.Stok}";
                lblStok.ForeColor = Color.FromArgb(107, 114, 128);
                lblNama.ForeColor = Color.FromArgb(31, 41, 55);
                lblHarga.ForeColor = Color.FromArgb(16, 149, 102);
            }

            PerbaruiTampilanSeleksi();
        }

        // Mengubah warna latar belakang jika kartu sedang aktif dipilih
        private void PerbaruiTampilanSeleksi()
        {
            if (terpilih)
            {
                BackColor = Color.FromArgb(255, 250, 230); // Kuning muda aksen SukiMart
            }
            else
            {
                BackColor = Color.White;
            }
            Invalidate();
        }

        // Menggambar garis tepi kartu (border) dengan warna aksen kuning saat dipilih
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color warnaGaris = terpilih ? Color.FromArgb(255, 196, 0) : Color.FromArgb(229, 231, 235);
            int tebal = terpilih ? 2 : 1;
            using Pen pena = new Pen(warnaGaris, tebal);
            e.Graphics.DrawRectangle(pena, tebal - 1, tebal - 1, ClientSize.Width - tebal, ClientSize.Height - tebal);
        }
    }
}
