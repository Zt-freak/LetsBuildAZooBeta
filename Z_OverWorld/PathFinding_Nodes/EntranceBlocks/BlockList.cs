// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.PathFinding_Nodes.EntranceBlocks.BlockList
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;

namespace TinyZoo.Z_OverWorld.PathFinding_Nodes.EntranceBlocks
{
  internal class BlockList
  {
    public List<Vector5Int> CustomerLocationsHere;

    public BlockList() => this.CustomerLocationsHere = new List<Vector5Int>();
  }
}
