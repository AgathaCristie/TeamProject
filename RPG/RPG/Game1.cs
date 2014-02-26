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
using RPG.AddOns; //monsters

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
        Texture2D imgMenuStats;
        BaseGameScreen activeScreen;
        MenuStartScreen startScreen;
        MenuHighScores scoresScreen;
        MenuControls controlsScreen;
        MenuStats statsScreen;
        GameStartScreen gameStartScreen;

        Hero JohnSnow;
        Troll monster = new Troll(); //monsters 
        Magician magician = new Magician(); //monsters
        Shooter shooter = new Shooter(); //monsters
        FireBall fireBall = new FireBall(); //monsters
        Mace mace = new Mace(); //monsters
        //HpBar hpBar = new HpBar(); //monsters
        Camera cam;
        HpBar hpBar;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {       
            fireBall.Initialize(); //monsters
            mace.Initialize(); //monsters
            base.Initialize();
        }

        protected override void LoadContent()
        {

            hpBar = new HpBar();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fontMenu = Content.Load<SpriteFont>("fonts\\MenuFont");
            imgMenuBackground = Content.Load<Texture2D>("images\\MenuBackground");
            imgGameStartBackground = Content.Load<Texture2D>("images\\Level1");
            imgMenuStats = Content.Load<Texture2D>("images\\MenuStats");

            startScreen = new MenuStartScreen(this, spriteBatch, fontMenu, imgMenuBackground);
            gameStartScreen = new GameStartScreen(this, spriteBatch, imgGameStartBackground);
            scoresScreen = new MenuHighScores(this, spriteBatch, fontMenu, imgMenuBackground);
            controlsScreen = new MenuControls(this, spriteBatch, fontMenu, imgMenuBackground);
            statsScreen = new MenuStats(this, spriteBatch, fontMenu, imgMenuStats, JohnSnow);

            Components.Add(startScreen);
            Components.Add(gameStartScreen);
            Components.Add(scoresScreen);
            Components.Add(controlsScreen);
            Components.Add(statsScreen);

            gameStartScreen.Hide();
            scoresScreen.Hide();
            controlsScreen.Hide();
            statsScreen.Hide();
            activeScreen = startScreen;
            activeScreen.Show();

            JohnSnow = gameStartScreen.Hero;
            monster.LoadContent(Content); //monsters 
            magician.LoadContent(Content); //monsters
            shooter.LoadContent(Content); //monsters
            fireBall.LoadContent(Content); //monsters
            mace.LoadContent(Content); //monsters
            hpBar.LoadContent(Content); //monsters
            cam = new Camera(GraphicsDevice.Viewport, JohnSnow);

            //Play background music
            MediaPlayer.Play(Content.Load<Song>("sounds\\Mad-Man-'s-Chase"));
            MediaPlayer.Volume = 0.2f;
            MediaPlayer.IsRepeating = true;          
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
                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.Tab))
                {
                    statsScreen.Show();
                }
                if (state.IsKeyUp(Keys.Tab))
                {
                    statsScreen.Hide();
                }
                
                if (heroSpeed == 0)
                    JohnSnow.Update();  //Update the position of the hero

                if (--heroSpeed < 0) heroSpeed = 5;

                monster.Update(gameTime); //monsters ++     
                magician.Update(gameTime); //monsters ++
                shooter.Update(gameTime, JohnSnow, mace); //monsters ++
                fireBall.SpriteAnimation.Active = true;//monsters ++                    
                fireBall.Update(gameTime, JohnSnow); //monsters ++
                mace.Update(gameTime, JohnSnow); //monsters ++
                hpBar.Update(JohnSnow); //monsters ++

                //If hero is dead end the game
                if (hpBar.isDeadHero)
                {
                    // TODO:

                }
                
            }
            cam.Update(gameTime, this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,cam.Transform);
            
            base.Draw(gameTime);
            monster.Draw(spriteBatch); //monsters
            magician.Draw(spriteBatch); //monsters
            shooter.Draw(spriteBatch); //monsters
            fireBall.Draw(spriteBatch); //monsters
            mace.Draw(spriteBatch); //monsters
            hpBar.Draw(spriteBatch); //monsters
            spriteBatch.End();           
        }

        

    }
}
