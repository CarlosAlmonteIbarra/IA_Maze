using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine.Objects
{
    public abstract class Character : GameObject
    {
        protected float Speed { get; set; }
        public Direction Facing { get; set; }
        
        public Character(float x, float y, float width, float height, float speed)
            : base(x, y, width, height)
        {
            Speed = speed;
        }

        public void Move(Direction to)
        {
            switch (to)
            {
                case Direction.Right:
                    if (Facing != Direction.Right)
                        Facing = Direction.Right;
                    else
                        X += Speed;
                    break;
                case Direction.Left:
                    if (Facing != Direction.Left)
                        Facing = Direction.Left;
                    else
                        X -= Speed;
                    break;
                case Direction.Up:
                    if (Facing != Direction.Up)
                        Facing = Direction.Up;
                    else
                        Y -= Speed;
                    break;
                case Direction.Down:
                    if (Facing != Direction.Down)
                        Facing = Direction.Down;
                    else
                        Y += Speed;
                    break;
            }
        }

    }
}
