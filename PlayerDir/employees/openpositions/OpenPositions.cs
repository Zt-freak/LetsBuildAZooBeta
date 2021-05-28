// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.employees.openpositions.OpenPositions
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System;
using System.Collections.Generic;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BalanceSystems.Employees;
using TinyZoo.Z_BalanceSystems.Employees.JobApplicants;

namespace TinyZoo.PlayerDir.employees.openpositions
{
  internal class OpenPositions
  {
    public int ShopUID;
    public TILETYPE tileType;
    public int DayStarted;
    private List<Applicant> Applicants;
    public int NewApplicantsNotPopulated;
    public int TotalAmountSpent;
    public int NumberOfPositionsOpened;
    public bool IsSocialMediaEnabled;
    public bool IsJobPortalEnabled;
    public bool IsReferralEnabled;
    public EmployeeType RoamingEmployeeType = EmployeeType.Count;

    public OpenPositions(int _ShopUID, TILETYPE _tileType, EmployeeType _RoamingEmployeeType = EmployeeType.Count)
    {
      this.RoamingEmployeeType = _RoamingEmployeeType;
      this.Applicants = new List<Applicant>();
      this.ShopUID = _ShopUID;
      this.tileType = _tileType;
    }

    public OpenPositions(OpenPositions deepcopythis)
    {
      this.RoamingEmployeeType = deepcopythis.RoamingEmployeeType;
      this.ShopUID = deepcopythis.ShopUID;
      this.DayStarted = deepcopythis.DayStarted;
      this.Applicants = deepcopythis.Applicants;
      this.NewApplicantsNotPopulated = deepcopythis.NewApplicantsNotPopulated;
      this.TotalAmountSpent = deepcopythis.TotalAmountSpent;
      this.NumberOfPositionsOpened = deepcopythis.NumberOfPositionsOpened;
      this.IsSocialMediaEnabled = deepcopythis.IsSocialMediaEnabled;
      this.IsJobPortalEnabled = deepcopythis.IsJobPortalEnabled;
      this.IsReferralEnabled = deepcopythis.IsReferralEnabled;
    }

    public void CompareAndApplyChanges(OpenPositions TempOpenPositions)
    {
      this.NumberOfPositionsOpened = TempOpenPositions.NumberOfPositionsOpened;
      this.IsSocialMediaEnabled = TempOpenPositions.IsSocialMediaEnabled;
      this.IsJobPortalEnabled = TempOpenPositions.IsJobPortalEnabled;
      this.IsReferralEnabled = TempOpenPositions.IsReferralEnabled;
    }

    public int GetCostPerDay() => JobApplicants_Calculator.CalculateTotalCostPerDay(this.NumberOfPositionsOpened, this.IsSocialMediaEnabled, this.IsJobPortalEnabled);

    public int GetTotalReach() => JobApplicants_Calculator.CalculateTotalReach(this.NumberOfPositionsOpened, this.IsSocialMediaEnabled, this.IsJobPortalEnabled);

    public int GetNumberOfApplicants() => this.NewApplicantsNotPopulated + this.Applicants.Count;

    public List<Applicant> GetAndPopulateApplicantsForDisplay()
    {
      int num = Math.Min(ApplicantGenerator.MaxApplicantsForDisplay - this.Applicants.Count, this.NewApplicantsNotPopulated);
      for (int index = 0; index < num; ++index)
        this.GenerateNewApplicantForThisPosition();
      return this.Applicants;
    }

    public Applicant GenerateNewApplicantForThisPosition()
    {
      if (this.NewApplicantsNotPopulated <= 0)
        throw new Exception("NO");
      Applicant newApplicant = ApplicantGenerator.CreateNewApplicant(this.tileType, this.RoamingEmployeeType, false);
      this.Applicants.Add(newApplicant);
      --this.NewApplicantsNotPopulated;
      return newApplicant;
    }

    public void RemoveApplicant(Applicant thisApplicant) => this.Applicants.Remove(thisApplicant);

    public void RemoveAndHireApplicant(Applicant thisApplicant)
    {
      this.RemoveApplicant(thisApplicant);
      if (this.NumberOfPositionsOpened > 0)
        --this.NumberOfPositionsOpened;
      if (this.NumberOfPositionsOpened != 0)
        return;
      this.Applicants.Clear();
      this.NewApplicantsNotPopulated = 0;
    }

    public OpenPositions(Reader reader)
    {
      int num1 = (int) reader.ReadInt("n", ref this.ShopUID);
      int _out = 0;
      int num2 = (int) reader.ReadInt("n", ref _out);
      this.tileType = (TILETYPE) _out;
      int num3 = (int) reader.ReadInt("n", ref this.DayStarted);
      int num4 = (int) reader.ReadInt("n", ref _out);
      this.Applicants = new List<Applicant>();
      for (int index = 0; index < _out; ++index)
        this.Applicants.Add(new Applicant(reader));
      int num5 = (int) reader.ReadInt("n", ref this.NewApplicantsNotPopulated);
      int num6 = (int) reader.ReadInt("n", ref this.TotalAmountSpent);
      int num7 = (int) reader.ReadInt("n", ref this.NumberOfPositionsOpened);
      int num8 = (int) reader.ReadBool("n", ref this.IsSocialMediaEnabled);
      int num9 = (int) reader.ReadBool("n", ref this.IsJobPortalEnabled);
      int num10 = (int) reader.ReadBool("n", ref this.IsReferralEnabled);
      int num11 = (int) reader.ReadInt("n", ref _out);
      this.RoamingEmployeeType = (EmployeeType) _out;
    }

    public void SaveOpenPositions(Writer writer)
    {
      writer.WriteInt("n", this.ShopUID);
      writer.WriteInt("n", (int) this.tileType);
      writer.WriteInt("n", this.DayStarted);
      writer.WriteInt("n", this.Applicants.Count);
      for (int index = 0; index < this.Applicants.Count; ++index)
        this.Applicants[index].SaveApplicant(writer);
      writer.WriteInt("n", this.NewApplicantsNotPopulated);
      writer.WriteInt("n", this.TotalAmountSpent);
      writer.WriteInt("n", this.NumberOfPositionsOpened);
      writer.WriteBool("n", this.IsSocialMediaEnabled);
      writer.WriteBool("n", this.IsJobPortalEnabled);
      writer.WriteBool("n", this.IsReferralEnabled);
      writer.WriteInt("n", (int) this.RoamingEmployeeType);
    }
  }
}
