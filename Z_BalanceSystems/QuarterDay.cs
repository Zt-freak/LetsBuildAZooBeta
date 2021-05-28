// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.QuarterDay
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_BalanceSystems.Animals;

namespace TinyZoo.Z_BalanceSystems
{
  internal class QuarterDay
  {
    internal static void StartQuarterDay(int QuarterIndex, Player player)
    {
      NewQuarterDayByPen.DoQuarterDay(player, QuarterIndex);
      player.farms.StartNewQuarterDay(player);
    }
  }
}
