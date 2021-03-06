// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.TopBar.Elements.DayOfWeek.DayPopOut
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GenericUI;
using TinyZoo.Z_HUD.TopBar.MoralityPopUp;

namespace TinyZoo.Z_HUD.TopBar.Elements.DayOfWeek
{
  internal class DayPopOut : GenericTopBarPopOutFrame
  {
    private SimpleTextHandler text;

    public DayPopOut(float BaseScale)
      : base(BaseScale)
    {
      this.text = new SimpleTextHandler("Each week starts on Monday.", this.scaleHelper.ScaleX(180f), true, BaseScale, AutoComplete: true);
      this.text.SetAllColours(ColourData.Z_Cream);
      Vector2 vector2 = Vector2.Zero + this.scaleHelper.DefaultBuffer;
      this.text.Location.Y = vector2.Y;
      this.text.Location.Y += this.text.GetHeightOfOneLine() * 0.5f;
      Vector2 _frameSize = vector2 + this.text.GetSize(true) + this.scaleHelper.DefaultBuffer;
      this.FinalizeSize(_frameSize);
      this.text.Location.Y += (-_frameSize * 0.5f).Y;
    }

    public bool UpdateDayPopOut(Player player, float DeltaTime, Vector2 offset) => this.UpdatePopOutFrame(player, DeltaTime, ref offset);

    public void DrawDayPopOut(Vector2 offset, SpriteBatch spriteBatch)
    {
      this.DrawPopOutFrame(ref offset, spriteBatch);
      this.text.DrawSimpleTextHandler(offset, 1f, spriteBatch);
    }
  }
}
