// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Layout.CellBlocks.BeamEntry
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GamePlay.beams;

namespace TinyZoo.PlayerDir.Layout.CellBlocks
{
  internal class BeamEntry
  {
    private Vector2 Location;
    public bool Horizontal;
    public bool WasDetonated;
    public int BeamType;

    public BeamEntry(Vector2 _Location, bool _Vertical, bool _WasDetonated)
    {
      this.Horizontal = _Vertical;
      this.Location = _Location;
    }

    public Vector2 GetLocation() => this.Location * Sengine.ScreenRatioUpwardsMultiplier;

    public BeamEntry(BeamCenter centerbeam)
    {
      this.Location = centerbeam.vLocation;
      this.Location.Y *= Sengine.ScreenRationReductionMultiplier.Y;
      this.Horizontal = centerbeam.IsHorizontal;
      this.WasDetonated = centerbeam.BeamWasHitByHuman;
    }

    public void SaveBeamEntry(Writer writer)
    {
      writer.WriteVector2("g", this.Location);
      writer.WriteBool("g", this.Horizontal);
      writer.WriteBool("g", this.WasDetonated);
      writer.WriteInt("g", this.BeamType);
    }

    public BeamEntry(Reader reader)
    {
      this.Location = reader.ReadVector2("g");
      int num1 = (int) reader.ReadBool("g", ref this.Horizontal);
      int num2 = (int) reader.ReadBool("g", ref this.WasDetonated);
      int num3 = (int) reader.ReadInt("g", ref this.BeamType);
    }
  }
}
