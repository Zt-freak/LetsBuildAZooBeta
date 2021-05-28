// Decompiled with JetBrains decompiler
// Type: TinyZoo.Tutorials.ResearchBuildReminder
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.GenericUI;
using TinyZoo.GenericUI.OveWorldUI;
using TinyZoo.OverWorld;

namespace TinyZoo.Tutorials
{
  internal class ResearchBuildReminder
  {
    private SmartCharacterBox charactertextbox;
    private float Timer;
    private BlackOut blacout;

    public ResearchBuildReminder(ref Arrow arrow, ref Vector2 ArrowLocation, Player player)
    {
      FeatureFlags.BlockTimer = true;
      arrow = new Arrow();
      FeatureFlags.BlockCash = false;
      this.blacout = new BlackOut();
      this.blacout.SetAllColours(ColourData.IconYellow);
      this.blacout.SetAlpha(false, 0.4f, 0.0f, 1f);
      ArrowLocation = new Vector2(700f, 40f);
      arrow = new Arrow();
      ArrowLocation = new Vector2(700f, 40f);
      ArrowLocation = new Vector2(1024f - OWCategoryButton.SizeBTN, OverwoldMainButtons.textbuttons[3].Location.Y);
    }

    public bool UpdateResearchBuildReminder(ref float DeltaTime, Player player)
    {
      if ((double) this.Timer < 1.0)
      {
        this.Timer += DeltaTime;
      }
      else
      {
        this.blacout.UpdateColours(DeltaTime);
        if (this.charactertextbox.UpdateSmartCharacterBox(DeltaTime, player))
        {
          player.inputmap.ClearAllInput(player);
          FeatureFlags.BlockTimer = false;
          return true;
        }
      }
      player.inputmap.ClearAllInput(player);
      return false;
    }

    public void DrawResearchBuildReminder() => this.charactertextbox.DrawSmartCharacterBox();
  }
}
