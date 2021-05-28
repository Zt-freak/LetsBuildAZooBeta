// Decompiled with JetBrains decompiler
// Type: TinyZoo.Audio.MusicSequencer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.AdvertPlayer;

namespace TinyZoo.Audio
{
  internal class MusicSequencer
  {
    private static float[] SongLengths;
    private static float TIME;
    private static SongTitle songplaying;
    private static bool IsPlaying;
    private static bool SmartLoop = true;

    internal static void UpdateMusicSequencer(bool BlockPlayngNewSong)
    {
      if (!MusicSequencer.IsPlaying)
        return;
      MusicSequencer.TIME -= GameFlags.RefDeltaTime;
      if (((double) MusicSequencer.TIME >= 0.0 || BlockPlayngNewSong) && (!HCAdvertPlayer.WasPlayingAdvert || HCAdvertPlayer.IsPlayingAdvert) || HCAdvertPlayer.IsPlayingAdvert)
        return;
      HCAdvertPlayer.WasPlayingAdvert = false;
      if (MusicSequencer.SmartLoop)
      {
        if (MusicSequencer.songplaying < SongTitle.RandomOverWorldMusic)
        {
          MusicManager.playsong(SongTitle.RandomOverWorldMusic, true, false);
        }
        else
        {
          if (MusicSequencer.songplaying <= SongTitle.RandomOverWorldMusic || MusicSequencer.songplaying >= SongTitle.RandomBattleMusic)
            return;
          MusicManager.playsong(SongTitle.RandomBattleMusic, true, false);
        }
      }
      else
        MusicManager.playsong(MusicSequencer.songplaying, true, false);
    }

    internal static void PlayedNewSong(SongTitle songtitle)
    {
      if (MusicSequencer.SongLengths == null)
      {
        MusicSequencer.SongLengths = new float[21];
        MusicSequencer.SongLengths[0] = 79f;
        MusicSequencer.SongLengths[1] = 64f;
        MusicSequencer.SongLengths[2] = 50f;
        MusicSequencer.SongLengths[3] = 79f;
        MusicSequencer.SongLengths[4] = 243f;
        MusicSequencer.SongLengths[5] = 188f;
        MusicSequencer.SongLengths[6] = 80f;
        MusicSequencer.SongLengths[7] = 121f;
        MusicSequencer.SongLengths[8] = 98f;
        MusicSequencer.SongLengths[9] = 84f;
        MusicSequencer.SongLengths[11] = 58f;
        MusicSequencer.SongLengths[10] = 90f;
        MusicSequencer.SongLengths[13] = 65f;
        MusicSequencer.SongLengths[14] = 75f;
        MusicSequencer.SongLengths[15] = 34f;
        MusicSequencer.SongLengths[16] = 54f;
        MusicSequencer.SongLengths[17] = 45f;
      }
      MusicSequencer.TIME = MusicSequencer.SongLengths[(int) songtitle];
      MusicSequencer.TIME += 5f;
      MusicSequencer.IsPlaying = true;
      MusicSequencer.songplaying = songtitle;
    }
  }
}
