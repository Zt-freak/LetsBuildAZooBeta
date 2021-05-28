// Decompiled with JetBrains decompiler
// Type: TinyZoo.GameVariables
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework.Content;
using SEngine;
using SEngine.FileInOut.SaveLoad.Switch;
using SEngine.Localization;
using Spring.Comms;
using Spring.UI;
using SpringIAP;
using System;
using System.Collections.Generic;
using TinyZoo.Utils;
using TinyZoo.Z_BalanceSystems.LoadValues;

namespace TinyZoo
{
  internal class GameVariables
  {
    internal static bool QuitNextFrame;
    internal static IAPHolder iapholder;

    internal static void InitializeGameVariables(ref Player[] players)
    {
      LoadBValues.loadBValues();
      players = new Player[1];
      players[0] = new Player(0);
      Game1.screenfade = new ScreenFade(Game1.WhitePixelRect);
      Game1.Rnd = new Random();
      Game1.ClsCLR = new CLSColour();
      AchievementSetUp.SetUpAchievements(players[0].socialmanager);
      GameVariables.SetUpForQuickAndBigSaves();
    }

    internal static void SetUpForQuickAndBigSaves()
    {
      SEngine.FlagSettings.IgnoreKeysForSave = true;
      SwitchSaveV2.OverrideDefaultSwitchSaveDataHeapSize(33554432);
    }

    internal static void SetUpSpringUI(ContentManager contentmanager, Language language)
    {
      SpringSocial.DebugFlags.UsingFBfriendslist = false;
      SpringUI_Main.SetUpSpringUI(AssetContainer.springFont, AssetContainer.SocialUI, new List<SocialType>()
      {
        SocialType.TDD1_UID
      }, new List<SpringUI_Category>()
      {
        SpringUI_Category.SocialLogIn,
        SpringUI_Category.CloudSave
      }, new List<SocialType>() { SocialType.Facebook }, MainVariables.ThisGame);
      SpringUI_Main.Instance.SetLanguage(language);
    }

    internal static void SetUpIAPManager(SpringIAPManager springIAPmanager) => GameVariables.iapholder = new IAPHolder(springIAPmanager);
  }
}
