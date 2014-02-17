using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Heroes
{
    public class Hero
    {
        private Rectangle imageContainer;
        private Texture2D[] images = new Texture2D[4];      //Holds four images for the movement of the hero
        private Texture2D defaultImage;                     //starting image

        private int windowHeight;
        private int windowWidth;
        private int count = 0;      //counts images' index in Update()

        public Hero(ContentManager manager, int width, int height)
        {
            windowWidth = width;
            windowHeight = height;
            //Loads The images from the files
            images[0] = manager.Load<Texture2D>("sprites\\Move1");
            images[1] = manager.Load<Texture2D>("sprites\\Move2");
            images[2] = manager.Load<Texture2D>("sprites\\Move3");
            images[2] = manager.Load<Texture2D>("sprites\\Move4");
            defaultImage = images[0];
            imageContainer = new Rectangle(60, 250, defaultImage.Width, defaultImage.Height);
        }

        public void Update(int x, int y)
        {

            //Moves and updates the image
            imageContainer.X += (x);
            imageContainer.Y += (y);
            defaultImage = images[count];
            count++;
            if (count == images.Length - 1)
                count = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(defaultImage, imageContainer, Color.White);
        }
    }
}
