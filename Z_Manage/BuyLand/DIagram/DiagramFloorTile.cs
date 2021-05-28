// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Manage.BuyLand.DIagram.DiagramFloorTile
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_Manage.BuyLand.DIagram
{
  internal class DiagramFloorTile : GameObject
  {
    public DiagramFloorTile(TileTypeForDiagram tiletypeordiagram)
    {
      switch (tiletypeordiagram)
      {
        case TileTypeForDiagram.Owned:
          this.DrawRect = new Rectangle(876, 309, 16, 16);
          break;
        case TileTypeForDiagram.BuyLand:
          this.DrawRect = new Rectangle(894, 309, 16, 16);
          break;
        case TileTypeForDiagram.Unpurchased:
          this.DrawRect = new Rectangle(912, 309, 16, 16);
          break;
      }
      this.SetDrawOriginToCentre();
      this.scale = 2f;
    }

    public void DrawDiagramFloorTile(Vector2 Offset) => this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset);
  }
}
