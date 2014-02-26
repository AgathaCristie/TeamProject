using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Heroes;
using RPG.Monsters;

namespace RPG.AddOns
{
    public class HpBar
    {
        Rectangle hpBarLife = new Rectangle(0, 0, 30, 5);
        Rectangle hpBarDeath = new Rectangle(0, 0, 30, 5);
        Texture2D redLine;
        Texture2D greenLine;
        Texture2D deadHero;
        Texture2D deadMonster;
        public bool isDeadHero = false;
        bool visible = false;


        public void LoadContent(ContentManager Content)
        {
            redLine = Content.Load<Texture2D>("sprites/redLine");
            greenLine = Content.Load<Texture2D>("sprites/greenLine");
            deadHero = Content.Load<Texture2D>("sprites\\HeroMoves\\DeadHero");
            deadMonster = Content.Load<Texture2D>("sprites/Tombstone");
        }
        public void Update(Hero hero)
        {
            visible = true;
            int currentX = hero.ImageContainer.X;
            int currentY = hero.ImageContainer.Y;
            hpBarLife.X = currentX + 15;
            hpBarLife.Y = currentY - 20;
            hpBarLife.Width = (int)hero.Life;

            //When hero dies change the image
            if (hero.Life < 1)
            {
                hero.DefaultImage = deadHero;
                isDeadHero = true;

            }

            hpBarDeath.X = currentX + 15;
            hpBarDeath.Y = currentY - 20;
            if (hero.Life <= 0)
            {

            }
        }
        public void Update(Monster monster)
        {
            visible = true;
            int currentX = monster.Playzone.X;
            int currentY = monster.Playzone.Y;
            hpBarLife.X = currentX + 15;
            hpBarLife.Y = currentY - 20;
            hpBarLife.Width = (int)monster.Life;

            //When hero dies change the image
            if (monster.Life < 1)
            {
                monster.PlayerImage = deadMonster;
                isDeadHero = true;

            }

            hpBarDeath.X = currentX + 15;
            hpBarDeath.Y = currentY - 20;
            if (monster.Life <= 0)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(redLine, hpBarDeath, Color.White);
                spriteBatch.Draw(greenLine, hpBarLife, Color.White);
            }
        }


    }
}

