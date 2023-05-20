using pinballServer;
using pinballServer.ConnectionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pinball
{
    public partial class choiceWin : Form
    {
        ClientMainWin main;
       
        public choiceWin(ClientMainWin main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void WaitingRoom_Load(object sender, EventArgs e)
        {

        }

        private void BtnOpenWatingRoom_Click(object sender, EventArgs e)
        {
            MessageModel message = new MessageModel();
            message.MsgType = ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM;
            message.player = main.connectionManager.currPlayer;
            main.connectionManager.sendMessageToServer(message);
        }

        private void BtnJoinGame_Click(object sender, EventArgs e)
        {
            MessageModel message = new MessageModel();
            message.MsgType = ProtocolInterface.MsgType.LIST_OPEN_ROOMS;
            message.player = main.connectionManager.currPlayer;
            main.connectionManager.sendMessageToServer(message);
        }

        
    }
}
