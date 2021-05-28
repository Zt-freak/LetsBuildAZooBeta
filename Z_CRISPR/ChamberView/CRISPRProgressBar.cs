// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_CRISPR.ChamberView.CRISPRProgressBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.PlayerDir.CRISPR;
using TinyZoo.Z_BalanceSystems.Animals.CRISPR;
using TinyZoo.Z_BreedResult.VariantDiscovered;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_CRISPR.ChamberView
{
  internal class CRISPRProgressBar
  {
    private ProgressBarWithPointer progressBar;
    public Vector2 Location;
    private DNAIcon dnaIcon;
    private float iconBarBuffer;

    public CRISPRProgressBar(
      CrisprActiveBreed breed,
      float BaseScale,
      bool DrawHeader = true,
      bool DrawDNAicon = false)
    {
      string empty = string.Empty;
      string headerText = string.Empty;
      float forThisCrisprBreed = CRISPRCalculator.GetDaysForThisCRISPRBreed(breed.genomeOne, breed.genomeTwo);
      double num = (double) forThisCrisprBreed - (double) breed.DaysLeft;
      string pointerText = (double) breed.DaysLeft != 1.0 ? breed.DaysLeft.ToString() + " days" : breed.DaysLeft.ToString() + " day";
      if (DrawHeader)
        headerText = "CRISPR Progress";
      float progress = (float) num / forThisCrisprBreed;
      this.progressBar = new ProgressBarWithPointer(pointerText, progress, BaseScale, headerText);
      this.progressBar.SetTint(new Vector3(0.8901961f, 0.6196079f, 0.4666667f));
      this.progressBar.SetPointerColor(new Vector3(0.9686275f, 0.8509804f, 0.6235294f), false);
      if (!DrawDNAicon)
        return;
      this.iconBarBuffer = 15f * BaseScale;
      this.dnaIcon = new DNAIcon(BaseScale);
      this.dnaIcon.SetUpSimpleAnimation();
      this.dnaIcon.SetDrawOriginToCentre();
      this.dnaIcon.vLocation.X = (float) (-(double) this.progressBar.GetWidth() * 0.5 - (double) this.dnaIcon.GetSize().X * 0.5);
      this.dnaIcon.vLocation.X -= this.iconBarBuffer;
    }

    public Vector2 GetBarSize() => new Vector2(this.progressBar.GetWidth(), this.progressBar.GetHeight());

    public float GetExtraOffsetFromTop() => this.progressBar.GetExtraOffsetFromTop();

    public void UpdateCRISPRProgressBar(float DeltaTime)
    {
      if (this.dnaIcon == null)
        return;
      this.dnaIcon.UpdateDNAIconAnimation(DeltaTime);
    }

    public float GetExtraIconOffset()
    {
      float num = 0.0f;
      if (this.dnaIcon != null)
        num += this.dnaIcon.GetSize().X + this.iconBarBuffer;
      return num;
    }

    public void DrawCRISPRProgressBar(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.Location;
      this.progressBar.DrawProgressBar(offset, spriteBatch);
      if (this.dnaIcon == null)
        return;
      this.dnaIcon.DrawDNAIcon(offset, spriteBatch);
    }
  }
}
