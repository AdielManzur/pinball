using pinballServer.ConnectionClasses;
using pinballServer.GamesClasses;
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
    public partial class game : Form
    {
        ClientMainWin main;


        int screenHeight = 980;

        public game(ClientMainWin main)
        {

            InitializeComponent();
            this.main = main;
        }
        private void Game_Load(object sender, EventArgs e)
        {

        }


        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            MessageModel msgToServer = new MessageModel();
            msgToServer.player = main.connectionManager.currPlayer;
            if (e.KeyCode == Keys.W && leftPlayer.Top >= 0)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_W;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.Up && rightPlayer.Top >= 0)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.UP;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.S && leftPlayer.Top + leftPlayer.Height <= screenHeight)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_S;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.Down && rightPlayer.Top + rightPlayer.Height <= screenHeight)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.DOWN;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
        }

        private void leftPlayer_Click(object sender, EventArgs e)
        {

        }

        public void keyPressed(ProtocolInterface.MsgType MsgType)
        {
            
                if (MsgType == ProtocolInterface.MsgType.KEY_W && leftPlayer.Top >= 0)
                {
                    rightPlayer.Top -= 20;

                }
                if (MsgType == ProtocolInterface.MsgType.UP && rightPlayer.Top >= 0)
                {
                    rightPlayer.Top -= 20;

                }
                if (MsgType == ProtocolInterface.MsgType.KEY_S && leftPlayer.Top + leftPlayer.Height <= screenHeight)
                {
                    leftPlayer.Top += 20;

                }
                if (MsgType == ProtocolInterface.MsgType.DOWN && rightPlayer.Top + rightPlayer.Height <= screenHeight)
                {
                    rightPlayer.Top += 20;

            }

            leftPlayer.Update();
            rightPlayer.Update();
        }
    }
}
