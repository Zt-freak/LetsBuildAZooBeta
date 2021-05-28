// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HeatMaps.BuildingHygieneDisplay
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_HeatMaps
{
  internal class BuildingHygieneDisplay
  {
    public Vector2 worldSpaceLocation;
    private ZGenericText shopstatus;
    private ZGenericText hygieneLevel;
    private Vector2 textOffset;

    public BuildingHygieneDisplay()
    {
      this.shopstatus = new ZGenericText("Status: Open", 1f, _UseOnePointFiveFont: true);
      this.shopstatus.SetAllColours(Color.Black.ToVector3());
      this.hygieneLevel = new ZGenericText("Hygiene Level: ???", 1f, _UseOnePointFiveFont: true);
      this.hygieneLevel.SetAllColours(Color.Black.ToVector3());
      this.textOffset.Y = this.shopstatus.GetSize().Y;
    }

    public void UpdateFoodDrinkBuildingDisplay()
    {
    }

    public void DrawFoodDrinkBuildingDisplay(SpriteBatch spriteBatch)
    {
      Vector2 screenSpace = RenderMath.TranslateWorldSpaceToScreenSpace(this.worldSpaceLocation);
      this.shopstatus.scale = 1f;
      this.shopstatus.scale = Sengine.WorldOriginandScale.Z * 0.5f;
      this.hygieneLevel.scale = this.shopstatus.scale;
      this.shopstatus.DrawZGenericText(screenSpace, spriteBatch);
      this.hygieneLevel.DrawZGenericText(screenSpace + this.textOffset * this.shopstatus.scale * Sengine.ScreenRatioUpwardsMultiplier.Y, spriteBatch);
    }
  }
}
