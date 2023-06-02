using pinballServer.GamesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace pinballServer.ConnectionClasses
{
    public class ConnectionManager
    {
        private TcpListener listener;           
        NetworkStream stream = default(NetworkStream);
        List<Socket> clientsList;
        private int BUFFER_SIZE = 1048576;
        private int PORT = 7000;
        private byte[] buffer;
        public ServerMainWin main;
        MessgaeHandeling messgaeHandeling;
        public List<ConnectedPlayer> players { get; set; }


        public ConnectionManager(ServerMainWin main)
        {
            this.main = main;
            buffer = new byte[BUFFER_SIZE];
            listener = new TcpListener(System.Net.IPAddress.Any, PORT);
            clientsList = new List<Socket>();
            players = new List<ConnectedPlayer>();
            messgaeHandeling = new MessgaeHandeling(this);

        }
        public void StartServer()
        {
            listener.Start();
            listener.BeginAcceptTcpClient(clientConnected, null);

        }

        private void clientConnected(IAsyncResult ar)
        {
            Socket socket;
            
            try
            {
                socket = listener.EndAcceptSocket(ar);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            clientsList.Add(socket);
            ConnectedPlayer c = new ConnectedPlayer();
            c.client = socket;

            players.Add(c);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);

            listener.BeginAcceptTcpClient(clientConnected, null);
            main.updateConnectedClients(getConnectedClients());
        }

        public List<string> getConnectedClients()
        {

            List<string> lst = new List<string>();
            foreach (ConnectedPlayer p in players)
            {
                lst.Add(p.client.RemoteEndPoint.ToString());
            }
            return lst;
        }

        public bool isListening()
        {
            return listener.Server.IsBound;

        }



        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket current = (Socket)ar.AsyncState;
            ConnectedPlayer conncted = players.Where(x => x.client == current).FirstOrDefault();



            int receivedMessageSize;

            try
            {
                receivedMessageSize = current.EndReceive(ar);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                clientsList.Remove(current);

                players.Remove(conncted);
                return;
            }
            
            byte[] recBuf = new byte[receivedMessageSize];
            Array.Copy(buffer, recBuf, receivedMessageSize);
            string msgStr = System.Text.Encoding.Default.GetString(recBuf);
            MessageModel message = ProtocolInterface.DeSerializeMessage(msgStr);
            messgaeHandeling.handleMessage(message, conncted);

            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);

        }
        public void sendMessageToClient(ConnectedPlayer connected,MessageModel message)
        {
            string str = ProtocolInterface.SerializeMessage(message);
            byte[] data = Encoding.UTF8.GetBytes(str);
            connected.client.Send(data, 0, data.Length, SocketFlags.None);

        }
        public void SendMessageToPlayer(MessageModel message,PlayerS player)
        {
            foreach(ConnectedPlayer connectedPlayer in players)
            {
                if(connectedPlayer.player == player)
                {
                    sendMessageToClient(connectedPlayer, message);
                }
            }
        }


        public void stopServer()
        {
            listener.Stop();
        }
    }
}

