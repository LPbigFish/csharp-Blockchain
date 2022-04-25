using System;
using System.Text;
using BigMath;

namespace Blockchain_inplementation
{
    internal class Wallet : Cryptography
    {
        byte[] PrivateKey;
        byte[] PublicKey;
        byte[] Compressed;
        string WIFPrivateKey;
        public string address;
        public string lastMessHash;


        public Wallet()
            : base() => Genkeys(out PrivateKey, out PublicKey);

        public void GenAddress()
        {
            //string[] pub = BitConverter.ToString(PublicKey).Replace("-", string.Empty).Insert(64, ",").Split(',');

            string[] pubBits = BitConverter.ToString(PublicKey).Insert(64, ",").Split(',');
            BigInteger bigKeyY = new BigInteger(GetBytes(pubBits[1]));

            if (bigKeyY % 2 == 0)
            {
                pubBits[0] = "02-" + pubBits[0];
            }
            else
            {
                pubBits[0] = "03-" + pubBits[0];
            }

            Compressed = GetBytes(pubBits[0]);
            WIFPrivateKey = CreateWIFKey(PrivateKey);

            //address = R160(Sha256(GetBytes(pubBits[0])));
            address = CreateWIFKey(PrivateKey);
        }

        public string[] WalletGetPhrase(string stream)
        {
            return GetPhrase(stream);
        }

        public string SignMessage(string _mess)
        {
            using (var secp256k1 = new Secp256k1Net.Secp256k1())
            {
                var messBytes = UTF8Encoding.ASCII.GetBytes(_mess);
                var messHash = System.Security.Cryptography.SHA256.Create().ComputeHash(messBytes);
                var signature = new byte[64];

                secp256k1.Sign(signature, messHash, PrivateKey);
                lastMessHash = BitConverter.ToString(messHash);
                return BitConverter.ToString(signature);
            }
        }

        public bool VerifyMessage(string _sign, string _message)
        {
            using (var secp256k1 = new Secp256k1Net.Secp256k1())
            {
                var sign = new byte[64];
                sign = GetBytes(_sign);

                var messBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(UTF8Encoding.ASCII.GetBytes(_message));
                /*
                for (int i = 0; i < messages.Count; i++)
                {*/
                    if (secp256k1.Verify(sign, messBytes, PublicKey) == true)
                    {
                        return true;
                    }
                    /*
                }
                */
                return false;
                
            }
        }
    }
}
