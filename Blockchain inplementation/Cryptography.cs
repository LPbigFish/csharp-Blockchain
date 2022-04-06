using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Secp256k1Net;

namespace Blockchain_inplementation
{
    class Cryptography
    {
        public ASCIIEncoding byter = new ASCIIEncoding();
        public RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public static string r160(string password)
        {
            RIPEMD160 r160 = RIPEMD160Managed.Create();
            byte[] myByte = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] encrypted = r160.ComputeHash(myByte);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encrypted.Length; i++)
            {
                sb.Append(encrypted[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        public void Genkeys(out string PrivateKey, out string PublicKey)
        {
            /*
            using (RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider(2048))
            {
                _rsa.PersistKeyInCsp = false;
                PrivateKey = _rsa.ExportParameters(true);
                PublicKey = _rsa.ExportParameters(false);
                StringifiedPublicKey = _rsa.ToXmlString(false);
                StringifiedPublicKey = StringifiedPublicKey.Remove(0, 22);
                StringifiedPublicKey = StringifiedPublicKey.Remove(StringifiedPublicKey.Length - 49, 49);
                StringifiedPublicKey = BitConverter.ToString(Convert.FromBase64String(StringifiedPublicKey), 0).ToString();
            }
            */

            using (var sec = new Secp256k1())
            {
                var privateKey = new byte[32];
                var rnd = RandomNumberGenerator.Create();
                do { rnd.GetBytes(privateKey); }
                while (!sec.SecretKeyVerify(privateKey));

                var publicKey = new byte[64];
                sec.PublicKeyCreate(publicKey, privateKey);

                PrivateKey = BitConverter.ToString(privateKey).Replace("-", string.Empty);
                PublicKey = BitConverter.ToString(publicKey).Replace("-", string.Empty).Insert(64, ",");
            }
        }


        public Cryptography()
        {

        }
    }
}
