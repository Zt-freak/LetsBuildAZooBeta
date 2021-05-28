// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Time.TimeBucket
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using SEngine.Time;
using System;

namespace TinyZoo.PlayerDir.Time
{
  internal class TimeBucket
  {
    private DateTime EndTime;
    private DateTime StartTime;
    private bool StartTimeWasServer;
    private bool IsInTimeWindow;

    public TimeBucket()
    {
    }

    public void AddToTime(int Hours, int Minutes, DateTimeManager timemanager)
    {
      if (this.IsInTimeWindow)
        return;
      bool WasServerTime;
      this.StartTime = timemanager.GetDateTimeNow(out WasServerTime);
      if (!WasServerTime)
        return;
      this.IsInTimeWindow = true;
    }

    public void SaveTimeBucket(Writer writer)
    {
      writer.WriteDateTime("t", this.EndTime);
      writer.WriteDateTime("t", this.StartTime);
      writer.WriteBool("t", this.StartTimeWasServer);
    }

    public TimeBucket(Reader reader)
    {
      this.EndTime = reader.ReadDateTime("t");
      this.StartTime = reader.ReadDateTime("t");
      int num = (int) reader.ReadBool("t", ref this.StartTimeWasServer);
    }
  }
}
