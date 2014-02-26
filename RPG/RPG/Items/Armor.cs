using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Armor
    {
        public enum slot
        {
            Head,
            Body,
            Hands,
            Feet
        }
        public slot Slot { get; protected set; }
        public string Name { get; protected set; }

        public uint Resistance { get; protected set; }
        public string ImagePath { get; protected set; }

        private Texture2D image;
        private Rectangle imageContainer;

        public Armor(Armor.slot Slot, string Name, uint Resistance, string ImagePath, SpriteBatch spriteBatch, Game game)
        {
            this.Slot = Slot;
            this.Name = Name;
            this.Resistance = Resistance;
            this.ImagePath = ImagePath;
            this.image = game.Content.Load<Texture2D>(ImagePath);
            this.imageContainer = new Rectangle(30, 510, image.Width, image.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.imageContainer, Color.White);
        }
    }
}
