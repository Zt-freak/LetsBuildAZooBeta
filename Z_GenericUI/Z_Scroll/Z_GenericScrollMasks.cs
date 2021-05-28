// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_GenericUI.Z_Scroll.Z_GenericScrollMasks
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.Z_ManageEmployees.EmployeeView.PerformanceTable;

namespace TinyZoo.Z_GenericUI.Z_Scroll
{
  internal class Z_GenericScrollMasks
  {
    public Vector2 location;
    private RowSegmentRectangle topMask;
    private RowSegmentRectangle bottomMask;

    public Z_GenericScrollMasks(
      float BaseScale,
      Vector3 color,
      float widthOfMask,
      float heightOfMask,
      float heightOfSpace)
    {
      this.topMask = new RowSegmentRectangle(widthOfMask, heightOfMask, color, 1f);
      this.topMask.SetDrawOriginToPoint(DrawOriginPosition.CentreBottom);
      this.bottomMask = new RowSegmentRectangle(widthOfMask, heightOfMask, color, 1f);
      this.bottomMask.SetDrawOriginToPoint(DrawOriginPosition.CentreTop);
      this.bottomMask.vLocation.Y = heightOfSpace;
    }

    public Vector2 GetMaskSize() => this.bottomMask.GetSize();

    public Vector2 GetMaskLocation(bool GetBottom = false) => GetBottom ? this.bottomMask.vLocation + this.location : this.topMask.vLocation + this.location;

    public void UpdateZ_GenericScrollMasks()
    {
    }

    public void DrawZ_GenericScrollMasks(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.topMask.DrawRowSegmentRectangle(offset, spriteBatch);
      this.bottomMask.DrawRowSegmentRectangle(offset, spriteBatch);
    }
  }
}
