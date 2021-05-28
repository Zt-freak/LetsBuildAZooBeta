// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.PenNav.NavLocation
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;

namespace TinyZoo.Z_AnimalsAndPeople.PenNav
{
  internal class NavLocation
  {
    public Vector2Int Position;
    public bool IsValidFloor;

    public NavLocation(Vector2Int _Position) => this.Position = _Position;
  }
}
