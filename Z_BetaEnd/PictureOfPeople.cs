// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BetaEnd.PictureOfPeople
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_BetaEnd
{
  internal class PictureOfPeople : GameObject
  {
    public PictureOfPeople()
    {
      this.DrawRect = new Rectangle(0, 256, 1024, 769);
      this.SetDrawOriginToCentre();
      this.scale = 0.3f;
    }

    public void UpdatePictureOfPeople()
    {
    }

    public void DrawPictureOfPeople() => this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.LogoSheet);
  }
}
