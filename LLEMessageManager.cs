using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LemonLiteEngine
{
    public class LLEMessageManager
    {
        List<string> mMessages;

        List<bool> mEventMsgFlags;

        List<string> mEventMsgIcons;

        LLEMessageBalloon mMsgBalloon;

        int mIndex;

        bool mHasMessages;

        LLESprite focusEntity;

        LLEMapFrontLayer mFrontLayer;        

        public LLEMessageManager(Assets assets, LLEMapFrontLayer frontLayer)
        {
            mFrontLayer = frontLayer;

            mMsgBalloon = new LLEMessageBalloon(0, 0,
                         assets.MessageBalloon, assets.BalloonPointer, assets.Verdana10, mFrontLayer);

            mMessages = new List<string>();

            mEventMsgFlags = new List<bool>();

            mEventMsgIcons = new List<string>();

            mIndex = 0;

            mHasMessages = false;
        }

        public void release()
        {
            mMsgBalloon.release();

            mMsgBalloon = null;

            clearMessages();

            mMessages = null;

            mEventMsgFlags.Clear();

            mEventMsgFlags = null;

            mEventMsgIcons.Clear();

            mEventMsgIcons = null;
        }

        public bool hasMessages()
        {
            return mHasMessages;
        }

        public void addMessage(string message, bool isEventMsg, string eventMsgIcon)
        {
            mMessages.Add(message);

            mEventMsgFlags.Add(isEventMsg);

            mEventMsgIcons.Add(eventMsgIcon);

            mHasMessages = true;
        }

        public List<string> getMessages()
        {
            return mMessages;
        }

        public LLEMessageBalloon getMessageBalloon()
        {
            return mMsgBalloon;
        }

        protected void clearMessages()
        {
            mMessages.Clear();

            mHasMessages = false;

            mIndex = 0;
        }

        protected void nextMessage(Assets assets)
        {
            if (mIndex < mMessages.Count)
            {
                mMsgBalloon.getSprite().setTexture(assets.MessageBalloon);

                mMsgBalloon.setAsEventMsg(assets, mEventMsgFlags[mIndex]);

                mMsgBalloon.setText(mMessages[mIndex]);

                if (!mMsgBalloon.isEventMsg())
                {
                    mMsgBalloon.getSprite().setX(focusEntity.getX() - (mMsgBalloon.getSprite().getWidth() / 2) + (focusEntity.getFrameWidth() / 4));

                    mMsgBalloon.getSprite().setY(focusEntity.getY() - assets.BalloonPointer.Height - 2);

                    mMsgBalloon.getSprite().setY(mMsgBalloon.getSprite().getY() - mMsgBalloon.getSprite().getHeight());
                }

                else
                {
                    mMsgBalloon.getSprite().setTexture(assets.KeyItemBoard);

                    mMsgBalloon.setIcon(assets, mEventMsgIcons[mIndex]);

                    mMsgBalloon.getSprite().setX((mFrontLayer.getWindowWidth() / 2) - (assets.KeyItemBoard.Width / 2));

                    mMsgBalloon.getSprite().setY((mFrontLayer.getWindowHeight() / 2) - (assets.KeyItemBoard.Height / 2));
                }

                mIndex++;
            }

            else
            {
                clearMessages();

                mEventMsgFlags.Clear();

                mEventMsgIcons.Clear();
            }
        }

        public void setFocusEntity(string entityName)
        {
            focusEntity = mFrontLayer.getTargetEntity(entityName);
        }

        public void update(Assets assets, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            if (mHasMessages)
            {
                if (keyboardState.IsKeyDown(Keys.Z) && !prevKeyboardState.IsKeyDown(Keys.Z))
                {
                    nextMessage(assets);
                }
            }
        }

        public void render(SpriteBatch g)
        {
            if (mHasMessages)
            {
                mMsgBalloon.render(g);
            }
        }
    }
}
