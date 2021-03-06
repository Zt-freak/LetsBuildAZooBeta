// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld._OverWorldEnv.WallsAndFloors.Components.WaterTrough
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.OverWorld.OverWorldEnv.WallsAndFloors;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_OverWorld._OverWorldEnv.WallsAndFloors.Components
{
  internal class WaterTrough : RenderComponent
  {
    public WaterTrough(TileRenderer parent)
      : base(parent, RenderComponentType.WaterTrough)
    {
      int troughToEmptyTrough = (int) TileData.GetWaterTroughToEmptyTrough(parent.tiletypeonconstruct);
    }

    public override void StartNewDay(TileRenderer parent, Player player)
    {
    }
  }
}
