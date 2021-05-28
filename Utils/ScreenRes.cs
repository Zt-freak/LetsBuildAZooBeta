// Decompiled with JetBrains decompiler
// Type: TinyZoo.Utils.ScreenRes
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;

namespace TinyZoo.Utils
{
  internal class ScreenRes
  {
    internal static void initializeScreenRes(
      GraphicsDeviceManager graphics,
      GraphicsDevice _GraphicsDevice)
    {
      Flags.SetPlatformOrientationForReferenceScreenRes(true);
      graphics.PreferredBackBufferWidth = 1280;
      graphics.PreferredBackBufferHeight = 720;
      graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
      graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
      graphics.IsFullScreen = true;
    }
  }
}
