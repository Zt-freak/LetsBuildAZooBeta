// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames.PostingInfoFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.Z_BalanceSystems.Employees;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames
{
  internal class PostingInfoFrame
  {
    public Vector2 location;
    private MiniHeading miniHeading;
    private CustomerFrame customerFrame;
    private SimpleTextHandler text;
    private ZCheckBox checkBox;
    private ZGenericText costHeader;
    private ZGenericText costNumberText;
    private string costNumberBaseString;
    private RecruitmentInfoIcon icon;
    private JobPostingModifiers refInfoType;
    private bool isCheckBoxActive;
    private OpenPositions TEMPOPENPOSITIONS;

    public PostingInfoFrame(
      JobPostingModifiers infoType,
      OpenPositions _TEMPOPENPOSITIONS,
      float forceWidth,
      float BaseScale)
    {
      this.refInfoType = infoType;
      this.TEMPOPENPOSITIONS = _TEMPOPENPOSITIONS;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      Vector2 vector2_1 = Vector2.One * 10f;
      float num1 = 0.0f;
      float num2 = 0.0f + uiScaleHelper.ScaleX(vector2_1.X);
      string text = "";
      string TextToWrite = "";
      bool flag = false;
      switch (infoType)
      {
        case JobPostingModifiers.AdminCost:
          text = "Admin Cost";
          TextToWrite = "Opening a job position will require a basic admin cost.";
          break;
        case JobPostingModifiers.SocialMedia:
          text = "Social Media";
          TextToWrite = "Post your job openings on social media to spread the word!";
          flag = true;
          break;
        case JobPostingModifiers.JobPortal:
          text = "Job Portal";
          TextToWrite = "Advertise your job openings on job portals and trade magazines to gain an even wider reach!";
          flag = true;
          break;
      }
      this.miniHeading = new MiniHeading(Vector2.Zero, text, 1f, BaseScale);
      float num3 = num1 + (float) ((double) this.miniHeading.GetTextHeight(true) + (double) uiScaleHelper.ScaleY(vector2_1.Y) + (double) defaultYbuffer * 0.5);
      this.icon = new RecruitmentInfoIcon(this.refInfoType, BaseScale);
      this.icon.SetDrawOriginToPoint(DrawOriginPosition.CentreLeft);
      this.icon.vLocation.X = num2;
      float num4 = num2 + this.icon.GetSize().X + defaultXbuffer;
      float PercentagePfScreenWidth = (float) ((double) forceWidth / 1024.0 * 0.649999976158142);
      this.text = new SimpleTextHandler(TextToWrite, false, PercentagePfScreenWidth, BaseScale, false, false);
      float heightOfParagraph = this.text.GetHeightOfParagraph();
      this.text.AutoCompleteParagraph();
      this.text.Location.X = num4;
      this.text.Location.Y = num3;
      this.text.SetAllColours(ColourData.Z_Cream);
      float num5 = num3 + heightOfParagraph;
      float num6 = num4 + PercentagePfScreenWidth * 1024f;
      this.icon.vLocation.Y += this.text.Location.Y + heightOfParagraph * 0.5f;
      this.costNumberBaseString = "$";
      this.costHeader = new ZGenericText("Cost:", BaseScale);
      this.costHeader.vLocation.Y = num5;
      this.costHeader.vLocation.Y += this.costHeader.GetSize().Y * 0.5f;
      this.costHeader.vLocation.Y -= this.text.GetHeightOfOneLine() * 2f;
      this.costHeader.vLocation.X = forceWidth * 0.85f;
      this.costNumberText = new ZGenericText(this.costNumberBaseString + (object) JobApplicants_Calculator.GetCostOfThisPerDay(this.refInfoType), BaseScale);
      this.costNumberText.vLocation = this.costHeader.vLocation;
      this.costNumberText.vLocation.Y += this.costHeader.GetSize().Y;
      if (flag)
      {
        this.checkBox = new ZCheckBox(BaseScale);
        Vector2 size = this.checkBox.GetSize();
        this.checkBox.location.X = this.costHeader.vLocation.X + this.costHeader.GetSize().X * 0.5f;
        this.checkBox.location.X += size.X * 0.5f;
        this.checkBox.location.X += defaultXbuffer * 0.5f;
        this.checkBox.location.Y = (float) (((double) this.costNumberText.vLocation.Y + (double) this.costHeader.vLocation.Y) * 0.5);
      }
      float y = num5 + defaultYbuffer;
      this.customerFrame = new CustomerFrame(new Vector2(forceWidth, y), BaseScale: BaseScale);
      this.miniHeading.SetTextPosition(this.customerFrame.VSCale, vector2_1.X, vector2_1.Y);
      Vector2 vector2_2 = -this.customerFrame.VSCale * 0.5f;
      RecruitmentInfoIcon icon = this.icon;
      icon.vLocation = icon.vLocation + vector2_2;
      this.text.Location += vector2_2;
      if (this.checkBox != null)
        this.checkBox.location += vector2_2;
      ZGenericText costHeader = this.costHeader;
      costHeader.vLocation = costHeader.vLocation + vector2_2;
      ZGenericText costNumberText = this.costNumberText;
      costNumberText.vLocation = costNumberText.vLocation + vector2_2;
      this.ReflectNewData();
    }

    private void SetActive(bool isActive, bool _checkBoxIsActive = false)
    {
      this.isCheckBoxActive = _checkBoxIsActive;
      if (!isActive)
      {
        this.customerFrame.SetInactiveGrey();
        Vector3 vector3 = Color.LightGray.ToVector3();
        this.miniHeading.SetAllColours(vector3);
        this.text.SetAllColours(vector3);
        this.costNumberText.SetAllColours(vector3);
        this.costHeader.SetAllColours(vector3);
      }
      else
      {
        this.customerFrame.ResetColor();
        Vector3 zCream = ColourData.Z_Cream;
        this.miniHeading.SetAllColours(zCream);
        this.text.SetAllColours(zCream);
        this.costNumberText.SetAllColours(zCream);
        this.costHeader.SetAllColours(zCream);
      }
      if (this.checkBox == null)
        return;
      if (this.isCheckBoxActive)
      {
        ZCheckBox checkBox = this.checkBox;
        Color white = Color.White;
        Vector3 vector3_1 = white.ToVector3();
        checkBox.SetColorTint(vector3_1);
        RecruitmentInfoIcon icon = this.icon;
        white = Color.White;
        Vector3 vector3_2 = white.ToVector3();
        icon.SetAllColours(vector3_2);
      }
      else
      {
        ZCheckBox checkBox = this.checkBox;
        Color darkGray = Color.DarkGray;
        Vector3 vector3_1 = darkGray.ToVector3();
        checkBox.SetColorTint(vector3_1);
        RecruitmentInfoIcon icon = this.icon;
        darkGray = Color.DarkGray;
        Vector3 vector3_2 = darkGray.ToVector3();
        icon.SetAllColours(vector3_2);
      }
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public void ReflectNewData()
    {
      switch (this.refInfoType)
      {
        case JobPostingModifiers.AdminCost:
          this.SetActive(this.TEMPOPENPOSITIONS.NumberOfPositionsOpened > 0);
          break;
        case JobPostingModifiers.SocialMedia:
          this.SetActive(this.TEMPOPENPOSITIONS.IsSocialMediaEnabled, this.TEMPOPENPOSITIONS.NumberOfPositionsOpened > 0);
          this.checkBox.SetTicked(this.TEMPOPENPOSITIONS.IsSocialMediaEnabled);
          break;
        case JobPostingModifiers.JobPortal:
          this.SetActive(this.TEMPOPENPOSITIONS.IsJobPortalEnabled, this.TEMPOPENPOSITIONS.NumberOfPositionsOpened > 0);
          this.checkBox.SetTicked(this.TEMPOPENPOSITIONS.IsJobPortalEnabled);
          break;
      }
      string str = this.costNumberBaseString + (object) JobApplicants_Calculator.GetCostOfThisPerDay(this.refInfoType);
      if (this.TEMPOPENPOSITIONS.NumberOfPositionsOpened > 1)
        str = str + "x" + (object) this.TEMPOPENPOSITIONS.NumberOfPositionsOpened;
      this.costNumberText.textToWrite = str;
    }

    public bool UpdatePostingInfoFrame(Player player, float DeltaTIme, Vector2 offset)
    {
      offset += this.location;
      if (this.checkBox == null || !this.isCheckBoxActive || !this.checkBox.UpdateCheckBox(player, offset))
        return false;
      switch (this.refInfoType)
      {
        case JobPostingModifiers.SocialMedia:
          this.TEMPOPENPOSITIONS.IsSocialMediaEnabled = !this.checkBox.GetIsTicked();
          break;
        case JobPostingModifiers.JobPortal:
          this.TEMPOPENPOSITIONS.IsJobPortalEnabled = !this.checkBox.GetIsTicked();
          break;
      }
      return true;
    }

    public void DrawPostingInfoFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      this.icon.DrawRecruitmentInfoIcon(offset, spriteBatch);
      this.text.DrawSimpleTextHandler(offset, 1f, spriteBatch);
      if (this.checkBox != null)
        this.checkBox.DrawCheckBox(spriteBatch, offset);
      this.costHeader.DrawZGenericText(offset, spriteBatch);
      this.costNumberText.DrawZGenericText(offset, spriteBatch);
    }
  }
}
