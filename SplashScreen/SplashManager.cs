// Decompiled with JetBrains decompiler
// Type: TinyZoo.SplashScreen.SplashManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework.Content;
using SEngine;
using SEngine.FileInOut;
using SEngine.Input;
using Spring.Comms;
using SpringIAP;
using SpringSocial;
using System;
using TinyZoo.Audio;
using TinyZoo.Utils;
using TinyZoo.Z_Breeding;

namespace TinyZoo.SplashScreen
{
  internal class SplashManager
  {
    private SplashLogo splashlogo;
    private bool Exiting;
    private bool LoadedAssets;
    private float Timer;
    private int RenderCounter;
    private int LoadIndex;

    public SplashManager()
    {
      this.LoadIndex = 0;
      TinyZoo.Game1.ClsCLR.SetAllColours(1f, 1f, 1f);
      TinyZoo.Game1.ClsCLR.SetAllColours(0.0f, 0.0f, 0.0f);
      this.splashlogo = new SplashLogo();
      TinyZoo.Game1.gamestate = GAMESTATE.SplashScreen;
      this.Exiting = false;
      this.LoadedAssets = false;
    }

    public void UpdateSplashManager(
      Player[] players,
      ContentManager contentmanager,
      float DeltaTime)
    {
      if (TinyZoo.Game1.screenfade.FadeActive)
        return;
      this.splashlogo.UpdateSplahs(DeltaTime);
      this.Timer += DeltaTime;
      if (!this.LoadedAssets && this.RenderCounter > 3)
      {
        if (this.LoadIndex == 0)
        {
          Z_SaveUtils.CheckSaveFiles();
          if (!CloudSaveUtil.JustLoadedFromCloud)
            TinyZoo.Game1.InitializeDuringSplash(players);
          bool flag = false;
          if ((Reader.DoesFileExist(Player.FileNameForSave()) || Z_DebugFlags.ForceLoadString.Length > 0) && TinyZoo.DebugFlags.LoadGame)
          {
            flag = players[0].LoadThisPlayer(_DelayUntilNextFrame: true);
            SoundEffectsManager.PlaySpecificSound(SoundEffectType.Menu_Splash);
            Player.HasCompletedFileLoad_orMadeNewSave = true;
          }
          if (!flag && !ThreadedSaveStatus.GetIsThreadedSave())
          {
            players[0].socialmanager.GetUser().AddSocialType(MainVariables.ThisGame, "", Guid.NewGuid().ToString(), "");
            players[0].OldSaveThisPlayer();
          }
          AnnalyticsEvents.StartedSession(players[0]);
          ++this.LoadIndex;
          if (Z_DebugFlags.AutoCompleteAllHeroQuests)
            players[0].heroquestprogress.AutoCompleteAllHeroQuests();
        }
        AssetContainer.LoadAssetsDuringSplash(contentmanager, SpringIAPManager.Instance, players[0], ref this.LoadIndex, ref this.LoadedAssets);
        if (this.LoadedAssets)
        {
          SpringIAPManager.Instance.RetryAllUnconsumedPurchases(players[0].iapuser);
          SocialType typeForThisPlatform = SocialManagerMain.GetBestSocialTypeForThisPlatform();
          if (typeForThisPlatform != SocialType.None && !players[0].socialmanager.GetIsSignedIn(typeForThisPlatform))
            players[0].socialmanager.SignInTo(typeForThisPlatform, true);
          BreedData.SetUpBreedData();
        }
      }
      ControllerType controllerType = ControllerInfo.GetControllerType(0);
      if (controllerType != ControllerType.Count)
        GameFlags.SelectedControllerType = controllerType;
      if (!this.LoadedAssets)
        return;
      CloudSaveUtil.JustLoadedFromCloud = false;
      if ((double) players[0].player.touchinput.MultiTouchTapArray[0].X < 0.0 && (double) this.Timer <= 3.0 || this.Exiting)
        return;
      this.Exiting = true;
      TinyZoo.Game1.screenfade.BeginFade(true);
      if (players[0].Stats.HasPickedCharacter)
        TinyZoo.Game1.SetNextGameState(GAMESTATE.TitleScreenSetUp);
      else
        TinyZoo.Game1.SetNextGameState(GAMESTATE.TitleScreenSetUp);
    }

    public void DrawSplashManager()
    {
      this.splashlogo.DrawSplashLogo();
      ++this.RenderCounter;
    }
  }
}
