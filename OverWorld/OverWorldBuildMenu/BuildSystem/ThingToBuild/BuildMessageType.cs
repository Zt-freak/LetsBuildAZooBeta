// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem.ThingToBuild.BuildMessageType
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem.ThingToBuild
{
  internal enum BuildMessageType
  {
    None,
    PlaceNextToExistingWall,
    Overlapping,
    CanBuild,
    CanBuild_ButNoMoney,
    TooSmall,
    TooBig,
    MakeTaller,
    MakeWider,
    Count,
  }
}
