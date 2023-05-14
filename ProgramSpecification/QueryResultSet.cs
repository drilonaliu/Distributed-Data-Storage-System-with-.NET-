using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSpecification
{
    [Serializable]
    public class QueryResultSet
    {
        private List<Record> records; 

        public QueryResultSet(List<Record> records)
        {
            this.records = records;
        }
        public override string ToString()
        {
            string peopleString = "";
            for (int i = 0; i < records.Count; i++)
            {
                peopleString += records[i].ToString() + "\n";
            }

            return "The query result set  has the returned the list of people" + "\n" + peopleString + "\n";
        }

    }
}
