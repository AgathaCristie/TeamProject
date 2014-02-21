namespace RPG.Heroes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public interface IHeroes
    {
        //Properties
        Rectangle ImageContainer { get; }

        Texture2D[] Images { get; }

        Texture2D[] ImagesLeft { get; }

        Texture2D DefaultImage { get; }

        //Methods
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
