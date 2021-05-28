// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.CurrentJobPostingFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Tile_Data;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment.SubFrames;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageEmployees.HiringDetailView.Recruitment
{
  internal class CurrentJobPostingFrame
  {
    public Vector2 location;
    private CustomerFrame customerFrame;
    private MiniHeading miniHeading;
    private OpenPositionsFrame openJobPositionsFrame;
    private List<PostingInfoFrame> modifiersFrames;
    private CampaignSummaryFrame campaignSummaryFrame;

    public CurrentJobPostingFrame(
      ShopEntry shopEntry,
      OpenPositions TEMPOPENPOSITIONS,
      Player player,
      float BaseScale,
      EmployeeType _RoamingEmplyeeType = EmployeeType.Count)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float defaultYbuffer = uiScaleHelper.GetDefaultYBuffer();
      float defaultXbuffer = uiScaleHelper.GetDefaultXBuffer();
      float num1 = 0.0f;
      Vector2 vector2_1 = Vector2.One * 10f;
      string str = "Recruitment Campaign: ";
      this.miniHeading = new MiniHeading(Vector2.Zero, _RoamingEmplyeeType == EmployeeType.Count ? str + TileData.GetTileStats(shopEntry.tiletype).Name : str + Employees.GetEmployeeThypeToString(_RoamingEmplyeeType), 1f, BaseScale);
      float num2 = num1 + (this.miniHeading.GetTextHeight(true) + uiScaleHelper.ScaleY(vector2_1.Y) + defaultYbuffer);
      float forceWidth = 325f * BaseScale;
      this.openJobPositionsFrame = new OpenPositionsFrame(TEMPOPENPOSITIONS, forceWidth, BaseScale, shopEntry, player);
      this.openJobPositionsFrame.location.Y += num2 + this.openJobPositionsFrame.GetSize().Y * 0.5f;
      float num3 = num2 + this.openJobPositionsFrame.GetSize().Y + defaultYbuffer;
      this.modifiersFrames = new List<PostingInfoFrame>();
      for (int index = 0; index < 3; ++index)
      {
        PostingInfoFrame postingInfoFrame = new PostingInfoFrame((JobPostingModifiers) index, TEMPOPENPOSITIONS, forceWidth, BaseScale);
        postingInfoFrame.location.Y += num3 + postingInfoFrame.GetSize().Y * 0.5f;
        num3 = num3 + postingInfoFrame.GetSize().Y + defaultYbuffer;
        this.modifiersFrames.Add(postingInfoFrame);
      }
      this.campaignSummaryFrame = new CampaignSummaryFrame(TEMPOPENPOSITIONS, forceWidth, BaseScale);
      this.campaignSummaryFrame.location.Y += num3 + this.campaignSummaryFrame.GetSize().Y * 0.5f;
      float y = num3 + this.campaignSummaryFrame.GetSize().Y + defaultYbuffer;
      this.customerFrame = new CustomerFrame(new Vector2(forceWidth + defaultXbuffer * 2f, y), true, BaseScale);
      this.miniHeading.SetTextPosition(this.customerFrame.VSCale, vector2_1.X, vector2_1.Y);
      Vector2 vector2_2 = -this.customerFrame.VSCale * 0.5f;
      this.openJobPositionsFrame.location.Y += vector2_2.Y;
      for (int index = 0; index < this.modifiersFrames.Count; ++index)
        this.modifiersFrames[index].location.Y += vector2_2.Y;
      this.campaignSummaryFrame.location.Y += vector2_2.Y;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public void UpdateCurrentJobPostingFrame(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      if (this.openJobPositionsFrame.UpdateOpenPositionsFrame(player, DeltaTime, offset))
      {
        for (int index = 0; index < this.modifiersFrames.Count; ++index)
          this.modifiersFrames[index].ReflectNewData();
        this.campaignSummaryFrame.ReflectNewData();
      }
      for (int index = 0; index < this.modifiersFrames.Count; ++index)
      {
        if (this.modifiersFrames[index].UpdatePostingInfoFrame(player, DeltaTime, offset))
        {
          this.modifiersFrames[index].ReflectNewData();
          this.campaignSummaryFrame.ReflectNewData();
        }
      }
      this.campaignSummaryFrame.UpdateCampaignSummaryFrame(player, DeltaTime, offset);
    }

    public void DrawCurrentJobPostingFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.miniHeading.DrawMiniHeading(offset, spriteBatch);
      this.openJobPositionsFrame.DrawOpenPositionsFrame(offset, spriteBatch);
      for (int index = 0; index < this.modifiersFrames.Count; ++index)
        this.modifiersFrames[index].DrawPostingInfoFrame(offset, spriteBatch);
      this.campaignSummaryFrame.DrawCampaignSummaryFrame(offset, spriteBatch);
    }
  }
}
