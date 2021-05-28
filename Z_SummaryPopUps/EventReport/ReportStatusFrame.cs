// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.EventReport.ReportStatusFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_SummaryPopUps.EventReport
{
  internal class ReportStatusFrame
  {
    protected float basescale;
    protected UIScaleHelper scalehelper;
    protected Vector2 pad;
    protected Vector2 framescale;
    public Vector2 location;

    public ReportStatusFrame(float basescale_)
    {
      this.basescale = basescale_;
      this.scalehelper = new UIScaleHelper(this.basescale);
      this.pad = this.scalehelper.DefaultBuffer;
    }

    public virtual Vector2 GetSize() => this.framescale;

    public virtual bool UpdateReportStatusFrame(Player player, Vector2 offset, float DeltaTime)
    {
      offset += this.location;
      return false;
    }

    public virtual void DrawReportStatusFrame(SpriteBatch spritebatch, Vector2 offset) => offset += this.location;
  }
}
