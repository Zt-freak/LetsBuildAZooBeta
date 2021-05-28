// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.DynamicEnrichment.EnrichmentPerch
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using System;
using System.Collections.Generic;
using TinyZoo.OverWorld.OverWorldEnv.WallsAndFloors;

namespace TinyZoo.Z_AnimalsAndPeople.DynamicEnrichment
{
  internal class EnrichmentPerch : GameObject
  {
    private List<PerchPoint> perchpoints;
    private TileRenderer tilerender;
    private Vector2 TileRendererLocation;
    private PerchInfo perchinfo;

    public EnrichmentPerch(TileRenderer _tilerender)
    {
      this.TileRendererLocation = _tilerender.vLocation;
      this.perchinfo = PerchData.GetPerchData(_tilerender.tiletypeonconstruct);
      this.perchpoints = new List<PerchPoint>();
      List<Vector2> perchPoints = this.perchinfo.GetPerchPoints(_tilerender.RotationOnConstruct);
      for (int index = 0; index < perchPoints.Count; ++index)
        this.perchpoints.Add(new PerchPoint(this.TileRendererLocation + perchPoints[index]));
    }

    public void ForceDetach(AnimalRenderMan animalrenderer)
    {
      for (int index = this.perchpoints.Count - 1; index > -1; --index)
      {
        if (this.perchpoints[index].animalrenderer == animalrenderer)
          this.perchpoints[index].ForceDetach();
      }
    }

    public bool GetCanPerch()
    {
      for (int index = 0; index < this.perchpoints.Count; ++index)
      {
        if (!this.perchpoints[index].HasAnimal())
          return true;
      }
      return false;
    }

    public void ForceDetatch()
    {
      for (int index = 0; index < this.perchpoints.Count; ++index)
      {
        if (this.perchpoints[index].HasAnimal())
          this.perchpoints[index].ForceDetach();
      }
    }

    public void AttachAnimalToPerch(AnimalRenderMan animalrenderer, int UID)
    {
      Console.WriteLine("Attaching");
      this.GetEmptyPerch().AttachAnimalToPerchPoint(animalrenderer);
      animalrenderer.LastInteractionPoint_UID = UID;
      int num = 0;
      for (int index = 0; index < this.perchpoints.Count; ++index)
      {
        if (this.perchpoints[index].animalrenderer == animalrenderer)
          ++num;
      }
    }

    public PerchPoint GetEmptyPerch()
    {
      int maxValue = 0;
      for (int index = 0; index < this.perchpoints.Count; ++index)
      {
        if (!this.perchpoints[index].HasAnimal())
          ++maxValue;
      }
      int num = TinyZoo.Game1.Rnd.Next(0, maxValue);
      for (int index = 0; index < this.perchpoints.Count; ++index)
      {
        if (!this.perchpoints[index].HasAnimal())
        {
          if (num <= 0)
            return this.perchpoints[index];
          --num;
        }
      }
      throw new Exception("NOT FOUND PERCH POINT");
    }

    public void UpdateEnrichmentPerch(float DeltaTime)
    {
      for (int index = 0; index < this.perchpoints.Count; ++index)
        this.perchpoints[index].UpdatePerchPoint(DeltaTime);
    }

    public void DrawEnrichmentPerch(bool IsPreDraw)
    {
      for (int index = 0; index < this.perchpoints.Count; ++index)
        this.perchpoints[index].DrawPerchPoint(IsPreDraw);
      if (!Z_DebugFlags.DrawWhiteStuffOnPerch)
        return;
      int num = 0;
      while (num < this.perchpoints.Count)
        ++num;
      for (int index = 0; index < this.perchpoints.Count; ++index)
        this.perchpoints[index].DebugDrawPerchPoint();
    }
  }
}
