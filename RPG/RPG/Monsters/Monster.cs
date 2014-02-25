namespace RPG.Monsters
{
    using RPG.Heroes;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public abstract class Monster : IDamageTaking, IDamageMaking
    {
        // fields:
        protected Texture2D playerImage;
        protected Vector2 playerPosition, tempCurrentFrame;
        protected Animation playerAnimation;
        protected Vector2 velocity;
        protected Rectangle playZone;
        // protected KeyboardState keyState;
        protected float moveSpeed;

        // properties:
        public Vector2 PlayerPosition
        {
            get { return this.playerPosition; }
        }

        public int CurrentHealth { get; set; }
        public int DamageResist { get; set; }
        public int DamageInflict { get; set; }

        // methods:
        public virtual void LoadContent(ContentManager Content)
        {
            playerAnimation.AnimationImage = playerImage;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerAnimation.Draw(spriteBatch);
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
