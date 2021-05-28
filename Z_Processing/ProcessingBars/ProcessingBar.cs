// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Processing.ProcessingBars.ProcessingBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.GenericUI;
using TinyZoo.Z_StoreRoom;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_Processing.ProcessingBars
{
  internal class ProcessingBar
  {
    private CustomerFrame Cframe;
    private SimpleTextBox textbox;
    private MiniHeading miniHeading;

    public ProcessingBar(float TargetWidth, float BaseScale, AnimalFoodType animalfoodtype)
    {
      this.Cframe = new CustomerFrame(new Vector2(TargetWidth * BaseScale, 80f * BaseScale), BaseScale: BaseScale);
      this.textbox = new SimpleTextBox("Converting deceased animals into ", 200f * BaseScale, false, BaseScale);
    }

    public void UpdateProcessingBar()
    {
    }

    public void DrawProcessingBar()
    {
    }
  }
}
