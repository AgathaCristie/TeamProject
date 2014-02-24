namespace RPG.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using RPG.Heroes;
    using RPG.Monsters;

    public abstract class BaseItem : IEquipable
    {
        public Animation ImageAnimation;
        public Texture2D Image;
        public string ImagePath { get; protected set; }
        public string Name { get; protected set; }
        public bool Equipped { get; protected set; }

        public BaseItem(string name, string imagePath)
        {
            this.Name = name;
            this.ImagePath = imagePath;
            this.Equipped = false;
            ImageAnimation = new Animation();
        }

        public void LoadContent(ContentManager content)
        {
            Image = content.Load<Texture2D>(this.ImagePath);
            ImageAnimation.AnimationImage = Image;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public abstract void Equip(Player player);
    }
}
