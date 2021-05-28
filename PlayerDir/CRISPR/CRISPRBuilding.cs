// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.CRISPR.CRISPRBuilding
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;
using TinyZoo.Z_Collection.Shared.Grid;

namespace TinyZoo.PlayerDir.CRISPR
{
  internal class CRISPRBuilding
  {
    public Vector2Int Location;
    public int BuildingUID;
    public List<CrisprActiveBreed> crisprBreeds;

    public CRISPRBuilding(Vector2Int _Location, int _UID)
    {
      this.Location = new Vector2Int(_Location);
      this.BuildingUID = _UID;
      this.crisprBreeds = new List<CrisprActiveBreed>();
    }

    public void AddGenomePair(CrisprActiveBreed breed) => this.crisprBreeds.Add(breed);

    public bool HasThisBreed(int UID)
    {
      for (int index = 0; index < this.crisprBreeds.Count; ++index)
      {
        if (this.crisprBreeds[index].UID == UID)
          return true;
      }
      return false;
    }

    public bool BreedIsComplete(
      int UID,
      Player player,
      ref bool WasNewVariant,
      out AnimalRenderDescriptor animalBorn)
    {
      animalBorn = (AnimalRenderDescriptor) null;
      for (int index = 0; index < this.crisprBreeds.Count; ++index)
      {
        if (this.crisprBreeds[index].UID == UID)
        {
          if (!this.crisprBreeds[index].IsBorn_CanCollect)
            animalBorn = this.crisprBreeds[index].DoBirth(player, ref WasNewVariant);
          return true;
        }
      }
      return false;
    }

    public void RemoveGenomePair(CrisprActiveBreed breed) => this.crisprBreeds.Remove(breed);

    public void StartNewDay(Player player)
    {
      for (int index = 0; index < this.crisprBreeds.Count; ++index)
        this.crisprBreeds[index].StartNewDay(player);
    }

    public CRISPRBuilding(Reader reader)
    {
      int num1 = (int) reader.ReadInt("c", ref this.BuildingUID);
      this.Location = new Vector2Int(reader);
      int _out = 0;
      int num2 = (int) reader.ReadInt("c", ref _out);
      this.crisprBreeds = new List<CrisprActiveBreed>();
      for (int index = 0; index < _out; ++index)
        this.crisprBreeds.Add(new CrisprActiveBreed(reader));
    }

    public void SaveCRISPRBuilding(Writer writer)
    {
      writer.WriteInt("c", this.BuildingUID);
      this.Location.SaveVector2Int(writer);
      writer.WriteInt("c", this.crisprBreeds.Count);
      for (int index = 0; index < this.crisprBreeds.Count; ++index)
        this.crisprBreeds[index].SaveCrisprActiveBreed(writer);
    }
  }
}
