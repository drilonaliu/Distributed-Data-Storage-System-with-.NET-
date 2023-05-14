using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using ProgramSpecification;

namespace TCPClient
{
    public class Client
    {

        private Socket socketKlienti;

        public Client()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            socketKlienti = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketKlienti.Connect(ip);
            }
            catch (SocketException socketex)
            {
                Console.WriteLine("E pamundur te krijohet lidhja me serverin" + socketex.Message);
                return;
            }
        }

        public void sendQueryRequestToServer(QueryFunction request)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, request);
            socketKlienti.Send(stream.ToArray());
        }

        public QueryResultSet recieveQueryResultSet()
        {
            byte[] informata = new byte[1024];
            int gjatesia = socketKlienti.Receive(informata);
            MemoryStream stream = new MemoryStream(informata);
            BinaryFormatter formatter = new BinaryFormatter();
            QueryResultSet recievedMatrix = (QueryResultSet)formatter.Deserialize(stream);
            return recievedMatrix;
        }

        public void turnOff()
        {
            socketKlienti.Shutdown(SocketShutdown.Both);
            socketKlienti.Close();
        }
    }
}
