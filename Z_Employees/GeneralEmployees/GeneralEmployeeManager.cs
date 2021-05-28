// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Employees.GeneralEmployees.GeneralEmployeeManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.PlayerDir;
using TinyZoo.Z_Employees.GeneralEmployees.NotHere;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_Employees.GeneralEmployees
{
  internal class GeneralEmployeeManager
  {
    private BigBrownPanel bigpanel;
    public Vector2 Location;
    private List<EmployeeByTypeSummary> employeesummary;
    private SimpleArrowPageButtons simplearrows;
    private int Page;
    private float BaseScale;
    private ParkStaffScreenState screenstate;
    private float UnmultipliedWidth;
    public EmployeeType SwitchToDetailViewForThis;
    private NotHereCollection notherecollection;

    public GeneralEmployeeManager(Player player)
    {
      this.screenstate = ParkStaffScreenState.Main;
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      this.BaseScale = baseScaleForUi;
      this.bigpanel = new BigBrownPanel(Vector2.Zero, true, "Park Staff", baseScaleForUi);
      UIScaleHelper uiScaleHelper = new UIScaleHelper(this.BaseScale);
      this.UnmultipliedWidth = 450f;
      this.MakePage(this.UnmultipliedWidth, player);
      this.simplearrows = new SimpleArrowPageButtons(baseScaleForUi);
      Vector2 size = this.employeesummary[0].GetSize();
      size.Y *= (float) this.employeesummary.Count;
      size.Y += 10f * baseScaleForUi * (float) (this.employeesummary.Count - 1);
      size.Y += uiScaleHelper.DefaultBuffer.Y;
      size.Y += this.simplearrows.GetSize(true).Y;
      this.bigpanel.Finalize(size);
      this.PositionEmployeeSummary();
      this.Location = new Vector2(700f, 384f);
      this.simplearrows.Location = size + this.bigpanel.GetFrameOffsetFromTop();
      this.simplearrows.Location -= this.simplearrows.GetSize(true) * 0.5f;
    }

    private void MakePage(float UnmultipliedWidth, Player player)
    {
      this.employeesummary = new List<EmployeeByTypeSummary>();
      if (Z_DebugFlags.IsBetaVersion)
      {
        if (this.Page == 0)
        {
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Keeper, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Janitor, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Architect, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.ShopKeeper, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.DNAResearcher, player, this.BaseScale, UnmultipliedWidth));
        }
        else if (this.Page == 1)
        {
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Guide, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Mascot, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Mechanic, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Breeder, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Vet, player, this.BaseScale, UnmultipliedWidth));
        }
        else if (this.Page == 2)
        {
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Farmer, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.MeatProcessorWorker, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.FactoryWorker, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.VegProcessorWorker, player, this.BaseScale, UnmultipliedWidth));
          this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.WarehouseWorker, player, this.BaseScale, UnmultipliedWidth));
        }
      }
      else if (this.Page == 0)
      {
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Keeper, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Janitor, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Mechanic, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Mascot, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.ShopKeeper, player, this.BaseScale, UnmultipliedWidth));
      }
      else if (this.Page == 1)
      {
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Guide, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Architect, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Breeder, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Vet, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.DNAResearcher, player, this.BaseScale, UnmultipliedWidth));
      }
      else if (this.Page == 2)
      {
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.Farmer, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.MeatProcessorWorker, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.FactoryWorker, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.VegProcessorWorker, player, this.BaseScale, UnmultipliedWidth));
        this.employeesummary.Add(new EmployeeByTypeSummary(EmployeeType.WarehouseWorker, player, this.BaseScale, UnmultipliedWidth));
      }
      this.PositionEmployeeSummary();
    }

    private void PositionEmployeeSummary()
    {
      Vector2 size = this.employeesummary[0].GetSize();
      for (int index = 0; index < this.employeesummary.Count; ++index)
      {
        this.employeesummary[index].Location.Y = size.Y * 0.5f;
        this.employeesummary[index].Location.Y += (size.Y + 10f * this.BaseScale) * (float) index;
        this.employeesummary[index].Location.Y += this.bigpanel.GetFrameOffsetFromTop().Y;
      }
    }

    public bool CheckMouseOver(Player player) => this.bigpanel.CheckMouseOver(player, this.Location);

    public bool UpdateGemeralEmployeeManager(
      float DeltaTime,
      Player player,
      out bool SwitchToManage)
    {
      SwitchToManage = false;
      this.bigpanel.UpdateDragger(player, ref this.Location, DeltaTime);
      if (this.bigpanel.UpdatePanelCloseButton(player, DeltaTime, this.Location))
        return true;
      if (this.screenstate == ParkStaffScreenState.Main)
      {
        int num1 = this.simplearrows.UpdateSimpleArrowPageButtons(DeltaTime, player, this.Location);
        int num2 = 2;
        if (num1 != 0)
        {
          this.Page += num1;
          if (this.Page < 0)
            this.Page = num2;
          if (this.Page > num2)
            this.Page = 0;
          this.MakePage(this.UnmultipliedWidth, player);
        }
        for (int index = 0; index < this.employeesummary.Count; ++index)
        {
          if (this.employeesummary[index].UpdateEmployeeByTypeSummary(player, DeltaTime, this.Location))
          {
            if (NotHereManager.ShouldDisplayNotHere(this.employeesummary[index].employeetype))
            {
              this.screenstate = ParkStaffScreenState.NotAvilableHere;
              this.notherecollection = new NotHereCollection(player, this.employeesummary[index].employeetype, this.BaseScale, this.UnmultipliedWidth, this.employeesummary[index].animalinframe);
              this.notherecollection.location.Y += this.bigpanel.GetFrameOffsetFromTop().Y;
            }
            else
            {
              this.SwitchToDetailViewForThis = this.employeesummary[index].employeetype;
              SwitchToManage = true;
            }
          }
        }
      }
      if (this.screenstate == ParkStaffScreenState.NotAvilableHere && this.notherecollection.UpdateNotHereCollection(player, DeltaTime, this.Location))
        this.screenstate = ParkStaffScreenState.Main;
      return false;
    }

    public void DrawGemeralEmployeeManager()
    {
      this.bigpanel.DrawBigBrownPanel(this.Location);
      if (this.screenstate == ParkStaffScreenState.NotAvilableHere)
      {
        this.notherecollection.DrawNotHereCollection(this.Location, AssetContainer.pointspritebatchTop05);
      }
      else
      {
        for (int index = 0; index < this.employeesummary.Count; ++index)
          this.employeesummary[index].DrawEmployeeByTypeSummary(this.Location, AssetContainer.pointspritebatchTop05);
        this.simplearrows.DrawSimpleArrowPageButtons(this.Location, AssetContainer.pointspritebatchTop05);
      }
    }
  }
}
