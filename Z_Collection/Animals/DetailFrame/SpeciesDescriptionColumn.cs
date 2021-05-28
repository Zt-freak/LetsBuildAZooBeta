// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Collection.Animals.DetailFrame.SpeciesDescriptionColumn
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.GenericUI;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_Collection.Animals.DetailFrame
{
  internal class SpeciesDescriptionColumn
  {
    public Vector2 location;
    private ZGenericText animalName;
    private SimpleTextHandler animalDesc;
    private ZGenericText firstDiscovered;
    private ZGenericText lastDiscovered;

    public SpeciesDescriptionColumn(
      AnimalType animalType,
      Player player,
      float BaseScale,
      float maxWidth,
      bool IsUnlocked)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float num1 = uiScaleHelper.GetDefaultYBuffer() * 0.5f;
      float num2 = 0.0f;
      this.animalName = new ZGenericText(EnemyData.GetEnemyTypeName(animalType), BaseScale, false, _UseOnePointFiveFont: true);
      float num3 = num2 + this.animalName.GetSize().Y + num1 * 0.5f;
      string TextToWrite = "You have yet to encounter this animal. Trade animals with other zoos to find more animals.";
      if (IsUnlocked)
        TextToWrite = "This will be a description describing the animal...";
      this.animalDesc = new SimpleTextHandler(TextToWrite, false, (float) ((double) maxWidth / 1024.0 * 0.899999976158142), BaseScale, false, true);
      this.animalDesc.SetAllColours(ColourData.Z_Cream);
      this.animalDesc.Location.Y = num3;
      float num4 = num3 + uiScaleHelper.ScaleY(45f);
      if (!IsUnlocked)
        return;
      int firstVariantIndex = -1;
      int firstVariant_dayFound = -1;
      int lastVariantIndex = -1;
      int lastVariant_dayFound = -1;
      player.Stats.GetFirstAndLastVariantFoundDates(animalType, out firstVariantIndex, out firstVariant_dayFound, out lastVariantIndex, out lastVariant_dayFound);
      this.firstDiscovered = new ZGenericText(string.Format("First Discovered: Day {0}", (object) firstVariant_dayFound), BaseScale, false);
      this.firstDiscovered.vLocation.Y = num4;
      float num5 = num4 + this.firstDiscovered.GetSize().Y;
      if (lastVariantIndex == firstVariantIndex)
        return;
      this.lastDiscovered = new ZGenericText(string.Format("Last Discovered Variant: Day {0}", (object) lastVariant_dayFound), BaseScale, false);
      this.lastDiscovered.vLocation.Y = num5;
    }

    public void DrawSpeciesDescriptionColumn(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.animalName.DrawZGenericText(offset, spriteBatch);
      this.animalDesc.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      if (this.firstDiscovered != null)
        this.firstDiscovered.DrawZGenericText(offset, spriteBatch);
      if (this.lastDiscovered == null)
        return;
      this.lastDiscovered.DrawZGenericText(offset, spriteBatch);
    }
  }
}
