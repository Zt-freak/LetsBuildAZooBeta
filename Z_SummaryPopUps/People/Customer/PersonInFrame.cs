// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Customer.PersonInFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.OverWorld.OverWorldEnv.Customers;

namespace TinyZoo.Z_SummaryPopUps.People.Customer
{
  internal class PersonInFrame
  {
    private GameObject PersonFrame;
    private WalkingPerson refperson;
    public Vector2 Location;

    public PersonInFrame(WalkingPerson person, float MainScaleMultiplier = 1f)
    {
      this.refperson = person;
      this.PersonFrame = new GameObject();
      this.PersonFrame.DrawRect = new Rectangle(402, 381, 63, 63);
      this.PersonFrame.scale = 2f * Sengine.ScreenRationReductionMultiplier.Y * MainScaleMultiplier;
      this.PersonFrame.SetDrawOriginToCentre();
    }

    public void UpdatePersonInFrame()
    {
    }

    public void DrawPersonInFrame(Vector2 Offset, SpriteBatch spritebatch)
    {
      Offset += this.Location;
      this.PersonFrame.Draw(spritebatch, AssetContainer.SpriteSheet, Offset);
      this.refperson.ScreenSpaceDraw(Offset, spritebatch, 5f * Sengine.ScreenRationReductionMultiplier.Y);
    }
  }
}
