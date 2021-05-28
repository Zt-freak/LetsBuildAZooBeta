// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.IncineratorBuildingInfo.IncineratorBuildingManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_BuildingInfo.IncineratorBuildingInfo
{
  internal class IncineratorBuildingManager
  {
    private IncineratorBuildingPanel panel;

    public IncineratorBuildingManager(int BuildingUID, TILETYPE tileTYPE, Player player)
    {
      double baseScaleForUi = (double) Z_GameFlags.GetBaseScaleForUI();
      this.panel = new IncineratorBuildingPanel(BuildingUID, tileTYPE, player);
      this.panel.location = new Vector2(512f, 384f);
    }

    public bool CheckMouseOver(Player player) => this.panel.CheckMouseOver(player, Vector2.Zero);

    public bool UpdateIncineratorBuildingManager(Player player, float DeltaTime) => this.panel.UpdateIncineratorBuildingPanel(player, DeltaTime, Vector2.Zero);

    public void DrawIncineratorBuildingManager() => this.panel.DrawIncineratorBuildingPanel(Vector2.Zero, AssetContainer.pointspritebatchTop05);
  }
}
