// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.CurrentDeadAnimals
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System;
using System.Collections.Generic;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;

namespace TinyZoo.Z_BalanceSystems
{
  internal class CurrentDeadAnimals
  {
    internal static List<Vector2Int> DeadAnimalsByCellUID_AndCollector = new List<Vector2Int>();

    public static void AnimalDied_AddDeadAnimalDontKnowWhatToDoYet() => Console.WriteLine("animal died not added to list properly");

    public static void AddDeadAnimal(int CellBlockUID) => CurrentDeadAnimals.DeadAnimalsByCellUID_AndCollector.Add(new Vector2Int(CellBlockUID, 0));

    public static void RefreshMeatCollectorsJob(Player player)
    {
      List<Employee> employeesOfThisType = player.employees.GetEmployeesOfThisType(EmployeeType.MeatProcessorWorker);
      for (int index = 0; index < employeesOfThisType.Count; ++index)
        CustomerManager.GetThisEmployee(employeesOfThisType[index]).simperson.CheckJob();
    }

    public static void StartNewDay() => CurrentDeadAnimals.DeadAnimalsByCellUID_AndCollector = new List<Vector2Int>();
  }
}
