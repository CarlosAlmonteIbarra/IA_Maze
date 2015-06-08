using Maze.Engine.Objects;
using Maze.Graph;
using Maze.Graph.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Engine.AI
{
    class ShortestPathStrategy : ICPUStrategy
    {
        private List<Cell> _path;
        private Cell _nextCell;
        private Direction _currentDirection;
        private bool _reachedGoal = false;

        public CPU CPU { get; set; }
        public CollitionProcessor CollitionProcessor { get; set; }

        public ShortestPathStrategy(Graph.Graph graph, Cell[,] cells, Cell start, Cell goal)
        {
            Dijkstra dijkstra = new Dijkstra(graph);
            List<Cell> cellsList = new List<Cell>();
            Vertex startV = null, goalV = null;
            
            int i = 0;
            foreach (Cell c in cells)
            {
                cellsList.Add(c);
                if (c == start)
                    startV = graph.Vertices[i];
                else if (c == goal)
                    goalV = graph.Vertices[i];
                i++;
            }
            
            dijkstra.BuildShortestPath(startV, goalV);
            List<Vertex> path = dijkstra.ShortestPath;

            _path = new List<Cell>();
            for (i = 0; i < path.Count; i++)
            {
                for (int j = 0; j < graph.Vertices.Count; j++)
                {
                    if (path[i] == graph.Vertices[j])
                    {
                        _path.Add(cellsList[j]);
                        break;
                    }
                }
            }
        }

        public void Operate()
        {
            if (_reachedGoal)
                return;
            _nextCell = GetNextCell();
            _currentDirection = GetNextCellDirection(_nextCell);
            CPU.Move(_currentDirection);
            this.CollitionProcessor.CheckForCollition(CPU, _currentDirection);
        }

        private Cell GetNextCell()
        {
            for (int i = 0; i < _path.Count; i++)
            {
                if (InsideCell(_path[i]) && i + 1 < _path.Count)
                    return _path[i + 1];
            }

            return _nextCell;
        }

        private bool InsideCell(Cell c)
        {
            float axw = CPU.X + CPU.Width;
            float ayh = CPU.Y + CPU.Height;
            float bxw = c.X + c.Width;
            float byh = c.Y + c.Height;

            if (CPU.X > c.X && axw < bxw
                && CPU.Y > c.Y && ayh < byh)
            {
                if (c == _path.Last())
                    return _reachedGoal = true;
                return true;
            }
            return false;
        }

        private Direction GetNextCellDirection(Cell c)
        {
            if (c.X + c.Width < CPU.X)
                return Direction.Left;
            else if (c.X > CPU.X + CPU.Width)
                return Direction.Right;
            else if (c.Y + c.Height < CPU.Y)
                return Direction.Up;
            else if (c.Y > CPU.Y + CPU.Height)
                return Direction.Down;
            return _currentDirection;
        }

    }
}
