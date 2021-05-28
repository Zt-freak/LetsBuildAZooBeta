// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.ManageEmployeePanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_HUD.PointAtThings;
using TinyZoo.Z_ManageEmployees.EmployeeView;
using TinyZoo.Z_ManageEmployees.HiringSummary;
using TinyZoo.Z_ManageShop.Shop_Data;
using TinyZoo.Z_SummaryPopUps.People.Animal.TabFrame;

namespace TinyZoo.Z_ManageEmployees
{
  internal class ManageEmployeePanel
  {
    private BigBrownPanel bigBrownPanel;
    private Vector2 location;
    private EmployeePerformancePanel employeeViewPanel;
    private HiringSummaryPanel hiringSummaryPanel;
    private LerpHandler_Float lerper;
    private AnimalTabmanager tabManager;
    private EmployeeDisplayType refDisplayType;
    private EmployeeType refRoamingEmployee;
    private ShopEntry refShopEntry;
    private OpenPositions refOpenPositions;
    private float BaseScale;
    private UIScaleHelper scaleHelper;
    private TabType currentTab;

    public ManageEmployeePanel(
      ShopEntry shopEntry,
      EmployeeDisplayType displayType,
      OpenPositions currentOpenPositions,
      Player player,
      float _BaseScale,
      EmployeeType _RoamingEmployeeType = EmployeeType.Count)
    {
      this.refDisplayType = displayType;
      this.refRoamingEmployee = _RoamingEmployeeType;
      this.BaseScale = _BaseScale;
      this.refOpenPositions = currentOpenPositions;
      this.refShopEntry = shopEntry;
      this.currentTab = TabType.Count;
      this.scaleHelper = new UIScaleHelper(this.BaseScale);
      double defaultYbuffer = (double) this.scaleHelper.GetDefaultYBuffer();
      double defaultXbuffer = (double) this.scaleHelper.GetDefaultXBuffer();
      this.bigBrownPanel = new BigBrownPanel(Vector2.Zero, true, "Manage Employees", this.BaseScale);
      float num = (float) AnimalTabmanager.PreferredWidthOfEachTab_Raw * this.BaseScale;
      TabType[] tabTypeArray = new TabType[2]
      {
        TabType.Employees_View,
        TabType.Employees_Hire
      };
      this.tabManager = new AnimalTabmanager(this.BaseScale, (float) tabTypeArray.Length * num, tabTypeArray);
      bool flag = this.refRoamingEmployee == EmployeeType.Count ? player.employees.GetEmployeesInThisSpecificShop(this.refShopEntry.ShopUID).Count == 0 : player.employees.GetEmployeesOfThisType(this.refRoamingEmployee).Count == 0;
      this.OnClickTab(tabTypeArray[0], player);
      if (flag)
      {
        this.tabManager.ForceTabSwitch(1);
        this.OnClickTab(tabTypeArray[1], player);
      }
      this.SetNotification(player);
      this.lerper = new LerpHandler_Float();
      this.LerpIn();
    }

    public void LerpIn() => this.lerper.SetLerp(true, 1f, 0.0f, 3f);

    public void LerpOff() => this.lerper.SetLerp(false, 0.0f, 1f, 3f);

    public bool CheckMouseOver(Player player) => this.tabManager.CheckMouseOver(player, this.location) || this.bigBrownPanel.CheckMouseOver(player, this.location);

    public void ForceRefreshCurrentTab(Player player)
    {
      TabType currentTab = this.currentTab;
      this.currentTab = TabType.Count;
      this.OnClickTab(currentTab, player, true);
    }

    private void SetNotification(Player player)
    {
      if (FeatureFlags.FlashHireStaffFromShop && this.refShopEntry != null && this.refShopEntry.GetEmplyeeCount() < ShopData.GetMaximumEmployeesForThisShop(this.refShopEntry.tiletype, player))
        this.tabManager.AddRedLight(OffscreenPointerType.JobApplicants, 1);
      if (this.refOpenPositions != null && this.refOpenPositions.GetNumberOfApplicants() > 0)
        this.tabManager.AddNotificationIcon(OffscreenPointerType.JobApplicants, 1);
      else
        this.tabManager.AddNotificationIcon(OffscreenPointerType.JobApplicants, 1, true);
    }

    private void OnClickTab(TabType tabType, Player player, bool ForceRemake = false)
    {
      if (this.currentTab != tabType)
      {
        string _NewText = string.Empty;
        switch (tabType)
        {
          case TabType.Employees_View:
            if (this.employeeViewPanel == null | ForceRemake)
              this.employeeViewPanel = new EmployeePerformancePanel(this.refDisplayType, this.refShopEntry, player, this.BaseScale, this.refRoamingEmployee);
            this.bigBrownPanel.Finalize(this.employeeViewPanel.GetSize());
            this.tabManager.SetToTopLeftOfThisPanel(this.bigBrownPanel);
            _NewText = "Manage Employees";
            break;
          case TabType.Employees_Hire:
            if (this.hiringSummaryPanel == null | ForceRemake)
            {
              float x = this.employeeViewPanel.GetSize().X;
              if (ForceRemake)
              {
                this.refOpenPositions = this.refRoamingEmployee != EmployeeType.Count ? player.employees.openPositionsContainer.GetOpenPositionForThisEmployee(this.refRoamingEmployee) : player.employees.openPositionsContainer.GetOpenPositionForThisShop(this.refShopEntry.ShopUID);
                this.SetNotification(player);
              }
              this.hiringSummaryPanel = new HiringSummaryPanel(this.refShopEntry, this.refOpenPositions, player, x, this.BaseScale, this.refRoamingEmployee);
            }
            this.bigBrownPanel.Finalize(this.hiringSummaryPanel.GetSize());
            this.tabManager.SetToTopLeftOfThisPanel(this.bigBrownPanel);
            _NewText = "Hire Employees";
            break;
        }
        this.bigBrownPanel.SetNewHeading(_NewText);
        this.location = new Vector2(512f, 200f);
        this.location.Y -= this.bigBrownPanel.GetFrameOffsetFromTop().Y;
      }
      this.currentTab = tabType;
    }

    public bool UpdateManageEmployeePanel(
      Player player,
      float DeltaTime,
      out Employee ViewThisEmployeeInfo,
      out RecruitmentButtonType recruitmentButtonSelected)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      ViewThisEmployeeInfo = (Employee) null;
      recruitmentButtonSelected = RecruitmentButtonType.Count;
      bool flag = false;
      if ((double) this.lerper.Value == 0.0)
      {
        TabType tabType = this.tabManager.UpdateAnimalTabmanager(this.location, player, DeltaTime);
        if (tabType != TabType.Count)
          this.OnClickTab(tabType, player);
        if (this.currentTab == TabType.Employees_View)
        {
          if (this.employeeViewPanel.UpdateEmployeePerformancePanel(player, DeltaTime, this.location, out ViewThisEmployeeInfo))
            return true;
        }
        else if (this.currentTab == TabType.Employees_Hire)
        {
          recruitmentButtonSelected = this.hiringSummaryPanel.UpdateHiringSummaryPanel(player, DeltaTime, this.location);
          if (recruitmentButtonSelected != RecruitmentButtonType.Count)
            return true;
        }
        this.bigBrownPanel.UpdateDragger(player, ref this.location, DeltaTime);
        if (this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, this.location))
          flag = true;
      }
      return flag;
    }

    public void DrawManageEmployeePanel(SpriteBatch spriteBatch)
    {
      if ((double) this.lerper.Value == 1.0)
        return;
      Vector2 location = this.location;
      location.X += this.lerper.Value * ManageEmployeeManager.LerpDistance;
      this.tabManager.PreDrawAnimalTabmanager(location, spriteBatch);
      this.bigBrownPanel.DrawBigBrownPanel(location);
      if (this.currentTab == TabType.Employees_View)
        this.employeeViewPanel.DrawEmployeePerformancePanel(location, spriteBatch);
      else if (this.currentTab == TabType.Employees_Hire)
        this.hiringSummaryPanel.DrawHiringSummaryPanel(location, spriteBatch);
      this.tabManager.DrawAnimalTabmanager(location, spriteBatch);
    }
  }
}
