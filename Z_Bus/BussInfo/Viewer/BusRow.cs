// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Bus.BussInfo.Viewer.BusRow
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.PlayerDir.BusTimetable;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Animal.Shared;
using TinyZoo.Z_SummaryPopUps.People.Customer;
using TinyZoo.Z_ZooValues;

namespace TinyZoo.Z_Bus.BussInfo.Viewer
{
  internal class BusRow
  {
    private AssignedBus[] assignedusses;
    private CustomerFrame customerframe;
    private MiniHeading miniheading;
    public Vector2 Location;
    private Vector2 FrameOffse;
    private Exdetails exdetails;

    public BusRow(
      Player player,
      BUSROUTE _route,
      float BaseScale,
      bool IsBussesInGarage = false,
      bool IsBuyScreen = false,
      bool IsSell = false)
    {
      UIScaleHelper uiScaleHelper = new UIScaleHelper(BaseScale);
      float num1 = 0.0f;
      float x = uiScaleHelper.DefaultBuffer.X;
      string text = "Buses on this route";
      if (IsBussesInGarage)
        text = "Buses not in service";
      if (IsBuyScreen)
        text = "Order new buses for your fleet";
      if (IsSell)
        text = "Scrap a bus you no longer need.";
      this.miniheading = new MiniHeading(Vector2.Zero, text, -1f, BaseScale);
      float num2 = num1 + (this.miniheading.GetTextHeight(true) + uiScaleHelper.DefaultBuffer.Y);
      if (IsBuyScreen)
      {
        this.exdetails = new Exdetails("Every bus costs $" + (object) BusTimes.GetMaintenenceCost() + " per week maintenence", BaseScale);
        this.exdetails.vLocation.X += x;
        this.exdetails.vLocation.Y += num2;
      }
      float num3 = num2 + uiScaleHelper.DefaultBuffer.Y * 1.5f;
      int[] numArray = player.busroutes.GetBusCount(_route);
      if (IsBussesInGarage)
        numArray = player.busroutes.GetBussesNotInUse();
      this.assignedusses = new AssignedBus[4];
      for (int index = 0; index < this.assignedusses.Length; ++index)
      {
        this.assignedusses[index] = new AssignedBus(player, (BUSTYPE) index, numArray[index], BaseScale, IsBussesInGarage, IsBuyScreen, IsBuyScreen, IsSell);
        Vector2 size = this.assignedusses[index].GetSize();
        this.assignedusses[index].Location.X = x;
        this.assignedusses[index].Location.X += size.X * 0.5f;
        x += size.X + uiScaleHelper.DefaultBuffer.X;
        this.assignedusses[index].Location.Y = num3;
        this.assignedusses[index].Location.Y += this.assignedusses[index].GetSize().Y * 0.5f;
      }
      float y = num3 + this.assignedusses[0].GetSize().Y + uiScaleHelper.DefaultBuffer.Y;
      this.customerframe = new CustomerFrame(new Vector2(x, y), true, BaseScale);
      Vector2 vector2 = -this.customerframe.VSCale * 0.5f;
      this.miniheading.SetTextPosition(this.customerframe.VSCale);
      if (this.exdetails != null)
      {
        Exdetails exdetails = this.exdetails;
        exdetails.vLocation = exdetails.vLocation + vector2;
      }
      for (int index = 0; index < this.assignedusses.Length; ++index)
        this.assignedusses[index].Location += vector2;
    }

    public Vector2 GetSize() => this.customerframe.VSCale;

    public int UpdateBusRow(Player player, float DeltaTime, Vector2 Offset)
    {
      int num = -1;
      Offset += this.Location;
      for (int index = 0; index < this.assignedusses.Length; ++index)
      {
        if (this.assignedusses[index].UpdateAssignedBus(Offset, player, DeltaTime))
          num = index;
      }
      return num;
    }

    public void DrawBusRow(Vector2 Offset, SpriteBatch spritebatch)
    {
      Offset += this.Location;
      this.customerframe.DrawCustomerFrame(Offset + this.FrameOffse, spritebatch);
      this.miniheading.DrawMiniHeading(Offset + this.FrameOffse);
      if (this.exdetails != null)
        this.exdetails.DrawExdetails(Offset + this.FrameOffse, spritebatch);
      for (int index = 0; index < this.assignedusses.Length; ++index)
        this.assignedusses[index].DrawAssignedBus(spritebatch, Offset);
    }
  }
}
