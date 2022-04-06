using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Blockchain_inplementation
{
    internal class Wallet : Cryptography
    {
        byte[] PrivateKey;
        byte[] PublicKey;
        public string address;
        List<byte[]> messages = new List<byte[]>();


        public Wallet()
            : base() => Genkeys(out PrivateKey, out PublicKey);
        public void GenAddress()
        {
            string[] pub = BitConverter.ToString(PublicKey).Replace("-", string.Empty).Insert(64, ",").Split(',');
            address = r160(sha256(pub[0]));
        }

        public string SignMessage(string _mess)
        {
            using (var secp256k1 = new Secp256k1Net.Secp256k1())
            {
                var messBytes = UTF8Encoding.UTF8.GetBytes(_mess);
                var messHash = System.Security.Cryptography.SHA256.Create().ComputeHash(messBytes);
                var signature = new byte[64];

                secp256k1.Sign(signature, messHash, PrivateKey);

                messages.Add(messHash);

                return BitConverter.ToString(signature);
            }
        }

        public bool VerifyMessage(string _sign)
        {
            using (var secp256k1 = new Secp256k1Net.Secp256k1())
            {
                var sign = new byte[64];
                sign = GetBytes(_sign);
                var message = new byte[32];
                for (int i = 0; i < messages.Count; i++)
                {
                        if (secp256k1.Verify(sign, messages[i], PublicKey) == true)
                        {
                            return true;
                        }
                    
                }
                return false;
                
            }

        }
    }
}
