// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.SelectionGrid.CustomAnimalSelectionGridFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_WorldMap.WorldMapPopUps.AnimalTradeQuests.AnimalSelection.SelectionGrid
{
  internal class CustomAnimalSelectionGridFrame
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private CustomAnimalSelectionGrid animalSelectionGrid;

    public CustomAnimalSelectionGridFrame(
      List<PrisonerInfo> animals,
      Player player,
      float BaseScale,
      int frameCount_X = 7,
      int frameCount_Y = 5,
      bool AddSellPrice = false)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      this.animalSelectionGrid = new CustomAnimalSelectionGrid(animals, player, BaseScale, frameCount_X, frameCount_Y, AddSellPrice);
      this.animalSelectionGrid.location = new Vector2(defaultXbuffer, defaultYbuffer);
      this.customerFrame = new CustomerFrame(this.animalSelectionGrid.GetSize(true, true) + new Vector2(defaultXbuffer * 2f, defaultYbuffer * 2f), CustomerFrameColors.DarkBrown, BaseScale);
      this.animalSelectionGrid.location += -this.customerFrame.VSCale * 0.5f;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public void AddTickToSelectedEntry(bool removeTick = false) => this.animalSelectionGrid.TickLastSelectedEntry(removeTick);

    public PrisonerInfo UpdateCustomAnimalSelectionGridFrame(
      Player player,
      float DeltaTime,
      Vector2 offset)
    {
      offset += this.location;
      return this.animalSelectionGrid.UpdateCustomAnimalSelectionGrid(player, DeltaTime, offset);
    }

    public void DrawCustomAnimalSelectionGridFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.animalSelectionGrid.DrawCustomAnimalSelectionGrid(offset, spriteBatch);
    }
  }
}
