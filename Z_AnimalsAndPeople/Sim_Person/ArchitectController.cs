// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.ArchitectController
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.PlayerDir;
using TinyZoo.Z_BalanceSystems.LoadValues;

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person
{
  internal class ArchitectController
  {
    private int Progress;
    private int CyclesForPorgress;
    private Employee RefEmployee;

    public ArchitectController(Employee _RefEmployee)
    {
      this.RefEmployee = _RefEmployee;
      this.CyclesForPorgress = 100 - (int) ((double) this.RefEmployee.quickemplyeedescription.Determination * 100.0);
      this.CyclesForPorgress += 100;
      this.CyclesForPorgress /= 2;
    }

    public void UpdateResearchProgress(float Cycles, Player player)
    {
      for (this.Progress += (int) ((double) Cycles * (double) BVal.ReaserachSpeedMult); this.Progress > this.CyclesForPorgress; this.Progress -= this.CyclesForPorgress)
      {
        ++this.RefEmployee.ResearchProgress;
        if (this.RefEmployee.ResearchProgress >= 100)
        {
          if (this.RefEmployee.ResearchPointHistory.Count > 0 && this.RefEmployee.ResearchPointHistory[this.RefEmployee.ResearchPointHistory.Count - 1].X == (int) Player.financialrecords.GetDaysPassed())
            ++this.RefEmployee.ResearchPointHistory[this.RefEmployee.ResearchPointHistory.Count - 1].Y;
          else
            this.RefEmployee.ResearchPointHistory.Add(new Vector2Int((int) Player.financialrecords.GetDaysPassed(), 1));
          this.RefEmployee.ResearchProgress -= 100;
          ++player.unlocks.ResearchPoints;
          LiveStats.EarnedResearch = true;
        }
      }
    }
  }
}
