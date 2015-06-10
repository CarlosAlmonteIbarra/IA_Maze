using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Engine.Characters
{
    public class EnemyFactory
    {
        private Enemy _enemy;

        public Enemy CreateEnemy(string name)
        {
            switch (name)
            {
                case "adan":
                    _enemy.Name = "Adan";
                    _enemy.Face_AssetName = "adanFace";
                    _enemy.Meme_AssetName = "adanMeme";
                    break;
                case "carol":
                    _enemy.Name = "Carol";
                    _enemy.Face_AssetName = "carolFace";
                    _enemy.Meme_AssetName = "carolMeme";
                    break;
                case "fabian":
                    _enemy.Name = "Fabian";
                    _enemy.Face_AssetName = "fabianFace";
                    _enemy.Meme_AssetName = "fabianMeme";
                    break;
                case "ricky":
                    _enemy.Name = "Ricky";
                    _enemy.Face_AssetName = "rickyFace";
                    _enemy.Meme_AssetName = "rickyMeme";
                    break;
                default:
                    break;
            }
            return _enemy;
        }
    }
}
