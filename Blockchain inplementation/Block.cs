using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_inplementation
{
    internal class Block : Cryptography
    {
        public readonly uint height;
        public readonly string prevBlock = "";
        public readonly string data = "";
        public readonly uint timestamp;

        public Block(uint height, string prevBlock, string data, uint timestamp)
        {
            this.height = height;
            this.prevBlock = prevBlock;
            this.data = data;
            this.timestamp = timestamp;
        }
    }
}
