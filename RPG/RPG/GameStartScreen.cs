using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using RPG.Heroes;

namespace RPG
{
    public class GameStartScreen : BaseGameScreen
    {
        KeyboardState keyboardState;
        Texture2D imgBackgound;
        Rectangle imgBackGroundContainer;
        SpriteBatch spriteBatch;
        //ContentManager parentContent;
        //Hero hero;

        public GameStartScreen(Game game, SpriteBatch sprite, Texture2D image) : base(game, sprite)
        {
            this.imgBackgound = image;
            this.spriteBatch = sprite;
            imgBackGroundContainer = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
        }

        //public GameStartScreen(Game game, SpriteBatch sprite, Texture2D image, ContentManager mngr): base(game, sprite)
        //{
        //    this.imgBackgound = image;
        //    this.spriteBatch = sprite;
        //    this.parentContent = mngr;
        //    imgBackGroundContainer = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
        //}


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
            base.Draw(gameTime);
  
            //hero.Draw(spriteBatch);
         
        }

    }
}
