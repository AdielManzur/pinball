using pinballServer.ConnectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pinballServer.GamesClasses
{
    [Serializable]
    public class RoomModel
    {
        public string name { get; set; }
        public PlayerS player1 { get; set; }
        public PlayerS player2 { get; set; }

    }
}
