using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEMapBackLayer
    {
        LLESprite[,] tileGrid;

        LLESprite[,] tileGrid2;

        List<LLERect> collisionBoxes;

        List<LLEWarpBox> warpBoxes;

        int mMapW, mMapH;

        const int TILE_SIZE = 40;

        float cameraX, cameraY;

        int cameraXG, cameraYG;

        int mCameraDestX, mCameraDestY;

        float mCameraVelocityX, mCameraVelocityY;

        bool mAlignCamera;

        bool mWarping;

        Assets assets;

        public LLEMapBackLayer(Assets theAssets)
        {
            assets = theAssets;

            mMapW = mMapH = 0;

            cameraX = cameraY = cameraXG = cameraYG = 0;

            mCameraDestX = mCameraDestY = 0;

            mCameraVelocityX = mCameraVelocityY = 0.0f;

            collisionBoxes = new List<LLERect>();

            warpBoxes = new List<LLEWarpBox>();

            mAlignCamera = false;

            mWarping = false;
        }

        public void setWarping(bool warping)
        {
            mWarping = warping;
        }

        public bool isWarping()
        {
            return mWarping;
        }

        public void release(bool reset)
        {
            releaseCollisionBoxes(reset);

            releaseWarpBoxes(reset);

            clearGrid();
        }

        public bool isCameraAligning()
        {
            return mAlignCamera;
        }

        public void setMapWH(int mapW, int mapH)
        {
            mMapW = mapW;

            mMapH = mapH;

            tileGrid = new LLESprite[Convert.ToInt32(mMapW), Convert.ToInt32(mMapH)];

            tileGrid2 = new LLESprite[Convert.ToInt32(mMapW), Convert.ToInt32(mMapH)];
        }

        public int getMapW()
        {
            return mMapW;
        }

        public int getMapH()
        {
            return mMapH;
        }

        public void setCameraX(float theCameraX)
        {
            cameraX = theCameraX;
        }

        public void setCameraY(float theCameraY)
        {
            cameraY = theCameraY;
        }

        public float getCameraX()
        {
            return cameraX;
        }

        public float getCameraY()
        {
            return cameraY;
        }

        public int getTileSize()
        {
            return TILE_SIZE;
        }

        public int getTargetWarpID(string targetWarpID)
        {
            int index = -1;

            for (int i = 0; i < warpBoxes.Count; i++)
            {
                if (warpBoxes[i].mID == targetWarpID)
                {
                    index = i;

                    break;
                }
            }

            return index;
        }

        public void alignCameraToWarp(string targetWarpID, LLESprite playerCharacter)
        {
            int index = getTargetWarpID(targetWarpID);

            if (index != -1)
            {
                cameraX = warpBoxes[index].mX + (warpBoxes[index].mWidth / 2) - (10 * TILE_SIZE);

                cameraY = warpBoxes[index].mY - (7 * TILE_SIZE);

                if (cameraX < 0)
                {
                    cameraX = 0;
                }

                if (cameraY < 0)
                {
                    cameraY = 0;
                }

                if (warpBoxes[index].mDirection.ToUpper() == "UP")
                {
                    cameraY -= playerCharacter.getHeight() - 5;

                    playerCharacter.setX(warpBoxes[index].mX + (warpBoxes[index].mWidth / 2) - (playerCharacter.getFrameWidth() / 2) - cameraX);

                    playerCharacter.setY(warpBoxes[index].mY - playerCharacter.getHeight() - 5 - cameraY);
                }

                else if (warpBoxes[index].mDirection.ToUpper() == "DOWN")
                {
                    playerCharacter.setX(warpBoxes[index].mX + (warpBoxes[index].mWidth / 2) - (playerCharacter.getFrameWidth() / 2) - cameraX);

                    playerCharacter.setY(warpBoxes[index].mY + warpBoxes[index].mHeight - (playerCharacter.getHeight() / 2) - cameraY);
                }

                else if (warpBoxes[index].mDirection.ToUpper() == "LEFT")
                {
                    cameraX -= playerCharacter.getFrameWidth() - 5;

                    playerCharacter.setX(warpBoxes[index].mX - playerCharacter.getFrameWidth() - 5 - cameraX);

                    playerCharacter.setY(warpBoxes[index].mY + (warpBoxes[index].mHeight / 2) - (playerCharacter.getHeight() / 2) - cameraY);
                }

                else if (warpBoxes[index].mDirection.ToUpper() == "RIGHT")
                {
                    cameraX += playerCharacter.getFrameWidth() - 5;

                    playerCharacter.setX(warpBoxes[index].mX + warpBoxes[index].mWidth + 5 - cameraX);

                    playerCharacter.setY(warpBoxes[index].mY + (warpBoxes[index].mHeight / 2) - (playerCharacter.getHeight() / 2) - cameraY);
                }
            }
        }

        public void update()
        {
            cameraXG = (int)cameraX / TILE_SIZE;

            cameraYG = (int)cameraY / TILE_SIZE;
        }

        protected void releaseWarpBoxes(bool reset)
        {
            for (int i = 0; i < warpBoxes.Count; i++)
            {
                warpBoxes[i] = null;
            }

            warpBoxes.Clear();

            warpBoxes = null;

            if (reset)
            {
                warpBoxes = new List<LLEWarpBox>();
            }
        }

        public void renderWarpBoxes(SpriteBatch g)
        {
            for (int i = 0; i < warpBoxes.Count; i++)
            {
                if (warpBoxes[i] != null)
                {
                    g.Draw(assets.Point, new Rectangle((int)warpBoxes[i].mX - (int)cameraX, (int)warpBoxes[i].mY - (int)cameraY, (int)warpBoxes[i].mWidth, (int)warpBoxes[i].mHeight), new Color(255, 0, 0, 100));
                }
            }
        }

        protected void clearGrid()
        {
            if (tileGrid != null)
            {
                for (int x = 0; x < mMapW; x++)
                {
                    for (int y = 0; y < mMapH; y++)
                    {
                        tileGrid[x, y] = null;
                    }
                }
            }

            tileGrid = null;
        }

        protected void clearGrid2()
        {
            if (tileGrid2 != null)
            {
                for (int x = 0; x < mMapW; x++)
                {
                    for (int y = 0; y < mMapH; y++)
                    {
                        tileGrid2[x, y] = null;
                    }
                }
            }

            tileGrid2 = null;
        }

        public void renderCollisionBoxes(SpriteBatch g)
        {
            for (int i = 0; i < collisionBoxes.Count; i++)
            {
                if (collisionBoxes[i] != null)
                {
                    g.Draw(assets.Point, new Rectangle((int)collisionBoxes[i].mX - (int)cameraX, (int)collisionBoxes[i].mY - (int)cameraY, (int)collisionBoxes[i].mWidth, (int)collisionBoxes[i].mHeight), new Color(255, 0, 0, 100));
                }
            }
        }

        protected void releaseCollisionBoxes(bool reset)
        {
            for (int i = 0; i < collisionBoxes.Count; i++)
            {
                collisionBoxes[i] = null;
            }

            collisionBoxes.Clear();

            collisionBoxes = null;

            if (reset)
            {
                collisionBoxes = new List<LLERect>();
            }
        }

        public void setGridTile(int tileX, int tileY, string tileTexture, int layer)
        {
            if (layer == 1)
            {
                tileGrid[tileX, tileY] = new LLESprite(0, 0, 0, 0, 0);

                tileGrid[tileX, tileY].setTexture(assets.getTexture(tileTexture));

                tileGrid[tileX, tileY].setTextureName(tileTexture);
            }

            else
            {
                tileGrid2[tileX, tileY] = new LLESprite(0, 0, 0, 0, 0);

                tileGrid2[tileX, tileY].setTexture(assets.getTexture(tileTexture));

                tileGrid2[tileX, tileY].setTextureName(tileTexture);
            }
        }

        public void addCollisionBox(int boxX, int boxY, int boxWidth, int boxHeight)
        {
            collisionBoxes.Add(new LLERect(boxX, boxY, boxWidth, boxHeight));
        }

        public void addWarpBox(int boxX, int boxY, int boxWidth, int boxHeight, string warpID, string warpTargetID, string warpDirection, string warpTargetLevel)
        {
            warpBoxes.Add(new LLEWarpBox(boxX, boxY, boxWidth, boxHeight, warpID, warpTargetID, warpDirection, warpTargetLevel));
        }

        public void renderGridTiles(SpriteBatch g)
        {
            int renderLimitX = cameraXG + mMapW;

            int renderLimitY = cameraYG + mMapH;

            int theX = cameraXG - 1;

            if (theX < 0)
            {
                theX = 0;
            }

            int theY = cameraYG - 1;

            if (theY < 0)
            {
                theY = 0;
            }

            for (int x = theX; x < renderLimitX; x++)
            {
                for (int y = theY; y < renderLimitY; y++)
                {
                    if (x < mMapW && y < mMapH)
                    {
                        if (tileGrid[x, y] != null && tileGrid[x, y].getTexture() != null)
                        {
                            g.Draw(tileGrid[x, y].getTexture(), new Rectangle((x * TILE_SIZE) - (int)cameraX, (y * TILE_SIZE) - (int)cameraY, TILE_SIZE, TILE_SIZE), Color.White);
                        }

                        if (tileGrid2[x, y] != null && tileGrid2[x, y].getTexture() != null)
                        {
                            g.Draw(tileGrid2[x, y].getTexture(), new Rectangle((x * TILE_SIZE) - (int)cameraX, (y * TILE_SIZE) - (int)cameraY, TILE_SIZE, TILE_SIZE), Color.White);
                        }
                    }
                }
            }
        }

        public void checkBoxCollision(LLESprite playerCharacter)
        {
            List<LLERect> rectangles = collisionBoxes;

            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i] != null && playerCharacter != null)
                {
                    playerCharacter.isCollidingMap(new Vector4(rectangles[i].mX, rectangles[i].mY, rectangles[i].mHeight, rectangles[i].mWidth), new Vector2(cameraX, cameraY), true, true, 4);
                }
            }
        }

        public void checkShurikenCollision(List<LLESprite> shurikens)
        {
            List<LLERect> rectangles = collisionBoxes;

            for (int j = 0; j < shurikens.Count; j++)
            {
                for (int i = 0; i < rectangles.Count; i++)
                {
                    if (rectangles[i] != null && shurikens[j] != null && shurikens[j].isCollidingMap(new Vector4(rectangles[i].mX, rectangles[i].mY, rectangles[i].mHeight, rectangles[i].mWidth), new Vector2(cameraX, cameraY), true, false, 0))
                    {
                        shurikens.RemoveAt(j);

                        break;
                    }
                }
            }
        }

        public int checkWarpCollision(LLESprite playerCharacter)
        {
            List<LLEWarpBox> rectangles = warpBoxes;

            for (int i = 0; i < rectangles.Count; i++)
            {
                if (playerCharacter.isCollidingMap(new Vector4(rectangles[i].mX, rectangles[i].mY, rectangles[i].mHeight, rectangles[i].mWidth), new Vector2(cameraX, cameraY), true, true, 4) == true)
                {
                    return i;
                }
            }

            return -1;
        }

        public void warpPlayer(Game game, LLESprite playerCharacter, float mPlayerX, float mPlayerY, Vector2 windowSize)
        {
            int index = checkWarpCollision(playerCharacter);

            if (index != -1 && warpBoxes[index].mID.Replace(" ", "") != "-1" && warpBoxes[index].mTargetID.Replace(" ", "") != "-1")
            {
                if (warpBoxes[index].mTargetLevel == "NONE")
                {
                    for (int i = 0; i < warpBoxes.Count; i++)
                    {
                        if (i != index && warpBoxes[i] != null && warpBoxes[i].mID == warpBoxes[index].mTargetID)
                        {
                            if (warpBoxes[i].mDirection.ToUpper() == "UP")
                            {
                                playerCharacter.setX(warpBoxes[i].mX + (warpBoxes[i].mWidth / 2) - (playerCharacter.getFrameWidth() / 2));

                                playerCharacter.setY(warpBoxes[i].mY - playerCharacter.getHeight() - 10);

                                //game.setPlayerXY(playerCharacter.getX(), playerCharacter.getY());

                                playerCharacter.setVisible(false);
                            }

                            else if (warpBoxes[i].mDirection.ToUpper() == "DOWN")
                            {
                                playerCharacter.setX(warpBoxes[i].mX + (warpBoxes[i].mWidth / 2) - (playerCharacter.getFrameWidth() / 2));

                                playerCharacter.setY(warpBoxes[i].mY + (warpBoxes[i].mHeight / 2));

                                //game.setPlayerXY(playerCharacter.getX(), playerCharacter.getY());

                                playerCharacter.setVisible(false);
                            }

                            else if (warpBoxes[i].mDirection.ToUpper() == "LEFT")
                            {
                                playerCharacter.setX(warpBoxes[i].mX - playerCharacter.getFrameWidth() - 10);

                                playerCharacter.setY(warpBoxes[i].mY + (warpBoxes[i].mHeight / 2) - (playerCharacter.getFrameHeight() / 2));
                            }

                            else if (warpBoxes[i].mDirection.ToUpper() == "RIGHT")
                            {
                                playerCharacter.setX(warpBoxes[i].mX + warpBoxes[i].mWidth + 10);

                                playerCharacter.setY(warpBoxes[i].mY + (warpBoxes[i].mHeight / 2) - (playerCharacter.getFrameHeight() / 2));
                            }

                            setCameraDestination(new Vector2(playerCharacter.getX(), playerCharacter.getY()), windowSize);

                            mWarping = true;

                            break;
                        }
                    }
                }

                else
                {
                    //game.setWarpVariables(true, warpBoxes[index].mTargetLevel, warpBoxes[index].mTargetID);
                }
            }
        }

        public void setCameraDestination(Vector2 cameraDest, Vector2 windowSize)
        {
            mCameraDestX = (int)(cameraDest.X - (10 * TILE_SIZE));

            if (mCameraDestX < 0)
            {
                mCameraDestX = 0;
            }

            else if (mCameraDestX + windowSize.X > mMapW * TILE_SIZE)
            {
                mCameraDestX -= mCameraDestX + (int)windowSize.X - (mMapW * TILE_SIZE);
            }

            mCameraDestY = (int)(cameraDest.Y - (7 * TILE_SIZE));

            if (mCameraDestY < 0)
            {
                mCameraDestY = 0;
            }

            else if (mCameraDestY + windowSize.Y > mMapH * TILE_SIZE)
            {
                mCameraDestY -= mCameraDestY + (int)windowSize.Y - (mMapH * TILE_SIZE);
            }

            mCameraVelocityX = 4.0f;

            mCameraVelocityY = mCameraVelocityX;

            if (mCameraDestX < cameraX)
            {
                mCameraVelocityX *= -1;
            }

            if (mCameraDestY < cameraY)
            {
                mCameraVelocityY *= -1;
            }

            mAlignCamera = true;
        }

        public void setAlignCamera(bool alignCamera)
        {
            mAlignCamera = alignCamera;
        }

        public void alignCamera(GameTime gameTime, LLESprite playerCharacter, LLESprite partnerCharacter, Vector2 windowSize)
        {
            if ((mCameraVelocityX < 0.0f && cameraX < mCameraDestX) || (mCameraVelocityX > 0.0f && cameraX > mCameraDestX))
            {
                cameraX = mCameraDestX;

                mCameraVelocityX = 0.0f;
            }

            if ((mCameraVelocityY < 0.0f && cameraY < mCameraDestY) || (mCameraVelocityY > 0.0f && cameraY > mCameraDestY))
            {
                cameraY = mCameraDestY;

                mCameraVelocityY = 0.0f;
            }

            if (mCameraVelocityX == 0.0f && mCameraVelocityY == 0.0f)
            {
                mAlignCamera = false;

                playerCharacter.setXVel(0.0f);

                playerCharacter.setYVel(0.0f);

                partnerCharacter.setXVel(0.0f);

                partnerCharacter.setYVel(0.0f);

                return;
            }

            cameraX += (gameTime.ElapsedGameTime.Ticks / 100000.0f) * mCameraVelocityX;

            cameraY += (gameTime.ElapsedGameTime.Ticks / 100000.0f) * mCameraVelocityY;

            //Move playerCharacter and partnerCharacter

            playerCharacter.setX(playerCharacter.getX() - ((gameTime.ElapsedGameTime.Ticks / 100000.0f) * mCameraVelocityX));

            playerCharacter.setY(playerCharacter.getY() - ((gameTime.ElapsedGameTime.Ticks / 100000.0f) * mCameraVelocityY));

            playerCharacter.updateRectangle();

            if (partnerCharacter != null && partnerCharacter.isVisible())
            {
                partnerCharacter.setX(partnerCharacter.getX() - ((gameTime.ElapsedGameTime.Ticks / 100000.0f) * mCameraVelocityX));

                partnerCharacter.setY(partnerCharacter.getY() - ((gameTime.ElapsedGameTime.Ticks / 100000.0f) * mCameraVelocityY));

                partnerCharacter.updateRectangle();
            }
        }
    }
}
