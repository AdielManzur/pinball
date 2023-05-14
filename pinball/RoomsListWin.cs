using pinballServer.ConnectionClasses;
using pinballServer.GamesClasses;
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
    public partial class RoomsListWin : Form
    {
        public ClientMainWin main;
        public List<RoomModel> rooms;
        public RoomsListWin(ClientMainWin main, List<RoomModel> rooms)
        {
            InitializeComponent();
            this.main = main;
            this.rooms = rooms;
        }
  
        private void RoomsList_Load(object sender, EventArgs e)
        {
            updatelbxRooms(rooms);
        }
        
        public void updatelbxRooms(List<RoomModel> rooms)
        {
            if(rooms == null)
            {
                MessageBox.Show("There are no open games");
                return;
            }
                foreach (RoomModel p in rooms)
            {
                this.Invoke((MethodInvoker)delegate {
                    lbxRooms.Items.Add(p.name);
                });
            }
           
        }

        private void LbxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageModel msgToSend = new MessageModel();
            string roomName = lbxRooms.SelectedItem as string;
            msgToSend.player = main.connectionManager.currPlayer;
            msgToSend.msgType = ProtocolInterface.MsgType.JOIN_ROOM;
            msgToSend.msgStr = roomName;
            main.sendMessageToServer(msgToSend);
        }
    }
}
