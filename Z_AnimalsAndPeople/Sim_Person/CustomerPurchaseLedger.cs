// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.CustomerPurchaseLedger
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_ManageShop.FoodIcon;

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person
{
  internal class CustomerPurchaseLedger
  {
    public FOODTYPE Thingpurchased;
    public int Cost;

    public CustomerPurchaseLedger(int _Cost, FOODTYPE purchasedthing)
    {
      this.Cost = _Cost;
      this.Thingpurchased = purchasedthing;
    }
  }
}
