// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem.ThingToBuild.CellBlockMaker.DragTile
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;

namespace TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem.ThingToBuild.CellBlockMaker
{
  internal class DragTile : GameObject
  {
    public DragTile()
    {
      this.DrawRect = TinyZoo.Game1.WhitePixelRect;
      this.SetDrawOriginToCentre();
      this.scale = TileMath.TileSize;
      this.SetGreen();
    }

    public void SetGreen() => this.SetAllColours(0.0f, 1f, 0.0f);

    public void SetRed() => this.SetAllColours(1f, 0.0f, 0.0f);

    public void UpdateDragTile()
    {
    }

    public void DrawDragTile() => this.WorldOffsetDraw(AssetContainer.pointspritebatch03, AssetContainer.SpriteSheet);
  }
}
