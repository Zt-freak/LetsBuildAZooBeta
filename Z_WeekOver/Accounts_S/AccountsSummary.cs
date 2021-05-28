// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WeekOver.Accounts_S.AccountsSummary
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Z_Manage.Accounts.GraphView;

namespace TinyZoo.Z_WeekOver.Accounts_S
{
  internal class AccountsSummary
  {
    private GraphManager graphmanager;
    private TextButton Next;

    public AccountsSummary(Player player)
    {
      this.Next = new TextButton(nameof (Next), 40f);
      this.Next.vLocation = new Vector2(900f, 700f);
      this.graphmanager = new GraphManager(player, true);
    }

    public bool UpdateAccountsSummary(Player player, float DeltaTime, Vector2 Offset)
    {
      this.graphmanager.UpdateGraphManager(player, DeltaTime, Offset);
      return (double) Offset.X == 0.0 && this.Next.UpdateTextButton(player, Offset, DeltaTime);
    }

    public void DrawAccountsSummary(Vector2 Offset)
    {
      this.graphmanager.DrawGraphManager(Offset);
      this.Next.DrawTextButton(Offset, 1f, AssetContainer.pointspritebatchTop05);
    }
  }
}
