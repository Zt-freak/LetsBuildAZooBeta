// Decompiled with JetBrains decompiler
// Type: TinyZoo.FontSet_Korean_3_CJK
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;

namespace TinyZoo
{
  internal class FontSet_Korean_3_CJK : FontBase
  {
    public override void CreateFontSet(
      Dictionary<char, SpringFontCharacter> FontDictionary)
    {
      // ISSUE: The method is too long to display (51052 instructions)
    }

    public FontSet_Korean_3_CJK()
    {
      this.CharacterSet = CharSet.CJK;
      this.TextureFileName = "Fonts/KoreanFont_pg03";
      this.startIndex = 50058;
      this.endIndex = 53060;
    }
  }
}
