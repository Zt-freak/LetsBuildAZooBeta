// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.Intake.InmateSummary.PrisonerIcons
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System.Collections.Generic;
using TinyZoo.PlayerDir.IntakeStuff;

namespace TinyZoo.OverWorld.Intake.InmateSummary
{
  internal class PrisonerIcons
  {
    private List<prisonerIcon> prisonericons;
    public Vector2 Location;

    public PrisonerIcons(IntakeInfo thisentry)
    {
      this.prisonericons = new List<prisonerIcon>();
      for (int index = 0; index < thisentry.People.Count; ++index)
      {
        this.prisonericons.Add(new prisonerIcon(thisentry.People[index]));
        int num1 = 120;
        if (index < 2)
          num1 = -120;
        float num2 = 0.0f;
        if (index != 0 && index != 2)
          num2 = 100f * Sengine.ScreenRatioUpwardsMultiplier.Y;
        this.prisonericons[index].Location = new Vector2((float) num1, -50f * Sengine.ScreenRatioUpwardsMultiplier.Y + num2);
      }
    }

    public void UpdatePrisonerIcons()
    {
      for (int index = 0; index < this.prisonericons.Count; ++index)
        this.prisonericons[index].UpdateprisonerIcon();
    }

    public void DrawPrisonerIcons(Vector2 Offset, SpriteBatch spritebatch)
    {
      for (int index = 0; index < this.prisonericons.Count; ++index)
        this.prisonericons[index].DrawprisonerIcon(Offset + this.Location, spritebatch);
    }
  }
}
