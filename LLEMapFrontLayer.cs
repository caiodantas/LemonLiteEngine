using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LemonLiteEngine
{
    public class LLEMapFrontLayer
    {
        List<LLEObject> mapObjects;

        List<LLEObject> playerInventory;

        private List<LLEEnemy> mapEnemies;

        const int TILE_SIZE = 40;

        float cameraX, cameraY;

        Assets assets;

        LLEScriptProcessor scriptProcessor;

        public LLEMessageManager msgManager;

        LLESprite mPlayerCharacter;

        string mSaveSlotName;

        int mWindowWidth, mWindowHeight;

        bool attack = true;

        public LLEMapFrontLayer(Assets theAssets, string saveSlotName, int windowWidth, int windowHeight)
        {
            assets = theAssets;

            mapObjects = null;

            mapObjects = new List<LLEObject>();

            playerInventory = new List<LLEObject>();

            mapEnemies = new List<LLEEnemy>();

            msgManager = null;

            mPlayerCharacter = null;

            mSaveSlotName = saveSlotName;

            mWindowWidth = windowWidth;

            mWindowHeight = windowHeight;
        }

        public void init()
        {
            msgManager = new LLEMessageManager(assets, this);

            scriptProcessor = new LLEScriptProcessor(assets, mSaveSlotName, this);
        }

        public void release(bool reset)
        {
            releaseMapObjects(reset);

            releaseMapEnemies(reset);

            releasePlayerInventory();

            if (scriptProcessor != null)
            {
                scriptProcessor.release();

                scriptProcessor = null;
            }

            if (msgManager != null)
            {
                msgManager.release();

                msgManager = null;
            }
        }

        public int getWindowWidth()
        {
            return mWindowWidth;
        }

        public int getWindowHeight()
        {
            return mWindowHeight;
        }

        public List<LLEObject> getPlayerInventory()
        {
            return playerInventory;
        }

        public LLEScriptProcessor getScriptProcessor()
        {
            return scriptProcessor;
        }

        public void saveGame()
        {
            if (scriptProcessor != null)
            {
                scriptProcessor.saveGame();
            }
        }

        public string getSaveSlotName()
        {
            return mSaveSlotName;
        }

        public void tryDestroyObjects(LLESprite playerCharacter)
        {
            for (int i = 0; i < mapObjects.Count; i++)
            {
                bool collided = playerCharacter.isCollidingMap(new Vector4(mapObjects[i].getSprite().getX(), mapObjects[i].getSprite().getY(), mapObjects[i].getSprite().getHeight(), mapObjects[i].getSprite().getWidth()), new Vector2(cameraX, cameraY), true, true, 1);

                if (mapObjects[i].isDestroyable() == true && collided == true)
                {
                    mapObjects[i].release();

                    mapObjects[i] = null;

                    mapObjects.RemoveAt(i);

                    i = -1;
                }
            }
        }

        public void releaseMapEnemies(bool reset)
        {
            for (int i = 0; i < mapEnemies.Count; i++)
            {
                mapEnemies[i].release();

                mapEnemies[i] = null;
            }

            mapEnemies.Clear();

            mapEnemies = null;

            if (reset)
            {
                mapEnemies = new List<LLEEnemy>();
            }
        }

        public List<LLEEnemy> getEnemyList()
        {
            return mapEnemies;
        }

        public void triggerEnemyAppearal(LLESprite playerCharacter)
        {
            for (int i = 0; i < mapEnemies.Count; i++)
            {
                if (!mapEnemies[i].getSprite().isVisible() && (((mapEnemies[i].getSprite().getX() - cameraX) < playerCharacter.getX() && playerCharacter.getX() - (mapEnemies[i].getSprite().getX() - cameraX) < 250) || ((mapEnemies[i].getSprite().getX() - cameraX) > playerCharacter.getX() && (mapEnemies[i].getSprite().getX() - cameraX) - playerCharacter.getX() < 250))
                    && (((mapEnemies[i].getSprite().getY() - cameraY) < playerCharacter.getY() && playerCharacter.getY() - (mapEnemies[i].getSprite().getY() - cameraY) < 250) || ((mapEnemies[i].getSprite().getY() - cameraY) > playerCharacter.getY() && (mapEnemies[i].getSprite().getY() - cameraY) - playerCharacter.getY() < 250)))
                {
                    mapEnemies[i].getSprite().setVisible(true);
                }
            }
        }

        public void releaseMapObjects(bool reset)
        {
            for (int i = 0; i < mapObjects.Count; i++)
            {
                mapObjects[i].release();

                mapObjects[i] = null;
            }

            mapObjects.Clear();

            mapObjects = null;

            if (reset)
            {
                mapObjects = new List<LLEObject>();
            }
        }

        public void releasePlayerInventory()
        {
            for (int i = 0; i < playerInventory.Count; i++)
            {
                playerInventory[i].release();

                playerInventory[i] = null;
            }

            playerInventory.Clear();

            playerInventory = null;
        }

        public void doCharacterAttack(LLESprite playerCharacter)
        {
            if (attack)
            {
                playerCharacter.stopAnimation();

                if (playerCharacter.getDirection() == LLESprite.DIRECTION_DOWN)
                {
                    playerCharacter.startAnimation(32, 35);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_RIGHT)
                {
                    playerCharacter.startAnimation(36, 39);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_UP)
                {
                    playerCharacter.startAnimation(40, 43);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_LEFT)
                {
                    playerCharacter.startAnimation(44, 47);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_LEFT_UP)
                {
                    playerCharacter.startAnimation(48, 51);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_RIGHT_UP)
                {
                    playerCharacter.startAnimation(52, 55);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_RIGHT_DOWN)
                {
                    playerCharacter.startAnimation(56, 59);
                }

                else if (playerCharacter.getDirection() == LLESprite.DIRECTION_LEFT_DOWN)
                {
                    playerCharacter.startAnimation(60, 63);
                }
            }

            attack = true;
        }

        public void accessObject(LLESprite playerCharacter, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            mPlayerCharacter = playerCharacter;

            if (playerCharacter != null && (playerCharacter.getDirection() == LLESprite.DIRECTION_UP || playerCharacter.getDirection() == LLESprite.DIRECTION_LEFT_UP || playerCharacter.getDirection() == LLESprite.DIRECTION_RIGHT_UP)
                
                && keyboardState.IsKeyDown(Keys.Z) == true && prevKeyboardState.IsKeyDown(Keys.Z) == false)
            {
                for (int i = 0; i < mapObjects.Count; i++)
                {
                    if (mapObjects[i] != null && mapObjects[i].getSprite() != null)
                    {
                        LLESprite target = mapObjects[i].getSprite();

                        if (playerCharacter.isCollidingMap(new Vector4(target.getX(), target.getY(), target.getHeight(), target.getWidth()), new Vector2(cameraX, cameraY), false, true, 4) == true)
                        {
                            scriptProcessor.extractObjectVariables(mapObjects[i]);

                            attack = false;

                            break;
                        }
                    }
                }
            }
        }

        public void checkObjectCollision(LLESprite playerCharacter, LLEPlayerData playerData, KeyboardState keyboardState, KeyboardState prevKeyboardState)
        {
            mPlayerCharacter = playerCharacter;

            for (int i = 0; i < mapObjects.Count; i++)
            {
                if (mapObjects[i] != null && mapObjects[i].getSprite() != null && mapObjects[i].getSprite().isVisible())
                {
                    LLESprite target = mapObjects[i].getSprite();

                    if (mapObjects[i].isColliding() == true && playerCharacter.isCollidingMap(new Vector4(target.getX(), target.getY(), target.getHeight(), target.getWidth()), new Vector2(cameraX, cameraY), true, true, 4) == true)
                    {
                        if ((playerCharacter.getDirection() == LLESprite.DIRECTION_UP || playerCharacter.getDirection() == LLESprite.DIRECTION_LEFT_UP || playerCharacter.getDirection() == LLESprite.DIRECTION_RIGHT_UP)

                            && keyboardState.IsKeyDown(Keys.Z) == true && prevKeyboardState.IsKeyDown(Keys.Z) == false)
                        {
                            if (mapObjects[i].getScriptName().Replace("NONE", "" ).Replace(" ", "") != "")
                            {
                                playerCharacter.setAttacking(false);

                                scriptProcessor.extractObjectVariables(mapObjects[i]);

                                scriptProcessor.executeScript(msgManager, playerData);
                            }

                            break;
                        }
                    }
                }
            }
        }

        public void checkShurikenOnObjects(List<LLESprite> shurikens)
        {
            for (int j = 0; j < shurikens.Count; j++)
            {
                for (int i = 0; i < mapObjects.Count; i++)
                {
                    if (shurikens[j] != null && mapObjects[i] != null && mapObjects[i].getSprite() != null && mapObjects[i].getSprite().isVisible())
                    {
                        LLESprite target = mapObjects[i].getSprite();

                        if (shurikens[j].isCollidingMap(new Vector4(target.getX(), target.getY(), target.getHeight(), target.getWidth()), new Vector2(cameraX, cameraY), true, false, 0) == true)
                        {
                            shurikens.RemoveAt(j);

                            break;
                        }
                    }
                }
            }
        }

        public LLESprite getTargetEntity(string entityName)
        {
            if (entityName == "PLAYER")
            {
                return mPlayerCharacter;
            }

            //Find an entity with entityName

            return null;
        }

        public void renderMapEnemies(SpriteBatch g)
        {
            if (mapEnemies != null)
            {
                for (int i = 0; i < mapEnemies.Count; i++)
                {
                    if (mapEnemies[i] != null)
                    {
                        mapEnemies[i].getSprite().renderXY(g, mapEnemies[i].getSprite().getX() - cameraX, mapEnemies[i].getSprite().getY() - cameraY);
                    }
                }
            }
        }

        public void renderMapObjects(SpriteBatch g)
        {
            if (mapObjects != null)
            {
                for (int i = 0; i < mapObjects.Count; i++)
                {
                    if (mapObjects[i] != null)
                    {
                        mapObjects[i].getSprite().renderXY(g, mapObjects[i].getSprite().getX() - cameraX, mapObjects[i].getSprite().getY() - cameraY);

                        //g.DrawString(assets.VerdanaBig, ((int)mapObjects[i].getSprite().getX() - (int)cameraX).ToString() + "; " + ((int)mapObjects[i].getSprite().getY() - (int)cameraY).ToString(), new Vector2(mapObjects[i].getSprite().getX() - cameraX, mapObjects[i].getSprite().getY() - cameraY), Color.Black);
                    }
                }
            }
        }

        public LLEObject getObjectByName(string objectName)
        {
            if (mapObjects != null)
            {
                for (int i = 0; i < mapObjects.Count; i++)
                {
                    if (mapObjects[i] != null && mapObjects[i].getName() == objectName)
                    {
                        return mapObjects[i];
                    }
                }
            }

            return null;
        }

        public void setCameraX(float theCameraX)
        {
            cameraX = theCameraX;
        }

        public void setCameraY(float theCameraY)
        {
            cameraY = theCameraY;
        }

        public LLEObject getLastObject()
        {
            return mapObjects.Last();
        }

        public void addObject(float x, float y, string name, string scriptName, string textureName)
        {
            mapObjects.Add(new LLEObject(x, y));

            mapObjects.Last().setName(name);

            mapObjects.Last().setScriptName(scriptName);

            mapObjects.Last().getSprite().setTexture(assets.getTexture(textureName));

            mapObjects.Last().getSprite().setTextureName(textureName);
        }
    }
}
