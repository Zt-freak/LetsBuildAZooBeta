// Decompiled with JetBrains decompiler
// Type: TinyZoo.ArcadeCredits.Bouncy
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.ArcadeCredits
{
  internal class Bouncy
  {
    private List<Bouncer> bouncies;

    public Bouncy()
    {
      this.bouncies = new List<Bouncer>();
      if (GameFlags.DifficultyIsEasy)
      {
        for (int index = 0; index < 15; ++index)
          this.bouncies.Add(new Bouncer((AnimalType) index));
      }
      else
      {
        for (int index = 0; index < 56; ++index)
          this.bouncies.Add(new Bouncer((AnimalType) index));
      }
    }

    public void uPDATEBouncy(float DeltaTime)
    {
      for (int index = 0; index < this.bouncies.Count; ++index)
        this.bouncies[index].UpdateBouncer(DeltaTime);
    }

    public void DrawBouncy()
    {
      for (int index = 0; index < this.bouncies.Count; ++index)
        this.bouncies[index].DrawBouncer();
    }
  }
}
