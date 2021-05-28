// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld._OverWorldEnv.Customers.EmployeeBuildingList
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_OverWorld._OverWorldEnv.Customers
{
  internal class EmployeeBuildingList
  {
    public List<TILETYPE> buildingsthispersoncanwork;

    public EmployeeBuildingList(TILETYPE building)
    {
      this.buildingsthispersoncanwork = new List<TILETYPE>();
      this.buildingsthispersoncanwork.Add(building);
    }
  }
}
