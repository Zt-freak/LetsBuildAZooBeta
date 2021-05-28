// Decompiled with JetBrains decompiler
// Type: TinyZoo.GenericUI.FakeMouse.MHIST
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GenericUI.FakeMouse
{
  internal class MHIST
  {
    public Vector2 LocationInWorldSpace;
    public float Alpha;

    public MHIST(Vector2 Loc)
    {
      this.LocationInWorldSpace = RenderMath.TranslateScreenSpaceToWorldSpace(Loc);
      this.Alpha = 1f;
    }
  }
}
