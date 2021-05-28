// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.TradeList.TradeListFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_BalanceSystems.Animals.SellCosts;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.TradeList
{
  internal class TradeListFrame
  {
    public Vector2 location;
    private string headerBaseString;
    private ZGenericText headerText;
    private CustomerFrame customerFrame;
    private AnimalInFrameGrid animalsInFrameGrid;
    private TradeStackWithNumber TradeStackWithNumber;
    private TextButton tradeButton;
    private List<AnimalRenderDescriptor> RefanimalsNeeded_forQuest;
    private bool isBlackMarketUI;
    private float BaseScale;
    private Vector2 temp_GridLocation;
    private float Xbuffer;
    private float Ybuffer;
    private int numberPerRow;
    private int maxAnimalsBeforeStacking;

    public List<PrisonerInfo> tradeList { get; private set; }

    public bool ReadyForTrade { get; private set; }

    public TradeListFrame(
      List<AnimalRenderDescriptor> animalsNeeded_forQuest,
      float _BaseScale,
      Vector2 frameSize,
      bool _isBlackMarketUI = false)
    {
      this.RefanimalsNeeded_forQuest = animalsNeeded_forQuest;
      this.isBlackMarketUI = _isBlackMarketUI;
      this.BaseScale = _BaseScale;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(this.BaseScale);
      this.Xbuffer = uiScaleHelper.GetDefaultXBuffer();
      this.Ybuffer = uiScaleHelper.GetDefaultYBuffer();
      this.customerFrame = new CustomerFrame(frameSize, CustomerFrameColors.DarkBrown, this.BaseScale);
      Vector2 vector2_1 = -this.customerFrame.VSCale * 0.5f;
      float x = this.Xbuffer + vector2_1.X;
      float y1 = this.Ybuffer + vector2_1.Y;
      string empty = string.Empty;
      string _textToWrite;
      if (this.isBlackMarketUI)
      {
        this.headerBaseString = "Offered For Sale: {0}, Total: ${1}";
        _textToWrite = string.Format(this.headerBaseString, (object) 0, (object) 0);
      }
      else
      {
        this.headerBaseString = "Required For Trade: {0}/{1}";
        _textToWrite = string.Format(this.headerBaseString, (object) 0, (object) this.RefanimalsNeeded_forQuest.Count);
      }
      this.headerText = new ZGenericText(_textToWrite, this.BaseScale, false, _UseOnePointFiveFont: true);
      this.headerText.vLocation = new Vector2(x, y1);
      float y2 = y1 + (this.headerText.GetSize().Y + this.Ybuffer);
      Vector2 vector2_2 = uiScaleHelper.ScaleVector2(25f * Vector2.One);
      this.numberPerRow = (int) Math.Floor((double) frameSize.X / ((double) vector2_2.X + (double) this.Xbuffer));
      this.maxAnimalsBeforeStacking = this.numberPerRow * (int) Math.Floor(((double) frameSize.Y - (double) this.headerText.GetSize().Y - (double) this.Ybuffer * 2.0) / ((double) vector2_2.Y + (double) this.Ybuffer)) - 3;
      this.temp_GridLocation = new Vector2(x, y2);
      if (!this.isBlackMarketUI)
        this.CreateAnimalGrid(animalsNeeded_forQuest);
      string TextToDraw = "Trade";
      if (this.isBlackMarketUI)
        TextToDraw = "Sell";
      this.tradeButton = new TextButton(this.BaseScale, TextToDraw, 40f);
      this.tradeButton.vLocation.X = (float) ((double) frameSize.X + (double) vector2_1.X - (double) this.tradeButton.GetSize_True().X * 0.5) - this.Xbuffer;
      this.tradeButton.vLocation.Y = (float) ((double) frameSize.Y + (double) vector2_1.Y - (double) this.tradeButton.GetSize_True().Y * 0.5) - this.Ybuffer;
      this.RefreshButton();
      this.tradeList = new List<PrisonerInfo>();
    }

    private void CreateAnimalGrid(List<AnimalRenderDescriptor> animalsToDisplay)
    {
      if (animalsToDisplay.Count > this.maxAnimalsBeforeStacking)
      {
        if (this.isBlackMarketUI)
        {
          this.animalsInFrameGrid = new AnimalInFrameGrid(this.BaseScale, this.numberPerRow, this.Xbuffer, this.Ybuffer, animalsToDisplay.ToList<AnimalRenderDescriptor>(), this.maxAnimalsBeforeStacking, UseNumberFrameWhenMaxFrames_NotButton: true);
          this.animalsInFrameGrid.location += this.temp_GridLocation;
        }
        else
        {
          this.TradeStackWithNumber = new TradeStackWithNumber(this.BaseScale, animalsToDisplay);
          this.TradeStackWithNumber.location += this.temp_GridLocation;
        }
      }
      else
      {
        this.animalsInFrameGrid = new AnimalInFrameGrid(this.BaseScale, this.numberPerRow, this.Xbuffer, this.Ybuffer, animalsToDisplay.ToList<AnimalRenderDescriptor>());
        this.animalsInFrameGrid.location += this.temp_GridLocation;
      }
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    private void RefreshButton()
    {
      if (!this.ReadyForTrade)
        this.tradeButton.SetButtonColour(BTNColour.Grey);
      else
        this.tradeButton.SetButtonColour(BTNColour.Green);
    }

    public bool AddOrRemoveThisFromTradeList(PrisonerInfo animal)
    {
      bool flag;
      if (this.tradeList.Contains(animal))
      {
        this.tradeList.Remove(animal);
        flag = false;
      }
      else
      {
        this.tradeList.Add(animal);
        flag = true;
      }
      if (this.isBlackMarketUI)
      {
        this.ReadyForTrade = this.tradeList.Count > 0;
        this.headerText.textToWrite = string.Format(this.headerBaseString, (object) this.tradeList.Count, (object) this.GetRecalculatedTotalCost());
        List<AnimalRenderDescriptor> animalsToDisplay = new List<AnimalRenderDescriptor>();
        foreach (PrisonerInfo trade in this.tradeList)
          animalsToDisplay.Add(new AnimalRenderDescriptor(trade.intakeperson.animaltype, trade.intakeperson.CLIndex, trade.intakeperson.HeadType, trade.intakeperson.HeadVariant, _IsFemale: trade.intakeperson.IsAGirl));
        this.CreateAnimalGrid(animalsToDisplay);
      }
      else
      {
        this.ReadyForTrade = this.tradeList.Count == this.RefanimalsNeeded_forQuest.Count;
        this.headerText.textToWrite = string.Format(this.headerBaseString, (object) this.tradeList.Count, (object) this.RefanimalsNeeded_forQuest.Count);
      }
      this.RefreshButton();
      return flag;
    }

    private int GetRecalculatedTotalCost()
    {
      int num = 0;
      for (int index = 0; index < this.tradeList.Count; ++index)
        num += AnimalSellCostCalculator.GetSellCostOfPlayerAnimal(this.tradeList[index]);
      return num;
    }

    public bool UpdateTradeListFrame(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      return this.ReadyForTrade && this.tradeButton.UpdateTextButton(player, offset, DeltaTime);
    }

    public void DrawTradeListFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      if (this.animalsInFrameGrid != null)
        this.animalsInFrameGrid.DrawAnimalInFrameGrid(offset, spriteBatch);
      if (this.TradeStackWithNumber != null)
        this.TradeStackWithNumber.DrawTradeStackWithNumber(offset, spriteBatch);
      this.headerText.DrawZGenericText(offset, spriteBatch);
      this.tradeButton.DrawTextButton(offset, 1f, spriteBatch);
    }
  }
}
