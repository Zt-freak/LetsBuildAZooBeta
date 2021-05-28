// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.SelectCell.CellClose
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.OverWorld.SelectCell
{
  internal class CellClose : GameObject
  {
    private Rectangle BaseRect;
    private bool MouseOver;
    private Vector2 LLLo;

    public CellClose()
    {
      this.scale = Z_GameFlags.GetBaseScaleForUI();
      this.BaseRect = new Rectangle(964, 313, 17, 17);
      this.DrawRect = this.BaseRect;
      this.SetDrawOriginToCentre();
      this.LLLo = new Vector2(95f, -76f * Sengine.ScreenRatioUpwardsMultiplier.Y);
    }

    public bool UpdateCellClose(Vector2 Offset, Player player)
    {
      Offset += this.LLLo;
      if (MathStuff.CheckPointCollision(true, this.vLocation + Offset, this.scale, (float) this.DrawRect.Width, (float) this.DrawRect.Height, player.player.touchinput.MultiTouchTouchLocations[0]))
        this.MouseOver = true;
      else if (MathStuff.CheckPointCollision(true, this.vLocation + Offset, this.scale, (float) this.DrawRect.Width, (float) this.DrawRect.Height, player.inputmap.PointerLocation))
        this.MouseOver = true;
      return MathStuff.CheckPointCollision(true, this.vLocation + Offset, this.scale, (float) this.DrawRect.Width, (float) this.DrawRect.Height, player.player.touchinput.ReleaseTapArray[0]);
    }

    public void DrawCellClose(Vector2 Offset, float AlphaMult)
    {
      if (GameFlags.IsUsingController)
        return;
      this.scale = 2f;
      Offset += this.LLLo * AlphaMult;
      if ((double) AlphaMult == 0.0)
        return;
      this.DrawRect = this.BaseRect;
      if (this.MouseOver)
      {
        this.DrawRect = new Rectangle(944, 313, 17, 17);
        this.MouseOver = false;
      }
      this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, Offset, this.fAlpha * AlphaMult);
    }
  }
}
