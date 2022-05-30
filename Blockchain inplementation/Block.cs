namespace Blockchain_inplementation
{
    internal class Block
    {
        public string prevBlock = "";
        public string data = "";
        public uint timestamp;
        public uint target;
        public uint nonce;
        public string[] transactions;

        public Block(string prevBlock, string root, uint timestamp, uint target, uint nonce, string[] transactions)
        {
            this.prevBlock = prevBlock;
            this.data = root;
            this.timestamp = timestamp;
            this.target = target;
            this.nonce = nonce;
            this.transactions = transactions;
        }
    }
}
