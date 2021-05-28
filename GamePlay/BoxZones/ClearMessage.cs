// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.BoxZones.ClearMessage
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GamePlay.BoxZones
{
  internal class ClearMessage : GameObject
  {
    private Vector2 Location;

    public ClearMessage(Vector2 Loc)
    {
      this.Location = Loc;
      this.SetAlpha(false, 1f, 1f, 0.0f);
      this.SetColourDelay(0.5f);
      this.scale = 2f;
      this.DrawRect = new Rectangle(228, 225, 45, 11);
      this.SetDrawOriginToCentre();
    }

    public void UpdateClearMessage(float DeltaTime) => this.UpdateColours(DeltaTime);

    public void DrawClearMessage()
    {
      this.vLocation = RenderMath.TranslateWorldSpaceToScreenSpace(this.Location);
      this.vLocation.Y += (float) (1.0 - (double) this.fAlpha * 10.0);
      this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet);
    }
  }
}
