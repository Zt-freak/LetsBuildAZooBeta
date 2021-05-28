// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Employees.EmployeeCheck
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_BalanceSystems.Employees
{
  internal class EmployeeCheck
  {
    internal static void CheckEmployees(Player player)
    {
      for (int index = 0; index < player.shopstatus.shopentries.Count; ++index)
        player.shopstatus.shopentries[index].StartNewDay(player.livestats.SecondsZooWasOpen);
      JobApplicants_Calculator.CalculateJobApplicant_OnNewDay(player);
    }
  }
}
