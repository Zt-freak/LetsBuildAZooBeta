// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.beams.BeamSpawnEffect
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GamePlay.beams
{
  internal class BeamSpawnEffect : AnimatedGameObject
  {
    private AnimatedGameObject Ring;

    public BeamSpawnEffect(Vector2 Location)
    {
      this.vLocation = Location;
      this.DrawRect = new Rectangle(0, 89, 39, 40);
      this.SetDrawOriginToCentre();
      this.SetUpSimpleAnimation(5, 0.06f);
      this.PlayOnlyOnce = true;
      this.Ring = new AnimatedGameObject();
      this.Ring.DrawRect = new Rectangle(0, 130, 39, 40);
      this.Ring.SetDrawOriginToCentre();
      this.Ring.SetUpSimpleAnimation(5, 0.06f);
      this.Ring.PlayOnlyOnce = true;
      this.Ring.scale = 0.5f;
      this.Ring.vLocation = Location;
      this.bActive = true;
    }

    public void UpdateBeamSpawnEffect(float DeltaTime)
    {
      if (this.Ring.UpdateAnimation(DeltaTime))
        this.bActive = false;
      this.UpdateAnimation(DeltaTime);
    }

    public void DrawBeamSpawnEffect()
    {
      if (!this.bActive)
        return;
      this.WorldOffsetDraw(AssetContainer.PointBlendBatch02, AssetContainer.SpriteSheet);
      this.Ring.WorldOffsetDraw(AssetContainer.PointBlendBatch02, AssetContainer.SpriteSheet);
    }
  }
}
