// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.HeroQuests.HeroQuestPack
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.PlayerDir.HeroQuests
{
  internal class HeroQuestPack
  {
    public List<HeroQuestDescription> heroquests;
    public AnimalType ThisCharacterAnimal = AnimalType.CleanerAsian;
    public HeroCharacter herocharacter;

    public HeroQuestPack(AnimalType thisanimaltype, HeroCharacter _herocharacter)
    {
      this.herocharacter = _herocharacter;
      this.ThisCharacterAnimal = thisanimaltype;
      this.heroquests = new List<HeroQuestDescription>();
    }

    public bool HasThisQuest(HeroQuestDescription heroquest)
    {
      for (int index = 0; index < this.heroquests.Count; ++index)
      {
        if (this.heroquests[index] == heroquest)
          return true;
      }
      return false;
    }
  }
}
