using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
                current = new game(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                mainPanel.Controls.Add(current);
                current.Show();
                updateMenuBTNs();
            });
        }

        public void sendLoginToServer(string userName, string pass)
        {
            if (connectionManager.isClientConnected())
            {
                MessageModel message = new MessageModel();
                //message.MsgType = ProtocolInterface.MsgType.MSG_LOGIN;
                message.userName = userName;
                message.pass = pass;
                message.msgStr = "";
                message.player = null;
                connectionManager.sendMessageToServer(message);
            }
            isLogined = clientHandle.isLogined();
        }
       /* public void sendJoinToServer(string userName, string pass)
        {
            if (connectionManager.isClientConnected())
            {
                MessageModel message = new MessageModel();
                message.MsgType = ProtocolInterface.MsgType.MSG_JOIN_GAME;
                message.userName = userName;
                message.pass = pass;
                message.msgStr = "";
                
                connectionManager.sendMessageToServer(message);
            }
        } */
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


    }   
}
