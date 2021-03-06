// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.Z_Notification.Notifications.Generic.GenericNotificationManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.Z_HUD.PointAtThings;
using TinyZoo.Z_HUD.Z_Notification.NotificationRibbon;
using TinyZoo.Z_Notification;

namespace TinyZoo.Z_HUD.Z_Notification.Notifications.Generic
{
  internal class GenericNotificationManager
  {
    private GenericNotificationPanel genericPanel;
    private List<NotificationPackage> Ref_notifications;
    private Z_NotificationType notiftype;

    public GenericNotificationManager(List<NotificationPackage> _notifications)
    {
      this.Ref_notifications = _notifications;
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      NotificationPackage refNotification = this.Ref_notifications[0];
      bool everythingsok = false;
      if (refNotification.AlertStatus == NotificationAlertStatus.Tick)
        everythingsok = true;
      string notificationHeaderText = NotificationData.GetNotificationHeaderText(this.Ref_notifications[0]);
      string notificationBodyText = NotificationData.GetNotificationBodyText(this.Ref_notifications[0], everythingsok);
      this.notiftype = this.Ref_notifications[0].notificationtype;
      string textButtonText = "Track";
      if (everythingsok)
        textButtonText = string.Empty;
      this.genericPanel = new GenericNotificationPanel(notificationHeaderText, notificationBodyText, textButtonText, baseScaleForUi);
      this.genericPanel.location = new Vector2(512f, 384f);
    }

    public bool CheckMouseOver(Player player) => this.genericPanel.CheckMouseOver(player, Vector2.Zero);

    public bool UpdateGenericNotificationManager(Player player, float DeltaTime)
    {
      bool TrackThis;
      if (!this.genericPanel.UpdateGenericNotificationPanel(player, DeltaTime, Vector2.Zero, out TrackThis))
        return false;
      if (!TrackThis)
        return true;
      switch (this.notiftype)
      {
        case Z_NotificationType.A_AnimalBirth:
        case Z_NotificationType.A_AnimalHunger:
        case Z_NotificationType.A_AnimalDeath:
        case Z_NotificationType.A_AnimalSick:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
        case Z_NotificationType.F_GateBroke:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
        case Z_NotificationType.F_BuildABench:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildABench, player);
          break;
        case Z_NotificationType.F_BuildABin:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildABin, player);
          break;
        case Z_NotificationType.A_AddAnimalsToYourPen:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
        case Z_NotificationType.A_NoWater:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
        case Z_NotificationType.A_NoEnrichment:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
        case Z_NotificationType.A_BuildAnotherPen:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildAPen, player);
          break;
        case Z_NotificationType.F_BuildAnyShop:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildAnyShop, player);
          break;
        case Z_NotificationType.F_BuildAFoodShop:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildAFoodShop, player);
          break;
        case Z_NotificationType.F_BuildADrinksShop:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildADrinksShop, player);
          break;
        case Z_NotificationType.F_BuildAGiftShop:
          ZHudManager.zquestpins.PinRibbonTrackView(OffscreenPointerType.BuildAGiftShop, player);
          break;
        case Z_NotificationType.F_AShopNeedsAnEmployee:
        case Z_NotificationType.F_AJobHasApplicants:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
        case Z_NotificationType.TicketPrice:
          PointOffScreenManager.AddPointerFromNotification(this.Ref_notifications);
          break;
      }
      return true;
    }

    public void DrawGenericNotificationManager() => this.genericPanel.DrawGenericNotificationPanel(Vector2.Zero, AssetContainer.pointspritebatchTop05);
  }
}
