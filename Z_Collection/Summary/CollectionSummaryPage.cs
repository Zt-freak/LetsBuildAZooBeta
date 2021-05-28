// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Collection.Summary.CollectionSummaryPage
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_Collection.Summary
{
  internal class CollectionSummaryPage
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private CollectionSummaryTextRows textRows;

    public CollectionSummaryPage(Player player, float BaseScale, Vector2 forcedSize)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      double defaultYbuffer = (double) uiScaleHelper.GetDefaultYBuffer();
      this.customerFrame = new CustomerFrame(forcedSize, CustomerFrameColors.Brown, BaseScale);
      Vector2 vector2 = -forcedSize * 0.5f;
      float y = (float) defaultYbuffer;
      float x = defaultXbuffer;
      this.textRows = new CollectionSummaryTextRows(player, BaseScale, forcedSize.X);
      this.textRows.location += vector2 + new Vector2(x, y);
    }

    public void UpdateCollectionSummaryFrame()
    {
    }

    public void DrawCollectionSummaryPage(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.textRows.DrawCollectionSummaryTextRows(offset, spriteBatch);
    }
  }
}
