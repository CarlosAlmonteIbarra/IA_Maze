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
                    _enemy.Face_AssetName = "Characters\\Adan\\adanFace";
                    _enemy.Meme_AssetName = "Characters\\Adan\\adanMeme";
                    break;
                case "carol":
                    _enemy.Name = "Carol";
                    _enemy.Face_AssetName = "Characters\\Carol\\carolFace";
                    _enemy.Meme_AssetName = "Characters\\Carol\\carolMeme";
                    break;
                case "fabian":
                    _enemy.Name = "Fabián";
                    _enemy.Face_AssetName = "Characters\\Fabián\\fabianFace";
                    _enemy.Meme_AssetName = "Characters\\Fabián\\fabianMeme";
                    break;
                case "ricky":
                    _enemy.Name = "Ricky";
                    _enemy.Face_AssetName = "Characters\\Ricky Martin\\rickyFace";
                    _enemy.Meme_AssetName = "Characters\\Ricky Martin\\rickyMeme";
                    break;
                default:
                    break;
            }
            return _enemy;
        }
    }
}
