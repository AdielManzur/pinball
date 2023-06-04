using pinballServer;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using pinballServer.ConnectionClasses;
using pinballServer.GamesClasses;
using System.Numerics;

namespace pinball
{
    public class clientConnectionManager
    {
        public PlayerS currPlayer { get; set; }
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private int PORT = 7000;
        private int BUFFER_SIZE = 1048576;
        private byte[] buffer;
        public ClientMainWin main;
        private bool isConnected;
        public clientConnectionManager(ClientMainWin main)
        {
            this.main = main;
            isConnected = false;
            buffer = new byte[BUFFER_SIZE];

        }

        public bool connectToServer()
        {
            try
            {
                clientSocket.Connect("127.0.0.1", PORT);
                isConnected = clientSocket.Connected;
              
            }
            catch (Exception)
            {
                isConnected = false;
            }
            if (isConnected)
            {
                clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE, 
                    SocketFlags.None, serverMessageCallback, clientSocket);

            }
            return isConnected;
        }
        private void serverMessageCallback(IAsyncResult ar)
        {/*getting message from the server*/
            Socket socket = (Socket)ar.AsyncState;
            int receivedMessageSize;
            try
            {
                receivedMessageSize = clientSocket.EndReceive(ar);
            }
            catch (SocketException)
            {
                return;
            }
            byte[] recBuf = new byte[receivedMessageSize];
            Array.Copy(buffer, recBuf, receivedMessageSize);
            string msgStr = System.Text.Encoding.Default.GetString(recBuf);
            MessageModel message = ProtocolInterface.DeSerializeMessage(msgStr);
            main.clientHandle.handleMessage(message);

            if (isConnected)
            {
                clientSocket.BeginReceive(buffer, 0, BUFFER_SIZE,
                    SocketFlags.None, serverMessageCallback, clientSocket);

            }
        }
       
        public bool isClientConnected()
        {
            return isConnected;
        }
        public void sendMessageToServer(MessageModel message)
        {
            string str = ProtocolInterface.SerializeMessage(message);
            byte[] data = Encoding.UTF8.GetBytes(str);
            clientSocket.Send(data, 0, data.Length, SocketFlags.None);

        }

        public void firstBallMovement(MessageModel message)
        {
            main.firstBallMovement(message);
        }

       

        public void updatelbxRooms(List<RoomModel> rooms)
        {
            main.updateRoomsLbx(rooms);
        }

        public void HandeKeyPress(ProtocolInterface.MsgType msgType)
        {
            main.handleKeyPress( msgType);
        }
    }
    }

