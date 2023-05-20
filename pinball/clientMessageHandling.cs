using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pinballServer;
using System.Windows.Forms;
using pinballServer.ConnectionClasses;
using pinball;

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
            switch (message.MsgType)
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
                /*    case ProtocolInterface.MsgType.JOIN_GAME_OK:
                    handleJoinOk(message);
                    break;
                    */
                case ProtocolInterface.MsgType.LIST_OPEN_ROOMS_OK:
                    handleOpenListRoomsOk(message);
                    break;
                case ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM_OK:
                    handleOpenRoomOk(message);
                    break;
                case ProtocolInterface.MsgType.OPEN_GAME:
                    handleOpenGame(message);
                    break;
                case ProtocolInterface.MsgType.DOWN:
                    handleKeyPressed(message);
                    break;
                case ProtocolInterface.MsgType.UP:
                    handleKeyPressed(message);
                    break;
                case ProtocolInterface.MsgType.KEY_S:
                    handleKeyPressed(message);
                    break;
                case ProtocolInterface.MsgType.KEY_W:
                    handleKeyPressed(message);
                    break;
                case ProtocolInterface.MsgType.UPDATE_OPEN_ROOMS:
                    handleUpdateRooms(message);
                    break;

            }

        }

        private void handleUpdateRooms(MessageModel message)
        {
            manager.main.RoomsListWin.updatelbxRooms(message.rooms);
        }

        private void handleKeyPressed(MessageModel message)
        {

            manager.main.gameWin.keyPressed(message.MsgType);
        }

        private void handleOpenGame(MessageModel message)
        {
            manager.main.openGameWin();
        }

       
        private void handleOpenListRoomsOk(MessageModel message)
        {
            manager.main.UpdateOpenRooms(message.rooms);
        }

        private void handleOpenRoomOk(MessageModel message)
        {
            manager.main.opennewWaitingRoom();


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
            manager.main.openChoiceWin();
           // manager.main.sendJoinToServer(message.userName, message.pass);
            
        }

        private void handleRegisterError(MessageModel message)
        {
            MessageBox.Show("registration failed, user already exist");
        }

        private void handleRegisterOk(MessageModel message)
        {
            MessageBox.Show("registration completed");
            manager.main.isLogined = true;
            manager.currPlayer = message.player;
            manager.main.updateMenuBTNs();
            manager.main.openChoiceWin();
            //manager.main.sendJoinToServer(message.userName, message.pass);
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
