namespace RPG.Heroes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public abstract class Player : IHeroes
    {
        protected int startX = 160;                //initial position of player
        protected int startY = 250;

        protected Rectangle imageContainer;
        protected Texture2D[] images = new Texture2D[4];      //Holds four images for the movement of the hero
        protected Texture2D[] imagesLeft = new Texture2D[4];
        protected Texture2D defaultImage;                     //starting image

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

        //Abstract methods
        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
