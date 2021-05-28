// Decompiled with JetBrains decompiler
// Type: TinyZoo.Intro.StarRenderer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace TinyZoo.Intro
{
  internal class StarRenderer
  {
    private List<Star> stars;

    public StarRenderer()
    {
      Random rnd = new Random(9900);
      this.stars = new List<Star>();
      for (int index = 0; index < 100; ++index)
        this.stars.Add(new Star(rnd));
    }

    public void UpdateStarRenderer(float DeltaTme)
    {
      for (int index = 0; index < this.stars.Count; ++index)
        this.stars[index].UpdateStar();
    }

    public void DrawStarRenderer(Vector2 ExtraOffset)
    {
      for (int index = 0; index < this.stars.Count; ++index)
        this.stars[index].DrawStar(ExtraOffset);
    }
  }
}
