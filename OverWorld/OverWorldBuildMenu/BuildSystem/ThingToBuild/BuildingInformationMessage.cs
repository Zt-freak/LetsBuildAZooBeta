// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem.ThingToBuild.BuildingInformationMessage
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GenericUI;

namespace TinyZoo.OverWorld.OverWorldBuildMenu.BuildSystem.ThingToBuild
{
  internal class BuildingInformationMessage
  {
    private SimpleTextHandler description;
    private GameObject BackGround;
    private BuildMessageType messagetype;
    private Vector2 VSCAle;

    public BuildingInformationMessage(BuildMessageType message)
    {
      this.BackGround = new GameObject();
      this.BackGround.DrawRect = TinyZoo.Game1.WhitePixelRect;
      this.BackGround.SetDrawOriginToPoint(DrawOriginPosition.CentreTop);
      this.BackGround.SetAllColours(0.0f, 0.0f, 0.0f);
      this.BackGround.SetAlpha(0.5f);
    }

    public void SetMessage(BuildMessageType message)
    {
      if (this.messagetype == message)
        return;
      this.messagetype = message;
      string TextToWrite = "";
      switch (message)
      {
        case BuildMessageType.PlaceNextToExistingWall:
          TextToWrite = "You can only place structures next to existing ones";
          break;
        case BuildMessageType.Overlapping:
          TextToWrite = "Blocked by another structure, Exit Build mode if you wish to sell this";
          break;
      }
      this.description = new SimpleTextHandler(TextToWrite, false, 0.9f, RenderMath.GetNearestPerfectPixelZoom(2f), false, false);
    }

    public void UpdateInformationMessage(float DeltaTime)
    {
      if (this.messagetype == BuildMessageType.None)
        return;
      this.description.UpdateSimpleTextHandler(DeltaTime);
    }

    public void DrawInformationMessage()
    {
    }
  }
}
