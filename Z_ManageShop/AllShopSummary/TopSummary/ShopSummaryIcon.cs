// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.AllShopSummary.TopSummary.ShopSummaryIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_ManageShop.AllShopSummary.TopSummary
{
  internal class ShopSummaryIcon : GameObject
  {
    public ShopSummaryIcon(SummaryEntryType summary)
    {
      switch (summary)
      {
        case SummaryEntryType.FodShops:
          this.DrawRect = new Rectangle(971, 502, 15, 14);
          break;
        case SummaryEntryType.DrinksShops:
          this.DrawRect = new Rectangle(971, 517, 14, 15);
          break;
        case SummaryEntryType.GiftShops:
          this.DrawRect = new Rectangle(971, 533, 14, 15);
          break;
        case SummaryEntryType.YesterdaysUpkeep:
          this.DrawRect = new Rectangle(921, 292, 17, 15);
          break;
        case SummaryEntryType.YesterdaysProfits:
          this.DrawRect = new Rectangle(970, 553, 17, 14);
          break;
      }
      this.SetDrawOriginToCentre();
    }

    public void UpdateShopSummaryIcon()
    {
    }

    public void DrawShopSummaryIcon(Vector2 Offset) => this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset);
  }
}
