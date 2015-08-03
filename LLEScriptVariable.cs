using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonLiteEngine
{
    public class LLEScriptVariable
    {
        public string mObjectName;

        public string mVariableName;

        public string mVariableValue;

        public LLEScriptVariable(string objectName, string variableName, string variableValue)
        {
            mObjectName = objectName;

            mVariableName = variableName;

            mVariableValue = variableValue;
        }
    }
}
