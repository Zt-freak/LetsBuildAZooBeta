// Decompiled with JetBrains decompiler
// Type: TinyZoo.TitleScreen.TitleScreenMainButtons
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GenericUI;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.TitleScreen
{
  internal class TitleScreenMainButtons
  {
    private TextButton[] buttons;
    public Vector2 InternalOffset;
    private UIScaleHelper scalehelper;
    private Vector2 pad;
    private bool FlippedFirstTwoButtons;

    public TitleScreenMainButtons(float BaseScale)
    {
      this.scalehelper = new UIScaleHelper(BaseScale);
      this.pad = this.scalehelper.DefaultBuffer;
      this.buttons = new TextButton[3];
      float num = 3f * this.pad.Y;
      for (int index = 0; index < this.buttons.Length; ++index)
      {
        this.buttons[index] = new TextButton(BaseScale, this.GetMainMenuButtonToString((MainMenuButton) index), 100f);
        this.buttons[index].vLocation = new Vector2(0.0f, (float) (0.0 + (double) index * (double) num));
        this.buttons[index].SetButtonColour(BTNColour.Grey);
        this.buttons[index].vLocation.Y -= 4.5f * this.pad.Y;
      }
      if (!Z_DebugFlags.IsBetaVersion)
      {
        if (Z_SaveUtils.AvalableSaves.Count == 0 && this.buttons.Length > 4)
          this.buttons[4].DarkenAndDisable();
        if (Reader.DoesFileExist(Player.FileNameForSave()))
          return;
        this.buttons[0].DarkenAndDisable();
      }
      else
      {
        if (Z_GameFlags.DidLoadSave && Player.financialrecords.GetDaysPassed() < 14L)
          return;
        this.buttons[0].DarkenAndDisable();
        Vector2 vLocation = this.buttons[0].vLocation;
        this.buttons[0].vLocation = this.buttons[1].vLocation;
        this.buttons[1].vLocation = vLocation;
        this.FlippedFirstTwoButtons = true;
      }
    }

    private string GetMainMenuButtonToString(MainMenuButton btn)
    {
      switch (btn)
      {
        case MainMenuButton.ContinueGame:
          return SEngine.Localization.Localization.GetText(751);
        case MainMenuButton.StartGame:
          return SEngine.Localization.Localization.GetText(750);
        case MainMenuButton.Settings:
          return SEngine.Localization.Localization.GetText(749);
        case MainMenuButton.LoadGame:
          return SEngine.Localization.Localization.GetText(748);
        default:
          return "NONE";
      }
    }

    public MainMenuButton UpdateTitleScreenMainButtons(
      Player player,
      float DeltaTime,
      Vector2 Offset)
    {
      MainMenuButton mainMenuButton = MainMenuButton.Count;
      Offset += this.InternalOffset;
      for (int index = 0; index < this.buttons.Length; ++index)
      {
        if (this.buttons[index].UpdateTextButton(player, Offset, DeltaTime))
          mainMenuButton = (MainMenuButton) index;
      }
      return mainMenuButton;
    }

    public void DrawTitleScreenMainButtons(Vector2 Offset)
    {
      Offset += this.InternalOffset;
      for (int index = 0; index < this.buttons.Length; ++index)
        this.buttons[index].DrawTextButton(Offset, 1f, AssetContainer.pointspritebatch03);
    }
  }
}
