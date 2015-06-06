using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Engine
{
    public enum EndResult
    {
        PlayerWon,
        CpuWon
    }

    public delegate void GameFinishHandler(EndResult result);
}
