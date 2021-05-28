﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Pause.PausePanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using SEngine.Input;
using TinyZoo.GamePlay.PauseScreen;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_Pause
{
  internal class PausePanel
  {
    public Vector2 location;
    private BigBrownPanel bigBrownPanel;
    private PauseFrame frame;
    public LerpHandler_Float lerper;

    public PausePanel()
    {
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      this.bigBrownPanel = new BigBrownPanel(Vector2.Zero, true, "Game Paused", baseScaleForUi);
      this.frame = new PauseFrame(baseScaleForUi);
      this.bigBrownPanel.Finalize(this.frame.GetSize());
      this.bigBrownPanel.GetFinalizedLocation();
      this.lerper = new LerpHandler_Float();
      this.LerpIn();
    }

    public void LerpIn() => this.lerper.SetLerp(true, 1f, 0.0f, 3f);

    public void LerpOff() => this.lerper.SetLerp(false, 0.0f, 1f, 3f);

    public PauseScreenButton UpdatePausePanel(
      Player player,
      float DeltaTime,
      Vector2 offset)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      offset += this.location;
      offset.Y += this.lerper.Value * (float) (384.0 - (double) this.bigBrownPanel.GetFrameOffsetFromTop().Y + (double) this.bigBrownPanel.vScale.Y * 0.5);
      if ((double) this.lerper.Value != 0.0)
        return PauseScreenButton.Count;
      return this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, offset) || PC_KeyState.Escape_Released ? PauseScreenButton.Resume : this.frame.UpdatePauseFrame(player, DeltaTime, offset);
    }

    public void DrawPausePanel(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      offset.Y += this.lerper.Value * (float) (384.0 - (double) this.bigBrownPanel.GetFrameOffsetFromTop().Y + (double) this.bigBrownPanel.vScale.Y * 0.5);
      this.bigBrownPanel.DrawBigBrownPanel(offset, spriteBatch);
      this.frame.DrawPauseFrame(offset, spriteBatch);
    }
  }
}
