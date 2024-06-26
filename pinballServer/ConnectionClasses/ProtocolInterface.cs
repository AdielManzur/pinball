﻿using Newtonsoft.Json;
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

        public enum MsgType
        {
            MSG_LOGIN,
            LOGIN_OK,
            LOGIN_ERROR,
            ALREADY_ONLINE,
            MSG_REGISTER,
            REGISTER_OK,
            REGISTER_ERROR,
            OPEN_NEW_WAITING_ROOM,
            OPEN_NEW_WAITING_ROOM_OK,
            OPEN_NEW_WAITING_ROOM_ERROR,
            LIST_OPEN_ROOMS_OK,
            JOIN_ROOM,
            JOIN_ROOM_OK,
            OPEN_GAME,
            LIST_OPEN_ROOMS,
            JOIN_GAME_ERROR,
            KEY_W,
            KEY_S,
            UPDATE_OPEN_ROOMS,
            KEY_T,
            KEY_G,
            FirstBallMovement,
            COLLISION_LOWER_OR_UPPER_WALL,
            COLLISION_RIGHT_WALL,
            COLLISION_LEFT_WALL,
            COLLISION_RIGHT_PLAYER,
            COLLISION_LEFT_PLAYER,
            GOAL_RIGHT_WALL,
            GOAL_LEFT_WALL,
            SIGN_OUT,
            REMOVE_ROOM,
            ROOM_REMOVED,
            ROOM_IS_FULL,
            playrLeft,
            LEAVE_GAME,
            GOAL,
            GOAL_TO_LEFT,
            GOAL_TO_RIGHT
        }


        public static string SerializeMessage(MessageModel message)
        {

            string str = JsonConvert.SerializeObject(message);
            return str;

        }
        public static MessageModel DeSerializeMessage(string msgStr)
        {
            MessageModel message = new MessageModel();

                message = JsonConvert.DeserializeObject<MessageModel>(msgStr);
    
            return message;
            }   
        
    }
}
