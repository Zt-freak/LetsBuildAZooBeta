// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Customers.NewCustomerCalculator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.BusTimetable;
using TinyZoo.Z_AnimalsAndPeople.Sim_Person;
using TinyZoo.Z_BalanceSystems.Animals;
using TinyZoo.Z_BalanceSystems.Customers.NewCustomers;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.Z_BalanceSystems.Customers
{
  internal class NewCustomerCalculator
  {
    private static BusPeopleAndRoutes[] buspeopleandroutes;
    private static List<VIP_Entry> VIPsToday;
    internal static int TotalPeopleWhoLeftBecauseOfProtestors;
    private static bool HasFootBallTeam;

    internal static void Calc_NewCustomers(Player player, float Popularity)
    {
      NewCustomerCalculator.buspeopleandroutes = new BusPeopleAndRoutes[10];
      Player.financialrecords.daystats[Player.financialrecords.daystats.Count - 1].PeopleWhoWantedToCome = 0;
      int _BasePeopleValue = 3 + (int) ((double) Popularity / 200.0 * 295.0);
      for (int index = 0; index < NewCustomerCalculator.buspeopleandroutes.Length; ++index)
        NewCustomerCalculator.buspeopleandroutes[index] = new BusPeopleAndRoutes(_BasePeopleValue, (BUSROUTE) index, player.busroutes.GetBussesByRoute((BUSROUTE) index).Count > 0);
      double num = (double) Popularity / 200.0;
    }

    internal static void AddVIPonTheFly(VIP_Entry entry) => NewCustomerCalculator.VIPsToday.Add(entry);

    internal static void SetUpVIP(Player player)
    {
      NewCustomerCalculator.TotalPeopleWhoLeftBecauseOfProtestors = 0;
      NewCustomerCalculator.VIPsToday = new List<VIP_Entry>();
      NewCustomerCalculator.HasFootBallTeam = false;
      if ((int) Player.financialrecords.GetDaysPassed() % 7 == 6 && player.heroquestprogress.ProgressArray[2].GetCompletetedQuests() > 0 && player.busroutes.GetBussesByRoute(BUSROUTE.Route01, BUSTYPE.StartingBus_01, true).Count > 0)
        NewCustomerCalculator.HasFootBallTeam = true;
      if (NewDay_ByPen.Day_CollectiveCorpses >= 1 && NewDay_ByPen.Day_CollectiveCorpseAge > 2)
      {
        for (int index = 0; index < 3; ++index)
        {
          if (!Z_DebugFlags.IsBetaVersion)
            NewCustomerCalculator.VIPsToday.Add(new VIP_Entry((AnimalType) Game1.Rnd.Next(391, 397), CustomerType.Protestor));
        }
      }
      if (Player.financialrecords.GetDaysPassed() % 8L == 3L)
        NewCustomerCalculator.VIPsToday.Add(new VIP_Entry(AnimalType.TigerKing, CustomerType.Count));
      else if (Player.financialrecords.GetDaysPassed() % 11L == 6L)
        NewCustomerCalculator.VIPsToday.Add(new VIP_Entry(AnimalType.TigerKing, CustomerType.Count));
      if (!player.Stats.TutorialsComplete[30] && Player.financialrecords.GetDaysPassed() > 0L)
        NewCustomerCalculator.VIPsToday.Add(new VIP_Entry(EnemyData.GetAnimalWelfarePerson(), CustomerType.AnimalWelfareOfficer));
      if (Player.criticalchoices.ChoiceIndexes[1] == -1 && player.Stats.variantsfound.GetTotalOfThisVariantFound(AnimalType.Horse, -1) > 0 && player.prisonlayout.GetTotalOfThisAnimal(AnimalType.Horse) > 0)
        NewCustomerCalculator.VIPsToday.Add(new VIP_Entry(AnimalType.SpecialEvent_Artist, CustomerType.AnimalArtist));
      if (Player.financialrecords.GetDaysPassed() != 7L)
        return;
      NewCustomerCalculator.VIPsToday.Add(new VIP_Entry(AnimalType.SpecialEvent_GenomeScientist, CustomerType.GenomeBetaGiver));
    }

    internal static void FinalizePropleWaitingRecordsAtEndOfDay()
    {
      if (NewCustomerCalculator.buspeopleandroutes == null)
        return;
      for (int index = 0; index < NewCustomerCalculator.buspeopleandroutes.Length; ++index)
        NewCustomerCalculator.buspeopleandroutes[index].FinalizePropleWaitingRecordsAtEndOfDay();
    }

    internal static int GetPeopleAtThisBusStop(
      BUSROUTE busroute,
      int MaximumPeopleOnThisBus,
      bool IsLastBus)
    {
      if (NewCustomerCalculator.buspeopleandroutes == null)
        return 0;
      int peopleForThisBus = NewCustomerCalculator.buspeopleandroutes[(int) busroute].GetPeopleForThisBus(MaximumPeopleOnThisBus, IsLastBus);
      if (NewCustomerCalculator.VIPsToday.Count > 0)
      {
        int num = 0;
        for (int index = 0; index < peopleForThisBus; ++index)
        {
          if (index < NewCustomerCalculator.VIPsToday.Count)
          {
            ++num;
            Z_GameFlags.SpecialPeopleOnBus.Add(NewCustomerCalculator.VIPsToday[index]);
          }
        }
        for (int index = num - 1; index > -1; --index)
          NewCustomerCalculator.VIPsToday.RemoveAt(index);
      }
      return peopleForThisBus;
    }
  }
}
