// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WeekOver.V2.Cubes.CubeComponents.Cube_Paragraph
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GenericUI;

namespace TinyZoo.Z_WeekOver.V2.Cubes.CubeComponents
{
  internal class Cube_Paragraph
  {
    private SimpleTextHandler text;
    public Vector2 Location;

    public Cube_Paragraph(string Text, float BaseScale)
    {
      this.text = new SimpleTextHandler(Text, 180f * BaseScale, true, BaseScale);
      this.text.AutoCompleteParagraph();
    }

    public void UpdateCube_Paragraph()
    {
    }

    public void DrawCube_Paragraph(Vector2 Offset, SpriteBatch spritebatch)
    {
      Offset += this.Location;
      this.text.DrawSimpleTextHandler(Offset, 1f, spritebatch);
    }
  }
}
