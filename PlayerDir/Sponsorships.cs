// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Sponsorships
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using System.Collections.Generic;
using TinyZoo.PlayerDir.sponsor;
using TinyZoo.Z_HUD.Z_Notification.NotificationBubble;

namespace TinyZoo.PlayerDir
{
  internal class Sponsorships
  {
    private List<CurrentSponsor> sponsoprs;

    public Sponsorships() => this.sponsoprs = new List<CurrentSponsor>();

    public void AddSponsorship(CurrentSponsor newsponsor) => this.sponsoprs.Add(newsponsor);

    public void StartNewDay(Player player)
    {
      int GiveThis = 0;
      for (int index = this.sponsoprs.Count - 1; index > -1; --index)
      {
        if (this.sponsoprs[index].DaysRemaining > 0)
        {
          --this.sponsoprs[index].DaysRemaining;
          GiveThis += this.sponsoprs[index].Value;
        }
        if (this.sponsoprs[index].DaysRemaining <= 0)
          this.sponsoprs.RemoveAt(index);
      }
      if (GiveThis <= 0)
        return;
      NotificationBubbleManager.Instance.AddNotificationBubbleToQueue(new NotificationBubbleInfo(nameof (Sponsorships), "Earnings: $" + (object) GiveThis, true));
      player.Stats.GiveCash(GiveThis, player);
    }

    public void SaveSponsorships(Writer writer)
    {
      writer.WriteInt("v", this.sponsoprs.Count);
      for (int index = 0; index < this.sponsoprs.Count; ++index)
        this.sponsoprs[index].SaveCurrentSponsor(writer);
    }

    public Sponsorships(Reader reader)
    {
      int _out = 0;
      int num = (int) reader.ReadInt("v", ref _out);
      this.sponsoprs = new List<CurrentSponsor>();
      for (int index = 0; index < _out; ++index)
        this.sponsoprs.Add(new CurrentSponsor(reader));
    }
  }
}
