// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.ZHudManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.OverWorld;
using TinyZoo.Z_HUD.ControlHint;
using TinyZoo.Z_HUD.PointAtThings;
using TinyZoo.Z_HUD.TopBar;
using TinyZoo.Z_HUD.Z_HeroQuests_Pins;
using TinyZoo.Z_HUD.Z_Notification.NotificationBubble;
using TinyZoo.Z_Notification;

namespace TinyZoo.Z_HUD
{
  internal class ZHudManager
  {
    private TopBarManager topbarmanager;
    internal static Z_QuestPinManager zquestpins;
    private Z_NotificationManager Znotificationmanager;
    private Z_BusStatus ZbusStatus;
    private ControlHintMaster controlhintmaster;
    private PointOffScreenManager pointoffscreenmanager;

    public ZHudManager(Player player)
    {
      ZHudManager.zquestpins = new Z_QuestPinManager();
      this.topbarmanager = new TopBarManager(player);
      this.Znotificationmanager = new Z_NotificationManager();
      this.ZbusStatus = new Z_BusStatus();
      this.controlhintmaster = new ControlHintMaster();
      this.pointoffscreenmanager = new PointOffScreenManager();
    }

    public bool CheckMouseOver(Player player) => (0 | (this.topbarmanager.CheckMouseOver(player) ? 1 : 0) | (this.Znotificationmanager.CheckMouseOver(player) ? 1 : 0) | (ZHudManager.zquestpins.CheckMouseOver(player) ? 1 : 0) | (this.controlhintmaster.CheckMouseOver(player) ? 1 : 0)) != 0;

    public void UpdateZHudManager(Player player, float DeltaTime)
    {
      ZHudManager.zquestpins.UpdateZ_QuestPinManager(player, DeltaTime);
      this.topbarmanager.UpdateTopBarManager(player, DeltaTime);
      this.pointoffscreenmanager.UpdatePointOffScreenManager(player, DeltaTime);
      this.controlhintmaster.UpdateControlHintMaster(DeltaTime, player);
      this.Znotificationmanager.UpdateZ_NotificationManager(player, DeltaTime);
      this.ZbusStatus.UpdateZ_BusStatus(DeltaTime);
      NotificationBubbleManager.Instance.UpdateNotificationBubbleManager(player, DeltaTime);
    }

    public void LateUpdate(float DeltaTime, Player player)
    {
    }

    public void DrawBussHUD()
    {
      if (TrailerDemoFlags.HasTrailerFlag)
        return;
      this.ZbusStatus.DrawZ_BusStatus();
    }

    public void DrawZHudManager(OverwoldMainButtons overworldbuttons)
    {
      this.topbarmanager.DrawTopBarManager(overworldbuttons);
      ZHudManager.zquestpins.DrawZ_QuestPinManager();
      this.pointoffscreenmanager.DrawPointOffScreenManager();
      this.Znotificationmanager.DrawZ_NotificationManager();
      this.controlhintmaster.DrawControlHintMaster(AssetContainer.pointspritebatch03);
      NotificationBubbleManager.Instance.DrawNotificationBubbleManager();
    }
  }
}
