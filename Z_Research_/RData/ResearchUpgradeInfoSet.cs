// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Research_.RData.ResearchUpgradeInfoSet
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;

namespace TinyZoo.Z_Research_.RData
{
  internal class ResearchUpgradeInfoSet
  {
    public List<ResearchUpgradeInfo> researchinfo;
    public ResearchUpgradeType upgradetype;

    public ResearchUpgradeInfoSet(int TotalInSet, ResearchUpgradeType _upgradetype = ResearchUpgradeType.Count)
    {
      this.upgradetype = _upgradetype;
      this.researchinfo = new List<ResearchUpgradeInfo>();
      this.researchinfo.Add(new ResearchUpgradeInfo(TotalInSet));
    }

    public void AddNew(int TotalInSet) => this.researchinfo.Add(new ResearchUpgradeInfo(TotalInSet));
  }
}
