// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.Maps.MapRenderer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.OverWorld.OverWorldEnv;
using TinyZoo.OverWorld.OverWorldEnv.PeopleAndBeams;
using TinyZoo.Z_WorldMap.Maps.MapLocations;

namespace TinyZoo.Z_WorldMap.Maps
{
  internal class MapRenderer
  {
    private OverWorldCamera overworld;
    private MapBG mapBG;
    private MapLocationManager maplocations;

    public MapRenderer(Player player)
    {
      TileMath.SetOverWorldMapSize_XDefault(64);
      TileMath.SetOverWorldMapSize_YSize(64);
      this.mapBG = new MapBG();
      this.overworld = new OverWorldCamera(player, true);
      this.maplocations = new MapLocationManager(player);
    }

    public CityName UpdateMapRenderer(
      float DeltaTime,
      Player player,
      bool MouseIsOverPopUpPanel,
      out Vector2 worldSpaceLocation,
      bool BlockDrag = false)
    {
      if (!BlockDrag)
        this.overworld.UpdateWorldCamera(DeltaTime, player, false, false, true, (AnimalsInPens) null);
      return this.maplocations.UpdateMapLocationManager(player, DeltaTime, MouseIsOverPopUpPanel, out worldSpaceLocation);
    }

    public void DrawMapRenderer()
    {
      this.mapBG.DrawMapBG();
      this.maplocations.DrawMapLocationManager();
    }
  }
}
