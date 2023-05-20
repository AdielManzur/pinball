﻿using pinballServer.ConnectionClasses;
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

        public RoomsListWin(ClientMainWin main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void RoomsList_Load(object sender, EventArgs e)
        {
            updatelbxRooms(rooms);
        }
        
        public void updatelbxRooms(List<RoomModel> rooms)
        {
            if(rooms.Count == 0)
            {
                MessageBox.Show("There are no open games");
                return;
            }          
            bool isExsist = false;
            foreach (RoomModel p in rooms)
            {
                for (int i = 0; i < lbxRooms.Items.Count; i++)
                {
                    if(lbxRooms.Items[i].ToString() ==  p.name)
                    {
                        isExsist = true;
                    }
                }
                if (!isExsist)
                {
                    lbxRooms.Items.Add(p.name);
                }
            }
            lbxRooms.Update();
            lbxRooms.Refresh();
          
        }

        public void LbxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageModel msgToSend = new MessageModel();
            string roomName = lbxRooms.SelectedItem as string;
            msgToSend.player = main.connectionManager.currPlayer;
            msgToSend.MsgType = ProtocolInterface.MsgType.JOIN_ROOM;
            msgToSend.msgStr = roomName;
            main.sendMessageToServer(msgToSend);
        }
       
        private void rjButton1_Click(object sender, EventArgs e)
        {
            MessageModel message = new MessageModel();
            message.MsgType = ProtocolInterface.MsgType.UPDATE_OPEN_ROOMS;
            message.player = main.connectionManager.currPlayer;
            main.connectionManager.sendMessageToServer(message);
        }
        
    }
}
