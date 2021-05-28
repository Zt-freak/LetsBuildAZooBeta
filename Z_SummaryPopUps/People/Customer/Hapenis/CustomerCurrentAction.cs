// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Customer.Hapenis.CustomerCurrentAction
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.Z_AnimalsAndPeople.Sim_Person;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.PeopleInPark.PeopleView.Row.Info;

namespace TinyZoo.Z_SummaryPopUps.People.Customer.Hapenis
{
  internal class CustomerCurrentAction
  {
    public Vector2 location;
    private ZGenericText header;
    private CurrentActionDisplay currentActionDisplay;

    public CustomerCurrentAction(float BaseScale)
    {
      this.header = new ZGenericText("Current Action:", BaseScale, false);
      this.currentActionDisplay = new CurrentActionDisplay(BaseScale);
      this.currentActionDisplay.location.Y = this.header.GetSize().Y;
      this.currentActionDisplay.location.Y += this.currentActionDisplay.GetHeight() * 0.5f;
    }

    public void UpdateCustomerCurrentAction(SimPerson simPerson, WalkingPerson walkingperson) => this.currentActionDisplay.UpdateCurrentAction(simPerson, walkingperson);

    public void DrawCustomerCurrentAction(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.header.DrawZGenericText(offset, spriteBatch);
      this.currentActionDisplay.DrawCurrentAction(offset, spriteBatch);
    }
  }
}
