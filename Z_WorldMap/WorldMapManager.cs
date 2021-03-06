// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Z_WorldMap.Maps;
using TinyZoo.Z_WorldMap.WorldHUD;
using TinyZoo.Z_WorldMap.WorldMapPopUps;

namespace TinyZoo.Z_WorldMap
{
  internal class WorldMapManager
  {
    private OldWorldMapManager oldworldmapmanager;
    private WorldMapPopUpManager worldmappopups;
    private WorldHUDManager worldmaphud;
    private MapRenderer maprenderer;

    public WorldMapManager(Player player)
    {
      this.worldmappopups = new WorldMapPopUpManager();
      this.worldmaphud = new WorldHUDManager();
      this.maprenderer = new MapRenderer(player);
    }

    public void UpdateWorldMapManager(Player player, float DeltaTime)
    {
      Z_GameFlags.MouseIsOverAPanel = false;
      Z_GameFlags.MouseIsOverAPanel_SoBlockZoom = false;
      bool MouseIsOverPopUpPanel = false;
      this.worldmappopups.UpdateWorldMapPopUpManager(DeltaTime, player, ref MouseIsOverPopUpPanel);
      bool BlockDrag = this.worldmappopups.popupstate != PopUpState.None;
      Vector2 worldSpaceLocation;
      CityName cityname = this.maprenderer.UpdateMapRenderer(DeltaTime, player, MouseIsOverPopUpPanel, out worldSpaceLocation, BlockDrag);
      if (cityname != CityName.Count)
        this.worldmappopups.SetNewSelection(cityname, player, worldSpaceLocation);
      this.worldmaphud.UpdateWorldHUDManager(this.worldmappopups.popupstate != PopUpState.None, player, DeltaTime);
    }

    public void DrawWorldMapManager()
    {
      this.maprenderer.DrawMapRenderer();
      this.worldmaphud.DrawWorldHUDManager();
      this.worldmappopups.DrawWorldMapPopUpManager();
    }
  }
}
