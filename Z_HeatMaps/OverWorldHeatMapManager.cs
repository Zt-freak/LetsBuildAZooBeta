// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HeatMaps.OverWorldHeatMapManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_HeatMaps
{
  internal class OverWorldHeatMapManager
  {
    internal static HeatMapType lastSelectedHeatMap = HeatMapType.Water;

    public OverWorldHeatMapManager()
    {
      OverWorldHeatMapManager.lastSelectedHeatMap = HeatMapType.Water;
      Z_GameFlags.SetHeatMapType(OverWorldHeatMapManager.lastSelectedHeatMap);
    }

    public bool UpdateOverWorldHeatMapManager(Player player) => Z_GameFlags.DRAW_heatmaptype == HeatMapType.None;
  }
}
