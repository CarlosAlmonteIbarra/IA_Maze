using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Graph
{
    public class Vertex
    {
        public string Label { get; private set; }
        public bool Visited { get; set; }
        public int Weight { get; set; }

        public Vertex(string label)
        {
            Label = label;
            Visited = false;
        }

    }
}
