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

    //TOD FIX POSITIONING
    public class MenuStats : BaseGameScreen
    {
        MenuComponent menu;
        Texture2D image;            //background image
        Rectangle imageContainer;
        SpriteBatch spriteBatch;
        Hero hero;

        public MenuStats(Game game, SpriteBatch spriteBatch, SpriteFont font, Texture2D image, Hero hero): base(game, spriteBatch)
        {
            this.image = image;
            this.spriteBatch = spriteBatch;
            this.hero = hero;
            string[] menuItems = new string[1] { "" };
            menu = new MenuComponent(game, menuItems, spriteBatch, font);
            imageContainer = new Rectangle(0, 0, Width , Height);
            Components.Add(menu);
            
        }

        public int SelectedIndex
        {
            get { return menu.SelectedIndex; }
            set { menu.SelectedIndex = value; }
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, imageContainer, Color.White);
            base.Draw(gameTime);
        }
    }
}
