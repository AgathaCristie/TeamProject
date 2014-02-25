using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Monsters;
using RPG.Heroes;

namespace RPG.Shots
{
    public class Mace
    {
        Texture2D objectImage;
        Vector2 objectPosition, tempCurrentFrame;
        Animation objectAnimation = new Animation();
        Vector2 velocity = new Vector2(1, 0);        
        Rectangle playZone = new Rectangle(100, 460, 1000, 1000);

        float moveSpeed = 120;

        public Vector2 MacePosition
        {
            get { return this.objectPosition; }
            set { this.objectPosition = value; }
        }
        public Animation SpriteAnimation
        {
            get { return this.objectAnimation; }
        }
        public void Initialize()
        {
            objectPosition = new Vector2(100, 460);
            objectAnimation.Initialize(objectPosition, new Vector2(11, 1));
            objectAnimation.Active = false;
            tempCurrentFrame = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content)
        {
            objectImage = Content.Load<Texture2D>("sprites/mace8");
            objectAnimation.AnimationImage = objectImage;
        }

        public void Update(GameTime gameTime, Hero hero)
        {
            int targetX = hero.ImageContainer.X;
            int targetY = hero.ImageContainer.Y;
            if
            (objectAnimation.Active == true)
            {
                float distance = Vector2.Distance(new Vector2(targetX, targetY), this.objectPosition);
                float rotation = (float)Math.Atan(distance);

                Vector2 velocityTmp = Vector2.Subtract(new Vector2(targetX, targetY), this.objectPosition);
                velocity.X = velocityTmp.X.CompareTo(0) * (float)Math.Sin(rotation);
                velocity.Y = velocityTmp.Y.CompareTo(0) * (float)Math.Sin(rotation);
                tempCurrentFrame.Y = 0;

                objectPosition.X += velocity.X * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                objectPosition.Y += velocity.Y * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                objectAnimation.Position = objectPosition;
                tempCurrentFrame.X = objectAnimation.CurrentFrame.X;
                objectAnimation.CurrentFrame = tempCurrentFrame;
                objectAnimation.Update(gameTime);

                if (tempCurrentFrame.X / objectAnimation.FrameWidth >= objectAnimation.AmountOfFrames.X - 1)
                {
                    objectAnimation.Active = false;
                    this.Initialize();
                }

                if (
                    (objectPosition.X >= hero.ImageContainer.X && objectPosition.X <= hero.ImageContainer.X + hero.ImageContainer.Width / 3) &&
                    (objectPosition.Y >= hero.ImageContainer.Y && objectPosition.Y <= hero.ImageContainer.Y + hero.ImageContainer.Height / 3)
                    )
                {
                    hero.Life = hero.Life - 0.2;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (objectAnimation.Active)
            {
                objectAnimation.Draw(spriteBatch);
            }
        }
    }
}
