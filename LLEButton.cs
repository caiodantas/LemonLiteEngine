using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEButton : LLEGUIElement
    {
        public LLEButton(Vector2 position, Texture2D texture, SpriteFont spriteFont, 
            string label, bool isTextOnly, OnClickEvent clickEvent)
            : base(position, texture, spriteFont, label, clickEvent)
        {
            mTextOnly = isTextOnly;

            mIcon = null;

            setDefaultColors();
        }

        public LLEButton(Vector2 position, Texture2D texture, Texture2D iconImg, OnClickEvent clickEvent)
            : base(position, texture, null, "", clickEvent)
        {
            mTextOnly = false;

            mIcon = iconImg;

            setDefaultColors();
        }

        protected void setDefaultColors()
        {
            setColors(new Color(153, 153, 153), new Color(204, 204, 204), new Color(204, 204, 204));

            setFontColors(new Color(255, 255, 255), new Color(255, 255, 255), new Color(0, 0, 0));
        }

        public override void render(SpriteBatch g)
        {
            setLabelVisible(mIcon == null);

            if (isVisible())
            {
                if (!mTextOnly)
                {
                    base.render(g);
                }

                else if(mIcon == null)
                {
                    renderLabel(g);
                }
            }

            else if (mTextOnly)
            {
                renderLabel(g);
            }
        }
    }
}
