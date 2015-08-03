using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonLiteEngine
{
    public class LLEMapChange
    {
        //Type of Change
        //1 = OBJECT TEXTURE
        //2 = OBJECT VISIBILITY

        int mType;

        string mMapName;

        LLEObject mObject;

        string mNewState;

        public LLEMapChange(int type, LLEObject theObject, string newState)
        {
            mType = type;

            mObject = theObject;

            mMapName = theObject.getMapName();

            mNewState = newState;
        }

        public int getChangeType()
        {
            return mType;
        }

        public string getMapName()
        {
            return mMapName;
        }

        public LLEObject getObject()
        {
            return mObject;
        }

        public string getStateName()
        {
            return mNewState;
        }
    }
}
