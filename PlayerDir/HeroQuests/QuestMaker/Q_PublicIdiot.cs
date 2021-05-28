// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.HeroQuests.QuestMaker.Q_PublicIdiot
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;
using TinyZoo.Tile_Data;

namespace TinyZoo.PlayerDir.HeroQuests.QuestMaker
{
  internal class Q_PublicIdiot
  {
    internal static HeroQuestPack GetQuests()
    {
      int _UID = 0;
      HeroQuestPack heroQuestPack = new HeroQuestPack(AnimalType.AfroOldLady, HeroCharacter.Complainer);
      HeroQuestDescription questDescription1 = new HeroQuestDescription();
      questDescription1.SetUpDaysPassed(1);
      HeroQuestDescription questDescription2 = new HeroQuestDescription(ref _UID, HeroCharacter.Complainer);
      questDescription2.ThisQuestHeading = StringID.PUBIDIOT_Heading;
      questDescription2.ThisQuestDescriptin = StringID.PUBIDIOT_Desc;
      questDescription2.SetUpThingsBuilt(1, TILETYPE.StoreRoom);
      questDescription2.UnlockThisQuestCriteria = questDescription1;
      questDescription2.TaskShortSummary = StringID.PUBIDIOT_TaskSummary;
      heroQuestPack.heroquests.Add(questDescription2);
      HeroQuestDescription questDescription3 = new HeroQuestDescription(ref _UID, HeroCharacter.Complainer);
      questDescription3.ThisQuestHeading = StringID.PUBIDIOT_Heading2;
      questDescription3.ThisQuestDescriptin = StringID.PUBIDIOT_Desc2;
      questDescription3.SetUpEmployThisPerson(EmployeeType.Janitor);
      HeroQuestDescription questDescription4 = new HeroQuestDescription();
      questDescription4.SetUpUnlockAtStartOfGame();
      questDescription3.UnlockThisQuestCriteria = questDescription4;
      questDescription3.WillAutoPopOnComplete = true;
      questDescription3.TaskShortSummary = StringID.PUBIDIOT_TaskSummary2;
      heroQuestPack.heroquests.Add(questDescription3);
      return heroQuestPack;
    }
  }
}
