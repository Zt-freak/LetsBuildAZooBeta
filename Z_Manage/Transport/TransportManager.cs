// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Manage.Transport.TransportManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.GenericUI;

namespace TinyZoo.Z_Manage.Transport
{
  internal class TransportManager
  {
    private ScreenHeading screenhead;

    public TransportManager() => this.screenhead = new ScreenHeading("TRANSPORT MANAGEMENT", 90f);

    public void UpdateTransportManager(Player player, float DeltaTime)
    {
    }

    public void DrawTransportManager()
    {
      if (this.screenhead == null)
        return;
      this.screenhead.DrawScreenHeading(Vector2.Zero, AssetContainer.pointspritebatch03);
    }
  }
}
