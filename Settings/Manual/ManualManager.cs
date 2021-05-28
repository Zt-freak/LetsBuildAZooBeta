// Decompiled with JetBrains decompiler
// Type: TinyZoo.Settings.Manual.ManualManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Audio;
using TinyZoo.GenericUI;

namespace TinyZoo.Settings.Manual
{
  internal class ManualManager
  {
    private TOC toc;
    private MANUALPAGETYPE CurrentPage;
    private ManualPage manualpage;
    private BackButton backbutton;

    public ManualManager()
    {
      this.toc = new TOC();
      this.CurrentPage = MANUALPAGETYPE.Count;
      this.backbutton = new BackButton();
      if (!GameFlags.IsUsingController)
        return;
      this.CurrentPage = MANUALPAGETYPE.TicketPrices;
      this.manualpage = new ManualPage(this.CurrentPage);
    }

    public bool UpdateManualManager(Player player, float DeltaTime)
    {
      MANUALPAGETYPE page = this.toc.UpdateTOC(DeltaTime, player);
      if (page != this.CurrentPage && page != MANUALPAGETYPE.Count)
      {
        SoundEffectsManager.PlaySpecificSound(SoundEffectType.ClickSingle, Pitch: 0.4f);
        this.CurrentPage = page;
        this.manualpage = new ManualPage(page);
        player.player.touchinput.ReleaseTapArray[0].X = -10000f;
      }
      if (this.manualpage != null)
        this.manualpage.UpdateManualPage(DeltaTime, player);
      if (this.backbutton.UpdateBackButton(player, DeltaTime))
      {
        SoundEffectsManager.PlaySpecificSound(SoundEffectType.BackClick);
        if (this.manualpage != null)
          this.manualpage.Exit();
        this.toc.Exit();
      }
      return this.toc.ExitComplete();
    }

    public void DrawManualManager()
    {
      this.toc.DrawTOC(this.CurrentPage);
      if (this.manualpage != null)
        this.manualpage.DrawManualPage();
      this.backbutton.DrawBackButton(Vector2.Zero);
    }
  }
}
