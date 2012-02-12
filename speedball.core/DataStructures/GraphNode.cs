using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class GraphNode
    {
        public NodeState NodeState { get; set; }
        public List<GraphNode> AdjacentNodes { get; set; }
 
        public GraphNode()
        {
            AdjacentNodes = new List<GraphNode>();
            NodeState = NodeState.Unvisited;
        }
    }
}
