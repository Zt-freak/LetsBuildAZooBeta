// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_EditZone.SelectedZones.Patrol_Zones.ZoneDragHandler
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_EditZone.SelectedZones.Patrol_Zones
{
  internal class ZoneDragHandler : GameObject
  {
    public ZoneDragHandler(Vector2Int Location, bool IsTopLeft)
    {
      this.DrawRect = new Rectangle(1, 1, 1, 1);
      this.scale = 20f;
      this.SetAllColours(0.0f, 1f, 1f);
    }

    public bool CheckForNewMouseDown(Player player) => (double) player.player.touchinput.MultiTouchTapArray[0].X > 0.0 && MathStuff.CheckPointCollision(true, RenderMath.TranslateWorldSpaceToScreenSpace(this.vLocation), this.scale * Sengine.WorldOriginandScale.Z, (float) this.DrawRect.Width, (float) this.DrawRect.Height * Sengine.ScreenRatioUpwardsMultiplier.Y, player.player.touchinput.MultiTouchTapArray[0]);

    public void UpdateZoneDragHandler(Player player)
    {
    }

    public void DrawZoneDragHandler()
    {
    }
  }
}
