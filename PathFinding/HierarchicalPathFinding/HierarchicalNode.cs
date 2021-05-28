// Decompiled with JetBrains decompiler
// Type: TinyZoo.PathFinding.HierarchicalPathFinding.HierarchicalNode
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace TinyZoo.PathFinding.HierarchicalPathFinding
{
  public class HierarchicalNode : IBinaryHeapItem<HierarchicalNode>, IComparable<HierarchicalNode>
  {
    public int layer;
    public NodeCluster cluster;
    public HierarchicalNode supernode;
    public HashSet<HierarchicalNode> subnodes;
    public Dictionary<HierarchicalNode, HashSet<HierarchicalNode>> neighbours;
    public Dictionary<Tuple<HierarchicalNode, HierarchicalNode>, List<HierarchicalNode>> paths;
    private HashSet<HierarchicalNode> edgenodes;
    public Vector2 location;
    public float fCost;
    public float gCost;
    public float hCost;
    public HierarchicalNode parent;
    private int heapIndex;

    internal void AddEdgenode(HierarchicalNode edgenode) => this.edgenodes.Add(edgenode);

    public int binaryHeapIndex
    {
      get => this.heapIndex;
      set => this.heapIndex = value;
    }

    public int CompareTo(HierarchicalNode rhs) => (double) this.fCost == (double) rhs.fCost ? this.hCost.CompareTo(rhs.hCost) : this.fCost.CompareTo(rhs.fCost);

    public HierarchicalNode()
    {
      this.neighbours = new Dictionary<HierarchicalNode, HashSet<HierarchicalNode>>();
      this.subnodes = new HashSet<HierarchicalNode>();
      this.edgenodes = new HashSet<HierarchicalNode>();
      this.paths = new Dictionary<Tuple<HierarchicalNode, HierarchicalNode>, List<HierarchicalNode>>();
    }

    public float GetDistanceManhattan(HierarchicalNode other) => Math.Abs(this.location.X - other.location.X) + Math.Abs(this.location.Y - other.location.Y);

    public float GetDistanceEuclidean(HierarchicalNode other) => (this.location - other.location).Length();

    public void ConnectNeighboursBasedOnSubnodes()
    {
      foreach (HierarchicalNode edgenode in this.edgenodes)
      {
        foreach (HierarchicalNode key in edgenode.neighbours.Keys)
        {
          if (key.supernode != this)
          {
            HierarchicalNode supernode = key.supernode;
            if (!this.neighbours.ContainsKey(supernode))
              this.neighbours[supernode] = new HashSet<HierarchicalNode>();
            this.neighbours[supernode].Add(edgenode);
            if (!supernode.neighbours.ContainsKey(this))
              supernode.neighbours[this] = new HashSet<HierarchicalNode>();
            supernode.neighbours[this].Add(key);
          }
        }
      }
    }
  }
}
