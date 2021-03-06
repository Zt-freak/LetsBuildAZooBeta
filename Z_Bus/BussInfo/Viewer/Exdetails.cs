// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Bus.BussInfo.Viewer.Exdetails
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.GenericUI;

namespace TinyZoo.Z_Bus.BussInfo.Viewer
{
  internal class Exdetails : GameObject
  {
    private string Heading;
    private bool UseBigFont;
    private SimpleTextHandler simpletext;

    public Exdetails(string WriteThis, float BaseScale, bool _UseBigFont = false, float ScreenWidth = 0.5f)
    {
      this.UseBigFont = _UseBigFont;
      this.Heading = WriteThis;
      this.scale = BaseScale;
      this.SetAllColours(ColourData.Z_Cream);
      this.simpletext = new SimpleTextHandler(WriteThis, false, ScreenWidth, BaseScale, _UseBigFont, false);
      this.simpletext.SetAllColours(ColourData.Z_Cream);
      this.simpletext.AutoCompleteParagraph();
    }

    public Vector2 GetSize() => this.simpletext.GetSize();

    public void SetForBrownPanel(Vector2 VSCaleForPanel, float BaseScale)
    {
      this.vLocation = VSCaleForPanel * -0.5f;
      this.vLocation.X += 10f * BaseScale;
      this.vLocation.Y += 40f * BaseScale * Sengine.ScreenRatioUpwardsMultiplier.Y;
    }

    public void DrawExdetails(Vector2 Offset, SpriteBatch spritebatch)
    {
      if (!this.UseBigFont)
        this.simpletext.DrawSimpleTextHandler(Offset + this.vLocation, 1f, spritebatch);
      else
        this.simpletext.DrawSimpleTextHandler(Offset + this.vLocation, 1f, spritebatch);
    }
  }
}
