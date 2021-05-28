// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuldMenu.Z_NewCostInfo.PenBuildInfo.PenBuildInfoManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TinyZoo.GenericUI;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BuldMenu.PenBuilder.Pens;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_BuldMenu.Z_NewCostInfo.PenBuildInfo
{
  internal class PenBuildInfoManager
  {
    private CustomerFrame customerframe;
    private CustomerFrame EvilFrame;
    private SimpleTextHandler simpletext;
    private SimpleTextHandler simpletextCantAfford;
    private SimpleTextHandler simpletextTooWide;
    private SimpleTextHandler simpletextTooLow;
    private int COST;
    private int CurrentTiles;
    private StringInBox CurrentCost;
    public bool CanAfford;
    private UIScaleHelper scalehelper;
    private string COST_String;
    private string CantAffordString;
    private bool IsCustomBuyOrSell;
    private bool ToooWide;
    private bool TooLow;

    public PenBuildInfoManager(
      TILETYPE tiletype,
      Player player,
      float BaseScale,
      bool _IsCustomBuyOrSell = false,
      float PreMultipliedWidth = -1f)
    {
      this.IsCustomBuyOrSell = _IsCustomBuyOrSell;
      this.scalehelper = new UIScaleHelper(BaseScale);
      Vector2 defaultBuffer = this.scalehelper.DefaultBuffer;
      this.COST = player.livestats.GetCost(tiletype, player, true);
      float width_ = 90f * BaseScale;
      if ((double) PreMultipliedWidth > -1.0)
        width_ = PreMultipliedWidth;
      this.COST_String = string.Format(SEngine.Localization.Localization.GetText(945), (object) this.COST);
      this.CantAffordString = SEngine.Localization.Localization.GetText(946);
      if (this.IsCustomBuyOrSell)
        CategoryData.IsThisACroppedFloor(tiletype);
      this.simpletext = new SimpleTextHandler(this.COST_String, width_, true, BaseScale, AutoComplete: true);
      this.simpletext.SetAllColours(ColourData.Z_Cream);
      this.simpletextCantAfford = new SimpleTextHandler(this.CantAffordString, width_, true, BaseScale, AutoComplete: true);
      this.simpletextCantAfford.SetAllColours(ColourData.Z_Cream);
      this.simpletextTooWide = new SimpleTextHandler("Too wide! Try to avoid building enclosures that will block your staff and your customers' movement.", width_, true, BaseScale, AutoComplete: true);
      this.simpletextTooWide.SetAllColours(ColourData.Z_Cream);
      this.simpletextTooLow = new SimpleTextHandler("Too low! Try to avoid building enclosures and structures that will block access to your zoo.", width_, true, BaseScale, AutoComplete: true);
      this.simpletextTooLow.SetAllColours(ColourData.Z_Cream);
      this.CurrentCost = new StringInBox(BaseScale, "$0", 100f * BaseScale, true, true, _UseOnePointFiveFont: true);
      this.CurrentTiles = -1;
      this.CurrentCost.SetWhite();
      float y = BaseScale * 15f + 2f * defaultBuffer.Y + this.CurrentCost.VScale.Y + defaultBuffer.Y;
      float num1 = -0.5f * y + defaultBuffer.Y;
      this.simpletextCantAfford.Location.Y = num1 + 0.5f * this.simpletextCantAfford.GetSize(true).Y;
      this.simpletext.Location.Y = num1 + 0.5f * this.simpletext.GetSize(true).Y;
      float num2 = num1 + (Math.Max(this.simpletextCantAfford.GetSize(true).Y, this.simpletext.GetSize(true).Y) + defaultBuffer.Y);
      this.CurrentCost.vLocation.Y = y * 0.5f;
      this.CurrentCost.vLocation.Y -= this.CurrentCost.VScale.Y * 0.5f;
      this.CurrentCost.vLocation.Y -= 10f * BaseScale;
      this.simpletextTooLow.Location.Y = this.simpletextCantAfford.Location.Y;
      this.simpletextTooWide.Location.Y = this.simpletextCantAfford.Location.Y;
      this.customerframe = (double) PreMultipliedWidth <= -1.0 ? new CustomerFrame(new Vector2(210f * BaseScale, y), CustomerFrameColors.Brown, BaseScale) : new CustomerFrame(new Vector2(PreMultipliedWidth, y), CustomerFrameColors.Brown, BaseScale);
      if (this.customerframe == null)
        return;
      this.EvilFrame = new CustomerFrame(this.customerframe.VSCale, true, BaseScale);
      this.EvilFrame.SetAlertRed();
    }

    public void FlashRedCantAfford() => this.customerframe.frame.SetPrimaryColours(0.5f, new Vector3(1f, 0.0f, 0.0f));

    public Vector2 GetSize() => this.customerframe.VSCale;

    public void UpdatePenBuildInfoManager(
      Player player,
      int _CurrentTiles,
      Z_PenBuilder z_penbuilder,
      float DeltaTime)
    {
      this.customerframe.frame.UpdateColours(DeltaTime);
      bool flag1 = true;
      bool flag2 = false;
      if (!Z_GameFlags.HasStartedFirstDay)
      {
        flag2 = true;
        int num = 0;
        if (z_penbuilder != null)
          num = z_penbuilder.GetMaxWidth();
        this.CanAfford = true;
        this.ToooWide = false;
        this.TooLow = false;
        if (num >= 22)
        {
          this.ToooWide = true;
          this.CurrentCost.SetRed();
          this.CanAfford = false;
          flag1 = false;
        }
        else if (z_penbuilder != null && z_penbuilder.IsBlockingGate())
        {
          flag1 = false;
          this.CurrentCost.SetRed();
          this.CanAfford = false;
          this.TooLow = true;
        }
      }
      if (!flag1)
        return;
      if (this.IsCustomBuyOrSell && _CurrentTiles == -1)
      {
        _CurrentTiles = 1;
        if (!this.CanAfford)
        {
          if (player.Stats.GetCashHeld() >= this.COST)
          {
            this.CurrentCost.SetGreen();
            this.CanAfford = true;
          }
        }
        else if (player.Stats.GetCashHeld() < this.COST)
        {
          this.CurrentCost.SetRed();
          this.CanAfford = false;
        }
      }
      if (!(this.CurrentTiles != _CurrentTiles | flag2))
        return;
      int num1 = this.COST * _CurrentTiles;
      this.CurrentTiles = _CurrentTiles;
      this.CurrentCost.SetText("$" + (object) num1);
      if (player.Stats.GetCashHeld() >= num1 || num1 == 0)
      {
        if (num1 == 0)
          this.CurrentCost.SetWhite();
        else
          this.CurrentCost.SetGreen();
        this.CanAfford = true;
      }
      else
      {
        this.CurrentCost.SetRed();
        this.CanAfford = false;
      }
    }

    public void DrawPenBuildInfoManager(Vector2 Offset, SpriteBatch spritebatch)
    {
      this.customerframe.DrawCustomerFrame(Offset, spritebatch);
      if (this.CanAfford)
      {
        this.simpletext.DrawSimpleTextHandler(Offset, 1f, spritebatch);
      }
      else
      {
        if (this.ToooWide)
        {
          this.EvilFrame.DrawCustomerFrame(Offset, spritebatch);
          this.simpletextTooWide.DrawSimpleTextHandler(Offset, 1f, spritebatch);
          return;
        }
        if (this.TooLow)
        {
          this.EvilFrame.DrawCustomerFrame(Offset, spritebatch);
          this.simpletextTooLow.DrawSimpleTextHandler(Offset, 1f, spritebatch);
          return;
        }
        this.simpletextCantAfford.DrawSimpleTextHandler(Offset, 1f, spritebatch);
      }
      this.CurrentCost.DrawStringInBox(Offset, spritebatch);
    }
  }
}
