using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSpecification
{

    [Serializable]
  public class Person : Record 
    {
        private IDPerson idPerson;
        private string name;
        private int age;
        public Person(IDPerson idPerson, string name, int age)
        {
            this.idPerson = idPerson;
            this.name = name; 
            this.age = age;
        }

        public string getName()
        {
            return name;
        }

        public int getAge() {
            return age;
        }


        public Key getKey()
        {
            return this.idPerson;
        }

        public override string ToString()
        {
            return this.idPerson.keyValue() + " " + this.name + " " + this.age;   
        }
    }
}
