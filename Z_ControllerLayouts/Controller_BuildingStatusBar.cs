// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ControllerLayouts.Controller_BuildingStatusBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine.Buttons;
using TinyZoo.Z_PenInfo.MainBar;

namespace TinyZoo.Z_ControllerLayouts
{
  internal class Controller_BuildingStatusBar
  {
    private ButtonRepeater repeater;

    public Controller_BuildingStatusBar() => this.repeater = new ButtonRepeater();

    public void UpdateController_BuildingStatisBar(
      Player player,
      float DeltaTime,
      MainBarManager mainbarmanager)
    {
      DirectionPressed Direction;
      if (this.repeater.UpdateMenuRepeats(DeltaTime, out Direction, false, false, player.inputmap.HeldButtons[5], player.inputmap.HeldButtons[6]))
        mainbarmanager.SetNew(Direction);
      if (player.inputmap.HeldButtons[9])
      {
        mainbarmanager.SkipToNextPage(false);
      }
      else
      {
        if (!player.inputmap.HeldButtons[10])
          return;
        mainbarmanager.SkipToNextPage(true);
      }
    }
  }
}
