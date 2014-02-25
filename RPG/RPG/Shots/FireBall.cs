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
    public class FireBall : Projectile
    {       
        public FireBall()
        {
            playerAnimation = new Animation();
            velocity = new Vector2(1, 0);
            playZone = new Rectangle(900, 100, 330, 140);
            moveSpeed = 100;           
        }

        public Animation SpriteAnimation
        {
            get { return this.playerAnimation; }
        }
        
        public void Initialize()
        {
            playerPosition = new Vector2(900, 100);            
            playerAnimation.Initialize(playerPosition, new Vector2(8, 1));
            playerAnimation.Active = true;
            tempCurrentFrame = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content)
        {
            playerImage = Content.Load<Texture2D>("sprites/FireBall");
            playerAnimation.AnimationImage = playerImage;
        }

        public void Update(GameTime gameTime, Hero hero)
        {
            int targetX = hero.ImageContainer.X;
            int targetY = hero.ImageContainer.Y;
            if
            (playerAnimation.Active == true)
            {
                float distance = Vector2.Distance(new Vector2(targetX, targetY), this.playerPosition);
                float rotation = (float)Math.Atan(distance);

                Vector2 velocityTmp = Vector2.Subtract(new Vector2(targetX, targetY), this.playerPosition);
                velocity.X = velocityTmp.X.CompareTo(0) * (float)Math.Sin(rotation);
                velocity.Y = velocityTmp.Y.CompareTo(0) * (float)Math.Sin(rotation);
                tempCurrentFrame.Y = 0;

                playerPosition.X += velocity.X * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                playerPosition.Y += velocity.Y * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                playerAnimation.Position = playerPosition;
                tempCurrentFrame.X = playerAnimation.CurrentFrame.X;
                playerAnimation.CurrentFrame = tempCurrentFrame;
                playerAnimation.Update(gameTime);

                if (tempCurrentFrame.X / playerAnimation.FrameWidth >= playerAnimation.AmountOfFrames.X - 1)
                {
                    playerAnimation.Active = false;
                    this.Initialize();
                }

                if (
                    (playerPosition.X >= hero.ImageContainer.X && playerPosition.X <= hero.ImageContainer.X + hero.ImageContainer.Width) &&
                    (playerPosition.Y >= hero.ImageContainer.Y && playerPosition.Y <= hero.ImageContainer.Y + hero.ImageContainer.Height)
                    )
                {
                    hero.Life = hero.Life - 0.2;
                }
            }
        }

    }
}
