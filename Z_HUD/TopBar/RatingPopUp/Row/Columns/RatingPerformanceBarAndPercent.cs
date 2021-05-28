// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.TopBar.RatingPopUp.Row.Columns.RatingPerformanceBarAndPercent
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_BalanceSystems.Park;

namespace TinyZoo.Z_HUD.TopBar.RatingPopUp.Row.Columns
{
  internal class RatingPerformanceBarAndPercent : SatisfactionBarWithBigNumber
  {
    public RatingPerformanceBarAndPercent(RatingCategory category, Player player, float BaseScale)
      : base(BaseScale)
    {
      this.SetValues(category, player);
    }

    public void SetValues(RatingCategory category, Player player) => this.SetBarValues(RatingPerformanceBarAndPercent.GetPerformancePercentageFloat(category, player));

    private static float GetPerformancePercentageFloat(RatingCategory category, Player player)
    {
      switch (category)
      {
        case RatingCategory.Facilities:
          return 0.0f;
        case RatingCategory.Animals:
          return 0.0f;
        case RatingCategory.Decoration:
          return DecoCalculator.OverallDecoEfficiiency;
        case RatingCategory.Publicity:
          return 0.0f;
        default:
          return -1f;
      }
    }

    public void UpdateRatingPerformanceBarAndPercent()
    {
    }

    public void DrawRatingPerformanceBarAndPercent(Vector2 offset, SpriteBatch spriteBatch) => this.DrawSatisfactionBarWithBigNumber(offset, spriteBatch);
  }
}
