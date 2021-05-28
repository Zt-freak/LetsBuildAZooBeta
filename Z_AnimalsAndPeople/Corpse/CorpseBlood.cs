// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Corpse.CorpseBlood
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.Z_DayNight;

namespace TinyZoo.Z_AnimalsAndPeople.Corpse
{
  internal class CorpseBlood : GameObject
  {
    public CorpseBlood()
    {
      this.DrawRect = new Rectangle(1243, 66, 27, 11);
      this.SetDrawOriginToCentre();
    }

    public void DrawCorpseBlood(Vector2 WorldLocation)
    {
      this.vLocation = WorldLocation;
      this.SetAllColours(DayNightManager.SunShineValueR, DayNightManager.SunShineValueG, DayNightManager.SunShineValueB);
      this.WorldOffsetDraw(AssetContainer.pointspritebatch01, AssetContainer.AnimalSheet);
    }
  }
}
