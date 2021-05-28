// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_GenericUI.PanelDragger
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using SEngine.Input;

namespace TinyZoo.Z_GenericUI
{
  internal class PanelDragger
  {
    private Vector2 prevLocation;
    private Vector2 currLocation;
    private Vector2 topLeft;
    private Vector2 bottomRight;
    private float basescale;

    public bool dragging { get; private set; }

    public PanelDragger(Vector2 topLeft_, Vector2 bottomRight_, float basescale_)
    {
      this.topLeft = topLeft_;
      this.bottomRight = bottomRight_;
      this.basescale = basescale_;
      this.dragging = false;
    }

    public Vector2 UpdatePanelDragger(Player player, Vector2 offset, float DeltaTime)
    {
      Vector2 vector2_1 = Vector2.Zero;
      this.prevLocation = this.currLocation;
      this.currLocation = MouseStatus.MousePosition;
      Vector2 vector2_2 = offset + this.topLeft;
      Vector2 vector2_3 = offset + this.bottomRight;
      if ((double) player.player.touchinput.MultiTouchTapArray[0].X > 0.0)
      {
        if ((double) this.prevLocation.X > (double) vector2_2.X && (double) this.prevLocation.X < (double) vector2_3.X && ((double) this.prevLocation.Y > (double) vector2_2.Y && (double) this.prevLocation.Y < (double) vector2_3.Y))
          this.dragging = true;
      }
      else if ((double) player.player.touchinput.MultiTouchTouchLocations[0].X <= -(double) Sengine.HalfReferenceScreenRes.X)
        this.dragging = false;
      if (this.dragging)
        vector2_1 = this.currLocation - this.prevLocation;
      return vector2_1;
    }
  }
}
