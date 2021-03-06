// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.PenNav.BouncingBallFriction
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_AnimalsAndPeople.PenNav
{
  internal class BouncingBallFriction
  {
    private float MovementMult;
    private float Friction;

    public void KnockBalls()
    {
      this.MovementMult = (float) Game1.Rnd.Next(60, 180);
      this.MovementMult *= 0.01f;
      this.Friction = (float) Game1.Rnd.Next(30, 100);
      this.Friction *= 0.01f;
    }

    public void UpdateBalls(ref float DeltaTime)
    {
      if ((double) this.MovementMult > 0.0)
      {
        this.MovementMult -= this.Friction * DeltaTime;
        if ((double) this.MovementMult < 0.0)
          this.MovementMult = 0.0f;
        DeltaTime *= this.MovementMult;
      }
      else
        DeltaTime = 0.0f;
    }
  }
}
