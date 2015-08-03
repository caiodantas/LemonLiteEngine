using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LemonLiteEngine
{
    public class LLEFadeRect
    {
        Rectangle mRect;

        //When mAutoFadeBack is true, the rect will fade in immediately after fading out or vice-versa

        public bool mAutoFadeBack;

        public float mFadeSpeed;

        Texture2D mTexture;

        Color mColor;

        public bool mFadeIn;

        public LLEFadeRect(GameWindow window, Texture2D rectTexture, float fadeSpeed)
        {
            mRect = new Rectangle(0, 0, window.ClientBounds.Width, window.ClientBounds.Height);

            init(rectTexture, fadeSpeed);
        }

        public LLEFadeRect(Rectangle rect, Texture2D rectTexture, float fadeSpeed)
        {
            mRect = rect;

            init(rectTexture, fadeSpeed);
        }

        protected void init(Texture2D rectTexture, float fadeSpeed)
        {
            mFadeIn = false;

            mAutoFadeBack = true;

            mFadeSpeed = fadeSpeed;

            mTexture = rectTexture;

            mColor = new Color(0, 0, 0, 0);
        }

        public delegate void OnFade();

        public void update(float theFrac, OnFade onFade)
        {
            int increase = (int)(theFrac * mFadeSpeed);

            if (mFadeIn)
            {
                if (mColor.A + increase < 255)
                {
                    mColor.A += (byte)increase;
                }

                else
                {
                    mColor.A = 255;

                    mFadeIn = false;

                    onFade();
                }
            }

            else if(mAutoFadeBack)
            {
                if (mColor.A - increase > 0)
                {
                    mColor.A -= (byte)increase;
                }

                else
                {
                    mColor.A = 0;
                }
            }
        }

        public void render(SpriteBatch g)
        {
            if (mColor.A > 0)
            {
                g.Draw(mTexture, mRect, mColor);
            }
        }
    }
}
