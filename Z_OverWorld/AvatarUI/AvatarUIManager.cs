﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.AvatarUI.AvatarUIManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.OverWorld.OverworldSelectedThing;
using TinyZoo.PathFinding;

namespace TinyZoo.Z_OverWorld.AvatarUI
{
  internal class AvatarUIManager
  {
    private static SmartCursor smartcursor;
    private bool SkipDraw;

    public AvatarUIManager() => AvatarUIManager.smartcursor = new SmartCursor();

    internal static void SetNewCharacterLocation(
      WalkingPerson Person,
      PathNavigator pathnavigator,
      Player player,
      bool SetNewCharacterLocation)
    {
      AvatarUIManager.smartcursor.SetNewCharacterLocation(Person, pathnavigator, player, SetNewCharacterLocation);
    }

    public void SkipDrawOnNextUpdate() => this.SkipDraw = true;

    public bool CheckNewSelections(Player player, SelectedThingManager selectedthingmanager) => AvatarUIManager.smartcursor.CheckNewSelections(player, selectedthingmanager);

    public void UpdareAvatarUIManager(
      Player player,
      float DeltaTime,
      SelectedThingManager selectedthingmanager,
      ref OverWOrldState OverrideOverworldState)
    {
      if (OverWorldManager.overworldstate == OverWOrldState.Manage || !AvatarUIManager.smartcursor.UpdateSmartCursor(player, DeltaTime, selectedthingmanager, ref OverrideOverworldState))
        return;
      AvatarUIManager.smartcursor.CheckNewSelections(player, selectedthingmanager);
    }

    public void DrawAvatarUIManager()
    {
      if (this.SkipDraw || Game1.gamestate == GAMESTATE.ManageShop)
      {
        this.SkipDraw = false;
      }
      else
      {
        if (Z_GameFlags.SkipDrawSmartCursor())
          return;
        AvatarUIManager.smartcursor.DrawSmartCursor(AssetContainer.pointspritebatch03);
      }
    }
  }
}
