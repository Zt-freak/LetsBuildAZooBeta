// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Shops.LiveSlectedShop
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Tile_Data;

namespace TinyZoo.PlayerDir.Shops
{
  internal class LiveSlectedShop
  {
    public Vector2Int Location;
    public TILETYPE tiletype;

    public LiveSlectedShop(Vector2Int _Location, TILETYPE _tile)
    {
      this.Location = new Vector2Int(_Location);
      this.tiletype = _tile;
    }
  }
}
