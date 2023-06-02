using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pinballServer;
using static pinballServer.ConnectionClasses.ProtocolInterface;
using pinballServer.ConnectionClasses;

namespace pinballServer.GamesClasses
{
    [Serializable]
        public class GameModel
        {
            public PlayerS player1;
            public PlayerS player2;
            public String gameName { get; set; }
        }
}
