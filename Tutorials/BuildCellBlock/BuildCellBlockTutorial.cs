// Decompiled with JetBrains decompiler
// Type: TinyZoo.Tutorials.BuildCellBlock.BuildCellBlockTutorial
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.GenericUI.OveWorldUI;
using TinyZoo.OverWorld;

namespace TinyZoo.Tutorials.BuildCellBlock
{
  internal class BuildCellBlockTutorial
  {
    private SmartCharacterBox characterbox;

    public BuildCellBlockTutorial(ref Arrow arrow, ref Vector2 ArrowLocation, Player player)
    {
      ArrowLocation = new Vector2(1024f - OWCategoryButton.SizeBTN, OverwoldMainButtons.textbuttons[3].Location.Y);
      arrow = new Arrow();
      this.characterbox = new SmartCharacterBox("You should consider building another cell block so you can easily store more prisoners.", AnimalType.Administrator);
    }

    public bool UpdateBuildCellBlockTutorial(Player player, ref float DeltaTime)
    {
      if (this.characterbox.UpdateSmartCharacterBox(DeltaTime, player))
      {
        player.inputmap.ClearAllInput(player);
        FeatureFlags.BlockTimer = false;
        return true;
      }
      player.inputmap.ClearAllInput(player);
      return false;
    }

    public void DrawBuildCellBlockTutorial() => this.characterbox.DrawSmartCharacterBox();
  }
}
