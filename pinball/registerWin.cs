using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using pinballServer;
using pinballServer.ConnectionClasses;

namespace pinball
{
    public partial class registerWin : Form
    {
        ClientMainWin main;
        dbEntities db = new dbEntities();


        public registerWin(ClientMainWin main)
        {

            InitializeComponent();
            this.main = main;
        }
        private void registerWin_Load(object sender, EventArgs e)
        {
            
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            PlayerS newPlayer = new PlayerS();
            newPlayer.firstName = firstNameTxb.Text.Trim();
            newPlayer.lastName = LastNameTxb.Text.Trim();
            newPlayer.password = txbPass.Text.Trim();
            newPlayer.username = txbUsername.Text.Trim();
            MessageModel mToSend = new MessageModel();
            mToSend.MsgType = ProtocolInterface.MsgType.MSG_REGISTER;
            mToSend.player = newPlayer;
            main.sendMessageToServer(mToSend);

            
        }

      
    }
}
