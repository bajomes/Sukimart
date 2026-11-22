using System.Text.Json;

namespace Sukimart
{
    // Kelas utilitas terpusat untuk membaca, menyimpan, dan mengelola berkas data JSON
    public static class PenyimpananData
    {
        // Pengaturan serialisasi JSON agar berformat rapi dan case-insensitive
        private static readonly JsonSerializerOptions opsiJson = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        // Menentukan lokasi fisik berkas data JSON di direktori AppData lokal
        private static string LokasiFile(string namaFile)
        {
            string folderSumber = Path.Combine(Application.StartupPath, "Data");
            string folderData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Sukimart", "Data");
            Directory.CreateDirectory(folderData);

            string lokasiTujuan = Path.Combine(folderData, namaFile);
            string lokasiAwal = Path.Combine(folderSumber, namaFile);

            // Jika berkas di AppData belum ada tetapi ada berkas awal di folder aplikasi, salin berkas tersebut
            if (!File.Exists(lokasiTujuan) && File.Exists(lokasiAwal))
            {
                try
                {
                    File.Copy(lokasiAwal, lokasiTujuan, true);
                }
                catch { }
            }

            return lokasiTujuan;
        }

        // Membaca daftar objek dari berkas JSON (Memenuhi Kasus Uji 19: Otomatis buat berkas jika terhapus)
        private static List<T> BacaData<T>(string namaFile)
        {
            string lokasi = LokasiFile(namaFile);

            // Kasus Uji 19: Jika berkas tidak ditemukan, buat kembali berkas kosong secara otomatis tanpa error
            if (!File.Exists(lokasi))
            {
                try
                {
                    File.WriteAllText(lokasi, "[]\n");
                }
                catch { }
                return new List<T>();
            }

            string json = File.ReadAllText(lokasi);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<T>();
            }

            try
            {
                return JsonSerializer.Deserialize<List<T>>(json, opsiJson) ?? new List<T>();
            }
            catch (JsonException ex)
            {
                // Jika berkas rusak, amankan salinan cadangan berkas rusak tersebut
                string cadangan = lokasi + ".rusak";
                try
                {
                    if (!File.Exists(cadangan))
                    {
                        File.Copy(lokasi, cadangan);
                    }
                }
                catch (IOException)
                {
                }

                throw new InvalidDataException(
                    $"File {namaFile} bukan JSON yang valid. Periksa tanda kurung, koma, dan tanda kutip. Salinan aslinya disimpan sebagai {Path.GetFileName(cadangan)}.", ex);
            }
        }

        // Menyimpan data ke berkas JSON dengan metode penulisan aman (temporary file swap)
        private static void SimpanData<T>(string namaFile, List<T> data)
        {
            string lokasi = LokasiFile(namaFile);
            string fileSementara = lokasi + ".tmp";
            string json = JsonSerializer.Serialize(data, opsiJson);
            File.WriteAllText(fileSementara, json);
            File.Move(fileSementara, lokasi, true);

            // Simpan juga ke folder Data aplikasi agar tetap sinkron
            try
            {
                string folderSumber = Path.Combine(Application.StartupPath, "Data");
                Directory.CreateDirectory(folderSumber);
                File.WriteAllText(Path.Combine(folderSumber, namaFile), json);
            }
            catch { }
        }

        // Membaca daftar kategori barang
        public static List<string> BacaKategori()
        {
            List<string> daftarKategori = BacaData<string>("kategori.json");
            if (daftarKategori.Count == 0)
            {
                daftarKategori = new List<string> { "Sembako", "Minuman", "Kebersihan", "Snack", "Makanan", "Perlengkapan", "Lainnya" };
                foreach (Barang barang in BacaBarang())
                {
                    if (!string.IsNullOrWhiteSpace(barang.Kategori) && !daftarKategori.Contains(barang.Kategori, StringComparer.OrdinalIgnoreCase))
                    {
                        daftarKategori.Add(barang.Kategori);
                    }
                }
                SimpanKategori(daftarKategori);
            }
            return daftarKategori;
        }

        public static void SimpanKategori(List<string> daftarKategori)
        {
            SimpanData("kategori.json", daftarKategori);
        }

        // Membaca daftar barang dari barang.json (Dilengkapi inisialisasi data contoh resmi penguji BRG001-BRG011)
        public static List<Barang> BacaBarang()
        {
            List<Barang> daftar = BacaData<Barang>("barang.json");
            if (daftar.Count == 0 || !daftar.Any(b => b.Kode == "BRG001"))
            {
                daftar = BuatDataBarangAwal();
                SimpanBarang(daftar);
            }
            return daftar;
        }

        public static void SimpanBarang(List<Barang> daftarBarang)
        {
            SimpanData("barang.json", daftarBarang);
        }

        // Data awal barang resmi sesuai Dokumen Ketentuan Penguji Bagian 7
        public static List<Barang> BuatDataBarangAwal()
        {
            return new List<Barang>
            {
                new Barang { Kode = "BRG001", Nama = "Beras Premium 5kg", Kategori = "Sembako", HargaBeli = 60000, Harga = 72000, Stok = 40, StokMinimum = 10, Aktif = true },
                new Barang { Kode = "BRG002", Nama = "Minyak Goreng 2L", Kategori = "Sembako", HargaBeli = 32000, Harga = 38000, Stok = 8, StokMinimum = 10, Aktif = true },
                new Barang { Kode = "BRG003", Nama = "Gula Pasir 1kg", Kategori = "Sembako", HargaBeli = 14000, Harga = 16500, Stok = 55, StokMinimum = 15, Aktif = true },
                new Barang { Kode = "BRG004", Nama = "Teh Botol 450ml", Kategori = "Minuman", HargaBeli = 4500, Harga = 5500, Stok = 100, StokMinimum = 30, Aktif = true },
                new Barang { Kode = "BRG005", Nama = "Air Mineral 600ml", Kategori = "Minuman", HargaBeli = 2500, Harga = 3500, Stok = 150, StokMinimum = 50, Aktif = true },
                new Barang { Kode = "BRG006", Nama = "Kopi Sachet 10s", Kategori = "Minuman", HargaBeli = 10000, Harga = 12000, Stok = 9, StokMinimum = 12, Aktif = true },
                new Barang { Kode = "BRG007", Nama = "Deterjen 800g", Kategori = "Kebersihan", HargaBeli = 17500, Harga = 21000, Stok = 5, StokMinimum = 10, Aktif = true },
                new Barang { Kode = "BRG008", Nama = "Sabun Mandi", Kategori = "Kebersihan", HargaBeli = 3500, Harga = 4500, Stok = 80, StokMinimum = 20, Aktif = true },
                new Barang { Kode = "BRG009", Nama = "Keripik Singkong", Kategori = "Snack", HargaBeli = 7000, Harga = 9000, Stok = 10, StokMinimum = 10, Aktif = true },
                new Barang { Kode = "BRG010", Nama = "Mie Instan Goreng", Kategori = "Makanan", HargaBeli = 2800, Harga = 3500, Stok = 200, StokMinimum = 50, Aktif = true },
                new Barang { Kode = "BRG011", Nama = "Susu UHT 1L", Kategori = "Minuman", HargaBeli = 15000, Harga = 18500, Stok = 0, StokMinimum = 12, Aktif = true }
            };
        }

        // Membaca daftar riwayat transaksi penjualan
        public static List<Transaksi> BacaTransaksi()
        {
            List<Transaksi> daftar = BacaData<Transaksi>("transaksi.json");
            if (daftar.Count == 0 || !daftar.Any(t => t.Id == "TRX001"))
            {
                daftar = BuatDataTransaksiAwal();
                SimpanTransaksi(daftar);
            }
            return daftar;
        }

        public static void SimpanTransaksi(List<Transaksi> daftarTransaksi)
        {
            SimpanData("transaksi.json", daftarTransaksi);
        }

        // Data awal transaksi resmi sesuai Dokumen Penguji TRX001 - TRX004
        private static List<Transaksi> BuatDataTransaksiAwal()
        {
            return new List<Transaksi>
            {
                new Transaksi { Id = "TRX001", Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), Kasir = "kasir1", Total = 87500, Bayar = 100000, Kembalian = 12500 },
                new Transaksi { Id = "TRX002", Tanggal = new DateTime(2026, 11, 2, 13, 25, 40), Kasir = "kasir2", Total = 25500, Bayar = 30000, Kembalian = 4500 },
                new Transaksi { Id = "TRX003", Tanggal = new DateTime(2026, 11, 3, 10, 5, 12), Kasir = "kasir1", Total = 110000, Bayar = 110000, Kembalian = 0 },
                new Transaksi { Id = "TRX004", Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), Kasir = "kasir2", Total = 43500, Bayar = 50000, Kembalian = 6500 }
            };
        }

        // Menyimpan transaksi baru lengkap dengan detail transaksi dan struk (Kasus Uji 8)
        public static void TambahTransaksi(Transaksi transaksi, List<DetailTransaksi> rincian)
        {
            List<Transaksi> daftarTransaksi = BacaTransaksi();
            daftarTransaksi.Add(transaksi);
            SimpanTransaksi(daftarTransaksi);

            if (rincian != null && rincian.Count > 0)
            {
                List<DetailTransaksi> daftarDetail = BacaDetailTransaksi();
                daftarDetail.AddRange(rincian);
                SimpanDetailTransaksi(daftarDetail);
            }

            // Menyimpan file struk otomatis dalam format JSON ke folder struk/ (Kasus Uji 8)
            SimpanStruk(transaksi, rincian);
        }

        // Menyimpan struk transaksi ke berkas JSON di folder struk/ (Kasus Uji 8)
        public static void SimpanStruk(Transaksi transaksi, List<DetailTransaksi>? rincian)
        {
            try
            {
                var dataStruk = new
                {
                    no_transaksi = transaksi.Id,
                    tanggal = transaksi.Tanggal.ToString("yyyy-MM-dd"),
                    waktu = transaksi.Tanggal.ToString("HH:mm:ss"),
                    kasir = transaksi.Kasir,
                    total = transaksi.Total,
                    bayar = transaksi.Bayar,
                    kembalian = transaksi.Kembalian,
                    item = (rincian ?? new List<DetailTransaksi>()).Select(r => new
                    {
                        kode_barang = r.KodeBarang,
                        nama_barang = r.NamaBarang,
                        harga_beli = r.HargaBeli,
                        harga = r.Harga,
                        jumlah = r.Jumlah,
                        subtotal = r.Subtotal
                    }).ToList()
                };

                string json = JsonSerializer.Serialize(dataStruk, opsiJson);

                // 1. Simpan di direktori kerja aktif (misal: ./struk/TRX005.json)
                string folderKerjaStruk = Path.Combine(Directory.GetCurrentDirectory(), "struk");
                Directory.CreateDirectory(folderKerjaStruk);
                File.WriteAllText(Path.Combine(folderKerjaStruk, $"{transaksi.Id}.json"), json);

                // 2. Simpan di direktori output aplikasi (BaseDirectory)
                string folderProyekStruk = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "struk");
                Directory.CreateDirectory(folderProyekStruk);
                File.WriteAllText(Path.Combine(folderProyekStruk, $"{transaksi.Id}.json"), json);

                // 3. Simpan di direktori AppData
                string folderDataStruk = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Sukimart", "struk");
                Directory.CreateDirectory(folderDataStruk);
                File.WriteAllText(Path.Combine(folderDataStruk, $"{transaksi.Id}.json"), json);
            }
            catch { }
        }

        // Menyimpan berkas laporan (penjualan atau gudang) dalam format JSON ke folder laporan/ (Fitur 9 & 10)
        public static string SimpanLaporanJson(string namaFile, object dataLaporan)
        {
            string json = JsonSerializer.Serialize(dataLaporan, opsiJson);

            // Simpan di folder laporan pada direktori kerja dan output aplikasi
            string folderKerjaLaporan = Path.Combine(Directory.GetCurrentDirectory(), "laporan");
            Directory.CreateDirectory(folderKerjaLaporan);
            string pathKerja = Path.Combine(folderKerjaLaporan, namaFile);
            File.WriteAllText(pathKerja, json);

            try
            {
                string folderBaseLaporan = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "laporan");
                Directory.CreateDirectory(folderBaseLaporan);
                File.WriteAllText(Path.Combine(folderBaseLaporan, namaFile), json);
            }
            catch { }

            return pathKerja;
        }

        // Membaca detail transaksi dan memastikan harga beli (modal) terisi akurat untuk kalkulator laba
        public static List<DetailTransaksi> BacaDetailTransaksi()
        {
            List<DetailTransaksi> daftarDetail = BacaData<DetailTransaksi>("detail_transaksi.json");
            if (daftarDetail.Count == 0 || !daftarDetail.Any(d => d.IdTransaksi == "TRX001"))
            {
                daftarDetail = BuatDataDetailAwal();
                SimpanDetailTransaksi(daftarDetail);
            }
            else
            {
                // Sinkronisasi otomatis nilai HargaBeli jika ada data transaksi lama yang bernilai 0
                bool adaPerubahan = false;
                List<Barang> daftarBarang = BacaBarang();
                Dictionary<string, int> petaHargaBeli = daftarBarang
                    .Where(b => !string.IsNullOrEmpty(b.Kode))
                    .ToDictionary(b => b.Kode, b => b.HargaBeli, StringComparer.OrdinalIgnoreCase);

                foreach (var d in daftarDetail)
                {
                    if (d.HargaBeli <= 0 && petaHargaBeli.TryGetValue(d.KodeBarang, out int hb) && hb > 0)
                    {
                        d.HargaBeli = hb;
                        adaPerubahan = true;
                    }
                }

                if (adaPerubahan)
                {
                    try { SimpanDetailTransaksi(daftarDetail); } catch { }
                }
            }
            return daftarDetail;
        }

        public static void SimpanDetailTransaksi(List<DetailTransaksi> daftarDetail)
        {
            SimpanData("detail_transaksi.json", daftarDetail);
        }

        // Data awal detail transaksi resmi sesuai Dokumen Penguji Bagian 7
        private static List<DetailTransaksi> BuatDataDetailAwal()
        {
            return new List<DetailTransaksi>
            {
                new DetailTransaksi { IdTransaksi = "TRX001", Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), KodeBarang = "BRG001", NamaBarang = "Beras Premium 5kg", HargaBeli = 60000, Harga = 72000, Jumlah = 1 },
                new DetailTransaksi { IdTransaksi = "TRX001", Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), KodeBarang = "BRG004", NamaBarang = "Teh Botol 450ml", HargaBeli = 4500, Harga = 5500, Jumlah = 2 },
                new DetailTransaksi { IdTransaksi = "TRX001", Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), KodeBarang = "BRG008", NamaBarang = "Sabun Mandi", HargaBeli = 3500, Harga = 4500, Jumlah = 1 },

                new DetailTransaksi { IdTransaksi = "TRX002", Tanggal = new DateTime(2026, 11, 2, 13, 25, 40), KodeBarang = "BRG003", NamaBarang = "Gula Pasir 1kg", HargaBeli = 14000, Harga = 16500, Jumlah = 1 },
                new DetailTransaksi { IdTransaksi = "TRX002", Tanggal = new DateTime(2026, 11, 2, 13, 25, 40), KodeBarang = "BRG009", NamaBarang = "Keripik Singkong", HargaBeli = 7000, Harga = 9000, Jumlah = 1 },

                new DetailTransaksi { IdTransaksi = "TRX003", Tanggal = new DateTime(2026, 11, 3, 10, 5, 12), KodeBarang = "BRG001", NamaBarang = "Beras Premium 5kg", HargaBeli = 60000, Harga = 72000, Jumlah = 1 },
                new DetailTransaksi { IdTransaksi = "TRX003", Tanggal = new DateTime(2026, 11, 3, 10, 5, 12), KodeBarang = "BRG002", NamaBarang = "Minyak Goreng 2L", HargaBeli = 32000, Harga = 38000, Jumlah = 1 },

                new DetailTransaksi { IdTransaksi = "TRX004", Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), KodeBarang = "BRG007", NamaBarang = "Deterjen 800g", HargaBeli = 17500, Harga = 21000, Jumlah = 1 },
                new DetailTransaksi { IdTransaksi = "TRX004", Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), KodeBarang = "BRG006", NamaBarang = "Kopi Sachet 10s", HargaBeli = 10000, Harga = 12000, Jumlah = 1 },
                new DetailTransaksi { IdTransaksi = "TRX004", Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), KodeBarang = "BRG005", NamaBarang = "Air Mineral 600ml", HargaBeli = 2500, Harga = 3500, Jumlah = 3 }
            };
        }

        // Membaca daftar akun pengguna
        public static List<Pengguna> BacaPengguna()
        {
            List<Pengguna> daftarPengguna = BacaData<Pengguna>("pengguna.json");
            if (daftarPengguna.Count == 0 || !daftarPengguna.Any(p => p.NamaPengguna == "kasir2"))
            {
                daftarPengguna = BuatPenggunaAwal();
                SimpanPengguna(daftarPengguna);
            }
            return daftarPengguna;
        }

        public static void SimpanPengguna(List<Pengguna> daftarPengguna)
        {
            SimpanData("pengguna.json", daftarPengguna);
        }

        // Data awal akun pengguna lengkap sesuai Dokumen Penguji (admin, kasir1, kasir2, kasir3, gudang1)
        public static List<Pengguna> BuatPenggunaAwal()
        {
            Pengguna admin = new Pengguna { NamaPengguna = "admin", NamaLengkap = "Administrator Suki MART", Peran = "admin", Aktif = true, Dibuat = new DateTime(2026, 11, 1, 8, 0, 0) };
            Pengguna kasir1 = new Pengguna { NamaPengguna = "kasir1", NamaLengkap = "Dewi Lestari", Peran = "kasir", Aktif = true, Dibuat = new DateTime(2026, 11, 1, 8, 0, 0) };
            Pengguna kasir2 = new Pengguna { NamaPengguna = "kasir2", NamaLengkap = "Rian Saputra", Peran = "kasir", Aktif = true, Dibuat = new DateTime(2026, 11, 1, 8, 0, 0) };
            Pengguna kasir3 = new Pengguna { NamaPengguna = "kasir3", NamaLengkap = "Sari Wulandari", Peran = "kasir", Aktif = false, Dibuat = new DateTime(2026, 11, 1, 8, 0, 0) };
            Pengguna gudang1 = new Pengguna { NamaPengguna = "gudang1", NamaLengkap = "Budi Santoso", Peran = "gudang", Aktif = true, Dibuat = new DateTime(2026, 11, 1, 8, 0, 0) };

            KeamananSandi.IsiSandi(admin, "admin123");
            KeamananSandi.IsiSandi(kasir1, "kasir123");
            KeamananSandi.IsiSandi(kasir2, "kasir123");
            KeamananSandi.IsiSandi(kasir3, "kasir123");
            KeamananSandi.IsiSandi(gudang1, "gudang123");

            return new List<Pengguna> { admin, kasir1, kasir2, kasir3, gudang1 };
        }

        // Membaca berkas log audit aktivitas
        public static List<Aktivitas> BacaAktivitas()
        {
            List<Aktivitas> daftar = BacaData<Aktivitas>("log_aktivitas.json");
            if (daftar.Count == 0)
            {
                daftar = BuatDataAktivitasAwal();
                SimpanData("log_aktivitas.json", daftar);
            }
            return daftar;
        }

        private static List<Aktivitas> BuatDataAktivitasAwal()
        {
            return new List<Aktivitas>
            {
                new Aktivitas { Tanggal = new DateTime(2026, 11, 2, 9, 0, 3), NamaPengguna = "kasir1", JenisAktivitas = "Login", Aksi = "LOGIN" },
                new Aktivitas { Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), NamaPengguna = "kasir1", JenisAktivitas = "Transaksi", Aksi = "TRANSAKSI TRX001" },
                new Aktivitas { Tanggal = new DateTime(2026, 11, 3, 8, 15, 40), NamaPengguna = "gudang1", JenisAktivitas = "Stok Keluar", Aksi = "BARANG KELUAR KLR001 BRG005 6" },
                new Aktivitas { Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), NamaPengguna = "kasir2", JenisAktivitas = "Transaksi", Aksi = "TRANSAKSI TRX004" }
            };
        }

        // Mencatat aktivitas audit trail baru
        public static void CatatAktivitas(string namaPengguna, string jenisAktivitas, string aksi)
        {
            List<Aktivitas> daftarAktivitas = BacaAktivitas();
            daftarAktivitas.Add(new Aktivitas
            {
                Tanggal = DateTime.Now,
                NamaPengguna = string.IsNullOrWhiteSpace(namaPengguna) ? "sistem" : namaPengguna,
                JenisAktivitas = string.IsNullOrWhiteSpace(jenisAktivitas) ? TentukanJenisAktivitas(aksi) : jenisAktivitas,
                Aksi = aksi ?? ""
            });
            SimpanData("log_aktivitas.json", daftarAktivitas);
        }

        public static void CatatAktivitas(string namaPengguna, string aksi)
        {
            string jenis = TentukanJenisAktivitas(aksi);
            CatatAktivitas(namaPengguna, jenis, aksi);
        }

        public static void BersihkanAktivitas()
        {
            SimpanData("log_aktivitas.json", new List<Aktivitas>());
        }

        public static string TentukanJenisAktivitas(string aksi)
        {
            if (string.IsNullOrWhiteSpace(aksi)) return "Umum";
            string a = aksi.Trim();
            if (a.StartsWith("LOGIN GAGAL", StringComparison.OrdinalIgnoreCase)) return "Login Gagal";
            if (a.StartsWith("LOGIN", StringComparison.OrdinalIgnoreCase)) return "Login";
            if (a.StartsWith("LOGOUT", StringComparison.OrdinalIgnoreCase)) return "Logout";
            if (a.StartsWith("TAMBAH BARANG", StringComparison.OrdinalIgnoreCase)) return "Tambah Barang";
            if (a.StartsWith("UBAH BARANG", StringComparison.OrdinalIgnoreCase)) return "Ubah Barang";
            if (a.StartsWith("HAPUS BARANG", StringComparison.OrdinalIgnoreCase)) return "Hapus Barang";
            if (a.StartsWith("AKTIFKAN BARANG", StringComparison.OrdinalIgnoreCase)) return "Aktifkan Barang";
            if (a.StartsWith("NONAKTIFKAN BARANG", StringComparison.OrdinalIgnoreCase)) return "Nonaktifkan Barang";
            if (a.StartsWith("TAMBAH KATEGORI", StringComparison.OrdinalIgnoreCase)) return "Tambah Kategori";
            if (a.StartsWith("UBAH KATEGORI", StringComparison.OrdinalIgnoreCase)) return "Ubah Kategori";
            if (a.StartsWith("HAPUS KATEGORI", StringComparison.OrdinalIgnoreCase)) return "Hapus Kategori";
            if (a.StartsWith("TAMBAH PENGGUNA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("TAMBAH AKUN", StringComparison.OrdinalIgnoreCase)) return "Tambah Akun";
            if (a.StartsWith("UBAH PASSWORD", StringComparison.OrdinalIgnoreCase) || a.StartsWith("UBAH KATA SANDI", StringComparison.OrdinalIgnoreCase) || a.StartsWith("AKTIVITAS: MENGGANTI KATA SANDI", StringComparison.OrdinalIgnoreCase) || a.StartsWith("MENGGANTI KATA SANDI", StringComparison.OrdinalIgnoreCase)) return "Ubah Password";
            if (a.StartsWith("UBAH NAMA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("UBAH PROFIL", StringComparison.OrdinalIgnoreCase)) return "Ubah Nama";
            if (a.StartsWith("UBAH PENGGUNA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("UBAH AKUN", StringComparison.OrdinalIgnoreCase)) return "Ubah Akun";
            if (a.StartsWith("HAPUS PENGGUNA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("HAPUS AKUN", StringComparison.OrdinalIgnoreCase)) return "Hapus Akun";
            if (a.StartsWith("TRANSAKSI", StringComparison.OrdinalIgnoreCase)) return "Transaksi";
            if (a.StartsWith("Masuk", StringComparison.OrdinalIgnoreCase) || a.StartsWith("STOK MASUK", StringComparison.OrdinalIgnoreCase) || a.StartsWith("BARANG MASUK", StringComparison.OrdinalIgnoreCase)) return "Stok Masuk";
            if (a.StartsWith("Keluar", StringComparison.OrdinalIgnoreCase) || a.StartsWith("STOK KELUAR", StringComparison.OrdinalIgnoreCase) || a.StartsWith("BARANG KELUAR", StringComparison.OrdinalIgnoreCase)) return "Stok Keluar";
            return "Umum";
        }

        // Membaca kartu stok barang
        public static List<RiwayatStok> BacaRiwayatStok()
        {
            List<RiwayatStok> daftar = BacaData<RiwayatStok>("riwayat_stok.json");
            if (daftar.Count == 0)
            {
                daftar = BuatDataRiwayatStokAwal();
                SimpanData("riwayat_stok.json", daftar);
            }
            return daftar;
        }

        public static void TambahRiwayatStok(RiwayatStok catatan)
        {
            List<RiwayatStok> daftarRiwayat = BacaRiwayatStok();
            daftarRiwayat.Add(catatan);
            SimpanData("riwayat_stok.json", daftarRiwayat);
        }

        // Data awal kartu stok resmi (memenuhi Kasus Uji 15 untuk BRG005: 03-11 KELUAR 6, 04-11 TERJUAL 3, Stok 150)
        private static List<RiwayatStok> BuatDataRiwayatStokAwal()
        {
            return new List<RiwayatStok>
            {
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 1, 8, 30, 0), KodeBarang = "BRG001", NamaBarang = "Beras Premium 5kg", Jenis = "MASUK", Jumlah = 50, StokSebelum = 0, StokSesudah = 50, Pemasok = "CV Sumber Pangan", Keterangan = "Penerimaan barang masuk MSK001", Pengguna = "gudang1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 1, 9, 15, 0), KodeBarang = "BRG004", NamaBarang = "Teh Botol 450ml", Jenis = "MASUK", Jumlah = 120, StokSebelum = 0, StokSesudah = 120, Pemasok = "PT Minum Segar", Keterangan = "Penerimaan barang masuk MSK002", Pengguna = "gudang1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), KodeBarang = "BRG001", NamaBarang = "Beras Premium 5kg", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 50, StokSesudah = 49, Keterangan = "Transaksi kasir TRX001", Pengguna = "kasir1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), KodeBarang = "BRG004", NamaBarang = "Teh Botol 450ml", Jenis = "TERJUAL", Jumlah = 2, StokSebelum = 120, StokSesudah = 118, Keterangan = "Transaksi kasir TRX001", Pengguna = "kasir1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 2, 9, 10, 25), KodeBarang = "BRG008", NamaBarang = "Sabun Mandi", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 81, StokSesudah = 80, Keterangan = "Transaksi kasir TRX001", Pengguna = "kasir1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 2, 13, 25, 40), KodeBarang = "BRG003", NamaBarang = "Gula Pasir 1kg", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 56, StokSesudah = 55, Keterangan = "Transaksi kasir TRX002", Pengguna = "kasir2" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 2, 13, 25, 40), KodeBarang = "BRG009", NamaBarang = "Keripik Singkong", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 13, StokSesudah = 12, Keterangan = "Transaksi kasir TRX002", Pengguna = "kasir2" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 3, 8, 15, 40), KodeBarang = "BRG005", NamaBarang = "Air Mineral 600ml", Jenis = "KELUAR", Jumlah = 6, StokSebelum = 159, StokSesudah = 153, Keterangan = "RUSAK (Kemasan bocor)", Pengguna = "gudang1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 3, 10, 5, 12), KodeBarang = "BRG001", NamaBarang = "Beras Premium 5kg", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 49, StokSesudah = 48, Keterangan = "Transaksi kasir TRX003", Pengguna = "kasir1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 3, 10, 5, 12), KodeBarang = "BRG002", NamaBarang = "Minyak Goreng 2L", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 9, StokSesudah = 8, Keterangan = "Transaksi kasir TRX003", Pengguna = "kasir1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 4, 10, 20, 0), KodeBarang = "BRG009", NamaBarang = "Keripik Singkong", Jenis = "KELUAR", Jumlah = 2, StokSebelum = 12, StokSesudah = 10, Keterangan = "KADALUARSA (Melewati tanggal kedaluwarsa)", Pengguna = "gudang1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 4, 11, 0, 0), KodeBarang = "BRG010", NamaBarang = "Mie Instan Goreng", Jenis = "MASUK", Jumlah = 100, StokSebelum = 100, StokSesudah = 200, Pemasok = "CV Sumber Pangan", Keterangan = "Penerimaan barang masuk MSK003", Pengguna = "gudang1" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), KodeBarang = "BRG007", NamaBarang = "Deterjen 800g", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 6, StokSesudah = 5, Keterangan = "Transaksi kasir TRX004", Pengguna = "kasir2" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), KodeBarang = "BRG006", NamaBarang = "Kopi Sachet 10s", Jenis = "TERJUAL", Jumlah = 1, StokSebelum = 10, StokSesudah = 9, Keterangan = "Transaksi kasir TRX004", Pengguna = "kasir2" },
                new RiwayatStok { Tanggal = new DateTime(2026, 11, 4, 16, 40, 55), KodeBarang = "BRG005", NamaBarang = "Air Mineral 600ml", Jenis = "TERJUAL", Jumlah = 3, StokSebelum = 153, StokSesudah = 150, Keterangan = "Transaksi kasir TRX004", Pengguna = "kasir2" }
            };
        }

        // Membaca daftar dokumen barang masuk gudang
        public static List<BarangMasuk> BacaBarangMasuk()
        {
            List<BarangMasuk> daftar = BacaData<BarangMasuk>("barang_masuk.json");
            if (daftar.Count == 0)
            {
                daftar = BuatDataBarangMasukAwal();
                SimpanData("barang_masuk.json", daftar);
            }
            return daftar;
        }

        public static void TambahBarangMasuk(BarangMasuk barangMasuk)
        {
            List<BarangMasuk> daftarBarangMasuk = BacaBarangMasuk();
            daftarBarangMasuk.Add(barangMasuk);
            SimpanData("barang_masuk.json", daftarBarangMasuk);
        }

        private static List<BarangMasuk> BuatDataBarangMasukAwal()
        {
            return new List<BarangMasuk>
            {
                new BarangMasuk { Id = "MSK001", Tanggal = new DateTime(2026, 11, 1), KodeBarang = "BRG001", NamaBarang = "Beras Premium 5kg", Jumlah = 50, Pemasok = "CV Sumber Pangan", Petugas = "gudang1", Keterangan = "Pengiriman rutin" },
                new BarangMasuk { Id = "MSK002", Tanggal = new DateTime(2026, 11, 1), KodeBarang = "BRG004", NamaBarang = "Teh Botol 450ml", Jumlah = 120, Pemasok = "PT Minum Segar", Petugas = "gudang1", Keterangan = "Restok awal bulan" },
                new BarangMasuk { Id = "MSK003", Tanggal = new DateTime(2026, 11, 4), KodeBarang = "BRG010", NamaBarang = "Mie Instan Goreng", Jumlah = 100, Pemasok = "CV Sumber Pangan", Petugas = "gudang1", Keterangan = "Tambahan stok mie" }
            };
        }

        // Membaca daftar dokumen barang keluar gudang
        public static List<BarangKeluar> BacaBarangKeluar()
        {
            List<BarangKeluar> daftar = BacaData<BarangKeluar>("barang_keluar.json");
            if (daftar.Count == 0)
            {
                daftar = BuatDataBarangKeluarAwal();
                SimpanData("barang_keluar.json", daftar);
            }
            return daftar;
        }

        public static void TambahBarangKeluar(BarangKeluar barangKeluar)
        {
            List<BarangKeluar> daftarBarangKeluar = BacaBarangKeluar();
            daftarBarangKeluar.Add(barangKeluar);
            SimpanData("barang_keluar.json", daftarBarangKeluar);
        }

        private static List<BarangKeluar> BuatDataBarangKeluarAwal()
        {
            return new List<BarangKeluar>
            {
                new BarangKeluar { Id = "KLR001", Tanggal = new DateTime(2026, 11, 3, 8, 15, 40), KodeBarang = "BRG005", NamaBarang = "Air Mineral 600ml", Jumlah = 6, Alasan = "RUSAK", Keterangan = "Kemasan bocor", Petugas = "gudang1" },
                new BarangKeluar { Id = "KLR002", Tanggal = new DateTime(2026, 11, 4, 10, 20, 0), KodeBarang = "BRG009", NamaBarang = "Keripik Singkong", Jumlah = 2, Alasan = "KADALUARSA", Keterangan = "Melewati tanggal kedaluwarsa", Petugas = "gudang1" }
            };
        }

        // Generator ID berurutan otomatis (TRX001, TRX002, ..., TRX005) - Memenuhi Kasus Uji 8
        public static string BuatIdTransaksi()
        {
            return BuatIdBerikutnya(BacaTransaksi().Select(data => data.Id), "TRX");
        }

        // Generator ID barang otomatis (BRG001, BRG002, ..., BRG012) - Memenuhi Kasus Uji 11
        public static string BuatIdBarang()
        {
            return BuatIdBerikutnya(BacaBarang().Select(data => data.Kode), "BRG");
        }

        // Generator ID barang masuk otomatis (MSK001, MSK002, ..., MSK004) - Memenuhi Kasus Uji 13
        public static string BuatIdBarangMasuk()
        {
            return BuatIdBerikutnya(BacaBarangMasuk().Select(data => data.Id), "MSK");
        }

        // Generator ID barang keluar otomatis (KLR001, KLR002, ..., KLR003) - Memenuhi Kasus Uji 14
        public static string BuatIdBarangKeluar()
        {
            return BuatIdBerikutnya(BacaBarangKeluar().Select(data => data.Id), "KLR");
        }

        // Fungsi pembantu untuk mencari angka terbesar dan memformat ID baru berurutan (misal: TRX + 005 = TRX005)
        private static string BuatIdBerikutnya(IEnumerable<string> daftarId, string awalan)
        {
            int nomorTerbesar = 0;
            foreach (string id in daftarId)
            {
                if (!string.IsNullOrEmpty(id) && id.StartsWith(awalan, StringComparison.OrdinalIgnoreCase))
                {
                    string sisa = id.Substring(awalan.Length);
                    // Ambil angka dari sisa string
                    string angkaStr = "";
                    foreach (char c in sisa)
                    {
                        if (char.IsDigit(c)) angkaStr += c;
                        else break;
                    }

                    if (int.TryParse(angkaStr, out int nomor))
                    {
                        nomorTerbesar = Math.Max(nomorTerbesar, nomor);
                    }
                }
            }
            return awalan + (nomorTerbesar + 1).ToString("D3");
        }

        public static void TambahDetailTransaksi(List<DetailTransaksi> rincian)
        {
            if (rincian != null && rincian.Count > 0)
            {
                List<DetailTransaksi> daftarDetail = BacaDetailTransaksi();
                daftarDetail.AddRange(rincian);
                SimpanDetailTransaksi(daftarDetail);
            }
        }
    }
}
