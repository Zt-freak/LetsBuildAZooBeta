// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Processing.MeatProcessingBar.ProcessingBarManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.PlayerDir.Processing;
using TinyZoo.Z_Processing.ProcessingBars;
using TinyZoo.Z_Processing.Summary;

namespace TinyZoo.Z_Processing.MeatProcessingBar
{
  internal class ProcessingBarManager
  {
    private List<ProcessingBar> processingbars;
    private ProcessingSummary processingsummary;

    public ProcessingBarManager(
      ProcessingBuilding processingbuilding,
      float BaseScale,
      int BuildingDisplayIndex)
    {
      this.processingbars = new List<ProcessingBar>();
      PcessedMeatData.GetConvertableAnimalFoodTypesInDisplayOrder();
      this.processingsummary = new ProcessingSummary(600f, BaseScale, BuildingDisplayIndex, processingbuilding);
      this.processingsummary.Location = new Vector2(512f, BaseScale * 200f);
    }

    public void UpdateProcessingBarManager(Player player, float DeltaTime)
    {
    }

    public void DrawProcessingBarManager(Vector2 Offset) => this.processingsummary.DrawProcessingSummary(Offset);
  }
}
