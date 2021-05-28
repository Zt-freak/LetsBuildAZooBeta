// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_ManageEmployees.EmployeeView.PerformanceTableRowFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_ManageEmployees.EmployeeView.PerformanceTable;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_ManageEmployees.EmployeeView
{
  internal class PerformanceTableRowFrame
  {
    public Vector2 location;
    private SplitFrame splitFrame;
    private CustomerFrame customerFrame;
    private RowSegmentRectangle[] rectangles;
    private RowSegmentRectangle[] colouredOverlay;
    private MouseoverHandler mouseOverHandler;
    private float[] refWidths;
    private float refHeight;

    public PerformanceTableRowFrame(
      float BaseScale,
      float Height,
      bool isSplitHeader,
      bool isBlueSplitHeader,
      params float[] widths)
    {
      this.Create(BaseScale, Height, isSplitHeader, isBlueSplitHeader, CustomerFrameColors.Brown, Vector3.Zero, widths);
    }

    public PerformanceTableRowFrame(
      float BaseScale,
      float Height,
      CustomerFrameColors frameColor,
      params float[] widths)
    {
      this.Create(BaseScale, Height, false, false, frameColor, Vector3.Zero, widths);
    }

    public PerformanceTableRowFrame(
      float BaseScale,
      float Height,
      Vector3 frameColor,
      params float[] widths)
    {
      this.Create(BaseScale, Height, false, false, CustomerFrameColors.Count, frameColor, widths);
    }

    private void Create(
      float BaseScale,
      float Height,
      bool isSplitHeader,
      bool isBlueSplitHeader,
      CustomerFrameColors frameColor,
      Vector3 customFrameColor,
      params float[] widths)
    {
      this.refWidths = widths;
      this.refHeight = Height;
      this.rectangles = new RowSegmentRectangle[widths.Length];
      float x = 0.0f;
      for (int index = 0; index < widths.Length; ++index)
      {
        if (index % 2 == 1)
        {
          RowSegmentRectangle segmentRectangle = new RowSegmentRectangle(widths[index], Height);
          segmentRectangle.vLocation.X = x + widths[index] * 0.5f;
          this.rectangles[index] = segmentRectangle;
        }
        x += widths[index];
      }
      Vector2 vector2 = new Vector2(x, Height);
      if (isSplitHeader)
        this.splitFrame = !isBlueSplitHeader ? new SplitFrame(vector2, BaseScale, 0.5f) : new SplitFrame(vector2, ColourData.Z_FrameBlueDarker, ColourData.Z_FrameBluePale, BaseScale, 0.5f);
      else
        this.customerFrame = frameColor == CustomerFrameColors.Count ? new CustomerFrame(vector2, customFrameColor, BaseScale) : new CustomerFrame(vector2, frameColor, BaseScale);
      for (int index = 0; index < this.rectangles.Length; ++index)
      {
        if (this.rectangles[index] != null)
          this.rectangles[index].vLocation.X -= x * 0.5f;
      }
      this.mouseOverHandler = new MouseoverHandler(vector2, BaseScale);
    }

    public Vector2 GetSize() => this.splitFrame != null ? this.splitFrame.VSCale : this.customerFrame.VSCale;

    public void ColorThisColumnRed(int columnIndex) => this.ColorThisColumn(columnIndex, ColourData.Z_FrameRedDarker);

    public void ColorThisColumnGreen(int columnIndex) => this.ColorThisColumn(columnIndex, ColourData.Z_FrameGreenDarker);

    public void ColorThisColumn(int columnIndex, Vector3 colour)
    {
      if (this.colouredOverlay == null)
        this.colouredOverlay = new RowSegmentRectangle[this.rectangles.Length];
      RowSegmentRectangle segmentRectangle = new RowSegmentRectangle(this.refWidths[columnIndex], this.refHeight, colour, 1f);
      float num = 0.0f;
      for (int index = 0; index < this.refWidths.Length; ++index)
      {
        num += this.refWidths[index];
        if (index == columnIndex)
        {
          num -= this.refWidths[index] * 0.5f;
          break;
        }
      }
      segmentRectangle.vLocation.X = num - this.customerFrame.VSCale.X * 0.5f;
      this.colouredOverlay[columnIndex] = segmentRectangle;
    }

    public bool UpdateFrameForMouseOver(Player player, float DeltaTime, Vector2 offset)
    {
      offset += this.location;
      this.mouseOverHandler.UpdateMouseoverHandler(player, offset, DeltaTime);
      return this.mouseOverHandler.Clicked;
    }

    public void DrawPerformanceTableRowFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      if (this.splitFrame != null)
        this.splitFrame.DrawSplitFrame(offset, spriteBatch);
      else
        this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      for (int index = 0; index < this.rectangles.Length; ++index)
      {
        if (this.colouredOverlay != null && this.colouredOverlay[index] != null)
          this.colouredOverlay[index].DrawRowSegmentRectangle(offset, spriteBatch);
        if (this.rectangles[index] != null)
          this.rectangles[index].DrawRowSegmentRectangle(offset, spriteBatch);
      }
    }

    public void PostDrawPerformanceTableRowFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.mouseOverHandler.DrawMouseOverHandler(spriteBatch, offset);
    }
  }
}
