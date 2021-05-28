// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageShop.AllShopSummary.Row.C08_Staff
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System;
using TinyZoo.Z_ManagePen.Diet.SingleAnimalSummary.MainAnimalFood;

namespace TinyZoo.Z_ManageShop.AllShopSummary.Row
{
  internal class C08_Staff
  {
    private TopTextMini toptextmini;
    private TopTextMini toptextminiTwo;
    public Vector2 Location;

    public C08_Staff(float HeightForText, float MidTextHeight, float BaseScale)
    {
      Console.WriteLine("BaseScaleNotApplied");
      this.toptextmini = new TopTextMini("Staff", BaseScale, HeightForText, false, true);
      this.toptextmini.CenterJustify = true;
      this.toptextminiTwo = new TopTextMini("x1", BaseScale, MidTextHeight);
      this.toptextminiTwo.CenterJustify = true;
    }

    public void DrawColumn(Vector2 Offset)
    {
      Offset += this.Location;
      this.toptextmini.DrawTopTextMini(Offset);
      this.toptextminiTwo.DrawTopTextMini(Offset);
    }
  }
}
