namespace RPG.Heroes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    public abstract class Player : IHeroes
    {
        protected int startX = 160;                          //initial position of player
        protected int startY = 250;

        protected Rectangle imageContainer;
        protected Texture2D imageAttack;
        protected Texture2D imageAttackLeft;
        protected Texture2D[] images = new Texture2D[4];      //Holds four images for the movement of the hero
        protected Texture2D[] imagesLeft = new Texture2D[4];
        protected Texture2D defaultImage;                     //starting image
        protected int count = 0;                              //counts images' index in Update()
        protected bool isLeft = false;                        //checks if the hero is turned to the left
        protected int heroMovement = 10;                      //controls the speed of the hero in MoveHero()

        //Properties
        public Rectangle ImageContainer
        {
            get { return this.imageContainer; }
            set { this.imageContainer = value; }
        }
        
        public Texture2D[] Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
        
        public Texture2D[] ImagesLeft
        {
            get { return this.imagesLeft; }
            set { this.imagesLeft = value; }
        }
        
        public Texture2D DefaultImage
        {
            get { return this.defaultImage; }
            set { this.defaultImage = value; }
        }

        public int StartX
        {
            get { return startX; }
        }
        public int StartY
        {
            get { return startY; }
        }


        //IsLeft property
        public bool IsLeft
        {
            get { return this.isLeft; }
            set { this.isLeft = value; }
        }

        //the Update() method
        public void Update()
        {   
            //Attack
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if(this.isLeft == false)
                    this.defaultImage = imageAttack;
                else
                    this.defaultImage = imageAttackLeft;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                if (this.isLeft == false)
                    this.DefaultImage = this.Images[0];
                else
                    this.DefaultImage = this.ImagesLeft[0];
            }

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

        //the Draw() method
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.DefaultImage, this.ImageContainer, Color.White);
        }
    }
}
