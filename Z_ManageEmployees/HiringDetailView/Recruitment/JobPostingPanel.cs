// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.JobPostingPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment
{
  internal class JobPostingPanel
  {
    public Vector2 location;
    private BigBrownPanel bigBrownPanel;
    private LerpHandler_Float lerper;
    private CurrentJobPostingFrame jobPostingFrame;
    private OpenPositions TEMPOPENPOSITIONS;

    public JobPostingPanel(
      ShopEntry shopEntry,
      OpenPositions _TEMPOPENPOSITIONS,
      Player player,
      float BaseScale,
      EmployeeType _RoamingEmplyeeType = EmployeeType.Count)
    {
      this.TEMPOPENPOSITIONS = _TEMPOPENPOSITIONS;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      double defaultYbuffer = (double) uiScaleHelper.GetDefaultYBuffer();
      double defaultXbuffer = (double) uiScaleHelper.GetDefaultXBuffer();
      float num = 0.0f;
      this.bigBrownPanel = new BigBrownPanel(Vector2.Zero, true, "Recruitment", BaseScale, true);
      this.jobPostingFrame = new CurrentJobPostingFrame(shopEntry, _TEMPOPENPOSITIONS, player, BaseScale, _RoamingEmplyeeType);
      this.jobPostingFrame.location.Y = num;
      Vector2 size = this.jobPostingFrame.GetSize();
      this.jobPostingFrame.location.Y += size.Y * 0.5f;
      float y = num + size.Y;
      this.bigBrownPanel.Finalize(new Vector2(size.X, y));
      this.jobPostingFrame.location.Y += this.bigBrownPanel.GetFrameOffsetFromTop().Y;
      this.lerper = new LerpHandler_Float();
      this.LerpIn();
    }

    public void LerpIn() => this.lerper.SetLerp(true, 1f, 0.0f, 3f);

    public void LerpOff() => this.lerper.SetLerp(false, 0.0f, 1f, 3f);

    public OpenPositions GetTempOpenPositions() => this.TEMPOPENPOSITIONS;

    public bool CheckMouseOver(Player player) => this.bigBrownPanel.CheckMouseOver(player, this.location);

    public bool UpdateJobPostingPanel(
      Player player,
      float DeltaTime,
      out bool GoToAgencyRecruit,
      out bool ExitCompletely)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      Vector2 location = this.location;
      GoToAgencyRecruit = false;
      ExitCompletely = false;
      if ((double) this.lerper.Value == 0.0)
      {
        this.jobPostingFrame.UpdateCurrentJobPostingFrame(player, DeltaTime, location);
        if (this.bigBrownPanel.UpdatePanelpreviousButton(player, DeltaTime, location))
          return true;
        if (this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, location))
        {
          ExitCompletely = true;
          return true;
        }
      }
      return false;
    }

    public void DrawJobPostingPanel(SpriteBatch spriteBatch)
    {
      if ((double) this.lerper.Value == 1.0)
        return;
      Vector2 location = this.location;
      location.X += this.lerper.Value * ManageEmployeeManager.LerpDistance;
      this.bigBrownPanel.DrawBigBrownPanel(location, spriteBatch);
      this.jobPostingFrame.DrawCurrentJobPostingFrame(location, spriteBatch);
    }
  }
}
