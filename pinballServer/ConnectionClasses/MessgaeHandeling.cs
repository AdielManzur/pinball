using pinballServer.GamesClasses;
using System;
using System.Linq;

namespace pinballServer.ConnectionClasses
{
    public class MessgaeHandeling
    {
        dbEntities db = new dbEntities();
        ConnectionManager manager;
    
        
        public MessgaeHandeling(ConnectionManager manager)
        {
            this.manager = manager;
        }
        public void handleMessage(MessageModel message, ConnectedPlayer connected)
        {
            switch (message.msgType)
            {
                case ProtocolInterface.MsgType.MSG_LOGIN:
                    handleLogin(message, connected);
                    break;
                case ProtocolInterface.MsgType.MSG_REGISTER:
                    handleRegister(message, connected);
                    break;
                case ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM:
                    handleOpenNewWaitingRoom(message, connected);
                    break;
                case ProtocolInterface.MsgType.LIST_OPEN_ROOMS:
                    handleOpenListRooms(message, connected);
                    break;

            }
        }

        private void handleOpenListRooms(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.msgType = ProtocolInterface.MsgType.LIST_OPEN_ROOMS_OK;
            msg.player = message.player;
            manager.sendMessageToClient(connected, msg);
        }

        private void handleOpenNewWaitingRoom(MessageModel message, ConnectedPlayer connected)
        {
            RoomModel room = new RoomModel();
            room.name = message.player.username;
            room.player1 = message.player;
            manager.main.gameManager.rooms.Add(room);
            MessageModel msg = new MessageModel();
            msg.msgType = ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM_OK;
            manager.sendMessageToClient(connected,message);
          
        }

       
        public void handleLogin(MessageModel message, ConnectedPlayer conncted)
        {
            string userName = message.userName;
            playerTBL player = (from s in db.playerTBL where s.username == userName select s).FirstOrDefault();
            if (player != null)
            {
                if (player.password == message.pass)
                {
                    PlayerS playerS = new PlayerS();
                    playerS.convertFromUserTBL(player);
                    MessageModel mToSend = new MessageModel();
                    mToSend.player = playerS;
                    mToSend.msgType = ProtocolInterface.MsgType.LOGIN_OK;
                    conncted.player = playerS;
                    manager.sendMessageToClient(conncted, mToSend);


                }
                else // wrong password
                {

                    MessageModel mToSend = new MessageModel();
                    mToSend.player = null;
                    mToSend.msgType = ProtocolInterface.MsgType.LOGIN_ERROR;
                    mToSend.msgStr = "Wrong password";
                    conncted.player = null;
                    manager.sendMessageToClient(conncted, mToSend);
                }
            }
            else // player == null
            {
                MessageModel mToSend = new MessageModel();
                mToSend.player = null;
                mToSend.msgType = ProtocolInterface.MsgType.LOGIN_ERROR;
                mToSend.msgStr = "No User in DB";
                conncted.player = null;
                manager.sendMessageToClient(conncted, mToSend);
            }

        }
        public void handleRegister(MessageModel message, ConnectedPlayer connected)
        {
            string userName = message.player.username;
            playerTBL player = (from s in db.playerTBL where s.username == userName select s).FirstOrDefault();
            if (player != null)
            {// error duplicated username
                MessageModel mToSend = new MessageModel();
                mToSend.player = null;
                mToSend.msgType = ProtocolInterface.MsgType.REGISTER_ERROR;
                mToSend.msgStr = "username already exists in DB";
                connected.player = null;
                manager.sendMessageToClient(connected, mToSend);
            }
            else
            {
                playerTBL newPlayer = PlayerS.convertUserTBLFromMessage(message);
                newPlayer.registerDate = DateTime.Now;
                PlayerS playerS = new PlayerS();
                playerS.convertFromUserTBL(newPlayer);

                MessageModel mToSend = new MessageModel();
                mToSend.player = playerS;
                mToSend.msgType = ProtocolInterface.MsgType.REGISTER_OK;
                db.playerTBL.Add(newPlayer);
                db.SaveChanges();
                manager.sendMessageToClient(connected, mToSend);
            }
        }
    }
}




