﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Monsters
{
    public class Animation
    {
        int frameCounter;
        int switchFrame = 150;
        bool active;

        Vector2 position, amountOfFrames, currentFrame;
        Texture2D Image;
        Rectangle sourceRect;

        public Vector2 AmountOfFrames
        {
            get { return this.amountOfFrames; }
        }

        public Texture2D AnimationImage
        {
            set { this.Image = value; }
        }

        public Vector2 CurrentFrame
        {
            get { return currentFrame; }
            set { this.currentFrame = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { this.position = value; }
        }
        public bool Active
        {
            get { return active; }
            set { this.active = value; }
        }
        public int FrameWidth
        {
            get { return Image.Width / (int)amountOfFrames.X; }
        }
        public int FrameHeight
        {
            get { return Image.Height / (int)amountOfFrames.Y; }
        }

        public void Initialize(Vector2 position, Vector2 Frames)
        {
            active = false;
            this.position = position;
            this.amountOfFrames = Frames;
        }

        public void Update(GameTime gameTime)
        {
            if (Active)
            {
                frameCounter += (int)gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                frameCounter = 0;
            }
            if (frameCounter >= switchFrame)
            {
                frameCounter = 0;
                currentFrame.X += FrameWidth;
                if (currentFrame.X >= Image.Width)
                {
                    currentFrame.X = 0;
                }
                sourceRect = new Rectangle((int)currentFrame.X, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, position, sourceRect, Color.White);
        }
    }
}