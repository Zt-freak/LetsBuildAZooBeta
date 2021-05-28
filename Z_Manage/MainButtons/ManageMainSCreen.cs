// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Manage.MainButtons.ManageMainSCreen
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;

namespace TinyZoo.Z_Manage.MainButtons
{
  internal class ManageMainSCreen
  {
    private mainButtonsManager mainbtns;

    public ManageMainSCreen() => this.mainbtns = new mainButtonsManager();

    public ManageButtonType UpdateManageMainSCreen(
      Player player,
      float DeltaTime,
      Vector2 Offset)
    {
      Z_GameFlags.BlockPointer = true;
      return this.mainbtns.UpdatemainButtonsManager(player, DeltaTime, Offset);
    }

    public void DrawManageMainSCreen(Vector2 Offset) => this.mainbtns.DrawmainButtonsManager(Offset);
  }
}
