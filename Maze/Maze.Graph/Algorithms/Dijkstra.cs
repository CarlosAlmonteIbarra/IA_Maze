using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Graph.Algorithms
{
    public class Dijkstra
    {
        private Graph _graph;
        public List<Vertex> ShortestPath { get; set; }

        public Dijkstra(Graph graph)
        {
            _graph = graph;
            foreach (Vertex v in _graph.Vertices)
                v.Weight = -1; // infinite
        }

        public void BuildShortestPath(Vertex from, Vertex to)
        {
            from.Weight = 0;
            BuildPath(from, to);
            ShortestPath = new List<Vertex>();
            ShortestPath.Add(from);
            SetShortestPath(from, to);
        }

        private void BuildPath(Vertex from, Vertex to)
        {
            List<Edge> edges = _graph.EdgesOf(from);

            foreach (Edge e in edges)
            {
                if (e.End.Weight == -1 || from.Weight + e.Cost < e.End.Weight)
                {
                    e.End.Weight = from.Weight + e.Cost;
                    if (e.End != to)
                        BuildPath(e.End, to);
                }
            }
        }

        private bool SetShortestPath(Vertex current, Vertex to)
        {
            List<Edge> edges = _graph.EdgesOf(current);
            foreach (Edge e in edges)
            {
                if (current.Weight + e.Cost == e.End.Weight)
                {
                    ShortestPath.Add(e.End);
                    if (e.End == to)
                        return true;
                    if (!SetShortestPath(e.End, to))
                        ShortestPath.Remove(e.End);
                    else
                        return true;
                }
            }

            return false;
        }

    }
}