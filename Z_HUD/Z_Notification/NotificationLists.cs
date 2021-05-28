// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.Z_Notification.NotificationLists
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.Z_Notification;

namespace TinyZoo.Z_HUD.Z_Notification
{
  internal class NotificationLists
  {
    public List<NotificationPackage> notificationtotrack;

    public NotificationLists(List<NotificationPackage> _notificationtotrack) => this.notificationtotrack = _notificationtotrack;
  }
}
