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
            centre = new Vector2(hero.ImgageContainer.X + (hero.ImgageContainer.Width / 2) - 195, hero.ImgageContainer.Y + (hero.ImgageContainer.Height / 2)-295);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0) )* Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }
    }
}
