using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RPG
{
    //Class to be extended by all other screen classes
    public abstract class BaseGameScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 600;

        private List<GameComponent> components = new List<GameComponent>();
        private Game game;
        private SpriteBatch spriteBatch;

        public BaseGameScreen(Game game, SpriteBatch sprite): base(game)
        {
            this.game = game;
            this.spriteBatch = sprite;
        }

        public List<GameComponent> Components
        {
            get { return components; }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (GameComponent component in components)
                if (component.Enabled == true)
                    component.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (GameComponent component in components)
                if (component is DrawableGameComponent && ((DrawableGameComponent)component).Visible)
                    ((DrawableGameComponent)component).Draw(gameTime);

        }

        public virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;
            foreach (GameComponent component in components)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;

            }
        }
        public virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;
            foreach (GameComponent component in components)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }

        public int Height
        {
            get { return HEIGHT; }
        }
        public int Width
        {
            get { return WIDTH; }
        }


    }
}
