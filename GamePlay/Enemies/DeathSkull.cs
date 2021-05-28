// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.Enemies.DeathSkull
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GamePlay.Enemies
{
  internal class DeathSkull : GameObject
  {
    public DeathSkull()
    {
      this.DrawRect = new Rectangle(242, 36, 13, 13);
      this.SetDrawOriginToCentre();
    }

    public void UpdateDeathSkull()
    {
    }

    public void DrawDeathSkull() => this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet);
  }
}
