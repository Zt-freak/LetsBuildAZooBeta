// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Animal_Data.EnrichmentEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_Animal_Data
{
  internal class EnrichmentEntry
  {
    public HashSet<AnimalType> animalsthatusethis;
    public List<Vector2Int> Animal_EnrichValue;
    public HashSet<TILETYPE> TheseItems;
    public ENRICHMENTCLASS enrichmentclass;

    public EnrichmentEntry(ENRICHMENTCLASS _enrichmentclass)
    {
      this.enrichmentclass = _enrichmentclass;
      this.animalsthatusethis = new HashSet<AnimalType>();
      this.Animal_EnrichValue = new List<Vector2Int>();
      this.TheseItems = new HashSet<TILETYPE>();
      switch (this.enrichmentclass)
      {
        case ENRICHMENTCLASS.WaterSprinklers:
          this.TheseItems.Add(TILETYPE.Enrichment_WaterSprinklers);
          break;
        case ENRICHMENTCLASS.Trampoline:
          this.TheseItems.Add(TILETYPE.Enrichment_BlueTrampoline);
          this.TheseItems.Add(TILETYPE.Enrichment_PinkTrampoline);
          break;
        case ENRICHMENTCLASS.WoodenPost:
          this.TheseItems.Add(TILETYPE.Enrichment_ScratchingPostWood);
          this.TheseItems.Add(TILETYPE.Enrichment_ScratchingPoleTree);
          break;
        case ENRICHMENTCLASS.LargeBall:
          this.TheseItems.Add(TILETYPE.Enrichment_LargeRedBall);
          this.TheseItems.Add(TILETYPE.Enrichment_LargeWhiteBall);
          this.TheseItems.Add(TILETYPE.Enrichment_LargeGreenBall);
          this.TheseItems.Add(TILETYPE.Enrichment_LargeYellowBall);
          this.TheseItems.Add(TILETYPE.Enrichment_LargeBlueBall);
          break;
        case ENRICHMENTCLASS.SmallBall:
          this.TheseItems.Add(TILETYPE.Enrichment_SmallBlueBall);
          this.TheseItems.Add(TILETYPE.Enrichment_SmallCyanBall);
          this.TheseItems.Add(TILETYPE.Enrichment_SmallGreenBall);
          this.TheseItems.Add(TILETYPE.Enrichment_SmallRedBall);
          this.TheseItems.Add(TILETYPE.Enrichment_SmallPinkBall);
          break;
        case ENRICHMENTCLASS.RopeToy:
          this.TheseItems.Add(TILETYPE.Enrichment_TugRopeToy);
          break;
        case ENRICHMENTCLASS.BoneToy:
          this.TheseItems.Add(TILETYPE.Enrichment_ChewToyPurpleBone);
          this.TheseItems.Add(TILETYPE.Enrichment_ChewToyBrownBone);
          this.TheseItems.Add(TILETYPE.Enrichment_ChewToyRope);
          break;
        case ENRICHMENTCLASS.Tunnel:
          this.TheseItems.Add(TILETYPE.Enrichment_TunnelGreen);
          this.TheseItems.Add(TILETYPE.Enrichment_TunnelWoodenLog);
          break;
        case ENRICHMENTCLASS.WoodenLogs:
          this.TheseItems.Add(TILETYPE.Enrichment_WoodenLogs);
          this.TheseItems.Add(TILETYPE.Enrichment_WoodenBeam2);
          this.TheseItems.Add(TILETYPE.Enrichment_WoodenBeam3);
          break;
        case ENRICHMENTCLASS.CardboardBoxes:
          this.TheseItems.Add(TILETYPE.Enrichment_LargeCardboardBox);
          this.TheseItems.Add(TILETYPE.Enrichment_CardboardBox2);
          break;
        case ENRICHMENTCLASS.CarTire:
          this.TheseItems.Add(TILETYPE.Enrichment_HangingCarTire);
          this.TheseItems.Add(TILETYPE.Enrichment_FlatCarTire);
          break;
        case ENRICHMENTCLASS.RockPerch:
          this.TheseItems.Add(TILETYPE.Enrichment_RockPerch);
          this.TheseItems.Add(TILETYPE.Enrichment_BrownRockPerch);
          this.TheseItems.Add(TILETYPE.Enrichment_YellowRockPerch);
          this.TheseItems.Add(TILETYPE.Enrichment_LogPerch);
          this.TheseItems.Add(TILETYPE.Enrichment_NetPerch);
          break;
        case ENRICHMENTCLASS.HighWoodBeamPerch:
          this.TheseItems.Add(TILETYPE.Enrichment_HighWoodBeamPerch);
          this.TheseItems.Add(TILETYPE.Enrichment_HighPerch);
          this.TheseItems.Add(TILETYPE.Enrichment_TreeHighPerch);
          break;
        case ENRICHMENTCLASS.RockCliff_Perch:
          this.TheseItems.Add(TILETYPE.Enrichment_RockCliff);
          this.TheseItems.Add(TILETYPE.Enrichment_IceCliff);
          this.TheseItems.Add(TILETYPE.Enrichment_BrownCliff);
          break;
        case ENRICHMENTCLASS.SaltBlock:
          this.TheseItems.Add(TILETYPE.Enrichment_SaltBlock);
          break;
        case ENRICHMENTCLASS.Mirror:
          this.TheseItems.Add(TILETYPE.Enrichment_MirrorRect);
          this.TheseItems.Add(TILETYPE.Enrichment_MirrorRound);
          break;
        case ENRICHMENTCLASS.ScentMarkers:
          this.TheseItems.Add(TILETYPE.Enrichment_ScentMarkerGrey);
          this.TheseItems.Add(TILETYPE.Enrichment_ScentMarkerGreen);
          this.TheseItems.Add(TILETYPE.Enrichment_ScentMarkerBrown);
          break;
        case ENRICHMENTCLASS.TugBallJollyBall:
          this.TheseItems.Add(TILETYPE.Enrichment_TugBallJollyBallYellow);
          break;
      }
    }

    public void AddAnimal(AnimalType animaltype, int EnrichmentValue)
    {
      this.animalsthatusethis.Add(animaltype);
      this.Animal_EnrichValue.Add(new Vector2Int((int) animaltype, EnrichmentValue));
    }
  }
}
