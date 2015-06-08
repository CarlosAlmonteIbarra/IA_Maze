using Maze.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Graph;

namespace Maze.Engine
{
    public class Builder
    {
        public List<GameObject> Walls { get; private set; }
        public Graph.Graph MazeGraph { get; private set; }
        public Cell[,] Cells { get; private set; }

        public Builder(int rows, int columns, float wallLength, float wallThickness)
        {
            RandomizedPrim prim = new RandomizedPrim(rows, columns, wallLength, wallThickness);
            Cells = prim.Maze;
            SetWalls(prim.Maze, rows, columns);
            CreateGraph(prim.Maze, rows, columns);
        }

        private void SetWalls(Cell[,] cells, int rows, int cols)
        {
            Walls = new List<GameObject>();
            Cell c = null;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    c = cells[i, j];
                    if (!c.Left.IsOpen)
                        Walls.Add(c.Left);
                    if (!c.Top.IsOpen)
                        Walls.Add(c.Top);
                    if (j == cols - 1)
                        Walls.Add(c.Right);
                    if (i == rows - 1)
                        Walls.Add(c.Bottom);
                }
            }
        }

        private void CreateGraph(Cell[,] cells, int rows, int cols)
        {
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
            Vertex v = null;
            Edge e = null;
            int prevRow = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    v = new Vertex();
                    if (j > 0 && cells[i, j].Left.IsOpen)
                    {
                        e = new Edge(vertices.Last(), v, 1);
                        edges.Add(e);
                        e = new Edge(v, vertices.Last(), 1);
                        edges.Add(e);
                    }
                    if (i > 0 && cells[i, j].Top.IsOpen)
                    {
                        prevRow = vertices.Count - cols;
                        e = new Edge(vertices[prevRow], v, 1);
                        edges.Add(e);
                        e = new Edge(v, vertices[prevRow], 1);
                        edges.Add(e);
                    }
                    vertices.Add(v);
                }
            }

            MazeGraph = new Graph.Graph(vertices, edges);
        }

    }
}
