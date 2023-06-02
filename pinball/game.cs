﻿using pinballServer.ConnectionClasses;
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
        Point firstBallLocation;
        int counter = 6;
        public int scoreRightPlayer = 0;
        public int scoreLeftPlayer = 0;
        public int speed = 6;
        bool boolEnemyLeft = false;
        String leftPlayerName = "";
        String rightPlayerName = "";
        bool isWin = false;
        bool passedRightPlayer = false;
        bool passedLeftPlayer = false;


        public game(ClientMainWin main)
        {
            InitializeComponent();
            this.main = main;
        }
       
        private void Game_Load(object sender, EventArgs e)
        {
            ball.Left = (this.ClientSize.Width - ball.Width) / 2;
            ball.Top = (this.ClientSize.Height - ball.Width) / 2;
            ball1.ballRadius = ball.Width / 2;
            ball1.ballLocation = ball.Location;
            screenHeight = this.ClientSize.Height;
            screenWidth = this.ClientSize.Width;
            firstBallLocation = ball.Location;
            playerKeysLBL.Left = (this.ClientSize.Width - playerKeysLBL.Width) / 2;
            scoreLeftLBL.Left = (this.ClientSize.Width - scoreLeftLBL.Width) / 4;
            scoreRightLBL.Left = this.ClientSize.Width - ((this.ClientSize.Width - scoreRightLBL.Width) / 4);
            nameLBL.Text = "your name: " + main.connectionManager.currPlayer.username;
            updateLBL();
            
        }

        private void updateLBL()
        {
            scoreLeftLBL.Text = "score:" + scoreLeftPlayer;
            scoreRightLBL.Text = "score:" + scoreRightPlayer;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            MessageModel msgToServer = new MessageModel();
            msgToServer.player = main.connectionManager.currPlayer;
            if (e.KeyCode == Keys.W && leftPlayer.Top >= 0 && !boolEnemyLeft)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_W;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.T && rightPlayer.Top >= 0 && !boolEnemyLeft)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_T;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.S && leftPlayer.Top + leftPlayer.Height <= screenHeight && !boolEnemyLeft)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_S;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if (e.KeyCode == Keys.G && rightPlayer.Top + rightPlayer.Height <= screenHeight && !boolEnemyLeft)
            {
                msgToServer.MsgType = ProtocolInterface.MsgType.KEY_G;
                main.connectionManager.sendMessageToServer(msgToServer);
            }
            if(e.KeyCode == Keys.Space && boolEnemyLeft || isWin)
            {
                main.openChoiceWin();
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

        public void hadGoal(MessageModel message)
        {
            scoreRightPlayer = message.scoreRightPlayer;
            scoreLeftPlayer = message.scoreLeftPlayer;
            updateLBL();
            ball1.vector = message.BallVector;
            ball1.vector = Vector2.Normalize(ball1.vector);
            ball.Location = firstBallLocation;
            ball1.ballLocation = firstBallLocation;
            timerBallMovement.Enabled = true;
        }

        public void enemyLeft()
        {
            boolEnemyLeft = true;
            timerBallMovement.Enabled = false;
            if(!isWin)
                enemyPlayerLeftLBL.Visible = true;
            
        }

        public void firstBallMovement(MessageModel message)
        {

            playerKeysLBL.Text = message.msgStr;
            playerKeysLBL.Left = (this.ClientSize.Width - playerKeysLBL.Width) / 2;
            leftPlayerName = message.game.player2.username;
            rightPlayerName = message.game.player1.username;
            ball1.vector = message.BallVector;
            ball1.vector = Vector2.Normalize(ball1.vector);
            ball1.ballLocation = ball.Location;
            ball1.ballSpeedY = speed * ball1.vector.Y;
            ball1.ballSpeedX = speed * ball1.vector.X;
            countdownTimer.Enabled = true;
        
        }

 

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            UpdateBallLocation();
            checkLocations();
            if(scoreLeftPlayer == 3)
            {
                playerWonLBL.Text = leftPlayerName + " Won!";

                playerWonLBL.Visible = true;
                playerWonLBL.Left = (this.ClientSize.Width - playerWonLBL.Width) / 2;
                timerBallMovement.Enabled = false;
                isWin = true;
                hadWin();
                
            }
            if (scoreRightPlayer == 3)
            {
                playerWonLBL.Text = rightPlayerName + " Won!";
                playerWonLBL.Left = (this.ClientSize.Width - playerWonLBL.Width) / 2;
                playerWonLBL.Visible = true;
                timerBallMovement.Enabled = false;
                isWin = true;
                hadWin();


            }
            if (ball1.checkCollisionWithLeftPlayer(leftPlayer.Location,leftPlayer.Height,leftPlayer.Width))
            {
                ball1.vector = new Vector2(-ball1.vector.X, ball1.vector.Y);
            }
            else if (ball1.checkCollisionWithRightPlayer(rightPlayer.Location, rightPlayer.Height, rightPlayer.Width))
            {
                ball1.vector = new Vector2(-ball1.vector.X, ball1.vector.Y);
            }
            else if (ball1.collisionLowerWall(this.ClientSize.Height) || ball1.collisionUpperWall()) 
            {                              
                ball1.vector = new Vector2(ball1.vector.X, -ball1.vector.Y);
            }    
            
            else if (ball1.goalToLeftPlayer())
            {
               
                MessageModel msg = new MessageModel();
                msg.MsgType = MsgType.GOAL_TO_LEFT;
                msg.player = main.connectionManager.currPlayer;
                msg.BallVector = ball1.vector * 100;
                msg.scoreLeftPlayer = scoreLeftPlayer;
                msg.scoreRightPlayer = scoreRightPlayer;
                main.connectionManager.sendMessageToServer(msg);
                timerBallMovement.Enabled = false;
                
            }

            else if (ball1.goalToRightPlayer(this.ClientSize.Width))
            {
                
                MessageModel msg = new MessageModel();
                msg.MsgType = MsgType.GOAL_TO_RIGHT;
                msg.player = main.connectionManager.currPlayer;
                msg.BallVector = ball1.vector * 100;
                msg.scoreLeftPlayer = scoreLeftPlayer;
                msg.scoreRightPlayer = scoreRightPlayer;
                main.connectionManager.sendMessageToServer(msg);
                timerBallMovement.Enabled = false;
                
            }

        }

        private void hadWin()
        {

            backToLobbyLBL.Visible = true;
            backToLobbyLBL.Left = (this.ClientSize.Width - backToLobbyLBL.Width) / 2;
            main.disableLeaveBtn();

        }

        private void checkLocations()
        {
            
            if(ball1.ballLocation.Y + ball1.ballSpeedY < 0)
            {
                ball.Location = new Point(ball1.ballLocation.X, 0);
                ball1.ballLocation = new Point(ball1.ballLocation.X, 0);
                
            }
            else if(ball1.ballLocation.Y + ball1.ballSpeedY + (2 * ball1.ballRadius) > screenHeight)
            {
                ball.Location = new Point(ball1.ballLocation.X, screenHeight - (int)(2 * ball1.ballRadius));
                ball1.ballLocation = new Point(ball1.ballLocation.X, screenHeight - (int)(2 * ball1.ballRadius));
                
            }
            else if(ball1.ballLocation.X + (2*ball1.ballRadius) + ball1.ballSpeedX > screenWidth)
            {
                ball.Location = new Point(screenWidth - (int)(2 * ball1.ballRadius), ball1.ballLocation.Y);
                ball1.ballLocation = new Point(screenWidth - (int)(2 * ball1.ballRadius), ball1.ballLocation.Y);
                
            }
            else if (ball1.ballLocation.X + ball1.ballSpeedX < 0 )
            {
                ball.Location = new Point(0, ball1.ballLocation.Y);
                ball1.ballLocation = new Point(0, ball1.ballLocation.Y);
                
            }
            
            else if (ball1.ballLocation.X + (2 * ball1.ballRadius) + ball1.ballSpeedX > rightPlayer.Location.X && !passedRightPlayer)
            {
                ball.Location = new Point(rightPlayer.Location.X - (int)(2 * ball1.ballRadius), ball1.ballLocation.Y);
                ball1.ballLocation = new Point(rightPlayer.Location.X - (int)(2 * ball1.ballRadius), ball1.ballLocation.Y);
                passedRightPlayer = true;
            }

            else if (ball1.ballLocation.X + ball1.ballSpeedX < leftPlayer.Location.X + leftPlayer.Width && !passedLeftPlayer)
            {
                ball.Location = new Point(leftPlayer.Location.X + leftPlayer.Width, ball1.ballLocation.Y);
                ball1.ballLocation = new Point(leftPlayer.Location.X + leftPlayer.Width, ball1.ballLocation.Y);
                passedLeftPlayer = true;
            }
            if(ball1.ballLocation.X  + (2 * ball1.ballRadius) < rightPlayer.Location.X)
            {
                passedRightPlayer = false;
            }
            if (ball1.ballLocation.X > leftPlayer.Location.X + leftPlayer.Width)
            {
                passedLeftPlayer = false;
            }
                        
        }



        private void UpdateBallLocation()
        {
            ball1.ballLocation = ball.Location;
            ball1.ballSpeedY = speed * ball1.vector.Y;
            ball1.ballSpeedX = speed * ball1.vector.X;
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
                countdownTimer.Enabled = false;
            }
            countdownLBL.Location = new Point(ball.Location.X, countdownLBL.Location.Y);
            countdownLBL.Text = counter.ToString();

        }        
    }
}
