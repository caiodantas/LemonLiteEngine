using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace LemonLiteEngine
{
public class Assets
{
private ContentManager mContent = null;
private GraphicsDevice mGraphicsDevice = null;
public Effect mShader = null;
public Texture2D Naomi = null;
public Texture2D PartnerSlime = null;
public Texture2D StretchingSlimeDown = null;
public Texture2D StretchingSlimeRight = null;
public Texture2D WarClaws = null;
public Texture2D KeyItemBoard = null;
public Texture2D MessageBalloon = null;
public Texture2D BalloonPointer = null;
public SpriteFont Verdana10 = null;
public SpriteFont VerdanaBig = null;
public SpriteFont Kootenay = null;
public Texture2D Arrow = null;
public Texture2D ReplaceWarpLabel = null;
public Texture2D MakeWarpLabel = null;
public Texture2D Button = null;
public Texture2D CopyTilesLabel = null;
public Texture2D CutTilesLabel = null;
public Texture2D PasteTilesLabel = null;
public Texture2D PlayerPositionLabel = null;
public Texture2D CollisionBoxLabel = null;
public Texture2D TriggerLabel = null;
public Texture2D Section = null;
public Texture2D Selector = null;
public Texture2D SmallButton = null;
public Texture2D StartPosition = null;
public Texture2D Tab = null;
public SpriteFont Arial12 = null;
public SpriteFont Arial14 = null;
public SpriteFont Arial16 = null;
public SpriteFont Arial20 = null;
public SpriteFont Arial26 = null;
public Texture2D UG_T1 = null;
public Texture2D UG_T2 = null;
public Texture2D UG_T3 = null;
public Texture2D UG_T4 = null;
public Texture2D W1_T0 = null;
public Texture2D W1_T1 = null;
public Texture2D W1_T2 = null;
public Texture2D W1_T3 = null;
public Texture2D W1_T4 = null;
public Texture2D W1_T5 = null;
public Texture2D W1_T6 = null;
public Texture2D W1_T7 = null;
public Texture2D W1_T8 = null;
public Texture2D W1_T9 = null;
public Texture2D W1_T10 = null;
public Texture2D W1_T11 = null;
public Texture2D W1_T12 = null;
public Texture2D W2_T1 = null;
public Texture2D W2_T2 = null;
public Texture2D OpenChest = null;
public Texture2D Point = null;
public Texture2D ClosedChest = null;
public Texture2D SleepingGuardian = null;
public Texture2D AwakeGuardian = null;
public Texture2D BuildingEntrance = null;
public Texture2D Bush = null;
public Texture2D Pot = null;
public Texture2D Signpost = null;
public Texture2D BlockingWood = null;
public Texture2D BookShelf = null;
public Texture2D HoleWay = null;
public Texture2D HouseBed = null;
public Texture2D HousePlant = null;
public Texture2D HouseSeat = null;
public Texture2D HouseTable = null;
public Texture2D RedMushroom = null;
public Texture2D MushroomHeadbutt = null;
public Assets(ContentManager theContentManager, GraphicsDevice theGraphicsDevice, Effect theShader)
{
mContent = theContentManager;
mGraphicsDevice = theGraphicsDevice;
mShader = theShader;
}
public Texture2D getTexture(string textureName)
{
switch(textureName)
{
case "Naomi":
{
return Naomi;
}
case "PartnerSlime":
{
return PartnerSlime;
}
case "StretchingSlimeDown":
{
return StretchingSlimeDown;
}
case "StretchingSlimeRight":
{
return StretchingSlimeRight;
}
case "WarClaws":
{
return WarClaws;
}
case "KeyItemBoard":
{
return KeyItemBoard;
}
case "MessageBalloon":
{
return MessageBalloon;
}
case "BalloonPointer":
{
return BalloonPointer;
}
case "Arrow":
{
return Arrow;
}
case "ReplaceWarpLabel":
{
return ReplaceWarpLabel;
}
case "MakeWarpLabel":
{
return MakeWarpLabel;
}
case "Button":
{
return Button;
}
case "CopyTilesLabel":
{
return CopyTilesLabel;
}
case "CutTilesLabel":
{
return CutTilesLabel;
}
case "PasteTilesLabel":
{
return PasteTilesLabel;
}
case "PlayerPositionLabel":
{
return PlayerPositionLabel;
}
case "CollisionBoxLabel":
{
return CollisionBoxLabel;
}
case "TriggerLabel":
{
return TriggerLabel;
}
case "Section":
{
return Section;
}
case "Selector":
{
return Selector;
}
case "SmallButton":
{
return SmallButton;
}
case "StartPosition":
{
return StartPosition;
}
case "Tab":
{
return Tab;
}
case "UG_T1":
{
return UG_T1;
}
case "UG_T2":
{
return UG_T2;
}
case "UG_T3":
{
return UG_T3;
}
case "UG_T4":
{
return UG_T4;
}
case "W1_T0":
{
return W1_T0;
}
case "W1_T1":
{
return W1_T1;
}
case "W1_T2":
{
return W1_T2;
}
case "W1_T3":
{
return W1_T3;
}
case "W1_T4":
{
return W1_T4;
}
case "W1_T5":
{
return W1_T5;
}
case "W1_T6":
{
return W1_T6;
}
case "W1_T7":
{
return W1_T7;
}
case "W1_T8":
{
return W1_T8;
}
case "W1_T9":
{
return W1_T9;
}
case "W1_T10":
{
return W1_T10;
}
case "W1_T11":
{
return W1_T11;
}
case "W1_T12":
{
return W1_T12;
}
case "W2_T1":
{
return W2_T1;
}
case "W2_T2":
{
return W2_T2;
}
case "OpenChest":
{
return OpenChest;
}
case "Point":
{
return Point;
}
case "ClosedChest":
{
return ClosedChest;
}
case "SleepingGuardian":
{
return SleepingGuardian;
}
case "AwakeGuardian":
{
return AwakeGuardian;
}
case "BuildingEntrance":
{
return BuildingEntrance;
}
case "Bush":
{
return Bush;
}
case "Pot":
{
return Pot;
}
case "Signpost":
{
return Signpost;
}
case "BlockingWood":
{
return BlockingWood;
}
case "BookShelf":
{
return BookShelf;
}
case "HoleWay":
{
return HoleWay;
}
case "HouseBed":
{
return HouseBed;
}
case "HousePlant":
{
return HousePlant;
}
case "HouseSeat":
{
return HouseSeat;
}
case "HouseTable":
{
return HouseTable;
}
case "RedMushroom":
{
return RedMushroom;
}
case "MushroomHeadbutt":
{
return MushroomHeadbutt;
}
}
return null;
}
public List<Texture2D> getPrefixedTextures(string prefix)
{
List<Texture2D> textureList = new List<Texture2D>();
if(("Naomi").StartsWith(prefix))
{
textureList.Add(Naomi);
}
if(("PartnerSlime").StartsWith(prefix))
{
textureList.Add(PartnerSlime);
}
if(("StretchingSlimeDown").StartsWith(prefix))
{
textureList.Add(StretchingSlimeDown);
}
if(("StretchingSlimeRight").StartsWith(prefix))
{
textureList.Add(StretchingSlimeRight);
}
if(("WarClaws").StartsWith(prefix))
{
textureList.Add(WarClaws);
}
if(("KeyItemBoard").StartsWith(prefix))
{
textureList.Add(KeyItemBoard);
}
if(("MessageBalloon").StartsWith(prefix))
{
textureList.Add(MessageBalloon);
}
if(("BalloonPointer").StartsWith(prefix))
{
textureList.Add(BalloonPointer);
}
if(("Arrow").StartsWith(prefix))
{
textureList.Add(Arrow);
}
if(("ReplaceWarpLabel").StartsWith(prefix))
{
textureList.Add(ReplaceWarpLabel);
}
if(("MakeWarpLabel").StartsWith(prefix))
{
textureList.Add(MakeWarpLabel);
}
if(("Button").StartsWith(prefix))
{
textureList.Add(Button);
}
if(("CopyTilesLabel").StartsWith(prefix))
{
textureList.Add(CopyTilesLabel);
}
if(("CutTilesLabel").StartsWith(prefix))
{
textureList.Add(CutTilesLabel);
}
if(("PasteTilesLabel").StartsWith(prefix))
{
textureList.Add(PasteTilesLabel);
}
if(("PlayerPositionLabel").StartsWith(prefix))
{
textureList.Add(PlayerPositionLabel);
}
if(("CollisionBoxLabel").StartsWith(prefix))
{
textureList.Add(CollisionBoxLabel);
}
if(("TriggerLabel").StartsWith(prefix))
{
textureList.Add(TriggerLabel);
}
if(("Section").StartsWith(prefix))
{
textureList.Add(Section);
}
if(("Selector").StartsWith(prefix))
{
textureList.Add(Selector);
}
if(("SmallButton").StartsWith(prefix))
{
textureList.Add(SmallButton);
}
if(("StartPosition").StartsWith(prefix))
{
textureList.Add(StartPosition);
}
if(("Tab").StartsWith(prefix))
{
textureList.Add(Tab);
}
if(("UG_T1").StartsWith(prefix))
{
textureList.Add(UG_T1);
}
if(("UG_T2").StartsWith(prefix))
{
textureList.Add(UG_T2);
}
if(("UG_T3").StartsWith(prefix))
{
textureList.Add(UG_T3);
}
if(("UG_T4").StartsWith(prefix))
{
textureList.Add(UG_T4);
}
if(("W1_T0").StartsWith(prefix))
{
textureList.Add(W1_T0);
}
if(("W1_T1").StartsWith(prefix))
{
textureList.Add(W1_T1);
}
if(("W1_T2").StartsWith(prefix))
{
textureList.Add(W1_T2);
}
if(("W1_T3").StartsWith(prefix))
{
textureList.Add(W1_T3);
}
if(("W1_T4").StartsWith(prefix))
{
textureList.Add(W1_T4);
}
if(("W1_T5").StartsWith(prefix))
{
textureList.Add(W1_T5);
}
if(("W1_T6").StartsWith(prefix))
{
textureList.Add(W1_T6);
}
if(("W1_T7").StartsWith(prefix))
{
textureList.Add(W1_T7);
}
if(("W1_T8").StartsWith(prefix))
{
textureList.Add(W1_T8);
}
if(("W1_T9").StartsWith(prefix))
{
textureList.Add(W1_T9);
}
if(("W1_T10").StartsWith(prefix))
{
textureList.Add(W1_T10);
}
if(("W1_T11").StartsWith(prefix))
{
textureList.Add(W1_T11);
}
if(("W1_T12").StartsWith(prefix))
{
textureList.Add(W1_T12);
}
if(("W2_T1").StartsWith(prefix))
{
textureList.Add(W2_T1);
}
if(("W2_T2").StartsWith(prefix))
{
textureList.Add(W2_T2);
}
if(("OpenChest").StartsWith(prefix))
{
textureList.Add(OpenChest);
}
if(("Point").StartsWith(prefix))
{
textureList.Add(Point);
}
if(("ClosedChest").StartsWith(prefix))
{
textureList.Add(ClosedChest);
}
if(("SleepingGuardian").StartsWith(prefix))
{
textureList.Add(SleepingGuardian);
}
if(("AwakeGuardian").StartsWith(prefix))
{
textureList.Add(AwakeGuardian);
}
if(("BuildingEntrance").StartsWith(prefix))
{
textureList.Add(BuildingEntrance);
}
if(("Bush").StartsWith(prefix))
{
textureList.Add(Bush);
}
if(("Pot").StartsWith(prefix))
{
textureList.Add(Pot);
}
if(("Signpost").StartsWith(prefix))
{
textureList.Add(Signpost);
}
if(("BlockingWood").StartsWith(prefix))
{
textureList.Add(BlockingWood);
}
if(("BookShelf").StartsWith(prefix))
{
textureList.Add(BookShelf);
}
if(("HoleWay").StartsWith(prefix))
{
textureList.Add(HoleWay);
}
if(("HouseBed").StartsWith(prefix))
{
textureList.Add(HouseBed);
}
if(("HousePlant").StartsWith(prefix))
{
textureList.Add(HousePlant);
}
if(("HouseSeat").StartsWith(prefix))
{
textureList.Add(HouseSeat);
}
if(("HouseTable").StartsWith(prefix))
{
textureList.Add(HouseTable);
}
if(("RedMushroom").StartsWith(prefix))
{
textureList.Add(RedMushroom);
}
if(("MushroomHeadbutt").StartsWith(prefix))
{
textureList.Add(MushroomHeadbutt);
}
return textureList;
}
public string getTextureName(Texture2D pTexture)
{
if(Naomi == pTexture)
{
return "Naomi";
}
else if(PartnerSlime == pTexture)
{
return "PartnerSlime";
}
else if(StretchingSlimeDown == pTexture)
{
return "StretchingSlimeDown";
}
else if(StretchingSlimeRight == pTexture)
{
return "StretchingSlimeRight";
}
else if(WarClaws == pTexture)
{
return "WarClaws";
}
else if(KeyItemBoard == pTexture)
{
return "KeyItemBoard";
}
else if(MessageBalloon == pTexture)
{
return "MessageBalloon";
}
else if(BalloonPointer == pTexture)
{
return "BalloonPointer";
}
if(Arrow == pTexture)
{
return "Arrow";
}
else if(ReplaceWarpLabel == pTexture)
{
return "ReplaceWarpLabel";
}
else if(MakeWarpLabel == pTexture)
{
return "MakeWarpLabel";
}
else if(Button == pTexture)
{
return "Button";
}
else if(CopyTilesLabel == pTexture)
{
return "CopyTilesLabel";
}
else if(CutTilesLabel == pTexture)
{
return "CutTilesLabel";
}
else if(PasteTilesLabel == pTexture)
{
return "PasteTilesLabel";
}
else if(PlayerPositionLabel == pTexture)
{
return "PlayerPositionLabel";
}
else if(CollisionBoxLabel == pTexture)
{
return "CollisionBoxLabel";
}
else if(TriggerLabel == pTexture)
{
return "TriggerLabel";
}
else if(Section == pTexture)
{
return "Section";
}
else if(Selector == pTexture)
{
return "Selector";
}
else if(SmallButton == pTexture)
{
return "SmallButton";
}
else if(StartPosition == pTexture)
{
return "StartPosition";
}
else if(Tab == pTexture)
{
return "Tab";
}
if(UG_T1 == pTexture)
{
return "UG_T1";
}
else if(UG_T2 == pTexture)
{
return "UG_T2";
}
else if(UG_T3 == pTexture)
{
return "UG_T3";
}
else if(UG_T4 == pTexture)
{
return "UG_T4";
}
if(W1_T0 == pTexture)
{
return "W1_T0";
}
else if(W1_T1 == pTexture)
{
return "W1_T1";
}
else if(W1_T2 == pTexture)
{
return "W1_T2";
}
else if(W1_T3 == pTexture)
{
return "W1_T3";
}
else if(W1_T4 == pTexture)
{
return "W1_T4";
}
else if(W1_T5 == pTexture)
{
return "W1_T5";
}
else if(W1_T6 == pTexture)
{
return "W1_T6";
}
else if(W1_T7 == pTexture)
{
return "W1_T7";
}
else if(W1_T8 == pTexture)
{
return "W1_T8";
}
else if(W1_T9 == pTexture)
{
return "W1_T9";
}
else if(W1_T10 == pTexture)
{
return "W1_T10";
}
else if(W1_T11 == pTexture)
{
return "W1_T11";
}
else if(W1_T12 == pTexture)
{
return "W1_T12";
}
if(W2_T1 == pTexture)
{
return "W2_T1";
}
else if(W2_T2 == pTexture)
{
return "W2_T2";
}
if(OpenChest == pTexture)
{
return "OpenChest";
}
else if(Point == pTexture)
{
return "Point";
}
else if(ClosedChest == pTexture)
{
return "ClosedChest";
}
else if(SleepingGuardian == pTexture)
{
return "SleepingGuardian";
}
else if(AwakeGuardian == pTexture)
{
return "AwakeGuardian";
}
else if(BuildingEntrance == pTexture)
{
return "BuildingEntrance";
}
else if(Bush == pTexture)
{
return "Bush";
}
else if(Pot == pTexture)
{
return "Pot";
}
else if(Signpost == pTexture)
{
return "Signpost";
}
else if(BlockingWood == pTexture)
{
return "BlockingWood";
}
else if(BookShelf == pTexture)
{
return "BookShelf";
}
else if(HoleWay == pTexture)
{
return "HoleWay";
}
else if(HouseBed == pTexture)
{
return "HouseBed";
}
else if(HousePlant == pTexture)
{
return "HousePlant";
}
else if(HouseSeat == pTexture)
{
return "HouseSeat";
}
else if(HouseTable == pTexture)
{
return "HouseTable";
}
else if(RedMushroom == pTexture)
{
return "RedMushroom";
}
if(MushroomHeadbutt == pTexture)
{
return "MushroomHeadbutt";
}
return "";
}
public Model getModel(string modelName)
{
switch(modelName)
{
}
return null;
}
public List<Model> getPrefixedModels(string prefix)
{
List<Model> modelList = new List<Model>();
return modelList;
}
public string getModelName(Model pModel)
{
return "";
}
public SpriteFont getFont(string fontName)
{
switch(fontName)
{
case "Verdana10":
{
return Verdana10;
}
case "VerdanaBig":
{
return VerdanaBig;
}
case "Kootenay":
{
return Kootenay;
}
case "Arial12":
{
return Arial12;
}
case "Arial14":
{
return Arial14;
}
case "Arial16":
{
return Arial16;
}
case "Arial20":
{
return Arial20;
}
case "Arial26":
{
return Arial26;
}
}
return null;
}
public void loadPlayerResourcesAssets()
{
Naomi = mContent.Load<Texture2D>("PlayerResources/Naomi");
PartnerSlime = mContent.Load<Texture2D>("PlayerResources/PartnerSlime");
StretchingSlimeDown = mContent.Load<Texture2D>("PlayerResources/StretchingSlimeDown");
StretchingSlimeRight = mContent.Load<Texture2D>("PlayerResources/StretchingSlimeRight");
WarClaws = mContent.Load<Texture2D>("PlayerResources/WarClaws");
KeyItemBoard = mContent.Load<Texture2D>("PlayerResources/KeyItemBoard");
MessageBalloon = mContent.Load<Texture2D>("PlayerResources/MessageBalloon");
BalloonPointer = mContent.Load<Texture2D>("PlayerResources/BalloonPointer");
Verdana10 = mContent.Load<SpriteFont>("PlayerResources/Verdana10");
VerdanaBig = mContent.Load<SpriteFont>("PlayerResources/VerdanaBig");
Kootenay = mContent.Load<SpriteFont>("PlayerResources/Kootenay");
}
public void releasePlayerResourcesAssets()
{
if(Naomi != null)
{
Naomi = null;
}
if(PartnerSlime != null)
{
PartnerSlime = null;
}
if(StretchingSlimeDown != null)
{
StretchingSlimeDown = null;
}
if(StretchingSlimeRight != null)
{
StretchingSlimeRight = null;
}
if(WarClaws != null)
{
WarClaws = null;
}
if(KeyItemBoard != null)
{
KeyItemBoard = null;
}
if(MessageBalloon != null)
{
MessageBalloon = null;
}
if(BalloonPointer != null)
{
BalloonPointer = null;
}
if(Verdana10 != null)
{
Verdana10 = null;
}
if(VerdanaBig != null)
{
VerdanaBig = null;
}
if(Kootenay != null)
{
Kootenay = null;
}
}
public void loadEditorContentAssets()
{
Arrow = mContent.Load<Texture2D>("Images/Arrow");
ReplaceWarpLabel = mContent.Load<Texture2D>("Images/ReplaceWarpLabel");
MakeWarpLabel = mContent.Load<Texture2D>("Images/MakeWarpLabel");
Button = mContent.Load<Texture2D>("Images/Button");
CopyTilesLabel = mContent.Load<Texture2D>("Images/CopyTilesLabel");
CutTilesLabel = mContent.Load<Texture2D>("Images/CutTilesLabel");
PasteTilesLabel = mContent.Load<Texture2D>("Images/PasteTilesLabel");
PlayerPositionLabel = mContent.Load<Texture2D>("Images/PlayerPositionLabel");
CollisionBoxLabel = mContent.Load<Texture2D>("Images/CollisionBoxLabel");
TriggerLabel = mContent.Load<Texture2D>("Images/TriggerLabel");
Section = mContent.Load<Texture2D>("Images/Section");
Selector = mContent.Load<Texture2D>("Images/Selector");
SmallButton = mContent.Load<Texture2D>("Images/SmallButton");
StartPosition = mContent.Load<Texture2D>("Images/StartPosition");
Tab = mContent.Load<Texture2D>("Images/Tab");
}
public void releaseEditorContentAssets()
{
if(Arrow != null)
{
Arrow = null;
}
if(ReplaceWarpLabel != null)
{
ReplaceWarpLabel = null;
}
if(MakeWarpLabel != null)
{
MakeWarpLabel = null;
}
if(Button != null)
{
Button = null;
}
if(CopyTilesLabel != null)
{
CopyTilesLabel = null;
}
if(CutTilesLabel != null)
{
CutTilesLabel = null;
}
if(PasteTilesLabel != null)
{
PasteTilesLabel = null;
}
if(PlayerPositionLabel != null)
{
PlayerPositionLabel = null;
}
if(CollisionBoxLabel != null)
{
CollisionBoxLabel = null;
}
if(TriggerLabel != null)
{
TriggerLabel = null;
}
if(Section != null)
{
Section = null;
}
if(Selector != null)
{
Selector = null;
}
if(SmallButton != null)
{
SmallButton = null;
}
if(StartPosition != null)
{
StartPosition = null;
}
if(Tab != null)
{
Tab = null;
}
}
public void loadEditorFontsAssets()
{
Arial12 = mContent.Load<SpriteFont>("Fonts/Arial12");
Arial14 = mContent.Load<SpriteFont>("Fonts/Arial14");
Arial16 = mContent.Load<SpriteFont>("Fonts/Arial16");
Arial20 = mContent.Load<SpriteFont>("Fonts/Arial20");
Arial26 = mContent.Load<SpriteFont>("Fonts/Arial26");
}
public void releaseEditorFontsAssets()
{
if(Arial12 != null)
{
Arial12 = null;
}
if(Arial14 != null)
{
Arial14 = null;
}
if(Arial16 != null)
{
Arial16 = null;
}
if(Arial20 != null)
{
Arial20 = null;
}
if(Arial26 != null)
{
Arial26 = null;
}
}
public void loadTilesetUGAssets()
{
UG_T1 = mContent.Load<Texture2D>("Tilesets/UG/UG_T1");
UG_T2 = mContent.Load<Texture2D>("Tilesets/UG/UG_T2");
UG_T3 = mContent.Load<Texture2D>("Tilesets/UG/UG_T3");
UG_T4 = mContent.Load<Texture2D>("Tilesets/UG/UG_T4");
}
public void releaseTilesetUGAssets()
{
if(UG_T1 != null)
{
UG_T1 = null;
}
if(UG_T2 != null)
{
UG_T2 = null;
}
if(UG_T3 != null)
{
UG_T3 = null;
}
if(UG_T4 != null)
{
UG_T4 = null;
}
}
public void loadTilesetW1Assets()
{
W1_T0 = mContent.Load<Texture2D>("Tilesets/W1/W1_T0");
W1_T1 = mContent.Load<Texture2D>("Tilesets/W1/W1_T1");
W1_T2 = mContent.Load<Texture2D>("Tilesets/W1/W1_T2");
W1_T3 = mContent.Load<Texture2D>("Tilesets/W1/W1_T3");
W1_T4 = mContent.Load<Texture2D>("Tilesets/W1/W1_T4");
W1_T5 = mContent.Load<Texture2D>("Tilesets/W1/W1_T5");
W1_T6 = mContent.Load<Texture2D>("Tilesets/W1/W1_T6");
W1_T7 = mContent.Load<Texture2D>("Tilesets/W1/W1_T7");
W1_T8 = mContent.Load<Texture2D>("Tilesets/W1/W1_T8");
W1_T9 = mContent.Load<Texture2D>("Tilesets/W1/W1_T9");
W1_T10 = mContent.Load<Texture2D>("Tilesets/W1/W1_T10");
W1_T11 = mContent.Load<Texture2D>("Tilesets/W1/W1_T11");
W1_T12 = mContent.Load<Texture2D>("Tilesets/W1/W1_T12");
}
public void releaseTilesetW1Assets()
{
if(W1_T0 != null)
{
W1_T0 = null;
}
if(W1_T1 != null)
{
W1_T1 = null;
}
if(W1_T2 != null)
{
W1_T2 = null;
}
if(W1_T3 != null)
{
W1_T3 = null;
}
if(W1_T4 != null)
{
W1_T4 = null;
}
if(W1_T5 != null)
{
W1_T5 = null;
}
if(W1_T6 != null)
{
W1_T6 = null;
}
if(W1_T7 != null)
{
W1_T7 = null;
}
if(W1_T8 != null)
{
W1_T8 = null;
}
if(W1_T9 != null)
{
W1_T9 = null;
}
if(W1_T10 != null)
{
W1_T10 = null;
}
if(W1_T11 != null)
{
W1_T11 = null;
}
if(W1_T12 != null)
{
W1_T12 = null;
}
}
public void loadTilesetW2Assets()
{
W2_T1 = mContent.Load<Texture2D>("Tilesets/W2/W2_T1");
W2_T2 = mContent.Load<Texture2D>("Tilesets/W2/W2_T2");
}
public void releaseTilesetW2Assets()
{
if(W2_T1 != null)
{
W2_T1 = null;
}
if(W2_T2 != null)
{
W2_T2 = null;
}
}
public void loadGameObjectsAssets()
{
OpenChest = mContent.Load<Texture2D>("Objects/OpenChest");
Point = mContent.Load<Texture2D>("Objects/Point");
ClosedChest = mContent.Load<Texture2D>("Objects/ClosedChest");
SleepingGuardian = mContent.Load<Texture2D>("Objects/SleepingGuardian");
AwakeGuardian = mContent.Load<Texture2D>("Objects/AwakeGuardian");
BuildingEntrance = mContent.Load<Texture2D>("Objects/BuildingEntrance");
Bush = mContent.Load<Texture2D>("Objects/Bush");
Pot = mContent.Load<Texture2D>("Objects/Pot");
Signpost = mContent.Load<Texture2D>("Objects/Signpost");
BlockingWood = mContent.Load<Texture2D>("Objects/BlockingWood");
BookShelf = mContent.Load<Texture2D>("Objects/BookShelf");
HoleWay = mContent.Load<Texture2D>("Objects/HoleWay");
HouseBed = mContent.Load<Texture2D>("Objects/HouseBed");
HousePlant = mContent.Load<Texture2D>("Objects/HousePlant");
HouseSeat = mContent.Load<Texture2D>("Objects/HouseSeat");
HouseTable = mContent.Load<Texture2D>("Objects/HouseTable");
RedMushroom = mContent.Load<Texture2D>("Objects/RedMushroom");
}
public void releaseGameObjectsAssets()
{
if(OpenChest != null)
{
OpenChest = null;
}
if(Point != null)
{
Point = null;
}
if(ClosedChest != null)
{
ClosedChest = null;
}
if(SleepingGuardian != null)
{
SleepingGuardian = null;
}
if(AwakeGuardian != null)
{
AwakeGuardian = null;
}
if(BuildingEntrance != null)
{
BuildingEntrance = null;
}
if(Bush != null)
{
Bush = null;
}
if(Pot != null)
{
Pot = null;
}
if(Signpost != null)
{
Signpost = null;
}
if(BlockingWood != null)
{
BlockingWood = null;
}
if(BookShelf != null)
{
BookShelf = null;
}
if(HoleWay != null)
{
HoleWay = null;
}
if(HouseBed != null)
{
HouseBed = null;
}
if(HousePlant != null)
{
HousePlant = null;
}
if(HouseSeat != null)
{
HouseSeat = null;
}
if(HouseTable != null)
{
HouseTable = null;
}
if(RedMushroom != null)
{
RedMushroom = null;
}
}
public void loadEnemiesAssets()
{
MushroomHeadbutt = mContent.Load<Texture2D>("Enemies/MushroomHeadbutt");
}
public void releaseEnemiesAssets()
{
if(MushroomHeadbutt != null)
{
MushroomHeadbutt = null;
}
}
public void releasePack(string packName)
{
switch(packName)
{
case "PlayerResources":
{
releasePlayerResourcesAssets();
break;
}
case "EditorContent":
{
releaseEditorContentAssets();
break;
}
case "EditorFonts":
{
releaseEditorFontsAssets();
break;
}
case "TilesetUG":
{
releaseTilesetUGAssets();
break;
}
case "TilesetW1":
{
releaseTilesetW1Assets();
break;
}
case "TilesetW2":
{
releaseTilesetW2Assets();
break;
}
case "GameObjects":
{
releaseGameObjectsAssets();
break;
}
case "Enemies":
{
releaseEnemiesAssets();
break;
}
}
}
public void loadPack(string packName)
{
switch(packName)
{
case "PlayerResources":
{
loadPlayerResourcesAssets();
break;
}
case "EditorContent":
{
loadEditorContentAssets();
break;
}
case "EditorFonts":
{
loadEditorFontsAssets();
break;
}
case "TilesetUG":
{
loadTilesetUGAssets();
break;
}
case "TilesetW1":
{
loadTilesetW1Assets();
break;
}
case "TilesetW2":
{
loadTilesetW2Assets();
break;
}
case "GameObjects":
{
loadGameObjectsAssets();
break;
}
case "Enemies":
{
loadEnemiesAssets();
break;
}
}
}
public void release()
{
releasePlayerResourcesAssets();
releaseEditorContentAssets();
releaseEditorFontsAssets();
releaseTilesetUGAssets();
releaseTilesetW1Assets();
releaseTilesetW2Assets();
releaseGameObjectsAssets();
releaseEnemiesAssets();
}
}
}
