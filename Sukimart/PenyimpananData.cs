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

            SimpanStruk(transaksi, rincian);
        }

        public static void SimpanStruk(Transaksi transaksi, List<DetailTransaksi>? rincian)
        {
            try
            {
                string folderData = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Sukimart", "struk");
                Directory.CreateDirectory(folderData);

                string lokasiFile = Path.Combine(folderData, $"{transaksi.Id}.json");
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
                        harga = r.Harga,
                        jumlah = r.Jumlah,
                        subtotal = r.Subtotal
                    }).ToList()
                };

                string json = JsonSerializer.Serialize(dataStruk, opsiJson);
                File.WriteAllText(lokasiFile, json);

                // Simpan juga ke folder proyek/struk jika aplikasi berjalan di folder proyek
                try
                {
                    string folderProyekStruk = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "struk");
                    Directory.CreateDirectory(folderProyekStruk);
                    File.WriteAllText(Path.Combine(folderProyekStruk, $"{transaksi.Id}.json"), json);
                }
                catch { }
            }
            catch { }
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

            // Hanya buat pengguna awal kalau file benar-benar kosong
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
            Pengguna admin = new Pengguna { NamaPengguna = "admin", NamaLengkap = "Administrator Suki MART", Peran = "admin", Aktif = true, Dibuat = DateTime.Now };
            Pengguna kasir = new Pengguna { NamaPengguna = "kasir1", NamaLengkap = "Dewi Lestari", Peran = "kasir", Aktif = true, Dibuat = DateTime.Now };
            Pengguna kasirNonaktif = new Pengguna { NamaPengguna = "kasir3", NamaLengkap = "Sari Wulandari", Peran = "kasir", Aktif = false, Dibuat = DateTime.Now };
            Pengguna gudang = new Pengguna { NamaPengguna = "gudang1", NamaLengkap = "Budi Santoso", Peran = "gudang", Aktif = true, Dibuat = DateTime.Now };
            KeamananSandi.IsiSandi(admin, "admin123");
            KeamananSandi.IsiSandi(kasir, "kasir123");
            KeamananSandi.IsiSandi(kasirNonaktif, "kasir123");
            KeamananSandi.IsiSandi(gudang, "gudang123");
            return new List<Pengguna> { admin, kasir, kasirNonaktif, gudang };
        }

        public static List<Aktivitas> BacaAktivitas()
        {
            List<Aktivitas> daftar = BacaData<Aktivitas>("log_aktivitas.json");
            bool adaMigrasi = false;
            foreach (var a in daftar)
            {
                if (string.IsNullOrWhiteSpace(a.JenisAktivitas))
                {
                    a.JenisAktivitas = TentukanJenisAktivitas(a.Aksi);
                    adaMigrasi = true;
                }

                if (!string.IsNullOrEmpty(a.Aksi) && a.Aksi.StartsWith("Aktivitas: Mengganti Kata Sandi", StringComparison.OrdinalIgnoreCase))
                {
                    a.Aksi = "Pengguna berhasil mengganti kata sandi akunnya sendiri.";
                    adaMigrasi = true;
                }
            }

            if (adaMigrasi)
            {
                try
                {
                    SimpanData("log_aktivitas.json", daftar);
                }
                catch { }
            }

            return daftar;
        }

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
            if (a.StartsWith("TAMBAH KATEGORI", StringComparison.OrdinalIgnoreCase)) return "Tambah Kategori";
            if (a.StartsWith("UBAH KATEGORI", StringComparison.OrdinalIgnoreCase)) return "Ubah Kategori";
            if (a.StartsWith("HAPUS KATEGORI", StringComparison.OrdinalIgnoreCase)) return "Hapus Kategori";
            if (a.StartsWith("TAMBAH PENGGUNA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("TAMBAH AKUN", StringComparison.OrdinalIgnoreCase)) return "Tambah Akun";
            if (a.StartsWith("UBAH PASSWORD", StringComparison.OrdinalIgnoreCase) || a.StartsWith("UBAH KATA SANDI", StringComparison.OrdinalIgnoreCase) || a.StartsWith("AKTIVITAS: MENGGANTI KATA SANDI", StringComparison.OrdinalIgnoreCase) || a.StartsWith("MENGGANTI KATA SANDI", StringComparison.OrdinalIgnoreCase)) return "Ubah Password";
            if (a.StartsWith("UBAH NAMA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("UBAH PROFIL", StringComparison.OrdinalIgnoreCase)) return "Ubah Nama";
            if (a.StartsWith("UBAH PENGGUNA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("UBAH AKUN", StringComparison.OrdinalIgnoreCase)) return "Ubah Akun";
            if (a.StartsWith("HAPUS PENGGUNA", StringComparison.OrdinalIgnoreCase) || a.StartsWith("HAPUS AKUN", StringComparison.OrdinalIgnoreCase)) return "Hapus Akun";
            if (a.StartsWith("TRANSAKSI", StringComparison.OrdinalIgnoreCase)) return "Transaksi";
            if (a.StartsWith("Masuk", StringComparison.OrdinalIgnoreCase) || a.StartsWith("STOK MASUK", StringComparison.OrdinalIgnoreCase)) return "Stok Masuk";
            if (a.StartsWith("Keluar", StringComparison.OrdinalIgnoreCase) || a.StartsWith("STOK KELUAR", StringComparison.OrdinalIgnoreCase)) return "Stok Keluar";
            return "Umum";
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

        public static List<BarangMasuk> BacaBarangMasuk()
        {
            return BacaData<BarangMasuk>("barang_masuk.json");
        }

        public static void TambahBarangMasuk(BarangMasuk barangMasuk)
        {
            List<BarangMasuk> daftarBarangMasuk = BacaBarangMasuk();
            daftarBarangMasuk.Add(barangMasuk);
            SimpanData("barang_masuk.json", daftarBarangMasuk);
        }

        public static List<BarangKeluar> BacaBarangKeluar()
        {
            return BacaData<BarangKeluar>("barang_keluar.json");
        }

        public static void TambahBarangKeluar(BarangKeluar barangKeluar)
        {
            List<BarangKeluar> daftarBarangKeluar = BacaBarangKeluar();
            daftarBarangKeluar.Add(barangKeluar);
            SimpanData("barang_keluar.json", daftarBarangKeluar);
        }

        public static string BuatIdBarangMasuk()
        {
            return BuatIdBerikutnya(BacaBarangMasuk().Select(data => data.Id), "MSK");
        }

        public static string BuatIdBarangKeluar()
        {
            return BuatIdBerikutnya(BacaBarangKeluar().Select(data => data.Id), "KLR");
        }

        private static string BuatIdBerikutnya(IEnumerable<string> daftarId, string awalan)
        {
            int nomorTerbesar = 0;
            foreach (string id in daftarId)
            {
                if (id.StartsWith(awalan, StringComparison.OrdinalIgnoreCase) && int.TryParse(id[awalan.Length..], out int nomor))
                {
                    nomorTerbesar = Math.Max(nomorTerbesar, nomor);
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
