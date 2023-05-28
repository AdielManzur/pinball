using pinballServer.GamesClasses;
using System;
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
                case ProtocolInterface.MsgType.COLLISION_LOWER_OR_UPPER_WALL:
                    handleCollisionUpperLowerWall(message, connected);
                    break;



            }
           
        }



        private void handleCollisionUpperLowerWall(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            Vector2 returnVector = new Vector2(message.BallVector.X, -message.BallVector.Y);
            msg.MsgType = ProtocolInterface.MsgType.COLLISION_LOWER_OR_UPPER_WALL;
            foreach(ConnectedPlayer connectedPlayer in manager.players)
            {
                if(manager.currGame.player1.username == connectedPlayer.player.username || manager.currGame.player2.username == connectedPlayer.player.username)
                {
                    manager.sendMessageToClient(connectedPlayer, msg);
                }
            }
        }

        private void handleUpdateRooms(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.UPDATE_OPEN_ROOMS;
            msg.player = message.player;
            msg.rooms = manager.main.gameManager.rooms;
            manager.sendMessageToClient(connected, msg);
        }

        private void handleKeyT(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_T;
            if (message.player.username == manager.currGame.player1.username)
            {
                manager.sendMessageToClient(connected, msg);
                foreach (ConnectedPlayer connected1 in manager.main.gameManager.players)
                {
                    if (connected1.player.username == manager.currGame.player2.username)
                    {
                        manager.sendMessageToClient(connected1, msg);
                    }
                }
            }


        }
        private void handleKeyG(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_G;
            if (message.player.username == manager.currGame.player1.username)
            {
                manager.sendMessageToClient(connected, msg);
                foreach(ConnectedPlayer connected1 in manager.main.gameManager.players)
                {
                    if(connected1.player.username == manager.currGame.player2.username)
                    {
                        manager.sendMessageToClient(connected1, msg);
                    }
                }
            }
        }

        //key G and Key T are for player 1
        private void handleKeyW(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_W;
            if (message.player.username == manager.currGame.player2.username)
            {
                manager.sendMessageToClient(connected, msg);
                foreach (ConnectedPlayer connected1 in manager.main.gameManager.players)
                {
                    if (connected1.player.username == manager.currGame.player1.username)
                    {
                        manager.sendMessageToClient(connected1, msg);
                    }
                }
            }
        }
        private void handleKeyS(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_S;
            if (message.player.username == manager.currGame.player2.username)
            {
                manager.sendMessageToClient(connected, msg);
                foreach (ConnectedPlayer connected1 in manager.main.gameManager.players)
                {
                    if (connected1.player.username == manager.currGame.player1.username)
                    {
                        manager.sendMessageToClient(connected1, msg);
                    }
                }
            }
        }

        // key W and key S are for player 2

        private void handleJoinRoom(MessageModel message, ConnectedPlayer connected)
        {
            RoomModel curr = new RoomModel();
            foreach (RoomModel room in manager.main.gameManager.rooms)
            {
                if (message.msgStr == room.name)
                {
                    room.player2 = message.player;
                    curr = room;
                }
            }
            GameModel curGame = new GameModel();
            foreach(GameModel game in manager.main.gameManager.games)
            {
                if(curr.player1.username == game.player1.username)
                {
                    curGame = game;
                }
            }
            curGame.player2 = connected.player;
            manager.currGame = curGame;
            MessageModel msgToSend = new MessageModel();
            msgToSend.MsgType = ProtocolInterface.MsgType.OPEN_GAME;
            msgToSend.game = curGame;
            manager.sendMessageToClient(connected, msgToSend);
            ConnectedPlayer player1 = new ConnectedPlayer();
            foreach (ConnectedPlayer connectedPlayer in manager.main.gameManager.players)
            {
                if(connectedPlayer.player.username == curGame.player1.username)
                {
                    player1 = connectedPlayer;
                    manager.sendMessageToClient(connectedPlayer, msgToSend);

                }
            }
            MessageModel keysMsg = new MessageModel();
            Random ballVectorX = new Random();
            Random ballVectorY = new Random();          
            Vector2 ballVector = new Vector2(ballVectorX.Next(-100,101), ballVectorY.Next(-100,101));
            ballVector = Vector2.Normalize(ballVector);
            keysMsg.MsgType = ProtocolInterface.MsgType.FirstBallMovement;
            keysMsg.msgStr = "your keys are T and G for up&down and your player is the right player";
            keysMsg.player = player1.player;
            keysMsg.BallVector = ballVector;
            manager.sendMessageToClient(player1, keysMsg);
            keysMsg.msgStr = "your keys are W and S for up&down and your player is the left player";
            keysMsg.player = connected.player;
            manager.sendMessageToClient(connected, keysMsg);


        }
        


        private void handleOpenListRooms(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.LIST_OPEN_ROOMS_OK;
            msg.player = message.player;
            msg.rooms = manager.main.gameManager.rooms;
            manager.sendMessageToClient(connected, msg);
        }

        private void handleOpenNewWaitingRoom(MessageModel message, ConnectedPlayer connected)
        {
            RoomModel room = new RoomModel();
            room.name = message.player.username;
            room.player1 = message.player;
            manager.main.gameManager.rooms.Add(room);
            GameModel newGame = new GameModel();
            newGame.player1 = connected.player;
            manager.main.gameManager.games.Add(newGame);
            manager.currGame = newGame;
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM_OK;
            manager.sendMessageToClient(connected, msg);
           
        }

       
        public void handleLogin(MessageModel message, ConnectedPlayer conncted)
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
                            manager.sendMessageToClient(conncted, msg);
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
                    conncted.player = playerS;
                    manager.sendMessageToClient(conncted, mToSend);


                }
                else // wrong password
                {

                    MessageModel mToSend = new MessageModel();
                    mToSend.player = null;
                    mToSend.MsgType = ProtocolInterface.MsgType.LOGIN_ERROR;
                    mToSend.msgStr = "Wrong password";
                    conncted.player = null;
                    manager.sendMessageToClient(conncted, mToSend);
                }
            }
            else // player == null
            {
                MessageModel mToSend = new MessageModel();
                mToSend.player = null;
                mToSend.MsgType = ProtocolInterface.MsgType.LOGIN_ERROR;
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




