// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_CRISPR.ChamberView.AnimalInTube
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_CRISPR.ChamberView
{
  internal class AnimalInTube
  {
    public Vector2 location;
    private GameObject tube;
    private GameObject tubeOverlay;
    private TubeBubbles tubeBubbles;
    private TubeBaby tubeBaby;

    public AnimalInTube(
      AnimalType body,
      AnimalType head,
      int bodyVariant,
      int headVariant,
      float BaseScale,
      float BabyProgress = 1f)
    {
      this.tube = new GameObject();
      this.tube.DrawRect = new Rectangle(432, 960, 56, 64);
      this.tube.SetDrawOriginToCentre();
      this.tube.scale = BaseScale;
      this.tubeOverlay = new GameObject();
      this.tubeOverlay.DrawRect = new Rectangle(489, 960, 56, 64);
      this.tubeOverlay.SetDrawOriginToCentre();
      this.tubeOverlay.scale = BaseScale;
      float num = 6f * this.tube.scale;
      this.tubeBaby = new TubeBaby(BabyProgress, body, head, bodyVariant, headVariant, BaseScale);
      this.tubeBaby.location.Y += num * Sengine.ScreenRatioUpwardsMultiplier.Y;
      this.tubeBubbles = new TubeBubbles(10, 20, (float) -this.tube.DrawRect.Width * 0.25f * this.tube.scale, (float) this.tube.DrawRect.Width * 0.25f * this.tube.scale, (float) (0.5 * ((double) this.tube.DrawRect.Height * (double) this.tube.scale - (double) num)) * Sengine.ScreenRatioUpwardsMultiplier.Y, BaseScale);
      this.tubeBubbles.location.Y += (float) ((double) this.tube.DrawRect.Height * (double) this.tube.scale * 0.5);
    }

    public Vector2 GetSize() => new Vector2((float) this.tube.DrawRect.Width, (float) this.tube.DrawRect.Height) * this.tube.scale * Sengine.ScreenRatioUpwardsMultiplier;

    public void UpdateAnimalInTube(float DeltaTime)
    {
      this.tubeBubbles.UpdateTubeBubbles(DeltaTime);
      if (this.tubeBaby == null)
        return;
      this.tubeBaby.UpdateTubeBaby(DeltaTime);
    }

    public void DrawAnimalInTube(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.tube.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
      if (this.tubeBaby != null)
        this.tubeBaby.DrawTubeBaby(offset, spriteBatch);
      this.tubeBubbles.DrawTubeBubbles(offset, spriteBatch);
      this.tubeOverlay.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
    }
  }
}
