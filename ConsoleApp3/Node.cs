using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Node
    {
        public string Name { get; set; }

        public Dictionary<Node, int> Edges { get; set; }

        public Node(string name) { Name = name; }

        public Node(string name, Dictionary<Node, int> edges)
        {
            Name = name;
            Edges = edges;
        }

        public override string ToString() => $"Node: {Name}, Edges: {Edges.Count}";

        public Node AddEdge(Node node, int distance)
        {
            if (Edges == null)
            {
                Edges = new Dictionary<Node, int>();
            }

            Edges.Add(node, distance);
            return this;

        }
    }
}