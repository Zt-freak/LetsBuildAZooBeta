// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Quests.TradeInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine.Objects;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_Quests
{
  internal class TradeInfo
  {
    public AnimalType animal;
    public int VariantIndex;
    public NumberObfiscatorV1 Total;

    public TradeInfo(AnimalType animaltype, int GetThisMany, int Index)
    {
      this.animal = animaltype;
      this.Total = new NumberObfiscatorV1();
      this.Total.ForceSetNewValue(GetThisMany);
      this.VariantIndex = Index;
    }

    public TradeInfo() => this.Total = new NumberObfiscatorV1();
  }
}
