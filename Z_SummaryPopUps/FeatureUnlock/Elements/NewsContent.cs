// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.NewsContent
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements.Specific;

namespace TinyZoo.Z_SummaryPopUps.FeatureUnlock.Elements
{
  internal class NewsContent
  {
    public Vector2 location;
    private CRISPRNewsLayout crispr;
    private ResearchHubNewsLayout researchHub;
    private LandExpansionNewsLayout landExpansion;
    private MoralityChoicesLayout morality;
    private FeatureUnlockDisplayType refUnlockType;

    public NewsContent(float BaseScale, FeatureUnlockDisplayType unlockType, float width)
    {
      this.refUnlockType = unlockType;
      this.SetUp(BaseScale, width);
    }

    public Vector2 GetSize()
    {
      switch (this.refUnlockType)
      {
        case FeatureUnlockDisplayType.ResearchHubUnlocked:
          return this.researchHub.GetSize();
        case FeatureUnlockDisplayType.LandExpansion:
          return this.landExpansion.GetSize();
        case FeatureUnlockDisplayType.CRIPSRUnlocked:
          return this.crispr.GetSize();
        case FeatureUnlockDisplayType.MoralityUsed:
          return this.morality.GetSize();
        default:
          return Vector2.Zero;
      }
    }

    private void SetUp(float BaseScale, float width)
    {
      switch (this.refUnlockType)
      {
        case FeatureUnlockDisplayType.ResearchHubUnlocked:
          this.researchHub = new ResearchHubNewsLayout(BaseScale, this.refUnlockType, width);
          break;
        case FeatureUnlockDisplayType.LandExpansion:
          this.landExpansion = new LandExpansionNewsLayout(BaseScale, this.refUnlockType, width);
          break;
        case FeatureUnlockDisplayType.CRIPSRUnlocked:
          this.crispr = new CRISPRNewsLayout(BaseScale, this.refUnlockType, width);
          break;
        case FeatureUnlockDisplayType.MoralityUsed:
          this.morality = new MoralityChoicesLayout(BaseScale, this.refUnlockType);
          break;
      }
    }

    public void DrawNewsContent(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      switch (this.refUnlockType)
      {
        case FeatureUnlockDisplayType.ResearchHubUnlocked:
          this.researchHub.DrawResearchHubNewsLayout(offset, spriteBatch);
          break;
        case FeatureUnlockDisplayType.LandExpansion:
          this.landExpansion.DrawLandExpansionNewsLayout(offset, spriteBatch);
          break;
        case FeatureUnlockDisplayType.CRIPSRUnlocked:
          this.crispr.DrawCRISPRNewsLayout(offset, spriteBatch);
          break;
        case FeatureUnlockDisplayType.MoralityUsed:
          this.morality.DrawMorality_PaintedAnimalLayout(offset, spriteBatch);
          break;
      }
    }
  }
}
