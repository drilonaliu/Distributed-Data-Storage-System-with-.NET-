using ProgramSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    public class ClientStarter
    {
    
        public static void Main(string[] args)
        {
            Client client = new Client();
            List<string> conditions = new List<string>() { "A", "B", "D" };
            QueryFunction queryFunction = new QueryFunction(conditions);

            client.sendQueryRequestToServer(queryFunction);
            QueryResultSet queryResultSet = client.recieveQueryResultSet();

            Console.WriteLine(queryResultSet);
     /*       client.turnOff();*/

        }
    }
}
