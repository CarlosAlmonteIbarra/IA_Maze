using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine.Objects
{
    public class Cell
    {
        public Wall Top, Right, Bottom, Left;
        public bool InMaze { get; set; }
    }
}
