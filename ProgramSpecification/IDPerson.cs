using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSpecification
{
    [Serializable]
    public class IDPerson : Key
    {
        private string id;

       public IDPerson(string id)
        {
            this.id = id;
        }

        public string keyValue()
        {
            return id;
        }
        public bool equals(Key other)
        {
            string id2 = ((IDPerson)other).keyValue();
            bool value = false;
            if (id2 == id) {
                value = true;
            }
            return value;
        }
    }
}
