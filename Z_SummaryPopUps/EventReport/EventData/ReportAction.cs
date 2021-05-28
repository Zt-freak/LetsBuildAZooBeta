// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.EventReport.EventData.ReportAction
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

namespace TinyZoo.Z_SummaryPopUps.EventReport.EventData
{
  internal class ReportAction
  {
    public ActionType actiontype;
    public string Description;
    public int Percent;
    public int Days;
    public ReportResultRank rank;

    public ReportAction(ActionType _actiontype, ReportResultRank _rank, int _Percent, int _Days)
    {
      this.rank = _rank;
      this.actiontype = _actiontype;
      this.Days = _Days;
      this.Percent = _Percent;
    }

    public string GetDescription()
    {
      switch (this.actiontype)
      {
        case ActionType.SavingsAtRescueShelter:
          return "Save " + (object) this.Percent + "% on all purchases at the animal rescue shelter for the next " + (object) this.Days + " days.";
        case ActionType.ZooTradesWillGiveAnExtraAnimal:
          return "Trades with other zoos will earn one additional animal for the next " + (object) this.Days + " days.";
        case ActionType.DonationsToMascottsBoost:
          return "Any constumed fund rasiers will earn " + (object) this.Percent + "% more donations for the next " + (object) this.Days + " days.";
        case ActionType.Bad_PayFine:
          return "Pay a fine, of " + (object) this.Percent + "% or your currently held cash reserves";
        case ActionType.Bad_ShelterCostsIncrease:
          return "All purchases at the animal rescue shelter will cost " + (object) this.Percent + " more for the next " + (object) this.Days + " days.";
        case ActionType.NoAction:
          return "No bonus awarded.";
        default:
          return "NO DEC FOUND";
      }
    }
  }
}
