using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Heroes;


namespace RPG
{
    public class Camera 
    {
        private Matrix transform;      //draw camera
        Viewport view;                  //viewpoint
        Vector2 centre;
        Hero hero;

        public Camera(Viewport view, Hero hero)
        {
            this.view = view;
            this.hero = hero;
        }

        public Matrix Transform
        {
            get { return transform; }
        }

        public void Update(GameTime gametTime, Game1 game)
        {
            //sets constraints for the camera
            if ((hero.ImageContainer.X <= hero.StartX) && (hero.ImageContainer.Y < hero.StartY))
            {
                centre = new Vector2(hero.StartX + (hero.ImageContainer.Width / 2) - 195, hero.StartY + (hero.ImageContainer.Height / 2) - 295);
            }
            else if ((hero.ImageContainer.X <= hero.StartX))
            {
                centre = new Vector2(hero.StartX + (hero.ImageContainer.Width / 2) - 195, hero.ImageContainer.Y + (hero.ImageContainer.Height / 2) - 295);
            }
            else if ((hero.ImageContainer.Y < hero.StartY))
            {
                centre = new Vector2(hero.ImageContainer.X + (hero.ImageContainer.Width / 2) - 195, hero.StartY + (hero.ImageContainer.Height / 2) - 295);
            }
            else
                centre = new Vector2(hero.ImageContainer.X + (hero.ImageContainer.Width / 2) - 195, hero.ImageContainer.Y + (hero.ImageContainer.Height / 2) - 295);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }
    }
}
