namespace RPG.Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Hero : Player
    {
        //Fields
        private int windowHeight;
        private int windowWidth;

        //Constructor
        public Hero(ContentManager manager, int width, int height)
        {
            windowWidth = width;
            windowHeight = height;

            //Loads The images from the files when the hero is going right
            this.Images[0] = manager.Load<Texture2D>("sprites\\Move1");
            this.Images[1] = manager.Load<Texture2D>("sprites\\Move2");
            this.Images[2] = manager.Load<Texture2D>("sprites\\Move3");
            this.Images[3] = manager.Load<Texture2D>("sprites\\Move4");

            //Loads The images from the files when the hero is going left
            this.ImagesLeft[0] = manager.Load<Texture2D>("sprites\\MoveLeft1");
            this.ImagesLeft[1] = manager.Load<Texture2D>("sprites\\MoveLeft2");
            this.ImagesLeft[2] = manager.Load<Texture2D>("sprites\\MoveLeft3");
            this.ImagesLeft[3] = manager.Load<Texture2D>("sprites\\MoveLeft4");
            this.DefaultImage = this.Images[0];

            //Create a rectangle for the hero
            this.ImageContainer = new Rectangle(160, 250, this.DefaultImage.Width, this.DefaultImage.Height);
        }
    }
}
