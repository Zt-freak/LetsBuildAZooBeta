// Decompiled with JetBrains decompiler
// Type: TinyZoo.Settings.Restore.RestoreManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using SpringIAP;
using TinyZoo.Audio;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.GenericUI;
using TinyZoo.Tutorials;
using TinyZoo.Utils;

namespace TinyZoo.Settings.Restore
{
  internal class RestoreManager
  {
    private bool failedToStart;
    private BackButton backbutton;
    private SmartCharacterBox charactertextbox;
    private bool validated;
    private bool started;

    public RestoreManager(Player player)
    {
      this.started = false;
      this.failedToStart = false;
      this.backbutton = new BackButton();
      this.charactertextbox = new SmartCharacterBox(SEngine.Localization.Localization.GetText(73), AnimalType.Administrator, _ScaleMult: Sengine.UltraWideSreenDownardsMultiplier);
    }

    public bool UpdateRestoreManager(float DeltaTime, Player player)
    {
      this.charactertextbox.UpdateSmartCharacterBox(DeltaTime, player, true);
      if (!this.started)
      {
        if (this.charactertextbox.FinishedLerping())
        {
          if (!SpringIAPManager.Instance.TryRestorePurchases(player.iapuser))
          {
            this.failedToStart = true;
            this.charactertextbox = new SmartCharacterBox(SEngine.Localization.Localization.GetText(74), AnimalType.Administrator, true, Sengine.UltraWideSreenDownardsMultiplier);
          }
          this.started = true;
        }
      }
      else
      {
        if (this.failedToStart || this.validated)
        {
          int num = this.backbutton.UpdateBackButton(player, DeltaTime) ? 1 : 0;
          if (num == 0)
            return num != 0;
          SoundEffectsManager.PlaySpecificSound(SoundEffectType.BackClick);
          IAPHolder.CheckPurchases(SpringIAPManager.Instance, player);
          return num != 0;
        }
        bool restoreTimeOut;
        if (!SpringIAPManager.Instance.IsStillTryingToRestorePurchases(out restoreTimeOut) && !this.validated)
        {
          this.validated = true;
          this.charactertextbox = !restoreTimeOut ? new SmartCharacterBox(SEngine.Localization.Localization.GetText(76), AnimalType.Administrator, true, Sengine.UltraWideSreenDownardsMultiplier) : new SmartCharacterBox(SEngine.Localization.Localization.GetText(75), AnimalType.Administrator, true, Sengine.UltraWideSreenDownardsMultiplier);
        }
      }
      return false;
    }

    public void DrawRestoreManager()
    {
      if (this.failedToStart || this.validated)
        this.backbutton.DrawBackButton(Vector2.Zero);
      this.charactertextbox.DrawSmartCharacterBox();
    }
  }
}
