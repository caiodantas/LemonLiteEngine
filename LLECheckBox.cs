using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLECheckBox : LLEGUIElement
    {
        bool mChecked;

        public LLECheckBox(Vector2 position, Texture2D bgTexture, SpriteFont font, bool check, OnClickEvent clickEvent)
            : base(position, bgTexture, font, "X", clickEvent)
        {
            mChecked = check;

            mSpriteFontColor = Color.White;
        }

        public LLECheckBox(Vector2 position, Texture2D bgTexture, bool check, OnClickEvent clickEvent)
            : base(position, bgTexture, null, "X", clickEvent)
        {
            mChecked = check;

            mSpriteFontColor = Color.White;
        }

        public void init(int size)
        {
            setWH(size, size);

            setColors(Color.DarkGray, Color.LightGray, new Color(100, 100, 100));

            setFontColors(Color.White, Color.White, Color.LightGray);
        }

        public void setChecked(bool check)
        {
            mChecked = check;
        }

        public bool isChecked()
        {
            return mChecked;
        }

        public int getSize()
        {
            return getWidth();
        }

        public override void render(SpriteBatch g)
        {
            setLabelVisible(mIcon == null && mChecked);

            setIconVisible(!isLabelVisible());

            base.render(g);
        }

        public override void update(MouseState mouseState, MouseState prevMouseState, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released
                && mouseOver(mouseState.X, mouseState.Y))
            {
                mChecked = !mChecked;
            }

            base.update(mouseState, prevMouseState, keyboardState, prevKeyboardState);
        }
    }
}
