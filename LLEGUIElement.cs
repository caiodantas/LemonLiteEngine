using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEGUIElement : LLESprite
    {
        bool mSelected, mDisabled;

        SpriteFont mSpriteFont;

        public Texture2D mIcon;

        string mLabel;

        bool mIsLabelVisible, mIsIconVisible;

        Vector2 mLabelXY;

        Vector2 mLabelWH;

        public Color mElementColor, mNormalColor, mSelectedColor, mDisabledColor;

        public Color mSpriteFontColor;

        public Color mNormalSpriteFontColor, mSelectedSpriteFontColor, mDisabledSpriteFontColor;

        bool mRenderBorder;

        Color mBorderColor;

        public bool mTextOnly;

        public LLEGUIElement(Vector2 position, Texture2D texture, SpriteFont spriteFont, string label, OnClickEvent clickEvent)
            : base(position, texture)
        {
            mIsIconVisible = true;

            mSelected = mDisabled = false;

            if (clickEvent != null)
            {
                onClickEvent = clickEvent;
            }

            mSpriteFont = spriteFont;

            mLabel = label;

            mInitialX = getX();

            mInitialY = getY();

            mRenderBorder = false;

            mIsLabelVisible = true;

            mBorderColor = Color.Black;
        }

        #region SetsAndGets

        public void setLabelVisible(bool visible)
        {
            mIsLabelVisible = visible;
        }

        public void setIconVisible(bool visible)
        {
            mIsIconVisible = visible;
        }

        public void setBorderColor(Color color)
        {
            mBorderColor = color;
        }

        public void setBorderVisible(bool visible)
        {
            mRenderBorder = visible;
        }

        public Vector2 getLabelXY()
        {
            return mLabelXY;
        }

        public bool isLabelVisible()
        {
            return mIsLabelVisible;
        }

        public bool isIconVisible()
        {
            return mIsIconVisible;
        }

        public Color getSpriteFontColor()
        {
            return mSpriteFontColor;
        }

        public void setRect(float x, float y, int width, int height)
        {
            setX(x);

            setY(y);

            setWidth(width);

            setHeight(height);
        }

        public void setSpriteFont(SpriteFont spriteFont)
        {
            mSpriteFont = spriteFont;
        }

        public SpriteFont getSpriteFont()
        {
            return mSpriteFont;
        }

        public bool isDisabled()
        {
            return mDisabled;
        }

        public void setLabel(string theLabel)
        {
            mLabel = theLabel;
        }

        public string getLabel()
        {
            return mLabel;
        }

        public void setLabelXY(int x, int y)
        {
            mLabelXY = new Vector2(x, y);
        }

        public float getLabelX()
        {
            return mLabelXY.X;
        }

        public float getLabelY()
        {
            return mLabelXY.Y;
        }

        public float getLabelW()
        {
            return mSpriteFont.MeasureString(mLabel).X;
        }

        public float getLabelH()
        {
            return mSpriteFont.MeasureString(mLabel).Y;
        }

        #endregion

        public virtual void release()
        {
            
        }

        public void setSelected(bool selected)
        {
            mSelected = selected;

            if (selected)
            {
                mElementColor = mSelectedColor;

                mSpriteFontColor = mSelectedSpriteFontColor;
            }

            else
            {
                mElementColor = mNormalColor;

                mSpriteFontColor = mNormalSpriteFontColor;
            }
        }

        private void setDisabled(bool disabled)
        {
	        mDisabled = disabled;

	        if(mDisabled)
	        {
		        mSelected = false;

                mElementColor = mDisabledColor;

                mSpriteFontColor = mDisabledSpriteFontColor;
	        }

            else
            {
                mElementColor = mNormalColor;

                mSpriteFontColor = mNormalSpriteFontColor;
            }
        }

        public delegate void OnClickEvent();

        public OnClickEvent onClickEvent;

        public virtual void update(MouseState mouseState, MouseState prevMouseState, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            if ((!mTextOnly && mouseOver(mouseState)) || (mSpriteFont != null && mouseOverLabel(mouseState)))
            {
                setSelected(true);

                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (onClickEvent != null)
                    {
                        onClickEvent();
                    }
                }
            }

            else
            {
                setSelected(false);
            }
        }

        public bool mouseOverLabel(MouseState mouseState)
        {
            return mouseOverLabel(mouseState.X, mouseState.Y);
        }

        public bool mouseOverLabel(int mouseX, int mouseY)
        {
            if (mouseX > mLabelXY.X && mouseX < (mLabelXY.X + getLabelW()) && mouseY > mLabelXY.Y && mouseY < mLabelXY.Y + getLabelH())
            {
                return true;
            }

            return false;
        }

        public bool isSelected()
        {
            return mSelected;
        }

        public override void render(SpriteBatch g)
        {
            if (isVisible() && getTexture() != null)
            {
                if (mRenderBorder)
                {
                    g.Draw(getTexture(), new LLERect(getXY(-1, -1), getWH(2, 2)).getXNARect(), mBorderColor);
                }

                setTextureColor(mElementColor);

                if (getWidth() != getTexture().Width || getHeight() != getTexture().Height)
                {
                    renderStretched(g);
                }

                else
                {
                    base.render(g);
                }

                renderLabel(g);

                renderIcon(g);
            }
        }

        public bool labelExists()
        {
            return mIsLabelVisible && mLabel.Length > 0 && mLabel.Replace(" ", "") != "";
        }

        public void renderIcon(SpriteBatch g)
        {
            if (mIsIconVisible && mIcon != null)
            {
                g.Draw(mIcon, getCenter(mIcon), Color.White);
            }
        }

        public void renderLabel(SpriteBatch g)
        {
            if (mSpriteFont != null)
            {
                mLabelXY = getCenter(mSpriteFont, mLabel);

                if (labelExists())
                {
                    g.DrawString(mSpriteFont, mLabel, mLabelXY, mSpriteFontColor);
                }
            }
        }

        public void setColors(Color normalColor, Color selectedColor, Color disabledColor)
        {
            mElementColor = normalColor;

            mNormalColor = normalColor;

            mSelectedColor = selectedColor;

            mDisabledColor = disabledColor;

            setTextureColor(normalColor);
        }

        public void setFontColors(Color normalSpriteFontColor, Color selectedSpriteFontColor, Color disabledSpriteFontColor)
        {
            mNormalSpriteFontColor = normalSpriteFontColor;

            mSpriteFontColor = mNormalSpriteFontColor;

            mSelectedSpriteFontColor = selectedSpriteFontColor;

            mDisabledSpriteFontColor = disabledSpriteFontColor;
        }
    }
}
