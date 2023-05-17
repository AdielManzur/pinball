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
            firstName = p.firstName;
            lastName = p.lastName;
            regDate = p.regDate;
        }

       
        public static playerTBL convertUserTBLFromMessage(MessageModel msg)
        {
            playerTBL user = new playerTBL();
            
            user.username = msg.player.username;
            user.password = msg.player.password;
            user.firstName = msg.player.firstName;
            user.lastName = msg.player.lastName;
            user.regDate = DateTime.Now ;
            return user;
        }
        
    }
}
