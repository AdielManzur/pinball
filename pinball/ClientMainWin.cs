﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pinballServer;
using pinballServer.ConnectionClasses;
using pinballServer.GamesClasses;

namespace pinball
{

    public partial class ClientMainWin : Form
    {
        public Form current;
        public clientConnectionManager connectionManager;
        public clientMessageHandling clientHandle;
        public game gameWin;
        public RoomsListWin RoomsListWin;
        
        public bool isConnected;
        public bool isLogined;
        public ClientMainWin()
        {

            InitializeComponent();
        }



        private void ClientMainWin_Load(object sender, EventArgs e)
        {
            current = null;
            isConnected = false;
            isLogined = false;
            connectionManager = new clientConnectionManager(this);
            clientHandle = new clientMessageHandling(connectionManager);
            gameWin = new game(this, mainPanel.Height, mainPanel.Width);
            RoomsListWin = new RoomsListWin(this);
            updateMenuBTNs();
        }
        public void openLoginWin(object sender, EventArgs e)
        {
            if (current != null)
            {
                if (current is ClientLoginWin)
                {
                    return;
                }
                current.Close();
            }
            current = new ClientLoginWin(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            mainPanel.Controls.Add(current);
            current.Show();
            updateMenuBTNs();

        }



        public void UpdateOpenRooms(List<RoomModel> rooms)
        {
            this.Invoke((MethodInvoker)delegate {
                if (current != null)
                {
                    if (current is RoomsListWin)
                    {
                        return;
                    }
                    current.Close();
                }
                current = new RoomsListWin(this,rooms) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                mainPanel.Controls.Add(current);
                current.Show();
                updateMenuBTNs();
            });
        }

        public void opennewWaitingRoom()
        {
            this.Invoke((MethodInvoker)delegate {
                if (current != null)
                {
                    if (current is newWaitingRoom)
                    {
                        return;
                    }
                    current.Close();
                }
                current = new newWaitingRoom(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                mainPanel.Controls.Add(current);
                current.Show();
                updateMenuBTNs();
            });
        }

        public void collisionWithUpperOrLowerWall(Vector2 ballVector)
        {
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate
                {
                    tmp.collisionWithUpperOrLowerWall(ballVector);
                });
            }
        }

        public void GoalLeftWall(MessageModel message)
        {
            String scorePlayer2 = message.scorePlayer2.ToString();
            String scorePlayer1 = message.scorePlayer1.ToString();

            if (message.player == message.game.player1)
            {
                scoreLBL.Text = "your score: " + scorePlayer1 + "enemy score: " + scorePlayer2;
            }
            else
            {
                scoreLBL.Text = "your score: " + scorePlayer2 + "enemy score: " + scorePlayer1;
            }
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate {
                    tmp.scoreRightPlayer = message.scorePlayer1;
                    tmp.scoreLeftPlayer = message.scorePlayer2;
                    tmp.StopTimer();
                });
            }
        }

        public void GoalRightWall(MessageModel message)
        {

            String scorePlayer2 = message.scorePlayer2.ToString();
            String scorePlayer1 = message.scorePlayer1.ToString();

            if (message.player == message.game.player2)
            {
                scoreLBL.Text = "your score: " + scorePlayer2 + "enemy score: "+scorePlayer1;
            }
            else
            {
                scoreLBL.Text = "your score: " + scorePlayer1 + "enemy score: " + scorePlayer2;
            }
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate {
                    tmp.scoreRightPlayer = message.scorePlayer1;
                    tmp.scoreLeftPlayer = message.scorePlayer2;
                    tmp.StopTimer();
                });
            }
        }

        public void updateRoomsLbx(List<RoomModel> rooms)
        {
            if (current is RoomsListWin)
            {
                RoomsListWin tmp = (RoomsListWin)current;
                tmp.updatelbxRooms(rooms);
            }
        }

        public void firstBallMovement(Vector2 ballVector)
        {
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate
                {
                    tmp.firstBallMovement(ballVector);
                });
            }
        }

        public void KeysLbl(MessageModel message)
        {
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate
                {
                    playerLabel.Text = message.msgStr;
                    playerLabel.Location = new Point((int)((this.Width - playerLabel.Width) / 2), playerLabel.Location.Y);
                    playerNameLbl.Text = "Your name: " + message.player.username;
                    scoreLBL.Text = "your score: 0 , enemy score: 0";
                    scoreLBL.Top =  playerNameLbl.Location.Y;

                });
            }
        }

        public void handleKeyPress(ProtocolInterface.MsgType msgType)
        {
            if (current is game)
            {
                 game tmp = (game)current;
                tmp.MykeyPressed(msgType);
            }
           
        }

        public void openRegWin(object sender, EventArgs e)
        {
            if (current != null)
            {
                if (current is registerWin)
                {
                    return;
                }
                current.Close();
            }
            current = new registerWin(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            mainPanel.Controls.Add(current);
            current.Show();
            updateMenuBTNs();
        }

    
        public void openChoiceWin()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (current != null)
                {
                    if (current is choiceWin)
                    {
                        return;
                    }
                    current.Close();
                }
                current = new choiceWin(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                mainPanel.Controls.Add(current);
                current.Show();
                updateMenuBTNs();
            });
        }

        public void openGameWin()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (current != null)
                {
                    if (current is game)
                    {
                        return;
                    }
                    current.Close();
                }

                current = new game(this, mainPanel.Height,mainPanel.Width) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                mainPanel.Controls.Add(current);
                current.Show();
                updateMenuBTNs();
                mainPanel.Height -= 36;
                mainPanel.Location = new Point(0, mainPanel.Location.Y + 35);

            });

        }

        public void sendLoginToServer(string userName, string pass)
        {
            if (connectionManager.isClientConnected())
            {
                MessageModel message = new MessageModel();
                message.MsgType = ProtocolInterface.MsgType.MSG_LOGIN;
                message.userName = userName;
                message.pass = pass;
                //message.msgStr = "";
                //message.player = null;
                connectionManager.sendMessageToServer(message);
            }
            isLogined = clientHandle.isLogined();
        }
       
        private void connectToServer(object sender, EventArgs e)
        {
            isConnected = connectionManager.connectToServer();
            updateMenuBTNs();
            if (isConnected)
                MessageBox.Show("Connected");
            else
                MessageBox.Show("Connection failed");
        }
        public void sendMessageToServer(MessageModel message)
        {
            connectionManager.sendMessageToServer(message);
        }

        public void updateMenuBTNs()
        {
            this.Invoke((MethodInvoker)delegate{
                btnConnectToServer.Enabled = !isConnected;
                btnLogin.Enabled = isConnected && !isLogined;
                btnRegister.Enabled = isConnected && !isLogined;
            });
        
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }   
}
