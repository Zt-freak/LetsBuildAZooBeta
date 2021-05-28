// Decompiled with JetBrains decompiler
// Type: TinyZoo.MainVariables
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Spring.Comms;

namespace TinyZoo
{
  internal class MainVariables
  {
    internal static string LIVE_SERVER_IP = "Spring-Server-Core-Balancer-177bb0fd6e8eb74a.elb.us-west-2.amazonaws.com";
    internal static string TEST_SERVER_IP = "test.servertddgame.com";
    internal static string LOCAL_SERVER_IP = "192.168.1.140";
    internal static SocialType ThisGame = SocialType.PrisonPlanet_UID;
    internal static string CloudSaveFile = "SPRINGTEMPLATE_CLOUD";
  }
}
