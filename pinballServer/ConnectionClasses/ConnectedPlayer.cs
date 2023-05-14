using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;


namespace pinballServer.ConnectionClasses
{   
    [Serializable]
        public class ConnectedPlayer
        {
            public PlayerS player { get; set; }
            public Socket client { get; set; }
        }
    }
