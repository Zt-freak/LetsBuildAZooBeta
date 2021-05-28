// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld._OverWorldEnv.Customers.DeadPeople
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.OverWorld.OverWorldEnv.Customers;

namespace TinyZoo.Z_OverWorld._OverWorldEnv.Customers
{
  internal class DeadPeople
  {
    private List<DeadPersonRenderer> deadpersonrenderers;

    public DeadPeople() => this.deadpersonrenderers = new List<DeadPersonRenderer>();

    public void AddDeadPerson(WalkingPerson walking) => this.deadpersonrenderers.Add(new DeadPersonRenderer(walking.vLocation));

    public void DrawDeadPeople()
    {
      for (int index = 0; index < this.deadpersonrenderers.Count; ++index)
        this.deadpersonrenderers[index].DrawDeadPersonRenderer(AssetContainer.pointspritebatch01);
    }
  }
}
