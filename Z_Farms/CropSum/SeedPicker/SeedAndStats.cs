// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Farms.CropSum.SeedPicker.SeedAndStats
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.PlayerDir.Farms_;

namespace TinyZoo.Z_Farms.CropSum.SeedPicker
{
  internal class SeedAndStats
  {
    private SeedIcon seedicon;

    public SeedAndStats(CROPTYPE seedtype, float BaseScale) => this.seedicon = new SeedIcon(seedtype, BaseScale);

    public void UpdateSeedAndStats()
    {
    }

    public void Drawv(SpriteBatch spritebatch, Vector2 Offset) => this.seedicon.DrawSeedIcon(spritebatch, Offset);
  }
}
