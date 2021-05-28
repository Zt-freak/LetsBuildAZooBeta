// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalNotification.StatBox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_AnimalNotification
{
  internal class StatBox
  {
    private CustomerFrame frame;
    private float basescale;
    private UIScaleHelper uiScale;

    public StatBox(float basescale_)
    {
      this.basescale = basescale_;
      this.uiScale = new UIScaleHelper(this.basescale);
    }
  }
}
