// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.Generic.Summary.InfoRow.SummaryIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_BuildingInfo.Generic.Summary.InfoRow
{
  internal class SummaryIcon : GameObject
  {
    public SummaryIcon(SummaryInfoType infoType, float BaseScale, TILETYPE tileType = TILETYPE.Count)
    {
      this.scale = BaseScale;
      switch (infoType)
      {
        case SummaryInfoType.ValueEarned:
          this.DrawRect = new Rectangle(633, 474, 22, 17);
          break;
        case SummaryInfoType.ProductsProduced:
          if (tileType == TILETYPE.BaconFactory)
          {
            this.DrawRect = new Rectangle(951, 572, 18, 16);
            break;
          }
          this.scale = BaseScale * 20f;
          this.DrawRect = TinyZoo.Game1.WhitePixelRect;
          break;
        default:
          this.scale = BaseScale * 20f;
          this.DrawRect = TinyZoo.Game1.WhitePixelRect;
          break;
      }
      this.SetDrawOriginToCentre();
    }

    public Vector2 GetSize() => new Vector2((float) this.DrawRect.Width, (float) this.DrawRect.Height) * this.scale * Sengine.ScreenRatioUpwardsMultiplier;

    public void DrawSummaryIcon(Vector2 offset, SpriteBatch spriteBatch) => this.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
  }
}
