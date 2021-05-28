// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.Employee.ShopKeeper.ShopKeeperInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Z_Employees.Emp_Summary;
using TinyZoo.Z_Employees.QuickPick;
using TinyZoo.Z_SummaryPopUps.People.Employee.ShopKeeper.PerformanceRecord;

namespace TinyZoo.Z_SummaryPopUps.People.Employee.ShopKeeper
{
  internal class ShopKeeperInfo
  {
    public EmployeeSummaryPanel panel;
    private ShopKeeperRecordDisplay shopkeeperrecord;

    public ShopKeeperInfo(QuickEmployeeDescription quickemployeedesc, Player player)
    {
      this.panel = new EmployeeSummaryPanel(quickemployeedesc, true);
      this.panel.location = this.panel.brownFrame.VSCale * 0.5f;
      this.panel.location += new Vector2(10f, 50f);
      this.shopkeeperrecord = new ShopKeeperRecordDisplay(quickemployeedesc, player, new Vector2(300f, 210f));
      this.shopkeeperrecord.Location = this.panel.location + new Vector2((float) ((double) this.panel.brownFrame.VSCale.X * 0.5 + 10.0 + (double) this.shopkeeperrecord.brownFrame.VSCale.X * 0.5), 0.0f);
    }

    public void UpdateShopKeeperInfo(float DeltaTime, Player player, Vector2 Offset)
    {
      this.panel.UpdateEmployeeSummary(DeltaTime, player, Offset);
      this.shopkeeperrecord.UpdateShopKeeperRecordDisplay(player, DeltaTime, Offset);
    }

    public void DrawShopKeeperInfo(Vector2 Offset)
    {
      this.panel.DrawEmployeeSummary(Offset);
      this.shopkeeperrecord.DrawShopKeeperRecordDisplay(Offset);
    }
  }
}
