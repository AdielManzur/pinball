using Elasticsearch.Net;
using pinballServer.GamesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pinballServer.ConnectionClasses
{
    [Serializable]

    public class MessageModel
    {
        public ProtocolInterface.MsgType MsgType { get; set; }
        public string msgStr { get; set; }
        public string userName { get; set; }
        public string pass { get; set; }
        public PlayerS player { get; set; }
        public GameModel game { get; set; }
        public List<RoomModel> rooms { get; set; }
        public Vector2 BallVector { get; set; }       
        public int scoreRightPlayer { get; set; }
        public int scoreLeftPlayer { get; set; }


    }
}
