// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Player.AColection.AnimalSet
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_Player.AColection
{
  internal class AnimalSet
  {
    private bool[] Males;
    private bool[] Females;
    private AnimalType animaltype;

    public AnimalSet(AnimalType _animaltype)
    {
      this.animaltype = _animaltype;
      this.Males = new bool[10];
      this.Females = new bool[10];
    }

    public bool HasThisVariant(int Index, VariantSex _VariantSex)
    {
      switch (_VariantSex)
      {
        case VariantSex.Male:
          return this.Males[Index];
        case VariantSex.Any:
          return this.Males[Index] || this.Females[Index];
        default:
          return this.Females[Index];
      }
    }
  }
}
