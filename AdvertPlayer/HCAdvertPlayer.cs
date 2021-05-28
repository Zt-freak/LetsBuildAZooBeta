// Decompiled with JetBrains decompiler
// Type: TinyZoo.AdvertPlayer.HCAdvertPlayer
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GenericUI;

namespace TinyZoo.AdvertPlayer
{
  internal class HCAdvertPlayer
  {
    private BlackOut blackout;
    private SimpleTextHandler text;
    public bool IsWaiting;
    public bool WasSuccess;
    private bool GettingAdverts;
    private float TimeOut;
    public bool WasTimeout;
    private bool IsInterstitial;
    private float HackyStartTimer;
    internal static bool IsPlayingAdvert;
    internal static bool WasPlayingAdvert;

    public HCAdvertPlayer(bool _IsInterstitial, Player player)
    {
    }

    public void UpdateAdvertPlayer(float DeltaTime)
    {
    }

    public void DrawAdvertPlayer()
    {
    }
  }
}
