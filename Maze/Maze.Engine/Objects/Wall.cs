using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine.Objects
{
    public class Wall : GameObject
    {
        public bool IsEdge, IsOpen;
        public Cell SideA, SideB;

        public Wall(float x, float y, float width, float height)
            : base(x, y, width, height) { }
    }
}
