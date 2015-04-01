using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Graph
{
    public class Edge
    {
        public int Cost { get; private set; }
        public Vertex Start { get; private set; }
        public Vertex End { get; private set; }

        public Edge(Vertex from, Vertex to, int cost)
        {
            Start = from;
            End = to;
            Cost = cost;
        }

    }
}
