// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.EventReport.ReportRewardSelect
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GenericUI;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_SummaryPopUps.EventReport.EventData;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_SummaryPopUps.EventReport
{
  internal class ReportRewardSelect
  {
    public Vector2 location;
    private float basescale;
    private UIScaleHelper scalehelper;
    private CustomerFrame frame;
    private Vector2 framescale;
    private SimpleTextHandler text;
    private MouseoverHandler mouseoverhandler;
    private ReportAction action;

    public ReportRewardSelect(ReportAction action_, float basescale_)
    {
      this.basescale = basescale_;
      this.scalehelper = new UIScaleHelper(this.basescale);
      Vector2 defaultBuffer = this.scalehelper.DefaultBuffer;
      this.action = action_;
      this.text = new SimpleTextHandler(this.action.GetDescription(), this.scalehelper.ScaleX(320f), _Scale: this.basescale, _UseFontOnePointFive: true);
      this.text.SetAllColours(ColourData.Z_Cream);
      this.text.AutoCompleteParagraph();
      this.framescale = 1f * defaultBuffer;
      this.framescale += this.text.GetSize();
      this.frame = new CustomerFrame(this.framescale, BaseScale: this.basescale);
      this.mouseoverhandler = new MouseoverHandler(this.framescale, basescale_);
      Vector2 vector2 = -0.5f * this.framescale;
      vector2.Y += 0.5f * defaultBuffer.Y;
      vector2.X += defaultBuffer.X;
      this.text.Location = vector2;
    }

    public Vector2 GetSize() => this.framescale;

    public string GetDescription() => this.action.GetDescription();

    public bool UpdateReportRewardSelect(Player player, Vector2 offset, float DeltaTime)
    {
      offset += this.location;
      bool flag = false;
      this.mouseoverhandler.UpdateMouseoverHandler(player, offset, DeltaTime);
      if (this.mouseoverhandler.Clicked)
        flag = true;
      return flag;
    }

    public void DrawReportRewardSelect(SpriteBatch spritebatch, Vector2 offset)
    {
      offset += this.location;
      this.frame.DrawCustomerFrame(offset, spritebatch);
      this.text.DrawSimpleTextHandler(offset, 1f, spritebatch);
      this.mouseoverhandler.DrawMouseOverHandler(spritebatch, offset);
    }
  }
}
