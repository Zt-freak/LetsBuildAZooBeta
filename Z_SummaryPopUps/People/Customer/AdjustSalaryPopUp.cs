// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Customer.AdjustSalaryPopUp
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.Z_Employees.Emp_Summary;
using TinyZoo.Z_Employees.QuickPick;
using TinyZoo.Z_SummaryPopUps.People.Employee;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.Z_SummaryPopUps.People.Customer
{
  internal class AdjustSalaryPopUp : CustomerActionPopUp
  {
    private EmployeeSummaryPanel summary;
    private SalarySliderWithAverage slider;
    private TextButton button;
    private float min;
    private float max;
    private float average;
    private float currentsalary;
    private WalkingPerson walkingperson;

    public AdjustSalaryPopUp(WalkingPerson walkingperson_, float basescale_)
      : base(basescale_)
    {
      this.walkingperson = walkingperson_;
      QuickEmployeeDescription quickemplyeedescription = this.walkingperson.simperson.Ref_Employee.quickemplyeedescription;
      EmployeeStats employeestats = EmployeesStats.GetEmployeestats(this.walkingperson.simperson.Ref_Employee.employeetype, this.walkingperson.thispersontype, (int) quickemplyeedescription.seniorityLevel);
      this.min = (float) employeestats.MinimumWage;
      this.max = (float) employeestats.MaximumWage;
      this.average = (float) (((double) this.max - (double) this.min) / 2.0) + this.min;
      this.currentsalary = (float) quickemplyeedescription.CurrentSalary;
      this.summary = new EmployeeSummaryPanel(quickemplyeedescription, false, false, this.basescale, true);
      this.slider = new SalarySliderWithAverage(this.basescale, this.min, this.max, this.currentsalary, this.uiscale.ScaleX(140f), withAgencyFee_: (quickemplyeedescription.AgencyPay_WeeksLeft > 0), averageval: this.average);
      this.button = new TextButton(this.basescale, "Confirm", 50f);
      this.framescale = 2f * this.pad;
      this.framescale = this.framescale + this.summary.GetSize();
      this.framescale.Y += this.pad.Y;
      this.framescale.Y += this.slider.GetSize().Y;
      this.framescale.Y += this.button.GetSize_True().Y + this.pad.Y;
      this.SizeFrame();
      Vector2 vector2 = -0.5f * this.framescale + this.pad;
      this.summary.location = vector2 + 0.5f * this.summary.GetSize();
      vector2.Y += this.summary.GetSize().Y + this.pad.Y;
      this.slider.location = vector2 + 0.5f * this.slider.GetSize();
      this.slider.location.X = 0.0f;
      vector2.Y += this.slider.GetSize().Y + this.pad.Y;
      this.button.vLocation = vector2 + 0.5f * this.button.GetSize_True();
      this.button.vLocation.X = 0.0f;
      vector2.Y += this.button.GetSize_True().Y;
    }

    public override bool UpdateCustomerActionPopUp(Player player, Vector2 offset, float DeltaTime)
    {
      offset += this.location;
      this.summary.UpdateEmployeeSummary(DeltaTime, player, offset);
      this.slider.UpdateSalarySliderWithAverage(player, offset, DeltaTime);
      int num1 = 0 | (this.button.UpdateTextButton(player, offset, DeltaTime) ? 1 : 0);
      float num2 = (float) (((double) this.currentsalary - (double) this.min) / ((double) this.max - (double) this.min));
      this.summary.PreviewStatChange(1, this.summary.GetStatValue(1) + (float) (((double) this.slider.Value - (double) num2) * 0.600000023841858));
      this.summary.PreviewStatChange(4, this.summary.GetStatValue(4) + (float) (((double) this.slider.Value - (double) num2) * 0.600000023841858));
      if (num1 == 0)
        return num1 != 0;
      this.currentsalary = this.slider.Salary;
      this.walkingperson.simperson.Ref_Employee.ChangeSalary((int) this.currentsalary);
      this.summary.ApplyChange(1);
      this.summary.ApplyChange(4);
      return num1 != 0;
    }

    public override void DrawCustomerActionPopUp(SpriteBatch spritebatch, Vector2 offset)
    {
      offset += this.location;
      this.frame.DrawCustomerFrame(offset, spritebatch);
      this.summary.DrawEmployeeSummary(offset);
      this.slider.DrawSalarySliderWithAverage(spritebatch, offset);
      this.button.DrawTextButton(offset, 1f, spritebatch);
    }
  }
}
