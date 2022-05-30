using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Secp256k1Net;
using Base58Check;
using System.IO;

namespace Blockchain_inplementation
{
    class Cryptography
    {
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
            return BitConverter.ToString(hash);
        }

        public uint GetUnixTime()
        {
            return (uint)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static string[] GetPhrase(string stream, byte[] privateKey)
        {
            string[] words;
            
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                using (StreamReader str = new StreamReader(stream))
                {
                    words = str.ReadToEnd().Replace("\r", string.Empty).Split('\n');
                    string[] funny = words;
                    string[] splitter = { "11010010" };
                    byte[] bytes = privateKey;


                    words = bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();

                    foreach (string item in words)
                    {
                        splitter[0] += item;
                    }

                    splitter = MySplit(splitter[0]);

                    int[] converted = new int[24];

                    for (int i = 0; i < splitter.Length; i++)
                    {
                        converted[i] = Convert.ToInt32(splitter[i], 2);
                    }

                    string[] final = new string[24];

                    for (int i = 0; i < converted.Length; i++)
                    {
                        final[i] = funny[converted[i]];
                    }
                    str.Close();
                    return final;
                }
            }
        }

        public static string ReversePhrase(string stream, string words)
        {
            using (StreamReader str = new StreamReader(stream))
            {
                string[] wordlist = str.ReadToEnd().Replace("\r", string.Empty).Split('\n');
                string[] list = words.Split(' ');
                int[] DecimalCount = new int[24];
                string[] Binary = new string[24];
                string oneBinary = "";

                for (int i = 0; i < list.Length; i++)
                {
                    DecimalCount[i] = (WordSearch(stream, list[i]) - 1);
                    Binary[i] = Convert.ToString(DecimalCount[i], 2).PadLeft(11, '0');
                }

                for (int i = 0; i < Binary.Length; i++)
                {
                    oneBinary += Binary[i];
                }

                oneBinary = String.Join(String.Empty, Binary);

                oneBinary = oneBinary.Remove(0, 8);
                int numOfBytes = oneBinary.Length / 8;
                byte[] bytes = new byte[numOfBytes];
                for (int i = 0; i < numOfBytes; ++i)
                {
                    bytes[i] = Convert.ToByte(oneBinary.Substring(8 * i, 8), 2);
                }

                str.Close();

                return BitConverter.ToString(bytes);
            }

            
        }

        public static byte[] GetBytes(string Bytes)
        {
            return Bytes.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
        }

        public byte[] Checksum(byte[] Signature)
        {
            return GetBytes(BitConverter.ToString(Sha256(Sha256(Signature))).Remove(11));
        }

        public string EncodeBase58(byte[] Data)
        {
            return Base58CheckEncoding.EncodePlain(Data);
        }

        public byte[] DecodeBase58(string Data)
        {
            return Base58CheckEncoding.DecodePlain(Data);
        }

        public string CreateWIFKey(byte[] PrivateKey)
        {
            string extpriv = "08-" + BitConverter.ToString(PrivateKey) + "-01";
            byte[] Ext = GetBytes(extpriv).Concat(Checksum(Sha256(Sha256(GetBytes(extpriv))))).ToArray();
            return EncodeBase58(Ext);
        }

        public void Genkeys(out byte[] PrivateKey, out byte[] PublicKey)
        {
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

        public void Genkeys(byte[] PrivateKey, out byte[] PublicKey)
        {
            using (var sec = new Secp256k1())
            {
                var rnd = RandomNumberGenerator.Create();
                do { rnd.GetBytes(PrivateKey); }
                while (!sec.SecretKeyVerify(PrivateKey));

                var publicKey = new byte[64];
                sec.PublicKeyCreate(publicKey, PrivateKey);
                PublicKey = publicKey;
            }
        }

        public static string[] MySplit(string input)
        {
            List<string> result = new List<string>();
            int count = 0;
            string temp = "";

            foreach (char c in input)
            {
                temp += c;
                count++;
                if (count == 11)
                {
                    result.Add(temp);
                    temp = "";
                    count = 0;
                }
            }

            if (temp != "")
                result.Add(temp);

            return result.ToArray();
        }

        public static int WordSearch(string stream, string word)
        {
            using (StreamReader str = new StreamReader(stream))
            {
                //string[] wordlist = str.ReadToEnd().Replace("\r", string.Empty).Split('\n');
                string line;
                int counter = 0;

                while ((line = str.ReadLine()) != null)
                {
                    if (line.Contains(word))
                    {
                        return counter + 1;
                    }

                    counter++;
                }
                return 0;
            }
        }

        public Cryptography()
        {

        }
    }
}
