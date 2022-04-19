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

        public static byte[] Sha256(byte[] randomString)
        {
            var crypt = new SHA256Managed();
            return crypt.ComputeHash(randomString);
        }
        public static string R160(byte[] pass)
        {
            RIPEMD160 r160 = RIPEMD160Managed.Create();
            var hash = r160.ComputeHash(pass);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
        public byte[] GetBytes(string _sign)
        {
            return _sign.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
        }

        public void Genkeys(out byte[] PrivateKey, out byte[] PublicKey)
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
                PublicKey = publicKey;
                PrivateKey = privateKey;
            }
        }


        public Cryptography()
        {

        }
    }
}
