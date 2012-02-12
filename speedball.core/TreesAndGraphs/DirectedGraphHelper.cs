using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using speedball.core.DataStructures;

namespace speedball.core.TreesAndGraphs
{
    public static class DirectedGraphHelper
    {
        // breadth first search
        public static bool CanFindRoute(Graph g, GraphNode start, GraphNode end)
        {
            // operates as a queue
            Queue<GraphNode> q = new Queue<GraphNode>();

            start.NodeState = NodeState.Visiting;
            q.Enqueue(start);
            GraphNode uNode;

            while (q.Count != 0)
            {
                uNode = q.Dequeue();
                if (uNode != null)
                {
                    foreach (var v in uNode.AdjacentNodes)
                    {
                        if (v.NodeState == NodeState.Unvisited)
                        {
                            if (v == end) return true;

                            v.NodeState = NodeState.Visiting;
                            q.Enqueue(v);
                        }
                    }
                }

                uNode.NodeState = NodeState.Visited;
            }

            return false;
        }
    }
}
