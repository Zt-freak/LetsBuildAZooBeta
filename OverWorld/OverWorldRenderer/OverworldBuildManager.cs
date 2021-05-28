﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.OverWorldRenderer.OverworldBuildManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Audio;
using TinyZoo.OverWorld.OverWorldBuildMenu;
using TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem;
using TinyZoo.OverWorld.OverWorldBuildMenu.CategorySelection;
using TinyZoo.OverWorld.OverWorldBuildMenu.ObjectInfo;
using TinyZoo.OverWorld.OverWorldEnv;
using TinyZoo.OverWorld.OverWorldEnv.PeopleAndBeams;
using TinyZoo.OverWorld.OverWorldEnv.WallsAndFloors;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Tile_Data;

namespace TinyZoo.OverWorld.OverWorldRenderer
{
  internal class OverworldBuildManager
  {
    private BuildingIconPanel buildingiconspanel;
    private BuildMatrix buildmatrix;
    private bool SkipFirstSound;
    private ObjectInfoPanel objectinfopanel;
    private BuildSystemManager buildsystmmanager;
    private bool BuildSomething;
    internal static BUILDSTATEFORCONTROLLERHINT currentbuildstate;

    public OverworldBuildManager(Player player)
    {
      OverworldBuildManager.currentbuildstate = BUILDSTATEFORCONTROLLERHINT.NothinngOpened;
      this.SkipFirstSound = true;
      GameFlags.SelectedBuildTILETYPE = TILETYPE.None;
      this.buildingiconspanel = new BuildingIconPanel(player);
      this.buildmatrix = new BuildMatrix(BIconAndCost.PerRow, BIconAndCost.Total, 0);
      if (Z_GameFlags.ForceToNewScreen != ForceToNewScreen.MoveGate && Z_GameFlags.ForceToNewScreen != ForceToNewScreen.MovePen)
        return;
      this.buildingiconspanel = new BuildingIconPanel(player);
      this.objectinfopanel = new ObjectInfoPanel(TileData.GetCellBlockToTileType((!Z_GameFlags.SelectedPrisonZoneisFarm ? player.prisonlayout.GetThisCellBlock(Z_GameFlags.SelectedPrisonZoneUID) : player.farms.GetThisFarmFieldByUID(Z_GameFlags.SelectedPrisonZoneUID)).CellBLOCKTYPE), CATEGORYTYPE.Enclosure, false, player);
      switch (Z_GameFlags.ForceToNewScreen)
      {
        case ForceToNewScreen.MoveGate:
          OverworldBuildManager.currentbuildstate = BUILDSTATEFORCONTROLLERHINT.PlaceGate;
          this.buildingiconspanel.SetToGatePlace();
          break;
        case ForceToNewScreen.MovePen:
          OverworldBuildManager.currentbuildstate = BUILDSTATEFORCONTROLLERHINT.MovePen;
          this.buildingiconspanel.SetToPenMove();
          break;
      }
      Z_GameFlags.ForceToNewScreen = ForceToNewScreen.None;
    }

    public bool CheckMouseOver(Player player) => this.buildingiconspanel != null && this.buildingiconspanel.CheckMouseOver(player);

    public bool UpdateOverworldBuildManager(
      float DeltaTime,
      Player player,
      WallsAndFloorsManager wallsandfloors,
      AnimalsInPens peopleandbeams,
      OverWorldEnvironmentManager overworldenvironment)
    {
      if (this.buildsystmmanager != null)
      {
        bool Built = false;
        if (this.buildsystmmanager.UpdateBuildSystemManager(DeltaTime, player, wallsandfloors, out Built, this.buildingiconspanel.GetSelectedCategory()))
        {
          FeatureFlags.BlockPlayerMoveCameraDuringCellBlockDrag = false;
          FeatureFlags.BlockPlayerMoveCamera = false;
          GameFlags.BlockOverWorldCamera = false;
          player.player.touchinput.ReleaseTapArray[0].X = -1000f;
          player.livestats.SimulationIsPaused = false;
          this.buildsystmmanager = (BuildSystemManager) null;
          this.buildingiconspanel.ReActivate();
          if (this.objectinfopanel != null)
            this.objectinfopanel.Reactivate();
          if (this.BuildSomething)
            return true;
          player.inputmap.ReleasedThisFrame[7] = false;
        }
        else
        {
          if (!Built)
            return false;
          this.BuildSomething = true;
          TileData.GetTileStats(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected));
          int cost = player.livestats.GetCost(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected), player, false);
          if (player.Stats.SpendCash(cost, SpendingCashOnThis.BuyBuilding, player))
          {
            player.prisonlayout.BuildTileFromTileRenderer(this.buildsystmmanager.thingtobuild.tilerenderer, player.livestats.consumptionstatus, player);
            player.shopstatus.BuiltABuilding(this.buildsystmmanager.thingtobuild.tilerenderer.TileLocation, this.buildsystmmanager.thingtobuild.tilerenderer.tiletypeonconstruct, this.buildsystmmanager.thingtobuild.tilerenderer.RotationOnConstruct, player, false, out int _);
            wallsandfloors.VallidateAgainstLayout(player.prisonlayout.layout);
            GameStateManager.tutorialmanager.BuildAStructure(this.buildsystmmanager.thingtobuild.tilerenderer.Ref_layoutentry.tiletype, player);
            if (this.buildsystmmanager.thingtobuild.tilerenderer.Ref_layoutentry.tiletype == TILETYPE.HoldingCell)
              peopleandbeams.AddHoldingCellOnTheFly(player, this.buildsystmmanager.thingtobuild.tilerenderer.TileLocation);
            player.OldSaveThisPlayer();
            player.inputmap.ClearAllInput(player);
            this.buildsystmmanager = new BuildSystemManager(this.buildsystmmanager.thingtobuild.tilerenderer.Ref_layoutentry.tiletype, player);
            this.buildsystmmanager.thingtobuild.HideFootPrint = true;
            return true;
          }
        }
      }
      if (this.buildmatrix.UpdateBuildMatrix(player, DeltaTime))
      {
        if (this.SkipFirstSound)
          this.SkipFirstSound = false;
        else
          SoundEffectsManager.PlaySpecificSound(SoundEffectType.ClickSingle, Pitch: 0.4f);
        this.buildingiconspanel.SelectThis(this.buildmatrix.Selected);
        GameFlags.SelectedBuildTILETYPE = this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected);
        this.objectinfopanel = new ObjectInfoPanel(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected), this.buildingiconspanel.GetSelectedCategory(), this.buildingiconspanel.IsThisLocked(this.buildmatrix.Selected), player);
      }
      bool TryToExit = false;
      bool ForceExitFromGateMove = false;
      if (this.objectinfopanel != null)
      {
        if ((double) player.player.touchinput.ReleaseTapArray[0].X >= 0.0 && !DebugFlags.IsPCVersion && (this.buildingiconspanel == null || !this.buildingiconspanel.CheckReleaseTapWithBack(player)) && (!this.objectinfopanel.BlocksThis(player.player.touchinput.ReleaseTapArray[0]) && !this.buildingiconspanel.BlocksThis(player.player.touchinput.ReleaseTapArray[0]) && !this.objectinfopanel.GetSelectedThingIsLocked()))
        {
          if (this.buildingiconspanel.GetSelectedCategory() == CATEGORYTYPE.Amenities)
          {
            if (player.Stats.CanBuildThis(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected), player))
            {
              this.buildsystmmanager = new BuildSystemManager(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected), player);
              return false;
            }
          }
          else if (this.buildingiconspanel.GetSelectedCategory() == CATEGORYTYPE.Enclosure && player.Stats.research.CellBlocksReseacrhed.Contains(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected)))
          {
            this.buildsystmmanager = new BuildSystemManager(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected), player);
            return false;
          }
        }
        bool SwitchToGatePlacement;
        if (this.objectinfopanel.UpdateObjectInfoPanel(Vector2.Zero, player, DeltaTime, wallsandfloors, this.buildingiconspanel.GetSelectedCategory(), this.buildingiconspanel.BlockDraw, peopleandbeams, out SwitchToGatePlacement, out TryToExit, out ForceExitFromGateMove, overworldenvironment))
        {
          this.buildsystmmanager = new BuildSystemManager(this.buildingiconspanel.GetTileByIndex(this.buildmatrix.Selected), player);
          return false;
        }
        if (SwitchToGatePlacement)
          this.buildingiconspanel.SetToGatePlace();
      }
      bool StartedExit1;
      bool flag = this.buildingiconspanel.UpdateBuildingIconPanel(DeltaTime, player, ref this.buildmatrix, out StartedExit1, ref this.SkipFirstSound, wallsandfloors, this);
      if (StartedExit1 | TryToExit | ForceExitFromGateMove)
      {
        this.objectinfopanel.Exit();
        if (this.buildingiconspanel != null)
        {
          bool StartedExit2 = false;
          this.buildingiconspanel.TryToExit(ref StartedExit2);
        }
        else
        {
          BuildSystemManager buildsystmmanager = this.buildsystmmanager;
        }
        if (ForceExitFromGateMove)
          flag = true;
      }
      return flag;
    }

    public void ForceEnterBuildMode(
      TILETYPE tiletype,
      Player player,
      WallsAndFloorsManager wallsandfloors,
      CATEGORYTYPE cattype,
      PrisonZone decoratethisprisonzone,
      int ArrayIndexOfBuilding)
    {
      this.buildingiconspanel = new BuildingIconPanel(player);
      this.buildingiconspanel.zbuildingiconpanel.ForceEnterBuildMode(player, wallsandfloors, cattype, ArrayIndexOfBuilding, decoratethisprisonzone, true);
    }

    public void DrawOverworldBuildManager(TileRenderer[,] tilesasarray, Player player)
    {
      if (this.buildsystmmanager != null)
      {
        this.buildsystmmanager.DrawBuildSystemManager(tilesasarray);
      }
      else
      {
        this.buildingiconspanel.DrawBuildingIconPanel(player);
        if (Z_DebugFlags.TempNewBuildingMenu || this.objectinfopanel == null)
          return;
        this.objectinfopanel.DrawObjectInfoPanel(Vector2.Zero, tilesasarray, this.buildingiconspanel.BlockDraw, player);
      }
    }
  }
}
