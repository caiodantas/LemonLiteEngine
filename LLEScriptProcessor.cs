using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace LemonLiteEngine
{
    public class LLEScriptProcessor
    {
        LLEObject targetObject;

        List<LLEScriptVariable> scriptVariables;

        //Command Data

        string command = "";

        string variableName = "";

        string variableValue = "";

        string scriptScopeName = "";

        string trueConditionScope = "";

        string falseConditionScope = "";

        string externObjectName = "";

        string objectVisible = "";

        string externSprite = "";

        string objectSprite = "";

        bool ignoreTags = false;

        string tagName = "";

        string mSaveSlotName = "";

        string mMessageTarget = "";

        string itemName = "";

        string eventMsgIcon = "";

        bool eventMsg = false;

        Assets assets;

        LLEMapChangeManager mapChangeManager;

        LLEMapFrontLayer mFrontLayer;

        public LLEScriptProcessor(Assets theAssets, string saveSlotName, LLEMapFrontLayer frontLayer)
        {
            assets = theAssets;

            mSaveSlotName = saveSlotName;

            scriptVariables = new List<LLEScriptVariable>();

            mFrontLayer = frontLayer;

            mapChangeManager = new LLEMapChangeManager(assets, mFrontLayer);
        }

        public void release()
        {
            for (int i = 0; i < scriptVariables.Count; i++)
            {
                scriptVariables[i] = null;
            }

            scriptVariables.Clear();

            scriptVariables = null;

            mapChangeManager.release();
        }

        public void saveGame()
        {
            StreamWriter fileWriter = null;

            string fileName = "";

            string objectName = "";

            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (fileName == "")
                {
                    fileName = "LemonPlatformEditor/ContentDatabase/" + mSaveSlotName + "/" + scriptVariables[i].mObjectName + "Variables.xml";

                    objectName = scriptVariables[i].mObjectName;

                    fileWriter = new StreamWriter(fileName);

                    fileWriter.WriteLine("<Variables>");
                }

                else if (objectName != scriptVariables[i].mObjectName)
                {
                    objectName = scriptVariables[i].mObjectName;

                    fileName = "LemonPlatformEditor/ContentDatabase/" + mSaveSlotName + "/" + scriptVariables[i].mObjectName + "Variables.xml";

                    fileWriter.WriteLine("</Variables>");

                    fileWriter.Close();

                    fileWriter = null;

                    fileWriter = new StreamWriter(fileName);

                    fileWriter.WriteLine("<Variables>");
                }

                fileWriter.WriteLine("<VariableName>" + scriptVariables[i].mVariableName + "</VariableName>");

                fileWriter.WriteLine("<VariableValue>" + scriptVariables[i].mVariableValue + "</VariableValue>");
            }

            if (fileWriter != null)
            {
                fileWriter.WriteLine("</Variables>");

                fileWriter.Close();
            }

            mapChangeManager.saveChangeList();
        }

        protected void setObjectSprite()
        {
            targetObject.getSprite().setTexture(assets.getTexture(objectSprite));

            mapChangeManager.addChange(new LLEMapChange(1, targetObject.clone(), objectSprite));
        }

        protected void setExternalSprite()
        {
            LLEObject externObject = mFrontLayer.getObjectByName(externObjectName);

            externObject.getSprite().setTexture(assets.getTexture(externSprite));

            mapChangeManager.addChange(new LLEMapChange(1, externObject.clone(), externSprite));
        }

        public LLEMapChangeManager getMapChangeManager()
        {
            return mapChangeManager;
        }

        protected void setScriptVariable()
        {
            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (scriptVariables[i] != null && scriptVariables[i].mObjectName == targetObject.getName() && scriptVariables[i].mVariableName == variableName)
                {
                    scriptVariables[i].mVariableValue = variableValue;

                    break;
                }
            }
        }

        protected void setExternalVariable()
        {
            bool foundVariable = false;

            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (scriptVariables[i] != null && scriptVariables[i].mObjectName == externObjectName && scriptVariables[i].mVariableName == variableName)
                {
                    scriptVariables[i].mVariableValue = variableValue;

                    foundVariable = true;

                    break;
                }
            }

            if (!foundVariable)
            {
                addExternalVariableToList();
            }
        }

        protected void setObjectVisibility()
        {
            LLEObject theObject = mFrontLayer.getObjectByName(externObjectName);

            if (objectVisible == "TRUE")
            {
                theObject.setEnabled(true);

                theObject.getSprite().setVisible(true);
            }

            else
            {
                theObject.setEnabled(false);

                theObject.getSprite().setVisible(false);
            }

            mapChangeManager.addChange(new LLEMapChange(2, theObject.clone(), objectVisible));
        }

        protected bool variableExists(string theVariableName)
        {
            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (scriptVariables[i] != null && scriptVariables[i].mObjectName == targetObject.getName() && scriptVariables[i].mVariableName == theVariableName)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool verifyVariableValue()
        {
            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (scriptVariables[i] != null && scriptVariables[i].mObjectName == targetObject.getName() && scriptVariables[i].mVariableName == variableName && scriptVariables[i].mVariableValue == variableValue)
                {
                    return true;
                }
            }

            return false;
        }

        protected void addScriptVariableToList()
        {
            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (scriptVariables[i] != null && scriptVariables[i].mObjectName == targetObject.getName() && scriptVariables[i].mVariableName == variableName)
                {
                    return;
                }
            }

            scriptVariables.Add(new LLEScriptVariable(targetObject.getName(), variableName, variableValue));
        }

        protected void addExternalVariableToList()
        {
            for (int i = 0; i < scriptVariables.Count; i++)
            {
                if (scriptVariables[i] != null && scriptVariables[i].mObjectName == externObjectName && scriptVariables[i].mVariableName == variableName)
                {
                    return;
                }
            }

            scriptVariables.Add(new LLEScriptVariable(externObjectName, variableName, variableValue));
        }

        public void extractObjectVariables(LLEObject theTargetObject)
        {
            targetObject = theTargetObject;

            if (File.Exists("LemonPlatformEditor/ContentDatabase/" + mSaveSlotName + "/" + targetObject.getName() + "Variables.xml"))
            {
                XmlTextReader xmlParser = new XmlTextReader("LemonPlatformEditor/ContentDatabase/" + mSaveSlotName + "/" + targetObject.getName() + "Variables.xml");

                while (xmlParser.Read())
                {
                    if (xmlParser.NodeType == XmlNodeType.Element)
                    {
                        tagName = xmlParser.Name;
                    }

                    else if (xmlParser.NodeType == XmlNodeType.Text)
                    {
                        if (tagName == "VariableName")
                        {
                            variableName = xmlParser.Value;
                        }

                        else if (tagName == "VariableValue")
                        {
                            variableValue = xmlParser.Value;

                            addScriptVariableToList();
                        }
                    }
                }

                xmlParser.Close();
            }
        }

        public void addItemToInventory(string itemName)
        {
            mFrontLayer.getPlayerInventory().Add(new LLEObject(0, 0));

            mFrontLayer.getPlayerInventory().Last().setName(itemName);

            mFrontLayer.getPlayerInventory().Last().getSprite().setTexture(assets.getTexture(itemName));
        }

        public bool hasItem(string itemName)
        {
            for (int i = 0; i < mFrontLayer.getPlayerInventory().Count; i++)
            {
                if (mFrontLayer.getPlayerInventory()[i] != null && mFrontLayer.getPlayerInventory()[i].getName() == itemName)
                {
                    return true;
                }
            }

            return false;
        }

        public void removeItemFromInventory(string itemName)
        {
            for (int i = 0; i < mFrontLayer.getPlayerInventory().Count; i++)
            {
                if (mFrontLayer.getPlayerInventory()[i] != null && mFrontLayer.getPlayerInventory()[i].getName() == itemName)
                {
                    mFrontLayer.getPlayerInventory().RemoveAt(i);
                }
            }
        }

        public void executeScript(LLEMessageManager msgManager, LLEPlayerData playerData)
        {
            XmlTextReader xmlParser = new XmlTextReader("LemonPlatformEditor/ContentDatabase/Scripts/" + targetObject.getScriptName() + ".xml");

            while (xmlParser.Read())
            {
                if (xmlParser.NodeType == XmlNodeType.Element)
                {
                    tagName = xmlParser.Name;

                    switch (tagName)
                    {
                        case "ScriptScope":
                        case "SetSprite":
                        case "VerifyVariable":
                        case "SetVariable":
                        case "MessageBalloon":
                        case "SetTargetVariable":
                        case "SetTargetSprite":
                        case "SetScriptVisibility":
                        case "GiveItem":
                        case "HasItem":
                        case "RemoveItem":
                        case "PlayerData.HasWeapon":
                        {
                            command = tagName;

                            break;
                        }
                    }
                }

                else if (xmlParser.NodeType == XmlNodeType.EndElement)
                {
                    if (xmlParser.Name == "ScriptScope")
                    {
                        ignoreTags = false;
                    }
                }

                else if (xmlParser.NodeType == XmlNodeType.Text)
                {
                    if (!ignoreTags)
                    {
                        switch (tagName)
                        {
                            case "ObjectName":
                            {
                                externObjectName = xmlParser.Value;

                                break;
                            }

                            case "ObjectVisible":
                            {
                                objectVisible = xmlParser.Value;

                                setObjectVisibility();

                                break;
                            }

                            case "VariableName":
                            {
                                variableName = xmlParser.Value;

                                break;
                            }

                            case "VariableValue":
                            {
                                variableValue = xmlParser.Value;

                                if (command == "SetVariable")
                                {
                                    setScriptVariable();
                                }

                                else if (command == "SetTargetVariable")
                                {
                                    setExternalVariable();
                                }

                                break;
                            }

                            case "TargetSprite":
                            {
                                externSprite = xmlParser.Value;

                                if (command == "SetTargetSprite")
                                {
                                    setExternalSprite();
                                }

                                break;
                            }

                            case "ItemName":
                            {
                                itemName = xmlParser.Value;

                                break;
                            }

                            case "IsTrue":
                                {
                                    trueConditionScope = xmlParser.Value;

                                    break;
                                }

                            case "IsFalse":
                                {
                                    falseConditionScope = xmlParser.Value;

                                    if (command == "VerifyVariable")
                                    {
                                        if (verifyVariableValue())
                                        {
                                            scriptScopeName = trueConditionScope;
                                        }

                                        else
                                        {
                                            scriptScopeName = falseConditionScope;
                                        }
                                    }

                                    else if (command == "HasItem")
                                    {
                                        if(hasItem(itemName))
                                        {
                                            scriptScopeName = trueConditionScope;
                                        }

                                        else
                                        {
                                            scriptScopeName = falseConditionScope;
                                        }
                                    }

                                    break;
                                }

                            case "ScopeName":
                                {
                                    if (command == "ScriptScope")
                                    {
                                        if (scriptScopeName != xmlParser.Value)
                                        {
                                            ignoreTags = true;
                                        }
                                    }

                                    break;
                                }

                            case "SetSprite":
                                {
                                    objectSprite = xmlParser.Value;

                                    setObjectSprite();

                                    break;
                                }

                            case "PlayerData.HasWeapon":
                                {
                                    playerData.mHasWeapon = Convert.ToBoolean(xmlParser.Value);

                                    break;
                                }

                            case "GiveItem":
                                {
                                    addItemToInventory(xmlParser.Value);

                                    break;
                                }

                            case "RemoveItem":
                                {
                                    removeItemFromInventory(xmlParser.Value);

                                    break;
                                }

                            case "Target":
                                {
                                    if (command == "MessageBalloon")
                                    {
                                        mMessageTarget = xmlParser.Value;
                                    }

                                    break;
                                }

                            case "EventMsgIcon":
                                {
                                    eventMsg = true;

                                    eventMsgIcon = xmlParser.Value;

                                    break;
                                }

                            case "Text":
                                {
                                    if (command == "MessageBalloon")
                                    {
                                        msgManager.setFocusEntity(mMessageTarget);

                                        msgManager.addMessage(xmlParser.Value, eventMsg, eventMsgIcon);

                                        eventMsgIcon = "";

                                        eventMsg = false;
                                    }

                                    break;
                                }
                        }
                    }
                }
            }

            xmlParser.Close();
        }
    }
}
