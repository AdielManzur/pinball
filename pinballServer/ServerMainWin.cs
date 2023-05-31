using pinballServer.ConnectionClasses;
using pinballServer.GamesClasses;
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

namespace pinballServer
{
    public partial class ServerMainWin : Form
    {
        public ConnectionManager manager;
        public serverGameManager gameManager;

        public ServerMainWin()
        {
            InitializeComponent();
        }

        private void ServerMainWin_Load(object sender, EventArgs e)
        {
            manager = new ConnectionManager(this);
            gameManager = new serverGameManager(this);
            startServer();


        }

        
        private void updateIcon()
        {
            if (manager.isListening())
            {
                pictureBox1.BackColor = Color.Green;
            }
            else
            {
                pictureBox1.BackColor = Color.Red;
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            manager.stopServer();
            updateIcon();
            btnStopServer.Enabled = false;
            btnStartServer.Enabled = true;

        }
        private void startServer()
        {
            manager.StartServer();
            updateIcon();
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
        }

        public void updateConnectedClients(List<string> lst)
        {
            gameManager.updatePlayersList();
            this.Invoke((MethodInvoker)delegate {
                lbxConnectedClients.Items.Clear();
                foreach (string str in lst)
                {
                    lbxConnectedClients.Items.Add(str);
                }
            });

        }
        private void lbxConnectedClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LbxConnectedClients_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            manager.StartServer();
            updateIcon();
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
        }
    }
}

