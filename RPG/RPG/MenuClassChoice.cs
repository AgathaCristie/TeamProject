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

namespace RPG
{

    public class MenuClassChoice : BaseGameScreen
    {
        MenuComponent menu;
        Texture2D image;            //background image
        Rectangle imageContainer;
        SpriteBatch spriteBatch;

        public MenuClassChoice(Game game, SpriteBatch spriteBatch, SpriteFont font, Texture2D image): base(game, spriteBatch)
        {
            this.image = image;
            this.spriteBatch = spriteBatch;
            string[] types = new string[3]{"Warrior","Wizard","Archer"};    //Replace with Images
            imageContainer = new Rectangle(0, 0, Width, Height);
            menu = new MenuComponent(game, types, spriteBatch, font);
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
    }
}
