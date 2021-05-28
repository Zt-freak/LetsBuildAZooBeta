// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.ZooMoment
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.PlayerDir
{
  internal class ZooMoment
  {
    public ZOOMOMENT zoomoment;
    public int TimeOfDay;
    public int UID;
    public bool StatsFlag;
    public int PenUID;
    public bool AllowUpdateDuringPopUp;

    public ZooMoment(ZOOMOMENT _zoomoment, int _TimeOfDay = -1, int _UID = -1, bool _AllowUpdateDuringPopUp = false)
    {
      this.AllowUpdateDuringPopUp = _AllowUpdateDuringPopUp;
      if (_TimeOfDay == -1)
        this.SetRandomTimeOfDay();
      else
        this.TimeOfDay = _TimeOfDay;
      this.UID = _UID;
      this.zoomoment = _zoomoment;
    }

    public ZooMoment(ZOOMOMENT _zoomoment, bool IsFamilyFight, int _PenUID = -1, int _UID = -1)
    {
      this.PenUID = _PenUID;
      this.zoomoment = _zoomoment;
      this.UID = _UID;
      this.StatsFlag = IsFamilyFight;
      this.SetRandomTimeOfDay();
    }

    private void SetRandomTimeOfDay() => this.TimeOfDay = Game1.Rnd.Next(0, (int) ((double) Z_GameFlags.SecondsInDay - 2.0));
  }
}
