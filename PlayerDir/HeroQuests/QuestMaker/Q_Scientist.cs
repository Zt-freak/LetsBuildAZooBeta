// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.HeroQuests.QuestMaker.Q_Scientist
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.PlayerDir.HeroQuests.QuestMaker
{
  internal class Q_Scientist
  {
    internal static HeroQuestPack GetQuests()
    {
      int _UID = 0;
      HeroQuestPack heroQuestPack = new HeroQuestPack(AnimalType.SpecialEvent_Scientist, HeroCharacter.Scientist2);
      HeroQuestDescription questDescription1 = new HeroQuestDescription();
      questDescription1.SetUpDaysPassed(4);
      HeroQuestDescription questDescription2 = new HeroQuestDescription(ref _UID, HeroCharacter.Scientist2);
      questDescription2.ThisQuestHeading = StringID.SCIENTISTB1_Heading;
      questDescription2.ThisQuestDescriptin = StringID.SCIENTISTB1_Desc;
      questDescription2.SetUpEmployThisPerson(EmployeeType.Architect, 2);
      questDescription2.UnlockThisQuestCriteria = questDescription1;
      questDescription2.WillAutoPopOnComplete = true;
      questDescription2.TaskShortSummary = StringID.SCIENTISTB1_TaskSummary;
      heroQuestPack.heroquests.Add(questDescription2);
      return heroQuestPack;
    }
  }
}
