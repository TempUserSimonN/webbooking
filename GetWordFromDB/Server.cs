using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NoneScaled.Models;

namespace NoneScaled
{
    public class Server
    {
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _ClientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Random rnd = new Random();
        public Server()
        {
            Console.WriteLine("Server Setup Type ind a port start at 101 and go up");
            int port = -1;
            Int32.TryParse(Console.ReadLine(), out port);

            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _ClientSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] databuf = new byte[received];
            Array.Copy(_buffer, databuf, received);
            string text = Encoding.ASCII.GetString(databuf);
            Console.WriteLine("Text Receivede = " + text);

            List<string> responce = new List<string>();
            int id = Int32.Parse(Console.ReadLine());
            //der er beder måder at lave load balance som at count hvormange der er logget på og så bruge det tal
            User u = GetUser(id);
            //responce.Add();

            byte[] eData = responce
            .SelectMany(s => Encoding.ASCII.GetBytes(s))
            .ToArray();

            byte[] eDataOld = Encoding.ASCII.GetBytes(responce.ToString());
            socket.BeginSend(eData, 0, eData.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);

            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();
            //socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }
        public static User GetUser(int id)
        {
            User user = null;
            try
            {
                using (var _reposetory = new WebbookingDBEnteties("name=WebBooking"))
                {
                    string SELECT = "SELECT 'id','vertion','pallers','tempPlates' ";
                    string FROM = "[bookingUser]";
                    //    string WHERE = "WHERE [WebBooking].[dbo].[bookingUser].[id]";
                    //    string Like = "like '" + id + "'";
                    string sqlCode = SELECT + FROM;// + WHERE + Like;
                    List<User> users = _reposetory.user.SqlQuery(sqlCode).ToList();

                    if (users.Count != 0)
                    {
                        user = users[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (user == null)
            {
                user = new User() { id = -1 };
            }
            return user;
        }
        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    }
}
