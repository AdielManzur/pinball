using pinballServer.ConnectionClasses;
using pinballServer.GamesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        Ball ball1 = new Ball();
        int counter = 6;


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


        public void firstBallMovement(Vector2 ballVector)
        {
            ball1.vector = ballVector;
            ball1.ballLocation = ball.Location;
            ball1.ballSpeedY = 15 * ball1.vector.Y;
            ball1.ballSpeedX = 15 * ball1.vector.X;
            countdownTimer.Enabled = true;
            

        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdatenBallLocation();
            
            if (ball1.checkCollisionWithLeftPlayer(leftPlayer.Location,leftPlayer.Height, rightPlayer.Width))
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_LEFT_PLAYER;
                msg.player = main.connectionManager.currPlayer;
                main.sendMessageToServer(msg);
            }
            else if(ball1.checkCollisionWithRightPlayer(rightPlayer.Location, rightPlayer.Height, rightPlayer.Width))
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_RIGHT_PLAYER;
                msg.player = main.connectionManager.currPlayer;
                main.sendMessageToServer(msg);
            }
            else if (ball1.collisionLowerWall(screenHeight))
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_LOWER_WALL;
                msg.player = main.connectionManager.currPlayer;
                main.sendMessageToServer(msg);
            }
            else if (ball1.collisionUpperWall())
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_UPPER_WALL;
                msg.player = main.connectionManager.currPlayer;
                main.sendMessageToServer(msg);
            }
            else if (ball1.goalToLeftPlayer())
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_LEFT_WALL;
                msg.player = main.connectionManager.currPlayer;
                main.sendMessageToServer(msg);
            }
            else if (ball1.goalToRightPlayer(screenWidth))
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_RIGHT_WALL;
                msg.player = main.connectionManager.currPlayer;
                main.sendMessageToServer(msg);
            }

        }

        private void UpdatenBallLocation()
        {
            ball1.ballLocation = ball.Location;
            ball1.ballSpeedY = 15 * ball1.vector.Y;
            ball1.ballSpeedX = 15 * ball1.vector.X;
            ball.Top += (int)ball1.ballSpeedY;
            ball.Left += (int)ball1.ballSpeedX;
            ball1.ballLocation = ball.Location;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                countdownLBL.Visible = false;
                countdownTimer.Stop();
                countdownLBL.Text = "";
                timerBallMovement.Enabled = true;
            }
            countdownLBL.Text = counter.ToString();
            countdownLBL.Location = new Point((int)((this.Width - countdownLBL.Width) / 2), countdownLBL.Location.Y);
        }
    }
}
