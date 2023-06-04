using pinballServer.ConnectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace pinballServer.GamesClasses
{
    public class serverGameManager
    {
        public ServerMainWin main;
        public List<GameModel> games { get; set; }
        public List<ConnectedPlayer> players { get; set; }
        public List<RoomModel> rooms { get; set; }
        public serverGameManager(ServerMainWin main)
        {
            this.main = main;
            games = new List<GameModel>();
            rooms = new List<RoomModel>();

        }
        public void updatePlayersList()
        {
            players = main.manager.players;
        }

        public GameModel getGameByString(String gameName)
        {
            GameModel result = new GameModel();
            foreach(GameModel game in games)
            {
                if(gameName == game.gameName)
                {
                    result = game;
                }
            }
            return result;
        }

        public void handleOpenNewWaitingRoom(MessageModel message, ConnectedPlayer connected)
        {
            RoomModel room = new RoomModel();
            room.name = message.player.username;
            room.player1 = message.player;
            rooms.Add(room);
            GameModel newGame = new GameModel();
            newGame.player1 = connected.player;
            newGame.gameName = connected.player.username;
            games.Add(newGame);
            connected.player.currGameName = newGame.gameName;
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.OPEN_NEW_WAITING_ROOM_OK;
            main.manager.sendMessageToClient(connected, msg);
        }

        public void handleOpenListRooms(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.LIST_OPEN_ROOMS_OK;
            msg.player = message.player;
            msg.rooms = rooms;
            main.manager.sendMessageToClient(connected, msg);
        }

        public void handleJoin(MessageModel message, ConnectedPlayer connected)
        {
            RoomModel curr = new RoomModel();
            foreach (RoomModel room in rooms)
            {
                if (message.msgStr == room.name)
                {
                    room.player2 = message.player;
                    curr = room;
                }
            }
            GameModel curGame = new GameModel();
            foreach (GameModel game in games)
            {
                if (curr.player1.username == game.player1.username)
                {
                    curGame = game;
                }
            }
            curGame.player2 = connected.player;
            //manager.currGame = curGame;
            connected.player.currGameName = curGame.gameName;
            MessageModel msgToSend = new MessageModel();
            msgToSend.MsgType = ProtocolInterface.MsgType.OPEN_GAME;
            msgToSend.game = curGame;
            main.manager.sendMessageToClient(connected, msgToSend);
            ConnectedPlayer player1 = new ConnectedPlayer();
            foreach (ConnectedPlayer connectedPlayer in players)
            {
                if (connectedPlayer.player.username == curGame.player1.username)
                {
                    player1 = connectedPlayer;
                    main.manager.sendMessageToClient(connectedPlayer, msgToSend);

                }
            }
            MessageModel keysMsg = new MessageModel();
            Random ballVectorX = new Random();
            Random ballVectorY = new Random();
            Vector2 ballVector = new Vector2(ballVectorX.Next(-100, 101), ballVectorY.Next(-100, 101));
            //ballVector = Vector2.Normalize(ballVector);
            keysMsg.MsgType = ProtocolInterface.MsgType.FirstBallMovement;
            keysMsg.msgStr = "your keys are T and G for up&down and your player is the right player";
            keysMsg.player = player1.player;
            keysMsg.BallVector = ballVector;
            keysMsg.game = curGame;
            main.manager.sendMessageToClient(player1, keysMsg);
            keysMsg.msgStr = "your keys are W and S for up&down and your player is the left player";
            keysMsg.player = connected.player;
            main.manager.sendMessageToClient(connected, keysMsg);
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.ROOM_IS_FULL;
            main.manager.main.gameManager.rooms.Remove(curr);
            msg.msgStr = curr.name;
            msg.rooms = main.manager.main.gameManager.rooms;
            foreach (ConnectedPlayer player in players)
            {
                if (player.player.username != curr.player1.username && player.player.username != curr.player2.username)
                    main.manager.sendMessageToClient(player, msg);
            }
        }

        public void handlePlayerLeft(MessageModel message, ConnectedPlayer connected)
        {
            GameModel connectedCurrGame = getGameByString(connected.player.currGameName);
            List<GameModel> gamesToRemove = new List<GameModel>();
            connected.player.currGameName = null;
            connectedCurrGame.player2.currGameName = null;
            foreach (GameModel gameToRemove in games)
            {
                if (connectedCurrGame == gameToRemove)
                {
                    gamesToRemove.Add(gameToRemove);
                }
            }
            foreach (GameModel gameToRemove in gamesToRemove)
            {
                games.Remove(gameToRemove);
            }
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.LEAVE_GAME;
            msg.player = connected.player;
            if (connected.player == connectedCurrGame.player1)
            {
                main.manager.SendMessageToPlayer(msg, connectedCurrGame.player2);
            }
            else if (connected.player == connectedCurrGame.player2)
            {
                main.manager.SendMessageToPlayer(msg, connectedCurrGame.player1);
            }
        }

        public void handleKeyS(MessageModel message, ConnectedPlayer connected)
        {
            GameModel currGame = new GameModel();
            currGame = getGameByString(connected.player.currGameName);
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_S;
            if (message.player.username == currGame.player2.username)
            {
                main.manager.sendMessageToClient(connected, msg);
                main.manager.SendMessageToPlayer(message, currGame.player1);
            }
        }

        public void handleKeyW(MessageModel message, ConnectedPlayer connected)
        {
            GameModel currGame = new GameModel();
            currGame = getGameByString(connected.player.currGameName);
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_W;
            if (message.player.username == currGame.player2.username)
            {
                main.manager.sendMessageToClient(connected, msg);
                main.manager.SendMessageToPlayer(msg, currGame.player1);
            }
        }

        public void handleMoveBall(MessageModel message, ConnectedPlayer connected)
        {
            GameModel currGame = new GameModel();
            currGame = getGameByString(connected.player.currGameName);
            Random ballVectorX = new Random();
            Random ballVectorY = new Random();
            Vector2 ballVector = new Vector2(ballVectorX.Next(-100, 101), ballVectorY.Next(-100, 101));
            MessageModel msg = new MessageModel();
            if (message.MsgType == ProtocolInterface.MsgType.GOAL_TO_LEFT)
            {
                msg.scoreRightPlayer = message.scoreRightPlayer + 1;
                msg.scoreLeftPlayer = message.scoreLeftPlayer;
            }
            else if (message.MsgType == ProtocolInterface.MsgType.GOAL_TO_RIGHT)
            {
                msg.scoreLeftPlayer = message.scoreLeftPlayer + 1;
                msg.scoreRightPlayer = message.scoreRightPlayer;

            }

            msg.MsgType = ProtocolInterface.MsgType.GOAL;
            msg.BallVector = ballVector;
            msg.game = currGame;
            main.manager.SendMessageToPlayer(msg, currGame.player1);
            main.manager.SendMessageToPlayer(msg, currGame.player2);
        }

        public void handleKeyG(MessageModel message, ConnectedPlayer connected)
        {
            GameModel currGame = new GameModel();
            currGame = getGameByString(connected.player.currGameName);
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_G;
            if (message.player.username == currGame.player1.username)
            {
                main.manager.sendMessageToClient(connected, msg);
                main.manager.SendMessageToPlayer(msg, currGame.player2);
            }
        }

        public void handleKeyT(MessageModel message, ConnectedPlayer connected)
        {
            GameModel currGame = new GameModel();
            currGame = getGameByString(connected.player.currGameName);
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.KEY_T;
            if (message.player.username == currGame.player1.username)
            {
                main.manager.sendMessageToClient(connected, msg);
                main.manager.SendMessageToPlayer(msg, currGame.player2);
            }
        }

        public void handleRemoveRoom(MessageModel message, ConnectedPlayer connected)
        {
            List<GameModel> gamesToRemove = new List<GameModel>();
            foreach (GameModel game in games)
            {
                if (message.player.username == game.player1.username)
                {
                    gamesToRemove.Add(game);
                }
            }
            foreach (GameModel gameToRemove in gamesToRemove)
            {
                games.Remove(gameToRemove);
            }
            List<RoomModel> roomsToRemove = new List<RoomModel>();

            foreach (RoomModel room in rooms)
            {
                if (message.player.username == room.player1.username)
                {
                    roomsToRemove.Add(room);
                }
            }

            foreach (RoomModel roomToRemove in roomsToRemove)
            {
                rooms.Remove(roomToRemove);
            }
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.ROOM_REMOVED;
            msg.rooms = rooms;
            msg.msgStr = connected.player.username;
            foreach (ConnectedPlayer player in players)
            {
                main.manager.sendMessageToClient(player, msg);
            }
        }
           
   

        public void handleSignOut(MessageModel message, ConnectedPlayer connected)
        {
            connected.player = null;
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.SIGN_OUT;
            main.manager.sendMessageToClient(connected, msg);
        }

        public void handleUpdateRooms(MessageModel message, ConnectedPlayer connected)
        {
            MessageModel msg = new MessageModel();
            msg.MsgType = ProtocolInterface.MsgType.UPDATE_OPEN_ROOMS;
            msg.player = message.player;
            msg.rooms = rooms;
            main.manager.sendMessageToClient(connected, msg);
        }
    }
}
