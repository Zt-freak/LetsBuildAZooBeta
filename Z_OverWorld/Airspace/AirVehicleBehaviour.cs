// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.Airspace.AirVehicleBehaviour
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TinyZoo.Z_OverWorld.Airspace
{
  internal class AirVehicleBehaviour
  {
    protected AirVehicle vehicle;
    public AirVehicleBehaviourType behaviourtype;

    protected AirVehicleBehaviour(AirVehicle vehicle_) => this.vehicle = vehicle_;

    public virtual bool UpdateAirVehicleBehaviour(float SimulationTime, Player player) => false;

    public virtual bool ThisIsOnOrder(int OrderUID) => false;

    public virtual bool IsSomethingOnOrderToThisPen(int _PenUID) => false;

    public virtual void DrawAirVehicleBehaviour(SpriteBatch spritebatch, Vector2 offset)
    {
    }
  }
}
