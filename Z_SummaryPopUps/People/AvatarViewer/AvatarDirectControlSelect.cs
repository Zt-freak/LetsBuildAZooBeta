// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.AvatarViewer.AvatarDirectControlSelect
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TinyZoo.Z_SummaryPopUps.People.AvatarViewer
{
  internal class AvatarDirectControlSelect
  {
    public Vector2 location;
    private TextButton textButton;

    public AvatarDirectControlSelect(float BaseScale) => this.textButton = new TextButton(BaseScale, "Control", 50f);

    public Vector2 GetSize() => this.textButton.GetSize_True();

    public bool UpdateAvatarDirectControlSelect(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      return this.textButton.UpdateTextButton(player, offset, DeltaTime);
    }

    public void DrawAvatarDirectControlSelect(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.textButton.DrawTextButton(offset, 1f, spriteBatch);
    }
  }
}
