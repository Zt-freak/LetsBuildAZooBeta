// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.Generic.Summary.InfoRow.ThisBuildingSummary
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Tile_Data;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_BuildingInfo.Generic.Summary.InfoRow
{
  internal class ThisBuildingSummary
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private List<SummaryInfoRow> rows;

    public ThisBuildingSummary(ShopEntry shopEntry, float BaseScale, float forceThisWidth = -1f)
    {
      Vector2 defaultBuffer = new UIScaleHelper(BaseScale).DefaultBuffer;
      this.rows = new List<SummaryInfoRow>();
      List<SummaryInfoType> summaryInfoTypeList = new List<SummaryInfoType>();
      if (TileData.IsAnIncinerator(shopEntry.tiletype))
      {
        summaryInfoTypeList.Add(SummaryInfoType.ValueEarned);
        summaryInfoTypeList.Add(SummaryInfoType.AnimalsBurnt);
        summaryInfoTypeList.Add(SummaryInfoType.OperationWorkload);
        summaryInfoTypeList.Add(SummaryInfoType.FertilizerGenerated);
      }
      else if (TileData.IsAMeatProcessingPlant(shopEntry.tiletype) || TileData.IsAVegetableProcessingPlant(shopEntry.tiletype))
      {
        summaryInfoTypeList.Add(SummaryInfoType.ValueEarned);
        summaryInfoTypeList.Add(SummaryInfoType.AnimalsOrCropsProcessed);
        summaryInfoTypeList.Add(SummaryInfoType.ProductsProduced);
        summaryInfoTypeList.Add(SummaryInfoType.OperationWorkload);
      }
      else if (TileData.IsAFactory(shopEntry.tiletype))
      {
        summaryInfoTypeList.Add(SummaryInfoType.ValueEarned);
        summaryInfoTypeList.Add(SummaryInfoType.ProductsProduced);
        summaryInfoTypeList.Add(SummaryInfoType.OperationWorkload);
      }
      else if (TileData.IsAWarehouse(shopEntry.tiletype))
      {
        summaryInfoTypeList.Add(SummaryInfoType.ValueEarned);
        summaryInfoTypeList.Add(SummaryInfoType.ProductsSold);
      }
      float num = 0.0f;
      this.customerFrame = new CustomerFrame(Vector2.Zero, CustomerFrameColors.DarkBrown, BaseScale);
      this.customerFrame.AddMiniHeading("This Building");
      float y = num + this.customerFrame.GetMiniHeadingHeight() + defaultBuffer.Y;
      for (int index = 0; index < summaryInfoTypeList.Count; ++index)
      {
        SummaryInfoRow summaryInfoRow = new SummaryInfoRow(summaryInfoTypeList[index], shopEntry.ShopUID, shopEntry.tiletype, BaseScale, forceThisWidth);
        summaryInfoRow.location = new Vector2(defaultBuffer.X, y);
        summaryInfoRow.location.Y += summaryInfoRow.GetSize().Y * 0.5f;
        y = y + summaryInfoRow.GetSize().Y + defaultBuffer.Y;
        this.rows.Add(summaryInfoRow);
      }
      this.customerFrame.Resize(new Vector2(forceThisWidth, y));
      Vector2 vector2 = -this.customerFrame.VSCale * 0.5f;
      for (int index = 0; index < this.rows.Count; ++index)
        this.rows[index].location += vector2;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public SummaryInfoType UpdateThisBuildingSummary(
      Player player,
      float DeltaTime,
      Vector2 offset)
    {
      offset += this.location;
      for (int index = 0; index < this.rows.Count; ++index)
      {
        if (this.rows[index].UpdateSummaryInfoRow(player, DeltaTime, offset))
          return this.rows[index].refInfoType;
      }
      return SummaryInfoType.Count;
    }

    public void DrawThisBuildingSummary(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      for (int index = 0; index < this.rows.Count; ++index)
        this.rows[index].DrawSummaryInfoRow(offset, spriteBatch);
    }
  }
}
