// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Customer.VIPSpecificInfo.PolicemanInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.OverWorld.OverWorldEnv.Customers;

namespace TinyZoo.Z_SummaryPopUps.People.Customer.VIPSpecificInfo
{
  internal class PolicemanInfo : VIPInfo
  {
    private CustomerFrame customerFrame;

    public PolicemanInfo(WalkingPerson person, float BaseScale, float forceThisWidth)
    {
    }

    public override Vector2 GetSize() => this.customerFrame != null ? this.customerFrame.VSCale : Vector2.Zero;

    public override bool UpdateVIPInfo(Player player, Vector2 offset, float DeltaTime) => false;

    public override void DrawVIPInfo(SpriteBatch spritebatch, Vector2 offset)
    {
      offset += this.location;
      if (this.customerFrame == null)
        return;
      this.customerFrame.DrawCustomerFrame(offset, spritebatch);
    }
  }
}
