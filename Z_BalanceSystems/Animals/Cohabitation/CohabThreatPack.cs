// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Animals.Cohabitation.CohabThreatPack
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;

namespace TinyZoo.Z_BalanceSystems.Animals.Cohabitation
{
  internal class CohabThreatPack
  {
    public List<AnimalCohabitRelationship> cohabitationrelationshipsJustQuerried;
    public bool ThisVictimIsACarnivore;

    public CohabThreatPack() => this.cohabitationrelationshipsJustQuerried = new List<AnimalCohabitRelationship>();
  }
}
