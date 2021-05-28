// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuildingInfo.Z_Processing.Data.WarehouseData
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.Z_Processing;
using TinyZoo.Z_StoreRoom;

namespace TinyZoo.Z_BuildingInfo.Z_Processing.Data
{
  internal class WarehouseData
  {
    private static List<AnimalFoodType> warehouseDisplayList;

    public static List<AnimalFoodType> GetDisplayListOfWarehouseItems()
    {
      if (WarehouseData.warehouseDisplayList == null)
      {
        WarehouseData.warehouseDisplayList = new List<AnimalFoodType>();
        WarehouseData.warehouseDisplayList.AddRange((IEnumerable<AnimalFoodType>) PcessedMeatData.GetConvertableAnimalFoodTypesInDisplayOrder());
        WarehouseData.warehouseDisplayList.AddRange((IEnumerable<AnimalFoodType>) ProcessedVeg.GetDisplayListOfVegProcessorOutput());
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.AlligatorSkin);
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.ChickenMeat);
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.SnakeSkin);
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.Pork);
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.HorseHoof);
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.Grains);
        WarehouseData.warehouseDisplayList.Remove(AnimalFoodType.Hops);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.SnakeSkinBelt);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.ChickenWing);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.Glue);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.CrocHandbag);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.BeerFromProcessor);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.FlourFromProcessor);
        WarehouseData.warehouseDisplayList.Add(AnimalFoodType.Bread);
      }
      return WarehouseData.warehouseDisplayList;
    }
  }
}
