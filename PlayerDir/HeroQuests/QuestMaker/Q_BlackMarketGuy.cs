// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.HeroQuests.QuestMaker.Q_BlackMarketGuy
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.PlayerDir.HeroQuests.QuestMaker
{
  internal class Q_BlackMarketGuy
  {
    internal static HeroQuestPack GetQuests()
    {
      HeroQuestDescription questDescription1 = new HeroQuestDescription();
      questDescription1.SetUpDaysPassed(3);
      int _UID = 0;
      HeroQuestPack heroQuestPack = new HeroQuestPack(AnimalType.TigerKing, HeroCharacter.BlackMarketGuy);
      HeroQuestDescription questDescription2 = new HeroQuestDescription(ref _UID, HeroCharacter.BlackMarketGuy);
      questDescription2.ThisQuestHeading = StringID.BLACKMARKEYGUY_Heading;
      questDescription2.ThisQuestDescriptin = StringID.BLACKMARKEYGUY_Desc;
      questDescription2.SetUpBuyAnimalFromBlackMarket(1);
      questDescription2.UnlockThisQuestCriteria = questDescription1;
      questDescription2.TaskShortSummary = StringID.BLACKMARKEYGUY_TaskSummary;
      heroQuestPack.heroquests.Add(questDescription2);
      return heroQuestPack;
    }
  }
}
