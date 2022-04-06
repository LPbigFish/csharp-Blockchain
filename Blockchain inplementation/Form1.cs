using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            wallet = new Wallet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wallet.GenAddress();
            richTextBox1.Text = wallet.address;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = wallet.SignMessage(richTextBox1.Text);

            MessageBox.Show(wallet.VerifyMessage(richTextBox2.Text).ToString());
        }
    }
}
