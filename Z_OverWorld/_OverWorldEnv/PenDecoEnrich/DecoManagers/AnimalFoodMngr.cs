// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld._OverWorldEnv.PenDecoEnrich.DecoManagers.AnimalFoodMngr
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.Z_AnimalsAndPeople.Sim_Person.Extras;

namespace TinyZoo.Z_OverWorld._OverWorldEnv.PenDecoEnrich.DecoManagers
{
  internal class AnimalFoodMngr : BaseDecoObject
  {
    private List<DecoFood> decofood;

    public AnimalFoodMngr(UsedFoodCollection foodused)
    {
      this.decofood = new List<DecoFood>();
      for (int index = 0; index < foodused.usedfoodentries.Count; ++index)
        this.decofood.Add(new DecoFood(foodused.usedfoodentries[index].FoodTypeUsed));
    }

    public override bool UpdateBaseDecoObject(float DeltaTime)
    {
      for (int index = this.decofood.Count - 1; index > -1; --index)
      {
        if (this.decofood[index].UpdateDecoFood(DeltaTime, 1f))
          this.decofood.RemoveAt(index);
      }
      return false;
    }

    public override void DrawBaseDecoObject(Vector2 Location)
    {
      for (int index = 0; index < this.decofood.Count; ++index)
      {
        this.decofood[index].vLocation = Location;
        this.decofood[index].DrawDeco();
      }
    }
  }
}
