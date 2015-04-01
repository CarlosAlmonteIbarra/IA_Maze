using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine.Objects
{
    class Player : Character
    {
        public Player(float x, float y, float width, float height, float speed)
            : base(x, y, width, height, speed)
        {
        }
    }
}
