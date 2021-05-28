// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.AvatarController
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PathFinding;
using TinyZoo.PlayerDir;
using TinyZoo.Z_AnimalsAndPeople.Sim_Person.Extras;
using TinyZoo.Z_OverWorld.AvatarUI;
using TinyZoo.Z_Trailer;

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person
{
  internal class AvatarController
  {
    private CharacterDirectController directcontroller;

    public AvatarController() => this.directcontroller = new CharacterDirectController();

    public void UpdateAvatarController(
      PathNavigator pathnavigator,
      Player player,
      float DeltaTime,
      Employee Ref_Employee,
      ref bool IsWalking,
      WalkingPerson Person)
    {
      if (OverWorldManager.overworldstate == OverWOrldState.PlayingAsAvatar || Z_GameFlags.IsWaitingToReturnToControllerWalk)
      {
        Person.AnimationFrameRate = 0.1f;
        if (Z_GameFlags.IsWaitingToReturnToControllerWalk)
        {
          this.directcontroller.Velocity = Vector2.Zero;
          return;
        }
        if (this.directcontroller.UpdateCharacterDirectController(player, DeltaTime, ref IsWalking, Person, pathnavigator))
          AvatarUIManager.SetNewCharacterLocation(Person, pathnavigator, player, true);
        else
          AvatarUIManager.SetNewCharacterLocation(Person, pathnavigator, player, false);
        if (player.inputmap.PressedBackOnController())
          OverWorldManager.overworldstate = OverWOrldState.MainMenu;
      }
      else
        Person.AnimationFrameRate = 0.2f;
      if (!TrailerDemoFlags.HasTrailerFlag)
        return;
      SpawnBlockArray.SetAvatarPostion(Person.vLocation);
    }
  }
}
