using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pinballServer;

namespace pinball
{
    public partial class ClientLoginWin : Form
    {
        ClientMainWin main;
        dbEntities db = new dbEntities();
        public ClientLoginWin(ClientMainWin main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string s1 = txbUsername.Text.Trim();
            string s2 = txbPass.Text.Trim();
            main.sendLoginToServer(s1, s2);
        }

        private void ClientLoginWin_Load(object sender, EventArgs e)
        {

        }

        private void TxbUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
