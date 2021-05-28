// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Animal._01Animal.Longevity.LongevityHeaderAndBar
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_SummaryPopUps.People.Animal._01Animal.Longevity
{
  internal class LongevityHeaderAndBar
  {
    private LongevityBar longevitybar;
    public Vector2 Location;
    private ZGenericText TextHeader;
    private ZGenericText SecondText;
    private Vector2 size;

    public LongevityHeaderAndBar(PrisonerInfo animal, Vector2 VSCale, float BaseScale)
    {
      this.longevitybar = new LongevityBar(animal, 1f, BaseScale);
      this.TextHeader = new ZGenericText("Longevity", BaseScale, false, _UseOnePointFiveFont: true);
      string str = "Child";
      if (!animal.GetIsABaby())
        str = !animal.GetCanHaveBaby() ? "Elderly" : "Adult";
      int num1 = animal.Age / 365;
      int num2 = animal.Age % 365;
      string _textToWrite;
      if (num1 > 0)
        _textToWrite = str + ", " + (object) num1 + " years " + (object) num2 + " days";
      else
        _textToWrite = str + ", " + (object) num2 + " days";
      this.SecondText = new ZGenericText(_textToWrite, BaseScale, false);
      this.size = Vector2.Zero;
      this.TextHeader.vLocation = this.size;
      this.size.Y += this.TextHeader.GetSize().Y;
      this.SecondText.vLocation = this.size;
      this.size.Y += this.SecondText.GetSize().Y;
      this.longevitybar.Location = this.size;
      this.size.Y += this.longevitybar.GetSize().Y;
      this.size.X = Math.Max(this.longevitybar.GetSize().X, this.TextHeader.GetSize().X);
      this.size.X = Math.Max(this.size.X, this.SecondText.GetSize().X);
    }

    public Vector2 GetSize() => this.size;

    public void UpdateLongevityHeaderAndBar()
    {
    }

    public void DrawLongevityHeaderAndBar(Vector2 Offset, SpriteBatch spriteBatch)
    {
      Offset += this.Location;
      this.TextHeader.DrawZGenericText(Offset, spriteBatch);
      this.SecondText.DrawZGenericText(Offset, spriteBatch);
      this.longevitybar.DrawLongevityBar(Offset);
    }
  }
}
