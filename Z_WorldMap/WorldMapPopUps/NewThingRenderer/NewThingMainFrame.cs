// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer.NewThingMainFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;
using TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer.Animals;
using TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer.TextBox;

namespace TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer
{
  internal class NewThingMainFrame
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private List<AnimalWithChromosone> animalRenderers;
    private NewThingTextBox textBox;

    public NewThingMainFrame(List<AnimalRenderDescriptor> animals, float BaseScale)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      float num1 = defaultYbuffer;
      this.animalRenderers = new List<AnimalWithChromosone>();
      float num2 = 0.0f;
      for (int index = 0; index < animals.Count; ++index)
      {
        AnimalWithChromosone animalWithChromosone = new AnimalWithChromosone(animals[index], BaseScale);
        Vector2 size = animalWithChromosone.GetSize();
        animalWithChromosone.location.Y = num1;
        animalWithChromosone.location.X = num2 + size.X * 0.5f;
        num2 += size.X;
        if (index != animals.Count - 1)
          num2 += (float) ((double) defaultXbuffer * 8.0 * (1.0 / (double) animals.Count));
        this.animalRenderers.Add(animalWithChromosone);
      }
      float num3 = num1 + (this.animalRenderers[0].GetSize().Y + defaultYbuffer);
      this.textBox = new NewThingTextBox(animals, BaseScale);
      this.textBox.location.Y = num3 + this.textBox.GetSize(false).Y * 0.5f + this.textBox.GetExtraHeightOffset();
      float y = num3 + (this.textBox.GetSize().Y + defaultYbuffer);
      this.customerFrame = new CustomerFrame(new Vector2(this.textBox.GetSize().X + defaultXbuffer * 2f, y), CustomerFrameColors.Brown, BaseScale);
      Vector2 vector2 = -this.customerFrame.VSCale * 0.5f;
      for (int index = 0; index < this.animalRenderers.Count; ++index)
      {
        this.animalRenderers[index].location.Y += vector2.Y;
        this.animalRenderers[index].location.X -= num2 * 0.5f;
      }
      this.textBox.location.Y += vector2.Y;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public bool UpdateNewThingMainFrame(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      for (int index = 0; index < this.animalRenderers.Count; ++index)
        this.animalRenderers[index].UpdateAnimalWithChromosone(DeltaTime);
      return this.textBox.UpdateNewThingTextBox(player, DeltaTime, offset);
    }

    public void DrawNewThingMainFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      for (int index = 0; index < this.animalRenderers.Count; ++index)
        this.animalRenderers[index].DrawAnimalWithChromosone(offset, spriteBatch);
      this.textBox.DrawNewThingTextBox(offset, spriteBatch);
    }
  }
}
