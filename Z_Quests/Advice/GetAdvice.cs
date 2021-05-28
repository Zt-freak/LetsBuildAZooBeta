// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Quests.Advice.GetAdvice
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using System.Collections.Generic;
using TinyZoo.PlayerDir.employees.openpositions;
using TinyZoo.Z_HUD.Z_Notification.NotificationRibbon;
using TinyZoo.Z_ManageShop.Shop_Data;
using TinyZoo.Z_Notification;

namespace TinyZoo.Z_Quests.Advice
{
  internal class GetAdvice
  {
    internal static void GetCurrentAdvice(Player player)
    {
      if (player.prisonlayout.cellblockcontainer.prisonzones.Count == 0)
        Z_NotificationManager.AddNotificationPackage(new NotificationPackage(Z_NotificationType.A_BuildFirstPen), player);
      else if (!GetAdvice.SetEmptyFirstPen(player) && !GetAdvice.HasNoWaterInAPen(player) && (!GetAdvice.HasNoCleanWaterInPen(player) && !GetAdvice.HasNoEnrichmentInAPen(player)) && !GetAdvice.SetEmptyPen(player))
        GetAdvice.ShouldBuildAnotherPen(player);
      if (!GetAdvice.BuildAnyShop(player) && !GetAdvice.BuildAFoodShop(player) && (!GetAdvice.BuildAGiftShop(player) && !GetAdvice.BuildAGiftShop(player)))
        GetAdvice.ShopHasExtraOpenPositions(player);
      GetAdvice.AJobHasApplicants(player);
      GetAdvice.HasShopsWithNoEmployee(player);
    }

    private static bool SetEmptyFirstPen(Player player)
    {
      for (int index = 0; index < player.prisonlayout.cellblockcontainer.prisonzones.Count; ++index)
      {
        int count = player.prisonlayout.cellblockcontainer.prisonzones[index].prisonercontainer.prisoners.Count;
      }
      return false;
    }

    private static bool HasNoWaterInAPen(Player player)
    {
      bool flag = false;
      for (int index = 0; index < player.prisonlayout.cellblockcontainer.prisonzones.Count; ++index)
      {
        player.prisonlayout.cellblockcontainer.prisonzones[index].CalculateWaterCapacity(player);
        if (!player.prisonlayout.cellblockcontainer.prisonzones[index].HasWaterTrough())
          flag = true;
      }
      return flag;
    }

    private static bool HasNoCleanWaterInPen(Player player) => false;

    private static bool HasNoEnrichmentInAPen(Player player)
    {
      bool flag = false;
      for (int index = 0; index < player.prisonlayout.cellblockcontainer.prisonzones.Count; ++index)
      {
        if (!player.prisonlayout.cellblockcontainer.prisonzones[index].HasEnrichment())
        {
          flag = true;
          Z_NotificationManager.AddNotificationPackage(new NotificationPackage(Z_NotificationType.A_NoEnrichment, player.prisonlayout.cellblockcontainer.prisonzones[index].Cell_UID), player);
        }
      }
      return flag;
    }

    private static bool SetEmptyPen(Player player) => false;

    private static bool ShouldBuildAnotherPen(Player player)
    {
      if (player.prisonlayout.cellblockcontainer.prisonzones.Count >= 5)
        return false;
      Z_NotificationManager.AddNotificationPackage(new NotificationPackage(Z_NotificationType.A_BuildAnotherPen), player);
      return true;
    }

    private static bool BuildAnyShop(Player player) => player.shopstatus.shopentries.Count == 0;

    private static bool BuildAFoodShop(Player player) => true;

    private static bool BuildADrinksShop(Player player) => true;

    private static bool BuildAGiftShop(Player player) => true;

    private static bool ShopHasExtraOpenPositions(Player player)
    {
      bool flag = false;
      for (int index = 0; index < player.shopstatus.shopentries.Count; ++index)
      {
        if (ShopData.GetMaximumEmployeesForThisShop(player.shopstatus.shopentries[index].tiletype, player) > player.shopstatus.shopentries[index].GetEmplyeeCount())
        {
          flag = true;
          Z_NotificationManager.AddNotificationPackage(new NotificationPackage(Z_NotificationType.F_ShopHasExtraOpenPositions, player.shopstatus.shopentries[index].ShopUID), player);
        }
      }
      return flag;
    }

    private static bool HasShopsWithNoEmployee(Player player) => false;

    private static bool AJobHasApplicants(Player player)
    {
      List<OpenPositions> applicantsOpenPositions = player.employees.openPositionsContainer.GetAllJobsWithApplicantsOpenPositions();
      for (int index = 0; index < applicantsOpenPositions.Count; ++index)
        Z_NotificationManager.AddNotificationPackage(new NotificationPackage(Z_NotificationType.F_AJobHasApplicants, applicantsOpenPositions[index].ShopUID)
        {
          AlertStatus = NotificationAlertStatus.Special_Star
        }, player);
      return applicantsOpenPositions.Count > 0;
    }
  }
}
