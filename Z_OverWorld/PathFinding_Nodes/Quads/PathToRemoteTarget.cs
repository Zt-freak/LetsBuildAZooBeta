// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.PathFinding_Nodes.Quads.PathToRemoteTarget
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_OverWorld.PathFinding_Nodes.Quads
{
  internal class PathToRemoteTarget
  {
    public LocationNode FinalTarget;
    public int PathLength;

    public PathToRemoteTarget(LocationNode _FinalTarget, int Distance)
    {
      this.PathLength = Distance;
      this.FinalTarget = _FinalTarget;
    }

    public bool CheckPath(int _PathLength)
    {
      if (this.PathLength <= _PathLength)
        return false;
      this.PathLength = _PathLength;
      return true;
    }
  }
}
