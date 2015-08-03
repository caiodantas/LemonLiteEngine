using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEPanelManager
    {
        public List<LLEPanel> mPanels;

        public LLEPanelManager()
        {
            mPanels = new List<LLEPanel>();
        }

        public void release()
        {
            for (int i = 0; i < mPanels.Count; i++)
            {
                mPanels[i].release();

                mPanels[i] = null;
            }

            mPanels.Clear();

            mPanels = null;
        }

        int mSelectedPanelIndex = 0;

        public void setFocus(LLEPanel panel)
        {
            for (int i = 0; i < mPanels.Count; i++)
            {
                if (mPanels[i] == panel)
                {
                    mSelectedPanelIndex = i;

                    break;
                }
            }
        }

        public int getNumOfVisiblePanels()
        {
            int count = 0;

            for (int i = 0; i < mPanels.Count; i++)
            {
                if (mPanels[i].isVisible())
                {
                    count++;
                }
            }

            return count;
        }

        public void update(MouseState mouseState, MouseState prevMouseState, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            if (mPanels.Count > 0)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    if (mSelectedPanelIndex >= 0)
                    {
                        for (int j = mPanels.Count - 1; j >= 0; j--)
                        {
                            if (mPanels[j].isVisible() && mPanels[j].isFirstClick(mouseState, prevMouseState) && (!mPanels[mSelectedPanelIndex].isVisible() || !mPanels[mSelectedPanelIndex].isFirstClick(mouseState, prevMouseState)))
                            {
                                mSelectedPanelIndex = j;

                                break;
                            }
                        }
                    }

                    else
                    {
                        mSelectedPanelIndex = 0;
                    }
                }

                if (mSelectedPanelIndex >= 0)
                {
                    if (!mPanels[mSelectedPanelIndex].isClosed())
                    {
                        if (mPanels[mSelectedPanelIndex].isVisible())
                        {
                            mPanels[mSelectedPanelIndex].update(prevMouseState, mouseState, keyboardState, prevKeyboardState);

                            mPanels[mSelectedPanelIndex].doDragging(mouseState, prevMouseState);
                        }
                    }

                    else
                    {
                        mPanels[mSelectedPanelIndex].release();

                        mPanels[mSelectedPanelIndex] = null;

                        mPanels.RemoveAt(mSelectedPanelIndex);

                        mSelectedPanelIndex--;
                    }
                }
            }
        }

        public void render(SpriteBatch g)
        {
            for (int i = 0; i < mPanels.Count; i++)
            {
                if (mPanels[i] != null && i != mSelectedPanelIndex)
                {
                    mPanels[i].render(g);
                }
            }

            if (mSelectedPanelIndex >= 0 && mPanels.Count > 0)
            {
                mPanels[mSelectedPanelIndex].render(g);
            }
        }
    }
}
