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
        public int scoreRightPlayer = 0;
        public int scoreLeftPlayer = 0;

        public game(ClientMainWin main,int mainPanelHeight, int mainPanelWidth)
        {

            InitializeComponent();
            this.main = main;
            this.Height = mainPanelHeight;
            this.Width = mainPanelWidth;
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

        public void collisionWithUpperOrLowerWall(Vector2 ballVector)
        {
            ball1.vector = ballVector;
            timerBallMovement.Enabled = true;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            UpdateBallLocation();
            label1.Text = "(" + ball1.ballLocation.X + "," + ball1.ballLocation.Y + ")";
            checkLocations();
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

            else if (ball1.collisionLowerWall(screenHeight) || ball1.collisionUpperWall())
            {
                
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_LOWER_OR_UPPER_WALL;
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
                msg.scorePlayer1 = scoreRightPlayer;
                msg.scorePlayer2 = scoreLeftPlayer;
                main.sendMessageToServer(msg);
            }
            else if (ball1.goalToRightPlayer(screenWidth))
            {
                timerBallMovement.Enabled = false;
                MessageModel msg = new MessageModel();
                msg.BallVector = ball1.vector;
                msg.MsgType = ProtocolInterface.MsgType.COLLISION_RIGHT_WALL;
                msg.player = main.connectionManager.currPlayer;
                msg.scorePlayer1 = scoreRightPlayer;
                msg.scorePlayer2 = scoreLeftPlayer;
                main.sendMessageToServer(msg);

            }

        }

        private void checkLocations()
        {
            if(ball1.ballLocation.Y + ball1.ballSpeedY < 0)
            {
                ball.Location = new Point(ball1.ballLocation.X, 0);
                ball1.ballLocation = new Point(ball1.ballLocation.X, 0);

            }
            if(ball1.ballLocation.Y + ball1.ballSpeedY + (2 * ball1.ballRadius) > screenHeight)
            {
                ball.Location = new Point(ball1.ballLocation.X, screenHeight - (int)(2 * ball1.ballRadius));
                ball1.ballLocation = new Point(ball1.ballLocation.X, screenHeight - (int)(2 * ball1.ballRadius));


            }
            if (ball1.ballLocation.X + (2*ball1.ballRadius) + ball1.ballSpeedX > screenWidth)
            {
                ball.Location = new Point(screenWidth - (int)(2 * ball1.ballRadius), ball1.ballLocation.Y);
                ball1.ballLocation = new Point(screenWidth - (int)(2 * ball1.ballRadius), ball1.ballLocation.Y);
            }
            if (ball1.ballLocation.X + ball1.ballSpeedX < 0 )
            {
                ball.Location = new Point(0, ball1.ballLocation.Y);
                ball1.ballLocation = new Point(0, ball1.ballLocation.Y);
            }
        }

        public void StopTimer()
        {
            timerBallMovement.Enabled = false;

        }

        private void UpdateBallLocation()
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
            countdownLBL.Location = new Point(ball.Location.X, countdownLBL.Location.Y);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
