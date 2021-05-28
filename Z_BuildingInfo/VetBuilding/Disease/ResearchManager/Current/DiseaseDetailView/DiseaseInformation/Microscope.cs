// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.VetBuilding.Disease.ResearchManager.Current.DiseaseDetailView.DiseaseInformation.Microscope
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_BuildingInfo.VetBuilding.Disease.ResearchManager.Current.DiseaseDetailView.DiseaseInformation
{
  internal class Microscope : GameObject
  {
    public Microscope(float _BaseScale)
    {
      this.DrawRect = new Rectangle(254, 475, 49, 61);
      this.SetDrawOriginToCentre();
      this.scale = _BaseScale;
    }

    public void DrawMicroscope(Vector2 Offset, SpriteBatch spritebatch) => this.Draw(spritebatch, AssetContainer.SpriteSheet, Offset);
  }
}
