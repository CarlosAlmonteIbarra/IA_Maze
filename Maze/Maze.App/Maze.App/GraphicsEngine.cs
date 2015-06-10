using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Maze.Engine;

namespace Maze.App
{
    class GraphicsEngine
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Character _player, _enemy;
        private List<GameObject> _walls;
        // temporal:
        private Texture2D _playerTexture, _enemyTexture;
        private Color[] _playerColor, _enemyColor, _cellColor;
        private Vector2 _playerPos, _enemyPos, _cellPos;

        public GraphicsEngine(GraphicsDeviceManager gdManager, SpriteBatch spriteBatch, GameEnvironment ge)
        {
            _graphics = gdManager;
            _spriteBatch = spriteBatch;
            SetGameObjects(ge);
        }

        public void SetGameObjects(GameEnvironment ge)
        {
            _player = ge.Player;
            _enemy = ge.Enemy;
            _walls = ge.Walls;

            _playerTexture = new Texture2D(_graphics.GraphicsDevice, (int)_player.Width, (int)_player.Height);
            _enemyTexture = new Texture2D(_graphics.GraphicsDevice, (int)_enemy.Width, (int)_enemy.Height);

            _playerColor = new Color[_playerTexture.Width * _playerTexture.Height];
            _enemyColor = new Color[_enemyTexture.Width * _enemyTexture.Height];

            for (int i = 0; i < _playerColor.Length; i++) _playerColor[i] = Color.Red;
            for (int i = 0; i < _enemyColor.Length; i++) _enemyColor[i] = Color.Blue;

            _playerPos = new Vector2(_player.X, _player.Y);
            _enemyPos = new Vector2(_enemy.X, _enemy.Y);
            _playerTexture.SetData(_playerColor);
            _enemyTexture.SetData(_enemyColor);
        }

        private void RellocateTextures()
        {
            _playerPos.X = _player.X;
            _playerPos.Y = _player.Y;
            _enemyPos.X = _enemy.X;
            _enemyPos.Y = _enemy.Y;
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

        public void Draw()
        {
            DrawCells();
            RellocateTextures();
            _spriteBatch.Draw(_playerTexture, _playerPos, Color.White);
            _spriteBatch.Draw(_enemyTexture, _enemyPos, Color.White);
        }
    }
}
