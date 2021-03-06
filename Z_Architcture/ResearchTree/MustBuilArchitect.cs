// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Architcture.ResearchTree.MustBuilArchitect
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.Tutorials;

namespace TinyZoo.Z_Architcture.ResearchTree
{
  internal class MustBuilArchitect
  {
    private SmartCharacterBox charactertextbox;

    public MustBuilArchitect() => this.charactertextbox = new SmartCharacterBox("You need to build an architects office before you can start researching new structures.~~WHile you can employ 3 architects, local planning and zoning restrictions mean you can only ever have one architecture buiding in your zoo", AnimalType.Administrator, Height: 300f);

    public void UpdateMustBuilArchitect(float DeltaTime, Player player) => this.charactertextbox.UpdateSmartCharacterBox(DeltaTime, player, true, DoNotClearInput: true);

    public void DrawMustBuilArchitect() => this.charactertextbox.DrawSmartCharacterBox(new Vector2(0.0f, 250f));
  }
}
