// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.HeroQuests.QuestMaker.Q_AnimalShelterGirl
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.PlayerDir.HeroQuests.QuestMaker
{
  internal class Q_AnimalShelterGirl
  {
    internal static HeroQuestPack GetQuests()
    {
      HeroQuestDescription questDescription1 = new HeroQuestDescription();
      if (Z_DebugFlags.IsBetaVersion)
        questDescription1.SetUpDaysPassed(20);
      else
        questDescription1.SetUpDaysPassed(10);
      int _UID = 0;
      HeroQuestPack heroQuestPack = new HeroQuestPack(AnimalType.AnimalShelterGirl, HeroCharacter.AnimalShelterGirl);
      HeroQuestDescription questDescription2 = new HeroQuestDescription(ref _UID, HeroCharacter.AnimalShelterGirl);
      questDescription2.ThisQuestHeading = StringID.ANIMALSHELTERGIRL_Heading;
      questDescription2.ThisQuestDescriptin = StringID.ANIMALSHELTERGIRL_Desc;
      questDescription2.SetUpGiveMoney(5000);
      questDescription2.UnlockThisQuestCriteria = questDescription1;
      questDescription2.TaskShortSummary = StringID.ANIMALSHELTERGIRL_TaskSummary;
      heroQuestPack.heroquests.Add(questDescription2);
      return heroQuestPack;
    }
  }
}
