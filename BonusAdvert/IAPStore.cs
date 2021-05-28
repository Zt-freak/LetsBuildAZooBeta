// Decompiled with JetBrains decompiler
// Type: TinyZoo.BonusAdvert.IAPStore
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.IAPScreen;
using TinyZoo.OverWorld.Store_Local.StoreBG;
using TinyZoo.Tutorials;

namespace TinyZoo.BonusAdvert
{
  internal class IAPStore
  {
    private StoreBGManager storeBG;
    private SmartCharacterBox charactertextbox;
    private IAPScreenManager iapscreen;

    public IAPStore(Player player) => this.iapscreen = new IAPScreenManager(player);

    public void UpdateIAPStore(Player player, float DeltaTime) => this.iapscreen.UpdateIAPScreenManager(player, DeltaTime);

    public void DrawIAPStore() => this.iapscreen.DrawIAPScreenManager();
  }
}
