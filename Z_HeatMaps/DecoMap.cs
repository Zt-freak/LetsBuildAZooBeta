// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HeatMaps.DecoMap
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.PlayerDir;

namespace TinyZoo.Z_HeatMaps
{
  internal class DecoMap
  {
    private List<DecoDisplay> decostatuses;

    public DecoMap(Player player)
    {
      this.decostatuses = new List<DecoDisplay>();
      for (int XLoc = 0; XLoc < PlayerStats.unblockedSectors.GetLength(0); ++XLoc)
      {
        for (int YLoc = 0; YLoc < PlayerStats.unblockedSectors.GetLength(1); ++YLoc)
        {
          if (PlayerStats.unblockedSectors[XLoc, YLoc])
            this.decostatuses.Add(new DecoDisplay(XLoc, YLoc, 1f));
        }
      }
    }

    public void DecoMapUpdateDecoMap(float DeltaTime)
    {
      foreach (DecoDisplay decostatuse in this.decostatuses)
        decostatuse.UpdateDecoDisplay(DeltaTime);
    }

    public void DrawDecoMap()
    {
      for (int index = 0; index < this.decostatuses.Count; ++index)
        this.decostatuses[index].DrawDecoDisplay();
    }
  }
}
