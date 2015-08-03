using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonLiteEngine
{
    public class LLECommandScope
    {
        public string mName;

        public List<LLECommand> mCommands;

        public LLECommandScope(string name)
        {
            mName = name;

            mCommands = new List<LLECommand>();
        }

        public LLECommandScope clone()
        {
            LLECommandScope scope = new LLECommandScope(mName);

            for (int i = 0; i < mCommands.Count; i++)
            {
                scope.mCommands.Add(mCommands[i].clone());
            }

            return scope;
        }
    }
}
