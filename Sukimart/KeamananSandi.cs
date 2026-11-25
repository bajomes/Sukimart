using System.Security.Cryptography;
using System.Text;

namespace Sukimart
{
    // Utilitas keamanan untuk hashing kata sandi pengguna menggunakan algoritma PBKDF2 SHA-256
    public static class KeamananSandi
    {
        // Standar jumlah iterasi untuk algoritma PBKDF2
        public const int IterasiBawaan = 100000;
        private const int UkuranGaram = 16;
        private const int UkuranHash = 32;

        // Menghasilkan garam (salt) acak dan membuat hash PBKDF2 SHA-256 untuk kata sandi
        public static void IsiSandi(Pengguna pengguna, string kataSandi)
        {
            byte[] garam = RandomNumberGenerator.GetBytes(UkuranGaram);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(kataSandi),
                garam,
                IterasiBawaan,
                HashAlgorithmName.SHA256,
                UkuranHash);

            pengguna.Garam = Convert.ToBase64String(garam);
            pengguna.HashSandi = Convert.ToBase64String(hash);
            pengguna.Iterasi = IterasiBawaan;
        }

        // Memeriksa kecocokan kata sandi yang dimasukkan dengan hash yang tersimpan
        public static bool Cocok(Pengguna pengguna, string kataSandi)
        {
            if (pengguna == null || kataSandi == null) return false;
            if (string.IsNullOrEmpty(pengguna.Garam) || string.IsNullOrEmpty(pengguna.HashSandi))
            {
                return false;
            }

            try
            {
                byte[] garam = Convert.FromBase64String(pengguna.Garam);
                byte[] hashTersimpan = Convert.FromBase64String(pengguna.HashSandi);
                int iterasi = pengguna.Iterasi > 0 ? pengguna.Iterasi : IterasiBawaan;

                byte[] hashBaru = Rfc2898DeriveBytes.Pbkdf2(
                    Encoding.UTF8.GetBytes(kataSandi),
                    garam,
                    iterasi,
                    HashAlgorithmName.SHA256,
                    hashTersimpan.Length);

                return CryptographicOperations.FixedTimeEquals(hashBaru, hashTersimpan);
            }
            catch (FormatException)
            {
                // Garam/hash di file bukan Base64 yang valid → tolak.
                return false;
            }
        }
    }
}
