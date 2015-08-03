using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LemonLiteEngine
{
    public class LLEMapChangeManager
    {
        List<LLEMapChange> mapChanges;

        Assets assets;

        LLEMapFrontLayer mFrontLayer;

        public LLEMapChangeManager(Assets theAssets, LLEMapFrontLayer frontLayer)
        {
            mapChanges = null;

            mapChanges = new List<LLEMapChange>();

            assets = theAssets;

            mFrontLayer = frontLayer;
        }

        public void release()
        {
            for (int i = 0; i < mapChanges.Count; i++)
            {
                mapChanges[i] = null;
            }

            mapChanges.Clear();

            mapChanges = null;
        }

        public void addChange(LLEMapChange mapChange)
        {
            mapChanges.Add(mapChange);
        }

        public void applyChanges(string mapName)
        {
            if (mapChanges.Count > 0)
            {
                for (int i = 0; i < mapChanges.Count; i++)
                {
                    if (mapChanges[i] != null && mapChanges[i].getMapName() == mapName)
                    {
                        if (mapChanges[i].getChangeType() == 1)
                        {
                            mFrontLayer.getObjectByName(mapChanges[i].getObject().getName()).getSprite().setTexture(assets.getTexture(mapChanges[i].getStateName()));
                        }

                        else if (mapChanges[i].getChangeType() == 2)
                        {
                            bool visible = true;

                            if (mapChanges[i].getStateName() == "FALSE")
                            {
                                visible = false;
                            }

                            LLEObject theObject = mFrontLayer.getObjectByName(mapChanges[i].getObject().getName());

                            theObject.setEnabled(visible);

                            theObject.getSprite().setVisible(visible);
                        }
                    }
                }
            }
        }

        public void saveChangeList()
        {
            if (mapChanges.Count > 0)
            {
                StreamWriter changeList = new StreamWriter("LemonPlatformEditor/ContentDatabase/" + mFrontLayer.getSaveSlotName() + "/ObjectChangeList.xml");

                changeList.WriteLine("<ChangeList>");

                for (int i = 0; i < mapChanges.Count; i++)
                {
                    changeList.WriteLine("<Change>");

                    changeList.WriteLine("<Type>" + mapChanges[i].getChangeType().ToString() + "</Type>");

                    changeList.WriteLine("<ObjectName>" + mapChanges[i].getObject().getName() + "</ObjectName>");

                    changeList.WriteLine("<StateName>" + mapChanges[i].getStateName() + "</StateName>");

                    changeList.WriteLine("</Change>");
                }

                changeList.WriteLine("</ChangeList>");

                changeList.Close();

                changeList = null;
            }
        }
    }
}
