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
        public newWaitingRoom(ClientMainWin main)
        {
            InitializeComponent();
            this.main = main;

        }

        private void NewWaitingRoom_Load(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            main.backButtonPressed();
        }
    }
}
