// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Breeding.BreedEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_Breeding
{
  internal class BreedEntry
  {
    public int Parent1_girl;
    public int Parent2;
    public int PercentChanceOfThisChild;

    public BreedEntry(int _Parent1, int _Parent2, int _PercentChanceOfThisChild)
    {
      this.Parent1_girl = _Parent1;
      this.Parent2 = _Parent2;
      this.PercentChanceOfThisChild = _PercentChanceOfThisChild;
    }
  }
}
