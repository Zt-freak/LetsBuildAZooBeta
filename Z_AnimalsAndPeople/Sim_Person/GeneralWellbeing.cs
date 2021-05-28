// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.GeneralWellbeing
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person
{
  internal class GeneralWellbeing
  {
    public int Thriftiness;

    public GeneralWellbeing()
    {
      int num = Game1.Rnd.Next(0, 10);
      if (num < 5)
      {
        this.Thriftiness = Game1.Rnd.Next(45, 55);
      }
      else
      {
        switch (num)
        {
          case 5:
            this.Thriftiness = Game1.Rnd.Next(35, 60);
            break;
          case 6:
            this.Thriftiness = Game1.Rnd.Next(25, 70);
            break;
          case 7:
            this.Thriftiness = Game1.Rnd.Next(15, 75);
            break;
          case 8:
            this.Thriftiness = Game1.Rnd.Next(5, 85);
            break;
          default:
            this.Thriftiness = Game1.Rnd.Next(0, 100);
            break;
        }
      }
    }
  }
}
