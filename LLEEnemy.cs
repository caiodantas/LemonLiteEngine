using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonLiteEngine
{
    public class LLEEnemy
    {
        string mName;

        int mHP;

        LLESprite mSprite;

        public LLEEnemy(string name, int hp, Vector2 position, Assets assets)
        {
            mName = name;

            mHP = hp;

            mSprite = new LLESprite(position.X, position.Y, 0, 0, 0);

            mSprite.setTexture(assets.getTexture(mName));

            mSprite.setTextureName(mName);
        }

        public void release()
        {
            mSprite = null;
        }

        public LLESprite getSprite()
        {
            return mSprite;
        }

        public string getName()
        {
            return mName;
        }

        public int getHP()
        {
            return mHP;
        }

        public LLEEnemy clone(Assets assets)
        {
            return new LLEEnemy(mName, mHP, new Vector2(mSprite.getX(), mSprite.getY()), assets);
        }
    }
}
