// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer.NewThingPanel
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_Collection.Shared.Grid;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_WorldMap.WorldMapPopUps.NewThingRenderer
{
  internal class NewThingPanel
  {
    public Vector2 location;
    private ScrollingBGPanel bigBrownPanel;
    private NewThingMainFrame mainFrame;
    private LerpHandler_Float lerper;
    private Vector2 lerpDistance;

    public NewThingPanel(List<PrisonerInfo> prisonerInfos)
    {
      List<AnimalRenderDescriptor> animals = new List<AnimalRenderDescriptor>(prisonerInfos.Count);
      foreach (PrisonerInfo prisonerInfo in prisonerInfos)
        animals.Add(new AnimalRenderDescriptor(prisonerInfo.intakeperson.animaltype, prisonerInfo.intakeperson.CLIndex, prisonerInfo.intakeperson.HeadType, prisonerInfo.intakeperson.HeadVariant, _IsFemale: prisonerInfo.intakeperson.IsAGirl));
      this.SetUp(animals);
    }

    public NewThingPanel(
      List<AnimalRenderDescriptor> animalRenderDescriptors)
    {
      this.SetUp(animalRenderDescriptors);
    }

    public NewThingPanel(List<AnimalType> animalsTypes)
    {
      List<AnimalRenderDescriptor> animals = new List<AnimalRenderDescriptor>(animalsTypes.Count);
      for (int index = 0; index < animalsTypes.Count; ++index)
        animals.Add(new AnimalRenderDescriptor(animalsTypes[index]));
      this.SetUp(animals);
    }

    private void SetUp(List<AnimalRenderDescriptor> animals)
    {
      float baseScaleForUi = Z_GameFlags.GetBaseScaleForUI();
      this.mainFrame = new NewThingMainFrame(animals, baseScaleForUi);
      this.bigBrownPanel = new ScrollingBGPanel(this.mainFrame.GetSize(), addHeaderText: "New Discovery!", _BaseScale: baseScaleForUi);
      this.lerper = new LerpHandler_Float();
      this.lerper.Value = 1f;
    }

    public void LerpIn(float lerpDistance_x = 0.0f, float lerpDistance_y = -600f)
    {
      this.lerper.SetLerp(true, 1f, 0.0f, 3f);
      this.lerpDistance = new Vector2(lerpDistance_x, lerpDistance_y);
    }

    public void LerpOff() => this.lerper.SetLerp(false, 0.0f, 1f, 3f);

    public bool UpdateNewThingPanel(Player player, float DeltaTime, bool AllowDrag = false)
    {
      Vector2 location = this.location;
      this.lerper.UpdateLerpHandler(DeltaTime);
      this.bigBrownPanel.UpdateScrollingBG(DeltaTime, location);
      if (this.bigBrownPanel.UpdatePanelCloseButton(player, DeltaTime, location))
        return true;
      if (AllowDrag)
        this.bigBrownPanel.UpdateDragger(player, ref this.location, DeltaTime);
      return this.mainFrame.UpdateNewThingMainFrame(player, DeltaTime, location);
    }

    public void DrawNewThingPanel(SpriteBatch spriteBatch)
    {
      Vector2 offset = this.location + this.lerper.Value * this.lerpDistance;
      this.bigBrownPanel.DrawScrollingBGPanel(offset, spriteBatch);
      this.mainFrame.DrawNewThingMainFrame(offset, spriteBatch);
    }
  }
}
