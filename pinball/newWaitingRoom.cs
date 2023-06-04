using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pinball
{
    public partial class newWaitingRoom : Form
    {
        ClientMainWin main;
        int numOfDots = 0;
        String str = ".";
        public newWaitingRoom(ClientMainWin main)
        {
            InitializeComponent();
            this.main = main;

        }

        public game game
        {
            get => default;
            set
            {
            }
        }

        private void NewWaitingRoom_Load(object sender, EventArgs e)
        {
            waitingLBL.Text = "waiting for player";
            waitingLBL.Left = (this.ClientSize.Width - waitingLBL.Width) / 2;
            loadGif.Left = (this.ClientSize.Width - loadGif.Width) / 2;
            waitingLBL.Top = (this.ClientSize.Height - waitingLBL.Height) / 2;
            loadGif.Top = ((this.ClientSize.Height - loadGif.Height) / 2 ) + loadGif.Height + 10;
            playerLBL.Text = main.connectionManager.currPlayer.username;
            playerLBL.Location = new Point(((playerPicture.Width - playerLBL.Width) / 2) + playerPicture.Left, playerLBL.Location.Y);
            if (main.connectionManager.currPlayer.profilePicture != null)
            {
                byte[] imageData = main.connectionManager.currPlayer.profilePicture;
                Image image;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }
                playerPicture.Image = image;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            main.backButtonPressed();
        }

        private void waitingTimer_Tick(object sender, EventArgs e)
        {
            waitingLBL.Text = "waiting for player" + string.Concat(Enumerable.Repeat(str, numOfDots));
            numOfDots++;
            if(numOfDots == 4)
            {
                numOfDots = 0;
            }
        }
    }
}
