// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_TicketPrice.TicketPriceManager_Holder
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using TinyZoo.GenericUI;
using TinyZoo.OverWorld.Store_Local.StoreBG;
using TinyZoo.Z_TicketPrice.Panel;

namespace TinyZoo.Z_TicketPrice
{
  internal class TicketPriceManager_Holder
  {
    private SetTicketPriceManager manager;
    private StoreBGManager storeBGManager;
    private BackButton backbutton;
    private TicketPriceMainPanel ticketPriceMainPanel;
    private bool UseNewPopUpMenu = true;

    public TicketPriceManager_Holder(Player player)
    {
      if (this.UseNewPopUpMenu)
      {
        this.ticketPriceMainPanel = new TicketPriceMainPanel(player, Z_GameFlags.GetBaseScaleForUI());
        this.ticketPriceMainPanel.location = new Vector2(512f, 384f);
      }
      else
      {
        this.backbutton = new BackButton(true);
        this.storeBGManager = new StoreBGManager(true);
        this.manager = new SetTicketPriceManager(player);
        this.manager.Location.Y = 300f;
      }
    }

    public bool CheckMouseOver(Player player) => this.ticketPriceMainPanel.CheckMouseOver(player, Vector2.Zero);

    public bool UpdateTicketPriceManager_Holder(Player player, float DeltaTime, bool UpdateValues = false)
    {
      float SimulationTime = 0.0f;
      GameStateManager.tutorialmanager.UpdateTutorialManager(ref DeltaTime, ref SimulationTime, player);
      if (this.UseNewPopUpMenu)
        return this.ticketPriceMainPanel.UpdateTicketPriceMainPanel(player, DeltaTime, UpdateValues, Vector2.Zero);
      if (this.backbutton.UpdateBackButton(player, DeltaTime))
      {
        Game1.SetNextGameState(GAMESTATE.OverWorld);
        Game1.screenfade.BeginFade(true);
      }
      this.storeBGManager.UpdateStoreBGManager(DeltaTime);
      this.manager.UpdateSetTicketPriceManager(player, DeltaTime, Vector2.Zero);
      return false;
    }

    public void DrawTicketPriceManager_Holder()
    {
      if (this.UseNewPopUpMenu)
      {
        this.ticketPriceMainPanel.DrawTicketPriceMainPanel(Vector2.Zero, AssetContainer.pointspritebatchTop05);
      }
      else
      {
        this.storeBGManager.DrawStoreBGManager(Vector2.Zero);
        this.backbutton.DrawBackButton(Vector2.Zero);
        this.manager.DrawSetTicketPriceManager(Vector2.Zero);
      }
    }
  }
}
