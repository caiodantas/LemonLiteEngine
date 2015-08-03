using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEItem : LLEGUIElement
    {
        LLEItemList mList;

        public int mSpacingW, mSpacingH;

        public LLEItem(LLEItemList list, Texture2D texture, SpriteFont font, string title)
            : base(new Vector2(-500, -500), texture, font, title, null)
        {
            mList = list;

            mSpacingW = 8;

            mSpacingH = 8;

            setWH((int)font.MeasureString(title).X + (mSpacingW * 2), (int)font.MeasureString(title).Y + (mSpacingH * 2));

            setDefaultColors();

            onClickEvent = changeIndex;
        }

        public LLEItem(LLEItemList list, Texture2D texture, Texture2D icon)
            : base(new Vector2(-500, -500), texture, null, "", null)
        {
            mList = list;

            mIcon = icon;

            mSpacingW = 8;

            mSpacingH = 8;

            setWH(mIcon.Width + (mSpacingW * 2), mIcon.Height + (mSpacingH * 2));

            setDefaultColors();

            onClickEvent = changeIndex;
        }

        protected void setDefaultColors()
        {
            setColors(Color.DarkGray, Color.LightGray, Color.Gray);

            setFontColors(Color.White, Color.White, Color.DarkGray);
        }

        protected void changeIndex()
        {
            mList.setIndexByName(getLabel());

            mList.mPanelOpened = false;
        }
    }
}
