using System.Security.Cryptography;
using System.Text;

namespace Sukimart
{
    public static class KeamananSandi
    {
        public const int IterasiBawaan = 100000;
        private const int UkuranGaram = 16;
        private const int UkuranHash = 32;

        public static void IsiSandi(Pengguna pengguna, string kataSandi)
        {
            byte[] garam = RandomNumberGenerator.GetBytes(UkuranGaram);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(kataSandi), garam, IterasiBawaan, HashAlgorithmName.SHA256, UkuranHash);
            pengguna.Garam = Convert.ToBase64String(garam);
            pengguna.HashSandi = Convert.ToBase64String(hash);
            pengguna.Iterasi = IterasiBawaan;
        }

        public static bool Cocok(Pengguna pengguna, string kataSandi)
        {
            try
            {
                byte[] garam = Convert.FromBase64String(pengguna.Garam);
                byte[] hashTersimpan = Convert.FromBase64String(pengguna.HashSandi);
                int iterasi = pengguna.Iterasi > 0 ? pengguna.Iterasi : IterasiBawaan;
                byte[] hashBaru = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(kataSandi), garam, iterasi, HashAlgorithmName.SHA256, hashTersimpan.Length);
                return CryptographicOperations.FixedTimeEquals(hashBaru, hashTersimpan);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
