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
                case ProtocolInterface.MsgType.SIGN_OUT:
                    handleSignOut(message);
                    break;
                case ProtocolInterface.MsgType.ALREADY_ONLINE:
                    handleAlreadyOnline(message);
                    break;
                case ProtocolInterface.MsgType.LIST_OPEN_ROOMS_OK:
                    handleOpenListRoomsOk(message);
                    break;
                case ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM_OK:
                    handleOpenRoomOk(message);
                    break;
                case ProtocolInterface.MsgType.OPEN_GAME:
                    handleOpenGame(message);
                    break;
                case ProtocolInterface.MsgType.KEY_G:
                    handleKeyPressed(message);
                    break;
                case ProtocolInterface.MsgType.KEY_T:
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
                case ProtocolInterface.MsgType.FirstBallMovement:
                    handleTxtAndBallMovement(message);
                    break;
                case ProtocolInterface.MsgType.ROOM_REMOVED:
                    handleRoomRemoved(message);
                    break;
                case ProtocolInterface.MsgType.ROOM_IS_FULL:
                    handleRoomIsFull(message);
                    break;
                case ProtocolInterface.MsgType.LEAVE_GAME:
                    handleLeaveGame(message);
                    break;
                case ProtocolInterface.MsgType.GOAL:
                    handleGoal(message);
                    break;

            }

        }

        private void handleGoal(MessageModel message)
        {
            manager.main.handleGoal(message);
        }

        private void handleLeaveGame(MessageModel message)
        {
            manager.main.leaveGame();
        }

        private void handleRoomIsFull(MessageModel message)
        {
            manager.main.roomIsFull(message);
        }

        private void handleRoomRemoved(MessageModel message)
        {
            manager.main.roomRemoved(message);
        }

        private void handleSignOut(MessageModel message)
        {
            manager.main.signOut();
            isReg = false;
            isLog = false;
        }

        private void handleAlreadyOnline(MessageModel message)
        {
            MessageBox.Show("User already online");
        }

        private void handleTxtAndBallMovement(MessageModel message)
        {            
            manager.firstBallMovement(message);
        }

        private void handleUpdateRooms(MessageModel message)
        {
            manager.updatelbxRooms(message.rooms);
        }

        private void handleKeyPressed(MessageModel message)
        {

            manager.HandeKeyPress(message.MsgType);
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

            manager.currPlayer = message.player;
            manager.main.isLogined = true;
            manager.main.openChoiceWin();
           
            
        }

        private void handleRegisterError(MessageModel message)
        {
            MessageBox.Show("registration failed, user already exist");
        }

        private void handleRegisterOk(MessageModel message)
        {
            //manager.main.DisableRegBtn();
            manager.main.isLogined = true;
            manager.currPlayer = message.player;
            manager.main.updateMenuBTNs();
            manager.main.openChoiceWin();

        }

        public bool isLogined()
        {
            return isLog;
        }


    }
}
