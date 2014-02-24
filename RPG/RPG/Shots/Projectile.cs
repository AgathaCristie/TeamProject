namespace RPG.Shots
{
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

    public abstract class Projectile
    {
        // fields:
        protected Texture2D playerImage;
        protected Vector2 playerPosition, tempCurrentFrame;
        protected Animation playerAnimation;
        protected Vector2 velocity;
        protected Rectangle playZone;
        protected float moveSpeed;

        public int DamageInflict { get; protected set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (playerAnimation.Active)
            {
                playerAnimation.Draw(spriteBatch);
            }
        }

        public void InflictDamage(Hero hero)
        {
            int damageInflicted = this.DamageInflict - hero.DamageResist;
            if (damageInflicted > 0)
            {
                hero.CurrentHealth -= damageInflicted;
            }
        }
    }
}
