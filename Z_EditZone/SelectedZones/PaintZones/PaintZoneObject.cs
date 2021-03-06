// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_EditZone.SelectedZones.PaintZones.PaintZoneObject
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_EditZone.SelectedZones.PaintZones
{
  internal class PaintZoneObject : GameObject
  {
    public PaintZoneObject(Vector2Int ZoneTopLeft, int ZoneSize)
    {
      this.DrawRect = TinyZoo.Game1.WhitePixelRect;
      this.scale = (float) ZoneSize * TileMath.TileSize;
      this.vLocation = TileMath.GetTileToWorldSpace(ZoneTopLeft);
      this.SetAlpha(0.3f);
    }

    public bool CheckCOllision(Vector2 LocationInWorldSpace) => false;

    public void DrawPaintZoneObject() => this.WorldOffsetDraw(AssetContainer.pointspritebatch03, AssetContainer.SpriteSheet);
  }
}
