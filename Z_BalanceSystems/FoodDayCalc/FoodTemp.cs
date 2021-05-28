// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.FoodDayCalc.FoodTemp
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_StoreRoom;

namespace TinyZoo.Z_BalanceSystems.FoodDayCalc
{
  internal class FoodTemp
  {
    public AnimalFoodType EatsThis;
    public float TotalUnitsPerDay;

    public FoodTemp(AnimalFoodType _EatsThis, float _TotalUnitsPerDay)
    {
      this.EatsThis = _EatsThis;
      this.TotalUnitsPerDay = _TotalUnitsPerDay;
    }
  }
}
