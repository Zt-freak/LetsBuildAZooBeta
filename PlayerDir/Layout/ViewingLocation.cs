// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Layout.ViewingLocation
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using SEngine.Buttons;

namespace TinyZoo.PlayerDir.Layout
{
  internal class ViewingLocation
  {
    public Vector2Int Location;
    public float Privacy;
    private float Privacy_lowerBetterForViewer;
    public DirectionPressed faceThisWayToLookAtPen;

    public ViewingLocation(
      int XLoc,
      int Yloc,
      float Privacy,
      DirectionPressed _faceThisWayToLookAtPen)
    {
      this.Location = new Vector2Int(XLoc, Yloc);
      this.Privacy_lowerBetterForViewer = Privacy;
      this.faceThisWayToLookAtPen = _faceThisWayToLookAtPen;
    }
  }
}
