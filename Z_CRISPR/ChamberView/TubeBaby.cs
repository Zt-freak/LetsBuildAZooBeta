// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_CRISPR.ChamberView.TubeBaby
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using SEngine.Objects;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_CRISPR.ChamberView
{
  internal class TubeBaby
  {
    public Vector2 location;
    private SinSocillator Xoscillator;
    private SinSocillator Yoscillator;
    private GameObject someBlackThing;
    private EnemyRenderer animal;

    public TubeBaby(
      float babyProgress,
      AnimalType body,
      AnimalType head,
      int bodyVariant,
      int headVariant,
      float BaseScale)
    {
      if ((double) babyProgress >= 0.899999976158142)
      {
        this.animal = new EnemyRenderer(body, bodyVariant, head, headVariant);
        this.animal.scale = BaseScale;
        this.animal.SetAllColours(Color.Black.ToVector3());
        this.animal.vLocation.Y += (float) ((double) this.animal.DrawRect.Height * (double) this.animal.scale * (double) Sengine.ScreenRatioUpwardsMultiplier.Y * 0.5);
      }
      else
      {
        this.someBlackThing = new GameObject();
        this.someBlackThing.DrawRect = TinyZoo.Game1.WhitePixelRect;
        this.someBlackThing.scale = BaseScale * 2f;
        this.someBlackThing.SetDrawOriginToCentre();
        this.someBlackThing.SetAllColours(Color.Black.ToVector3());
      }
      this.Xoscillator = new SinSocillator(0.2f, BaseScale * 2f);
      this.Yoscillator = new SinSocillator(0.2f, BaseScale * 2f);
    }

    public Vector2 GetSize() => new Vector2((float) this.someBlackThing.DrawRect.Width, (float) this.someBlackThing.DrawRect.Height) * this.someBlackThing.scale;

    public void UpdateTubeBaby(float DeltaTime)
    {
      this.Xoscillator.UpdateSinOscillator(DeltaTime);
      this.Yoscillator.UpdateSinOscillator(DeltaTime);
    }

    public void DrawTubeBaby(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      if (this.someBlackThing != null)
        this.someBlackThing.Draw(spriteBatch, AssetContainer.SpriteSheet, offset + new Vector2(this.Xoscillator.CurrentOffset, this.Yoscillator.CurrentOffset));
      if (this.animal == null)
        return;
      this.animal.ScreenSpaceDrawEnemyRenderer(offset + new Vector2(this.Xoscillator.CurrentOffset, this.Yoscillator.CurrentOffset), spriteBatch);
    }
  }
}
