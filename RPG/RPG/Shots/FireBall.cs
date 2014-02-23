using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Monsters;

namespace RPG.Shots
{
    public class FireBall
    {
        Texture2D playerImage;
        Vector2 playerPosition, tempCurrentFrame;
        Animation playerAnimation = new Animation();        
        Vector2 velocity = new Vector2(1, 0);
        //Rectangle playZone = new Rectangle(340, 250, 330, 140);
        Rectangle playZone = new Rectangle(900, 100, 330, 140);

        KeyboardState keyState;
        float moveSpeed = 100;

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

        public void Update(GameTime gameTime, int targetX, int targetY)
        {
            //Vector2 distance = new Vector2(targetX - this.playerPosition.X, targetY - this.playerPosition.Y);    
            //Vector2 distance = new Vector2(this.playerPosition.X - targetX, this.playerPosition.Y - targetY);
            
            if
            (playerAnimation.Active == true)
            {
                float distance = Vector2.Distance(new Vector2(targetX, targetY), this.playerPosition);
                //float rotation = (float)Math.Atan2(distance.X, distance.Y);
                float rotation = (float)Math.Atan(distance);

                Vector2 velocityTmp = Vector2.Subtract(new Vector2(targetX, targetY), this.playerPosition);
                velocity.X = velocityTmp.X.CompareTo(0) * (float)Math.Sin(rotation);
                velocity.Y = velocityTmp.Y.CompareTo(0) * (float)Math.Sin(rotation);
                //velocity.X = (float)Math.Cos(rotation);
                //velocity.Y = (float)Math.Sin(rotation);
                //velocity.X = 1;
                //velocity.Y = 1; 
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
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerAnimation.Active)
            {
                playerAnimation.Draw(spriteBatch);
            }
        }

    }
}
