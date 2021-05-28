// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.StoreRoom.AnimalStuff.AnimalNameAndCount
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_Animal_Data;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_HUD.StoreRoom.AnimalStuff
{
  internal class AnimalNameAndCount
  {
    public Vector2 vLocation;
    private ZGenericText Text;

    public AnimalNameAndCount(
      AnimalType animal,
      int TotalOfThese,
      float BaseScale,
      AnimalType AnimalHead,
      PrisonZone prison = null)
    {
      this.Text = new ZGenericText(prison == null ? (AnimalHead == AnimalType.None ? (object) AnimalData.GetAnimalName(animal) : (object) HybridNames.GetAnimalCombinedName(animal, AnimalHead)).ToString() + " x" + (object) TotalOfThese : "Enclosure #" + (object) prison.Cell_UID, BaseScale, false);
      this.Text.vLocation.Y -= this.Text.GetSize().Y * 0.5f;
    }

    public void SetAllDead() => this.Text.textToWrite = "There are no animals here.";

    public void DrawAnimalNameAndCount(Vector2 Offset, SpriteBatch spritebatch)
    {
      Offset += this.vLocation;
      this.Text.DrawZGenericText(Offset, spritebatch);
    }
  }
}
