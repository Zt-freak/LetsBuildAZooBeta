// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalsAndPeople.DynamicEnrichment.AttachItemToAnimal
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.Z_AnimalsAndPeople.PenNav;

namespace TinyZoo.Z_AnimalsAndPeople.DynamicEnrichment
{
  internal class AttachItemToAnimal
  {
    private bool Attached;
    public Vector2Int WorldSpace;
    private AnimalRenderMan AttachedToThisAnimal;
    private float OriginExtra;
    private float HoldForThisLong;
    private float BlockPickUpForThisLong;

    public AttachItemToAnimal() => this.Attached = false;

    public void SetWorldSpaceLocation(Vector2Int _WorldSpace) => this.WorldSpace = _WorldSpace;

    public bool GetCanAttach() => !this.Attached && (double) this.BlockPickUpForThisLong <= 0.0;

    public void UpdateAttachItemToAnimal(
      float DeltaTime,
      ref GameObject EnrichmentObject,
      PenNavigator pennavigation)
    {
      if (this.Attached)
      {
        this.HoldForThisLong -= DeltaTime;
        if ((double) this.HoldForThisLong < 0.0 || this.AttachedToThisAnimal.REF_prisonerinfo.IsDead)
        {
          EnrichmentObject.SetDrawOriginToCentre();
          this.Attached = false;
          this.AttachedToThisAnimal.HoldingToy = false;
          this.BlockPickUpForThisLong = (float) TinyZoo.Game1.Rnd.Next(5, 20);
          pennavigation.CurrentWorldSpaceLocation = TileMath.GetWorldSpaceToTile(EnrichmentObject.vLocation);
          this.WorldSpace = pennavigation.CurrentWorldSpaceLocation;
        }
        else
        {
          EnrichmentObject.SetDrawOriginToCentre();
          EnrichmentObject.vLocation = this.AttachedToThisAnimal.enemyrenderere.vLocation;
          EnrichmentObject.vLocation.Y += this.OriginExtra;
          if ((double) this.AttachedToThisAnimal.enemyrenderere.DirectionFacing.X == -1.0)
            EnrichmentObject.DrawOrigin.X += (float) this.AttachedToThisAnimal.enemyrenderere.DrawRect.Width * 0.5f;
          else
            EnrichmentObject.DrawOrigin.X -= (float) this.AttachedToThisAnimal.enemyrenderere.DrawRect.Width * 0.5f;
          float num = (float) this.AttachedToThisAnimal.enemyrenderere.DrawRect.Height * 0.5f;
          EnrichmentObject.DrawOrigin.Y += num * this.AttachedToThisAnimal.enemyrenderere.animator.CurrentScale.Y;
          EnrichmentObject.vLocation.Y += 4f;
          EnrichmentObject.DrawOrigin.Y += 4f;
          EnrichmentObject.DrawOrigin.Y -= this.AttachedToThisAnimal.enemyrenderere.animator.PositionalOffset.Y * this.AttachedToThisAnimal.enemyrenderere.animator.CurrentScale.Y;
        }
      }
      else
      {
        if ((double) this.BlockPickUpForThisLong <= 0.0)
          return;
        this.BlockPickUpForThisLong -= DeltaTime;
      }
    }

    public void AttachToThisAnimal(AnimalRenderMan animalrenderer, int UID)
    {
      animalrenderer.LastInteractionPoint_UID = UID;
      this.AttachedToThisAnimal = animalrenderer;
      this.AttachedToThisAnimal.HoldingToy = true;
      this.Attached = true;
      this.HoldForThisLong = (float) TinyZoo.Game1.Rnd.Next(10, 30);
      this.OriginExtra = (float) animalrenderer.enemyrenderere.DrawRect.Height;
      this.OriginExtra -= animalrenderer.enemyrenderere.DrawOrigin.Y;
    }
  }
}
