using pinballServer.GamesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pinballServer.ConnectionClasses
{
    [Serializable]

    public class MessageModel
    {
        public ProtocolInterface.MsgType msgType { get; set; }
        public string msgStr { get; set; }
        public string userName { get; set; }
        public string pass { get; set; }
        public PlayerS player { get; set; }
        public GameModel game { get; set; }
        public List<RoomModel> rooms { get; set; }

    }
}
