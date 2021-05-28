// Decompiled with JetBrains decompiler
// Type: TinyZoo.PathFinding.NodeList
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;

namespace TinyZoo.PathFinding
{
  internal class NodeList
  {
    public List<PathNode> pathnodes;
    private Vector2Int TargetNode;

    public NodeList(Vector2Int _TargetNode, List<PathNode> nodes)
    {
      this.pathnodes = nodes;
      this.TargetNode = _TargetNode;
    }

    public static int SortNodeList(NodeList A, NodeList B)
    {
      if (A.pathnodes.Count > B.pathnodes.Count)
        return -1;
      return A.pathnodes.Count < B.pathnodes.Count ? 1 : 0;
    }
  }
}
