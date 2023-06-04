using System;
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
            gameWin = new game(this);
            RoomsListWin = new RoomsListWin(this);
            updateMenuBTNs();
            connectToServer();
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
            current = new ClientLoginWin(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, Size = mainPanel.Size };
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
                current = new RoomsListWin(this,rooms) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, Size = mainPanel.Size };
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
                current = new newWaitingRoom(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, Size = mainPanel.Size };
                mainPanel.Controls.Add(current);
                current.Show();
                updateMenuBTNs();
            });
        }

        public void roomIsFull(MessageModel message)
        {
            if(current is RoomsListWin)
            {
                updateRoomsLbx(message);
            }
        }

        public void roomRemoved(MessageModel message)
        {
           if(current is RoomsListWin)
            {
                updateRoomsLbx(message);
            }
        }

        public void handleGoal(MessageModel message)
        {
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate
                {
                    tmp.hadGoal(message);
                });
            }
        }

        public void disableLeaveBtn()
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnLeaveGame.Visible = false;
            });
        }

        public void leaveGame()
        {
            btnLeaveGame.Enabled = false;
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate
                {
                    tmp.enemyLeft();
                });
            }
        }

        private void updateRoomsLbx(MessageModel message)
        {
            if (current is RoomsListWin)
            {
                RoomsListWin tmp = (RoomsListWin)current;
                tmp.updatelbxRooms(message,message.rooms);
            }
        }

        public void backButtonPressed()
        {
            if(current is RoomsListWin)
            {
                openChoiceWin();
            }
            if(current is newWaitingRoom)
            {
                removeThisOpendRoom();
                openChoiceWin();
            }
        }

        public void signOut()
        {
            this.Invoke((MethodInvoker)delegate {
                mainPanel.Controls.Clear();         
                isLogined = false;               
                updateMenuBTNs();
            });
        }
        
        public void updateRoomsLbx(List<RoomModel> rooms)
        {
            if (current is RoomsListWin)
            {
                RoomsListWin tmp = (RoomsListWin)current;
                tmp.updatelbxRooms(rooms);
            }
        }

        public void firstBallMovement(MessageModel message)
        {
            if (current is game)
            {
                game tmp = (game)current;
                this.Invoke((MethodInvoker)delegate
                {
                    tmp.firstBallMovement(message);
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
            current = new registerWin(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, Size = mainPanel.Size };
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
                current = new choiceWin(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, Size = mainPanel.Size };
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

                current = new game(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
                mainPanel.Controls.Add(current);
                current.Show();
                btnLeaveGame.Visible = true;
                updateMenuBTNs();
                btnSignOut.Enabled = false;
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

        private void connectToServer()
        {
            isConnected = connectionManager.connectToServer();
            updateMenuBTNs();
            if (!isConnected)
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
                btnSignOut.Enabled = !btnRegister.Enabled || !btnLogin.Enabled;
            });
        
        }


        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if(current is newWaitingRoom)
            {
                removeThisOpendRoom();
            }
            btnLeaveGame.Visible = false;
            MessageModel signOutMsg = new MessageModel();
            signOutMsg.MsgType = ProtocolInterface.MsgType.SIGN_OUT;
            signOutMsg.player = connectionManager.currPlayer;
            sendMessageToServer(signOutMsg);
        }
        private void removeThisOpendRoom()
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.REMOVE_ROOM;
            msg.player = connectionManager.currPlayer;
            sendMessageToServer(msg);
        }

        private void btnLeaveGame_Click(object sender, EventArgs e)
        {
            MessageModel leaveMsg = new MessageModel();
            leaveMsg.MsgType = ProtocolInterface.MsgType.playrLeft;
            leaveMsg.player = connectionManager.currPlayer;
            sendMessageToServer(leaveMsg);
            openChoiceWin();
        }


    }   
}
