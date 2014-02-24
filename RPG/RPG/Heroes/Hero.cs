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

    public class Hero : Player, IHeroes
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
            this.Images[0] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMove1");
            this.Images[1] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMove2");
            this.Images[2] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMove3");
            this.Images[3] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMove4");

            //Loads The images from the files when the hero is going left
            this.ImagesLeft[0] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMoveLeft1");
            this.ImagesLeft[1] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMoveLeft2");
            this.ImagesLeft[2] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMoveLeft3");
            this.ImagesLeft[3] = manager.Load<Texture2D>("sprites\\HeroMoves\\HeroMoveLeft4");

            this.imageAttack = manager.Load<Texture2D>("sprites\\HeroMoves\\Hit");
            this.imageAttackLeft = manager.Load<Texture2D>("sprites\\HeroMoves\\HitLeft");
            this.DefaultImage = this.Images[0];

            //Create a rectangle for the hero
            this.ImageContainer = new Rectangle(160, 250, this.DefaultImage.Width, this.DefaultImage.Height);
        }
    }
}
