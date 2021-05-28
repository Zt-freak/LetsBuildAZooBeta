// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.ZooQuest.ZQuest
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System;
using TinyZoo.Z_Quests;

namespace TinyZoo.PlayerDir.ZooQuest
{
  internal class ZQuest
  {
    public QuestPack Ref_questpack;
    private int ThisQuestIndex;
    public bool IsComplete;

    public ZQuest(int _ThisQuestIndex, QuestPack questpack)
    {
      this.ThisQuestIndex = _ThisQuestIndex;
      this.Ref_questpack = questpack;
    }

    public string GetQuestObjectiveDescription(CityName city, int CompletedQuestsHere) => QuestData.GetQuestset(city).GetQuestObjectiveDescription(CompletedQuestsHere);

    public void SetRefQuestPack() => throw new Exception("OImportant?");

    public ZQuest(Reader reader)
    {
      int num1 = (int) reader.ReadBool("q", ref this.IsComplete);
      int num2 = (int) reader.ReadInt("q", ref this.ThisQuestIndex);
    }

    public void SaveZQuest(Writer writer)
    {
      writer.WriteBool("q", this.IsComplete);
      writer.WriteInt("q", this.ThisQuestIndex);
    }
  }
}
