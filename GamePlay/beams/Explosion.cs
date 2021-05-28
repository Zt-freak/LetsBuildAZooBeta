// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.beams.Explosion
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GamePlay.beams
{
  internal class Explosion : AnimatedGameObject
  {
    public Explosion(Vector2 Location) => this.Reset(Location);

    public void Reset(Vector2 Location)
    {
      this.vLocation = Location;
      this.DrawRect = new Rectangle(0, 192, 38, 32);
      this.SetDrawOriginToCentre();
      this.SetUpSimpleAnimation(7, 0.1f);
      this.bActive = true;
      this.PlayOnlyOnce = true;
    }

    public void UpdateExplosion(float DeltaTime)
    {
      if (!this.UpdateAnimation(DeltaTime))
        return;
      this.bActive = false;
    }

    public void DrawExplosion()
    {
      if (!this.bActive)
        return;
      this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet);
    }
  }
}
