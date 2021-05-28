// Decompiled with JetBrains decompiler
// Type: TinyZoo.PathFinding.BoundsChecker
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Z_Data;

namespace TinyZoo.PathFinding
{
  internal class BoundsChecker
  {
    internal static bool IsThisInBounds(Vector2Int ThisLocation)
    {
      Vector2Int TopLeft;
      Vector2Int BottomRight;
      Z_WorldExpansion.GetSizes(0, out TopLeft, out BottomRight, TileMath.GetOverWorldMapSize_XDefault(), TileMath.GetOverWorldMapSize_YSize());
      return ThisLocation.X > TopLeft.X && ThisLocation.X < BottomRight.X && (ThisLocation.Y > TopLeft.Y && ThisLocation.Y < BottomRight.Y);
    }
  }
}
