// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_StoreRoom.AnimalFoodEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_StoreRoom
{
  internal class AnimalFoodEntry
  {
    public int QualityOfLife;
    public float PercentOfDailyIdeal;
    public AnimalFoodType foodtype;
    public float NutritionValue;
    public float CostTemp;
    public float CostNormalized;

    public AnimalFoodEntry(AnimalFoodType _foodtype, float _PercentOfDailyIdeal)
    {
      this.foodtype = _foodtype;
      this.PercentOfDailyIdeal = _PercentOfDailyIdeal;
    }
  }
}
