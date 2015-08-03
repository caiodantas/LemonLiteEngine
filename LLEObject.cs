using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LemonLiteEngine
{
    public class LLEObject
    {
        string mName;

        string mMapName;

        string mScriptName;

        bool mIsItem;

        LLESprite mSprite;

        bool mEnabled;

        bool mDestroyable;

        bool mCollide;

        public LLEObject(float x, float y)
        {
            mName = mScriptName = "NONE";

            mSprite = new LLESprite(x, y, 0, 0, 0);

            mIsItem = false;

            mEnabled = true;

            mDestroyable = false;

            mCollide = true;
        }

        public void release()
        {
            mSprite = null;
        }

        public void setName(string name)
        {
            mName = name;
        }

        public void setMapName(string mapName)
        {
            mMapName = mapName;
        }

        public void setScriptName(string scriptName)
        {
            mScriptName = scriptName;
        }

        public void setAsItem()
        {
            mIsItem = true;
        }

        public void setEnabled(bool Enabled)
        {
            mEnabled = Enabled;
        }

        public void setCollide(bool collide)
        {
            mCollide = collide;
        }

        public string getName()
        {
            return mName;
        }

        public string getMapName()
        {
            return mMapName;
        }

        public string getScriptName()
        {
            return mScriptName;
        }

        public bool isItem()
        {
            return mIsItem;
        }

        public bool isEnabled()
        {
            return mEnabled;
        }

        public bool isDestroyable()
        {
            return mDestroyable;
        }

        public bool isColliding()
        {
            return mCollide;
        }

        public void setDestroyable(bool destroyable)
        {
            mDestroyable = destroyable;
        }

        public void setSprite(LLESprite sprite)
        {
            mSprite = sprite;
        }

        public LLESprite getSprite()
        {
            return mSprite;
        }

        public LLEObject clone()
        {
            LLEObject theObject = new LLEObject(mSprite.getX(), mSprite.getY());

            theObject.setName(mName);

            theObject.setScriptName(mScriptName);

            theObject.setSprite(mSprite.clone());

            theObject.setMapName(mMapName);

            theObject.setEnabled(mEnabled);

            theObject.setDestroyable(mDestroyable);

            if (mIsItem)
            {
                theObject.setAsItem();
            }

            return theObject;
        }
    }
}
