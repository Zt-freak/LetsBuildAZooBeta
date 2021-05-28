// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.PopUps.ReturnToWild
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GenericUI;

namespace TinyZoo.OverWorld.PopUps
{
  internal class ReturnToWild
  {
    private GameObjectNineSlice box;
    private TextButton Sell;
    private SimpleTextHandler text;
    public Vector2 Location;

    public ReturnToWild()
    {
      float smallTextScale = GameFlags.GetSmallTextScale();
      this.box = new GameObjectNineSlice(new Rectangle(873, 372, 21, 21), 7);
      this.Sell = new TextButton("Release", 50f);
      this.Sell.SetButtonColour(BTNColour.BlackMarketBright);
      this.Location = new Vector2(512f, 250f);
      this.text = new SimpleTextHandler("Release this animal back into the wild.~~This increases your trust rating", false, 0.4f, smallTextScale, false, false);
      this.text.paragraph.linemaker.SetAllColours(ColourData.BlackMarketPaleBlue);
      this.text.Location = new Vector2(-200f, -50f);
      this.Sell.vLocation = new Vector2(150f, 50f);
    }

    public bool UpdatSellOnBlackMarket(float DeltaTime, Player player, Vector2 Offset)
    {
      Offset += this.Location;
      this.text.UpdateSimpleTextHandler(DeltaTime);
      return this.Sell.UpdateTextButton(player, Offset, DeltaTime);
    }

    public void DrawSellOnBlackMarket(Vector2 Offset)
    {
      Offset += this.Location;
      this.box.DrawGameObjectNineSlice(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset, new Vector2(512f, 200f));
      this.text.DrawSimpleTextHandler(Offset, 1f, AssetContainer.pointspritebatchTop05);
      this.Sell.DrawTextButton(Offset, 1f, AssetContainer.pointspritebatchTop05);
    }
  }
}
