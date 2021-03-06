using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Maze.Engine;

namespace Maze.Test.XNAApp
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private GraphicsEngine _graphicsEngine;
        private LevelWorkflow _game;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _game = new LevelWorkflow(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            _game.OnLevelFinished += this.LevelTransition;
            _game.OnGameFinished += this.ReturnToManu;
            _graphicsEngine = new GraphicsEngine(graphics, spriteBatch, _game.CurrentLevel);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _game.CurrentLevel.MoveRight();
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _game.CurrentLevel.MoveLeft();
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _game.CurrentLevel.MoveUp();
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _game.CurrentLevel.MoveDown();

            _game.CurrentLevel.Tick();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            _graphicsEngine.Draw();
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void LevelTransition()
        {
            _graphicsEngine.SetGameObjects(_game.CurrentLevel);
        }

        private void ReturnToManu()
        {

        }

    }
}
