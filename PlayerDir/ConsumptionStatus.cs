// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.ConsumptionStatus
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.PlayerDir
{
  internal class ConsumptionStatus
  {
    public float[] ConsumptionValues;
    public float[] GenerationValues;
    public bool SomethingIsBad;

    public ConsumptionStatus()
    {
      this.ConsumptionValues = new float[10];
      this.GenerationValues = new float[10];
    }

    public void Reset()
    {
      this.ConsumptionValues = new float[10];
      this.GenerationValues = new float[10];
    }

    public void MultiplyByHalf()
    {
      for (int index = 0; index < this.ConsumptionValues.Length; ++index)
        this.ConsumptionValues[index] /= 2f;
    }

    public void CheckConsuption()
    {
      this.SomethingIsBad = false;
      for (int index = 0; index < this.ConsumptionValues.Length; ++index)
      {
        if ((double) this.ConsumptionValues[index] > (double) this.GenerationValues[index])
          this.SomethingIsBad = true;
      }
    }

    public void UpateConsumptionStatus()
    {
    }

    public int ModifyDailyEarnings(int TodaysEarnings)
    {
      if (this.SomethingIsBad)
      {
        float num1 = 0.0f;
        float num2 = 0.0f;
        this.SomethingIsBad = false;
        for (int index = 0; index < this.ConsumptionValues.Length; ++index)
        {
          if ((double) this.ConsumptionValues[index] > (double) this.GenerationValues[index])
          {
            this.SomethingIsBad = true;
            num1 += this.ConsumptionValues[index];
            num2 += this.GenerationValues[index];
          }
          else
          {
            num1 += this.ConsumptionValues[index];
            num2 += this.ConsumptionValues[index];
          }
        }
        if ((double) num1 > (double) num2)
        {
          int num3 = (int) ((double) TodaysEarnings * ((double) num2 / (double) num1));
          if (num3 == 0 && TodaysEarnings > 0)
            num3 = 1;
          return num3;
        }
      }
      return TodaysEarnings;
    }
  }
}
