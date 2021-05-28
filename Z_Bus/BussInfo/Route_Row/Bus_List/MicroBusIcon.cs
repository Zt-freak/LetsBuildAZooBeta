// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Bus.BussInfo.Route_Row.Bus_List.MicroBusIcon
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.PlayerDir;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.Z_Bus.BussInfo.Route_Row.Bus_List
{
  internal class MicroBusIcon : GameObject
  {
    private GameObject icon;

    public MicroBusIcon(BUSTYPE bustype, float BaseScale)
    {
      this.DrawRect = new Rectangle(0, 0, 1, 1);
      this.scale = BaseScale * 16f;
      this.SetDrawOriginToCentre();
      this.SetAlpha(0.5f);
      this.icon = new GameObject();
      switch (bustype)
      {
        case BUSTYPE.StartingBus_01:
          this.icon.DrawRect = new Rectangle(210, 74, 16, 14);
          break;
        case BUSTYPE.BiggerBus_02:
          this.icon.DrawRect = new Rectangle(176, 74, 16, 14);
          break;
        case BUSTYPE.LargeBus_03:
          this.icon.DrawRect = new Rectangle(176, 74, 16, 14);
          break;
        case BUSTYPE.DoubleDeckerBus_04:
          this.icon.DrawRect = new Rectangle(158, 72, 17, 16);
          break;
      }
      if (!Researcher.BusTypesReseacred[(int) bustype])
      {
        this.icon.SetAllColours(0.0f, 0.0f, 0.0f);
        this.icon.SetAlpha(0.3f);
      }
      this.icon.scale = BaseScale;
      this.icon.SetDrawOriginToCentre();
    }

    public void DrawMicroBusIcon(SpriteBatch spritebatch, Vector2 Offset) => this.icon.Draw(spritebatch, AssetContainer.SpriteSheet, Offset + this.vLocation);
  }
}
