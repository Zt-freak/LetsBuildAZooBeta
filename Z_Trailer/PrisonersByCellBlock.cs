// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Trailer.PrisonersByCellBlock
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.IntakeStuff;
using TinyZoo.PlayerDir.Layout;

namespace TinyZoo.Z_Trailer
{
  internal class PrisonersByCellBlock
  {
    public List<PrisonerInfo> prisoners;
    public int CellUID;

    public PrisonersByCellBlock()
    {
    }

    public PrisonersByCellBlock(List<PrisonerInfo> _prisoners, int _CellUID)
    {
      this.CellUID = _CellUID;
      this.prisoners = _prisoners;
    }

    public WaveInfo GetAsWave()
    {
      IntakeInfo prisoners = new IntakeInfo();
      for (int index = this.prisoners.Count - 1; index > -1; --index)
        prisoners.People.Add(this.prisoners[index].intakeperson);
      return new WaveInfo(prisoners);
    }
  }
}
