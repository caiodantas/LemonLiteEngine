using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEPanel
    {
        Texture2D mBGTexture;

        Vector2 mPosition;

        int mWidth, mHeight;

        bool mDragging, mDraggable;

        bool mFocused;

        string mTitle;

        SpriteFont mFont;

        List<LLEGUIElement> mGUIElements;

        Color mBGColor, mFontColor;

        int mMouseRefX, mMouseRefY;

        bool mClose;

        public List<LLELabel> mLabels;

        Vector2 mFirstClick;

        int mLayer, mTopLayer;

        public bool mFirstClicked;

        bool touchedElement = false;

        bool mVisible;

        Color mBorderColor;

        bool mRenderBorder;

        public LLEPanel(Texture2D bgTexture, SpriteFont font, Vector2 position, int width, int height)
        {
            mBGTexture = bgTexture;

            mFont = font;

            mPosition = position;

            mWidth = width;

            mHeight = height;

            init();
        }

        public LLEPanel(Texture2D bgTexture, SpriteFont font, GameWindow window, int width, int height)
        {
            mBGTexture = bgTexture;

            mFont = font;

            mWidth = width;

            mHeight = height;

            mPosition = new Vector2((window.ClientBounds.Width / 2) - (width / 2), (window.ClientBounds.Height / 2) - (height / 2));

            init();
        }

        protected void init()
        {
            mRenderBorder = false;

            mBorderColor = Color.Black;

            mLayer = mTopLayer = -1;

            mFirstClicked = false;

            mDragging = false;

            mDraggable = true;

            mFocused = false;

            mVisible = true;

            mGUIElements = new List<LLEGUIElement>();

            mLabels = new List<LLELabel>();

            mTitle = "";

            mBGColor = Color.Gray;

            mFontColor = Color.Black;

            mMouseRefX = mMouseRefY = 0;

            mClose = false;
        }

        public void setBorderColor(Color color)
        {
            mBorderColor = color;
        }

        public void setBorderVisible(bool visible)
        {
            mRenderBorder = visible;
        }

        public void setVisible(bool visible)
        {
            mVisible = visible;
        }

        public bool isVisible()
        {
            return mVisible;
        }

        public void setLayering(int layer, int topLayer)
        {
            mLayer = layer;

            mTopLayer = topLayer;
        }

        public void setDraggable(bool draggable)
        {
            mDraggable = draggable;
        }

        public bool isDragging()
        {
            return mDragging;
        }

        public void release()
        {
            //Delete GUI Elements

            for (int i = 0; i < mGUIElements.Count; i++)
            {
                mGUIElements[i].release();

                mGUIElements[i] = null;
            }

            mGUIElements.Clear();

            mGUIElements = null;

            //Delete Labels

            for (int i = 0; i < mLabels.Count; i++)
            {
                mLabels[i] = null;
            }

            mLabels.Clear();

            mLabels = null;
        }

        public void setColors(Color bgColor, Color fontColor)
        {
            mBGColor = bgColor;

            mFontColor = fontColor;
        }

        public void setTitle(string title)
        {
            mTitle = title;
        }

        public string getTitle()
        {
            return mTitle;
        }

        public void addGUIElement(LLEGUIElement element)
        {
            element.setRect(mPosition.X + element.mInitialX,
                            mPosition.Y + element.mInitialY,
                            element.getWidth(),
                            element.getHeight());

            if (element.GetType() == typeof(LLETextBox))
            {
                ((LLETextBox)(element)).adjustCursor();
            }

            mGUIElements.Add(element);
        }

        public void fixateGUI()
        {
            for (int i = 0; i < mGUIElements.Count; i++)
            {
                mGUIElements[i].setRect(mPosition.X + mGUIElements[i].mInitialX,
                                          mPosition.Y + mGUIElements[i].mInitialY,
                                          mGUIElements[i].getWidth(), 
                                          mGUIElements[i].getHeight());

                if (mGUIElements[i].GetType() == typeof(LLETextBox))
                {
                    ((LLETextBox)(mGUIElements[i])).adjustCursor();
                }
            }
        }

        public void setBGColor(Color color)
        {
            mBGColor = color;
        }

        public void render(SpriteBatch g)
        {
            if (!mClose && mVisible)
            {
                if (mRenderBorder)
                {
                    g.Draw(mBGTexture, new Rectangle((int)mPosition.X - 1, (int)mPosition.Y - 1, mWidth + 2, mHeight + 2), mBorderColor);
                }

                g.Draw(mBGTexture, new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight), mBGColor);

                if (mTitle.Replace(" ", "") != "")
                {
                    g.DrawString(mFont, mTitle, new Vector2((int)(mPosition.X + (mWidth / 2) - (mFont.MeasureString(mTitle).X / 2)), (int)mPosition.Y + 10), mFontColor);
                }

                if (mGUIElements != null)
                {
                    for (int i = 0; i < mGUIElements.Count; i++)
                    {
                        mGUIElements[i].render(g);
                    }
                }

                if (mLabels != null)
                {
                    for (int i = 0; i < mLabels.Count; i++)
                    {
                        mLabels[i].renderOnPanel(g, this);
                    }
                }
            }
        }

        public void clearGUIItems()
        {
            for (int i = 0; i < mGUIElements.Count; i++)
            {
                if (mGUIElements[i].GetType() == typeof(LLETextBox))
                {
                    ((LLETextBox)(mGUIElements[i])).setText("");
                }
            }
        }

        public void close()
        {
            mClose = true;
        }

        public bool isClosed()
        {
            return mClose;
        }

        public void update(MouseState prevMouseState, MouseState mouseState, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            //Update containing GUI Elements

            if (!mClose && mVisible)
            {
                touchedElement = false;

                if (mGUIElements != null)
                {
                    for (int i = 0; i < mGUIElements.Count; i++)
                    {
                        mGUIElements[i].update(mouseState, prevMouseState, keyboardState, prevKeyboardState);

                        if (mGUIElements[i].isSelected())
                        {
                            touchedElement = true;
                        }
                    }
                }
            }
        }

        public bool isFirstClick(MouseState mouseState, MouseState prevMouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                mFirstClick.X = mouseState.X;

                mFirstClick.Y = mouseState.Y;
            }

            return mouseState.LeftButton == ButtonState.Pressed
                    && LLESprite.mouseOverRect(new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight), (int)mFirstClick.X, (int)mFirstClick.Y);
        }

        public void doDragging(MouseState mouseState, MouseState prevMouseState)
        {
            if (touchedElement == false && isFirstClick(mouseState, prevMouseState))
            {
                mLayer = mTopLayer;

                if (!mDragging)
                {
                    mMouseRefX = mouseState.X - (int)mPosition.X;

                    mMouseRefY = mouseState.Y - (int)mPosition.Y;

                    mDragging = true;
                }

                mPosition.X = mouseState.X - mMouseRefX;

                mPosition.Y = mouseState.Y - mMouseRefY;

                mFirstClick.X = mouseState.X;

                mFirstClick.Y = mouseState.Y;

                fixateGUI();
            }

            else if (mouseState.LeftButton == ButtonState.Released)
            {
                mDragging = false;

                mFirstClick.X = -5000;

                mFirstClick.Y = -5000;
            }
        }

        public void setBGTexture(Texture2D bgTexture)
        {
            mBGTexture = bgTexture;
        }

        public void setPosition(Vector2 position)
        {
            mPosition = position;
        }

        public void setWidth(int width)
        {
            mWidth = width;
        }

        public void setHeight(int height)
        {
            mHeight = height;
        }

        public void setFocused(bool focused)
        {
            mFocused = focused;
        }

        public Texture2D getBGTexture()
        {
            return mBGTexture;
        }

        public float getX()
        {
            return mPosition.X;
        }

        public float getY()
        {
            return mPosition.Y;
        }

        public int getWidth()
        {
            return mWidth;
        }

        public int getHeight()
        {
            return mHeight;
        }

        public bool isFocused()
        {
            return mFocused;
        }
    }
}
