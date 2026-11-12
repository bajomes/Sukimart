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

        [System.Text.Json.Serialization.JsonIgnore]
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

    public class Pengguna
    {
        public string NamaPengguna { get; set; } = "";
        public string NamaLengkap { get; set; } = "";
        public string Peran { get; set; } = "kasir";
        public bool Aktif { get; set; } = true;
        public string HashSandi { get; set; } = "";
        public string Garam { get; set; } = "";
        public int Iterasi { get; set; }
        public DateTime Dibuat { get; set; }
    }

    public class Aktivitas
    {
        public DateTime Tanggal { get; set; }
        public string NamaPengguna { get; set; } = "";
        public string Aksi { get; set; } = "";
    }

    public class RiwayatStok
    {
        public DateTime Tanggal { get; set; }
        public string KodeBarang { get; set; } = "";
        public string NamaBarang { get; set; } = "";
        public string Jenis { get; set; } = "";
        public int Jumlah { get; set; }
        public int StokSebelum { get; set; }
        public int StokSesudah { get; set; }
        public string Keterangan { get; set; } = "";
        public string Pengguna { get; set; } = "";
    }

    public class BarangMasuk
    {
        public string Id { get; set; } = "";
        public DateTime Tanggal { get; set; }
        public string KodeBarang { get; set; } = "";
        public string NamaBarang { get; set; } = "";
        public int Jumlah { get; set; }
        public string Pemasok { get; set; } = "";
        public string Petugas { get; set; } = "";
        public string Keterangan { get; set; } = "";
    }

    public class BarangKeluar
    {
        public string Id { get; set; } = "";
        public DateTime Tanggal { get; set; }
        public string KodeBarang { get; set; } = "";
        public string NamaBarang { get; set; } = "";
        public int Jumlah { get; set; }
        public string Alasan { get; set; } = "";
        public string Keterangan { get; set; } = "";
        public string Petugas { get; set; } = "";
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
