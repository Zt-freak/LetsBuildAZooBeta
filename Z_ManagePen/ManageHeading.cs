// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManagePen.ManageHeading
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_ManagePen
{
  internal class ManageHeading : GameObject
  {
    private string Heading;

    public ManageHeading(string TXT, Vector2 VSCALE)
    {
      this.vLocation.X = VSCALE.X * -0.5f;
      this.vLocation.X += 10f;
      this.vLocation.Y += 21f;
      this.SetAllColours(ColourData.Z_Cream);
      this.Heading = TXT;
      this.scale = 0.7f;
    }

    public void UpdateManageHeading()
    {
    }

    public void DrawManageHeading(Vector2 TopCentre) => TextFunctions.DrawTextWithDropShadow(this.Heading, this.scale, this.vLocation + TopCentre, this.GetColour(), 1f, AssetContainer.roundaboutFont, AssetContainer.pointspritebatchTop05, true);
  }
}
