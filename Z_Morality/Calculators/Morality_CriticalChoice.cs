// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Morality.Calculators.Morality_CriticalChoice
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;

namespace TinyZoo.Z_Morality.Calculators
{
  internal class Morality_CriticalChoice
  {
    internal static void CalculateMorality_CriticalChoice(ref float MoralityScore)
    {
      int num = MathHelper.Clamp((Player.criticalchoices.GoodCoicesMade - Player.criticalchoices.BadChoicesMade) * 5, -30, 30);
      MoralityScore += (float) num;
    }
  }
}
