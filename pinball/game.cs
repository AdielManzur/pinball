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
using static pinballServer.ConnectionClasses.ProtocolInterface;

namespace pinball
{
    public partial class game : Form
    {
        ClientMainWin main;


        int screenHeight;
        int screenWidth;
        Ball ball1;


        public game(ClientMainWin main)
        {

            InitializeComponent();
            this.main = main;
        }
        private void Game_Load(object sender, EventArgs e)
        {
            screenHeight = this.Height;
            screenWidth = this.Width;
            ball1.ballRadius = ball.Width / 2;
            ball1.ballLocation = ball.Location;
            ballStart();
        }
        public void ballStart()
        {
            MessageModel msg = new MessageModel();

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
            if (e.KeyCode == Keys.T && rightPlayer.Top >= 0)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_T;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.S && leftPlayer.Top + leftPlayer.Height <= screenHeight)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_S;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.G && rightPlayer.Top + rightPlayer.Height <= screenHeight)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_G;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
        }

        

        public void MykeyPressed(MsgType MsgType)
        {
            this.Invoke((MethodInvoker)delegate{
                if (MsgType == MsgType.KEY_W && leftPlayer.Top >= 0)
                {
                    leftPlayer.Top -= 20;

                }
                else if (MsgType == MsgType.KEY_T && rightPlayer.Top >= 0)
                {
                    rightPlayer.Top -= 20;

                }
                else if (MsgType == MsgType.KEY_S && leftPlayer.Top + leftPlayer.Height <= screenHeight)
                {
                    leftPlayer.Top += 20;

                }
                else if (MsgType == MsgType.KEY_G && rightPlayer.Top + rightPlayer.Height <= screenHeight)
                {
                    rightPlayer.Top += 20;

                }

                leftPlayer.Invalidate();
                rightPlayer.Invalidate();

            });

           
        }
    }
}
