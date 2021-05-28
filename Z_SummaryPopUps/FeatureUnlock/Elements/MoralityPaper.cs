// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.MoralityPaper
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements
{
  internal class MoralityPaper
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private NewsContent newsContent;

    public MoralityPaper(float BaseScale, FeatureUnlockDisplayType unlockType)
    {
      Vector2 defaultBuffer = new UIScaleHelper(BaseScale).DefaultBuffer;
      this.newsContent = new NewsContent(BaseScale, unlockType, -1f);
      Vector2 zero = Vector2.Zero;
      Vector2 vector2 = defaultBuffer + defaultBuffer * 2f;
      this.newsContent.location.Y = vector2.Y;
      vector2.Y += this.newsContent.GetSize().Y;
      vector2.Y += defaultBuffer.Y;
      vector2.X = this.newsContent.GetSize().X;
      vector2.X += defaultBuffer.X * 3f;
      this.customerFrame = new CustomerFrame(vector2 + defaultBuffer * 2f, CustomerFrameColors.Paper, BaseScale);
      this.newsContent.location.Y += (-this.customerFrame.VSCale * 0.5f).Y;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public void UpdateMoralityPaper()
    {
    }

    public void DrawMoralityPaper(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.newsContent.DrawNewsContent(offset, spriteBatch);
    }
  }
}
