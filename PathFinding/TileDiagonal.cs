// Decompiled with JetBrains decompiler
// Type: TinyZoo.PathFinding.TileDiagonal
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using SEngine.Buttons;
using System.Collections.Generic;

namespace TinyZoo.PathFinding
{
  internal class TileDiagonal
  {
    private float MovementSpeed;

    public TileDiagonal(float _MovementSpeed) => this.MovementSpeed = _MovementSpeed;

    public bool UpdateNavigationTileDiagonal(
      float DeltaTime,
      List<PathNode> CurrentPath,
      ref Vector2Int CurrentTile,
      ref Vector2 TileRelativeLocation,
      ref DirectionPressed directionmovedthisframe,
      ref bool facingLeft,
      bool endAtCenter)
    {
      return true;
    }
  }
}
