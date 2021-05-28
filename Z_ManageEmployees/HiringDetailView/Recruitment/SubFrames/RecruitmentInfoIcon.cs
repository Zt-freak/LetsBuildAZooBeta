// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames.RecruitmentInfoIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames
{
  internal class RecruitmentInfoIcon : GameObject
  {
    public RecruitmentInfoIcon(JobPostingModifiers infoType, float BaseScale)
    {
      this.scale = BaseScale;
      switch (infoType)
      {
        case JobPostingModifiers.AdminCost:
          this.DrawRect = new Rectangle(962, 144, 20, 20);
          break;
        case JobPostingModifiers.SocialMedia:
          this.DrawRect = new Rectangle(962, 165, 20, 20);
          break;
        case JobPostingModifiers.JobPortal:
          this.DrawRect = new Rectangle(941, 168, 20, 20);
          break;
      }
      this.SetDrawOriginToCentre();
    }

    public Vector2 GetSize() => new Vector2((float) this.DrawRect.Width * this.scale, (float) this.DrawRect.Height * this.scale) * Sengine.ScreenRatioUpwardsMultiplier;

    public void DrawRecruitmentInfoIcon(Vector2 offset, SpriteBatch spriteBatch) => this.Draw(spriteBatch, AssetContainer.SpriteSheet, offset);
  }
}
