// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Layout.CellBlocks.AnimalHappyness
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;

namespace TinyZoo.PlayerDir.Layout.CellBlocks
{
  internal class AnimalHappyness
  {
    public float Happyness = 0.5f;

    public void AtePartialMeal(float Partial) => this.Happyness += Partial * 0.2f;

    public void AteFullMeal() => this.Happyness += 0.22f;

    public float GetHappiness() => this.Happyness;

    public AnimalHappyness()
    {
    }

    public AnimalHappyness(Reader reader)
    {
      int num = (int) reader.ReadFloat("b", ref this.Happyness);
    }

    public void SaveAnimalHappyness(Writer writer) => writer.WriteFloat("b", this.Happyness);
  }
}
