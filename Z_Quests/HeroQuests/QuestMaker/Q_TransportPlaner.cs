// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Quests.HeroQuests.QuestMaker.Q_TransportPlaner
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.HeroQuests;

namespace TinyZoo.Z_Quests.HeroQuests.QuestMaker
{
  internal class Q_TransportPlaner
  {
    internal static HeroQuestPack GetQuests()
    {
      HeroQuestDescription questDescription1 = new HeroQuestDescription();
      if (Z_DebugFlags.IsBetaVersion)
        questDescription1.SetUpDaysPassed(20);
      else
        questDescription1.SetUpOtherHeroCharacterprogress(HeroCharacter.Mayor, 1);
      int _UID = 0;
      HeroQuestPack heroQuestPack = new HeroQuestPack(AnimalType.Mayor, HeroCharacter.TransportPlaner);
      HeroQuestDescription questDescription2 = new HeroQuestDescription(ref _UID, HeroCharacter.TransportPlaner);
      questDescription2.ThisQuestHeading = StringID.TRANSPORTPLANNER_Heading;
      int TargetRating = 100;
      questDescription2.ThisQuestDescriptin = StringID.TRANSPORTPLANNER_Desc;
      questDescription2.UseCustomQuestDescriptionString = true;
      questDescription2.SetUpParkRating(TargetRating);
      questDescription2.UnlockThisQuestCriteria = questDescription1;
      questDescription2.SetReward(new RewardPack(REWARDTYPE.BusRoute, 1));
      heroQuestPack.heroquests.Add(questDescription2);
      questDescription2.TaskShortSummary = StringID.TRANSPORTPLANNER_TaskSummary;
      return heroQuestPack;
    }
  }
}
