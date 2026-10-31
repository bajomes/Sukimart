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
                throw new InvalidDataException(
                    $"File {namaFile} bukan JSON yang valid. Periksa tanda kurung, koma, dan tanda kutip.", ex);
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