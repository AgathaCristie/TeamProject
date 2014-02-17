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
    //This is a game component that implements IUpdateable.
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private string[] menuItems;
        private int selectedIndex;

        private Color normal = Color.Chocolate;
        private Color selected = Color.Green;

        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        private KeyboardState keyboardState;
        private KeyboardState oldKeyboardState;

        private float width;
        private float height;
        private Vector2 position;
        private SoundEffect soundEffect;

        public MenuComponent(Game game, string[] items, SpriteBatch batch, SpriteFont font): base(game)
        {
            menuItems = items;
            spriteBatch = batch;
            spriteFont = font;
            soundEffect = game.Content.Load<SoundEffect>("sounds\\Menu");
            MeasureMenu();
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex < 0)
                    selectedIndex = menuItems.Length - 1;
                if (selectedIndex >= menuItems.Length)
                    selectedIndex = 0;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (CheckKey(Keys.Down))
            {
                soundEffect.Play();
                SelectedIndex++;
            }
            if (CheckKey(Keys.Up))
            {
                SelectedIndex--;
                soundEffect.Play();
            }
            base.Update(gameTime);
            oldKeyboardState = keyboardState;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Vector2 location = position;
            Color color;

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                    color = selected;
                else      
                    color = normal;

                    spriteBatch.DrawString(spriteFont, menuItems[i], location, color);
                    location.Y += spriteFont.LineSpacing + 30;       //draws strings on different lines          
            }
        }
       
        private void MeasureMenu()
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                    width = size.X;
                height += spriteFont.LineSpacing + 4;
            }

            position = new Vector2(
                (Game.Window.ClientBounds.Width - width) / 2,
                (Game.Window.ClientBounds.Height - height) / 6);
        }
        private bool CheckKey(Keys key)
        {
            return keyboardState.IsKeyUp(key) && oldKeyboardState.IsKeyDown(key);
        }
    }
}
