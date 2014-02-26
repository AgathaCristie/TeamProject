
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Heroes;
using RPG.Shots;

namespace RPG.Monsters
{
    public class Shooter : Monster
    {        
        public Shooter()
        {
            playerAnimation = new Animation();
            velocity = new Vector2(1, 0);
            playZone = new Rectangle(100, 460, 325, 145);
            moveSpeed = 150;
            playerPosition = new Vector2(200, 575);
            playerAnimation.Initialize(playerPosition, new Vector2(4, 2));
            playerAnimation.Active = true;
            tempCurrentFrame = Vector2.Zero;
        }       

        public override void LoadContent(ContentManager Content)
        {
            PlayerImage = Content.Load<Texture2D>("sprites/Orc4");
            playerAnimation.AnimationImage = PlayerImage;
        }

        public void Update(GameTime gameTime, Hero hero, Mace mace)
        {
            playerAnimation.Active = true;

            if (playZone.Intersects(hero.ImageContainer))
            {
                tempCurrentFrame.Y = 0;
                if (playerPosition.X < playZone.X)
                {
                    playerPosition.X = playZone.X;
                }
                if (playerPosition.X > playZone.X + playZone.Width)
                {
                    playerPosition.X = playZone.X + playZone.Width;
                }

                playerAnimation.Position = playerPosition;
                tempCurrentFrame.X = playerAnimation.CurrentFrame.X;
                if (mace.SpriteAnimation.Active == false)
                {
                    Vector2 newPosition = new Vector2(playerPosition.X, playerPosition.Y);
                    mace.MacePosition = newPosition;
                }
                mace.SpriteAnimation.Active = true;
            }
            else
            {
                mace.SpriteAnimation.Active = false;

                if (playerPosition.X < playZone.X)
                {
                    velocity.X = 1;
                    velocity.Y = 0;
                    playerPosition.X = playZone.X;
                    tempCurrentFrame.Y = 0;
                }
                if (playerPosition.X > playZone.X + playZone.Width)
                {
                    velocity.X = -1;
                    velocity.Y = 0;
                    playerPosition.X = playZone.X + playZone.Width;
                    tempCurrentFrame.Y = 1;
                }

                playerPosition.X += velocity.X * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                playerPosition.Y += velocity.Y * moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                playerAnimation.Position = playerPosition;
                tempCurrentFrame.X = playerAnimation.CurrentFrame.X;
            }

            playerAnimation.CurrentFrame = tempCurrentFrame;
            playerAnimation.Update(gameTime);
        }
    }
}
