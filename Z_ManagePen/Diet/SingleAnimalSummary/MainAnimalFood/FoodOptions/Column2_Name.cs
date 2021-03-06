// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManagePen.Diet.SingleAnimalSummary.MainAnimalFood.FoodOptions.Column2_Name
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Z_StoreRoom;

namespace TinyZoo.Z_ManagePen.Diet.SingleAnimalSummary.MainAnimalFood.FoodOptions
{
  internal class Column2_Name
  {
    private TopTextMini toptextmini;
    public Vector2 Location;
    private TopTextMini Middletextmini;

    public Column2_Name(
      float HeightForText,
      AnimalFoodType foodtype,
      float HeightForMiddleText,
      float BaseScale)
    {
      this.toptextmini = new TopTextMini("name", BaseScale, HeightForText);
      this.Middletextmini = new TopTextMini(AnimalFoodData.GetAnimalFoodTypeToString(foodtype), BaseScale, HeightForMiddleText);
      this.Middletextmini.SetAsSplit();
    }

    public void DrawColumn2_Name(Vector2 Offset)
    {
      Offset += this.Location;
      this.toptextmini.DrawTopTextMini(Offset);
      this.Middletextmini.DrawTopTextMini(Offset);
    }
  }
}
