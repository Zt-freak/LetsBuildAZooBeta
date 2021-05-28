// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.Z_Processing.NewPanel.ProcessingValueView.QueueView.DeadAnimalsInQueue
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TinyZoo.PlayerDir._Factories;
using TinyZoo.PlayerDir.Incinerator;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_GenericUI.Z_Scroll;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_BuildingInfo.Z_Processing.NewPanel.ProcessingValueView.QueueView
{
  internal class DeadAnimalsInQueue
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private MiniHeading miniHeading;
    private List<AnimalInFrame> animals;
    private AnimalInFrameGrid animalGrid;
    private float BaseScale;
    private Z_ScrollHelper scrollHelper;
    private Vector2 contentsSize;
    private string baseString;
    private FactoryProductionLine reffactoryproduction;
    private float lastStockCount;

    public DeadAnimalsInQueue(
      FactoryProductionLine factoryproduction,
      float _BaseScale,
      float ForcedHeight,
      float ForcedWidth)
    {
      this.BaseScale = _BaseScale;
      this.reffactoryproduction = factoryproduction;
      this.customerFrame = new CustomerFrame(new Vector2(ForcedWidth, ForcedHeight), CustomerFrameColors.DarkBrown, this.BaseScale);
      this.baseString = "Waiting for Processing Queue: ";
      this.miniHeading = new MiniHeading(this.customerFrame.VSCale, this.baseString + (object) 0, 1f, this.BaseScale);
      this.animals = new List<AnimalInFrame>();
      this.SetUp();
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    private void SetUp()
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(this.BaseScale);
      Vector2 defaultBuffer = uiScaleHelper.DefaultBuffer;
      Vector2 vector2 = uiScaleHelper.ScaleVector2(Vector2.One * 35f);
      int numberPerRow = (int) Math.Floor(((double) this.customerFrame.VSCale.X - (double) defaultBuffer.X) / ((double) vector2.X + (double) defaultBuffer.X));
      List<DeadAnimal> deadAnimalQueue = this.reffactoryproduction.GetDeadAnimalQueue();
      this.animals.Clear();
      List<AnimalRenderDescriptor> animals = new List<AnimalRenderDescriptor>();
      if (deadAnimalQueue != null && deadAnimalQueue.Count > 0)
      {
        for (int index = 0; index < deadAnimalQueue.Count; ++index)
        {
          bool flag = index == 0 && this.reffactoryproduction.IsCurrentlyManufacturing();
          AnimalRenderDescriptor renderDescriptor = new AnimalRenderDescriptor(deadAnimalQueue[index].animalType, deadAnimalQueue[index].variant, deadAnimalQueue[index].headType, deadAnimalQueue[index].headVariant, _IsAvailable: (!flag), _IsFemale: deadAnimalQueue[index].IsAGirl, _cropType: deadAnimalQueue[index].cropType);
          animals.Add(renderDescriptor);
        }
      }
      this.animalGrid = new AnimalInFrameGrid(this.BaseScale, numberPerRow, defaultBuffer.X, defaultBuffer.Y, animals, numberPerRow * 3, UseNumberFrameWhenMaxFrames_NotButton: true, rawFrameSize: 35f, _DrawWithoutFrames: true);
      this.animalGrid.location.Y += this.miniHeading.GetTextHeight(true) + defaultBuffer.Y;
      this.animalGrid.location.X = defaultBuffer.X;
      this.animalGrid.location -= this.customerFrame.VSCale * 0.5f;
      this.lastStockCount = (float) this.GetStockCountIncludingCurrent();
      this.miniHeading.SetNewText(this.baseString + (object) this.reffactoryproduction.GetStockToDisplay());
    }

    private int GetStockCountIncludingCurrent()
    {
      int stockToDisplay = this.reffactoryproduction.GetStockToDisplay();
      if (this.reffactoryproduction.IsCurrentlyManufacturing())
        ++stockToDisplay;
      return stockToDisplay;
    }

    public void AddScroll(float maxHeight)
    {
    }

    public void UpdateDeadAnimalsInQueue(Player player, Vector2 offset)
    {
      if ((double) this.GetStockCountIncludingCurrent() == (double) this.lastStockCount)
        return;
      this.SetUp();
    }

    public void DrawDeadAnimalsInQueue(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      this.animalGrid.DrawAnimalInFrameGrid(offset, spriteBatch);
    }
  }
}
