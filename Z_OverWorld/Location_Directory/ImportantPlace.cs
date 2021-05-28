// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.Location_Directory.ImportantPlace
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Tile_Data;

namespace TinyZoo.Z_OverWorld.Location_Directory
{
  internal class ImportantPlace
  {
    public Vector2Int Location;

    public ImportantPlace(int _LocationX, int _LocationY, TILETYPE tiletype) => this.Location = new Vector2Int(_LocationX, _LocationY);
  }
}
