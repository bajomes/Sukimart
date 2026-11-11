using System.Text.Json;

namespace Sukimart
{
    public static class PenyimpananData
    {
        private static readonly JsonSerializerOptions opsiJson = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        private static string LokasiFile(string namaFile)
        {
            string folderSumber = Path.Combine(Application.StartupPath, "Data");
            string folderData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Sukimart", "Data");
            Directory.CreateDirectory(folderData);

            string lokasiTujuan = Path.Combine(folderData, namaFile);
            string lokasiAwal = Path.Combine(folderSumber, namaFile);
            if (!File.Exists(lokasiTujuan) && File.Exists(lokasiAwal))
            {
                File.Copy(lokasiAwal, lokasiTujuan);
            }

            return lokasiTujuan;
        }

        private static List<T> BacaData<T>(string namaFile)
        {
            string lokasi = LokasiFile(namaFile);

            if (!File.Exists(lokasi))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(lokasi);

            try
            {
                return JsonSerializer.Deserialize<List<T>>(json, opsiJson) ?? new List<T>();
            }
            catch (JsonException ex)
            {
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

        private static void SimpanData<T>(string namaFile, List<T> data)
        {
            string lokasi = LokasiFile(namaFile);
            string fileSementara = lokasi + ".tmp";
            string json = JsonSerializer.Serialize(data, opsiJson);
            File.WriteAllText(fileSementara, json);
            File.Move(fileSementara, lokasi, true);
        }

        public static List<string> BacaKategori()
        {
            List<string> daftarKategori = BacaData<string>("kategori.json");
            if (daftarKategori.Count == 0)
            {
                daftarKategori = new List<string> { "Makanan", "Minuman", "Perlengkapan", "Lainnya" };
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

        public static List<Barang> BacaBarang()
        {
            return BacaData<Barang>("barang.json");
        }

        public static void SimpanBarang(List<Barang> daftarBarang)
        {
            SimpanData("barang.json", daftarBarang);
        }

        public static List<Transaksi> BacaTransaksi()
        {
            return BacaData<Transaksi>("transaksi.json");
        }

        public static void SimpanTransaksi(List<Transaksi> daftarTransaksi)
        {
            SimpanData("transaksi.json", daftarTransaksi);
        }

        public static void TambahTransaksi(Transaksi transaksi)
        {
            List<Transaksi> daftarTransaksi = BacaTransaksi();
            daftarTransaksi.Add(transaksi);
            SimpanTransaksi(daftarTransaksi);
        }

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
        }

        public static List<DetailTransaksi> BacaDetailTransaksi()
        {
            return BacaData<DetailTransaksi>("detail_transaksi.json");
        }

        public static void SimpanDetailTransaksi(List<DetailTransaksi> daftarDetail)
        {
            SimpanData("detail_transaksi.json", daftarDetail);
        }

        public static List<Pengguna> BacaPengguna()
        {
            List<Pengguna> daftarPengguna = BacaData<Pengguna>("pengguna.json");
            if (daftarPengguna.Count == 0)
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

        private static List<Pengguna> BuatPenggunaAwal()
        {
            Pengguna admin = new Pengguna { NamaPengguna = "admin", Peran = "admin", Dibuat = DateTime.Now };
            Pengguna kasir = new Pengguna { NamaPengguna = "kasir", Peran = "kasir", Dibuat = DateTime.Now };
            Pengguna gudang = new Pengguna { NamaPengguna = "gudang", Peran = "gudang", Dibuat = DateTime.Now };
            KeamananSandi.IsiSandi(admin, "admin123");
            KeamananSandi.IsiSandi(kasir, "kasir123");
            KeamananSandi.IsiSandi(gudang, "gudang123");
            return new List<Pengguna> { admin, kasir, gudang };
        }

        public static List<RiwayatStok> BacaRiwayatStok()
        {
            return BacaData<RiwayatStok>("riwayat_stok.json");
        }

        public static void TambahRiwayatStok(RiwayatStok catatan)
        {
            List<RiwayatStok> daftarRiwayat = BacaRiwayatStok();
            daftarRiwayat.Add(catatan);
            SimpanData("riwayat_stok.json", daftarRiwayat);
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