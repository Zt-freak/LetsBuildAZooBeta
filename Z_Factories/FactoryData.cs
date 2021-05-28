// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Factories.FactoryData
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Tile_Data;

namespace TinyZoo.Z_Factories
{
  internal class FactoryData
  {
    internal static int GetManufacturingTimeInMinutes(
      TILETYPE tiletype,
      float EmployeeProductivityMultiplier)
    {
      return tiletype == TILETYPE.SnakeSkinFactory ? (int) (480.0 * (double) EmployeeProductivityMultiplier) : (int) (120.0 * (double) EmployeeProductivityMultiplier);
    }
  }
}
