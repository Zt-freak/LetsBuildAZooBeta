// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Employees.QuickPick.QuickPickEmployeeManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.IntakeStuff;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BalanceSystems.Park;
using TinyZoo.Z_Employees.Emp_Summary;
using TinyZoo.Z_HUD.Z_HeroQuests_Pins;
using TinyZoo.Z_HUD.Z_Notification.NotificationBubble;

namespace TinyZoo.Z_Employees.QuickPick
{
  internal class QuickPickEmployeeManager
  {
    private QuickEmployeeDescription newemployee;
    private AutomaticJobOfferPanel jobOfferPanel;
    private TILETYPE BuildingToUse;
    private Applicant refApplicant;
    private OpenPositions cameFromOpenPosition;

    public bool Exiting { get; private set; }

    public bool WasCancelled { get; private set; }

    public QuickPickEmployeeManager(TILETYPE _BuildingToUse, int ShopUID)
    {
      this.BuildingToUse = _BuildingToUse;
      this.newemployee = new QuickEmployeeDescription(this.BuildingToUse, ShopUID);
      this.SetUpPanel();
    }

    public QuickPickEmployeeManager(
      Applicant _applicant,
      OpenPositions _cameFromOpenPosition,
      QuickEmployeeDescription _quickEmployeeDescription)
    {
      this.BuildingToUse = _quickEmployeeDescription.WorksHere;
      this.refApplicant = _applicant;
      this.cameFromOpenPosition = _cameFromOpenPosition;
      this.newemployee = _quickEmployeeDescription;
      this.SetUpPanel(true);
    }

    private void SetUpPanel(bool AllowClose = false)
    {
      this.jobOfferPanel = new AutomaticJobOfferPanel(this.newemployee, Z_GameFlags.GetBaseScaleForUI(), AllowClose);
      this.jobOfferPanel.location = new Vector2(512f, 384f);
    }

    public bool UpdateQuickPickEmployeeManager(Player player, float DeltaTime)
    {
      bool isCancel;
      if (this.jobOfferPanel.UpdateAutomaticJobOfferPanel(DeltaTime, player, Vector2.Zero, out isCancel))
      {
        if (isCancel)
        {
          this.WasCancelled = true;
        }
        else
        {
          ShopEntry shopEntry = (ShopEntry) null;
          EmployeeType employeetype;
          EmployeeData.IsThisAnEmployee(this.newemployee.thisemployee, out employeetype);
          if (TileData.IsABreedingRoom(this.BuildingToUse))
            shopEntry = player.shopstatus.GetThisFacility(this.newemployee.ShopUID);
          else if (TileData.IsACRISPRBuilding(this.BuildingToUse))
            shopEntry = player.shopstatus.GetThisFacility(this.newemployee.ShopUID);
          else if (TileData.IsAStoreRoom(this.BuildingToUse))
            player.employees.AddThisEmplyee((IntakePerson) null, employeetype, this.jobOfferPanel.GetSalarySet(), -1, player, this.newemployee);
          else if (TileData.IsThisAFacility(this.BuildingToUse))
            shopEntry = player.shopstatus.GetThisFacility(this.newemployee.ShopUID);
          else if (TileData.IsASlaughterhouse(this.BuildingToUse))
            shopEntry = player.shopstatus.GetThisFacility(this.newemployee.ShopUID);
          else if (TileData.IsAnArchitectOffice(this.BuildingToUse))
            shopEntry = player.shopstatus.GetThisArchitectsOffice(this.newemployee.ShopUID);
          else if (TileData.IsAFactory(this.BuildingToUse))
            shopEntry = player.shopstatus.GetThisFacility(this.newemployee.ShopUID);
          else if (this.BuildingToUse == TILETYPE.Logo)
            player.employees.AddThisEmplyee((IntakePerson) null, employeetype, this.jobOfferPanel.GetSalarySet(), Game1.Rnd.Next(10, 100), player, this.newemployee);
          else
            shopEntry = player.shopstatus.GetThisShop(this.newemployee.ShopUID);
          int ShopUID = -1;
          if (shopEntry != null)
          {
            Employee employee = player.employees.AddThisEmplyee((IntakePerson) null, employeetype, this.jobOfferPanel.GetSalarySet(), -1, player, this.newemployee);
            shopEntry.AddEmployee(player.employees.employees[player.employees.employees.Count - 1]);
            ShopUID = shopEntry.ShopUID;
            employee.quickemplyeedescription.ShopUID = ShopUID;
          }
          Z_QuestPinManager.DoubleCheckTaskNotifications = true;
          CustomerManager.AddPerson(this.newemployee.thisemployee, player.employees.employees[player.employees.employees.Count - 1], player.prisonlayout.cellblockcontainer, player, ShopUID);
          if (this.cameFromOpenPosition != null)
            this.cameFromOpenPosition.RemoveAndHireApplicant(this.refApplicant);
          if ((double) player.livestats.LastCalculatedFacilities >= 0.0)
          {
            float facilities = FacilitiesCalulator.CalculateFacilities(player);
            NotificationBubbleManager.QuickAddNotification(player.livestats.LastCalculatedFacilities, facilities, BubbleMainType.Facilities);
            player.livestats.LastCalculatedFacilities = -1f;
          }
        }
        this.jobOfferPanel.LerpOff();
        this.Exiting = true;
      }
      return this.Exiting && this.jobOfferPanel.IsOffScreen();
    }

    public void DrawQuickPickEmployeeManager() => this.jobOfferPanel.DrawAutomaticJobOfferPanel(Vector2.Zero);
  }
}
