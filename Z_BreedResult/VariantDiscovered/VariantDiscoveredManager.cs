// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_BreedResult.VariantDiscovered.VariantDiscoveredManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GamePlay.Enemies;

namespace TinyZoo.Z_BreedResult.VariantDiscovered
{
  internal class VariantDiscoveredManager
  {
    private VariantDiscoveredPanel popup;

    public VariantDiscoveredManager(Player player, AnimalType type, int variant)
    {
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      this.popup = new VariantDiscoveredPanel(player, type, variant, baseScaleForUi);
      this.popup.location = Sengine.HalfReferenceScreenRes;
    }

    public bool CheckMouseOver(Player player) => this.popup.CheckMouseOver(player, Vector2.Zero);

    public bool UpdateVariantDiscoveredManager(Player player, float DeltaTime) => this.popup.UpdateVariantDiscoveredPanel(player, DeltaTime);

    public void DrawVariantDiscoveredManager() => this.popup.DrawVariantDiscoveredPanel(Vector2.Zero, AssetContainer.pointspritebatchTop05);
  }
}
