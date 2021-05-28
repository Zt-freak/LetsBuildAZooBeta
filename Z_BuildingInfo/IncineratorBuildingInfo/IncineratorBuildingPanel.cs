// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.IncineratorBuildingInfo.IncineratorBuildingPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.PlayerDir.Shops;
using TinyZoo.Tile_Data;
using TinyZoo.Z_BuildingInfo.Generic;
using TinyZoo.Z_BuildingInfo.Z_Processing.NewPanel.ActiveProcess;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_BuildingInfo.IncineratorBuildingInfo
{
  internal class IncineratorBuildingPanel
  {
    public Vector2 location;
    private BigBrownPanel bigBrownPanel;
    private Summary24Hr summary24hr;
    private ActiveProcessDisplayFrame activeProcessFrame;

    public IncineratorBuildingPanel(int BuildingUID, TILETYPE tileTYPE, Player player)
    {
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      Vector2 defaultBuffer = new UIScaleHelper(baseScaleForUi).DefaultBuffer;
      ShopEntry thisFacility = player.shopstatus.GetThisFacility(BuildingUID);
      this.bigBrownPanel = new BigBrownPanel(Vector2.Zero, true, "Incinerator", baseScaleForUi);
      this.activeProcessFrame = new ActiveProcessDisplayFrame(thisFacility, player, baseScaleForUi);
      this.summary24hr = new Summary24Hr(thisFacility, player, baseScaleForUi, this.activeProcessFrame.GetSize().X);
      this.summary24hr.location.Y = Vector2.Zero.Y;
      this.summary24hr.location.Y += this.summary24hr.GetSize().Y * 0.5f;
      Vector2 size = this.summary24hr.GetSize();
      size.Y += defaultBuffer.Y;
      this.activeProcessFrame.location.Y = size.Y;
      this.activeProcessFrame.location.Y += this.activeProcessFrame.GetSize().Y * 0.5f;
      size.Y += this.activeProcessFrame.GetSize().Y;
      this.bigBrownPanel.Finalize(size);
      Vector2 frameOffsetFromTop = this.bigBrownPanel.GetFrameOffsetFromTop();
      this.summary24hr.location.Y += frameOffsetFromTop.Y;
      this.activeProcessFrame.location.Y += frameOffsetFromTop.Y;
    }

    public bool CheckMouseOver(Player player, Vector2 offset)
    {
      offset += this.location;
      return this.bigBrownPanel.CheckMouseOver(player, offset);
    }

    public bool UpdateIncineratorBuildingPanel(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      this.bigBrownPanel.UpdateDragger(player, ref this.location, DeltaTime);
      this.summary24hr.UpdateSummary24Hr(player, DeltaTime, offset);
      this.activeProcessFrame.UpdateActiveProcessDisplayFrame(player, DeltaTime, offset);
      return this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, offset);
    }

    public void DrawIncineratorBuildingPanel(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.summary24hr.PreDrawSummary24Hr(offset, spriteBatch);
      this.bigBrownPanel.DrawBigBrownPanel(offset, spriteBatch);
      this.summary24hr.DrawSummary24Hr(offset, spriteBatch);
      this.activeProcessFrame.DrawActiveProcessDisplayFrame(offset, spriteBatch);
    }
  }
}
