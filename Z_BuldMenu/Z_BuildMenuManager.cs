// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BuldMenu.Z_BuildMenuManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GenericUI;

namespace TinyZoo.Z_BuldMenu
{
  internal class Z_BuildMenuManager
  {
    private GameObjectNineSlice frameobject;
    private LerpHandler_Float Lerper;

    public Z_BuildMenuManager()
    {
      this.frameobject = new GameObjectNineSlice(StringInBox.GetFrameColourRect(BTNColour.Cream, out Vector3 _), 7);
      this.Lerper = new LerpHandler_Float();
      this.Lerper.SetLerp(true, 1f, 0.0f, 3f);
    }

    public void UpdateZ_BuildMenuManager(float DeltaTime) => this.Lerper.UpdateLerpHandler(DeltaTime);

    public void DrawZ_BuildMenuManager() => this.frameobject.DrawGameObjectNineSlice(AssetContainer.pointspritebatch03, AssetContainer.SpriteSheet, new Vector2(0.0f, (float) (668.0 + 100.0 * (double) this.Lerper.Value)), new Vector2(1024f, 200f));
  }
}
