// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld._OverWorldEnv.Customers.PeopleAttachments.StatusIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_OverWorld._OverWorldEnv.Customers.PeopleAttachments
{
  internal class StatusIcon : GameObject
  {
    public StatusIconType statusicontype;

    public void SetStatucIconType(StatusIconType statusicon)
    {
      this.statusicontype = statusicon;
      if (statusicon != StatusIconType.Caffiene)
        return;
      this.DrawRect = new Rectangle(194, 483, 20, 22);
      this.SetDrawOriginToPoint(DrawOriginPosition.CentreBottom);
      this.DrawOrigin.Y += 17f;
    }

    public void UpdateStatusIcon()
    {
    }

    public void DrawStatusIcon(Vector2 Offset)
    {
      this.vLocation = Offset;
      this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet);
    }
  }
}
