using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Engine.Objects;

namespace Maze.Engine.Objects
{
    public class Cell : GameObject
    {
        public Wall Top, Right, Bottom, Left;
        public bool InMaze { get; set; }
        
        public Cell(float x, float y, float length)
            : base(x, y, length, length)
        {
        }

    }
}
