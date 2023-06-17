using pinballServer.GamesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
            switch (message.MsgType)
            {
                case ProtocolInterface.MsgType.MSG_LOGIN:
                    handleLogin(message, connected);
                    break;
                case ProtocolInterface.MsgType.MSG_REGISTER:
                    handleRegister(message, connected);
                    break;
                case ProtocolInterface.MsgType.SIGN_OUT:
                    handleSignOut(message, connected);
                    break;
                case ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM:
                    handleOpenNewWaitingRoom(message, connected);
                    break;
                case ProtocolInterface.MsgType.LIST_OPEN_ROOMS:
                    handleOpenListRooms(message, connected);
                    break;
                case ProtocolInterface.MsgType.JOIN_ROOM:
                    handleJoinRoom(message, connected);
                    break;
                case ProtocolInterface.MsgType.UPDATE_OPEN_ROOMS:
                    handleUpdateRooms(message, connected);
                    break;
                case ProtocolInterface.MsgType.KEY_G:
                    handleKeyG(message, connected);
                    break;
                case ProtocolInterface.MsgType.KEY_S:
                    handleKeyS(message, connected);
                    break;
                case ProtocolInterface.MsgType.KEY_W:
                    handleKeyW(message, connected);
                    break;
                case ProtocolInterface.MsgType.KEY_T:
                    handleKeyT(message, connected);
                    break;
                case ProtocolInterface.MsgType.REMOVE_ROOM:
                    handleRemoveRoom(message, connected);
                    break;
                case ProtocolInterface.MsgType.GOAL_TO_RIGHT:
                    handleMoveBall(message, connected);
                    break;
                case ProtocolInterface.MsgType.GOAL_TO_LEFT:
                    handleMoveBall(message, connected);
                    break;
                case ProtocolInterface.MsgType.playrLeft:
                    handlePlayerLeft(message, connected);
                    break;
                

            }
           
        }
        
        private void handlePlayerLeft(MessageModel message, ConnectedPlayer connected)
        {
        
            manager.main.gameManager.handlePlayerLeft(message, connected);
        }

        private void handleMoveBall(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleMoveBall(message, connected);
        }

        private void handleRemoveRoom(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleRemoveRoom(message, connected);
        }

        private void handleSignOut(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleSignOut(message, connected);

        }

        private void handleUpdateRooms(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleUpdateRooms(message, connected);
        }

        private void handleKeyT(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleKeyT(message, connected);


        }
        private void handleKeyG(MessageModel message, ConnectedPlayer connected)
        {
           
            manager.main.gameManager.handleKeyG(message, connected);

        }

        //key G and Key T are for player 1
        private void handleKeyW(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleKeyW(message, connected);

        }
        private void handleKeyS(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleKeyS(message, connected);

        }

        // key W and key S are for player 2

        private void handleJoinRoom(MessageModel message, ConnectedPlayer connected)
        { 
        
            manager.main.gameManager.handleJoin(message, connected);
        }
        


        private void handleOpenListRooms(MessageModel message, ConnectedPlayer connected)
        {
          
            manager.main.gameManager.handleOpenListRooms(message, connected);
        }

        private void handleOpenNewWaitingRoom(MessageModel message, ConnectedPlayer connected)
        {
            
            manager.main.gameManager.handleOpenNewWaitingRoom(message, connected);
        }

       
        public void handleLogin(MessageModel message, ConnectedPlayer connected)
        {
            
            if (manager.players != null )
            {
                foreach (ConnectedPlayer connected1 in manager.players)
                {
                    if (connected1.player != null)
                    {
                        if (connected1.player.username == message.userName)
                        {
                            MessageModel msg = new MessageModel();
                            msg.MsgType = ProtocolInterface.MsgType.ALREADY_ONLINE;
                            msg.player = message.player;
                            manager.sendMessageToClient(connected, msg);
                            return;
                        }
                    }
                }
            }            
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
                    mToSend.MsgType = ProtocolInterface.MsgType.LOGIN_OK;
                    connected.player = playerS;
                    manager.sendMessageToClient(connected, mToSend);


                }
                else // wrong password
                {

                    MessageModel mToSend = new MessageModel();
                    mToSend.player = null;
                    mToSend.MsgType = ProtocolInterface.MsgType.LOGIN_ERROR;
                    mToSend.msgStr = "Wrong password";
                    connected.player = null;
                    manager.sendMessageToClient(connected, mToSend);
                }
            }
            else // player == null
            {
                MessageModel mToSend = new MessageModel();
                mToSend.player = null;
                mToSend.MsgType = ProtocolInterface.MsgType.LOGIN_ERROR;
                mToSend.msgStr = "No User in DB";
                connected.player = null;
                manager.sendMessageToClient(connected, mToSend);
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
                mToSend.MsgType = ProtocolInterface.MsgType.REGISTER_ERROR;
                mToSend.msgStr = "username already exists in DB";
                connected.player = null;
                manager.sendMessageToClient(connected, mToSend);
            }
            else

            {
                playerTBL newPlayer = PlayerS.convertUserTBLFromMessage(message);
                newPlayer.regDate = DateTime.Now;
                PlayerS playerS = new PlayerS();
                playerS.convertFromUserTBL(newPlayer);
                MessageModel mToSend = new MessageModel();
                mToSend.player = playerS;
                mToSend.MsgType = ProtocolInterface.MsgType.REGISTER_OK;
                connected.player = playerS;
                db.playerTBL.Add(newPlayer);
                db.SaveChanges();
                manager.sendMessageToClient(connected, mToSend);
            }
        }
    }
}




