using System;
using System.Windows.Forms;
using System.IO;

namespace Blockchain_inplementation
{
    public partial class Form1 : Form
    {
        private Wallet wallet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wallet = new Wallet();
            wallet.GenAddress();
            richTextBox1.Text = BitConverter.ToString(wallet.PrivateKey);
            richTextBox3.Text = String.Join(" ", wallet.WalletGetPhrase(Directory.GetCurrentDirectory() + "/wordlist.txt"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = wallet.SignMessage(richTextBox1.Text);

            richTextBox3.Text = wallet.lastMessHash;
        }

        private void Verify_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(wallet.VerifyMessage(richTextBox2.Text, richTextBox1.Text).ToString());
        }

        private void PhraseBTN_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = wallet.WalletReversePhrase(Directory.GetCurrentDirectory() + "/wordlist.txt", richTextBox3.Text);
        }
    }
}
