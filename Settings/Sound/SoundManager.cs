// Decompiled with JetBrains decompiler
// Type: TinyZoo.Settings.Sound.SoundManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine;
using TinyZoo.Audio;
using TinyZoo.GenericUI;

namespace TinyZoo.Settings.Sound
{
  internal class SoundManager
  {
    private BackButton Back;
    private LerpHandler_Float lerper;
    public SoundButtons soundbuttons;

    public SoundManager(Player player)
    {
      this.Back = new BackButton();
      this.soundbuttons = new SoundButtons(player);
      this.lerper = new LerpHandler_Float();
    }

    public bool UpdateSoundManager(
      Player player,
      float DeltaTime,
      GraphicsDeviceManager graphics,
      GraphicsDevice _GraphicsDevice)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      if (this.Back.UpdateBackButton(player, DeltaTime) && (double) this.lerper.TargetValue != -1.0)
      {
        SoundEffectsManager.PlaySpecificSound(SoundEffectType.BackClick);
        this.lerper.SetLerp(false, -1f, -1f, 3f);
        this.soundbuttons.BeginExit();
        TinyZoo.Game1.SetNextGameState(GAMESTATE.TitleScreenSetUp);
        TinyZoo.Game1.screenfade.BeginFade(true);
      }
      this.soundbuttons.UpdateSettingsMainButtons(player, DeltaTime, out bool _, graphics, _GraphicsDevice);
      if ((double) this.lerper.Value != -1.0)
        return false;
      if (this.soundbuttons.SomethingChanged)
      {
        this.soundbuttons.SomethingChanged = false;
        player.SaveThisPlayer(DelayUntilNextFrame: false, IsEndOfDay: true);
      }
      return true;
    }

    public void DrawSoundManager()
    {
      Vector2 Offset = new Vector2(this.lerper.Value * 1024f, 0.0f);
      this.Back.DrawBackButton(Offset);
      this.soundbuttons.DrawSettingsMainButtons(Offset);
    }
  }
}
