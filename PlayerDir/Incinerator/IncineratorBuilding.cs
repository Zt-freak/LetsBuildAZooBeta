// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Incinerator.IncineratorBuilding
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;
using TinyZoo.Z_Employees.WorkZonePane;

namespace TinyZoo.PlayerDir.Incinerator
{
  internal class IncineratorBuilding
  {
    public WorkZoneInfo workzoneinfo;
    public int UID;
    private float currentBurningProgress;

    public IncineratorBuilding(int _UID)
    {
      this.UID = _UID;
      this.workzoneinfo = new WorkZoneInfo();
      this.workzoneinfo.workzonetype = WorkZoneType.SingleZone;
    }

    public void StartNewDay()
    {
    }

    public void SaveIncineratorBuilding(Writer writer)
    {
      writer.WriteInt("i", this.UID);
      this.workzoneinfo.SaveWorkZoneInfo(writer);
      writer.WriteFloat("i", this.currentBurningProgress);
    }

    public IncineratorBuilding(Reader reader, int VersionForLoad)
    {
      int num1 = (int) reader.ReadInt("i", ref this.UID);
      if (VersionForLoad < 12)
      {
        int _out = 0;
        int num2 = (int) reader.ReadInt("i", ref _out);
        List<IncineratingAnimals> incineratingAnimalsList = new List<IncineratingAnimals>();
        for (int index = 0; index < _out; ++index)
          incineratingAnimalsList.Add(new IncineratingAnimals(reader, VersionForLoad));
      }
      this.workzoneinfo = new WorkZoneInfo(reader, VersionForLoad);
      if (VersionForLoad <= 9)
        return;
      int num3 = (int) reader.ReadFloat("i", ref this.currentBurningProgress);
    }
  }
}
