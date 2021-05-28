// Decompiled with JetBrains decompiler
// Type: TinyZoo.Utils.FinancialDumper
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.IO;

namespace TinyZoo.Utils
{
  internal class FinancialDumper
  {
    internal static void DumpFinancials(Player player)
    {
      if (Game1.gamestate != GAMESTATE.OverWorld)
        return;
      using (FileStream fileStream = new FileStream("Financials.csv", FileMode.Create))
      {
        StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
        for (int index = 0; (long) index < Player.financialrecords.GetDaysPassed(); ++index)
        {
          if (index == 0)
          {
            string str = "Day,CustomersInPark,CustomersTurnedAway,MoneyIn,MoneyOut,BalanceOnClosing,TicketMoney,FoodMoney,DrinksMoney,SouvenirMoney,BlackMarketMoney,CommoditiesMoney,DonationsMoney, FoodItemsSold,DrinksItemsSold,SouvenirsSold,CommoditiesSold,";
            streamWriter.WriteLine(str);
          }
          string str1 = Player.financialrecords.daystats[index].Day.ToString() + "," + (object) Player.financialrecords.daystats[index].PeopleWhoCame + "," + (object) (Player.financialrecords.daystats[index].PeopleWhoWantedToCome - Player.financialrecords.daystats[index].PeopleWhoCame) + "," + (object) Player.financialrecords.daystats[index].TotalMoneyEarnedThisDay + "," + (object) Player.financialrecords.daystats[index].TotalMoneySpentThisDay + "," + (object) Player.financialrecords.daystats[index].BankBalanceOnClosing + "," + (object) Player.financialrecords.daystats[index].MoneyFromTicketSales + "," + (object) Player.financialrecords.daystats[index].MoneyFromFood + "," + (object) Player.financialrecords.daystats[index].MoneyFromDrinks + "," + (object) Player.financialrecords.daystats[index].MoneyFromSouvenirs + "," + (object) Player.financialrecords.daystats[index].MonsyFromBlackMarket + "," + (object) Player.financialrecords.daystats[index].MoneyFromCommodities + "," + (object) Player.financialrecords.daystats[index].MoneyFromDonations + "," + (object) Player.financialrecords.daystats[index].FoodItemsSold + "," + (object) Player.financialrecords.daystats[index].DrinksSold + "," + (object) Player.financialrecords.daystats[index].SouveniersSold + "," + (object) Player.financialrecords.daystats[index].CommoditiesSold + ",";
          streamWriter.WriteLine(str1);
        }
        streamWriter.Close();
      }
    }
  }
}
