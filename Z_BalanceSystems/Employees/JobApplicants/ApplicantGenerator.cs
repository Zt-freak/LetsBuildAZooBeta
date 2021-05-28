// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BalanceSystems.Employees.JobApplicants.ApplicantGenerator
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.Tile_Data;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.Z_BalanceSystems.Employees.JobApplicants
{
  internal class ApplicantGenerator
  {
    public static int MaxApplicantsForDisplay = 10;

    public static Applicant CreateNewApplicant(
      TILETYPE tileType,
      EmployeeType roamingemplyeetype,
      bool IsAgencyHire)
    {
      bool IsAGirl;
      AnimalType animalType = roamingemplyeetype == EmployeeType.Count ? EmployeeData.GetBuildingtoEmployee(tileType, out IsAGirl) : TinyZoo.PlayerDir.Employees.GetEmployee(roamingemplyeetype, out IsAGirl);
      float _StarRating = 0.5f;
      Seniority _SeniorityLevel = Seniority.Junior;
      int NameStringIndex;
      string name = PeopleNames.GetName(!IsAGirl, out NameStringIndex, animalType);
      return new Applicant(animalType, _StarRating, _SeniorityLevel, IsAGirl, name, IsAgencyHire, NameStringIndex);
    }
  }
}
