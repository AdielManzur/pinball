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
    public partial class game : Form
    {
        ClientMainWin main;
        int screenHeight = 980;
        public game(ClientMainWin main)
        {

            InitializeComponent();
            this.main = main;
        }
        private void Game_Load(object sender, EventArgs e)
        {

        }


        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W && leftPlayer.Top >= 0)
            {
                    leftPlayer.Top -= 20;
            }
            if (e.KeyCode == Keys.T && rightPlayer.Top >= 0)
            {
                    rightPlayer.Top -= 20;
            }
            if (e.KeyCode == Keys.S && leftPlayer.Top + leftPlayer.Height <= screenHeight)    
            {
                    leftPlayer.Top += 20;
            }
            if (e.KeyCode == Keys.G && rightPlayer.Top + rightPlayer.Height <= screenHeight)
            {
             
                    rightPlayer.Top += 20;
            }
        }

        
    }
}
