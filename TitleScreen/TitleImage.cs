// Decompiled with JetBrains decompiler
// Type: TinyZoo.TitleScreen.TitleImage
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.TitleScreen
{
  internal class TitleImage : GameObject
  {
    public TitleImage()
    {
      this.DrawRect = new Rectangle(0, 0, 3840, 2160);
      this.scale = 0.2666667f;
      if ((double) this.scale * 2160.0 >= 768.0 * (double) Sengine.ScreenRationReductionMultiplier.Y)
        return;
      this.scale = 0.3555556f;
    }
  }
}
