using Maze.Engine.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine.Objects
{
    class CPU : Character
    {
        private ICPUStrategy _strategy;

        public CPU(float x, float y, float width, float height, float speed, ICPUStrategy strategy)
            : base(x, y, width, height, speed)
        {
            _strategy = strategy;
        }

        public void ApplyStrategy()
        {
            _strategy.Operate();
        }

    }
}
