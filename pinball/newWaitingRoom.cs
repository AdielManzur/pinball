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

        private void NewWaitingRoom_Load(object sender, EventArgs e)
        {
            waitingLBL.Text = "waiting for player";
            waitingLBL.Left = (this.ClientSize.Width - waitingLBL.Width) / 2;
            loadGif.Left = (this.ClientSize.Width - loadGif.Width) / 2;
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
