// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.Ships.ShipManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.GamePlay.beams;
using TinyZoo.GamePlay.ReclaimedZones;

namespace TinyZoo.GamePlay.Ships
{
  internal class ShipManager
  {
    public List<Ship> ships;

    public ShipManager(int TotalPlayers)
    {
      this.ships = new List<Ship>();
      this.ships.Add(new Ship(0));
    }

    public void UpdateShipManager(
      Player[] players,
      float DeltaTime,
      BeamManager beammanager,
      bool IsGoingToNextLevel,
      BoxZoneManager boxzonemanager)
    {
      if (!IsGoingToNextLevel)
      {
        for (int index = 0; index < this.ships.Count; ++index)
          this.ships[index].UpdateShip(DeltaTime, players, beammanager, out bool _, boxzonemanager);
      }
      else
      {
        for (int index = 0; index < this.ships.Count; ++index)
          this.ships[index].UpdateDuringGameOver(DeltaTime);
      }
    }

    public void DrawShipManager()
    {
      for (int index = 0; index < this.ships.Count; ++index)
        this.ships[index].DrawShip();
    }
  }
}
