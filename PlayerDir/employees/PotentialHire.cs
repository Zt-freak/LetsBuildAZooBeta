// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.employees.PotentialHire
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.IntakeStuff;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.PlayerDir.employees
{
  internal class PotentialHire
  {
    public IntakePerson intakeperson;
    public EmployeeStats employeestats;
    public EmployeeType employeetype;
    public HireResult CurrentHireResult;

    public PotentialHire(EmployeeType _employeetype, int Seniority = -1)
    {
      this.employeetype = _employeetype;
      this.CurrentHireResult = HireResult.NoResult;
      bool IsAGirl;
      AnimalType employee = Employees.GetEmployee(this.employeetype, out IsAGirl);
      this.intakeperson = new IntakePerson(employee, _IsAGirl: IsAGirl);
      this.employeestats = EmployeesStats.GetEmployeestats(this.employeetype, employee, Seniority);
    }

    public int GetMinimumWage() => this.employeestats.MinimumWage + (int) Math.Round((double) (this.employeestats.MaximumWage - this.employeestats.MinimumWage) * (double) this.employeestats.Greed * 0.00999999977648258);

    public string GetJobTitle() => EmployeesStats.GetJobTitle(this.employeetype, this.intakeperson.animaltype, this.employeestats.Seniority);

    public void SavePotentialHire(Writer writer)
    {
      this.intakeperson.SaveIntakePerson(writer);
      this.employeestats.SaveEmployeeStats(writer);
      writer.WriteInt("p", (int) this.employeetype);
      writer.WriteInt("p", (int) this.CurrentHireResult);
    }

    public PotentialHire(Reader reader)
    {
      this.intakeperson = new IntakePerson(reader);
      this.employeestats = new EmployeeStats(reader);
      int _out = 0;
      int num1 = (int) reader.ReadInt("p", ref _out);
      this.employeetype = (EmployeeType) _out;
      int num2 = (int) reader.ReadInt("p", ref _out);
      this.CurrentHireResult = (HireResult) _out;
    }
  }
}
