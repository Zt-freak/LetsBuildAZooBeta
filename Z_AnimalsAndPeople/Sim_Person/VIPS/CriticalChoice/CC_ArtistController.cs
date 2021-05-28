// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.Sim_Person.VIPS.CriticalChoice.CC_ArtistController
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_OverWorld;
using TinyZoo.Z_SummaryPopUps.EventReport.CriticalChoiceData;

namespace TinyZoo.Z_AnimalsAndPeople.Sim_Person.VIPS.CriticalChoice
{
  internal class CC_ArtistController
  {
    private DeliveryManController deliveryman;
    private CriticalChoiceType playerChoice = CriticalChoiceType.Count;
    private PrisonerInfo destinationAnimal;
    private PrisonZone destinationPen;
    private bool DoneWithJob;
    private bool IsPainting;

    public CC_ArtistController() => this.deliveryman = new DeliveryManController();

    public void UpdateCC_ArtistController(
      WalkingPerson walkingPerson,
      bool HasPoppedUp,
      float DeltaTime,
      WalkingPerson parent,
      ref bool IsPlayingWalkAnimation,
      ref bool BlockAutoWalk,
      Player player)
    {
      if (HasPoppedUp && this.playerChoice == CriticalChoiceType.Count)
      {
        int selectedChoice = walkingPerson.simperson.memberofthepublic.criticalchoiceVIP.SelectedChoice;
        if (selectedChoice != -1)
          this.playerChoice = TinyZoo.Z_SummaryPopUps.EventReport.CriticalChoiceData.CriticalChoiceData.GetCriticalChoiceSet(CustomerType.AnimalArtist).CriticalActions[selectedChoice].criticalchoicerype;
      }
      if (!this.deliveryman.IsDoingDelivery)
        return;
      if (this.deliveryman.deliveryguystatus == DeliveryGuyStatus.AtJobWaiting)
      {
        if (!this.UpdatePaintingAnimalInPen(walkingPerson))
          return;
        this.deliveryman.ExitJobLocation();
      }
      else
        this.deliveryman.UpdateDelivery(DeltaTime, ref IsPlayingWalkAnimation, player, walkingPerson, ref BlockAutoWalk, out bool _);
    }

    public void ReachedLocation(
      Vector2Int CurrentLocation,
      out bool SetNewPath,
      Player player,
      WalkingPerson walkingPerson,
      ref Vector2Int ForceGoHere,
      ref bool IsWalking,
      ref bool BlockAutoWalk,
      MemberOfThePublic member)
    {
      SetNewPath = false;
      if (this.deliveryman.IsDoingDelivery)
      {
        this.deliveryman.ReachedTargetLocation(CurrentLocation, ref BlockAutoWalk, ref IsWalking, out bool _);
      }
      else
      {
        if (this.playerChoice == CriticalChoiceType.Count || this.DoneWithJob)
          return;
        this.ReactToCriticalChoiceSelection(walkingPerson, player, ref ForceGoHere);
      }
    }

    private void ReactToCriticalChoiceSelection(
      WalkingPerson walkingPerson,
      Player player,
      ref Vector2Int ForceGoHere)
    {
      if (this.playerChoice == CriticalChoiceType.GetPaintedAnimal)
      {
        AnimalType animalType = AnimalType.Horse;
        foreach (PrisonZone prisonzone in player.prisonlayout.cellblockcontainer.prisonzones)
        {
          foreach (PrisonerInfo prisoner in prisonzone.prisonercontainer.prisoners)
          {
            if (!prisoner.IsDead && !prisoner.IsPainted && prisoner.intakeperson.animaltype == animalType)
            {
              this.destinationAnimal = prisoner;
              this.destinationPen = prisonzone;
              break;
            }
          }
        }
        if (this.destinationAnimal != null)
          this.deliveryman.TryToStartJourneyToPen(player, this.destinationPen.Cell_UID, walkingPerson, ref ForceGoHere);
      }
      int playerChoice = (int) this.playerChoice;
    }

    private bool UpdatePaintingAnimalInPen(WalkingPerson walkingPerson)
    {
      if (!this.IsPainting)
      {
        if (this.destinationPen.PaintAnAnimal(this.destinationAnimal))
        {
          this.IsPainting = true;
          MoneyRenderer.PopIcon(walkingPerson.vLocation, IconPopType.Painting);
        }
        else
        {
          this.destinationPen = (PrisonZone) null;
          this.destinationAnimal = (PrisonerInfo) null;
          return true;
        }
      }
      else
      {
        this.DoneWithJob = true;
        this.destinationPen = (PrisonZone) null;
        this.destinationAnimal = (PrisonerInfo) null;
      }
      return this.DoneWithJob;
    }
  }
}
