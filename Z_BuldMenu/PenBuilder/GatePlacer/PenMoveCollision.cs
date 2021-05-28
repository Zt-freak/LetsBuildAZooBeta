// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuldMenu.PenBuilder.GatePlacer.PenMoveCollision
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using System.Collections.Generic;
using TinyZoo.OverWorld.OverWorldEnv.WallsAndFloors;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BuldMenu.PenBuilder.MovePen;
using TinyZoo.Z_BuldMenu.PenBuilder.Pens;

namespace TinyZoo.Z_BuldMenu.PenBuilder.GatePlacer
{
  internal class PenMoveCollision
  {
    private List<EntranceArrow> BlockedPlaces;
    private List<Vector2Int> OriginalPlaces;
    private List<bool> OriginalFloor;
    private List<Vector2Int> BLOCKS;
    private bool[,] MOVE_Blocks;
    private Vector2Int TopLeftBlock;
    private static Vector2Int newPos;
    private bool Canplace;
    internal static Vector2Int Offset;

    public PenMoveCollision(
      List<TileRenderer> tilerenderers,
      PerimeterBuilder perimeterBuilder,
      PrisonZone prisonzone)
    {
      if (PenMoveCollision.Offset == null)
        PenMoveCollision.Offset = new Vector2Int();
      this.BLOCKS = new List<Vector2Int>();
      PenMoveCollision.newPos = new Vector2Int();
      this.OriginalPlaces = new List<Vector2Int>();
      this.BlockedPlaces = new List<EntranceArrow>();
      this.OriginalFloor = new List<bool>();
      this.MOVE_Blocks = new bool[prisonzone.WidthAndHeight.X + 1, prisonzone.WidthAndHeight.Y + 1];
      this.TopLeftBlock = new Vector2Int(prisonzone.TopLeft);
      for (int index = 0; index < tilerenderers.Count; ++index)
      {
        this.BlockedPlaces.Add(new EntranceArrow(0));
        this.BlockedPlaces[index].bActive = false;
        this.BlockedPlaces[index].SetAsBlocked();
        this.OriginalPlaces.Add(new Vector2Int(tilerenderers[index].TileLocation));
        this.OriginalFloor.Add(false);
        this.MOVE_Blocks[tilerenderers[index].TileLocation.X - this.TopLeftBlock.X, tilerenderers[index].TileLocation.Y - this.TopLeftBlock.Y] = true;
        if (Z_GameFlags.pathfinder.GetIsBlocked(tilerenderers[index].TileLocation.X, tilerenderers[index].TileLocation.Y))
          this.BLOCKS.Add(new Vector2Int(tilerenderers[index].TileLocation));
      }
      for (int index = 0; index < prisonzone.penItems.items.Count; ++index)
      {
        this.BlockedPlaces.Add(new EntranceArrow(0));
        this.BlockedPlaces[this.BlockedPlaces.Count - 1].bActive = false;
        this.BlockedPlaces[this.BlockedPlaces.Count - 1].SetAsBlocked();
        if (!this.MOVE_Blocks[prisonzone.penItems.items[index].Location.X - this.TopLeftBlock.X, prisonzone.penItems.items[index].Location.Y - this.TopLeftBlock.Y])
        {
          this.MOVE_Blocks[prisonzone.penItems.items[index].Location.X - this.TopLeftBlock.X, prisonzone.penItems.items[index].Location.Y - this.TopLeftBlock.Y] = true;
          this.OriginalPlaces.Add(new Vector2Int(prisonzone.penItems.items[index].Location));
        }
        this.OriginalFloor.Add(false);
      }
      for (int index = 0; index < prisonzone.FloorTiles.Count; ++index)
      {
        this.BlockedPlaces.Add(new EntranceArrow(0));
        this.BlockedPlaces[this.BlockedPlaces.Count - 1].bActive = false;
        this.BlockedPlaces[this.BlockedPlaces.Count - 1].SetAsBlocked();
        if (!this.MOVE_Blocks[prisonzone.FloorTiles[index].X - this.TopLeftBlock.X, prisonzone.FloorTiles[index].Y - this.TopLeftBlock.Y])
        {
          this.MOVE_Blocks[prisonzone.FloorTiles[index].X - this.TopLeftBlock.X, prisonzone.FloorTiles[index].Y - this.TopLeftBlock.Y] = true;
          this.OriginalPlaces.Add(new Vector2Int(prisonzone.FloorTiles[index]));
        }
        this.OriginalFloor.Add(true);
        if (Z_GameFlags.pathfinder.GetIsBlocked(prisonzone.FloorTiles[index].X, prisonzone.FloorTiles[index].Y))
        {
          this.BLOCKS.Add(new Vector2Int(prisonzone.FloorTiles[index]));
          this.MOVE_Blocks[prisonzone.FloorTiles[index].X - this.TopLeftBlock.X, prisonzone.FloorTiles[index].Y - this.TopLeftBlock.Y] = true;
        }
      }
    }

    public void ConfirmMove(Player player, WallsAndFloorsManager wallsandfloors, int CELLUID)
    {
      List<BaseTileDesc> baseTileDescList = new List<BaseTileDesc>();
      for (int index = 0; index < this.OriginalPlaces.Count; ++index)
      {
        if (this.OriginalFloor[index])
          baseTileDescList.Add(new BaseTileDesc(player.prisonlayout.layout.FloorTileTypes[this.OriginalPlaces[index].X, this.OriginalPlaces[index].Y]));
        else
          baseTileDescList.Add(new BaseTileDesc(player.prisonlayout.layout.BaseTileTypes[this.OriginalPlaces[index].X, this.OriginalPlaces[index].Y]));
        player.prisonlayout.layout.BaseTileTypes[this.OriginalPlaces[index].X, this.OriginalPlaces[index].Y].tiletype = TILETYPE.None;
        wallsandfloors.VallidateAgainstLayout(player.prisonlayout.layout, JustThisTile: this.OriginalPlaces[index], DoRemakeTileLists: false);
        player.prisonlayout.layout.FloorTileTypes[this.OriginalPlaces[index].X, this.OriginalPlaces[index].Y].tiletype = TILETYPE.EMPTY_DIRT_WALKABLE_TILE;
        wallsandfloors.VallidateAgainstLayout(player.prisonlayout.layout, true, this.OriginalPlaces[index], false);
      }
      for (int index = 0; index < this.OriginalPlaces.Count; ++index)
      {
        if (this.OriginalFloor[index])
        {
          player.prisonlayout.layout.FloorTileTypes[this.OriginalPlaces[index].X + PenMoveCollision.Offset.X, this.OriginalPlaces[index].Y + PenMoveCollision.Offset.Y].CloneFromBaseTileDesc(baseTileDescList[index]);
          wallsandfloors.VallidateAgainstLayout(player.prisonlayout.layout, true, new Vector2Int(this.OriginalPlaces[index].X + PenMoveCollision.Offset.X, this.OriginalPlaces[index].Y + PenMoveCollision.Offset.Y), false);
        }
        else
        {
          player.prisonlayout.layout.BaseTileTypes[this.OriginalPlaces[index].X + PenMoveCollision.Offset.X, this.OriginalPlaces[index].Y + PenMoveCollision.Offset.Y].CloneFromBaseTileDesc(baseTileDescList[index]);
          wallsandfloors.VallidateAgainstLayout(player.prisonlayout.layout, JustThisTile: new Vector2Int(this.OriginalPlaces[index].X + PenMoveCollision.Offset.X, this.OriginalPlaces[index].Y + PenMoveCollision.Offset.Y), DoRemakeTileLists: false);
        }
      }
      PrisonZone prisonZone;
      if (Z_GameFlags.SelectedPrisonZoneisFarm)
      {
        prisonZone = player.farms.GetThisFarmFieldByUID(Z_GameFlags.SelectedPrisonZoneUID);
        prisonZone.cropsatus.MoveCrop(PenMoveCollision.Offset);
      }
      else
        prisonZone = player.prisonlayout.cellblockcontainer.GetThisCellBlock(CELLUID);
      TILETYPE cellBlockTypeToPice = TileData.GetCellBlockTypeToPice(prisonZone.CellBLOCKTYPE, CellBlockPiece.Floor);
      for (int index = 0; index < prisonZone.penItems.items.Count; ++index)
      {
        player.prisonlayout.layout.FloorTileTypes[prisonZone.penItems.items[index].Location.X, prisonZone.penItems.items[index].Location.Y].tiletype = cellBlockTypeToPice;
        wallsandfloors.VallidateAgainstLayout(player.prisonlayout.layout, true, new Vector2Int(prisonZone.penItems.items[index].Location.X, prisonZone.penItems.items[index].Location.Y), false);
      }
      for (int index = 0; index < this.BLOCKS.Count; ++index)
        Z_GameFlags.pathfinder.UnblockTile(this.BLOCKS[index].X, this.BLOCKS[index].Y, true);
      for (int index = 0; index < this.BLOCKS.Count; ++index)
        Z_GameFlags.pathfinder.BlockTile(this.BLOCKS[index].X + PenMoveCollision.Offset.X, this.BLOCKS[index].Y + PenMoveCollision.Offset.Y, true);
      wallsandfloors.RemakeTileList();
    }

    public bool CanPlace() => this.Canplace;

    public void SetNewLocations(Vector2Int _Offset)
    {
      this.Canplace = true;
      PenMoveCollision.Offset.X = _Offset.X;
      PenMoveCollision.Offset.Y = _Offset.Y;
      for (int index = 0; index < this.OriginalPlaces.Count; ++index)
      {
        PenMoveCollision.newPos.X = PenMoveCollision.Offset.X + this.OriginalPlaces[index].X;
        PenMoveCollision.newPos.Y = PenMoveCollision.Offset.Y + this.OriginalPlaces[index].Y;
        bool flag = false;
        this.BlockedPlaces[index].bActive = false;
        if (PenMoveCollision.newPos.X >= this.TopLeftBlock.X && PenMoveCollision.newPos.Y >= this.TopLeftBlock.Y && (PenMoveCollision.newPos.X - this.TopLeftBlock.X < this.MOVE_Blocks.GetLength(0) && PenMoveCollision.newPos.Y - this.TopLeftBlock.Y < this.MOVE_Blocks.GetLength(1)) && this.MOVE_Blocks[PenMoveCollision.newPos.X - this.TopLeftBlock.X, PenMoveCollision.newPos.Y - this.TopLeftBlock.Y])
          flag = true;
        if (!flag && Z_GameFlags.pathfinder.GetIsBlocked(PenMoveCollision.newPos.X, PenMoveCollision.newPos.Y))
        {
          this.BlockedPlaces[index].bActive = true;
          this.Canplace = false;
          this.BlockedPlaces[index].vLocation = TileMath.GetTileToWorldSpace(PenMoveCollision.newPos);
        }
      }
    }

    public void DrawPenMoveCollision()
    {
      for (int index = 0; index < this.BlockedPlaces.Count; ++index)
      {
        if (this.BlockedPlaces[index].bActive)
          this.BlockedPlaces[index].DrawEntrance(Vector2.Zero, AssetContainer.pointspritebatch03);
      }
    }
  }
}
