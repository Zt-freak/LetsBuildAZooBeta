// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Farms.CropInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_Farms
{
  internal class CropInfo
  {
    public float ExpectedYield;
    public float DaysToGrow;
    public float ProgressPerQuarterDay;

    public CropInfo(int _ExpectedYield, int _QuarterDaysToGrow)
    {
      this.DaysToGrow = (float) _QuarterDaysToGrow;
      this.ExpectedYield = (float) _ExpectedYield;
      this.ProgressPerQuarterDay = 1f / (float) _QuarterDaysToGrow;
    }
  }
}
