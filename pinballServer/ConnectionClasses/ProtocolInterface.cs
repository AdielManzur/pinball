using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pinballServer.ConnectionClasses
{
    public static class ProtocolInterface
    {
        static JsonSerializer serializer = new JsonSerializer();
        public enum gameState
        {
            NOT_STARTED,
            INIT,
            START, 
            END
        }
        public enum MsgType
        {
            MSG_LOGIN,
            LOGIN_OK,
            LOGIN_ERROR,
            MSG_REGISTER,
            REGISTER_OK,
            REGISTER_ERROR,
            MSG_JOIN_GAME,
            OPEN_NEW_WAITING_ROOM,
            OPEN_NEW_WAITING_ROOM_OK,
            OPEN_NEW_WAITING_ROOM_ERROR,
            LIST_OPEN_ROOMS_OK,
            JOIN_ROOM,
            LIST_OPEN_ROOMS,
            JOIN_GAME_OK,
            JOIN_GAME_ERROR
        }
        public static string SerializeMessage(MessageModel message)
        {
            string str = JsonConvert.SerializeObject(message);
            return str;
        }
        public static MessageModel DeSerializeMessage(string msgStr)
        {
            MessageModel message = JsonConvert.DeserializeObject<MessageModel>(msgStr);
            return message;
        }
    }
}
