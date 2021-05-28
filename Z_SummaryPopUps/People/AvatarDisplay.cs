// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.AvatarDisplay
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.AvatarViewer;

namespace TinyZoo.Z_SummaryPopUps.People
{
  internal class AvatarDisplay
  {
    private AvatarViewManager avatarViewManager;
    internal static bool DoLerp;

    public AvatarDisplay(WalkingPerson walkingPerson, Player player)
    {
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      Vector2 defaultBuffer = new UIScaleHelper(baseScaleForUi).DefaultBuffer;
      this.avatarViewManager = new AvatarViewManager(player, walkingPerson, baseScaleForUi);
      this.avatarViewManager.location = new Vector2(512f, 384f);
    }

    public bool CheckMouseOver(Player player, Vector2 offset) => this.avatarViewManager.CheckMouseOver(player, offset);

    public bool UpdateAvatarViewManager(Vector2 offset, Player player, float DeltaTime)
    {
      bool controlAvatar;
      if (!this.avatarViewManager.UpdateAvatarViewManager(player, DeltaTime, offset, out controlAvatar))
        return false;
      if (controlAvatar)
      {
        AvatarDisplay.DoLerp = true;
        OverWorldManager.overworldstate = OverWOrldState.PlayingAsAvatar;
      }
      return true;
    }

    public void DrawAvatarDisplay(Vector2 offset, SpriteBatch spriteBatch) => this.avatarViewManager.DrawAvatarViewManager(offset, spriteBatch);
  }
}
