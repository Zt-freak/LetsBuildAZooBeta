// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.TheDead
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_AnimalsAndPeople;

namespace TinyZoo.PlayerDir
{
  internal class TheDead
  {
    public int UID;
    public CauseOfDeath causeofdeath;

    public TheDead(int _UID, CauseOfDeath _causeofdeath)
    {
      this.causeofdeath = _causeofdeath;
      this.UID = _UID;
    }
  }
}
