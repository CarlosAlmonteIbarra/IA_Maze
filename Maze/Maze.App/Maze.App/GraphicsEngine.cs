using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Maze.Engine.Characters;
using Maze.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Maze.Engine;
using Character = Maze.Engine.Objects.Character;
using Protagonist = Maze.Engine.Characters.Character;

namespace Maze.App
{
    class GraphicsEngine
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Character _player, _enemy;
        private GameObject _goal; // star
        private List<GameObject> _walls;
        // temporal:
        private Texture2D _playerTexture, _enemyTexture;
        private Texture2D[] _starTextures = new Texture2D[16];
        private int _starIndex = 0, _starTimer = 0;
        private const int STAR_SPEED = 150; // ms
        private Rectangle _playerRect, _enemyRect, _starRect;

        public GraphicsEngine(GraphicsDeviceManager gdManager, SpriteBatch spriteBatch, GameEnvironment ge, ContentManager cm, Protagonist p, Enemy e)
        {
            _graphics = gdManager;
            _spriteBatch = spriteBatch;
            SetGameObjects(ge, cm, p, e);

            for (int i = 0; i < _starTextures.Length; i++)
                _starTextures[i] = cm.Load<Texture2D>(string.Format("star\\star{0}", i + 1));


        }

        public void SetGameObjects(GameEnvironment ge, ContentManager cm, Protagonist p, Enemy e)
        {
            _player = ge.Player;
            _enemy = ge.Enemy;
            _goal = ge.Goal;
            _walls = ge.Walls;

            _playerTexture = cm.Load<Texture2D>(p.Face_AssetName);
            _enemyTexture = cm.Load<Texture2D>("Characters\\Adan\\adanFace");

            _playerRect = new Rectangle(0, 0, (int)_player.Width, (int)_player.Height);
            _enemyRect = new Rectangle(0, 0, (int)_enemy.Width, (int)_enemy.Height);
            _starRect = new Rectangle((int)_goal.X, (int)_goal.Y, (int)_goal.Width, (int)_goal.Height);
            //_playerTexture = new Texture2D(_graphics.GraphicsDevice, (int)_player.Width, (int)_player.Height);
            //_enemyTexture = new Texture2D(_graphics.GraphicsDevice, (int)_enemy.Width, (int)_enemy.Height);
        }

        private void RellocateTextures()
        {
            _playerRect.X = (int)_player.X;
            _playerRect.Y = (int)_player.Y;
            _enemyRect.X = (int)_enemy.X;
            _enemyRect.Y = (int)_enemy.Y;
        }

        private void DrawCells()
        {
            Vector2 pos = new Vector2(0, 0);
            Texture2D t;
            Color[] color;

            foreach (GameObject w in _walls)
            {
                t = new Texture2D(_graphics.GraphicsDevice, (int)w.Width, (int)w.Height);
                color = new Color[t.Width * t.Height];
                for (int i = 0; i < color.Length; i++) color[i] = Color.Green;
                t.SetData(color);
                pos.X = w.X;
                pos.Y = w.Y;
                _spriteBatch.Draw(t, pos, Color.White);
            }
        }

        private void DrawStar()
        {
            _spriteBatch.Draw(_starTextures[_starIndex], _starRect, Color.White);
            _starIndex = (_starIndex + 1) % _starTextures.Length;
            _starTimer++;
        }

        public void Draw()
        {
            DrawCells();
            RellocateTextures();
            _spriteBatch.Draw(_playerTexture, _playerRect, Color.White);
            _spriteBatch.Draw(_enemyTexture, _enemyRect, Color.White);
            DrawStar();
        }
        

    }
}
