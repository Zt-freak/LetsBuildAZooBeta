// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.FeatureUnlock.FeatureUnlockSpeechPack
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_SummaryPopUps.FeatureUnlock
{
  internal class FeatureUnlockSpeechPack
  {
    public string textToSay;
    public AnimalType person;
    public string panelHeader;

    public FeatureUnlockSpeechPack(string _textToSay, AnimalType _person, string _panelHeader = "")
    {
      this.textToSay = _textToSay;
      this.person = _person;
      this.panelHeader = _panelHeader;
    }
  }
}
