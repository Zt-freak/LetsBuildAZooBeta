// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld._OverWorldEnv.PhotoModeSurround.EdgePiece
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_OverWorld._OverWorldEnv.PhotoModeSurround
{
  internal class EdgePiece : GameObject
  {
    public EdgePiece(bool Flipper = false, bool IsRoadLeft = false, bool IsRoadRight = false)
    {
      if (Flipper)
      {
        this.DrawRect = new Rectangle(515, 1535, 512, 512);
        if (IsRoadLeft)
          this.DrawRect = new Rectangle(515, 1437, 512, 96);
        else if (IsRoadRight)
          this.DrawRect = new Rectangle(515, 1339, 512, 96);
      }
      else
      {
        this.DrawRect = new Rectangle(1, 1535, 512, 512);
        if (IsRoadLeft)
          this.DrawRect = new Rectangle(1, 1437, 512, 96);
        else if (IsRoadRight)
          this.DrawRect = new Rectangle(1, 1339, 512, 96);
      }
      this.SetDrawOriginToPoint(DrawOriginPosition.BottomRight);
    }

    public void UpdateEdgePiece()
    {
    }

    public void DrawEdgePiece() => this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.EnvironmentSheet2);
  }
}
