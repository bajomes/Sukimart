# Panduan Belajar Sukimart untuk Pemula

Kamu tidak perlu menghafal seluruh proyek sekaligus. Pelajari satu fungsi, pahami input dan hasilnya, lalu coba jalankan aplikasinya.

## 1. Bentuk dasar fungsi

```csharp
private int HitungTransaksiHariIni()
{
    List<Transaksi> daftarTransaksi = PenyimpananData.BacaTransaksi();
    int jumlah = 0;

    foreach (Transaksi transaksi in daftarTransaksi)
    {
        if (transaksi.Tanggal.Date == DateTime.Today)
        {
            jumlah = jumlah + 1;
        }
    }

    return jumlah;
}
```

Cara membacanya:

- `private`: fungsi dipakai dari dalam class tersebut.
- `int`: fungsi mengembalikan angka bulat.
- `HitungTransaksiHariIni`: nama fungsi yang menjelaskan tugasnya.
- `()` berarti fungsi ini tidak menerima parameter.
- `foreach` memeriksa setiap transaksi dalam daftar.
- `if` hanya menambah hitungan jika tanggal transaksi sama dengan hari ini.
- `return jumlah` mengirim hasil hitungan kepada pemanggil fungsi.

## 2. Fungsi yang perlu dipelajari lebih dahulu

1. `IsiDashboard()` menampilkan hasil hitungan pada label dashboard.
2. `IsiDaftarBarang()` membaca data barang JSON lalu menampilkannya pada tabel.
3. `btnSimpan_Click()` dipanggil ketika tombol tambah barang ditekan.
4. `btnTambah_Click()` menambahkan barang ke keranjang dan memeriksa stok.
5. `btnBayar_Click()` memvalidasi pembayaran, mengurangi stok, dan menyimpan transaksi.
6. `BacaData<T>()` dan `SimpanData<T>()` membantu membaca serta menulis file JSON. Bagian `<T>` adalah fitur C# bernama *generic* agar fungsi serupa dapat digunakan untuk beberapa jenis data.

## 3. Cara kerja JSON pada proyek

`barang.json` menyimpan daftar barang. `JsonSerializer.Deserialize` mengubah teks JSON menjadi daftar objek C#, sedangkan `JsonSerializer.Serialize` mengubah daftar objek menjadi teks JSON untuk disimpan.

Contoh satu objek barang:

```json
{
  "kode": "MKN001",
  "nama": "Roti Tawar",
  "kategori": "Makanan",
  "harga": 15000,
  "stok": 20,
  "stokMinimum": 5
}
```

File JSON memakai tanda kurung kurawal untuk objek dan tanda kurung siku untuk daftar. Nama teks memakai tanda kutip ganda. Angka seperti `15000` tidak memakai tanda kutip.

## 4. Urutan kerja ketika membuat transaksi

1. Kasir memilih barang dan jumlahnya.
2. Fungsi memeriksa apakah stok tersedia.
3. Aplikasi menghitung subtotal setiap baris dan total belanja.
4. Aplikasi memeriksa apakah uang pembayaran cukup.
5. Aplikasi menyimpan perubahan stok, ringkasan transaksi, dan rincian transaksi ke JSON.
6. Riwayat membaca transaksi yang telah disimpan.

Saat belajar, coba ubah satu bagian kecil, jalankan aplikasi, lalu uji hasilnya. Jangan mengubah beberapa fungsi sekaligus sebelum memahami error yang muncul.
