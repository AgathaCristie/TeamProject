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
using RPG.Monsters;
using RPG.Shots;

namespace RPG
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WIDTH = 800;
        const int HEIGHT = 600;
        int heroSpeed = 8;          //controls the pace at which movement images change in Update()
        
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
        Troll monster = new Troll(); //didi++
        Magician magician = new Magician(); //didi++
        Shooter shooter = new Shooter(); //didi++
        FireBall fireBall = new FireBall(); //didi++
        Camera cam;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            monster.Initialize(); //didi++
            magician.Initialize(); //didi++
            shooter.Initialize(); //didi++
            fireBall.Initialize(); //didi++
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //BUG : Pressing Enter in Menu Use oldstate?
            //TODO : Move Camera to GameStartScreen?
            //TODO : Restrict camera movement

            spriteBatch = new SpriteBatch(GraphicsDevice);
            fontMenu = Content.Load<SpriteFont>("fonts\\MenuFont");
            imgMenuBackground = Content.Load<Texture2D>("images\\MenuBackground");
            imgGameStartBackground = Content.Load<Texture2D>("images\\Level1");

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
            monster.LoadContent(Content); //didi ++ 
            magician.LoadContent(Content); //didi ++
            shooter.LoadContent(Content); //didi ++
            fireBall.LoadContent(Content); //didi ++
            cam = new Camera(GraphicsDevice.Viewport, JohnSnow);
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
                    JohnSnow.Update();  //Update the position of the hero

                if (--heroSpeed < 0) heroSpeed = 5;
                monster.Update(gameTime); //didi++     
                magician.Update(gameTime); //didi++
                shooter.Update(gameTime); //didi++
                fireBall.SpriteAnimation.Active = true;//didi++                
                fireBall.Update(gameTime, JohnSnow.ImageContainer.X, JohnSnow.ImageContainer.Y); //didi++
            }
            cam.Update(gameTime, this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,cam.Transform);
            
            base.Draw(gameTime);
            monster.Draw(spriteBatch); //didi++
            magician.Draw(spriteBatch); //didi++
            shooter.Draw(spriteBatch); //didi++
            fireBall.Draw(spriteBatch); //didi++
            spriteBatch.End();           
        }

        

    }
}
