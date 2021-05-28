﻿// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.sponsor.CurrentSponsor
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;

namespace TinyZoo.PlayerDir.sponsor
{
  internal class CurrentSponsor
  {
    public int Value;
    public int DaysRemaining;
    public SponsorshipType sponsorshiptype;

    public CurrentSponsor(int _Value, int _DaysRemaining, SponsorshipType _sponsorshiptype)
    {
      this.Value = _Value;
      this.DaysRemaining = _DaysRemaining;
      this.sponsorshiptype = _sponsorshiptype;
    }

    public CurrentSponsor(Reader reader)
    {
      int num1 = (int) reader.ReadInt("g", ref this.Value);
      int num2 = (int) reader.ReadInt("g", ref this.DaysRemaining);
      int _out = 0;
      int num3 = (int) reader.ReadInt("g", ref _out);
      this.sponsorshiptype = (SponsorshipType) _out;
    }

    public void SaveCurrentSponsor(Writer writer)
    {
      writer.WriteInt("g", this.Value);
      writer.WriteInt("g", this.DaysRemaining);
      writer.WriteInt("g", (int) this.sponsorshiptype);
    }
  }
}
