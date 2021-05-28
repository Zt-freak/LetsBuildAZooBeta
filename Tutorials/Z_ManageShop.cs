// Decompiled with JetBrains decompiler
// Type: TinyZoo.Tutorials.Z_ManageShop
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Tutorials
{
  internal class Z_ManageShop
  {
    private SmartCharacterBox charactertextbox;
    private int StateCounter;

    public Z_ManageShop()
    {
      FeatureFlags.BlockAlerts = true;
      FeatureFlags.BlockBuild = true;
      FeatureFlags.BlockManage = true;
      FeatureFlags.BlockIntake = true;
      FeatureFlags.BlockSettings = true;
      FeatureFlags.DemolishEnabled = true;
      this.charactertextbox = new SmartCharacterBox("You can adjust prices and other components in your shops.~Select the shop you just built and click on the options icon.", AnimalType.Administrator, _ScaleMult: Sengine.UltraWideSreenDownardsMultiplier);
    }

    public bool UpdateZ_Z_ManageShop(ref float SimulationTime, ref float DeltaTime, Player player)
    {
      if ((double) Z_GameFlags.DayTimer > 25.0)
        Z_GameFlags.DayTimer = 25f;
      if (TinyZoo.Game1.gamestate == GAMESTATE.ManageShop)
      {
        FeatureFlags.BlockAlerts = false;
        FeatureFlags.BlockBuild = false;
        FeatureFlags.BlockManage = false;
        FeatureFlags.BlockIntake = false;
        FeatureFlags.BlockSettings = false;
        FeatureFlags.DemolishEnabled = true;
        return true;
      }
      if (OverWorldManager.overworldstate != OverWOrldState.Build)
      {
        this.charactertextbox.UpdateSmartCharacterBox(DeltaTime, player, true, DoNotClearInput: true);
        int gamestate = (int) TinyZoo.Game1.gamestate;
      }
      return false;
    }

    public void DrawZ_ManageShop()
    {
      if (this.charactertextbox == null)
        return;
      this.charactertextbox.DrawSmartCharacterBox();
    }
  }
}
