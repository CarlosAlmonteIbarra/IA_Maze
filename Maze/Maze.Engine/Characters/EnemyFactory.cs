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
            _enemy = new Enemy();
            switch (name)
            {
                case "adan":
                    _enemy.Name = "Adan";
                    _enemy.Face_AssetName = "Characters\\Adan\\adanFace";
                    _enemy.Meme_AssetName = "Characters\\Adan\\adanMeme2";
                    break;
                case "carol":
                    _enemy.Name = "Carol";
                    _enemy.Face_AssetName = "Characters\\Carol\\carolFace";
                    _enemy.Meme_AssetName = "Characters\\Carol\\carolMeme2";
                    break;
                case "fabian":
                    _enemy.Name = "Fabián";
                    _enemy.Face_AssetName = "Characters\\Fabián\\fabianFace";
                    _enemy.Meme_AssetName = "Characters\\Fabián\\fabianMeme2";
                    break;
                case "ricky":
                    _enemy.Name = "Ricky";
                    _enemy.Face_AssetName = "Characters\\Ricky Martin\\rickyFace";
                    _enemy.Meme_AssetName = "Characters\\Ricky Martin\\rickyMeme2";
                    break;
                default:
                    _enemy.Name = null;
                    _enemy.Face_AssetName = null;
                    _enemy.Meme_AssetName = null;
                    break;
            }
            return _enemy;
        }
    }
}
