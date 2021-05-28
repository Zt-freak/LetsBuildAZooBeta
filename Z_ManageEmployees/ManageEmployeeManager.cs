// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.ManageEmployeeManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Tile_Data;
using TinyZoo.Z_Employees.QuickPick;
using TinyZoo.Z_ManageEmployees.HiringDetailView.Applicants;
using TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment;
using TinyZoo.Z_ManageEmployees.HiringSummary;

namespace TinyZoo.Z_ManageEmployees
{
  internal class ManageEmployeeManager
  {
    private ManageEmployeePanel manageEmployeePanel;
    private JobPostingPanel jobPostingPanel;
    private ApplicantViewPanel applicantViewPanel;
    private QuickPickEmployeeManager quickPickManager;
    internal static float LerpDistance = 768f;
    private EmployeeDisplayType displayType;
    private ShopEntry shopEntry;
    private float BaseScale;
    private OpenPositions currentOpenPositions;
    private EmployeeType RoamingEmployeeType;
    internal static bool LimitOverHiring = true;

    public ManageEmployeeManager(
      Vector2Int location,
      TILETYPE tileType,
      Player player,
      EmployeeType _RoamingEmployeeType = EmployeeType.Count)
    {
      if (TileData.IsAStoreRoom(tileType))
        _RoamingEmployeeType = EmployeeType.Keeper;
      this.RoamingEmployeeType = _RoamingEmployeeType;
      this.BaseScale = Z_GameFlags.GetBaseScaleForUI();
      if (this.RoamingEmployeeType == EmployeeType.Count)
      {
        this.displayType = ManageEmployeeDisplayData.GetTileTypeToEmployeeDisplayType(tileType, location, player, out this.shopEntry);
        this.currentOpenPositions = player.employees.openPositionsContainer.GetOpenPositionForThisShop(this.shopEntry.ShopUID);
      }
      else
      {
        this.displayType = EmployeeDisplayType.Facility;
        this.currentOpenPositions = player.employees.openPositionsContainer.GetOpenPositionForThisEmployee(this.RoamingEmployeeType);
      }
      this.ConstructMainSummaryPanel(player);
    }

    private void ConstructMainSummaryPanel(Player player) => this.manageEmployeePanel = new ManageEmployeePanel(this.shopEntry, this.displayType, this.currentOpenPositions, player, this.BaseScale, this.RoamingEmployeeType);

    public bool CheckMouseOver(Player player)
    {
      bool flag = false;
      if (this.applicantViewPanel != null)
        flag |= this.applicantViewPanel.CheckMouseOver(player);
      if (this.manageEmployeePanel != null)
        flag |= this.manageEmployeePanel.CheckMouseOver(player);
      if (this.jobPostingPanel != null)
        flag |= this.jobPostingPanel.CheckMouseOver(player);
      return flag;
    }

    public bool UpdateManageEmployeeManager(Player player, float DeltaTime)
    {
      bool ExitCompletely = false;
      if (this.quickPickManager != null)
      {
        if (this.quickPickManager.UpdateQuickPickEmployeeManager(player, DeltaTime))
        {
          if (!this.quickPickManager.WasCancelled)
            return true;
          this.quickPickManager = (QuickPickEmployeeManager) null;
        }
        if (this.quickPickManager != null && this.quickPickManager.Exiting && this.quickPickManager.WasCancelled)
          this.applicantViewPanel.LerpIn();
      }
      Applicant selectedThisApplicant;
      bool somethingChanged;
      if (this.applicantViewPanel != null && this.applicantViewPanel.UpdateApplicantViewPanel(player, DeltaTime, out selectedThisApplicant, out somethingChanged, out ExitCompletely))
      {
        if (selectedThisApplicant != null)
        {
          this.applicantViewPanel.LerpOff();
          QuickEmployeeDescription _quickEmployeeDescription = selectedThisApplicant.ConstructQuickEmployeeDescriptionForHiring(this.shopEntry, this.RoamingEmployeeType);
          this.quickPickManager = new QuickPickEmployeeManager(selectedThisApplicant, this.currentOpenPositions, _quickEmployeeDescription);
        }
        else
        {
          this.applicantViewPanel.LerpOff();
          if (!ExitCompletely)
          {
            this.manageEmployeePanel.LerpIn();
            if (somethingChanged)
              this.manageEmployeePanel.ForceRefreshCurrentTab(player);
          }
        }
      }
      if (this.jobPostingPanel != null && this.jobPostingPanel.UpdateJobPostingPanel(player, DeltaTime, out bool _, out ExitCompletely))
      {
        OpenPositions tempOpenPositions = this.jobPostingPanel.GetTempOpenPositions();
        bool flag = false;
        if (this.currentOpenPositions != null)
        {
          if (tempOpenPositions.NumberOfPositionsOpened != this.currentOpenPositions.NumberOfPositionsOpened || tempOpenPositions.IsSocialMediaEnabled != this.currentOpenPositions.IsSocialMediaEnabled || (tempOpenPositions.IsJobPortalEnabled != this.currentOpenPositions.IsJobPortalEnabled || tempOpenPositions.IsReferralEnabled != this.currentOpenPositions.IsReferralEnabled))
            flag = true;
          this.currentOpenPositions.CompareAndApplyChanges(tempOpenPositions);
        }
        else if (tempOpenPositions.NumberOfPositionsOpened > 0)
        {
          this.currentOpenPositions = tempOpenPositions;
          player.employees.openPositionsContainer.AddNewOpenPosition(this.currentOpenPositions);
          flag = true;
        }
        this.jobPostingPanel.LerpOff();
        if (!ExitCompletely)
        {
          this.manageEmployeePanel.LerpIn();
          if (flag)
            this.manageEmployeePanel.ForceRefreshCurrentTab(player);
        }
      }
      Employee ViewThisEmployeeInfo;
      RecruitmentButtonType recruitmentButtonSelected;
      if (this.manageEmployeePanel.UpdateManageEmployeePanel(player, DeltaTime, out ViewThisEmployeeInfo, out recruitmentButtonSelected))
      {
        switch (recruitmentButtonSelected)
        {
          case RecruitmentButtonType.ViewJobPostings:
            OpenPositions _TEMPOPENPOSITIONS;
            if (this.currentOpenPositions != null)
            {
              _TEMPOPENPOSITIONS = new OpenPositions(this.currentOpenPositions);
            }
            else
            {
              int _ShopUID = -1;
              TILETYPE _tileType = TILETYPE.Count;
              if (this.shopEntry != null)
              {
                _ShopUID = this.shopEntry.ShopUID;
                _tileType = this.shopEntry.tiletype;
              }
              _TEMPOPENPOSITIONS = new OpenPositions(_ShopUID, _tileType, this.RoamingEmployeeType);
            }
            this.jobPostingPanel = new JobPostingPanel(this.shopEntry, _TEMPOPENPOSITIONS, player, this.BaseScale, this.RoamingEmployeeType);
            this.jobPostingPanel.location = new Vector2(512f, 384f);
            this.manageEmployeePanel.LerpOff();
            break;
          case RecruitmentButtonType.ViewApplicantsForJobPostings:
            this.applicantViewPanel = new ApplicantViewPanel(this.shopEntry, this.currentOpenPositions, this.BaseScale, _RoamingEmployeeType: this.RoamingEmployeeType);
            this.applicantViewPanel.location = new Vector2(512f, 384f);
            this.manageEmployeePanel.LerpOff();
            break;
          case RecruitmentButtonType.HireFromAgency:
            this.applicantViewPanel = new ApplicantViewPanel(this.shopEntry, this.currentOpenPositions, this.BaseScale, true, this.RoamingEmployeeType);
            this.applicantViewPanel.location = new Vector2(512f, 384f);
            this.manageEmployeePanel.LerpOff();
            break;
          default:
            if (ViewThisEmployeeInfo != null)
            {
              OverWorldManager.zoopopupHolder.CreateZooPopUps(CustomerManager.GetThisEmployee(ViewThisEmployeeInfo), player);
              break;
            }
            ExitCompletely = true;
            break;
        }
      }
      return ExitCompletely;
    }

    public void DrawManageEmployeeManager()
    {
      this.manageEmployeePanel.DrawManageEmployeePanel(AssetContainer.pointspritebatchTop05);
      if (this.jobPostingPanel != null)
        this.jobPostingPanel.DrawJobPostingPanel(AssetContainer.pointspritebatchTop05);
      if (this.applicantViewPanel != null)
        this.applicantViewPanel.DrawApplicantViewPanel(AssetContainer.pointspritebatchTop05);
      if (this.quickPickManager == null)
        return;
      this.quickPickManager.DrawQuickPickEmployeeManager();
    }
  }
}
