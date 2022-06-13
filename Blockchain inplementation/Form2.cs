using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blockchain_inplementation
{
    public partial class Form2 : Form
    {
        private Blockchain blockchain;
        private Wallet wallet;
        public Form2()
        {
            InitializeComponent();

            blockchain = new Blockchain();
            wallet = new Wallet();
        }


        
    }
}
