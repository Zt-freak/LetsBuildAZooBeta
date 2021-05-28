// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Park.DecoCalculator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;
using TinyZoo.PlayerDir;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_BalanceSystems.Park
{
  internal class DecoCalculator
  {
    internal static float OverallDecoEfficiiency = 0.0f;
    internal static bool RecalculateDeco = true;
    private Vector2Int JustCalculateThisDecoSector;
    private static ParkDecoSector[,] decobysector;
    private static int TotalSectorsX;
    private static int TotalSectorsY;
    private static float TotalDeco;
    private static List<Vector2Int> SectorsToRecheck;
    internal static int TotalSigns;
    internal static float TotalSignPoints;

    internal static float CalculateDeco(Player player)
    {
      if (DecoCalculator.RecalculateDeco)
      {
        DecoCalculator.RecalculateDeco = false;
        DecoCalculator.TotalDeco = 0.0f;
        DecoCalculator.TotalSignPoints = 0.0f;
        if (DecoCalculator.decobysector == null)
        {
          DecoCalculator.TotalSectorsX = TileMath.GetOverWorldMapSize_XDefault() / TileMath.SectorSize;
          DecoCalculator.TotalSectorsY = TileMath.GetOverWorldMapSize_YSize() / TileMath.SectorSize;
          DecoCalculator.decobysector = new ParkDecoSector[DecoCalculator.TotalSectorsX, DecoCalculator.TotalSectorsY];
          for (int SecX = 0; SecX < DecoCalculator.TotalSectorsX; ++SecX)
          {
            for (int SecY = 0; SecY < DecoCalculator.TotalSectorsY; ++SecY)
            {
              DecoCalculator.decobysector[SecX, SecY] = new ParkDecoSector();
              DecoCalculator.RefreshSector(player, SecX, SecY);
            }
          }
        }
        else if (DecoCalculator.SectorsToRecheck != null)
        {
          for (int index = 0; index < DecoCalculator.SectorsToRecheck.Count; ++index)
            DecoCalculator.RefreshSector(player, DecoCalculator.SectorsToRecheck[index].X, DecoCalculator.SectorsToRecheck[index].Y);
          DecoCalculator.SectorsToRecheck = (List<Vector2Int>) null;
        }
        else
        {
          for (int SecX = 0; SecX < DecoCalculator.TotalSectorsX; ++SecX)
          {
            for (int SecY = 0; SecY < DecoCalculator.TotalSectorsY; ++SecY)
              DecoCalculator.RefreshSector(player, SecX, SecY);
          }
        }
        DecoCalculator.OverallDecoEfficiiency = 0.0f;
        for (int index1 = 0; index1 < DecoCalculator.TotalSectorsX; ++index1)
        {
          for (int index2 = 0; index2 < DecoCalculator.TotalSectorsY; ++index2)
          {
            DecoCalculator.TotalDeco += DecoCalculator.decobysector[index1, index2].LastDecoValue;
            DecoCalculator.TotalSignPoints += DecoCalculator.decobysector[index1, index2].SignValue;
            DecoCalculator.OverallDecoEfficiiency += DecoCalculator.decobysector[index1, index2].Efficiency;
          }
        }
        float totalLandUnlocked = (float) PlayerStats.GetTotalLandUnlocked();
        DecoCalculator.OverallDecoEfficiiency /= totalLandUnlocked;
      }
      return DecoCalculator.TotalDeco;
    }

    internal static float GetThisEfficiency(int Xloc, int Yloc) => DecoCalculator.decobysector[Xloc, Yloc] != null ? DecoCalculator.decobysector[Xloc, Yloc].Efficiency : 0.0f;

    internal static float GetThisValue(int Xloc, int Yloc) => DecoCalculator.decobysector[Xloc, Yloc] != null ? DecoCalculator.decobysector[Xloc, Yloc].LastDecoValue : 0.0f;

    internal static void AddOrRemovedDeco(Vector2Int Location)
    {
      ParkRating.NeedsRecalculating = true;
      DecoCalculator.RecalculateDeco = true;
      int _X = Location.X / TileMath.SectorSize;
      int _Y = Location.Y / TileMath.SectorSize;
      if (DecoCalculator.SectorsToRecheck == null)
      {
        DecoCalculator.SectorsToRecheck = new List<Vector2Int>();
        DecoCalculator.SectorsToRecheck.Add(new Vector2Int(_X, _Y));
      }
      else
      {
        for (int index = 0; index < DecoCalculator.SectorsToRecheck.Count; ++index)
        {
          if (DecoCalculator.SectorsToRecheck[index].X == _X && DecoCalculator.SectorsToRecheck[index].Y == _Y)
            return;
        }
        DecoCalculator.SectorsToRecheck.Add(new Vector2Int(_X, _Y));
      }
    }

    private static void RefreshSector(Player player, int SecX, int SecY)
    {
      DecoCalculator.decobysector[SecX, SecY] = new ParkDecoSector();
      for (int index1 = SecX * TileMath.SectorSize; index1 < (SecX + 1) * TileMath.SectorSize; ++index1)
      {
        for (int index2 = SecY * TileMath.SectorSize; index2 < (SecY + 1) * TileMath.SectorSize; ++index2)
        {
          if (player.prisonlayout.layout.BaseTileTypes[index1, index2] != null && player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype != TILETYPE.None && (player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype != TILETYPE.BoundaryTree && player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype != TILETYPE.PinkMoonPlant))
          {
            if (TileData.IsThisAnyKindOfDeco(player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype))
              DecoCalculator.decobysector[SecX, SecY].AddDeco(player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype);
            else if (TileData.IsThisASignBoard(player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype))
              DecoCalculator.decobysector[SecX, SecY].AddSign(player.prisonlayout.layout.BaseTileTypes[index1, index2].tiletype);
          }
        }
      }
      DecoCalculator.decobysector[SecX, SecY].CalculateDeco();
    }
  }
}
