// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.AnimalDeliveryUI.AnimalDeliveryDetailedView
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GenericUI;
using TinyZoo.PlayerDir.Animals;
using TinyZoo.PlayerDir.IntakeStuff;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Tile_Data;
using TinyZoo.Z_AnimalNotification;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_HUD.AnimalDeliveryUI
{
  internal class AnimalDeliveryDetailedView
  {
    public Vector2 location;
    private float basescale;
    private UIScaleHelper uiscale;
    private CustomerFrame frame;
    private Vector2 framescale;
    private BasicAnimalInfoBox infobox;
    private ZGenericText etaText;
    private ZGenericText costText;
    private TextButton cancelbutton;
    private AnimalOrder refOrderInfo;
    private static Color cream = new Color(ColourData.Z_Cream);

    public AnimalDeliveryDetailedView(IntakePerson animal, AnimalOrder orderInfo, float basescale_)
    {
      this.basescale = basescale_;
      this.refOrderInfo = orderInfo;
      this.uiscale = new UIScaleHelper(this.basescale);
      Vector2 defaultBuffer = this.uiscale.DefaultBuffer;
      this.infobox = new BasicAnimalInfoBox(new PrisonerInfo(animal, false, Vector2.Zero, CellBlockType.Count), this.basescale);
      this.cancelbutton = new TextButton(this.basescale, "Cancel Order", 70f);
      this.cancelbutton.SetButtonColour(BTNColour.Red);
      float num = this.uiscale.ScaleY(AssetContainer.springFont.MeasureString("whaTever Arby text").Y);
      this.framescale = this.infobox.GetSize() + 2f * defaultBuffer;
      this.framescale.Y += 2f * num + defaultBuffer.Y;
      this.framescale.Y += this.cancelbutton.GetSize_True().Y + defaultBuffer.Y;
      this.frame = new CustomerFrame(this.framescale, BaseScale: this.basescale);
      this.costText = new ZGenericText("", this.basescale, false);
      this.etaText = new ZGenericText("Arriving in: " + AnimalDeliveryListEntry.GetETAString(orderInfo), this.basescale, false);
      Vector2 vector2 = -0.5f * this.framescale + defaultBuffer;
      this.infobox.location.Y = vector2.Y + 0.5f * this.infobox.GetSize().Y;
      vector2.Y += this.infobox.GetSize().Y + defaultBuffer.Y;
      this.costText.vLocation = vector2;
      vector2.Y += num;
      this.etaText.vLocation = vector2;
      vector2.Y += num + defaultBuffer.Y;
      this.cancelbutton.vLocation = vector2;
      this.cancelbutton.vLocation.Y += 0.5f * this.cancelbutton.GetSize_True().Y;
      this.cancelbutton.vLocation.X = 0.0f;
    }

    public Vector2 GetSize() => this.framescale;

    public bool UpdateAnimalDeliveryDetailedView(Player player, Vector2 offset, float DeltaTime)
    {
      offset += this.location;
      int num = this.cancelbutton.UpdateTextButton(player, offset, DeltaTime) ? 1 : 0;
      this.etaText.textToWrite = "Arriving in: " + AnimalDeliveryListEntry.GetETAString(this.refOrderInfo);
      return num != 0;
    }

    public void DrawAnimalDeliveryDetailedView(SpriteBatch spritebatch, Vector2 offset)
    {
      offset += this.location;
      this.frame.DrawCustomerFrame(offset, spritebatch);
      this.infobox.DrawBasicAnimalInfoBox(offset, spritebatch);
      this.etaText.DrawZGenericText(offset, spritebatch);
      this.costText.DrawZGenericText(offset, spritebatch);
      this.cancelbutton.DrawTextButton(offset, 1f, spritebatch);
    }
  }
}
