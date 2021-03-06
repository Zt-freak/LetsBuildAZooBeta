// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Customer.LabelledCheckbox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_SummaryPopUps.People.Customer
{
  internal class LabelledCheckbox
  {
    public Vector2 location;
    private float basescale;
    private UIScaleHelper scalehelper;
    private Vector2 framescale;
    private ZGenericText text;
    private ZCheckBox checkbox;

    public bool IsTicked => this.checkbox.GetIsTicked();

    public LabelledCheckbox(string text_, bool textOnRight_, float basescale_, bool startChecked = false)
    {
      this.basescale = basescale_;
      this.scalehelper = new UIScaleHelper(this.basescale);
      Vector2 defaultBuffer = this.scalehelper.DefaultBuffer;
      this.text = new ZGenericText(text_, this.basescale);
      this.checkbox = new ZCheckBox(this.basescale);
      if (startChecked)
        this.checkbox.SetTicked(true);
      this.framescale = new Vector2();
      this.framescale.X = this.GetBoxSize().X + 0.5f * defaultBuffer.X + this.text.GetSize().X;
      this.framescale.Y = Math.Max(this.text.GetSize().Y, this.GetBoxSize().Y);
      this.checkbox.location = Vector2.Zero;
      this.text.vLocation = Vector2.Zero;
      float num = (float) (0.5 * (double) this.GetBoxSize().X + 0.5 * (double) defaultBuffer.X + 0.5 * (double) this.text.GetSize().X);
      if (textOnRight_)
        this.text.vLocation.X += num;
      else
        this.text.vLocation.X -= num;
    }

    public Vector2 GetBoxSize() => this.scalehelper.ScaleVector2(new Vector2((float) this.checkbox.checkBox.DrawRect.Width, (float) this.checkbox.checkBox.DrawRect.Height));

    public Vector2 GetSize() => this.framescale;

    public void ForceSetTickStatus(bool isTicked) => this.checkbox.SetTicked(isTicked);

    public bool UpdateLabelledCheckbox(Player player, Vector2 offset, float DeltaTime)
    {
      offset += this.location;
      if (!this.checkbox.UpdateCheckBox(player, offset))
        return false;
      this.checkbox.SetTicked(!this.checkbox.GetIsTicked());
      return true;
    }

    public void DrawLabelledCheckbox(SpriteBatch spritebatch, Vector2 offset)
    {
      offset += this.location;
      this.text.DrawZGenericText(offset, spritebatch);
      this.checkbox.DrawCheckBox(spritebatch, offset);
    }
  }
}
