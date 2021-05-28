// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames.CampaignReachBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.Z_BalanceSystems.Employees;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer.SatisfactionBars;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames
{
  internal class CampaignReachBar
  {
    public Vector2 location;
    private SatisfactionBar satisfactionBar;
    private ZGenericText barLabel;
    private Vector3 originalBarColour;
    private string baseString;

    public CampaignReachBar(OpenPositions TEMPOPENPOSITIONS, float BaseScale)
    {
      this.satisfactionBar = new SatisfactionBar(1f, BaseScale, BarSIze.Thin);
      this.originalBarColour = this.satisfactionBar.GetColourAsVector3();
      this.baseString = "Estimated Reach: {0}/{1}";
      this.barLabel = new ZGenericText(this.baseString, BaseScale);
      this.barLabel.vLocation.Y -= (float) ((double) this.barLabel.GetSize().Y * 0.5 + (double) this.satisfactionBar.GetSize().Y * 0.5);
      this.SetNewNumbers(TEMPOPENPOSITIONS);
    }

    public void SetNewNumbers(OpenPositions TEMPOPENPOSITIONS)
    {
      int totalReach = TEMPOPENPOSITIONS.GetTotalReach();
      int populationSize = JobApplicants_Calculator.PopulationSize;
      this.barLabel.textToWrite = string.Format(this.baseString, (object) TEMPOPENPOSITIONS.GetTotalReach(), (object) populationSize);
      this.satisfactionBar.SetFullness((float) totalReach / (float) populationSize);
    }

    public void SetActive(bool _isActive)
    {
      if (_isActive)
      {
        this.satisfactionBar.SetAllColours(Color.White.ToVector3());
        this.barLabel.SetAllColours(ColourData.Z_Cream);
      }
      else
      {
        this.satisfactionBar.SetAllColours(Color.DarkGray.ToVector3());
        this.barLabel.SetAllColours(Color.LightGray.ToVector3());
      }
    }

    public Vector2 GetSize() => new Vector2(this.satisfactionBar.GetSize().X, this.satisfactionBar.GetSize().Y + this.barLabel.GetSize().Y);

    public float GetExtraTextOffsetFromTop() => this.barLabel.GetSize().Y;

    public void UpdateCampaignReachBar(Vector2 offset)
    {
    }

    public void DrawCampaignReachBar(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.satisfactionBar.DrawSatisfactionBar(offset, spriteBatch);
      this.barLabel.DrawZGenericText(offset, spriteBatch);
    }
  }
}
