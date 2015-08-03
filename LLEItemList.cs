using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEItemList : LLEGUIElement
    {
        SpriteFont mFont;

        Texture2D mListTexture;

        List<LLEItem> mItems;

        int mSelectedIndex;

        public bool mPanelOpened;

        public delegate void OnChangeItem();

        OnChangeItem onChangeItem;

        public LLEItemList(Vector2 position, Texture2D panelTexture, Texture2D listTexture, SpriteFont font, OnChangeItem changeItem)
                : base(position, panelTexture, font, "", null)
        {
            mFont = font;

            setTexture(panelTexture);

            mListTexture = listTexture;

            setColors(Color.DarkGray, Color.LightGray, Color.Gray);

            setFontColors(Color.White, Color.White, Color.DarkGray);


            mItems = new List<LLEItem>();

            mSelectedIndex = -1;

            mPanelOpened = false;

            this.onClickEvent = toggleItemList;

            onChangeItem = changeItem;
        }

        protected void toggleItemList()
        {
            mPanelOpened = !mPanelOpened;
        }

        public override void release()
        {
            for (int i = 0; i < mItems.Count; i++)
            {
                mItems[i] = null;
            }

            mItems.Clear();

            mItems = null;
        }

        public override void render(SpriteBatch g)
        {
            base.render(g);

            if (mItems.Count > 0 && mSelectedIndex >= 0)
            {
                if (mItems[mSelectedIndex].mIcon == null)
                {
                    g.DrawString(getSpriteFont(), mItems[mSelectedIndex].getLabel(), getCenter(getSpriteFont(), mItems[mSelectedIndex].getLabel()), getSpriteFontColor());
                }

                else
                {
                    g.Draw(mItems[mSelectedIndex].mIcon, getCenter(mItems[mSelectedIndex].mIcon), Color.White);
                }
            }

            if (mPanelOpened)
            {
                for (int i = 0; i < mItems.Count; i++)
                {
                    mItems[i].setX(getX());

                    mItems[i].setY(getY() + (getHeight() * (i + 1)));

                    mItems[i].render(g);
                }
            }
        }

        public override void update(MouseState mouseState, MouseState prevMouseState, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            base.update(mouseState, prevMouseState, keyboardState, prevKeyboardState);

            if (mPanelOpened)
            {
                for (int i = 0; i < mItems.Count; i++)
                {
                    mItems[i].update(mouseState, prevMouseState, keyboardState, prevKeyboardState);
                }
            }
        }

        protected int getLargestItemWidth()
        {
            int largestW = 0;

            for (int i = 0; i < mItems.Count; i++)
            {
                if (mItems[i].getWidth() > largestW)
                {
                    largestW = mItems[i].getWidth();
                }
            }

            return largestW;
        }

        public int getNumItems()
        {
            return mItems.Count;
        }

        public void setIndexByName(string itemName)
        {
            for (int i = 0; i < mItems.Count; i++)
            {
                if (mItems[i].getLabel().StartsWith(itemName))
                {
                    int selectedIndex = mSelectedIndex;

                    mSelectedIndex = i;

                    if (selectedIndex != i && onChangeItem != null)
                    {
                        onChangeItem();
                    }

                    break;
                }
            }
        }

        public void addItem(string itemName)
        {
            if (mItems == null)
            {
                mItems = new List<LLEItem>();
            }

            mItems.Add(new LLEItem(this, getTexture(), mFont, itemName));

            mItems.Last().setBorderVisible(true);

            int itemWidth = getLargestItemWidth();

            int itemHeight = (int)mFont.MeasureString(itemName).Y + mItems.Last().mSpacingH;

            //Resize based on the largest item

            mSelectedIndex = 0;

            resize(itemWidth, itemHeight);
        }

        public void addItem(Texture2D itemIcon)
        {
            mItems.Add(new LLEItem(this, getTexture(), itemIcon));

            mItems.Last().setBorderVisible(true);

            int itemWidth = getLargestItemWidth();

            int itemHeight = itemIcon.Height + mItems.Last().mSpacingH;

            //Resize based on the largest item

            mSelectedIndex = 0;

            resize(itemWidth, itemHeight);
        }

        protected void resize(int width, int height)
        {
            setWidth(width);

            setHeight(height);

            for (int i = 0; i < mItems.Count; i++)
            {
                mItems[i].setWH(getWH());
            }
        }

        public void removeItem(int index)
        {
            mItems.RemoveAt(index);
        }

        public int getSelectedIndex()
        {
            return mSelectedIndex;
        }

        public LLEItem getSelectedItem()
        {
            return mItems[mSelectedIndex];
        }
    }
}
