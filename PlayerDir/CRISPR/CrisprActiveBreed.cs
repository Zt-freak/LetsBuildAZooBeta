// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.CRISPR.CrisprActiveBreed
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.Z_BalanceSystems.Animals.CRISPR;
using TinyZoo.Z_Collection.Shared.Grid;

namespace TinyZoo.PlayerDir.CRISPR
{
  internal class CrisprActiveBreed
  {
    public AnimalType genomeOne;
    public AnimalType genomeTwo;
    public float DaysLeft;
    public bool IsBorn_CanCollect;
    public float DayStarted;
    public bool isBoy;
    public AnimalType resultBody;
    public AnimalType resultHead;
    public int resultBodyVariant;
    public int resultHeadVariant;
    public int percentChanceOfSuccess;
    public int UID;

    public CrisprActiveBreed(AnimalType _animalOne, AnimalType _animalTwo, int _UID)
    {
      this.genomeOne = _animalOne;
      this.genomeTwo = _animalTwo;
      this.DaysLeft = CRISPRCalculator.GetDaysForThisCRISPRBreed(this.genomeOne, this.genomeTwo);
      this.isBoy = TinyZoo.Game1.Rnd.Next(0, 2) == 0;
      if (TinyZoo.Game1.Rnd.Next(0, 2) == 0)
      {
        this.resultBody = this.genomeOne;
        this.resultHead = this.genomeTwo;
      }
      else
      {
        this.resultBody = this.genomeTwo;
        this.resultHead = this.genomeOne;
      }
      this.resultBodyVariant = TinyZoo.Game1.Rnd.Next(0, 10);
      this.resultHeadVariant = TinyZoo.Game1.Rnd.Next(0, 10);
      this.UID = _UID;
    }

    public void StartNewDay(Player player)
    {
      --this.DaysLeft;
      this.DaysLeft = MathHelper.Clamp(this.DaysLeft, 0.0f, this.DaysLeft);
      if ((double) this.DaysLeft > 0.0)
        return;
      LiveStats.AddEventToTheDay(new ZooMoment(ZOOMOMENT.CRISPR_Birth, _UID: this.UID));
    }

    public AnimalRenderDescriptor DoBirth(
      Player player,
      ref bool WasNewVariant)
    {
      WasNewVariant = player.unlocks.TryUnlockNewHybrid(this.resultBody, this.resultHead, this.resultBodyVariant, this.resultHeadVariant);
      this.IsBorn_CanCollect = true;
      int num = WasNewVariant ? 1 : 0;
      return new AnimalRenderDescriptor(this.resultBody, this.resultBodyVariant, this.resultHead, this.resultHeadVariant);
    }

    public float GetFloatPercentProgress()
    {
      float forThisCrisprBreed = CRISPRCalculator.GetDaysForThisCRISPRBreed(this.genomeOne, this.genomeTwo);
      return (forThisCrisprBreed - this.DaysLeft) / forThisCrisprBreed;
    }

    public CrisprActiveBreed(Reader reader)
    {
      int _out = 0;
      int num1 = (int) reader.ReadInt("c", ref _out);
      this.genomeOne = (AnimalType) _out;
      int num2 = (int) reader.ReadInt("c", ref _out);
      this.genomeTwo = (AnimalType) _out;
      int num3 = (int) reader.ReadFloat("c", ref this.DaysLeft);
      int num4 = (int) reader.ReadFloat("c", ref this.DayStarted);
      int num5 = (int) reader.ReadBool("c", ref this.isBoy);
      int num6 = (int) reader.ReadInt("c", ref _out);
      this.resultBody = (AnimalType) _out;
      int num7 = (int) reader.ReadInt("c", ref _out);
      this.resultHead = (AnimalType) _out;
      int num8 = (int) reader.ReadInt("c", ref this.resultBodyVariant);
      int num9 = (int) reader.ReadInt("c", ref this.resultHeadVariant);
      int num10 = (int) reader.ReadInt("c", ref this.UID);
    }

    public void SaveCrisprActiveBreed(Writer writer)
    {
      writer.WriteInt("c", (int) this.genomeOne);
      writer.WriteInt("c", (int) this.genomeTwo);
      writer.WriteFloat("c", this.DaysLeft);
      writer.WriteFloat("c", this.DayStarted);
      writer.WriteBool("c", this.isBoy);
      writer.WriteInt("c", (int) this.resultBody);
      writer.WriteInt("c", (int) this.resultHead);
      writer.WriteInt("c", this.resultBodyVariant);
      writer.WriteInt("c", this.resultHeadVariant);
      writer.WriteInt("c", this.UID);
    }
  }
}
