// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.Research.ResearchTimer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.OverWorld.Research.ResearchEntry;

namespace TinyZoo.OverWorld.Research
{
  internal class ResearchTimer
  {
    private TimerRemainingrender timeremaining;

    public ResearchTimer(Player player) => this.timeremaining = new TimerRemainingrender();

    public void UpdateResearchTimer(float DeltaTime, Player player) => this.timeremaining.UpdateTimerRemainingrender(player, DeltaTime);

    public bool IsReadyToClaim() => this.timeremaining.IsReadyToClaim();

    public void DrawResearchTimer(Vector2 Offset) => this.timeremaining.DrawTimerRemainingrender(Offset);
  }
}
