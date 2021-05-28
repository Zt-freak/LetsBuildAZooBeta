// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_TicketPrice.TicketData
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.Tile_Data;

namespace TinyZoo.Z_TicketPrice
{
  internal class TicketData
  {
    public static string GetTicketTypeToString(TicketType tickettype)
    {
      switch (tickettype)
      {
        case TicketType.StandardTicket:
          return "Standard Ticket";
        case TicketType.SeasonPass:
          return "Season Pass";
        case TicketType.Child:
          return "Child";
        case TicketType.Helicopter:
          return "Helicopter Ride";
        default:
          return "NA";
      }
    }

    public static TicketType GetTileTypeToTicketType(TILETYPE tiletype) => tiletype == TILETYPE.HelicopterRide ? TicketType.Helicopter : TicketType.Count;
  }
}
