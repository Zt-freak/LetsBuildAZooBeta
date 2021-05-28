// Decompiled with JetBrains decompiler
// Type: TinyZoo.Blance.PReq
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine.Objects;

namespace TinyZoo.Blance
{
  internal class PReq
  {
    public int[] Uses;
    public NumberObfiscatorV1 VPM;
    public NumberObfiscatorV1 TRCST;
    public int CellRequirement;

    public PReq()
    {
      this.VPM = new NumberObfiscatorV1();
      this.Uses = new int[10];
      this.TRCST = new NumberObfiscatorV1();
    }
  }
}
