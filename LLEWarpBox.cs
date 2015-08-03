using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonLiteEngine
{
    public class LLEWarpBox : LLERect
    {
        public string mID, mTargetID;

        public string mDirection, mTargetLevel;

        public LLEWarpBox(int x, int y, int width, int height, string ID, string targetID, string direction, string targetLevel)
            : base(x, y, width, height)
        {
            mID = ID;

            mTargetID = targetID;

            mDirection = direction;

            mTargetLevel = targetLevel;
        }

        public LLEWarpBox clone()
        {
            return new LLEWarpBox(mX, mY, mWidth, mHeight, mID, mTargetID, mDirection, mTargetLevel);
        }
    }
}
