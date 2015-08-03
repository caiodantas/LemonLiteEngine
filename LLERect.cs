using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LemonLiteEngine
{
    public class LLERect
    {
        public int mX, mY, mWidth, mHeight;

        public LLERect(int x, int y, int width, int height)
        {
            mX = x;

            mY = y;

            mWidth = width;

            mHeight = height;
        }

        public LLERect(Vector2 position, Vector2 size)
        {
            mX = (int)position.X;

            mY = (int)position.Y;

            mWidth = (int)size.X;

            mHeight = (int)size.Y;
        }

        public LLERect(Vector2 position, int width, int height)
        {
            mX = (int)position.X;

            mY = (int)position.Y;

            mWidth = width;

            mHeight = height;
        }

        public LLERect(int x, int y, Vector2 size)
        {
            mX = x;

            mY = y;

            mWidth = (int)size.X;

            mHeight = (int)size.Y;
        }


        public Rectangle getXNARect()
        {
            return new Rectangle(mX, mY, mWidth, mHeight);
        }
    }
}
