// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Research_.ResearcherInfo.ResearcherSummary
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System.Collections.Generic;
using TinyZoo.PlayerDir;

namespace TinyZoo.Z_Research_.ResearcherInfo
{
  internal class ResearcherSummary
  {
    public Vector2 location;
    private List<MiniResearchGuy> researchers;
    private float Ybuffer;

    public ResearcherSummary(
      Player player,
      float BaseScale,
      bool UseExtraMiniVersion = false,
      bool IsForResearchBuilding = false)
    {
      this.researchers = new List<MiniResearchGuy>();
      this.Ybuffer = 10f * Sengine.ScreenRatioUpwardsMultiplier.Y * BaseScale;
      for (int index = 0; index < player.employees.employees.Count; ++index)
      {
        if (player.employees.employees[index].employeetype == EmployeeType.Architect)
        {
          this.researchers.Add(new MiniResearchGuy(player.employees.employees[index], BaseScale, UseExtraMiniVersion, IsForResearchBuilding));
          this.researchers[this.researchers.Count - 1].Location += this.researchers[this.researchers.Count - 1].GetSize() * 0.5f;
          this.researchers[this.researchers.Count - 1].Location.Y += (float) (this.researchers.Count - 1) * (this.researchers[this.researchers.Count - 1].GetSize().Y + this.Ybuffer);
        }
      }
    }

    public Vector2 GetSize()
    {
      if (this.researchers.Count <= 0)
        return Vector2.Zero;
      Vector2 size = this.researchers[0].GetSize();
      float y = size.Y * (float) this.researchers.Count;
      if (this.researchers.Count > 1)
        y += this.Ybuffer * (float) (this.researchers.Count - 1);
      return new Vector2(size.X, y);
    }

    public int GetNumberOfResearchersShown() => this.researchers.Count;

    public void UpdateResearcherSummary(Player player, float DeltatTime)
    {
      for (int index = 0; index < this.researchers.Count; ++index)
        this.researchers[index].UpdateMiniResearchGuy();
    }

    public void DrawResearcherSummary(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      for (int index = 0; index < this.researchers.Count; ++index)
        this.researchers[index].DrawMiniResearchGuy(offset, spriteBatch);
    }
  }
}
