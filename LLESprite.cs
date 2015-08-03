using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLESprite
    {
        //Atributes

        private float mX, mY;

        private float mRotation;

        private int mW, mH;

        private float mXVel, mYVel;

        private float mSpeed;

        private float mRotationSpeed;

        private Texture2D mTexture;

        private Color mTextureColor;

        private bool mVisible;

        private string mTextureName;

        public float mInitialX, mInitialY;


        //Animation

        float mAnimTimer = 0.0f;

        float mAnimInterval = 0.0f;

        int mFrameCount = 0;

        int mCurrentFrame = 0;

        int mInitialFrame = 0;

        int mFinalFrame = 0;

        int mFrameWidth = 0;

        int mFrameHeight = 0;

        Rectangle mSourceRect;

        Rectangle mDestinationRect;

        bool mAnimating = false;

        bool mMoving = true;

        int mDirection = -1;

        public const int DIRECTION_LEFT = 0;

        public const int DIRECTION_LEFT_UP = 1;

        public const int DIRECTION_LEFT_DOWN = 2;

        public const int DIRECTION_RIGHT = 3;

        public const int DIRECTION_RIGHT_UP = 4;

        public const int DIRECTION_RIGHT_DOWN = 5;

        public const int DIRECTION_UP = 6;

        public const int DIRECTION_DOWN = 7;

        Viewport viewport;

        Vector2 originVector;

        Vector2 destinationVector;

        float rotationAngle = 0.0f;

        private bool characterAttacking;


        //Methods

        public LLESprite(float x, float y, float xVel, float yVel, float speed)
        {
            mX = x;

            mY = y;

            mXVel = xVel;

            mYVel = yVel;

            mSpeed = speed;

            init();
        }

        public LLESprite(Vector2 spritePos)
        {
            mX = spritePos.X;

            mY = spritePos.Y;

            mXVel = mYVel = mSpeed = 0.0f;

            init();
        }

        public LLESprite(Vector2 spritePos, Texture2D texture)
        {
            mX = spritePos.X;

            mY = spritePos.Y;

            mXVel = mYVel = mSpeed = 0.0f;

            init();

            setTexture(texture);
        }

        public LLESprite(Vector4 spriteData)
        {
            mX = spriteData.X;

            mY = spriteData.Y;

            mXVel = spriteData.Z;

            mYVel = spriteData.W;

            mSpeed = 0.0f;

            init();
        }

        protected void init()
        {
            mW = mH = 0;

            mRotation = mRotationSpeed = 0.0f;

            mVisible = true;

            mTexture = null;

            mTextureColor = Color.White;

            characterAttacking = false;
        }

        static public bool mouseOverRect(Rectangle rect, int mouseX, int mouseY)
        {
            if (mouseX > rect.X && mouseX < (rect.X + rect.Width) && mouseY > rect.Y && mouseY < (rect.Y + rect.Height))
            {
                return true;
            }

            return false;
        }

        public bool mouseOverWH(int mouseX, int mouseY, int width, int height)
        {
            if (mouseX > mX && mouseX < (mX + width) && mouseY > mY && mouseY < (mY + height))
            {
                return true;
            }

            return false;
        }

        public void setAttacking(bool attacking)
        {
            characterAttacking = attacking;
        }

        public bool isAttacking()
        {
            return characterAttacking;
        }

        public void setRotationSettings(GraphicsDevice device)
        {
            viewport = device.Viewport;

            originVector = new Vector2(mTexture.Width / 2, mTexture.Height / 2);

            destinationVector = new Vector2(viewport.Width / 2, viewport.Height / 2);
        }

        public void updateRotation(GameTime gameTime, float rotationSpeed)
        {
            rotationAngle += (float)((float)(gameTime.ElapsedGameTime.Ticks / 100000.0f) * rotationSpeed);

            float circle = MathHelper.Pi * 2;

            rotationAngle = rotationAngle % circle;
        }

        public void setDirection(int theDirection)
        {
            mDirection = theDirection;
        }

        public int getDirection()
        {
            return mDirection;
        }

        public void setAnimation(float interval, int frameCount)
        {
            mAnimInterval = interval;

            mFrameCount = frameCount;

            mFrameWidth = mTexture.Width / mFrameCount;

            mFrameHeight = mTexture.Height;
        }

        public int getFrameWidth()
        {
            return mFrameWidth;
        }

        public int getFrameHeight()
        {
            return mFrameHeight;
        }

        public void setMoving(bool moving)
        {
            mMoving = moving;
        }

        public bool isMoving()
        {
            return mMoving;
        }

        public void startAnimation(int initialFrame, int finalFrame)
        {
            mAnimating = true;

            mInitialFrame = initialFrame;

            mCurrentFrame = mInitialFrame;

            mFinalFrame = finalFrame;
        }

        public void stopAnimation()
        {
            mAnimating = false;

            mCurrentFrame = mInitialFrame;
        }

        public void animate(GameTime gameTime)
        {
            if (mAnimating)
            {
                mAnimTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (mAnimTimer > mAnimInterval)
                {
                    mCurrentFrame++;

                    if (mCurrentFrame > mFinalFrame)
                    {
                        mCurrentFrame = mInitialFrame;

                        characterAttacking = false;
                    }

                    mAnimTimer = 0.0f;
                }
            }

            mSourceRect = new Rectangle(mCurrentFrame * mFrameWidth, 0, mFrameWidth, mFrameHeight);

            updateRectangle();
        }

        public void updateRectangle()
        {
            mDestinationRect = new Rectangle((int)mX, (int)mY, mFrameWidth, mFrameHeight);
        }

        public void setTextureName(string name)
        {
            mTextureName = name;
        }

        public string getTextureName()
        {
            return mTextureName;
        }

        public float getX()
        {
            return mX;
        }

        public int getXi()
        {
            return (int)mX;
        }

        public float getY()
        {
            return mY;
        }

        public int getYi()
        {
            return (int)mY;
        }

        public Vector2 getXYi()
        {
            return new Vector2((int)mX, (int)mY);
        }

        public int getWidth()
        {
            return mW;
        }

        public int getHeight()
        {
            return mH;
        }

        public Vector2 getWH()
        {
            return new Vector2(mW, mH);
        }

        public float getXVel()
        {
            return mXVel;
        }

        public float getYVel()
        {
            return mYVel;
        }

        public float getSpeed()
        {
            return mSpeed;
        }

        public float getRotation()
        {
            return mRotation;
        }

        public float getRotationSpeed()
        {
            return mRotationSpeed;
        }

        public Texture2D getTexture()
        {
            return mTexture;
        }

        public Color getTextureColor()
        {
            return mTextureColor;
        }

        public void setXY(float newX, float newY)
        {
            mX = newX;

            mY = newY;
        }

        public Vector2 getXY()
        {
            return new Vector2(mX, mY);
        }

        public Vector2 getXY(float offsetX, float offsetY)
        {
            return new Vector2(mX + offsetX, mY + offsetY);
        }

        public Vector2 getWH(float offsetW, float offsetH)
        {
            return new Vector2(mW + offsetW, mH + offsetH);
        }

        public Vector2 getCenter()
        {
            return new Vector2(mX + (mW / 2), mY + (mH / 2));
        }

        public Vector2 getCenter(Texture2D texture)
        {
            return new Vector2(mX + (mW / 2) - (texture.Width / 2), mY + (mH / 2) - (texture.Height / 2));
        }

        public Vector2 getCenter(SpriteFont font, string message)
        {
            return new Vector2((int)(mX + (mW / 2) - (font.MeasureString(message).X / 2)), (int)(mY + (mH / 2) - (font.MeasureString(message).Y / 2)));
        }

        public void setX(float newX)
        {
            mX = newX;
        }

        public void setY(float newY)
        {
            mY = newY;
        }

        public void setWidth(int newWidth)
        {
            mW = newWidth;
        }

        public void setHeight(int newHeight)
        {
            mH = newHeight;
        }

        public void setWH(int width, int height)
        {
            mW = width;

            mH = height;
        }

        public void setWH(Vector2 size)
        {
            mW = (int)size.X;

            mH = (int)size.Y;
        }

        public void setXVel(float newXVel)
        {
            mXVel = newXVel;
        }

        public void setYVel(float newYVel)
        {
            mYVel = newYVel;
        }

        public void setSpeed(float newSpeed)
        {
            mSpeed = newSpeed;
        }

        public void setRotation(float newRotation)
        {
            mRotation = newRotation;
        }

        public void setRotationSpeed(float newSpeed)
        {
            mRotationSpeed = newSpeed;
        }

        public void setTexture(Texture2D newTexture)
        {
            mTexture = newTexture;

            if (mTexture != null)
            {
                mW = mTexture.Width;

                mH = mTexture.Height;
            }
        }

        public void setTexture(Texture2D newTexture, int width, int height)
        {
            mTexture = newTexture;

            if (mTexture != null)
            {
                mW = width;

                mH = height;
            }
        }

        public void setTextureColor(Color newColor)
        {
            mTextureColor = newColor;
        }

        public void move(float theFrac)
        {
            if (mMoving)
            {
                mX += mXVel * theFrac;

                mY += mYVel * theFrac;
            }
        }

        public void stopIt()
        {
            mXVel = mYVel = 0;
        }

        public void setVisible(bool IsVisib)
        {
            mVisible = IsVisib;
        }

        public bool isVisible()
        {
            return mVisible;
        }

        public bool collide(LLESprite target, float offsetX, float offsetY)
        {
            if(target != null)
	        {
                float targetX = target.getX();

                float targetY = target.getY();

                float targetW = target.getWidth();

                float targetH = target.getHeight();

                int theWidth = mW;

                if (mAnimating)
                {
                    theWidth = getFrameWidth();
                }

                if (mX + theWidth >= targetX + offsetX && mX <= targetX + targetW - offsetX &&

                   mY + mH >= targetY + offsetY && mY <= targetY + targetH - offsetY)
		        {
			        return true;
		        }
	        }

	        return false;
        }

        public virtual void render(SpriteBatch renderer)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, new Vector2(mX, mY), mTextureColor);
            }
        }

        public void renderRotating(SpriteBatch renderer)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, new Vector2(mX, mY), null, Color.White, rotationAngle, originVector, 1.0f, SpriteEffects.None, 0.0f);
            }
        }

        public void renderXY(SpriteBatch renderer, float x, float y)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, new Vector2(x, y), mTextureColor);
            }
        }

        public void renderRect(SpriteBatch renderer)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, mDestinationRect, mSourceRect, Color.White);
            }
        }

        public void renderStretched(SpriteBatch renderer)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, new Rectangle(Convert.ToInt32(mX), Convert.ToInt32(mY), Convert.ToInt32(mW), Convert.ToInt32(mH)), mTextureColor);
            }
        }

        public void renderStretched(SpriteBatch renderer, int width, int height)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, new Rectangle(Convert.ToInt32(mX), Convert.ToInt32(mY), width, height), mTextureColor);
            }
        }

        public void renderStretchedXY(SpriteBatch renderer, int x, int y, int width, int height)
        {
            if (mVisible)
            {
                renderer.Draw(mTexture, new Rectangle(x, y, width, height), mTextureColor);
            }
        }

        public bool mouseOver(int mouseX, int mouseY)
        {
            if (mouseX > mX && mouseX < (mX + mW) && mouseY > mY && mouseY < (mY + mH))
            {
                return true;
            }

            return false;
        }

        public bool mouseOver(MouseState mouseState)
        {
            return mouseOver(mouseState.X, mouseState.Y);
        }

        public bool mouseOverEx(int mouseX, int mouseY, int paddingX, int paddingY)
        {
            if (mouseX > mX - paddingX && mouseX < (mX + mW - paddingX) && mouseY > mY - paddingY && mouseY < (mY + mH - paddingY))
            {
                return true;
            }

            return false;
        }

        public bool isCollidingMap(Vector4 theTargetData, Vector2 cameraCoords, bool stopSprite, bool animatingSprite, int heightOffsetDivider)
        {
            //W = Width

            //Z = Height

            float X = getX();

            float Y = getY();

            float W = getWidth();

            float H = getHeight();

            if (animatingSprite)
            {
                W = getFrameWidth();
            }

            if (X > theTargetData.X - cameraCoords.X

                && X < theTargetData.X - cameraCoords.X + theTargetData.W + 3

                && Y + H > theTargetData.Y - cameraCoords.Y && Y + H < theTargetData.Y - cameraCoords.Y + theTargetData.Z)
            {
                if (stopSprite && getXVel() < 0.0f)
                {
                    setXVel(0.0f);
                }

                return true;
            }

            else if ( X < theTargetData.X - cameraCoords.X + theTargetData.W - 5

                && X + W - (W / 4) + 8 > theTargetData.X - cameraCoords.X

                && Y + H > theTargetData.Y - cameraCoords.Y && Y + H < theTargetData.Y - cameraCoords.Y + theTargetData.Z)
            {
                if (stopSprite && getXVel() > 0.0f)
                {
                    setXVel(0.0f);
                }

                return true;
            }

            int heightOffset = (int)(H / heightOffsetDivider);

            if (heightOffsetDivider == 0)
            {
                heightOffset = 0;
            }

            if ( Y + H > theTargetData.Y - cameraCoords.Y

                && Y + H - heightOffset < theTargetData.Y - cameraCoords.Y + theTargetData.Z

                && X + W - 15 > theTargetData.X - cameraCoords.X && X + 5 < theTargetData.X - cameraCoords.X + theTargetData.W)
            {
                if (stopSprite && getYVel() < 0.0f)
                {
                    setYVel(0.0f);
                }

                return true;
            }

            else if (((theTargetData.Z >= H && Y < theTargetData.Y - cameraCoords.Y) || (theTargetData.Z < H && Y + (H / 2) < theTargetData.Y - cameraCoords.Y))

                && Y + H > theTargetData.Y - cameraCoords.Y - 5

                && X + W - 5 > theTargetData.X - cameraCoords.X && X + 5 < theTargetData.X - cameraCoords.X + theTargetData.W)
            {
                if (stopSprite && getYVel() > 0.0f)
                {
                    setYVel(0.0f);
                }

                return true;
            }

            return false;
        }

        public virtual LLESprite clone()
        {
            LLESprite theSprite = new LLESprite(mX, mY, mXVel, mYVel, mSpeed);

            theSprite.setTexture(mTexture);

            theSprite.setTextureName(mTextureName);

            theSprite.setWidth(mW);

            theSprite.setHeight(mH);

            theSprite.setRotation(mRotation);

            theSprite.setRotationSpeed(mRotationSpeed);

            theSprite.setTextureColor(mTextureColor);

            theSprite.setVisible(mVisible);

            return theSprite;
        }
    }
}
