// Decompiled with JetBrains decompiler
// Type: TinyZoo.Program
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SpringSocial.Steam;
using TinyZoo.Utils.Logger;

namespace TinyZoo
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      CrashDumper.Instance.InitCrashDumperFromMAIN();
      using (Game1 game1 = new Game1())
      {
        SteamAPIInit.InitSteamAPI();
        game1.Run();
        SteamAPIInit.ShutDownSteamAPI();
      }
    }
  }
}
