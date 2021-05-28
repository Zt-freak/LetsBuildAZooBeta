// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Manage.Accounts.GraphView.GraphHelper.GraphData
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TinyZoo.Z_Manage.Accounts.GraphView.GraphHelper
{
  internal class GraphData
  {
    public List<GraphEntry> graphentries;
    public string Name;
    public List<Vector3> Colours;
    public float HighestValueInGraph;

    public GraphData(string _Name, Vector3 _Colour)
    {
      this.Name = _Name;
      this.Colours = new List<Vector3>();
      this.Colours.Add(_Colour);
      this.graphentries = new List<GraphEntry>();
    }

    public void AddColourForLowerOrHigher(GraphData Compareres, int LowerColour = 0)
    {
      for (int index = 0; index < Compareres.graphentries.Count; ++index)
      {
        if ((double) this.graphentries[index].ThisEntryValue > (double) Compareres.graphentries[index].ThisEntryValue)
        {
          this.graphentries[index].BackBarEntryValue = this.graphentries[index].ThisEntryValue;
          this.graphentries[index].ThisEntryValue = Compareres.graphentries[index].ThisEntryValue;
          this.graphentries[index].BackColourIndex = 1;
        }
      }
    }

    public void SetMax(params GraphData[] Compareres)
    {
      this.HighestValueInGraph = this.GetMax();
      for (int index = 0; index < Compareres.Length; ++index)
      {
        float max = Compareres[index].GetMax();
        if ((double) max > (double) this.HighestValueInGraph)
          this.HighestValueInGraph = max;
      }
      for (int index = 0; index < Compareres.Length; ++index)
        Compareres[index].HighestValueInGraph = this.HighestValueInGraph;
    }

    public float GetMax()
    {
      float num = 0.0f;
      for (int index = 0; index < this.graphentries.Count; ++index)
      {
        if ((double) this.graphentries[index].ThisEntryValue > (double) num)
          num = this.graphentries[index].ThisEntryValue;
      }
      return num;
    }
  }
}
