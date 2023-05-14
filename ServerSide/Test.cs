using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProgramSpecification;

namespace ServerSide
{
    internal class Test
    {
        public static void maininKryesor(string[] args)
        {
            Person p1 = new Person(new IDPerson("1"),"Drilon",21);
            Person p2 = new Person(new IDPerson("1"), "Ben", 20);
            Person p3 = new Person(new IDPerson("1"), "Artan", 40);
            Person p4 = new Person(new IDPerson("2"), "Dn", 1);

            DistributedDatabase db  = new DistributedDatabase();
            db.writeRecord(p1);
            db.writeRecord(p2); 
            db.writeRecord(p3);
            db.writeRecord(p4);

            Console.WriteLine(db);

            List<string> conditions = new List<string>() { "A", "B", "D" };
            QueryFunction qf = new QueryFunction(conditions);
            ProxyService proxy = new ProxyService(db.getNodes(), qf);
            List<Record> rezultatet = proxy.getDataRequestedFromUser();

            for (int i = 0; i < rezultatet.Count; i++)
            {

                Console.WriteLine(rezultatet[i]);
            }


        }
    }
}
