// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.GraveYardCutScene.GraveYardCutScenePlayer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.OverWorld.OverWorldEnv;
using TinyZoo.Tutorials;

namespace TinyZoo.OverWorld.GraveYardCutScene
{
  internal class GraveYardCutScenePlayer
  {
    private SmartCharacterBox charactertextbox;
    private float Timer;

    public GraveYardCutScenePlayer(Player player)
    {
      OverWorldEnvironmentManager.overworldcam.CenterCam();
      this.charactertextbox = new SmartCharacterBox(string.Format("{0} inmates have been added to the cemetery.~Visit their graves for reanimation options.", (object) player.livestats.NewlyDeads.Count), AnimalType.Administrator);
      Vector2Int LocationOfLastGrave = new Vector2Int();
      player.livestats.TransferNewlyDeadsToGraveYards(player, ref LocationOfLastGrave);
      Vector2 tileToWorldSpace = TileMath.GetTileToWorldSpace(LocationOfLastGrave);
      OverWorldEnvironmentManager.overworldcam.DoPan(new Vector3(tileToWorldSpace.X, tileToWorldSpace.Y, 4f), 0.5f);
      player.OldSaveThisPlayer();
    }

    public bool UpdateGraveYardCutScenePlayer(float DeltaTime, Player player)
    {
      this.Timer += DeltaTime;
      return this.charactertextbox.UpdateSmartCharacterBox(DeltaTime, player, (double) this.Timer < 2.0);
    }

    public void DrawGraveYardCutScenePlayer() => this.charactertextbox.DrawSmartCharacterBox();
  }
}
