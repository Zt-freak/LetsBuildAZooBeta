// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.beams.IntersectionPoint
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;

namespace TinyZoo.GamePlay.beams
{
  internal class IntersectionPoint
  {
    public Vector2 ChildLocation;
    public Vector2 IntersectionPointLocation;

    public IntersectionPoint(Vector2 _ChildLocation, Vector2 _IntersectionPoint)
    {
      this.ChildLocation = _ChildLocation;
      this.IntersectionPointLocation = _IntersectionPoint;
    }
  }
}
