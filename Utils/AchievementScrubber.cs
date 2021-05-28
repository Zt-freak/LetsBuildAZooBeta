// Decompiled with JetBrains decompiler
// Type: TinyZoo.Utils.AchievementScrubber
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SpringSocial;

namespace TinyZoo.Utils
{
  internal class AchievementScrubber
  {
    internal static void ScrubAllAchievements(Player player)
    {
      int typeForThisPlatform = (int) SocialManagerMain.GetBestSocialTypeForThisPlatform();
    }
  }
}
