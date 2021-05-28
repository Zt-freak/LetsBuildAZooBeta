// Decompiled with JetBrains decompiler
// Type: TinyZoo.Tile_Data.SplitBuildingInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;

namespace TinyZoo.Tile_Data
{
  internal class SplitBuildingInfo
  {
    public bool HasClosedDoorRect;
    public Rectangle BuildingLayer_Rect;
    public Vector2 BuildLayer_DrawOrigin;
    public Rectangle BuildingLayer_Rect_CLOSED;
    public Vector2 BuildLayer_DrawOrigin_CLOSED;
    public Rectangle LightsLayerLayer_Rect;
    public Vector2 LightsLayer_DrawOrigin;

    public SplitBuildingInfo(
      Rectangle _Buildrect,
      Vector2 _BuildDrawOrigin,
      Rectangle CloseDoorRect,
      Vector2 ClosedDoorOrigin,
      int RotationClockWise = 0)
    {
      this.HasClosedDoorRect = CloseDoorRect.Width > 0;
      this.BuildingLayer_Rect = _Buildrect;
      this.BuildLayer_DrawOrigin = _BuildDrawOrigin;
      this.BuildingLayer_Rect_CLOSED = CloseDoorRect;
      this.BuildLayer_DrawOrigin_CLOSED = ClosedDoorOrigin;
    }
  }
}
