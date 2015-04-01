using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Graph.Algorithms
{
    public class Kruskal
    {
        public List<Vertex> Set { get; private set; }

        public Kruskal(List<Edge> edges)
        {
            List<Edge> sortedEdges = SortEdgesByCost(edges);
            List<List<Vertex>> disjointSets = DisjointSets(sortedEdges);
            Set = Build(disjointSets);
        }

        private List<Edge> SortEdgesByCost(List<Edge> edges)
        {
            List<Edge> sortedEdges = new List<Edge>();
            foreach (Edge e in edges)
                sortedEdges.Add(e);

            int n = 0;
            Edge tmp = null;
            for (int i = 0; i < sortedEdges.Count; i++)
            {
                for (int j = n = i; j < sortedEdges.Count; j++)
                {
                    if (sortedEdges[j].Cost < sortedEdges[n].Cost)
                        n = j;
                }
                tmp = sortedEdges[i];
                sortedEdges[i] = sortedEdges[n];
                sortedEdges[n] = tmp;
            }

            return sortedEdges;
        }

        private List<List<Vertex>> DisjointSets(List<Edge> edges)
        {
            List<List<Vertex>> disjointSets = new List<List<Vertex>>();

            foreach (Edge e in edges)
            {
                disjointSets.Add(new List<Vertex>());
                disjointSets.Last().Add(e.Start);
                disjointSets.Last().Add(e.End);
            }

            return disjointSets;
        }

        private List<Vertex> Build(List<List<Vertex>> sets)
        {
            List<List<Vertex>> tmpSets = new List<List<Vertex>>();
            List<int> indexes = null;
            foreach (List<Vertex> vl in sets)
            {
                indexes = new List<int>();
                for (int i = 0; i < tmpSets.Count; i++)
                {
                    //To know if was any union, if not, "lv" will add to "tmp" separately.
                    if (DisjointUnion(tmpSets[i], vl))
                        indexes.Add(i);
                }
                if (indexes.Count == 0)
                    tmpSets.Add(vl);
                else if (indexes.Count > 1)
                {
                    for (int i = 1; i < indexes.Count; i++)
                    {
                        DisjointUnion(tmpSets[indexes[0]], tmpSets[indexes[i]]);
                        tmpSets.RemoveAt(i);
                    }
                }
            }

            return tmpSets[0];
        }

        private bool DisjointUnion(List<Vertex> u, List<Vertex> v)
        {
            bool unite = false;
            foreach (Vertex x in v)
            {
                if (Exists(x, u))
                {
                    unite = true;
                    break;
                }
            }

            if (unite)
            {
                foreach (Vertex x in v)
                {
                    if (!Exists(x, u))
                        u.Add(x);
                }
            }

            return unite;
        }

        private bool Exists(Vertex a, List<Vertex> b)
        {
            foreach (Vertex v in b)
            {
                if (a == v)
                    return true;
            }

            return false;
        }

    }
}
