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

namespace Test
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero JohnSnow;

        const int WIDTH = 800;
        const int HEIGHT = 600;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
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
            JohnSnow = new Hero(Content, WIDTH, HEIGHT);

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

            MoveHero();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Khaki);

            spriteBatch.Begin();
            JohnSnow.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void MoveHero()
        {
                KeyboardState keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.Right))
                {
                    JohnSnow.Update(1,0);
                }
                else if(keyState.IsKeyDown(Keys.Left))
                {
                    JohnSnow.Update(-1,0);
                    //turn image left . Add more images to array
                }
                else if(keyState.IsKeyDown(Keys.Up))
                {
                    JohnSnow.Update(0, -1);
                }
                else if (keyState.IsKeyDown(Keys.Down))
                {
                    JohnSnow.Update(0, 1);
                }
                else if (keyState.IsKeyDown(Keys.Space))
                {
                    //fire, hit, open, etc...
                }
                else if (keyState.IsKeyDown(Keys.P))
                {
                    //pause game
                }
        }
    }
}
