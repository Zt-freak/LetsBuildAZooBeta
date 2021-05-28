// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_EditZone.EditUI.NumericSummaryText
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_EditZone.EditUI
{
  internal class NumericSummaryText : GameObject
  {
    private string texttowrite;

    public NumericSummaryText(float BaseScale, string _texttowrite)
    {
      this.texttowrite = _texttowrite;
      this.scale = BaseScale;
    }

    public void SetString(string NewText) => this.texttowrite = NewText;

    public void DrawNumericSummaryText(Vector2 Offset, SpriteBatch spritebatch) => TextFunctions.DrawTextWithDropShadow(this.texttowrite, this.scale, this.vLocation + Offset, this.GetColour(), this.fAlpha, AssetContainer.SpringFontX1AndHalf, spritebatch, false, true);
  }
}
