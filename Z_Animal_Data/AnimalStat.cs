// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Animal_Data.AnimalStat
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;

namespace TinyZoo.Z_Animal_Data
{
  internal class AnimalStat
  {
    public float Popularity;
    public int GroupSize;
    public float OverGroupSizeSubtraction;
    public float OverGroupSizeMinimum;
    public float EnclosuerSpacePerAnimal;
    public float Aggression;
    public float Strength;
    public float Defence;
    public float AttackSpeed;
    public DietType diettype;
    public int Compatibility_GrassLand;
    public int Compatibility_Forest;
    public int Compatibility_Desert;
    public int Compatibility_Mountain;
    public int Compatibility_Arctic;
    public int Compatibility_Tropical;
    public int Compatibility_Savannah;
    private List<ENRICHMENTCLASS> AnimalEnrichmentOptions;

    public void AddEnrichment(ENRICHMENTCLASS enrichmenttype)
    {
      if (this.AnimalEnrichmentOptions == null)
        this.AnimalEnrichmentOptions = new List<ENRICHMENTCLASS>();
      this.AnimalEnrichmentOptions.Add(enrichmenttype);
    }
  }
}
