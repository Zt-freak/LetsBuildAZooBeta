// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.BoxZones.ClearParticles
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TinyZoo.GamePlay.BoxZones
{
  internal class ClearParticles
  {
    private List<BoxParticle> parties;

    public ClearParticles(Vector2 TopLeft, Vector2 BottomRight)
    {
      double num1 = (double) (BottomRight - TopLeft).X * (double) (BottomRight - TopLeft).Y;
      this.parties = new List<BoxParticle>();
      int num2 = (int) (num1 * 0.025000000372529);
      for (int index = 0; index < num2; ++index)
        this.parties.Add(new BoxParticle(TopLeft, BottomRight));
    }

    public void UpdateClearParticles(float DeltaTime)
    {
      for (int index = 0; index < this.parties.Count; ++index)
        this.parties[index].UpdateBoxParticle(DeltaTime);
    }

    public void DrawClearParticles()
    {
      for (int index = 0; index < this.parties.Count; ++index)
        this.parties[index].DrawBoxParticle();
    }
  }
}
