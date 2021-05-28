// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Employees.JobApplicants_Calculator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment;
using TinyZoo.Z_Notification;

namespace TinyZoo.Z_BalanceSystems.Employees
{
  internal class JobApplicants_Calculator
  {
    public static int PopulationSize = 1000;
    private static int MaxCapForDaysOpenedUp = 10;

    public static void CalculateJobApplicant_OnNewDay(Player player)
    {
      List<OpenPositions> allOpenPositions = player.employees.openPositionsContainer.GetAllOpenPositions();
      int count = player.employees.employees.Count;
      float parkPopularity = ParkPopularity.GetParkPopularity(player);
      for (int index1 = 0; index1 < allOpenPositions.Count; ++index1)
      {
        int num1 = 0;
        int ofPositionsOpened = allOpenPositions[index1].NumberOfPositionsOpened;
        int totalReach = JobApplicants_Calculator.CalculateTotalReach(ofPositionsOpened, allOpenPositions[index1].IsSocialMediaEnabled, allOpenPositions[index1].IsJobPortalEnabled);
        int num2 = totalReach / 5;
        int num3 = (int) Player.financialrecords.GetDaysPassed() - allOpenPositions[index1].DayStarted;
        EmployeeType employeetype;
        if (allOpenPositions[index1].RoamingEmployeeType != EmployeeType.Count)
          employeetype = allOpenPositions[index1].RoamingEmployeeType;
        else
          EmployeeData.IsThisAnEmployee(EmployeeData.GetBuildingtoEmployee(allOpenPositions[index1].tileType, out bool _), out employeetype);
        int requirementForJob = JobApplicants_Calculator.GetSkillRequirementForJob(employeetype);
        int num4 = totalReach % 5;
        for (int index2 = 0; index2 < num2 * ofPositionsOpened; ++index2)
        {
          if ((num3 > JobApplicants_Calculator.MaxCapForDaysOpenedUp || Game1.Rnd.Next(0, JobApplicants_Calculator.MaxCapForDaysOpenedUp) < num3) && (Game1.Rnd.Next(0, 100) >= requirementForJob && (double) Game1.Rnd.Next(0, 100) < (double) parkPopularity))
            ++num1;
        }
        if (Z_DebugFlags.ForceNumberOfJobApplicantsEachDay != -1)
          num1 = Z_DebugFlags.ForceNumberOfJobApplicantsEachDay;
        if (Z_DebugFlags.IsBetaVersion && (employeetype == EmployeeType.Janitor || employeetype == EmployeeType.Architect) && (num1 == 0 && allOpenPositions[index1].GetNumberOfApplicants() == 0 && num3 == 1))
          ++num1;
        if (num1 > 0)
          Z_NotificationManager.RescrubJobApplicants = true;
        allOpenPositions[index1].NewApplicantsNotPopulated += num1;
        allOpenPositions[index1].TotalAmountSpent += JobApplicants_Calculator.CalculateTotalCostPerDay(ofPositionsOpened, allOpenPositions[index1].IsSocialMediaEnabled, allOpenPositions[index1].IsJobPortalEnabled);
        player.Stats.SpendCash(allOpenPositions[index1].TotalAmountSpent, SpendingCashOnThis.HiringCampaign, player);
      }
    }

    public static int GetSkillRequirementForJob(EmployeeType employeeType)
    {
      switch (employeeType)
      {
        case EmployeeType.Mascot:
          return 35;
        case EmployeeType.Guide:
          return 25;
        case EmployeeType.Janitor:
          return 5;
        case EmployeeType.Keeper:
          return 15;
        case EmployeeType.Vet:
          return 70;
        case EmployeeType.Mechanic:
          return 55;
        case EmployeeType.SecurityGuard:
          return 25;
        case EmployeeType.Architect:
          return 60;
        case EmployeeType.ShopKeeper:
          return 10;
        case EmployeeType.Breeder:
          return 50;
        case EmployeeType.DNAResearcher:
          return 99;
        case EmployeeType.MeatProcessorWorker:
          return 45;
        case EmployeeType.SlaughterhouseEmployee:
          return 40;
        case EmployeeType.FactoryWorker:
          return 40;
        case EmployeeType.Farmer:
          return 40;
        case EmployeeType.Surgeon:
          return 85;
        case EmployeeType.Trainer:
          return 60;
        case EmployeeType.AnimalPsycologist:
          return 60;
        default:
          return -1;
      }
    }

    public static int GetCostOfThisPerDay(JobPostingModifiers modifier)
    {
      switch (modifier)
      {
        case JobPostingModifiers.AdminCost:
          return 5;
        case JobPostingModifiers.SocialMedia:
          return 30;
        case JobPostingModifiers.JobPortal:
          return 50;
        default:
          return 0;
      }
    }

    public static int CalculateTotalReach(
      int NumberOfPositions,
      bool isSocialMediaEnabled,
      bool isJobPortalEnabled)
    {
      int num = 5;
      if (isSocialMediaEnabled)
        num += 20;
      if (isJobPortalEnabled)
        num += 25;
      return num * NumberOfPositions;
    }

    public static int CalculateTotalCostPerDay(
      int NumberOfPositions,
      bool isSocialMediaEnabled,
      bool isJobPortalEnabled)
    {
      int costOfThisPerDay = JobApplicants_Calculator.GetCostOfThisPerDay(JobPostingModifiers.AdminCost);
      if (isSocialMediaEnabled)
        costOfThisPerDay += JobApplicants_Calculator.GetCostOfThisPerDay(JobPostingModifiers.SocialMedia);
      if (isJobPortalEnabled)
        costOfThisPerDay += JobApplicants_Calculator.GetCostOfThisPerDay(JobPostingModifiers.JobPortal);
      return costOfThisPerDay * NumberOfPositions;
    }

    public static int GetMaximumOpenPositionsYouCanHave() => 4;
  }
}
