// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.PenNav.StaticPenNavPool
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System;
using System.Collections.Generic;
using TinyZoo.Z_AnimalsAndPeople.PenNav.CurrentPens;

namespace TinyZoo.Z_AnimalsAndPeople.PenNav
{
  internal class StaticPenNavPool
  {
    private static List<PenNavCollection> pennavigators = new List<PenNavCollection>();

    internal static PenNavCollection GetThisPenNav(
      List<Vector2Int> FloorLocations,
      int PenUID)
    {
      for (int index = 0; index < StaticPenNavPool.pennavigators.Count; ++index)
      {
        if (StaticPenNavPool.pennavigators[index].PenUID == PenUID)
          return StaticPenNavPool.pennavigators[index];
      }
      StaticPenNavPool.pennavigators.Add(new PenNavCollection(PenUID, FloorLocations));
      return StaticPenNavPool.pennavigators[StaticPenNavPool.pennavigators.Count - 1];
    }

    internal static PenNavCollection GetThisExistingPenNav(int PenUID)
    {
      for (int index = 0; index < StaticPenNavPool.pennavigators.Count; ++index)
      {
        if (StaticPenNavPool.pennavigators[index].PenUID == PenUID)
          return StaticPenNavPool.pennavigators[index];
      }
      throw new Exception("BALLZ");
    }

    internal static void RemoveThisPen(int PenUID)
    {
      for (int index = StaticPenNavPool.pennavigators.Count - 1; index > -1; --index)
      {
        if (StaticPenNavPool.pennavigators[index].PenUID == PenUID)
        {
          StaticPenNavPool.pennavigators.RemoveAt(index);
          break;
        }
      }
    }
  }
}
