// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Events.NewsCaster.NewsCasterManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_Notification;

namespace TinyZoo.Z_Events.NewsCaster
{
  internal class NewsCasterManager
  {
    private NewsTruck newstruck;
    private CasterAndCamera casterlady;
    private NewsText newstext;

    public NewsCasterManager(string Heading, string Body)
    {
      this.newstruck = new NewsTruck();
      this.casterlady = new CasterAndCamera();
      this.newstext = new NewsText(Heading, Body);
    }

    public void SetNewBodyText(string Body) => this.newstext.SetNewBodyText(Body);

    public void UpdateNewsCasterManager(float DeltaTime)
    {
      this.newstext.UpdateNewsText(DeltaTime);
      this.casterlady.UpdateCasterAndCamera(DeltaTime);
    }

    public bool RemoveThisEvent(Z_NotificationType thiseventjustended) => true;

    public void DrawNewsCasterManager()
    {
      this.newstruck.DrawNewsTruck();
      this.casterlady.DrawCasterAndCamera();
      if (GameFlags.PhotoMode)
        return;
      this.newstext.DrawNewsText();
    }
  }
}
