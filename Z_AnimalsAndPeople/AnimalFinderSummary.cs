// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.AnimalFinderSummary
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.PlayerDir.Layout;

namespace TinyZoo.Z_AnimalsAndPeople
{
  internal class AnimalFinderSummary
  {
    public Vector2Int Location;
    public PrisonerInfo Ref_prisoninfo;

    public AnimalFinderSummary(Vector2Int _Location, PrisonerInfo _prisoninfo)
    {
      this.Location = new Vector2Int(_Location);
      this.Ref_prisoninfo = _prisoninfo;
    }
  }
}
