// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Quests.Advice.GetReason
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_Quests.Advice
{
  internal class GetReason
  {
    public static int GetHungerReason(Player player, int animalUID) => Game1.Rnd.Next(0, 4);
  }
}
