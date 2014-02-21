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
        private int count = 0;              //counts images' index in Update()
        private bool isLeft = false;        //checks if the hero is turned to the left
        private int heroMovement = 10;       //controls the speed of the hero in MoveHero()

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

        //IsLeft property
        public bool IsLeft
        {
            get { return this.isLeft; }
            set { this.isLeft = value; }
        }

        //Override the Update() method
        public override void Update()
        {
            // Movement right
            if (Keyboard.GetState().IsKeyDown(Keys.Right)
                || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                // the X coordinate of the rectangle will increase depending on the movement speed
                this.IsLeft = false;
                this.DefaultImage = this.Images[count];
                this.imageContainer.X += heroMovement;
            }

            // Movement left
            if (Keyboard.GetState().IsKeyDown(Keys.Left)
                || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                this.IsLeft = true;
                this.DefaultImage = this.ImagesLeft[count];
                this.imageContainer.X -= heroMovement;
            }

            // Movement up
            if (Keyboard.GetState().IsKeyDown(Keys.Up)
                || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                if (this.IsLeft == true)
                {
                    this.DefaultImage = this.ImagesLeft[count];
                    this.imageContainer.Y -= heroMovement;
                }
                else if (this.IsLeft == false)
                {
                    this.DefaultImage = this.Images[count];
                    this.imageContainer.Y -= heroMovement;
                }
                
            }

            // Movement down
            if (Keyboard.GetState().IsKeyDown(Keys.Down)
                || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                if (this.IsLeft == true)
                {
                    this.DefaultImage = this.ImagesLeft[count];
                    this.imageContainer.Y += heroMovement;
                }
                else if (this.IsLeft == false)
                {
                    this.DefaultImage = this.Images[count];
                    this.imageContainer.Y += heroMovement;
                }
                
            }

            count++;

            if (count == images.Length - 1)
            {
                count = 0;
            }
                
        }

        //Override the Draw() method
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.DefaultImage, this.ImageContainer, Color.White);
        }
    }
}
