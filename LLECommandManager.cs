using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace LemonLiteEngine
{
    public class LLECommandManager
    {
        public List<LLECommandScope> mCmdScopes;

        LLECommandScope mCurrentScope;

        GameTime mGameTime;

        public LLECommandManager()
        {
            mCurrentScope = null;

            mCmdScopes = new List<LLECommandScope>();
        }

        public void setGameTime(GameTime gameTime)
        {
            mGameTime = gameTime;
        }

        //Move this for ScriptManager

        public void gatherCommands(string scriptFile)
        {
            TextReader txtReader = new StreamReader(scriptFile + ".lmn");

            string fileText = txtReader.ReadToEnd().Replace("\r", "").Replace("\n", "");

            string[] commands = fileText.Replace(" ", "").Split(new char[] { ';' });

            LLECommandScope scope = null;

            for (int i = 0; i < commands.Length; i++)
            {
                string[] commandSplit = commands[i].Split(new char[] { '(' });

                string commandName = commandSplit[0];

                if (commandName != "")
                {
                    string[] commandParams = commandSplit[1].Replace(")", "").Replace(" ", "").Split(new char[] { ',' });

                    if (commandName == "startScope")
                    {
                        if (scope != null)
                        {
                            mCmdScopes.Add(scope.clone());

                            scope = null;
                        }

                        scope = new LLECommandScope(commandParams[0]);
                    }

                    else
                    {
                        scope.mCommands.Add(new LLECommand(commandName));

                        for (int j = 0; j < commandParams.Length; j++)
                        {
                            scope.mCommands.Last().mParams.Add(commandParams[j]);
                        }
                    }
                }
            }

            if (mCmdScopes.Count == 0)
            {
                mCmdScopes.Add(scope.clone());
            }
        }

        public void init()
        {
            if(mCmdScopes.Count > 0)
            {
                mCurrentScope = mCmdScopes[0];
            }
        }

        public void executeScope()
        {
            int i = 0;

            while(i < mCurrentScope.mCommands.Count)
            {
                if (mCurrentScope.mCommands[i].mName != "delay")
                {
                    executeCommand(mCurrentScope.mCommands[i]);

                    i++;
                }

                else
                {
                    //Increment Timer

                    if ((int)mCurrentScope.mCommands[i].mParams[1] >= (int)mCurrentScope.mCommands[i].mParams[0])
                    {
                        i++;
                    }

                    //Confirm Time properties

                    else if (Convert.ToInt32(mGameTime.ElapsedRealTime) % 100 == 0)
                    {
                        mCurrentScope.mCommands[i].mParams[1] = (int)mCurrentScope.mCommands[i].mParams[1] + 1;
                    }
                }
            }
        }

        public LLECommandScope getCommandScope(string scopeName)
        {
            for (int i = 0; i < mCmdScopes.Count; i++)
            {
                if (mCmdScopes[i].mName == scopeName)
                {
                    return mCmdScopes[i];
                }
            }

            return null;
        }

        public void executeCommand(LLECommand command)
        {
            switch (command.mName)
            {
                case "goToScope":
                {
                    LLECommandScope scope = getCommandScope((string)command.mParams[0]);

                    if (scope != null)
                    {
                        mCurrentScope = scope;

                        executeScope();
                    }

                    break;
                }

                //Other commands access gameplay engine
            }
        }
    }
}
