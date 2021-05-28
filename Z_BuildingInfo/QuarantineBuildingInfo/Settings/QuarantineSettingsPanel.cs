// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.QuarantineBuildingInfo.Settings.QuarantineSettingsPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_BuildingInfo.QuarantineBuildingInfo.Settings.Frame;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_BuildingInfo.QuarantineBuildingInfo.Settings
{
  internal class QuarantineSettingsPanel
  {
    public Vector2 location;
    private BigBrownPanel bigBrownPanel;
    private ImportActionSettings frame;

    public QuarantineSettingsPanel(Player player, float BaseScale)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      this.bigBrownPanel = new BigBrownPanel(Vector2.Zero, true, "Quarantine Options", BaseScale);
      this.frame = new ImportActionSettings(player, BaseScale);
      this.bigBrownPanel.Finalize(this.frame.GetSize());
    }

    public bool CheckMouseOver(Player player, Vector2 offset)
    {
      offset += this.location;
      return this.bigBrownPanel.CheckMouseOver(player, offset);
    }

    public bool UpdateQuarantineSettingsPanel(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      this.bigBrownPanel.UpdateDragger(player, ref this.location, DeltaTime);
      this.frame.UpdateImportActionSettings(player, DeltaTime, offset);
      return this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, offset);
    }

    public void DrawQuarantineSettingsPanel(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.bigBrownPanel.DrawBigBrownPanel(offset, spriteBatch);
      this.frame.DrawImportActionSettings(offset, spriteBatch);
    }
  }
}
