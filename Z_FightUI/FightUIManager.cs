// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_FightUI.FightUIManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Z_MoralityActionUI;

namespace TinyZoo.Z_FightUI
{
  internal class FightUIManager
  {
    private MoralityActionUI actionUI;

    public FightUIManager() => this.actionUI = new MoralityActionUI(Z_GameFlags.GetBaseScaleForUI());

    public bool UpdateFightUIManager(Player player, Vector2 offset, float DeltaTime) => this.actionUI.UpdateMoralityActionUIManager(player, DeltaTime);

    public void DrawFightUIManager() => this.actionUI.DrawMoralityActionUIManager(Vector2.Zero, AssetContainer.pointspritebatchTop05);
  }
}
