using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Heroes
{
    public class Archer : Player, IHeroes
    {
        //Fields
        private int windowHeight;
        private int windowWidth;

        //Constru
        public Archer(ContentManager manager, int width, int height)
        {
            windowWidth = width;
            windowHeight = height;

            //Loads The images from the files when the hero is going right
            this.Images[0] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMove1");
            this.Images[1] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMove2");
            this.Images[2] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMove3");
            this.Images[3] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMove4");

            //Loads The images from the files when the hero is going left
            this.ImagesLeft[0] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMoveLeft1");
            this.ImagesLeft[1] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMoveLeft2");
            this.ImagesLeft[2] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMoveLeft3");
            this.ImagesLeft[3] = manager.Load<Texture2D>("sprites\\ArcherMoves\\ArcherMoveLeft4");
            this.DefaultImage = this.Images[0];

            //Create a rectangle for the hero
            this.ImageContainer = new Rectangle(160, 250, this.DefaultImage.Width, this.DefaultImage.Height);
        }
    }
}
