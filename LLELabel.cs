using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LemonLiteEngine
{
    public class LLELabel
    {
        public string mText;

        public Vector2 mPosition;

        public SpriteFont mFont;

        public Color mColor;

        public LLELabel(Vector2 position, SpriteFont font, string text, Color color)
        {
            mText = text;

            mPosition = position;

            mFont = font;

            mColor = color;
        }

        public void render(SpriteBatch g)
        {
            g.DrawString(mFont, mText, mPosition, mColor);
        }

        public void renderOnPanel(SpriteBatch g, LLEPanel panel)
        {
            g.DrawString(mFont, mText, new Vector2(panel.getX() + mPosition.X, panel.getY() + mPosition.Y), mColor);
        }

        public int getWidth()
        {
            return (int)mFont.MeasureString(mText).X;
        }

        public int getHeight()
        {
            return (int)mFont.MeasureString(mText).Y;
        }
    }
}
