// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Morality.Morality_UnionCalculator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System;

namespace TinyZoo.Z_Morality
{
  internal class Morality_UnionCalculator
  {
    internal static void CalculateMorality(Player player, ref float MoralityScore)
    {
      int pointBalance = player.unions.GetPointBalance();
      float num1 = 2f;
      float num2 = 0.0f;
      for (int index = 0; index < Math.Abs(pointBalance); ++index)
      {
        num2 += num1;
        if ((double) num1 > 0.100000001490116)
        {
          if ((double) num1 > 1.0)
            num1 -= 0.2f;
          else if ((double) num1 > 0.5)
          {
            num1 -= 0.1f;
          }
          else
          {
            num1 -= 0.05f;
            if ((double) num1 < 0.100000001490116)
              num1 = 0.1f;
          }
        }
      }
      if ((double) num2 > (double) MoralityData.MaxUnionScale)
        num2 = 20f;
      if (pointBalance < 0)
        num2 = -num2;
      MoralityScore += num2;
    }
  }
}
