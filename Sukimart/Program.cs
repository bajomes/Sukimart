namespace Sukimart
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0 && args[0] == "--test")
            {
                JalankanVerifikasi();
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => TampilkanKesalahan(e.Exception, true);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    TampilkanKesalahan(ex, false);
                }
            };
            ApplicationConfiguration.Initialize();
            FontInter.Muat();
            Application.Run(new FormLogin());
        }

        // Metode verifikasi otomatis untuk memastikan kredensial default dan data kosong
        private static void JalankanVerifikasi()
        {
            Console.WriteLine("=== VERIFIKASI SUKIMART ===");
            PenyimpananData.SimpanPengguna(PenyimpananData.BuatPenggunaAwal());
            var pengguna = PenyimpananData.BacaPengguna();
            Console.WriteLine($"Total pengguna: {pengguna.Count}");
            foreach (var p in pengguna)
            {
                string pw = p.Peran == "admin" ? "admin123" : (p.Peran == "gudang" ? "gudang123" : "kasir123");
                bool cocok = KeamananSandi.Cocok(p, pw);
                Console.WriteLine($"Pengguna '{p.NamaPengguna}' ({p.Peran}) sandi '{pw}': cocok = {cocok}");
            }

            Console.WriteLine($"Barang count: {PenyimpananData.BacaBarang().Count}");
            Console.WriteLine($"Transaksi count: {PenyimpananData.BacaTransaksi().Count}");
            Console.WriteLine($"DetailTransaksi count: {PenyimpananData.BacaDetailTransaksi().Count}");
            Console.WriteLine($"BarangMasuk count: {PenyimpananData.BacaBarangMasuk().Count}");
            Console.WriteLine($"BarangKeluar count: {PenyimpananData.BacaBarangKeluar().Count}");
            Console.WriteLine($"RiwayatStok count: {PenyimpananData.BacaRiwayatStok().Count}");
            Console.WriteLine($"LogAktivitas count: {PenyimpananData.BacaAktivitas().Count}");

            Console.WriteLine($"ID Barang berikutnya: {PenyimpananData.BuatIdBarang()}");
            Console.WriteLine($"ID Transaksi berikutnya: {PenyimpananData.BuatIdTransaksi()}");
            Console.WriteLine($"ID Masuk berikutnya: {PenyimpananData.BuatIdBarangMasuk()}");
            Console.WriteLine($"ID Keluar berikutnya: {PenyimpananData.BuatIdBarangKeluar()}");
            Console.WriteLine("=== VERIFIKASI SELESAI ===");
        }

        private static void TampilkanKesalahan(Exception ex, bool tetapBerjalan)
        {
            string keterangan = tetapBerjalan
                ? "Terjadi kesalahan yang tidak terduga, tetapi aplikasi tetap berjalan."
                : "Terjadi kesalahan yang tidak terduga dan aplikasi harus ditutup.";
            MessageBox.Show(
                keterangan + "\n\n" + ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}