// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_OverWorld.Airspace.DeliveryAirBehaviour
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.Z_HUD;

namespace TinyZoo.Z_OverWorld.Airspace
{
  internal class DeliveryAirBehaviour : AirVehicleBehaviour
  {
    private Vector2 start;
    private Vector2 destination;
    private DeliveryAirBehaviour.DeliveryBehaviourState state;
    private AirDeliveryCrateAndRope crate;
    private Z_BusStatus InboundArrow;
    private bool SnapToSideOfScreen;
    private int OrderUID;
    private int PenDeliveryID;
    private float timer;
    private static float maxspeed = 200f;
    private static float slowdowndistance = 100f;
    private float speed;
    private bool HasDelivered;

    public DeliveryAirBehaviour(
      AirVehicle vehicle_,
      Vector2 destination_,
      WaveInfo delivery_,
      int _OrderUID,
      bool _SnapToSideOfScreen,
      int PenUID)
      : base(vehicle_)
    {
      this.OrderUID = _OrderUID;
      this.PenDeliveryID = PenUID;
      this.SnapToSideOfScreen = _SnapToSideOfScreen;
      this.vehicle = vehicle_;
      this.destination = destination_;
      this.behaviourtype = AirVehicleBehaviourType.AnimalDelivery;
      this.state = DeliveryAirBehaviour.DeliveryBehaviourState.Start;
      this.crate = new AirDeliveryCrateAndRope(delivery_, _OrderUID);
      this.InboundArrow = new Z_BusStatus();
    }

    public override bool UpdateAirVehicleBehaviour(float SimulationTime, Player player)
    {
      this.InboundArrow.UpdateZ_BusStatusAsChopper(SimulationTime, this.vehicle.vLocation, this.state == DeliveryAirBehaviour.DeliveryBehaviourState.Start || this.state == DeliveryAirBehaviour.DeliveryBehaviourState.Entering);
      this.HasDelivered = false;
      float oscillateRatio = (float) Math.Log((double) (this.speed / DeliveryAirBehaviour.maxspeed) + 1.0, 2.0);
      this.vehicle.Rotation = oscillateRatio * 0.1570796f;
      this.vehicle.drawoffset = 0.3f * new Vector2(0.0f, SinOscillator.OscillateWithSin(ref this.timer, 5f, SimulationTime));
      float num1 = 1f;
      if (TrailerDemoFlags.HasTrailerFlag)
        num1 *= TrailerDemoFlags.ChopperDropSpeed;
      bool flag = this.crate.UpdateAirDeliveryCrateAndRope(this.vehicle.altitude, oscillateRatio, SimulationTime * num1, player, ref this.HasDelivered);
      switch (this.state)
      {
        case DeliveryAirBehaviour.DeliveryBehaviourState.Start:
          if (this.SnapToSideOfScreen)
            this.vehicle.vLocation = new Vector2(RenderMath.TranslateScreenSpaceToWorldSpace(Vector2.Zero).X + -0.5f * (float) this.vehicle.DrawRect.Width * Sengine.WorldOriginandScale.Z, this.destination.Y);
          else
            this.vehicle.vLocation = new Vector2(-0.5f * (float) this.vehicle.DrawRect.Width, this.destination.Y);
          this.start = this.vehicle.vLocation;
          this.state = DeliveryAirBehaviour.DeliveryBehaviourState.Entering;
          return false;
        case DeliveryAirBehaviour.DeliveryBehaviourState.Entering:
          Vector2 vector2_1 = Vector2.Normalize(this.destination - this.start);
          Vector2 vector2_2 = this.destination - this.vehicle.vLocation;
          float num2 = vector2_2.Length();
          float num3 = (float) ((double) vector2_1.X * (double) vector2_2.X + (double) vector2_1.Y * (double) vector2_2.Y);
          if ((double) num2 < 0.0500000007450581 || (double) num3 < 0.0)
          {
            this.speed = 0.0f;
            this.vehicle.vLocation = this.destination;
            this.state = DeliveryAirBehaviour.DeliveryBehaviourState.Hovering;
            this.crate.StartUnload();
          }
          else if ((double) num2 > (double) DeliveryAirBehaviour.slowdowndistance)
          {
            this.speed = DeliveryAirBehaviour.maxspeed;
            AirVehicle vehicle = this.vehicle;
            vehicle.vLocation = vehicle.vLocation + this.speed * SimulationTime * vector2_1;
          }
          else
          {
            this.speed = Math.Max(0.025f, (float) Math.Log((double) num2 / (double) DeliveryAirBehaviour.slowdowndistance + 1.0, 2.0)) * DeliveryAirBehaviour.maxspeed;
            AirVehicle vehicle = this.vehicle;
            vehicle.vLocation = vehicle.vLocation + this.speed * SimulationTime * vector2_1;
          }
          return false;
        case DeliveryAirBehaviour.DeliveryBehaviourState.Hovering:
          if (flag)
          {
            this.speed = 0.0f;
            this.start = this.destination;
            this.destination.X = TileMath.GetTileToWorldSpace(new Vector2Int(TileMath.GetOverWorldMapSize_XDefault(), 0)).X + (float) this.vehicle.DrawRect.Width;
            this.state = DeliveryAirBehaviour.DeliveryBehaviourState.Exiting;
          }
          return false;
        case DeliveryAirBehaviour.DeliveryBehaviourState.Exiting:
          Vector2 vector2_3 = Vector2.Normalize(this.destination - this.start);
          float num4 = (this.start - this.vehicle.vLocation).Length();
          Vector2 vector2_4 = this.destination - this.vehicle.vLocation;
          if ((double) vector2_3.X * (double) vector2_4.X + (double) vector2_3.Y * (double) vector2_4.Y < 0.0)
            this.state = DeliveryAirBehaviour.DeliveryBehaviourState.Exited;
          if (this.start == this.vehicle.vLocation || (double) num4 < 0.0500000007450581)
          {
            this.speed = 0.025f * DeliveryAirBehaviour.maxspeed;
            AirVehicle vehicle = this.vehicle;
            vehicle.vLocation = vehicle.vLocation + this.speed * SimulationTime * vector2_3;
          }
          else if ((double) num4 > (double) DeliveryAirBehaviour.slowdowndistance)
          {
            this.speed = DeliveryAirBehaviour.maxspeed;
            AirVehicle vehicle = this.vehicle;
            vehicle.vLocation = vehicle.vLocation + this.speed * SimulationTime * vector2_3;
          }
          else
          {
            this.speed = Math.Max(0.025f, (float) Math.Log((double) num4 / (double) DeliveryAirBehaviour.slowdowndistance + 1.0, 2.0)) * DeliveryAirBehaviour.maxspeed;
            AirVehicle vehicle = this.vehicle;
            vehicle.vLocation = vehicle.vLocation + this.speed * SimulationTime * vector2_3;
          }
          return false;
        case DeliveryAirBehaviour.DeliveryBehaviourState.Exited:
          return true;
        default:
          return false;
      }
    }

    public override bool ThisIsOnOrder(int _OrderUID) => this.OrderUID == _OrderUID;

    public override bool IsSomethingOnOrderToThisPen(int _PenUID) => this.PenDeliveryID == _PenUID && !this.HasDelivered;

    public override void DrawAirVehicleBehaviour(SpriteBatch spritebatch, Vector2 offset)
    {
      if (!TrailerDemoFlags.HasTrailerFlag && !GameFlags.PhotoMode)
        this.InboundArrow.DrawZ_BusStatusForChopper();
      this.crate.DrawAirDeliveryCrateAndRope(spritebatch, offset);
    }

    private enum DeliveryBehaviourState
    {
      Start,
      Entering,
      Hovering,
      Exiting,
      Exited,
      Count,
    }
  }
}
