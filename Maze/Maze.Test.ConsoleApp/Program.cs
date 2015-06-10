using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Engine;
using Maze.Graph;
using Maze.Graph.Algorithms;

namespace Maze.Test.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateMaze();
        }

        private static void Dijkstra()
        {
            var vertices = new List<Vertex>();
            vertices.Add(new Vertex("A"));
            vertices.Add(new Vertex("B"));
            vertices.Add(new Vertex("C"));
            vertices.Add(new Vertex("D"));
            vertices.Add(new Vertex("E"));
            vertices.Add(new Vertex("F"));
            vertices.Add(new Vertex("G"));
            vertices.Add(new Vertex("H"));

            var edges = new List<Edge>();
            edges.Add(new Edge(vertices[0], vertices[1], 10));
            edges.Add(new Edge(vertices[0], vertices[2], 3));
            edges.Add(new Edge(vertices[1], vertices[3], 1));
            edges.Add(new Edge(vertices[1], vertices[2], 14));
            edges.Add(new Edge(vertices[2], vertices[4], 21));
            edges.Add(new Edge(vertices[2], vertices[3], 4));
            edges.Add(new Edge(vertices[3], vertices[5], 6));
            edges.Add(new Edge(vertices[4], vertices[3], 6));
            edges.Add(new Edge(vertices[4], vertices[5], 6));
            edges.Add(new Edge(vertices[5], vertices[6], 10));
            edges.Add(new Edge(vertices[6], vertices[7], 7));
            edges.Add(new Edge(vertices[5], vertices[7], 12));

            var graph = new Maze.Graph.Graph(vertices, edges);
            var dijkstra = new Dijkstra(graph);
            dijkstra.BuildShortestPath(vertices[0], vertices[7]);

            foreach (var v in dijkstra.ShortestPath)
                Console.WriteLine(v.Label);
        }

        private static void GenerateMaze()
        {
            int rows = 20, cols = 20;
            var prim = new RandomizedPrim(rows, cols,11,11);
            var maze = prim.Maze;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!prim.Maze[i, j].Left.IsOpen)
                        Console.Write("|");
                    else
                        Console.Write(" ");
                    if (!prim.Maze[i, j].Top.IsOpen)
                        Console.Write(@"""");
                    else
                        Console.Write(" ");
                    if (j == cols - 1)
                        Console.Write("|");
                }
                Console.WriteLine("");
            }
            for (int i = 0; i < rows; i++)
                Console.Write(@"'""");
            Console.WriteLine("'");
        }

    }
}
