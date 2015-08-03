using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLETextBox : LLEGUIElement
    {
        Texture2D mCursorImg;

        Vector2 mCursorPosition;

        Color mCursorColor;

        string mText;

        int mMaxLength;

        int mIndex;

        bool mHasFocus;

        public LLETextBox(Vector2 position, Texture2D bgTexture, Texture2D cursorImg, String text, SpriteFont font, 
                          int maxLength, OnClickEvent clickEvent)
            : base(position, bgTexture, font, "", clickEvent)
        {
            mCursorImg = cursorImg;

            mText = (string)text.Clone();

            mMaxLength = maxLength;

            setFontColors(Color.Black, Color.Black, Color.Gray);

            setColors(Color.DarkGray, Color.LightGray, Color.Gray);

            mIndex = -1;

            mHasFocus = false;

            mCursorColor = Color.Black;

            adjustCursor();
        }

        public void init()
        {
            setWidth((int)getSpriteFont().MeasureString("Z").X * mMaxLength + 6);

            setHeight((int)getSpriteFont().MeasureString("Z").Y + 6);
        }

        public void setCursorColor(Color color)
        {
            mCursorColor = color;
        }

        public void adjustCursor()
        {
            mIndex = -1;

            mCursorPosition.X = getX() + 3;

            mCursorPosition.Y = getY() + 3;

            if (mText.Length > 0)
            {
                for (int i = 0; i < mText.Length; i++)
                {
                    mCursorPosition.X += getSpriteFont().MeasureString(mText[i].ToString()).X;

                    mIndex++;
                }
            }
        }

        public void setPosition(int x, int y)
        {
            setRect(x, y, getWidth(), getHeight());

            adjustCursor();
        }

        public void setText(string text)
        {
            mText = (string)text.Clone();

            adjustCursor();
        }

        public string getText()
        {
            return mText;
        }

        public bool hasFocus()
        {
            return mHasFocus;
        }

        public override void update(MouseState mouseState, MouseState prevMouseState, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseOver(mouseState.X, mouseState.Y))
                {
                    mHasFocus = true;

                    //Change cursor position
                }

                else
                {
                    mHasFocus = false;
                }
            }

            if (mHasFocus)
            {
                string character = "";

                if ((keyboardState.IsKeyDown(Keys.Left) && !prevKeyboardState.IsKeyDown(Keys.Left)) ||

                    (keyboardState.IsKeyDown(Keys.Back) && !prevKeyboardState.IsKeyDown(Keys.Back)))
                {
                    if (mIndex > -1 && mText.Length > 0)
                    {
                        mCursorPosition.X -= getSpriteFont().MeasureString(mText[mIndex].ToString()).X;

                        if (keyboardState.IsKeyDown(Keys.Back) && !prevKeyboardState.IsKeyDown(Keys.Back))
                        {
                            string newStr = "";

                            for (int i = 0; i < mText.Length; i++)
                            {
                                if (i != mIndex)
                                {
                                    newStr += mText[i].ToString();
                                }
                            }

                            mText = newStr;
                        }

                        mIndex--;
                    }
                }

                
                else if (keyboardState.IsKeyDown(Keys.Right) && !prevKeyboardState.IsKeyDown(Keys.Right))
                {
                    if (mIndex < mText.Length - 1)
                    {
                        mIndex++;

                        mCursorPosition.X += getSpriteFont().MeasureString(mText[mIndex].ToString()).X;
                    }
                }
                
                else if (mText.Length + 1 < mMaxLength)
                {
                    if (keyboardState.IsKeyDown(Keys.D0) && !prevKeyboardState.IsKeyDown(Keys.D0))
                    {
                        character = "0";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D0) && !prevKeyboardState.IsKeyDown(Keys.D0))
                    {
                        character = "0";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D1) && !prevKeyboardState.IsKeyDown(Keys.D1))
                    {
                        character = "1";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D2) && !prevKeyboardState.IsKeyDown(Keys.D2))
                    {
                        character = "2";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D3) && !prevKeyboardState.IsKeyDown(Keys.D3))
                    {
                        character = "3";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D4) && !prevKeyboardState.IsKeyDown(Keys.D4))
                    {
                        character = "4";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D5) && !prevKeyboardState.IsKeyDown(Keys.D5))
                    {
                        character = "5";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D6) && !prevKeyboardState.IsKeyDown(Keys.D6))
                    {
                        character = "6";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D7) && !prevKeyboardState.IsKeyDown(Keys.D7))
                    {
                        character = "7";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D8) && !prevKeyboardState.IsKeyDown(Keys.D8))
                    {
                        character = "8";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D9) && !prevKeyboardState.IsKeyDown(Keys.D9))
                    {
                        character = "9";
                    }

                    else if (keyboardState.IsKeyDown(Keys.Q) && !prevKeyboardState.IsKeyDown(Keys.Q))
                    {
                        character = "q";
                    }

                    else if (keyboardState.IsKeyDown(Keys.OemMinus) && !prevKeyboardState.IsKeyDown(Keys.OemMinus))
                    {
                        character = "-";
                    }

                    else if (keyboardState.IsKeyDown(Keys.W) && !prevKeyboardState.IsKeyDown(Keys.W))
                    {
                        character = "w";
                    }

                    else if (keyboardState.IsKeyDown(Keys.E) && !prevKeyboardState.IsKeyDown(Keys.E))
                    {
                        character = "e";
                    }

                    else if (keyboardState.IsKeyDown(Keys.R) && !prevKeyboardState.IsKeyDown(Keys.R))
                    {
                        character = "r";
                    }

                    else if (keyboardState.IsKeyDown(Keys.T) && !prevKeyboardState.IsKeyDown(Keys.T))
                    {
                        character = "t";
                    }

                    else if (keyboardState.IsKeyDown(Keys.Y) && !prevKeyboardState.IsKeyDown(Keys.Y))
                    {
                        character = "y";
                    }

                    else if (keyboardState.IsKeyDown(Keys.U) && !prevKeyboardState.IsKeyDown(Keys.U))
                    {
                        character = "u";
                    }

                    else if (keyboardState.IsKeyDown(Keys.I) && !prevKeyboardState.IsKeyDown(Keys.I))
                    {
                        character = "i";
                    }

                    else if (keyboardState.IsKeyDown(Keys.O) && !prevKeyboardState.IsKeyDown(Keys.O))
                    {
                        character = "o";
                    }

                    else if (keyboardState.IsKeyDown(Keys.P) && !prevKeyboardState.IsKeyDown(Keys.P))
                    {
                        character = "p";
                    }

                    else if (keyboardState.IsKeyDown(Keys.A) && !prevKeyboardState.IsKeyDown(Keys.A))
                    {
                        character = "a";
                    }

                    else if (keyboardState.IsKeyDown(Keys.B) && !prevKeyboardState.IsKeyDown(Keys.B))
                    {
                        character = "b";
                    }

                    else if (keyboardState.IsKeyDown(Keys.D) && !prevKeyboardState.IsKeyDown(Keys.D))
                    {
                        character = "d";
                    }

                    else if (keyboardState.IsKeyDown(Keys.F) && !prevKeyboardState.IsKeyDown(Keys.F))
                    {
                        character = "f";
                    }

                    else if (keyboardState.IsKeyDown(Keys.G) && !prevKeyboardState.IsKeyDown(Keys.G))
                    {
                        character = "g";
                    }

                    else if (keyboardState.IsKeyDown(Keys.H) && !prevKeyboardState.IsKeyDown(Keys.H))
                    {
                        character = "h";
                    }

                    else if (keyboardState.IsKeyDown(Keys.J) && !prevKeyboardState.IsKeyDown(Keys.J))
                    {
                        character = "j";
                    }

                    else if (keyboardState.IsKeyDown(Keys.K) && !prevKeyboardState.IsKeyDown(Keys.K))
                    {
                        character = "k";
                    }

                    else if (keyboardState.IsKeyDown(Keys.L) && !prevKeyboardState.IsKeyDown(Keys.L))
                    {
                        character = "l";
                    }

                    else if (keyboardState.IsKeyDown(Keys.Z) && !prevKeyboardState.IsKeyDown(Keys.Z))
                    {
                        character = "z";
                    }

                    else if (keyboardState.IsKeyDown(Keys.X) && !prevKeyboardState.IsKeyDown(Keys.X))
                    {
                        character = "x";
                    }

                    else if (keyboardState.IsKeyDown(Keys.C) && !prevKeyboardState.IsKeyDown(Keys.C))
                    {
                        character = "c";
                    }

                    else if (keyboardState.IsKeyDown(Keys.V) && !prevKeyboardState.IsKeyDown(Keys.V))
                    {
                        character = "v";
                    }

                    else if (keyboardState.IsKeyDown(Keys.N) && !prevKeyboardState.IsKeyDown(Keys.N))
                    {
                        character = "n";
                    }

                    else if (keyboardState.IsKeyDown(Keys.M) && !prevKeyboardState.IsKeyDown(Keys.M))
                    {
                        character = "m";
                    }

                    else if (keyboardState.IsKeyDown(Keys.S) && !prevKeyboardState.IsKeyDown(Keys.S))
                    {
                        character = "s";
                    }

                    else if (keyboardState.IsKeyDown(Keys.Space) && !prevKeyboardState.IsKeyDown(Keys.Space))
                    {
                        character = " ";
                    }

                    if (keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift))
                    {
                        character = character.ToUpper();
                    }

                    if (character.Length > 0)
                    {
                        string theStr = "";

                        if (mIndex < mText.Length - 1)
                        {
                            for (int i = 0; i < mText.Length; i++)
                            {
                                theStr += mText[i].ToString();

                                if (mIndex == i)
                                {
                                    theStr += character;
                                }
                            }

                            mText = theStr;
                        }

                        else
                        {
                            mText += character;
                        }

                        mCursorPosition.X += getSpriteFont().MeasureString(character).X;

                        mIndex++;
                    }
                }
            }

            base.update(mouseState, prevMouseState, keyboardState, prevKeyboardState);
        }

        public override void render(SpriteBatch g)
        {
            base.render(g);

            if (mText.Length > 0)
            {
                g.DrawString(getSpriteFont(), mText, new Vector2(getX() + 3, getY() + 3), getSpriteFontColor());
            }

            g.Draw(mCursorImg, new Rectangle((int)mCursorPosition.X, (int)mCursorPosition.Y, 2, (int)getSpriteFont().MeasureString("Z").Y), mCursorColor);
        }
    }
}
