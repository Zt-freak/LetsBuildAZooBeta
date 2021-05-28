// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Architcture.Z_ArchitectManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Z_Architcture.NeedAthing;

namespace TinyZoo.Z_Architcture
{
  internal class Z_ArchitectManager
  {
    private NeedSomeArch needsomearchitects;
    private ResearchTreeDisplay researchtreedisplay;

    public Z_ArchitectManager(Player player)
    {
      if (!player.prisonlayout.HasAnArchitectureBuilding())
        this.needsomearchitects = new NeedSomeArch(true);
      else if (player.employees.GetTotalArchitects() == 0)
        this.needsomearchitects = new NeedSomeArch(false);
      else
        this.researchtreedisplay = new ResearchTreeDisplay(player);
      this.needsomearchitects = (NeedSomeArch) null;
      this.researchtreedisplay = new ResearchTreeDisplay(player);
    }

    public void UpdateZ_ArchitectManager(Player player, float DeltaTime)
    {
      if (this.needsomearchitects != null)
        this.needsomearchitects.UpdateNeedSomeArch(DeltaTime, player);
      else
        this.researchtreedisplay.UpdateResearchTreeDisplay(player, DeltaTime);
    }

    public void DrawZ_ArchitectManager()
    {
      if (this.needsomearchitects != null)
        this.needsomearchitects.DrawNeedSomeArch();
      else
        this.researchtreedisplay.DrawResearchTreeDisplay();
    }
  }
}
