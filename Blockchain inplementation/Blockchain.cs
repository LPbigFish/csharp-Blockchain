using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain_inplementation
{
    internal class Blockchain : Cryptography
    {
        List<Block> blockchain = new List<Block>();

        public Blockchain()
        {
            blockchain.Add(new Block(BitConverter.ToString(Sha256(GetBytes("00"))), null, GetUnixTime(), 90000, 1, null));
        }

    }
}
