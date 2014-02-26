﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG.Monsters
{
    public class Magician : Monster
    {
        //Texture2D playerImage;
        //Vector2 playerPosition, tempCurrentFrame;
        //Animation playerAnimation = new Animation();
        //Vector2 velocity = new Vector2(1, 0);       
        //Rectangle playZone = new Rectangle(900, 100, 325, 145);

        //KeyboardState keyState;
        //float moveSpeed = 150;
        
        public Magician()
        {
            playerAnimation = new Animation();
            velocity = new Vector2(1, 0);
            playZone = new Rectangle(900, 100, 325, 145);
            moveSpeed = 150;
            playerPosition = new Vector2(900, 100);
            playerAnimation.Initialize(playerPosition, new Vector2(3, 2));
            playerAnimation.Active = true;
            tempCurrentFrame = Vector2.Zero;
        }

        //public void Initialize()
        //{
        //    playerPosition = new Vector2(900, 100);
        //    playerAnimation.Initialize(playerPosition, new Vector2(3, 2));
        //    playerAnimation.Active = true;
        //    tempCurrentFrame = Vector2.Zero;
        //}

        public override void LoadContent(ContentManager Content)
        {
            PlayerImage = Content.Load<Texture2D>("sprites/Magician");
            playerAnimation.AnimationImage = PlayerImage;
        }

        public void Update(GameTime gameTime)
        {
            //keyState = Keyboard.GetState();
            playerAnimation.Active = true;


            if (playerPosition.X < playZone.X)
            {
                velocity.X = 0;
                velocity.Y = 1;
                playerPosition.X = playZone.X;
                tempCurrentFrame.Y = 0;
            }
            if (playerPosition.X > playZone.X + playZone.Width)
            {
                velocity.X = 0;
                velocity.Y = -1;
                playerPosition.X = playZone.X + playZone.Width;
                tempCurrentFrame.Y = 3;
            }
            if (playerPosition.Y < playZone.Y)
            {
                velocity.Y = 0;
                velocity.X = -1;
                playerPosition.Y = playZone.Y;
                tempCurrentFrame.Y = 1;
            }
            if (playerPosition.Y > playZone.Y + playZone.Height)
            {
                velocity.Y = 0;
                velocity.X = 1;
                playerPosition.Y = playZone.Y + playZone.Height;
                tempCurrentFrame.Y = 2;
            }

            //playerPosition.X += velocity.X * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //playerPosition.Y += velocity.Y * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            playerAnimation.Position = playerPosition;
            tempCurrentFrame.X = playerAnimation.CurrentFrame.X;
            playerAnimation.CurrentFrame = tempCurrentFrame;
            playerAnimation.Update(gameTime);
        }               
    }
}
