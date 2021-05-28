// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Employees.Emp_Summary.AutomaticJobOfferPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GenericUI;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;
using TinyZoo.Z_Employees.QuickPick;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_ManageEmployees;
using TinyZoo.Z_SummaryPopUps.People.Animal;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.Z_Employees.Emp_Summary
{
  internal class AutomaticJobOfferPanel
  {
    private EmployeeSummaryPanel employeeSummary;
    public Vector2 location;
    private BigBrownPanel BigFrame;
    private SimpleTextHandler text;
    private TextButton hireButton;
    private QuickEmployeeDescription Employee;
    private LerpHandler_Float lerper;

    public AutomaticJobOfferPanel(
      QuickEmployeeDescription newemployee,
      float BaseScale,
      bool AllowClose = false)
    {
      float num1 = AnimalPopUpManager.VerticalBuffer * Sengine.ScreenRatioUpwardsMultiplier.Y * BaseScale;
      float num2 = 0.0f;
      this.Employee = newemployee;
      EmployeeType employeetype;
      EmployeeData.IsThisAnEmployee(newemployee.thisemployee, out employeetype);
      string jobTitle = EmployeesStats.GetJobTitle(employeetype, newemployee.thisemployee, (int) newemployee.seniorityLevel, false);
      this.BigFrame = new BigBrownPanel(Vector2.Zero, AllowClose, "Hire", BaseScale);
      this.employeeSummary = new EmployeeSummaryPanel(newemployee, true, BaseScale: BaseScale);
      this.employeeSummary.location.Y = num2;
      this.employeeSummary.location.Y += this.employeeSummary.brownFrame.VSCale.Y * 0.5f;
      float num3 = num2 + this.employeeSummary.brownFrame.VSCale.Y + num1;
      this.text = new SimpleTextHandler("Choose a salary for your new " + jobTitle + ".", true, this.employeeSummary.brownFrame.VSCale.X / 1024f, BaseScale);
      this.text.SetAllColours(ColourData.Z_Cream);
      this.text.AutoCompleteParagraph();
      this.text.Location.Y = num3 + this.text.GetHeightOfOneLine() * 0.5f;
      float num4 = num3 + (this.text.GetHeightOfParagraph() - this.text.GetHeightOfOneLine() * 0.5f) + num1;
      this.hireButton = new TextButton(BaseScale, "Hire", 50f, _OverrideFrameScale: BaseScale);
      this.hireButton.vLocation.Y = num4;
      this.hireButton.vLocation.Y += this.hireButton.GetVScale().Y * 0.5f * Sengine.ScreenRatioUpwardsMultiplier.Y;
      this.BigFrame.Finalize(new Vector2(this.employeeSummary.brownFrame.VSCale.X, num4 + this.hireButton.GetVScale().Y * Sengine.ScreenRatioUpwardsMultiplier.Y));
      float num5 = (float) (-(double) this.BigFrame.vScale.Y * 0.5 - (double) this.BigFrame.InternalOffset.Y + (double) this.BigFrame.GetEdgeBuffer() * (double) BaseScale * (double) Sengine.ScreenRatioUpwardsMultiplier.Y);
      this.employeeSummary.location.Y += num5;
      this.text.Location.Y += num5;
      this.hireButton.vLocation.Y += num5;
      this.lerper = new LerpHandler_Float();
      this.LerpIn();
    }

    public void LerpIn() => this.lerper.SetLerp(true, 1f, 0.0f, 3f);

    public void LerpOff() => this.lerper.SetLerp(false, 0.0f, 1f, 3f);

    public bool IsOffScreen() => (double) this.lerper.Value == 1.0;

    public int GetSalarySet() => this.employeeSummary.GetSalarySet();

    public bool UpdateAutomaticJobOfferPanel(
      float DeltaTime,
      Player player,
      Vector2 offset,
      out bool isCancel)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      isCancel = false;
      offset += this.location;
      offset.X += this.lerper.Value * ManageEmployeeManager.LerpDistance;
      if ((double) this.lerper.Value == 0.0)
      {
        this.BigFrame.UpdateDragger(player, ref this.location, DeltaTime);
        this.employeeSummary.UpdateEmployeeSummary(DeltaTime, player, this.location);
        this.text.UpdateSimpleTextHandler(DeltaTime);
        if (this.hireButton.UpdateTextButton(player, this.location, DeltaTime))
        {
          this.Employee.CurrentSalary = this.employeeSummary.GetSalarySet();
          return true;
        }
        if (this.BigFrame.UpdatePanelCloseButton(player, DeltaTime, this.location))
        {
          isCancel = true;
          return true;
        }
      }
      return false;
    }

    public void DrawAutomaticJobOfferPanel(Vector2 offset)
    {
      if ((double) this.lerper.Value == 1.0)
        return;
      offset += this.location;
      offset.X += this.lerper.Value * ManageEmployeeManager.LerpDistance;
      this.BigFrame.DrawBigBrownPanel(offset);
      this.employeeSummary.DrawEmployeeSummary(offset);
      this.text.DrawSimpleTextHandler(offset, 1f, AssetContainer.pointspritebatchTop05);
      this.hireButton.DrawTextButton(offset, 1f, AssetContainer.pointspritebatchTop05);
    }
  }
}
