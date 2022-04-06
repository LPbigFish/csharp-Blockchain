using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BigMath;

namespace Blockchain_inplementation
{
    internal class Wallet : Cryptography
    {
        public string PrivateKey;
        string PublicKey;
        public string address;

        public Wallet()
            : base() => Genkeys(out PrivateKey, out PublicKey);
        public void GenAddress()
        {
            address = r160(sha256(PublicKey));
            address = PublicKey;

            string[] pub = PublicKey.Split(',');
            Int128 x = Int128.Parse(pub[0], System.Globalization.NumberStyles.HexNumber);
            Int128 y = Int128.Parse(pub[1], System.Globalization.NumberStyles.HexNumber);
            string _y = y.ToString();

            if (int.Parse(y[_y.Length - 1])%2 == 0)
            {

            }
        }
    }
}
