// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Layout.facilities.Facility
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;

namespace TinyZoo.PlayerDir.Layout.facilities
{
  internal class Facility
  {
    public Vector2Int Location;

    public Facility(Vector2Int _Location) => this.Location = new Vector2Int(_Location);

    public Facility(Reader reader) => this.Location = new Vector2Int(reader);

    public void SaveWaterPump(Writer writer) => this.Location.SaveVector2Int(writer);
  }
}
