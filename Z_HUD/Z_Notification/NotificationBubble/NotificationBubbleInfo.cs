// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_HUD.Z_Notification.NotificationBubble.NotificationBubbleInfo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_Collection.Shared.Grid;

namespace TinyZoo.Z_HUD.Z_Notification.NotificationBubble
{
  internal class NotificationBubbleInfo
  {
    public string heading;
    public string bodytext;
    public bool HoldForever;
    public NoticicationExtraIcon notificationicon;
    public AnimalRenderDescriptor animalRenderDescriptor;
    public NotificationBubbleFrameType frametype;

    public NotificationBubbleInfo(
      string heading_,
      string bodytext_,
      bool _HoldForever = false,
      NoticicationExtraIcon _notificationicon = NoticicationExtraIcon.None,
      AnimalRenderDescriptor _animalRenderDescriptor = null,
      NotificationBubbleFrameType _frametype = NotificationBubbleFrameType.Regular)
    {
      this.heading = heading_;
      this.bodytext = bodytext_;
      this.HoldForever = _HoldForever;
      this.notificationicon = _notificationicon;
      this.animalRenderDescriptor = _animalRenderDescriptor;
      this.frametype = _frametype;
    }
  }
}
