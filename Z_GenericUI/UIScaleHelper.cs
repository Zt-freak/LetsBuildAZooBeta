﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_GenericUI.UIScaleHelper
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.Z_GenericUI
{
  internal class UIScaleHelper
  {
    private float basescale = 1f;
    private static float rawDefaultBufferSize = 10f;

    public Vector2 DefaultBuffer => this.ScaleVector2(new Vector2(UIScaleHelper.rawDefaultBufferSize));

    public UIScaleHelper(float basescale_) => this.basescale = basescale_;

    public float ScaleX(float value) => value * this.basescale * Sengine.ScreenRatioUpwardsMultiplier.X;

    public float ScaleY(float value) => value * this.basescale * Sengine.ScreenRatioUpwardsMultiplier.Y;

    public Vector2 ScaleVector2(Vector2 value) => value * this.basescale * Sengine.ScreenRatioUpwardsMultiplier;

    public float GetDefaultXBuffer() => this.ScaleX(UIScaleHelper.rawDefaultBufferSize);

    public float GetDefaultYBuffer() => this.ScaleY(UIScaleHelper.rawDefaultBufferSize);
  }
}
