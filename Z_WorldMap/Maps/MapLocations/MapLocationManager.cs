// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_WorldMap.Maps.MapLocations.MapLocationManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.Tutorials;
using TinyZoo.Z_Quests;
using TinyZoo.Z_WorldMap.Maps.MapLocations.MapMarkers;

namespace TinyZoo.Z_WorldMap.Maps.MapLocations
{
  internal class MapLocationManager
  {
    private List<MapMarker> mapmarkers;

    public MapLocationManager(Player player)
    {
      this.mapmarkers = new List<MapMarker>();
      player.zquests.CheckQuests();
      for (int index = 0; index < player.zquests.ProgressByCity.Length; ++index)
      {
        if (player.zquests.ProgressByCity[index] > -1)
        {
          this.mapmarkers.Add(new MapMarker((CityName) index, player));
          QuestPack questFromThisCity = player.zquests.GetActiveQuestFromThisCity((CityName) index);
          if (questFromThisCity != null)
          {
            if (!player.prisonlayout.HasTheseAnimals(questFromThisCity, out bool _, out int _) && (questFromThisCity.city != CityName.Sydney || questFromThisCity.GetThisAnimal != AnimalType.Rabbit) && index != 15)
              this.mapmarkers[this.mapmarkers.Count - 1].SetSmall();
          }
          else
            this.mapmarkers[this.mapmarkers.Count - 1].SetSmall();
        }
      }
      if (TutorialManager.currenttutorial != TUTORIALTYPE.None || !player.Stats.TutorialsComplete[29])
        return;
      this.mapmarkers.Add(new MapMarker(CityName.Shelter, player));
    }

    public CityName UpdateMapLocationManager(
      Player player,
      float DeltaTime,
      bool MouseIsOverPopUpPanel,
      out Vector2 worldSpaceLocation)
    {
      CityName cityName = CityName.Count;
      worldSpaceLocation = Vector2.Zero;
      for (int index = 0; index < this.mapmarkers.Count; ++index)
      {
        if (this.mapmarkers[index].UpdateMapMarker(DeltaTime, player, MouseIsOverPopUpPanel))
        {
          cityName = this.mapmarkers[index].city;
          worldSpaceLocation = this.mapmarkers[index].vLocation;
        }
      }
      return cityName;
    }

    public void DrawMapLocationManager()
    {
      for (int index = 0; index < this.mapmarkers.Count; ++index)
        this.mapmarkers[index].DrawMapMarker();
    }
  }
}
