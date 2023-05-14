using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ProgramSpecification;

namespace ServerSide
{
    public class ProxyServer
    {

        static void Main(string[] args)
        {

            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8888);
            Socket socketKlienti = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketKlienti.Bind(ip);
            socketKlienti.Listen(10);
            Console.WriteLine("\n Duke e pritur klientin...");
            Socket socketServeri = socketKlienti.Accept();
            Console.WriteLine("Oh helo im connectid");
 


            Person p1 = new Person(new IDPerson("1"), "Drilon", 21);
            Person p2 = new Person(new IDPerson("1"), "Ben", 20);
            Person p3 = new Person(new IDPerson("1"), "Artan", 40);
            Person p4 = new Person(new IDPerson("2"), "Dn", 1);

            DistributedDatabase db = new DistributedDatabase();
            db.writeRecord(p1);
            db.writeRecord(p2);
            db.writeRecord(p3);
            db.writeRecord(p4);


            IPEndPoint klientiEndPoint = (IPEndPoint)socketServeri.RemoteEndPoint;
            Console.WriteLine("Serveri u lidh me klientin: {0} ne portin {1}", klientiEndPoint.Address, klientiEndPoint.Port);
            while (true)
            {
                //Get Request
                QueryFunction queryFunctionRequest = recieveRequestFromClient(socketServeri);

                //Find the requested Data
                ProxyService proxyService = new ProxyService(db.getNodes(), queryFunctionRequest);
                List<Record> resultSet = proxyService.getDataRequestedFromUser();
                QueryResultSet queryResultSet= new QueryResultSet(resultSet);

                //Send resultedData to Client
                sendQueryResultSet(queryResultSet, socketServeri);
                Console.WriteLine("Helo now i wait");
            }

            socketKlienti.Close();
            Console.WriteLine("\nShtypeni tastin 'Enter' per te perfunduar punen");
            Console.ReadLine();
        }

        public static QueryFunction recieveRequestFromClient(Socket socketKlienti)
        {
            byte[] informata = new byte[1024];
            int gjatesia = socketKlienti.Receive(informata);
            MemoryStream stream = new MemoryStream(informata);
            BinaryFormatter formatter = new BinaryFormatter();
            QueryFunction request = (QueryFunction)formatter.Deserialize(stream);
            return request;
        }

        public static void sendQueryResultSet(QueryResultSet resultSet, Socket socketKlienti)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, resultSet);
            socketKlienti.Send(stream.ToArray());
        }
    }
}
