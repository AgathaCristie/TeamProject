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
        private Texture2D[] imagesLeft = new Texture2D[4];
        private Texture2D defaultImage;                     //starting image

        private int windowHeight;
        private int windowWidth;
        private int count = 0;              //counts images' index in Update()
        private bool isLeft = false;        //checks if the hero is turned to the left

        public Hero(ContentManager manager, int width, int height)
        {
            windowWidth = width;
            windowHeight = height;
            //Loads The images from the files
            images[0] = manager.Load<Texture2D>("sprites\\Move1");
            images[1] = manager.Load<Texture2D>("sprites\\Move2");
            images[2] = manager.Load<Texture2D>("sprites\\Move3");
            images[3] = manager.Load<Texture2D>("sprites\\Move4");
            imagesLeft[0] = manager.Load<Texture2D>("sprites\\MoveLeft1");
            imagesLeft[1] = manager.Load<Texture2D>("sprites\\MoveLeft2");
            imagesLeft[2] = manager.Load<Texture2D>("sprites\\MoveLeft3");
            imagesLeft[3] = manager.Load<Texture2D>("sprites\\MoveLeft4");
            defaultImage = images[0];
            imageContainer = new Rectangle(160, 250, defaultImage.Width, defaultImage.Height);
        }

        public Rectangle ImgageContainer
        {
            get { return imageContainer; }
        }     

        public void Update(int x, int y)
        {
            if(isLeft == true)
                defaultImage = imagesLeft[count];
            if(isLeft == false)
                defaultImage = images[count];
 
            imageContainer.X += (x);        //moves the images
            imageContainer.Y += (y);
            count++;
            if (count == images.Length - 1)
                count = 0;
        }

        public bool IsLeft
        {
            set { isLeft = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(defaultImage, imageContainer, Color.White);
        }
    }
}
