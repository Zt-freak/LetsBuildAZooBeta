// Decompiled with JetBrains decompiler
// Type: TinyZoo.TitleScreen.TitleScreenManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.Audio;
using TinyZoo.TitleScreen.MainButtons;
using TinyZoo.TitleScreen.PickSaveSlot;
using TinyZoo.Z_Save.CreateNewGame;

namespace TinyZoo.TitleScreen
{
  internal class TitleScreenManager
  {
    private TitleImage BGO;
    private TitleSCreenState titlescreenstete;
    private GameLogo Logo;
    private float BaseScale;
    private MainButtonManager mainbuttonmanager;
    private SaveSlotSelectionManager saveslotselectionmanager;
    private BetaButtons BetaButtons;

    public TitleScreenManager()
    {
      this.BGO = new TitleImage();
      this.Logo = new GameLogo();
      this.Logo.Logo.vLocation = new Vector2(860f, 620f);
      this.titlescreenstete = TitleSCreenState.MainButtons;
      this.BaseScale = Z_GameFlags.GetBaseScaleForUI();
      this.mainbuttonmanager = new MainButtonManager(this.BaseScale);
      MusicManager.playsong(SongTitle.TrailerV2Fade, true);
      if (!Z_DebugFlags.IsBetaVersion)
        return;
      this.BetaButtons = new BetaButtons();
    }

    public void UpdateTitleScreenManager(ref Player[] player, float DeltaTime)
    {
      double fAlpha = (double) TinyZoo.Game1.screenfade.fAlpha;
      if (Z_DebugFlags.IsBetaVersion)
        this.BetaButtons.UpdateBetaButtons(player[0], DeltaTime);
      if ((double) TinyZoo.Game1.screenfade.fAlpha != 0.0)
        return;
      int titlescreenstete = (int) this.titlescreenstete;
      if (this.titlescreenstete == TitleSCreenState.MainButtons)
      {
        MainMenuButton mainMenuButton = this.mainbuttonmanager.UpdateMainButtonManager(player[0], DeltaTime);
        if (mainMenuButton == MainMenuButton.Count)
          return;
        switch (mainMenuButton)
        {
          case MainMenuButton.ContinueGame:
            if (DebugFlags.LoadGame)
            {
              TinyZoo.Game1.SetNextGameState(GAMESTATE.OverWorldSetUp);
              TinyZoo.Game1.screenfade.BeginFade(true);
              break;
            }
            TinyZoo.Game1.SetNextGameState(GAMESTATE.CharacterSelectSetUp);
            TinyZoo.Game1.screenfade.BeginFade(true);
            break;
          case MainMenuButton.StartGame:
            TinyZoo.Game1.SetNextGameState(GAMESTATE.CharacterSelectSetUp);
            TinyZoo.Game1.screenfade.BeginFade(true);
            if (!Z_GameFlags.DidLoadSave)
              break;
            NewGameCreator.CreateNewGame(ref player[0]);
            break;
          case MainMenuButton.Settings:
            Z_GameFlags.SettingWasFromTitleScreen = true;
            TinyZoo.Game1.SetNextGameState(GAMESTATE.SettingsSetUp);
            TinyZoo.Game1.screenfade.BeginFade(true);
            break;
          case MainMenuButton.LoadGame:
            this.saveslotselectionmanager = new SaveSlotSelectionManager(this.BaseScale);
            this.titlescreenstete = TitleSCreenState.LoadGame;
            break;
        }
      }
      else
      {
        if (this.titlescreenstete != TitleSCreenState.LoadGame || !this.saveslotselectionmanager.UpdateSaveSlotSelectionManager(player[0], DeltaTime))
          return;
        this.titlescreenstete = TitleSCreenState.MainButtons;
        this.mainbuttonmanager = new MainButtonManager(this.BaseScale);
      }
    }

    public void DrawTitleScreenManager()
    {
      this.BGO.Draw(AssetContainer.spritebacth, AssetContainer.TitleScreen);
      TextFunctions.DrawTextWithDropShadow("Build: " + TinyZoo.Game1.BUILDNUMBER, this.BaseScale, new Vector2(1020f, 740f), Color.White, 1f, AssetContainer.SpringFontX1AndHalf, AssetContainer.pointspritebatch07Final, false, true);
      if (Z_DebugFlags.IsBetaVersion)
        this.BetaButtons.DrawBetaButtons();
      switch (this.titlescreenstete)
      {
        case TitleSCreenState.MainButtons:
          this.mainbuttonmanager.DrawMainButtonManager();
          break;
        case TitleSCreenState.LoadGame:
          this.saveslotselectionmanager.DrawSaveSlotSelectionManager();
          break;
        case TitleSCreenState.Loading:
          this.Logo.DrawGameLogo(Vector2.Zero);
          break;
      }
    }
  }
}
