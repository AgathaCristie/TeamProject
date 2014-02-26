namespace RPG.Heroes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RPG.Monsters;
    public abstract class Player : IHeroes, IDamageMaking, IDamageTaking
    {
        protected int startX = 160;                          //initial position of player
        protected int startY = 250;
        protected bool accessible;
        protected double life = 30;                          //In order to use hpBar life field is needed

        protected Rectangle imageContainer;
        protected Texture2D imageAttack;
        protected Texture2D imageAttackLeft;
        protected Texture2D[] images = new Texture2D[4];      //Holds four images for the movement of the hero
        protected Texture2D[] imagesLeft = new Texture2D[4];
        protected Texture2D defaultImage;                     //starting image
        protected SoundEffect sound;
        protected int count = 0;                              //counts images' index in Update()
        protected bool isLeft = false;                        //checks if the hero is turned to the left
        protected int heroMovement = 10;                      //controls the speed of the hero in MoveHero()

        //Properties
        public double Life
        {
            get { return this.life; }
            set { this.life = value; }
        }
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

        public SoundEffect Sound
        {
            get { return this.sound; }
            set { this.sound = value; }
        }

        public int StartX
        {
            get { return startX; }
        }
        public int StartY
        {
            get { return startY; }
        }

        public int CurrentHealth { get; set; }
        public int DamageInflict { get; set; }
        public int DamageResist { get; set; }

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

                //Play sword slash sound
                this.PlaySound();
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
                if(imageContainer.X >= 0)
                    this.imageContainer.X -= heroMovement;

            }

            // Movement up
            if (Keyboard.GetState().IsKeyDown(Keys.Up)
                || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                if (this.IsLeft == true)
                {
                    this.DefaultImage = this.ImagesLeft[count];
                    if (imageContainer.Y >= 1)                       
                        this.imageContainer.Y -= heroMovement;
                }
                else if (this.IsLeft == false)
                {
                    this.DefaultImage = this.Images[count];
                    if (imageContainer.Y >= 1)
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

                    accessible = MovementControl();
                    if (accessible == true)
                    this.imageContainer.Y += heroMovement;
                }
                else if (this.IsLeft == false)
                {
                    this.DefaultImage = this.Images[count];

                    accessible = MovementControl();
                    if (accessible == true)
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

        //Method for making sound when hero attack
        public void PlaySound(float volume = 0.5f)
        {
            this.sound.Play(volume, 0.5f, 0.5f);
        }

        public void InflictDamage(Monster monster)
        {
            int damageInflicted = this.DamageInflict - monster.DamageResist;
            if (damageInflicted > 0)
            {
                monster.CurrentHealth -= damageInflicted;
            }
        }
        //160,250
        public bool MovementControl()
        {
            bool isAccessible = true;

            if ((imageContainer.Y == 250) && (imageContainer.X <= 305))
                isAccessible = false;
            else if ((imageContainer.Y == 250) && ((imageContainer.X >= 335) && (imageContainer.X <= 620)))
                isAccessible = false;

            return isAccessible;
        }

        public bool isAlive()
        {
            bool alive = true;
            if (life <= 0)
                alive = false;

            return alive;
        }
    }
}
