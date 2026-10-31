namespace Sukimart
{
    public class Barang
    {
        public string Kode { get; set; } = "";
        public string Nama { get; set; } = "";
        public string Kategori { get; set; } = "";
        public int Harga { get; set; }
        public int Stok { get; set; }
        public int StokMinimum { get; set; }
    }

    public class Transaksi
    {
        public string Id { get; set; } = "";
        public DateTime Tanggal { get; set; }
        public string Kasir { get; set; } = "";
        public int Total { get; set; }
        public int Bayar { get; set; }
        public int Kembalian { get; set; }
    }

    public class DetailTransaksi
    {
        public DateTime Tanggal { get; set; }
        public string IdTransaksi { get; set; } = "";
        public string KodeBarang { get; set; } = "";
        public string NamaBarang { get; set; } = "";
        public int Harga { get; set; }

        public int HargaSatuan
        {
            get => Harga;
            set => Harga = value;
        }

        public int Jumlah { get; set; }

        private int _subtotal;
        public int Subtotal
        {
            get => _subtotal != 0 ? _subtotal : (Harga * Jumlah);
            set => _subtotal = value;
        }
    }

    public class ItemKeranjang
    {
        public string KodeBarang { get; set; } = "";
        public string NamaBarang { get; set; } = "";
        public int Harga { get; set; }
        public int Jumlah { get; set; }
        public int Subtotal
        {
            get { return Harga * Jumlah; }
        }
    }
}