// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames.CampaignSummaryFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames
{
  internal class CampaignSummaryFrame
  {
    public Vector2 location;
    private MiniHeading miniHeading;
    private CustomerFrame customerFrame;
    private CampaignReachBar estimatedReachBar;
    private ZGenericText TotalSpentSoFar;
    private string totalSpentBaseString;
    private SimpleTextHandler costHeader;
    private ZGenericText costText;
    private string costString;
    private OpenPositions TEMPOPENPOSITIONS;

    public CampaignSummaryFrame(
      OpenPositions _TEMPOPENPOSITIONS,
      float forceWidth,
      float BaseScale)
    {
      this.TEMPOPENPOSITIONS = _TEMPOPENPOSITIONS;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      double defaultXbuffer = (double) uiScaleHelper.GetDefaultXBuffer();
      Vector2 vector2_1 = Vector2.One * 10f;
      float num1 = 0.0f;
      this.miniHeading = new MiniHeading(Vector2.Zero, "Campaign Summary", 1f, BaseScale);
      float num2 = num1 + (float) ((double) this.miniHeading.GetTextHeight(true) + (double) uiScaleHelper.ScaleY(vector2_1.Y) + (double) defaultYbuffer * 0.5);
      this.costHeader = new SimpleTextHandler("Total Cost~Per Day:", true, 0.2f, BaseScale);
      this.costHeader.AutoCompleteParagraph();
      float heightOfParagraph = this.costHeader.GetHeightOfParagraph();
      this.costHeader.SetAllColours(ColourData.Z_Cream);
      this.costHeader.Location.X = forceWidth * 0.85f;
      this.costHeader.Location.Y = num2;
      this.costHeader.Location.Y -= this.costHeader.GetHeightOfOneLine() * 0.5f;
      this.costString = "$";
      this.costText = new ZGenericText(this.costString + (object) 0, BaseScale);
      this.costText.vLocation = this.costHeader.Location;
      this.costText.vLocation.Y += heightOfParagraph;
      this.estimatedReachBar = new CampaignReachBar(this.TEMPOPENPOSITIONS, BaseScale);
      Vector2 size1 = this.estimatedReachBar.GetSize();
      this.estimatedReachBar.location.Y = num2;
      this.estimatedReachBar.location.X = forceWidth * 0.5f;
      this.estimatedReachBar.location.Y += (float) ((double) size1.Y * 0.5 + (double) this.estimatedReachBar.GetExtraTextOffsetFromTop() * 0.5);
      float num3 = num2 + size1.Y + defaultYbuffer;
      this.totalSpentBaseString = "Total Spent: $";
      this.TotalSpentSoFar = new ZGenericText(this.totalSpentBaseString + (object) this.TEMPOPENPOSITIONS.TotalAmountSpent, BaseScale);
      Vector2 size2 = this.TotalSpentSoFar.GetSize();
      this.TotalSpentSoFar.vLocation.Y = num3 + size2.Y * 0.5f;
      this.TotalSpentSoFar.vLocation.X = forceWidth * 0.5f;
      float y = num3 + size2.Y + defaultYbuffer;
      this.customerFrame = new CustomerFrame(new Vector2(forceWidth, y), BaseScale: BaseScale);
      this.miniHeading.SetTextPosition(this.customerFrame.VSCale, vector2_1.X, vector2_1.Y);
      Vector2 vector2_2 = -this.customerFrame.VSCale * 0.5f;
      this.costHeader.Location += vector2_2;
      ZGenericText costText = this.costText;
      costText.vLocation = costText.vLocation + vector2_2;
      this.estimatedReachBar.location += vector2_2;
      ZGenericText totalSpentSoFar = this.TotalSpentSoFar;
      totalSpentSoFar.vLocation = totalSpentSoFar.vLocation + vector2_2;
      this.ReflectNewData();
    }

    private void SetActive(bool isPanelActive)
    {
      if (!isPanelActive)
      {
        this.customerFrame.SetInactiveGrey();
        this.estimatedReachBar.SetActive(isPanelActive);
        Vector3 vector3 = Color.LightGray.ToVector3();
        this.miniHeading.SetAllColours(vector3);
        this.TotalSpentSoFar.SetAllColours(vector3);
        this.costHeader.SetAllColours(vector3);
        this.costText.SetAllColours(vector3);
      }
      else
      {
        this.customerFrame.ResetColor();
        this.estimatedReachBar.SetActive(isPanelActive);
        Vector3 zCream = ColourData.Z_Cream;
        this.miniHeading.SetAllColours(zCream);
        this.TotalSpentSoFar.SetAllColours(zCream);
        this.costHeader.SetAllColours(zCream);
        this.costText.SetAllColours(zCream);
      }
    }

    public void ReflectNewData()
    {
      this.SetActive(this.TEMPOPENPOSITIONS.NumberOfPositionsOpened > 0);
      this.TotalSpentSoFar.textToWrite = this.totalSpentBaseString + (object) this.TEMPOPENPOSITIONS.TotalAmountSpent;
      this.costText.textToWrite = this.costString + (object) this.TEMPOPENPOSITIONS.GetCostPerDay();
      this.estimatedReachBar.SetNewNumbers(this.TEMPOPENPOSITIONS);
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public void UpdateCampaignSummaryFrame(Player player, float DeltaTIme, Vector2 offset) => offset += this.location;

    public void DrawCampaignSummaryFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      this.costHeader.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      this.costText.DrawZGenericText(offset, spriteBatch);
      this.estimatedReachBar.DrawCampaignReachBar(offset, spriteBatch);
      this.TotalSpentSoFar.DrawZGenericText(offset, spriteBatch);
    }
  }
}
