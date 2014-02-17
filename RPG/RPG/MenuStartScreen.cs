using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class MenuStartScreen : BaseGameScreen
    {
        MenuComponent menu;
        Texture2D image;            //background image
        Rectangle imageContainer;
        SpriteBatch spriteBatch;

        public MenuStartScreen(Game game, SpriteBatch sprite, SpriteFont font, Texture2D image) : base(game, sprite)
        {
            string[] menuItems = { "New Game", "Controls", "High Scores", "Exit Game" };
            menu = new MenuComponent(game, menuItems, sprite, font);           
            this.image = image;
            spriteBatch = sprite;            
            imageContainer = new Rectangle(0, 0, 800, 600);
            Components.Add(menu);
        }

        public int SelectedIndex
        {
            get { return menu.SelectedIndex; }
            set { menu.SelectedIndex = value; }
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