// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.HUD.StatusArea.GameStatusManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;

namespace TinyZoo.GamePlay.HUD.StatusArea
{
  internal class GameStatusManager
  {
    private ProgressBar progressbar;
    private Survivors survivors;
    private BeamCounter beamcounter;
    private GameObject FrameThing;
    private Vector2 FrameThingScale;
    private ShuffleButton shufflebutton;

    public GameStatusManager()
    {
      this.progressbar = new ProgressBar();
      this.survivors = new Survivors();
      this.FrameThing = new GameObject();
      this.FrameThing.DrawRect = TinyZoo.Game1.WhitePixelRect;
      this.FrameThing.SetAllColours(0.0f, 0.0f, 0.0f);
      this.FrameThing.SetDrawOriginToCentre();
      this.FrameThing.SetAlpha(0.6f);
      this.FrameThingScale = new Vector2(1024f, 60f);
      this.FrameThing.vLocation = new Vector2(512f, this.FrameThingScale.Y * 0.5f);
      this.shufflebutton = new ShuffleButton();
      this.beamcounter = new BeamCounter();
    }

    public bool UpdateGameStatusManager(
      float DeltaTime,
      Player player,
      bool BeamFiring,
      bool IsResultsOrIntro)
    {
      if (GameFlags.GamePaused)
        return false;
      this.survivors.UpdateSurvivors(DeltaTime);
      this.progressbar.UpdateProgressBar(DeltaTime);
      this.beamcounter.UpdateBeamCounter(DeltaTime);
      return this.shufflebutton.UpdateShuffleButton(player, DeltaTime, BeamFiring, IsResultsOrIntro);
    }

    public void DrawGameStatusManager(bool IsResultsOrIntro)
    {
      Vector2 Offset = new Vector2(0.0f, 0.0f);
      this.FrameThing.Draw(AssetContainer.pointspritebatch03, AssetContainer.SpriteSheet, Offset, this.FrameThingScale);
      this.progressbar.DrawProgressBar(new Vector2(140f, this.FrameThing.vLocation.Y));
      this.survivors.DrawSurvivors(new Vector2(442f, this.FrameThing.vLocation.Y));
      this.shufflebutton.DrawShuffleButton();
      this.beamcounter.DrawBeamCounter(new Vector2(800f, this.FrameThing.vLocation.Y));
    }
  }
}
