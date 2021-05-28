// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Animal._02Habitat.EnclosureCap.EnclosureCapacity
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;

namespace TinyZoo.Z_SummaryPopUps.People.Animal._02Habitat.EnclosureCap
{
  internal class EnclosureCapacity : GameObject
  {
    private PointerAndText pointerandtext;
    public Vector2 Location;

    public EnclosureCapacity(PrisonZone pz, float FloorSpace, float BaseScale)
    {
      this.DrawRect = new Rectangle(654, 591, 230, 10);
      this.scale = BaseScale;
      float aniamlsInThisPen = pz.GetSpaceRequiredByAniamlsInThisPen();
      float num1 = 2f;
      float num2 = 73f;
      float num3 = 79f;
      float num4 = 52f;
      float num5 = 22f;
      float num6 = 1f;
      float num7 = 3f;
      string Text;
      float num8;
      if ((double) aniamlsInThisPen >= (double) FloorSpace + (double) FloorSpace * (double) num6)
      {
        float num9 = num1 + num2 + num3 + num4;
        Text = "Inhumane";
        float num10 = (aniamlsInThisPen - (FloorSpace + FloorSpace * num6)) / (FloorSpace * num7);
        if ((double) num10 > 1.0)
          num10 = 1f;
        num8 = num9 + num5 * num10;
      }
      else if ((double) aniamlsInThisPen > (double) FloorSpace)
      {
        float num9 = num1 + num2 + num3;
        Text = "Uncomfortable";
        float num10 = (aniamlsInThisPen - FloorSpace) / (FloorSpace * num6);
        num8 = num9 + num4 * num10;
      }
      else
      {
        float num9 = 0.5f;
        if ((double) aniamlsInThisPen > (double) FloorSpace * (double) num9)
        {
          Text = "Acceptable";
          num8 = num1 + num2 + num3 * (float) ((double) aniamlsInThisPen * (1.0 - (double) num9) / ((double) FloorSpace - (double) aniamlsInThisPen * (double) num9));
        }
        else
        {
          Text = "Spacious";
          num8 = num1 + num2 * (aniamlsInThisPen / (FloorSpace * num9));
        }
      }
      float x = num8 * this.scale;
      this.pointerandtext = new PointerAndText(Text, BaseScale);
      this.pointerandtext.vLocation = new Vector2(x, this.GetBarSize().Y * 0.5f);
    }

    public Vector2 GetBarSize() => new Vector2((float) this.DrawRect.Width, (float) this.DrawRect.Height) * this.scale * Sengine.ScreenRatioUpwardsMultiplier;

    public Vector2 GetSize()
    {
      Vector2 barSize = this.GetBarSize();
      Vector2 vector2 = barSize;
      vector2.Y += this.pointerandtext.GetLineAndTextHeight() - barSize.Y;
      return vector2;
    }

    public Vector2 GetOffsetFromTopLeft() => new Vector2(0.0f, (float) (((double) this.pointerandtext.GetLineVScale().Y - (double) this.GetBarSize().Y) * 0.5));

    public void DrawEnclosureCapacity(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.Location;
      this.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
      this.pointerandtext.DrawPointerAndText(offset);
    }
  }
}
