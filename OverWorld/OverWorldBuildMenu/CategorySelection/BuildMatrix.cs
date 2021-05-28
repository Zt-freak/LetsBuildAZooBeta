// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.OverWorldBuildMenu.CategorySelection.BuildMatrix
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine.Input;

namespace TinyZoo.OverWorld.OverWorldBuildMenu.CategorySelection
{
  internal class BuildMatrix
  {
    private ControllerGridNavMatrix gridmatrix;
    public int Selected;
    private bool ForceSelected;
    public int ForceSelectThis = -1;

    public BuildMatrix(int _TotalPerRow, int _Total, int ForceSelectThis = -1)
    {
      this.Selected = ForceSelectThis;
      this.gridmatrix = new ControllerGridNavMatrix(_TotalPerRow, _Total, ForceSelectThis);
      this.ForceSelected = false;
    }

    public void ForceSelect(int NewIndex)
    {
      this.Selected = NewIndex;
      this.gridmatrix.SelectedIndex = NewIndex;
    }

    public bool UpdateBuildMatrix(Player player, float DeltaTime)
    {
      if (this.ForceSelected)
        return false;
      this.ForceSelected = true;
      return true;
    }
  }
}
