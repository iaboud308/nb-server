using System.Text;
using System.Security.Cryptography;

namespace server.Services {

    public class PasswordHashingService {

        public string EncryptPassword(string Password, string keyString) {

            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create()) {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV)) {
                    using (var msEncrypt = new MemoryStream()) {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt)) {
                            swEncrypt.Write(Password);
                        }

                        var iv = aesAlg.IV;
                        var decryptedPassword = msEncrypt.ToArray();
                        var result = new byte[iv.Length + decryptedPassword.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedPassword, 0, result, iv.Length, decryptedPassword.Length);

                        return Convert.ToBase64String(result);
                    }
                }

            }

        }











        

    }

}