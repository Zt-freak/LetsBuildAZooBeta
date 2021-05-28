// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.DynamicEnrichment.PerchInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_AnimalsAndPeople.DynamicEnrichment
{
  internal class PerchInfo
  {
    public TILETYPE TileType;
    private List<Vector2> Perchpoints_Rot0;
    private List<Vector2> Perchpoints_Rot1;
    private List<Vector2> Perchpoints_Rot2;
    private List<Vector2> Perchpoints_Rot3;

    public PerchInfo(TILETYPE tileType, Vector2 FirstPoint, int RotationForThisPoint = 0)
    {
      this.TileType = tileType;
      if (RotationForThisPoint != 0)
        throw new Exception("Please use Add point for this! I was too lasy to type a switch case!!!");
      this.Perchpoints_Rot0 = new List<Vector2>();
      this.Perchpoints_Rot0.Add(FirstPoint);
      this.Perchpoints_Rot1 = new List<Vector2>();
      this.Perchpoints_Rot2 = new List<Vector2>();
      this.Perchpoints_Rot3 = new List<Vector2>();
    }

    public void AddPoint(Vector2 ExtraPoint, int RotationClockWise)
    {
      switch (RotationClockWise)
      {
        case 0:
          this.Perchpoints_Rot0.Add(ExtraPoint);
          break;
        case 1:
          this.Perchpoints_Rot1.Add(ExtraPoint);
          break;
        case 2:
          this.Perchpoints_Rot2.Add(ExtraPoint);
          break;
        case 3:
          this.Perchpoints_Rot3.Add(ExtraPoint);
          break;
      }
    }

    public List<Vector2> GetPerchPoints(int RotationClockWise)
    {
      switch (RotationClockWise)
      {
        case 0:
          return this.Perchpoints_Rot0;
        case 1:
          return this.Perchpoints_Rot1;
        case 2:
          return this.Perchpoints_Rot2;
        default:
          return this.Perchpoints_Rot3;
      }
    }
  }
}
