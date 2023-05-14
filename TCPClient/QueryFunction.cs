using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgramSpecification
{
    [Serializable]
    public class QueryFunction
    {

        private List<string> nameConditions;

        public QueryFunction(List<string> conditions)
        {
            this.nameConditions = conditions;
        }

        public List<string> getConditions()
        {
            return nameConditions;
        }
        public  List<Record> query(List<Record> list) {
            List<Record> result = new List<Record>();
            foreach (Record record in list)
            {
                Person person = (Person)record;
                if(person.getAge() > 20)
                {
                    result.Add(person);
                }
            }

            return result;
        }
    }
}
