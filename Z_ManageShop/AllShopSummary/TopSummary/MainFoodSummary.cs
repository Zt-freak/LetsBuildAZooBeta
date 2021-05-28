// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.AllShopSummary.TopSummary.MainFoodSummary
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.Z_SummaryPopUps.People.Animal;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageShop.AllShopSummary.TopSummary
{
  internal class MainFoodSummary
  {
    public CustomerFrame customerframe;
    public Vector2 Location;
    private List<ShopSummaryEntry> summaries;

    public MainFoodSummary(Player player, Vector2 MasterScale)
    {
      this.customerframe = new CustomerFrame(new Vector2(MasterScale.X - AnimalPopUpManager.Space, 50f));
      this.Location.Y = 25f;
      this.Location.Y += AnimalPopUpManager.TopAreaBuffer;
      this.summaries = new List<ShopSummaryEntry>();
      for (int index = 0; index < 7; ++index)
      {
        this.summaries.Add(new ShopSummaryEntry((SummaryEntryType) index));
        float num = this.customerframe.VSCale.X / 7f;
        this.summaries[index].Location = new Vector2(this.customerframe.VSCale.X * -0.5f, 0.0f);
        this.summaries[index].Location.X += num * (float) index;
        this.summaries[index].Location.X += num * 0.5f;
        this.summaries[index].Location.Y -= 7f;
      }
    }

    public void UpdateMainFoodSummary()
    {
    }

    public void DrawMainFoodSummary(Vector2 TopCenter)
    {
      TopCenter += this.Location;
      this.customerframe.DrawCustomerFrame(TopCenter, AssetContainer.pointspritebatch03);
      TopCenter += this.customerframe.frame.vLocation;
      for (int index = 0; index < this.summaries.Count; ++index)
        this.summaries[index].DrawShopSummaryEntry(TopCenter);
    }
  }
}
