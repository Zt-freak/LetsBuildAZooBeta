// Decompiled with JetBrains decompiler
// Type: TinyZoo.Utils.ControllerHelper
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.PlayerDir;

namespace TinyZoo.Utils
{
  internal class ControllerHelper
  {
    public static int DidAPlayerPressThis(Player[] players, ButtonPressed buttonpressed)
    {
      for (int index = 0; index < players.Length; ++index)
      {
        if (players[index].inputmap.PressedThisFrame[(int) buttonpressed])
          return index;
      }
      return -1;
    }
  }
}
