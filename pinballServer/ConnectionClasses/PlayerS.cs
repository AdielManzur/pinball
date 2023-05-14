using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace pinballServer.ConnectionClasses
{
    [Serializable]

    public class PlayerS
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime regDate { get; set; }
        public void convertFromUserTBL(playerTBL p)
        {
            //Id = p.Id;
            username = p.username;
            password = p.password;
            firstName = p.first_name;
            lastName = p.last_name;
            regDate = p.registerDate;
        }

       
        public static playerTBL convertUserTBLFromMessage(MessageModel msg)
        {
            playerTBL user = new playerTBL();
            
            user.username = msg.player.username;
            user.password = msg.player.password;
            user.first_name = msg.player.firstName;
            user.last_name = msg.player.lastName;
            user.registerDate = DateTime.Now ;
            return user;
        }
    }
}
