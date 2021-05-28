// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.Extras.UsedFoodEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_StoreRoom;

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person.Extras
{
  internal class UsedFoodEntry
  {
    public AnimalFoodType FoodTypeUsed;
    public float TotalUsed;

    public UsedFoodEntry(AnimalFoodType _FoodTypeUsed, float _TotalUsed)
    {
      this.FoodTypeUsed = _FoodTypeUsed;
      this.TotalUsed = _TotalUsed;
    }
  }
}
