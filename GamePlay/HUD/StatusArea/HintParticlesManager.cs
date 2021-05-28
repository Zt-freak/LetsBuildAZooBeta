// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.HUD.StatusArea.HintParticlesManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TinyZoo.GamePlay.HUD.StatusArea
{
  internal class HintParticlesManager
  {
    private static List<HintParticle> boxparticles;

    public HintParticlesManager() => HintParticlesManager.boxparticles = new List<HintParticle>();

    public void AddParticles(Vector2 TopLeft, Vector2 BottomRight)
    {
      int num = (int) ((double) (BottomRight - TopLeft).X * (double) (BottomRight - TopLeft).Y * 0.00999999977648258);
      for (int index = 0; index < HintParticlesManager.boxparticles.Count; ++index)
      {
        if (num > 0 && !HintParticlesManager.boxparticles[index].IsActive())
        {
          --num;
          HintParticlesManager.boxparticles[index].Create(TopLeft, BottomRight);
        }
      }
      if (num <= 0)
        return;
      for (int index = 0; index < num; ++index)
      {
        HintParticle hintParticle = new HintParticle();
        hintParticle.Create(TopLeft, BottomRight);
        HintParticlesManager.boxparticles.Add(hintParticle);
      }
    }

    public void UpdateHintParticlesManager(float DeltaTime)
    {
      for (int index = 0; index < HintParticlesManager.boxparticles.Count; ++index)
        HintParticlesManager.boxparticles[index].UpdateHintParticle(DeltaTime);
    }

    public void DrawHintParticlesManager(Vector2 BarLocatin)
    {
      for (int index = 0; index < HintParticlesManager.boxparticles.Count; ++index)
        HintParticlesManager.boxparticles[index].DrawHintParticle(BarLocatin);
    }
  }
}
