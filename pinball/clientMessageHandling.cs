﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pinballServer;
using System.Windows.Forms;
using pinballServer.ConnectionClasses;

namespace pinball
{
    public class clientMessageHandling
    {
       
        clientConnectionManager manager;
        bool isReg = false;
        bool isLog = false;
        public clientMessageHandling(clientConnectionManager manager)
        {
            this.manager = manager;
        }
        public void handleMessage(MessageModel message)
        {
            switch (message.msgType)
            {
                case ProtocolInterface.MsgType.REGISTER_OK:
                    handleRegisterOk(message);
                    break;
                case ProtocolInterface.MsgType.REGISTER_ERROR:
                    handleRegisterError(message);
                    break;
                case ProtocolInterface.MsgType.LOGIN_OK:
                    handleLoginOk(message);
                    break;
                case ProtocolInterface.MsgType.LOGIN_ERROR:
                    handleLoginError(message);
                    break;
                case ProtocolInterface.MsgType.JOIN_GAME_OK:
                    handleJoinOk(message);
                    break;
                case ProtocolInterface.MsgType.LIST_OPEN_ROOMS_OK:
                    handleOpenListRoomsOk(message);
                    break;


            }
        }

        private void handleOpenListRoomsOk(MessageModel message)
        {
            manager.main.openRoomsListWin();
            
        }

        private void handleOpenRoomOk(MessageModel message)
        {
            MessageBox.Show("waiting for another player");
        }

        private void handleJoinOk(MessageModel message)
        {

            MessageBox.Show("waiting for another player");

           

        }

        private void handleLoginError(MessageModel message)
        {
            MessageBox.Show("password or username are not correct");
        }

        private void handleLoginOk(MessageModel message)
        {
            MessageBox.Show("connected");
            manager.currPlayer = message.player;
            manager.main.isLogined = true;
            manager.main.openGameWin();
            manager.main.sendJoinToServer(message.userName, message.pass);
            
        }

        private void handleRegisterError(MessageModel message)
        {
            MessageBox.Show("registration failed, user already exist");
        }

        private void handleRegisterOk(MessageModel message)
        {
            MessageBox.Show("registration completed");
            manager.main.isLogined = true;
            manager.main.updateMenuBTNs();
            manager.main.openGameWin();
            manager.main.sendJoinToServer(message.userName, message.pass);
        }

        public bool isLogined()
        {
            return isLog;
        }

        public bool isRegistered()
        {
            return isReg;
        }
    }
}
