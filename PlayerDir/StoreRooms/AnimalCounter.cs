// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.StoreRooms.AnimalCounter
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.PlayerDir.StoreRooms
{
  internal class AnimalCounter
  {
    public AnimalType animal;
    public float Total;

    public AnimalCounter(AnimalType _animal, bool IsBaby)
    {
      this.animal = _animal;
      if (IsBaby)
        this.Total = 0.5f;
      else
        this.Total = 1f;
    }

    public void AddPerson(bool IsBaby)
    {
      if (IsBaby)
        this.Total += 0.5f;
      else
        ++this.Total;
    }
  }
}
