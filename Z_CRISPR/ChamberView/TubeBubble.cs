// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_CRISPR.ChamberView.TubeBubble
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using SEngine.Objects;

namespace TinyZoo.Z_CRISPR.ChamberView
{
  internal class TubeBubble : GameObject
  {
    private Rectangle bigBubble = new Rectangle(159, 766, 4, 4);
    private Rectangle smallBubble = new Rectangle(162, 770, 3, 3);
    private float Speed;
    private SinSocillator oscilator;
    private float maxHeight;
    private float BaseScale;
    private float minX;
    private float maxX;
    private bool ReadyToCreateNewBubble;
    private float reSpawnTimer;
    private float reSpawnMin = 0.5f;
    private float reSpawnMax = 3f;
    private float nextreSpawnTime;

    public TubeBubble(float _BaseScale, float _maxHeight, float _minX, float _maxX)
    {
      this.maxHeight = _maxHeight;
      this.BaseScale = _BaseScale;
      this.minX = _minX;
      this.maxX = _maxX;
      this.SetToCreateNewBubble();
    }

    public void SetToCreateNewBubble()
    {
      this.ReadyToCreateNewBubble = true;
      this.nextreSpawnTime = MathStuff.getRandomFloat(this.reSpawnMin, this.reSpawnMax);
    }

    public void CreateBubble()
    {
      this.bActive = true;
      this.reSpawnTimer = 0.0f;
      this.ReadyToCreateNewBubble = false;
      float _XScale = MathStuff.getRandomFloat(0.1f, 1f) * this.BaseScale;
      this.oscilator = new SinSocillator(MathStuff.getRandomFloat(0.2f, 0.6f), _XScale);
      if (TinyZoo.Game1.Rnd.Next(0, 2) == 0)
        this.DrawRect = this.bigBubble;
      else
        this.DrawRect = this.smallBubble;
      this.scale = this.BaseScale;
      this.SetDrawOriginToPoint(DrawOriginPosition.CentreBottom);
      this.vLocation.X = MathStuff.getRandomFloat(this.minX + (float) ((double) this.DrawRect.Width * (double) this.scale * 0.5) + _XScale, this.maxX - (float) ((double) this.DrawRect.Width * (double) this.scale * 0.5) - _XScale);
      this.vLocation.Y = 0.0f;
      int num = TinyZoo.Game1.Rnd.Next(0, 7);
      if (num == 0)
        this.Speed = MathStuff.getRandomFloat(10f, 15f);
      else if (num < 4)
      {
        this.Speed = MathStuff.getRandomFloat(0.5f, 2f);
      }
      else
      {
        if (num >= 7)
          return;
        this.Speed = MathStuff.getRandomFloat(3f, 6f);
      }
    }

    public void UpdateTubeBubble(float DeltaTime)
    {
      if (this.ReadyToCreateNewBubble)
      {
        this.reSpawnTimer += DeltaTime;
        if ((double) this.reSpawnTimer > (double) this.nextreSpawnTime)
          this.CreateBubble();
      }
      this.UpdateColours(DeltaTime);
      if (!this.bActive)
        return;
      this.oscilator.UpdateSinOscillator(DeltaTime);
      this.vLocation.Y -= DeltaTime * this.Speed;
      if ((double) this.vLocation.Y >= -(double) this.maxHeight + (double) this.DrawRect.Height * (double) this.scale * (double) Sengine.ScreenRatioUpwardsMultiplier.Y)
        return;
      this.bActive = false;
      this.SetToCreateNewBubble();
    }

    public void DrawTubeBubble(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.vLocation;
      if (!this.bActive)
        return;
      this.Draw(spriteBatch, AssetContainer.SpriteSheet, offset + new Vector2(this.oscilator.CurrentOffset, 0.0f));
    }
  }
}
