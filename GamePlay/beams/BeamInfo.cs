// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.beams.BeamInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.GamePlay.beams
{
  internal class BeamInfo
  {
    public float BeamSpeed;
    public bool IsInstantBeam;

    public BeamInfo(Player player) => this.SetSpeed(ref this.BeamSpeed, player.inventory.BeamSpdUpgrades.SmartGetValue(true));

    public BeamInfo(bool __IsInstantBeam) => this.IsInstantBeam = __IsInstantBeam;

    private void SetSpeed(ref float Speed, int Level)
    {
      Speed = 20f;
      Speed += (float) (Level * 5);
    }
  }
}
