// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Quests.QuestSet
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_Quests
{
  internal class QuestSet
  {
    public List<QuestPack> questshere;
    public int UnlockedAtThisMantCompleteQuests;

    public QuestSet(int _UnlockedAtThisMantCompleteQuests)
    {
      this.UnlockedAtThisMantCompleteQuests = _UnlockedAtThisMantCompleteQuests;
      this.questshere = new List<QuestPack>();
    }

    public QuestPack GetCurrentQuest(int CompletedQeuests) => CompletedQeuests >= this.questshere.Count ? (QuestPack) null : this.questshere[CompletedQeuests];

    public string GetQuestObjectiveDescription(int Completed) => Completed == -1 ? "ERROR STRING" : this.questshere[Completed].GetQuestObjectiveDescription();

    public bool WillUnlockThisAnimal(AnimalType animaltype)
    {
      for (int index = 0; index < this.questshere.Count; ++index)
      {
        if (this.questshere[index].GetThisAnimal == animaltype)
          return true;
      }
      return false;
    }
  }
}
