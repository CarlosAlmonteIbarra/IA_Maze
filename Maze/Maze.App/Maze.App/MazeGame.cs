using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Maze.Engine.Objects;

namespace Maze.App
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MazeGame : Microsoft.Xna.Framework.Game
    {
        #region Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        private GraphicsEngine _graphicsEngine;
        private LevelWorkflow _game;

        KeyboardState PreviousState;
        KeyboardState CurrentState;

        Color color;

        Texture2D Electivo;
        Rectangle elige;

        private GameScreen introScreen;
        private GameScreen winScreen;
        private GameScreen loseScreen;
        private GameScreen characterScreen;
        private GameScreen creditScreen;
        private GameScreen protoScreen;

        GameStates gameState = GameStates.IntroScreen;
        #endregion
        public MazeGame()
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
            // TODO: Add your initialization logic here
            this.graphics.ToggleFullScreen();
            font = Content.Load<SpriteFont>("GameFont");
            color = new Color(255, 255, 255);
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
            _graphicsEngine = new GraphicsEngine(graphics, spriteBatch, _game.CurrentLevel, this.Content);

            Electivo = Content.Load<Texture2D>("selector");
            elige = new Rectangle(35, 40, 50, 50);

            Rectangle fullScreenRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            introScreen = new GameScreen(this, "Prototipo", fullScreenRectangle);
            //creditScreen = new GameScreen(this, "Creditos", fullScreenRectangle);
            characterScreen = new GameScreen(this, "selectScreenFirst", fullScreenRectangle);
            //loseScreen = new GameScreen(this, "You suck!!!", fullScreenRectangle);
            //winScreen = new GameScreen(this, "You win!!!", fullScreenRectangle);
            //protoScreen = new GameScreen(this, "FONDO COMPLETO PROTOMAN", fullScreenRectangle);
            
            // TODO: use this.Content to load your game content here
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
            CurrentState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (gameState == GameStates.CharacterScreen)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    elige.X += 2;

                    if (elige.X >= 750)
                    {
                        elige.X = 750;
                        elige.X -= 2;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    elige.Y += 2;

                    if (elige.Y >= 430)
                    {
                        elige.Y = 430;
                        elige.Y -= 2;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    elige.X -= 2;

                    if (elige.X == 1)
                    {
                        elige.X = 1;
                        elige.X += 2;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    elige.Y -= 2;

                    if (elige.Y == 0)
                    {
                        elige.Y = 0;
                        elige.Y += 2;
                    }
                }

                if (elige.X >= 280 & elige.X <= 370 & elige.Y >= 150 & elige.Y <= 250 &
                    Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameStates.GameScreen;
                }

                if (elige.X >= 500 & elige.X <= 670 & elige.Y >= 150 & elige.Y <= 250 &
                    Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameStates.CreditScreen;
                }

            }

            if (gameState == GameStates.GameScreen)
            {
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
            }

            switch (gameState)
            {
                case GameStates.IntroScreen:
                    if (CurrentState.IsKeyUp(Keys.Enter) && PreviousState.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameStates.CharacterScreen;
                    }
                    break;

                case GameStates.CharacterScreen:
                    if (CurrentState.IsKeyUp(Keys.Enter) && PreviousState.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameStates.GameScreen;
                    }
                    break;
            }
            // TODO: Add your update logic here
            PreviousState = CurrentState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (gameState == GameStates.IntroScreen)
            {
                color.A++;
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);
                spriteBatch.Draw(introScreen.ScreenTexture, introScreen.ScreenFrame, Color.White);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);
                spriteBatch.DrawString(font, "PRESS START", new Vector2(250, 330), color);
                spriteBatch.End();
            }

            if (gameState == GameStates.CharacterScreen)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);
                spriteBatch.Draw(characterScreen.ScreenTexture, characterScreen.ScreenFrame, Color.White);
                spriteBatch.End();

                spriteBatch.Begin();
                spriteBatch.Draw(Electivo, elige, Color.White);
                spriteBatch.End();
            }
            if (gameState == GameStates.GameScreen)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);
                _graphicsEngine.Draw();
                spriteBatch.End();
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void LevelTransition()
        {
            _graphicsEngine.SetGameObjects(_game.CurrentLevel, this.Content);
        }

        private void ReturnToManu()
        {

        }

    }
}
