using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonLiteEngine
{
    public class LLECommand
    {
        public string mName;

        public List<object> mParams;

        public LLECommand(string name)
        {
            mName = name;

            mParams = new List<object>();
        }

        public LLECommand clone()
        {
            LLECommand command = new LLECommand(mName);

            for (int i = 0; i < mParams.Count; i++)
            {
                command.mParams.Add(mParams[i]);
            }

            return command;
        }
    }
}
