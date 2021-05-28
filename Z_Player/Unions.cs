// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Player.Unions
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Z_Employees.Emp_Summary;
using TinyZoo.Z_Morality;

namespace TinyZoo.Z_Player
{
  internal class Unions
  {
    private int TotalPeopleFiredWithNoPay;
    private int TotalPeopleFiredWithEverything;
    private int TotalPeopleFired_Neutral_Bad;
    private int TotalPeopleFired_Neutral_Good;
    private int TotalPeopleFired_Neutral_Neutral;

    public Unions()
    {
    }

    public void FiredEmployee(
      SeverenceOption sevoption,
      Player player,
      int SalaryOwed,
      int HappinessOfEmployee)
    {
      switch (sevoption)
      {
        case SeverenceOption.PayNothing:
          ++this.TotalPeopleFiredWithNoPay;
          break;
        case SeverenceOption.PayWagesOnly:
          if (SalaryOwed > player.Stats.GetCashHeld() * 3 && TinyZoo.Game1.Rnd.Next(0, 100) < HappinessOfEmployee)
          {
            ++this.TotalPeopleFired_Neutral_Good;
            break;
          }
          if (SalaryOwed < player.Stats.GetCashHeld() * 15)
          {
            ++this.TotalPeopleFired_Neutral_Bad;
            break;
          }
          ++this.TotalPeopleFired_Neutral_Neutral;
          break;
        case SeverenceOption.PayAll:
          ++this.TotalPeopleFiredWithEverything;
          break;
      }
      MoralityCalculator.CalculateMorality(player);
    }

    public int GetPointBalance() => this.TotalPeopleFiredWithEverything + this.TotalPeopleFired_Neutral_Good - (this.TotalPeopleFiredWithNoPay + this.TotalPeopleFired_Neutral_Bad);

    public Unions(Reader reader)
    {
      int num1 = (int) reader.ReadInt("x", ref this.TotalPeopleFiredWithNoPay);
      int num2 = (int) reader.ReadInt("x", ref this.TotalPeopleFiredWithEverything);
      int num3 = (int) reader.ReadInt("x", ref this.TotalPeopleFired_Neutral_Bad);
      int num4 = (int) reader.ReadInt("x", ref this.TotalPeopleFired_Neutral_Good);
      int num5 = (int) reader.ReadInt("x", ref this.TotalPeopleFired_Neutral_Neutral);
    }

    public void SaveUnions(Writer writer)
    {
      writer.WriteInt("x", this.TotalPeopleFiredWithNoPay);
      writer.WriteInt("x", this.TotalPeopleFiredWithEverything);
      writer.WriteInt("x", this.TotalPeopleFired_Neutral_Bad);
      writer.WriteInt("x", this.TotalPeopleFired_Neutral_Good);
      writer.WriteInt("x", this.TotalPeopleFired_Neutral_Neutral);
    }
  }
}
