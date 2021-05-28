// Decompiled with JetBrains decompiler
// Type: TinyZoo.GenericUI.FingerPointer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GenericUI
{
  internal class FingerPointer : GameObject
  {
    private Rectangle BaseRect;
    private int Frames = 5;
    private int Frame;
    private float Timer;

    public FingerPointer()
    {
      this.BaseRect = new Rectangle(82, 0, 48, 29);
      this.DrawOrigin = new Vector2(13f, 13f);
    }

    public void UpdateFingerPointer(float DeltaTime)
    {
      if ((double) this.fAlpha == 1.0)
      {
        this.Timer += DeltaTime;
        if ((double) this.Timer > 0.100000001490116)
        {
          ++this.Frame;
          if (this.Frame < 5)
          {
            this.DrawRect = this.BaseRect;
            this.DrawRect.X += this.Frame * 49;
          }
          else if ((double) this.fTargetAlpha != 0.0)
            this.SetAlpha(false, 0.3f, 1f, 0.0f);
        }
      }
      this.UpdateColours(DeltaTime);
      if ((double) this.fAlpha != 0.0 || (double) this.fTargetAlpha != 0.0)
        return;
      this.DrawRect = this.BaseRect;
      this.SetAlpha(false, 0.2f, 0.0f, 1f);
      this.Timer = 0.0f;
      this.Frame = 0;
    }

    public void DrawFingerPointer(Vector2 Offset) => this.Draw(AssetContainer.pointspritebatchTop05, AssetContainer.UISheet, Offset);
  }
}
