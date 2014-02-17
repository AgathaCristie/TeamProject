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
using RPG.Heroes;

namespace RPG
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WIDTH = 800;
        const int HEIGHT = 600;
        int heroSpeed = 8;          //controls the pace at which movement images change in Update()
        int heroMovement = 3;       //controls the speed of the hero in MoveHero()

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fontMenu;

        Texture2D imgMenuBackground;            //background image
        Texture2D imgGameStartBackground;
        BaseGameScreen activeScreen;
        MenuStartScreen startScreen;
        MenuHighScores scoresScreen;
        MenuControls controlsScreen;
        GameStartScreen gameStartScreen;

        Hero JohnSnow;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fontMenu = Content.Load<SpriteFont>("fonts\\MenuFont");
            imgMenuBackground = Content.Load<Texture2D>("images\\MenuBackground");
            imgGameStartBackground = Content.Load<Texture2D>("images\\BattleScreen1");

            startScreen = new MenuStartScreen(this, spriteBatch, fontMenu, imgMenuBackground);
            gameStartScreen = new GameStartScreen(this, spriteBatch, imgGameStartBackground);
            scoresScreen = new MenuHighScores(this, spriteBatch, fontMenu, imgMenuBackground);
            controlsScreen = new MenuControls(this, spriteBatch, fontMenu, imgMenuBackground);

            Components.Add(startScreen);
            Components.Add(gameStartScreen);
            Components.Add(scoresScreen);
            Components.Add(controlsScreen);

            gameStartScreen.Hide();
            scoresScreen.Hide();
            controlsScreen.Hide();
            activeScreen = startScreen;
            activeScreen.Show();

            JohnSnow = gameStartScreen.Hero;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Switch between screens
            if(activeScreen == startScreen)
            {
                KeyboardState state = Keyboard.GetState();
                if(state.IsKeyDown(Keys.Enter) && (startScreen.SelectedIndex == 0 ))
                {
                    activeScreen.Hide();
                    activeScreen = gameStartScreen;
                    activeScreen.Show();
                }
                if (state.IsKeyDown(Keys.Enter) && (startScreen.SelectedIndex == 2))
                {
                    activeScreen.Hide();
                    activeScreen = scoresScreen;
                    activeScreen.Show();
                }
                if (state.IsKeyDown(Keys.Enter) && (startScreen.SelectedIndex == 1))
                {
                    activeScreen.Hide();
                    activeScreen = controlsScreen;
                    activeScreen.Show();
                }
                if (state.IsKeyDown(Keys.Enter) && (startScreen.SelectedIndex == 3))
                {
                    this.Exit();
                }
            }

            //Control for each screen
            else if(activeScreen == scoresScreen)
            {
                //BUG : Pressing Enter Use oldstate?
                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.Enter))
                {
                    activeScreen.Hide();
                    activeScreen = startScreen;
                    activeScreen.Show();
                }
            }
            else if (activeScreen == controlsScreen)
            {
                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.Enter))
                {
                    activeScreen.Hide();
                    activeScreen = startScreen;
                    activeScreen.Show();
                }
            }
            else if (activeScreen == gameStartScreen)
            {
                if (heroSpeed == 0)
                    MoveHero();

                if (--heroSpeed < 0) heroSpeed = 5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            base.Draw(gameTime);
            spriteBatch.End();           
        }

        public void MoveHero()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Right))
            {
                JohnSnow.IsLeft = false;
                JohnSnow.Update(heroMovement, 0);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                JohnSnow.IsLeft = true;         //turns hero to the left
                JohnSnow.Update(-heroMovement, 0);
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                JohnSnow.Update(0, -heroMovement);
            }
            else if (keyState.IsKeyDown(Keys.Down))
            {
                JohnSnow.Update(0, heroMovement);
            }
            else if (keyState.IsKeyDown(Keys.Space))
            {
                //fire, hit, open, etc...
            }
            else if (keyState.IsKeyDown(Keys.P))
            {
               
            }

        }

    }
}
