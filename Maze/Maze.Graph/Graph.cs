using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Graph
{
    public class Graph
    {
        public List<Vertex> Vertices { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }
        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public List<Edge> EdgesOf(Vertex v)
        {
            return Edges.Where(e => e.Start == v).ToList();
        }

        public List<Vertex> Neighbors(Vertex v)
        {
            List<Vertex> neighbors = new List<Vertex>();
            foreach (Edge e in EdgesOf(v))
                neighbors.Add(e.End);
            return neighbors;
        }

    }
}
