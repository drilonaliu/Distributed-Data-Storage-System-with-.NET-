using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSpecification;

namespace ServerSide
{
    public class Node
    {
        private string id;
        private List<Record> records = new List<Record>();

         public Node (string id)
        {
            this.id = id;
        }

        public void addRecord(Record record) {
            records.Add(record);
        }

        public string getID()
        {
            return id;
        }
        public List<Record> runQuery(QueryFunction queryFunction)
        {
            List<Record> rez = queryFunction.query(records);
            return rez;
        }


        public override string ToString()
        {
            string peopleString = "";
            for(int i = 0; i<records.Count; i++)
            {
                peopleString += records[i].ToString() +"\n";
            }

            return "Node with id " + id + " has the list of people" + "\n" + peopleString +"\n";
        }
    }
}
