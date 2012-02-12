using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class Graph
    {
        public List<GraphNode> Nodes { get; set; }
 
        public Graph()
        {
            Nodes = new List<GraphNode>();
        }

        public GraphNode[] GetNodes()
        {
            return Nodes.ToArray();
        }

        public void AddNode(GraphNode input)
        {
            Nodes.Add(input);
        }
    }
}
