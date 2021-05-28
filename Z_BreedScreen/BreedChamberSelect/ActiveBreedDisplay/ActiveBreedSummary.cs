// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BreedScreen.BreedChamberSelect.ActiveBreedDisplay.ActiveBreedSummary
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using System;

namespace TinyZoo.Z_BreedScreen.BreedChamberSelect.ActiveBreedDisplay
{
  internal class ActiveBreedSummary
  {
    private AnimalSexFrame Left;
    private AnimalSexFrame Right;
    private GameObject Plus;

    public ActiveBreedSummary(Player player, int Index) => throw new Exception("DepricatedBreeds 32");

    public void UpdateActiveBreedSummary()
    {
    }

    public void DrawActiveBreedSummary(Vector2 Offset)
    {
      Vector2 vector2 = new Vector2(0.0f, -140f);
      this.Left.DrawAnimalSexFrame(Offset + new Vector2(-55f, 0.0f) + vector2, AssetContainer.pointspritebatch03);
      this.Plus.Draw(AssetContainer.pointspritebatch03, AssetContainer.SpriteSheet, Offset + vector2);
      this.Right.DrawAnimalSexFrame(Offset + new Vector2(55f, 0.0f) + vector2, AssetContainer.pointspritebatch03);
    }
  }
}
