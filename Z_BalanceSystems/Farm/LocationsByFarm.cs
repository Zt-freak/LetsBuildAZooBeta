// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Farm.LocationsByFarm
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;

namespace TinyZoo.Z_BalanceSystems.Farm
{
  internal class LocationsByFarm
  {
    public int FarmUID;
    public List<Vector2Int> Locations;

    public LocationsByFarm(int farm_UID)
    {
      this.Locations = new List<Vector2Int>();
      this.FarmUID = farm_UID;
    }

    public bool CheckLoc(Vector2Int loco)
    {
      if (this.Locations.Count <= 0)
        return false;
      this.Locations = new List<Vector2Int>();
      return true;
    }
  }
}
