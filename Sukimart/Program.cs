namespace Sukimart
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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