// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Farms_.FarmFields
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BuldMenu.PenBuilder.GatePlacer;
using TinyZoo.Z_BuldMenu.PenBuilder.Pens;

namespace TinyZoo.PlayerDir.Farms_
{
  internal class FarmFields
  {
    public List<PrisonZone> farmfields;

    public FarmFields() => this.farmfields = new List<PrisonZone>();

    public void AddNewIrregularCellBlock(
      PerimeterBuilder perimeterBuilder,
      int CELLNUMBER,
      CellBlockType cellblocktype,
      GatePlacementManager gateplacer,
      bool AddToCollisionCheckList = false)
    {
      this.farmfields.Add(new PrisonZone(perimeterBuilder, CELLNUMBER, cellblocktype, gateplacer, AddToCollisionCheckList, true));
    }

    public FarmFields(Reader reader, int VersionNumberForLoad)
    {
      int _out = 0;
      int num = (int) reader.ReadInt("f", ref _out);
      this.farmfields = new List<PrisonZone>();
      for (int index = 0; index < _out; ++index)
        this.farmfields.Add(new PrisonZone(reader, VersionNumberForLoad, true));
    }

    public void SaveFarmFields(Writer writer)
    {
      writer.WriteInt("f", this.farmfields.Count);
      for (int index = 0; index < this.farmfields.Count; ++index)
        this.farmfields[index].SavePrisonZone(writer);
    }
  }
}
