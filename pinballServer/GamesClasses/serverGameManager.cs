using pinballServer.ConnectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool isGameExist(String gameName)
        {
            foreach (GameModel game in games)
            {
                if (gameName == game.gameName)
                {
                    return true;
                }
            }
            return false;
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


    }
}
