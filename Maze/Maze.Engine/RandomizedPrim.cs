using Maze.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Engine
{
    public class RandomizedPrim
    {
        private Cell[,] _maze;
        private Random _random = new Random();

        public Cell[,] Maze { get { return _maze; } }

        public RandomizedPrim(int rows, int columns, float cellSize, float wallThickness)
        {
            _maze = new Cell[rows, columns];
            SetCells(rows, columns, cellSize, wallThickness);
            BuildMaze(rows, columns);
        }

        private void SetCells(int m, int n, float cellSize, float wallThickness)
        {
            float x = wallThickness, y = wallThickness; // For GameEnviroment use
            Cell cell = null;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cell = _maze[i, j] = new Cell(x, y, cellSize);
                    x += cellSize + wallThickness;

                    cell.Bottom = new Wall(cell.X - wallThickness, cell.Y + cellSize, (wallThickness*2) + cellSize, wallThickness);
                    if (i == 0) // Top row
                    {
                        cell.Top = new Wall(cell.X-wallThickness, cell.Y - wallThickness, cellSize + (wallThickness*2), wallThickness);
                        cell.Top.IsEdge = true;
                    }
                    else
                    {
                        cell.Top = _maze[i - 1, j].Bottom;
                        cell.Top.SideA = _maze[i - 1, j];
                        cell.Top.SideB = cell;
                    }
                    if (i == m - 1)
                        cell.Bottom.IsEdge = true;

                    cell.Right = new Wall(cell.X + cellSize, cell.Y - wallThickness, wallThickness, cellSize + (wallThickness*2));
                    if (j == 0) // First column
                    {
                        cell.Left = new Wall(cell.X - wallThickness, cell.Y - wallThickness, wallThickness, wallThickness + cellSize);
                        cell.Left.IsEdge = true;
                    }
                    else
                    {
                        cell.Left = _maze[i, j - 1].Right;
                        cell.Left.SideA = _maze[i, j - 1];
                        cell.Left.SideB = cell;
                    }
                    if (j == n - 1)
                        cell.Right.IsEdge = true;
                }
                x = wallThickness;
                y += cellSize + wallThickness;
            }
        }

        private void BuildMaze(int m, int n)
        {
            List<Wall> walls = new List<Wall>();
            Cell cell = GetRandomCell(m, n);
            InitializeCellInMaze(cell, null, walls);
            Wall wall = null;
            
            while (walls.Count != 0)
            {
                wall = GetRandomWall(walls);
                if (!(wall.SideA.InMaze && wall.SideB.InMaze))
                {
                    wall.IsOpen = true;
                    if (wall.SideA.InMaze)
                        cell = wall.SideB;
                    else
                        cell = wall.SideA;
                    InitializeCellInMaze(cell, wall, walls);
                }
                walls.Remove(wall);
                if (AllCellsInMaze())
                    break;
            }
        }

        private Cell GetRandomCell(int columns, int rows)
        {
            return _maze[_random.Next(0, columns), _random.Next(0, rows)];
        }

        private Wall GetRandomWall(List<Wall> walls)
        {
            Wall wall = walls[_random.Next(0, walls.Count)];
            while (wall.IsEdge || wall.SideA.InMaze && wall.SideB.InMaze)
            {
                walls.Remove(wall);
                wall = wall = walls[_random.Next(0, walls.Count)];
            }
            return wall;
        }

        private void InitializeCellInMaze(Cell cell, Wall ignore, List<Wall> walls)
        {
            cell.InMaze = true;
            if (cell.Top != ignore) walls.Add(cell.Top);
            if (cell.Right != ignore) walls.Add(cell.Right);
            if (cell.Bottom != ignore) walls.Add(cell.Bottom);
            if (cell.Left != ignore) walls.Add(cell.Left);
        }

        private bool AllCellsInMaze()
        {
            foreach (Cell c in _maze)
            {
                if (!c.InMaze)
                    return false;
            }
            return true;
        }

    }
}
