using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace Maze.Engine.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public Song CallName { get; set; }
        public string Face_AssetName { get; set; }
        public string Body_AssetName { get; set; }

    }
}
