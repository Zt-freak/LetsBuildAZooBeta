// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.Specific.MoralityChoicesLayout
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GenericUI;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.Specific.MoralityElements;

namespace TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.Specific
{
  internal class MoralityChoicesLayout
  {
    public Vector2 location;
    private Vector2 size;
    private MoralityLockArrowWithImage diagram;
    private ZGenericText header;
    private SimpleTextHandler para;

    public MoralityChoicesLayout(float BaseScale, FeatureUnlockDisplayType unlockType)
    {
      Vector2 defaultBuffer = new UIScaleHelper(BaseScale).DefaultBuffer;
      this.diagram = new MoralityLockArrowWithImage(BaseScale);
      double x = (double) this.diagram.GetSize().X;
      this.header = new ZGenericText(FeatureUnlockDisplayData.GetNewsHeaderForThis(unlockType), BaseScale, _UseRoundaboutHugeFont: true);
      this.header.SetAllColours(ColourData.Z_DarkTextGray);
      double num = (double) defaultBuffer.X * 2.0;
      float width_ = (float) (x - num);
      this.para = new SimpleTextHandler(FeatureUnlockDisplayData.GetBodyParagraphForNews(unlockType), width_, true, BaseScale, AutoComplete: true);
      this.para.SetAllColours(ColourData.Z_DarkTextGray);
      this.size = this.diagram.GetSize();
      this.size.Y += defaultBuffer.Y * 3f;
      this.header.vLocation.Y = this.size.Y;
      this.header.vLocation.Y += this.header.GetSize().Y * 0.5f;
      this.size.Y += this.header.GetSize().Y;
      this.para.Location.Y = this.size.Y;
      this.para.Location.Y += this.para.GetHeightOfOneLine() * 0.5f;
      this.size.Y += this.para.GetHeightOfParagraph();
    }

    public Vector2 GetSize() => this.size;

    public void DrawMorality_PaintedAnimalLayout(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.diagram.DrawMoralityLockArrowWithImage(offset, spriteBatch);
      this.header.DrawZGenericText(offset, spriteBatch);
      this.para.DrawSimpleTextHandler(offset, 1f, spriteBatch);
    }
  }
}
