using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LemonLiteEngine
{
    public class LLEMessageBalloon
    {
        LLESprite mBalloon;

        Texture2D mBalloonPointer;

        Texture2D mIcon;

        SpriteFont mFont;

        string mText;

        List<string> mTextLines;

        bool mEventMsg;

        Color mTextColor;

        int mWindowWidth, mWindowHeight;

        public LLEMessageBalloon(float x, float y, Texture2D texture, Texture2D balloonPointer, SpriteFont font, LLEMapFrontLayer frontLayer)
        {
            mText = "";

            mBalloonPointer = balloonPointer;

            mBalloon = null;

            mBalloon = new LLESprite(x, y, 0, 0, 0);

            mBalloon.setTexture(texture);

            mIcon = null;

            mFont = font;

            mTextLines = new List<string>();

            mEventMsg = false;

            mTextColor = new Color(210, 105, 0);

            mWindowWidth = frontLayer.getWindowWidth();

            mWindowHeight = frontLayer.getWindowHeight();
        }

        public void release()
        {
            mBalloon = null;
        }

        public void setAsEventMsg(Assets assets, bool eventMsg)
        {
            mEventMsg = eventMsg;

            mTextColor = new Color(210, 105, 0);

            if (eventMsg)
            {
                mFont = assets.VerdanaBig;
            }

            else
            {
                mFont = assets.Verdana10;
            }

            mBalloon.setX((mWindowWidth / 2) - (assets.KeyItemBoard.Width / 2));

            mBalloon.setY((mWindowHeight / 2) - (assets.KeyItemBoard.Height / 2));
        }

        public bool isEventMsg()
        {
            return mEventMsg;
        }

        public Texture2D getBalloonTexture()
        {
            return mBalloon.getTexture();
        }

        public Texture2D getPointerTexture()
        {
            return mBalloonPointer;
        }

        public void setIcon(Assets assets, string iconName)
        {
            mIcon = assets.getTexture(iconName);
        }

        public void setText(string text)
        {
            mText = text;

            if (!mEventMsg)
            {
                resize();
            }
        }

        public LLESprite getSprite()
        {
            return mBalloon;
        }

        protected void resize()
        {
            mTextLines.Clear();

            Vector2 textSize = mFont.MeasureString(mText);

            int lines = (int)(textSize.X) / mBalloon.getTexture().Width;

            if (lines > 0)
            {
                string textLine = "";

                for (int i = 0; i < mText.Length; i++)
                {
                    if (mFont.MeasureString(textLine + mText[i].ToString()).X > mBalloon.getTexture().Width)
                    {
                        mTextLines.Add(textLine);

                        textLine = mText[i].ToString();
                    }

                    else
                    {
                        textLine += mText[i];
                    }
                }

                if (textLine != "")
                {
                    mTextLines.Add(textLine);
                }

                int largestLineW = 0;

                for (int i = 0; i < mTextLines.Count; i++)
                {
                    if (mFont.MeasureString(mTextLines[i]).X > largestLineW)
                    {
                        largestLineW = (int)mFont.MeasureString(mTextLines[i]).X;
                    }
                }

                mBalloon.setWidth(largestLineW + 10);

                mBalloon.setHeight((mTextLines.Count * (int)textSize.Y) + 15);
            }

            else
            {
                mTextLines.Add(mText);

                mBalloon.setWidth((int)textSize.X + 10);

                mBalloon.setHeight((int)textSize.Y + 10);
            }
        }

        public void render(SpriteBatch g)
        {
            if (mEventMsg)
            {
                mBalloon.render(g);

                g.DrawString(mFont, mText, new Vector2(Convert.ToInt32((int)mBalloon.getX() + ((int)mBalloon.getTexture().Width / 2) - ((int)mFont.MeasureString(mText).X / 2)), Convert.ToInt32((int)mBalloon.getY() + ((int)mBalloon.getTexture().Height / 2) + 20)), mTextColor);

                g.Draw(mIcon, new Vector2(mBalloon.getX() + (mBalloon.getTexture().Width / 2) - (mIcon.Width / 2), mBalloon.getY() + 20), Color.White);
            }

            else
            {
                mBalloon.renderStretched(g);

                for (int i = 0; i < mTextLines.Count; i++)
                {
                    g.DrawString(mFont, mTextLines[i], new Vector2(Convert.ToInt32(mBalloon.getX() + 5), Convert.ToInt32(mBalloon.getY() + 5 + (2 * i) + (mFont.MeasureString(mTextLines[i]).Y * i))), mTextColor);
                }

                g.Draw(mBalloonPointer, new Vector2(mBalloon.getX() + (mBalloon.getWidth() / 2) - (mBalloonPointer.Width / 2), mBalloon.getY() + mBalloon.getHeight() - 1), Color.White);
            }
        }
    }
}
