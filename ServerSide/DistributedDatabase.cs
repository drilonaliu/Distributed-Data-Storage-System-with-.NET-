using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProgramSpecification;

namespace ServerSide
{
    public class DistributedDatabase
    {
       private List<string> alphabet = new List<string>(); // List 1 a b c d
       private List<Node> nodes = new List<Node>();                           // List 2: NodeA nodeB nodeC
       private List<Person> people = new List<Person>();
        public DistributedDatabase()
        {
            initNodes();
        }
        private void initNodes()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                string letter= c.ToString();
                alphabet.Add(letter);
                Node node = new Node(letter);
                nodes.Add(node);
            }
        }

        public void initProxyServer()
        {
            
        }

        public List<Node> getNodes()
        {
            return nodes;
        }
        public Node findNode(Person person)
        {
            string name = person.getName();
            string firstCharacter = name.ToCharArray()[0].ToString();
            int index = alphabet.IndexOf(firstCharacter);
            Node node = nodes[index];
            return node;
        }
        public void writeRecord(Person person)
        {
            Node node =  findNode(person);
            node.addRecord(person);
        }
        public override string ToString()
        {
            string nodesText = "";
            for(int i = 0; i < nodes.Count; i++)
            {
                nodesText+= nodes[i].ToString() + "\n";
            }
            return "Databaza ka keto nodes" + "\n" + nodesText;
        }
    }
}
