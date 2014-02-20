using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{

    public class MenuHighScores :  BaseGameScreen
    {
        MenuComponent menu;
        Texture2D image;            //background image
        Rectangle imageContainer;
        SpriteBatch spriteBatch;

        public MenuHighScores(Game game, SpriteBatch spriteBatch, SpriteFont font, Texture2D image) : base(game, spriteBatch)
        {
            this.image = image;
            this.spriteBatch = spriteBatch;

            string[] menuItems = new string[1] { "Back" };
            menu = new MenuComponent(game, menuItems, spriteBatch, font);
            imageContainer = new Rectangle(0, 0, Width, Height);
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