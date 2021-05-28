// Decompiled with JetBrains decompiler
// Type: TinyZoo.GamePlay.PauseScreen.PauseManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.GamePlay.PauseScreen
{
  internal class PauseManager
  {
    internal static bool ForcePause;
    private PauseButton pausebutton;
    private PauseScreenManager pausescreenmanager;

    public PauseManager()
    {
      GameFlags.GamePaused = false;
      this.pausebutton = new PauseButton();
    }

    public bool UpdatePauseManager(ref float DeltaTime, Player player, bool IsResultsOrIntro)
    {
      if (this.pausebutton.UpdatePauseButton(player, DeltaTime, !IsResultsOrIntro))
      {
        GameFlags.GamePaused = true;
        this.pausescreenmanager = new PauseScreenManager(player);
      }
      if (GameFlags.GamePaused)
      {
        if (this.pausescreenmanager.UpdatePauseScreenManager(DeltaTime, player))
        {
          GameFlags.GamePaused = false;
          if (this.pausescreenmanager.WillRetry)
          {
            this.pausescreenmanager.WillRetry = false;
            return true;
          }
        }
        DeltaTime = 0.0f;
      }
      return false;
    }

    public void DrawPauseManager()
    {
      this.pausebutton.DrawPauseButton();
      if (!GameFlags.GamePaused)
        return;
      this.pausescreenmanager.DrawPauseScreenManager();
    }
  }
}
