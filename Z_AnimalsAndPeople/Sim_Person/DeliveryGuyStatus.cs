// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.DeliveryGuyStatus
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person
{
  internal enum DeliveryGuyStatus
  {
    DoingNothing,
    OnWayToJob,
    WaitingForDoorToOpen,
    WalkingThroughTheDoorAndOffCollision,
    AtLocationWaitingForDoorToClose,
    AtJobWaiting,
    isInternalNavigating,
    InternalNavigationWaiting,
    WaitingForDoorToOpenToExit,
    ExitingThoughDoor,
    WaitingForDoorToCloseAfterExit,
    WalkingToGateToLeaveInterior,
  }
}
