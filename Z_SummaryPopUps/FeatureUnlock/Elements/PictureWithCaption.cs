// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.PictureWithCaption
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.GenericUI;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements
{
  internal class PictureWithCaption
  {
    public Vector2 location;
    private GameObject Picture;
    private SimpleTextHandler caption;
    private Vector2 size;

    public PictureWithCaption(float BaseScale, PictureType pictureType, bool IncludeCaption = true)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      this.Picture = new GameObject();
      this.Picture.scale = BaseScale;
      this.Picture.DrawRect = this.GetDrawRectangleForPicture(pictureType);
      this.Picture.SetDrawOriginToPoint(DrawOriginPosition.CentreTop);
      this.size = new Vector2((float) this.Picture.DrawRect.Width, (float) this.Picture.DrawRect.Height) * this.Picture.scale * Sengine.ScreenRatioUpwardsMultiplier;
      if (!IncludeCaption)
        return;
      string captionForThisPicture = FeatureUnlockDisplayData.GetCaptionForThisPicture(pictureType);
      if (string.IsNullOrEmpty(captionForThisPicture))
        return;
      this.size.Y += uiScaleHelper.ScaleY(2f);
      this.caption = new SimpleTextHandler(captionForThisPicture, this.size.X, true, BaseScale, AutoComplete: true);
      this.caption.SetAllColours(ColourData.Z_DarkTextGray);
      this.caption.Location.Y = this.size.Y;
      this.caption.Location.Y += this.caption.GetHeightOfOneLine() * 0.5f;
      this.size.Y += this.caption.GetHeightOfParagraph();
    }

    public Vector2 GetSize() => this.size;

    private Rectangle GetDrawRectangleForPicture(PictureType pictureType)
    {
      switch (pictureType)
      {
        case PictureType.DNABuilding:
          return new Rectangle(253, 1431, 158, 143);
        case PictureType.ResearchHub:
          return new Rectangle(412, 1449, 158, 123);
        case PictureType.HybridAnimal:
          return new Rectangle(259, 30, 109, 71);
        case PictureType.HyrbidAnimalDrawings:
          return new Rectangle(208, 203, 145, 44);
        case PictureType.ResearchHubDrawings:
          return new Rectangle(89, 198, 118, 49);
        case PictureType.LandForSale:
          return new Rectangle(571, 1449, 134, 123);
        case PictureType.MoralityPreview_Good:
          return new Rectangle(0, 1685, 210, 206);
        case PictureType.MoralityPreview_Bad:
          return new Rectangle(211, 1685, 210, 206);
        default:
          return Rectangle.Empty;
      }
    }

    public void DrawPictureWithCaption(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.Picture.Draw(spriteBatch, AssetContainer.UISheet, offset);
      if (this.caption == null)
        return;
      this.caption.DrawSimpleTextHandler(offset, 1f, spriteBatch);
    }
  }
}
