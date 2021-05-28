// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Garbage
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_Garbage;

namespace TinyZoo.PlayerDir
{
  internal class Garbage
  {
    public int TotalBins = 5;
    public float GarbageHeld;

    public void AddGarbageToBigGreenBins(float NewGarbage)
    {
      this.GarbageHeld += NewGarbage;
      Z_GarbageManager.CheckBins = true;
    }

    public void StartDay()
    {
      Z_GameFlags.TotalGarbageTrucksToComeToday = (int) this.GarbageHeld;
      Z_GarbageManager.StartDay();
    }

    public void RemoveGarbage(float GarbageTakenAway) => this.GarbageHeld -= GarbageTakenAway;
  }
}
