// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Player.AnimalCollection
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.Z_Player.AColection;

namespace TinyZoo.Z_Player
{
  internal class AnimalCollection
  {
    private List<AnimalSet> animals;

    public AnimalCollection()
    {
      this.animals = new List<AnimalSet>();
      for (int index = 0; index < 56; ++index)
        this.animals.Add(new AnimalSet((AnimalType) index));
    }

    public bool HasThisVariant(AnimalType animal, int Variant, VariantSex variantSex) => this.animals[(int) animal].HasThisVariant(Variant, variantSex);
  }
}
