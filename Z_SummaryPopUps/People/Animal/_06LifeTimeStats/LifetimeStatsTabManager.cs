// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Animal._06LifeTimeStats.LifetimeStatsTabManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.PlayerDir.Layout;

namespace TinyZoo.Z_SummaryPopUps.People.Animal._06LifeTimeStats
{
  internal class LifetimeStatsTabManager
  {
    public Vector2 location;
    private StatsManager satsmanager;

    public LifetimeStatsTabManager(
      PrisonerInfo animal,
      Player player,
      float width,
      float BaseScale)
    {
      this.satsmanager = new StatsManager(animal, width, BaseScale);
    }

    public Vector2 GetSize() => this.satsmanager.GetSize();

    public void UpdateLifetimeStatsTabManager() => this.satsmanager.UpdateStatsManager();

    public void DrawLifetimeStatsTabManager(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.satsmanager.DrawStatsManager(offset, spriteBatch);
    }
  }
}
