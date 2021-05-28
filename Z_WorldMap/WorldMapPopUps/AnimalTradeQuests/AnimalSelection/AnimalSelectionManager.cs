// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.AnimalSelectionManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_BalanceSystems.Animals.SellCosts;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_Quests;
using TinyZoo.Z_SummaryPopUps.People.Customer;
using TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.InfoBox;
using TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.SelectionGrid;
using TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.TradeList;

namespace TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection
{
  internal class AnimalSelectionManager
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private CustomAnimalSelectionGridFrame animalSelectionGridFrame;
    private AnimalLocationInfoBox animalLocationInfoBox;
    private AnimalInfoBox animalInfoBox;
    private SimpleTextHandler noAnimalsText;
    private TradeListFrame tradeListFrame;
    private bool IsBlackMarket;

    public QuestPack refQuest { get; private set; }

    public AnimalSelectionManager(
      QuestPack quest,
      List<AnimalRenderDescriptor> animalsNeeded,
      Player player,
      float BaseScale,
      Vector2 ForcedSize,
      int frameCount_X = 7,
      int frameCount_Y = 5)
    {
      this.refQuest = quest;
      this.SetUp(AnimalSelectionManager.GetListOfPlayersAnimalsThatCanBeIncludedInTrade(quest, player), animalsNeeded, player, BaseScale, ForcedSize, frameCount_X, frameCount_Y);
    }

    public AnimalSelectionManager(
      bool _IsBlackMarket,
      Player player,
      float BaseScale,
      Vector2 forcedWidth,
      AnimalType viewThisAnimalTypeOnly = AnimalType.None,
      int frameCount_X = 7,
      int frameCount_Y = 5)
    {
      this.IsBlackMarket = _IsBlackMarket;
      this.SetUp(AnimalSelectionManager.GetListOfPlayerAnimals(player, viewThisAnimalTypeOnly), (List<AnimalRenderDescriptor>) null, player, BaseScale, forcedWidth, frameCount_X, frameCount_Y);
    }

    private void SetUp(
      List<PrisonerInfo> animalsToTrade,
      List<AnimalRenderDescriptor> animalsNeeded,
      Player player,
      float BaseScale,
      Vector2 ForcedSize,
      int frameCount_X = 7,
      int frameCount_Y = 5)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      this.customerFrame = new CustomerFrame(ForcedSize, CustomerFrameColors.Brown, BaseScale);
      Vector2 vector2 = -this.customerFrame.VSCale * 0.5f;
      float x1 = defaultXbuffer + vector2.X;
      float y1 = defaultYbuffer + vector2.Y;
      this.animalSelectionGridFrame = new CustomAnimalSelectionGridFrame(animalsToTrade, player, BaseScale, frameCount_X, frameCount_Y, this.IsBlackMarket);
      Vector2 size1 = this.animalSelectionGridFrame.GetSize();
      float x2 = (float) ((double) ForcedSize.X - ((double) size1.X + (double) defaultXbuffer) - (double) defaultXbuffer * 2.0);
      this.animalInfoBox = new AnimalInfoBox(BaseScale, new Vector2(x2, size1.Y));
      Vector2 size2 = this.animalInfoBox.GetSize();
      this.animalInfoBox.location = new Vector2(x1, y1) + size2 * 0.5f;
      float x3 = x1 + (size2.X + defaultXbuffer);
      this.animalSelectionGridFrame.location = new Vector2(x3, y1) + size1 * 0.5f;
      float num = x3 + (size1.X + defaultXbuffer);
      if (animalsToTrade.Count == 0)
      {
        this.noAnimalsText = new SimpleTextHandler("You do not have any animals that can be used for this trade.", true, (float) ((double) size1.X / 1024.0 * 0.899999976158142), BaseScale, AutoComplete: true);
        this.noAnimalsText.SetAllColours(ColourData.Z_Cream);
        this.noAnimalsText.Location = this.animalSelectionGridFrame.location;
      }
      float y2 = y1 + (this.animalSelectionGridFrame.GetSize().Y + defaultYbuffer);
      float x4 = defaultXbuffer + vector2.X;
      float y3 = ForcedSize.Y - defaultYbuffer * 2f - size1.Y - defaultYbuffer;
      if (!this.IsBlackMarket)
      {
        this.animalLocationInfoBox = new AnimalLocationInfoBox(animalsNeeded[0].bodyAnimalType, animalsNeeded[0].variant, player, BaseScale);
        Vector2 size3 = this.animalLocationInfoBox.GetSize();
        this.animalLocationInfoBox.location = new Vector2(x4, y2) + size3 * 0.5f;
        x4 += size3.X + defaultXbuffer;
      }
      float x5 = ForcedSize.X - (x4 - vector2.X) - defaultXbuffer;
      this.tradeListFrame = new TradeListFrame(animalsNeeded, BaseScale, new Vector2(x5, y3), this.IsBlackMarket);
      this.tradeListFrame.location = new Vector2(x4, y2) + this.tradeListFrame.GetSize() * 0.5f;
    }

    public static List<PrisonerInfo> GetListOfPlayersAnimalsThatCanBeIncludedInTrade(
      QuestPack quest,
      Player player)
    {
      List<PrisonerInfo> prisonerInfoList = new List<PrisonerInfo>();
      List<PrisonZone> prisonzones = player.prisonlayout.cellblockcontainer.prisonzones;
      for (int index = 0; index < prisonzones.Count; ++index)
      {
        foreach (PrisonerInfo prisoner in prisonzones[index].prisonercontainer.prisoners)
        {
          if (!prisoner.IsDead)
          {
            foreach (TradeInfo tradeInfo in quest.trades_ListOnlyOne)
            {
              if (tradeInfo.animal == prisoner.intakeperson.animaltype && (tradeInfo.VariantIndex == -1 || tradeInfo.VariantIndex == 0 || tradeInfo.VariantIndex == prisoner.intakeperson.CLIndex))
                prisonerInfoList.Add(prisoner);
            }
          }
        }
      }
      return prisonerInfoList;
    }

    public static List<PrisonerInfo> GetListOfPlayerHybridAnimals(Player player)
    {
      List<PrisonerInfo> prisonerInfoList = new List<PrisonerInfo>();
      List<PrisonZone> prisonzones = player.prisonlayout.cellblockcontainer.prisonzones;
      for (int index = 0; index < prisonzones.Count; ++index)
      {
        foreach (PrisonerInfo prisoner in prisonzones[index].prisonercontainer.prisoners)
        {
          if (!prisoner.IsDead && prisoner.intakeperson.HeadType != AnimalType.None && prisoner.intakeperson.animaltype != prisoner.intakeperson.HeadType)
            prisonerInfoList.Add(prisoner);
        }
      }
      return prisonerInfoList;
    }

    public static List<PrisonerInfo> GetListOfPlayerAnimals(
      Player player,
      AnimalType filterThisAnimalType = AnimalType.None)
    {
      List<PrisonerInfo> prisonerInfoList = new List<PrisonerInfo>();
      List<PrisonZone> prisonzones = player.prisonlayout.cellblockcontainer.prisonzones;
      for (int index = 0; index < prisonzones.Count; ++index)
      {
        foreach (PrisonerInfo prisoner in prisonzones[index].prisonercontainer.prisoners)
        {
          if (!prisoner.IsDead)
          {
            if (filterThisAnimalType != AnimalType.None)
            {
              if (prisoner.intakeperson.animaltype == filterThisAnimalType)
                prisonerInfoList.Add(prisoner);
            }
            else
              prisonerInfoList.Add(prisoner);
          }
        }
      }
      return prisonerInfoList;
    }

    private int GetBlackMarketSellPriceOfThisAnimal(PrisonerInfo animal) => !this.IsBlackMarket ? -1 : AnimalSellCostCalculator.GetSellCostOfPlayerAnimal(animal);

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public bool UpdateAnimalSelectionManager(
      Player player,
      float DeltaTime,
      Vector2 offset,
      out List<PrisonerInfo> animalsSelected)
    {
      animalsSelected = (List<PrisonerInfo>) null;
      offset += this.location;
      PrisonerInfo animal1 = this.animalSelectionGridFrame.UpdateCustomAnimalSelectionGridFrame(player, DeltaTime, offset);
      bool flag = this.tradeListFrame.ReadyForTrade;
      if (this.IsBlackMarket)
        flag = false;
      if (animal1 != null)
        this.animalInfoBox.SetInfoForThisAnimal(animal1, this.tradeListFrame.tradeList.Contains(animal1), flag, this.GetBlackMarketSellPriceOfThisAnimal(animal1));
      PrisonerInfo animal2 = this.animalInfoBox.UpdateAnimalInfoBox(player, DeltaTime, offset);
      if (animal2 != null)
      {
        bool selectThis = this.tradeListFrame.AddOrRemoveThisFromTradeList(animal2);
        if (!this.IsBlackMarket && !selectThis)
          flag = false;
        this.animalInfoBox.SetSelection(selectThis, flag);
        this.animalSelectionGridFrame.AddTickToSelectedEntry(!selectThis);
      }
      if (this.animalLocationInfoBox != null)
        this.animalLocationInfoBox.UpdateAnimalLocationInfoBox(player, DeltaTime, offset);
      if (!this.tradeListFrame.UpdateTradeListFrame(player, DeltaTime, offset))
        return false;
      animalsSelected = this.tradeListFrame.tradeList;
      return true;
    }

    public void DrawAnimalSelectionManager(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.animalSelectionGridFrame.DrawCustomAnimalSelectionGridFrame(offset, spriteBatch);
      this.animalInfoBox.DrawAnimalInfoBox(offset, spriteBatch);
      if (this.noAnimalsText != null)
        this.noAnimalsText.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      this.tradeListFrame.DrawTradeListFrame(offset, spriteBatch);
      if (this.animalLocationInfoBox == null)
        return;
      this.animalLocationInfoBox.DrawAnimalLocationInfoBox(offset, spriteBatch);
    }
  }
}
