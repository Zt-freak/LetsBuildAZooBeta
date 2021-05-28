// Decompiled with JetBrains decompiler
// Type: TinyZoo.SplashScreen.SplashLogo
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.SplashScreen
{
  internal class SplashLogo : GameObject
  {
    private bool USEFULLSCREEN = true;
    private NMR_Logo nmrlogo;

    public SplashLogo()
    {
      this.DrawRect = new Rectangle(5, 0, 53, 14);
      this.scale = 10f;
      this.vLocation = Sengine.ReferenceScreenRes * 0.5f;
      this.vLocation.X += 6f;
      this.SetDrawOriginToCentre();
      this.vLocation.X = 256f;
      this.scale *= 0.3f;
      this.nmrlogo = new NMR_Logo();
    }

    public void UpdateSplahs(float DeltaTime) => this.nmrlogo.UpdateNMR_Logo(DeltaTime);

    public void DrawSplashLogo()
    {
      this.Draw(AssetContainer.pointspritebatch01, AssetContainer.SpriteSheet);
      this.nmrlogo.DrawNMR_Logo();
    }
  }
}
