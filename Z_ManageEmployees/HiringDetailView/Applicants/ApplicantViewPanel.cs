// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Applicants.ApplicantViewPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System.Collections.Generic;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BalanceSystems.Employees.JobApplicants;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Applicants
{
  internal class ApplicantViewPanel
  {
    public Vector2 location;
    private BigBrownPanel bigBrownPanel;
    private LerpHandler_Float lerper;
    private ApplicantsTable applicantTable;
    private SimpleTextHandler InfoPara;
    private ZGenericText applicantDisplayedCountText;
    private string applicantDisplayedBaseString;
    private ZGenericText noMoreApplicantText;
    private string noMoreApplicantsString;
    private TextButton DismissAllButton;
    public bool isAgencyInstantHire;
    private OpenPositions refcurrentOpenPositions;
    private ShopEntry refShopEntry;
    private float refBaseScale;
    private float refYBuffer;
    private bool SomethingChanged;
    private EmployeeType RoamingEmployeeType;

    public ApplicantViewPanel(
      ShopEntry shopEntry,
      OpenPositions _currentOpenPositions,
      float BaseScale,
      bool _isAgencyInstantHire = false,
      EmployeeType _RoamingEmployeeType = EmployeeType.Count)
    {
      this.RoamingEmployeeType = _RoamingEmployeeType;
      this.isAgencyInstantHire = _isAgencyInstantHire;
      this.refcurrentOpenPositions = _currentOpenPositions;
      this.refShopEntry = shopEntry;
      this.refBaseScale = BaseScale;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      this.refYBuffer = defaultYbuffer;
      float num1 = 0.0f;
      this.bigBrownPanel = new BigBrownPanel(Vector2.Zero, true, "Applicants", BaseScale, true);
      float[] widths = new float[6]
      {
        uiScaleHelper.ScaleX(110f),
        uiScaleHelper.ScaleX(100f),
        uiScaleHelper.ScaleX(100f),
        uiScaleHelper.ScaleX(80f),
        uiScaleHelper.ScaleX(45f),
        uiScaleHelper.ScaleX(45f)
      };
      float x = 0.0f;
      for (int index = 0; index < widths.Length; ++index)
        x += widths[index];
      int num2 = 0;
      string empty = string.Empty;
      List<Applicant> listOfApplicants;
      string TextToWrite;
      if (this.isAgencyInstantHire)
      {
        listOfApplicants = new List<Applicant>();
        for (int index = 0; index < ApplicantGenerator.MaxApplicantsForDisplay; ++index)
        {
          if (this.RoamingEmployeeType != EmployeeType.Count)
            listOfApplicants.Add(ApplicantGenerator.CreateNewApplicant(TILETYPE.Count, this.RoamingEmployeeType, this.isAgencyInstantHire));
          else
            listOfApplicants.Add(ApplicantGenerator.CreateNewApplicant(shopEntry.tiletype, EmployeeType.Count, this.isAgencyInstantHire));
        }
        TextToWrite = string.Format("The Recruitment Agency takes a {0}% additional fee based on the salary given, for a period of {1} weeks.", (object) (float) ((double) HiringAgency.GetPercentageAgencyCutAsFloat() * 100.0), (object) HiringAgency.GetLengthOfAgencyCut_Weeks());
      }
      else
      {
        listOfApplicants = this.refcurrentOpenPositions.GetAndPopulateApplicantsForDisplay();
        TextToWrite = "Job Positions Opened: " + (object) this.refcurrentOpenPositions.NumberOfPositionsOpened + "~After hiring a new employee, the job position will be closed.";
      }
      this.InfoPara = new SimpleTextHandler(TextToWrite, true, (float) ((double) x / 1024.0 * 0.899999976158142), BaseScale);
      this.InfoPara.AutoCompleteParagraph();
      this.InfoPara.SetAllColours(ColourData.Z_Cream);
      this.InfoPara.Location.Y = num1;
      float num3 = num1 + this.InfoPara.GetHeightOfParagraph();
      if (!this.isAgencyInstantHire)
      {
        num2 = this.refcurrentOpenPositions.GetNumberOfApplicants();
        this.applicantDisplayedBaseString = "Displaying: ";
        this.applicantDisplayedCountText = new ZGenericText(this.applicantDisplayedBaseString + (object) listOfApplicants.Count + "/" + (object) num2, BaseScale, false, true);
        this.applicantDisplayedCountText.vLocation.Y = num3;
        num3 = num3 + this.applicantDisplayedCountText.GetSize().Y + defaultYbuffer * 0.5f;
      }
      this.applicantTable = new ApplicantsTable(listOfApplicants, BaseScale, defaultYbuffer, ref widths, this.isAgencyInstantHire);
      this.applicantTable.location.Y = num3;
      float num4 = num3 + this.applicantTable.GetSize().Y + this.refYBuffer;
      this.noMoreApplicantsString = "No more applicants.";
      string _textToWrite = "Dismiss applicants to view more.";
      if (!this.isAgencyInstantHire && listOfApplicants.Count == num2)
        _textToWrite = this.noMoreApplicantsString;
      this.noMoreApplicantText = new ZGenericText(_textToWrite, this.refBaseScale);
      Vector2 size = this.noMoreApplicantText.GetSize();
      this.noMoreApplicantText.vLocation.Y = num4 + size.Y * 0.5f;
      float num5 = num4 + size.Y + defaultYbuffer;
      this.DismissAllButton = new TextButton(BaseScale, "Dismiss All", 70f, _OverrideFrameScale: (BaseScale * 2f));
      this.DismissAllButton.SetButtonColour(BTNColour.Red);
      Vector2 sizeTrue = this.DismissAllButton.GetSize_True();
      this.DismissAllButton.vLocation.X -= sizeTrue.X * 0.5f;
      this.DismissAllButton.vLocation.Y = num5 + sizeTrue.Y * 0.5f;
      float y = num5 + sizeTrue.Y;
      this.bigBrownPanel.Finalize(new Vector2(x, y));
      Vector2 frameOffsetFromTop = this.bigBrownPanel.GetFrameOffsetFromTop();
      if (this.applicantDisplayedCountText != null)
      {
        this.applicantDisplayedCountText.vLocation.Y += frameOffsetFromTop.Y;
        this.applicantDisplayedCountText.vLocation.X += x * 0.5f;
      }
      this.applicantTable.location.Y += frameOffsetFromTop.Y;
      if (this.InfoPara != null)
        this.InfoPara.Location.Y += frameOffsetFromTop.Y;
      if (this.noMoreApplicantText != null)
        this.noMoreApplicantText.vLocation.Y += frameOffsetFromTop.Y;
      this.DismissAllButton.vLocation.Y += frameOffsetFromTop.Y;
      this.DismissAllButton.vLocation.X += x * 0.5f;
      this.lerper = new LerpHandler_Float();
      this.LerpIn();
    }

    public void LerpIn() => this.lerper.SetLerp(true, 1f, 0.0f, 3f);

    public void LerpOff() => this.lerper.SetLerp(false, 0.0f, 1f, 3f);

    private void DismissApplicant(List<Applicant> applicantSelected)
    {
      List<Applicant> addThisApplicantToo = new List<Applicant>();
      if (this.isAgencyInstantHire)
      {
        TILETYPE tileType = TILETYPE.Count;
        if (this.refShopEntry != null)
          tileType = this.refShopEntry.tiletype;
        for (int index = 0; index < applicantSelected.Count; ++index)
          addThisApplicantToo.Add(ApplicantGenerator.CreateNewApplicant(tileType, this.RoamingEmployeeType, true));
      }
      else
      {
        for (int index = 0; index < applicantSelected.Count; ++index)
        {
          if (this.refcurrentOpenPositions.NewApplicantsNotPopulated > 0)
            addThisApplicantToo.Add(this.refcurrentOpenPositions.GenerateNewApplicantForThisPosition());
        }
      }
      this.applicantTable.DismissApplicants(applicantSelected, addThisApplicantToo);
      if (!this.isAgencyInstantHire)
      {
        for (int index = 0; index < applicantSelected.Count; ++index)
          this.refcurrentOpenPositions.RemoveApplicant(applicantSelected[index]);
      }
      this.SomethingChanged = true;
      if (this.isAgencyInstantHire)
        return;
      int numberOfApplicants = this.refcurrentOpenPositions.GetNumberOfApplicants();
      int numberOfEntries = this.applicantTable.GetNumberOfEntries();
      if (numberOfApplicants == numberOfEntries)
        this.noMoreApplicantText.textToWrite = this.noMoreApplicantsString;
      this.applicantDisplayedCountText.textToWrite = this.applicantDisplayedBaseString + (object) numberOfEntries + "/" + (object) numberOfApplicants;
      if (numberOfEntries != 0)
        return;
      this.DismissAllButton.SetButtonColour(BTNColour.Grey);
      this.DismissAllButton.Locked = true;
    }

    public bool CheckMouseOver(Player player) => this.bigBrownPanel.CheckMouseOver(player, this.location);

    public bool UpdateApplicantViewPanel(
      Player player,
      float DeltaTime,
      out Applicant selectedThisApplicant,
      out bool somethingChanged,
      out bool ExitCompletely)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      Vector2 location = this.location;
      selectedThisApplicant = (Applicant) null;
      somethingChanged = this.SomethingChanged;
      ExitCompletely = false;
      if ((double) this.lerper.Value == 0.0)
      {
        if (this.bigBrownPanel.UpdatePanelpreviousButton(player, DeltaTime, location))
          return true;
        if (this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, location))
        {
          ExitCompletely = true;
          return true;
        }
        bool isDismiss;
        Applicant applicant = this.applicantTable.UpdateApplicantsTable(player, DeltaTime, location, out isDismiss);
        if (applicant != null)
        {
          if (isDismiss)
          {
            this.DismissApplicant(new List<Applicant>()
            {
              applicant
            });
          }
          else
          {
            selectedThisApplicant = applicant;
            this.SomethingChanged = true;
            return true;
          }
        }
        if (!this.DismissAllButton.Locked && this.DismissAllButton.UpdateTextButton(player, location, DeltaTime) && !this.applicantTable.IsBusy())
          this.DismissApplicant(this.applicantTable.GetAllApplicantsDisplayed());
      }
      return false;
    }

    public void DrawApplicantViewPanel(SpriteBatch spriteBatch)
    {
      if ((double) this.lerper.Value == 1.0)
        return;
      Vector2 location = this.location;
      location.X += this.lerper.Value * ManageEmployeeManager.LerpDistance;
      this.bigBrownPanel.DrawBigBrownPanel(location, spriteBatch);
      if (this.applicantDisplayedCountText != null)
        this.applicantDisplayedCountText.DrawZGenericText(location, spriteBatch);
      this.applicantTable.DrawApplicantsTable(location, spriteBatch);
      if (this.InfoPara != null)
        this.InfoPara.DrawSimpleTextHandler(location, 1f, spriteBatch);
      if (this.noMoreApplicantText != null)
        this.noMoreApplicantText.DrawZGenericText(location, spriteBatch);
      this.DismissAllButton.DrawTextButton(location, 1f, spriteBatch);
    }
  }
}
