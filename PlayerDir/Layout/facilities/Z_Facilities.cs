// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Layout.facilities.Z_Facilities
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;

namespace TinyZoo.PlayerDir.Layout.facilities
{
  internal class Z_Facilities
  {
    public List<Facility> WaterPumps;

    public Z_Facilities() => this.WaterPumps = new List<Facility>();

    public void RemoveWaterPump(Vector2Int Location)
    {
      for (int index = this.WaterPumps.Count - 1; index > -1; --index)
      {
        if (this.WaterPumps[index].Location.CompareMatches(Location))
        {
          this.WaterPumps.RemoveAt(index);
          Z_GameFlags.MustRebuildWaterMap = true;
          break;
        }
      }
    }

    public void AddPumpStation(Vector2Int Location)
    {
      Z_GameFlags.MustRebuildWaterMap = true;
      this.WaterPumps.Add(new Facility(Location));
    }

    public Z_Facilities(Reader reader)
    {
      Z_GameFlags.MustRebuildWaterMap = true;
      int _out = 0;
      int num = (int) reader.ReadInt("x", ref _out);
      this.WaterPumps = new List<Facility>();
      for (int index = 0; index < _out; ++index)
        this.WaterPumps.Add(new Facility(reader));
    }

    public void SaveZ_Facilities(Writer writer)
    {
      writer.WriteInt("x", this.WaterPumps.Count);
      for (int index = 0; index < this.WaterPumps.Count; ++index)
        this.WaterPumps[index].SaveWaterPump(writer);
    }
  }
}
