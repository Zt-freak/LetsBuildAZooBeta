// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.VetBuilding.Disease.DiseaseCat.DiseeaseCatSelectManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_BuildingInfo.VetBuilding.Disease.DiseaseCat
{
  internal class DiseeaseCatSelectManager
  {
    private BigBrownPanel BigBrownPanel;
    private Vector2 Position;

    public DiseeaseCatSelectManager() => this.BigBrownPanel = new BigBrownPanel(new Vector2(0.0f, 0.0f), true, "Medical Journal", Z_GameFlags.GetBaseScaleForUI());

    public void UpdateDiseeaseCatSelectManager()
    {
    }

    public void DrawrDiseeaseCatSelectManager()
    {
    }
  }
}
