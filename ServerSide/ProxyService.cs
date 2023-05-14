using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSpecification;

namespace ServerSide
{
    public class ProxyService
    {
        private List<string> alphabet = new List<string>();
        private List<Node> nodes;
        private QueryFunction queryFunction;


       public ProxyService(List<Node> nodes, QueryFunction queryFunction)
        {
    
            this.nodes = nodes;
            this.queryFunction = queryFunction;
            initAlphabet();
        }

        private void initAlphabet()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                string letter = c.ToString();
                alphabet.Add(letter);
            }
        }

        public List<Record> getDataRequestedFromUser()
        {
            List<Record> rez = new List<Record>();
            List<string> conditions = queryFunction.getConditions();
            for(int i = 0; i < conditions.Count; i++)
            {
                Node node = findNode(conditions[i]);
                List<Record> queryResultSet = node.runQuery(queryFunction);
                rez.AddRange(queryResultSet);
            }
            return rez;
        }

        public Node findNode(string firstCharacter)
        {
            Console.WriteLine(firstCharacter);

            int index = alphabet.IndexOf(firstCharacter);

            Console.WriteLine("ERORRRI NDODHI PER INDEX = " + index + " DHE shkronjen" + firstCharacter);
            Node node = nodes[index];
            return node;
        }

    }
}
