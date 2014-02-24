using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using RPG.Heroes;
using Microsoft.Xna.Framework.Audio;

namespace RPG
{
    public class GameStartScreen : BaseGameScreen
    {
        private static int CONTAINER_SIZE = 2048; // Size of the background image
        private KeyboardState keyboardState;
        private Texture2D imgBackgound;
        private Rectangle imgBackGroundContainer;
        private SpriteBatch spriteBatch;
        private Hero hero;
        private SpriteFont fontMenu;

        public GameStartScreen(Game game, SpriteBatch sprite, Texture2D image) : base(game, sprite)
        {
            this.imgBackgound = image;
            this.spriteBatch = sprite;
            imgBackGroundContainer = new Rectangle(0, 0, CONTAINER_SIZE, CONTAINER_SIZE);
            hero = new Hero(game.Content, game.Content.Load<SoundEffect>("sounds\\SwordEffect"), Width, Height);
            fontMenu = game.Content.Load<SpriteFont>("fonts\\MenuFont");
        }
        
        public Hero Hero
        {
            get { return hero; }
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Game.Exit(); 
 
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(imgBackgound, imgBackGroundContainer, Color.White);
            hero.Draw(spriteBatch);
            base.Draw(gameTime);    
        }


        //Write Text On Screen
        public void WriteText(SpriteFont font, SpriteBatch sprite, string text, Color c )
        {
            sprite.DrawString(font, text, new Vector2(120,190), c);
            //Add rectangle or border around text
        }
        
    }
}
