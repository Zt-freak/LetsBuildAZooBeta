// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.Airspace.AirVehicleManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TinyZoo.Z_OverWorld.Airspace
{
  internal class AirVehicleManager
  {
    private List<AirVehicle> airvehicles = new List<AirVehicle>();

    public void UpdateAirVehicleManager(float SimulationTime, Player player)
    {
      List<AirVehicle> airVehicleList = new List<AirVehicle>();
      foreach (AirVehicle airvehicle in this.airvehicles)
      {
        if (airvehicle.active && airvehicle.UpdateAirVehicle(SimulationTime, player))
        {
          airvehicle.active = false;
          airVehicleList.Add(airvehicle);
        }
      }
      foreach (AirVehicle airVehicle in airVehicleList)
        this.airvehicles.Remove(airVehicle);
    }

    public bool ThisIsOnOrder(int OrderUID)
    {
      foreach (AirVehicle airvehicle in this.airvehicles)
      {
        if ((airvehicle.vehicletype == AirVehicleType.DeliveryChinook || airvehicle.vehicletype == AirVehicleType.BlackChinook) && airvehicle.ThisIsOnOrder(OrderUID))
          return true;
      }
      return false;
    }

    public bool IsSomethingOnOrderToThisPen(int CellUID)
    {
      foreach (AirVehicle airvehicle in this.airvehicles)
      {
        if ((airvehicle.vehicletype == AirVehicleType.DeliveryChinook || airvehicle.vehicletype == AirVehicleType.BlackChinook) && airvehicle.IsSomethingOnOrderToThisPen(CellUID))
          return true;
      }
      return false;
    }

    public void AddAirVehicle(AirVehicle vehicle) => this.airvehicles.Add(vehicle);

    public void DrawAirVehicleManager()
    {
      foreach (AirVehicle airvehicle in this.airvehicles)
        airvehicle.DrawAirVehicle(AssetContainer.pointspritebatch01, Vector2.Zero);
    }
  }
}
