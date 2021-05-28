// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Manage.Accounts.GraphView.GraphDisplay
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.Z_Manage.Accounts.GraphView.Graph;
using TinyZoo.Z_Manage.Accounts.GraphView.GraphHelper;

namespace TinyZoo.Z_Manage.Accounts.GraphView
{
  internal class GraphDisplay
  {
    private List<GraphBar> graphbars;
    private Vector2 BottomLeftCornerOffset;
    private List<int> CurrentFilter;
    private GraphAxisMain graphaxis;
    private float BarHight;
    public Vector2 CENTERLOCATION;

    public GraphDisplay(ComaprerSet comparerset)
    {
      float num = 10f;
      this.graphbars = new List<GraphBar>();
      for (int Index = 0; Index < comparerset.ComparableGraphs[0].graphentries.Count; ++Index)
        this.graphbars.Add(new GraphBar(comparerset, Index, num, Index % 2 == 0));
      this.CurrentFilter = new List<int>();
      for (int index = 0; index < comparerset.ComparableGraphs.Length; ++index)
        this.CurrentFilter.Add(index);
      this.BarHight = 150f;
      this.graphaxis = new GraphAxisMain(this.BarHight, num, 50, comparerset);
      this.CENTERLOCATION = new Vector2(510f, 600f);
      this.BottomLeftCornerOffset = new Vector2(this.graphaxis.SIZEOFGRAPH.X * -0.5f, this.graphaxis.SIZEOFGRAPH.Y * 0.5f);
      this.BottomLeftCornerOffset.X = -100f;
    }

    public void UpdateGraphDisplay(Vector2 Offset, float DeltaTime, Player player)
    {
      Offset += this.CENTERLOCATION;
      this.graphaxis.UpdateGrapAxis(Offset, this.BottomLeftCornerOffset, player, DeltaTime, ref this.CurrentFilter);
    }

    public void DrawGraphDisplay(Vector2 Offset)
    {
      Offset += this.CENTERLOCATION;
      this.graphaxis.DrawGrapAxis(Offset, this.BottomLeftCornerOffset);
      Offset += this.BottomLeftCornerOffset;
      for (int index = 0; index < this.graphbars.Count; ++index)
        this.graphbars[index].DrawGraphBar(Offset, this.BarHight, this.CurrentFilter);
    }
  }
}
