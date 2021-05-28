// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.OverWorldBuildMenu.BuldCost
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.GenericUI.UXPanels;
using TinyZoo.Tile_Data;

namespace TinyZoo.OverWorld.OverWorldBuildMenu
{
  internal class BuldCost : GameObject
  {
    private Coin coin;
    private int Cost;

    public BuldCost(TILETYPE tiletype, int _Cost)
    {
      this.Cost = _Cost;
      this.coin = new Coin();
      this.coin.vLocation.X = -12f;
      this.coin.scale = 1f;
    }

    public void UpdateBuldCost()
    {
    }

    public void DrawBuldCost(Vector2 Offset, SpriteBatch spritebatch, float MasterAlpha)
    {
      if (!DebugFlags.IsPCVersion)
        return;
      this.vLocation.X = -6f;
      this.vLocation.Y = -4f;
      this.SetAllColours(new Vector3(0.9f, 0.7f, 0.0f));
      this.coin.fAlpha = MasterAlpha;
      this.coin.DrawCoin(spritebatch, Offset);
      TextFunctions.DrawTextWithDropShadow(string.Concat((object) this.Cost), this.scale, Offset + this.vLocation, this.GetColour(), MasterAlpha, AssetContainer.springFont, AssetContainer.pointspritebatch03, false);
    }
  }
}
