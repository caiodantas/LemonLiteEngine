using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LemonLiteEngine
{
    public class LLEParticleEmitter
    {
        public List<LLESprite> mParticles;

        //Rectangle representing the region where the particles are created

        float mXVel, mYVel;

        Random randomizer;

        int mParticleSpacing;

        public Texture2D mParticleTexture;

        public bool mFadeParticles;

        public int mAlpha;

        float mFadingSpeed;

        public LLEParticleEmitter(Texture2D particleTexture, int particleSpacing, float xVel, float yVel, float fadingSpeed)
        {
            mParticles = new List<LLESprite>();

            mFadeParticles = true;

            mAlpha = 255;

            mXVel = xVel;

            mYVel = yVel;

            mParticleSpacing = particleSpacing;

            randomizer = new Random();

            mParticleTexture = particleTexture;

            mFadingSpeed = fadingSpeed;
        }

        public void release()
        {
            randomizer = null;

            for (int i = 0; i < mParticles.Count; i++)
            {
                mParticles[i] = null;
            }

            mParticles.Clear();

            mParticles = null;
        }

        public void createParticles(Rectangle originRect, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int directionX = randomizer.Next(4);

                if(directionX == 0 || directionX == 1)
                {
                    directionX = -1;
                }

                int directionY = randomizer.Next(4);

                if (directionY == 0 || directionX == 1)
                {
                    directionY = -1;
                }

                mParticles.Add(new LLESprite(new Vector4(originRect.X + (randomizer.Next((originRect.Width / mParticleSpacing)) * mParticleSpacing),
                                                         originRect.Y + (randomizer.Next((originRect.Height / mParticleSpacing)) * mParticleSpacing), mXVel * directionX, mYVel * directionY)));

                mParticles.Last().setTexture(mParticleTexture);
            }
        }

        public void render(SpriteBatch g)
        {
            for (int i = 0; i < mParticles.Count; i++)
            {
                mParticles[i].render(g);
            }
        }

        public void update(GameTime gameTime, GameWindow window)
        {
            if (mFadeParticles)
            {
                int decrease = (int)((gameTime.ElapsedGameTime.Ticks / 10000) * mFadingSpeed);

                if (mAlpha - decrease > 0)
                {
                    mAlpha -= decrease;
                }

                else
                {
                    mAlpha = 0;
                }
            }

            for (int i = 0; i < mParticles.Count; i++)
            {
                if (mParticles[i] != null)
                {
                    mParticles[i].move(gameTime.ElapsedGameTime.Ticks / 10000);

                    if (mFadeParticles)
                    {
                        Color particleColor = mParticles[i].getTextureColor();

                        mParticles[i].setTextureColor(new Color(particleColor.R, particleColor.G, particleColor.B, (byte)mAlpha));
                    }

                    if (mParticles[i].getX() + mParticles[i].getWidth() < 0 || mParticles[i].getX() > window.ClientBounds.Width + 2)
                    {
                        mParticles[i] = null;

                        mParticles.RemoveAt(i);

                        //break;
                    }
                }
            }
        }
    }
}
