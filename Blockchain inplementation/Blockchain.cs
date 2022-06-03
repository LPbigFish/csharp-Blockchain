using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain_inplementation
{
    internal class Blockchain : Cryptography
    {
        List<Block> blockchain = new List<Block>();
        readonly string genesis = "0000000000000000000000000000000000000000000000000000000000000000";
        public Blockchain()
        {
            blockchain.Add(new Block(genesis, null, GetUnixTime(), 0, 1, null));
        }

    }
}
