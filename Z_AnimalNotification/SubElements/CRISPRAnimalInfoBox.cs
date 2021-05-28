// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalNotification.SubElements.CRISPRAnimalInfoBox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TinyZoo.Z_Animal_Data;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_AnimalNotification.SubElements
{
  internal class CRISPRAnimalInfoBox
  {
    public Vector2 location;
    private AnimalInFrame animalInFrame;
    private ZGenericText species;
    private Vector2 size;

    public CRISPRAnimalInfoBox(float BaseScale, AnimalRenderDescriptor animal)
    {
      Vector2 defaultBuffer = new UIScaleHelper(BaseScale).DefaultBuffer;
      this.animalInFrame = new AnimalInFrame(animal.bodyAnimalType, animal.headAnimalType, animal.variant, 50f * BaseScale, 6f * BaseScale, BaseScale, animal.headVariant);
      this.animalInFrame.Location += this.animalInFrame.GetSize() * 0.5f;
      this.size = this.animalInFrame.GetSize();
      Vector2 zero = Vector2.Zero;
      zero.X = this.size.X + defaultBuffer.X;
      this.species = new ZGenericText(HybridNames.GetAnimalCombinedName(animal.bodyAnimalType, animal.headAnimalType), BaseScale, false, _UseOnePointFiveFont: true);
      this.species.vLocation.X = zero.X;
      zero.Y += this.species.GetSize().Y;
      zero.X += this.species.GetSize().X;
      this.size.X += zero.X;
      this.size.Y = Math.Max(this.size.Y, zero.Y);
    }

    public Vector2 GetSize() => this.size;

    public void DrawCRISPRAnimalInfoBox(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.animalInFrame.DrawAnimalInFrame(offset, spriteBatch);
      this.species.DrawZGenericText(offset, spriteBatch);
    }
  }
}
