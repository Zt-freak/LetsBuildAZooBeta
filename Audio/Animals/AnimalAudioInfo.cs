// Decompiled with JetBrains decompiler
// Type: TinyZoo.Audio.Animals.AnimalAudioInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;

namespace TinyZoo.Audio.Animals
{
  internal class AnimalAudioInfo
  {
    public List<AnimalAudioSet> animalaudiosets;

    public AnimalAudioInfo() => this.animalaudiosets = new List<AnimalAudioSet>();

    public void AddSet(AnimalAudioSet animalaudioset) => this.animalaudiosets.Add(animalaudioset);

    public AnimalAudioSet GetAudioSet()
    {
      if (this.animalaudiosets.Count > 1)
        return this.animalaudiosets[Game1.Rnd.Next(0, this.animalaudiosets.Count)];
      return this.animalaudiosets.Count > 0 ? this.animalaudiosets[0] : (AnimalAudioSet) null;
    }
  }
}
