// Decompiled with JetBrains decompiler
// Type: TinyZoo.Settings.Sound.SFXButton
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.Audio;

namespace TinyZoo.Settings.Sound
{
  internal class SFXButton
  {
    private bool IsMusic;
    private TextButton textbutton;
    public Vector2 Location;
    public bool SOmethingChanged;

    public SFXButton(bool _IsMusic, float basescale)
    {
      this.IsMusic = _IsMusic;
      if (!this.IsMusic)
        this.textbutton = new TextButton(basescale, SEngine.Localization.Localization.GetText(53) + ": " + (object) (int) ((double) SoundEffectsManager.SFXVolume * 10.0), 100f);
      else
        this.textbutton = new TextButton(basescale, SEngine.Localization.Localization.GetText(52) + ": " + (object) (int) ((double) MusicManager.MusicVol * 10.0), 100f);
    }

    public Vector2 GetSize() => this.textbutton.GetSize_True();

    public void UpdateSoundButton(Player player, float DeltaTime, Vector2 Offset)
    {
      Offset += this.Location;
      if (!this.textbutton.UpdateTextButton(player, Offset, DeltaTime))
        return;
      if (this.IsMusic)
      {
        this.SOmethingChanged = true;
        MusicManager.MusicVol += 0.2f;
        if ((double) MusicManager.MusicVol > 1.0)
          MusicManager.MusicVol = 0.0f;
        MusicManager.SetVolumeForOptions(MusicManager.MusicVol);
        this.textbutton.SetText(SEngine.Localization.Localization.GetText(52) + ": " + (object) (int) ((double) MusicManager.MusicVol * 10.0));
      }
      else
      {
        this.SOmethingChanged = true;
        SoundEffectsManager.SFXVolume += 0.2f;
        if ((double) SoundEffectsManager.SFXVolume > 1.0)
          SoundEffectsManager.SFXVolume = 0.0f;
        SoundEffectsManager.PlaySpecificSound((SoundEffectType) Game1.Rnd.Next(42, 53));
        this.textbutton.SetText(SEngine.Localization.Localization.GetText(53) + ": " + (object) (int) ((double) SoundEffectsManager.SFXVolume * 10.0));
      }
    }

    public void DrawSoundButton(Vector2 Offset)
    {
      Offset += this.Location;
      this.textbutton.DrawTextButton(Offset, 1f, AssetContainer.pointspritebatchTop05);
    }
  }
}
