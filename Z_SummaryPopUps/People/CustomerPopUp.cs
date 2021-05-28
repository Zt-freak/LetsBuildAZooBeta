// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_SummaryPopUps.People.CustomerPopUp
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using SEngine;
using TinyZoo.GenericUI;
using TinyZoo.OverWorld.OverWorldEnv.Customers;
using TinyZoo.PlayerDir;
using TinyZoo.Z_AnimalsAndPeople.Sim_Person;
using TinyZoo.Z_SummaryPopUps.People.BlackMarket;
using TinyZoo.Z_SummaryPopUps.People.Customer;
using TinyZoo.Z_SummaryPopUps.People.Employee;

namespace TinyZoo.Z_SummaryPopUps.People
{
  internal class CustomerPopUp
  {
    private BackButton close;
    private LerpHandler_Float lerper;
    private GameObjectNineSlice gameobjectninslice;
    private WalkingPerson refperson;
    private GameObjectNineSlice box;
    private bool Exiting;
    private Vector2 VSCALE;
    private BlackMarketDealer blackmarketdealer;
    private Vector2 MainFrameScale;
    private CustomerViewManager customerViewManager;
    private EmployeeViewManager employeeviewer;
    private AvatarDisplay avatardisplay;
    private GameObject PersonFrame;

    public CustomerPopUp(WalkingPerson person, float MasterScaleMult, Player player)
    {
      this.MainFrameScale = new Vector2(700f, 400f) * Sengine.ScreenRatioUpwardsMultiplier * MasterScaleMult;
      this.PersonFrame = new GameObject();
      this.PersonFrame.DrawRect = new Rectangle(402, 381, 63, 63);
      this.PersonFrame.scale = 2f;
      this.PersonFrame.SetDrawOriginToCentre();
      this.gameobjectninslice = new GameObjectNineSlice(new Rectangle(961, 372, 21, 21), 7);
      if (person.simperson.roleinsociety == RoleInSociety.BlackMarket)
      {
        this.gameobjectninslice = new GameObjectNineSlice(new Rectangle(992, 556, 21, 21), 7);
      }
      else
      {
        int roleinsociety = (int) person.simperson.roleinsociety;
      }
      this.gameobjectninslice.scale = 2f;
      this.gameobjectninslice.vLocation = new Vector2(512f, 384f);
      this.lerper = new LerpHandler_Float();
      this.lerper.SetLerp(true, 1f, 0.0f, 3f);
      this.refperson = person;
      if (person.simperson.roleinsociety != RoleInSociety.Customer)
      {
        this.close = new BackButton(true);
        this.box = new GameObjectNineSlice(new Rectangle(939, 416, 21, 21), 7);
        this.box.scale = 3f;
        this.box.scale = RenderMath.GetPixelSizeBestMatch(2f);
        this.box.vLocation = new Vector2(512f, 384f);
        this.close.vLocation = this.box.vLocation + new Vector2(330f, -180f * Sengine.ScreenRatioUpwardsMultiplier.Y);
      }
      if (person.simperson.roleinsociety == RoleInSociety.BlackMarket)
      {
        this.MainFrameScale = new Vector2(500f, 500f * Sengine.ScreenRatioUpwardsMultiplier.Y) * MasterScaleMult;
        this.customerViewManager = new CustomerViewManager(person.simperson, person, this.MainFrameScale, player);
      }
      else if (person.simperson.roleinsociety == RoleInSociety.Customer || person.simperson.Ref_Employee != null && person.simperson.Ref_Employee.employeetype == EmployeeType.Police)
      {
        this.MainFrameScale = new Vector2(550f, 600f) * Sengine.ScreenRatioUpwardsMultiplier * MasterScaleMult;
        this.customerViewManager = new CustomerViewManager(person.simperson, person, this.MainFrameScale, player);
      }
      else if (person.simperson.roleinsociety == RoleInSociety.Avatar)
        this.avatardisplay = new AvatarDisplay(person, player);
      else if (person.simperson.roleinsociety == RoleInSociety.Employee)
        this.employeeviewer = new EmployeeViewManager(player, person);
      this.VSCALE = new Vector2(150f, 230f) * Sengine.ScreenRatioUpwardsMultiplier;
    }

    public bool CheckMouseOver(Player player)
    {
      Vector2 offset = new Vector2(this.lerper.Value * 1024f, 0.0f);
      bool flag = false;
      BlackMarketDealer blackmarketdealer = this.blackmarketdealer;
      if (this.customerViewManager != null)
        flag |= this.customerViewManager.CheckMouseOver(player, offset);
      else if (this.employeeviewer != null)
        flag |= this.employeeviewer.CheckMouseOver(player, offset);
      else if (this.avatardisplay != null)
        flag |= this.avatardisplay.CheckMouseOver(player, offset);
      return flag;
    }

    public bool UpdateCustomerPopUp(Player player, float DeltaTime)
    {
      this.lerper.UpdateLerpHandler(DeltaTime);
      if ((double) this.lerper.Value == 0.0 && this.close != null && (this.close.UpdateBackButton(player, DeltaTime) && !this.Exiting))
      {
        this.Exiting = true;
        this.lerper.SetLerp(false, 0.0f, 1f, 3f, true);
      }
      Vector2 offset = new Vector2(this.lerper.Value * 1024f, 0.0f);
      if (this.blackmarketdealer != null && this.blackmarketdealer.UpdateBlackMarketDealer(offset + this.box.vLocation - new Vector2(0.0f, this.MainFrameScale.Y * 0.5f), player, DeltaTime, this.MainFrameScale))
        this.TryExit();
      if (this.customerViewManager != null)
      {
        if (this.customerViewManager.UpdateCustomerViewManager(offset, player, DeltaTime) && (double) this.lerper.Value == 0.0)
          this.TryExit();
      }
      else if (this.employeeviewer != null)
      {
        if (this.employeeviewer.UpdateEmployeeViewManager(offset, player, DeltaTime))
        {
          this.TryExit();
          return true;
        }
      }
      else if (this.avatardisplay != null && this.avatardisplay.UpdateAvatarViewManager(offset, player, DeltaTime))
        this.TryExit();
      return this.Exiting && (double) this.lerper.Value == 1.0;
    }

    private void TryExit()
    {
      if (this.Exiting)
        return;
      this.Exiting = true;
      this.lerper.SetLerp(false, 0.0f, 1f, 3f, true);
    }

    public void DrawCustomerPopUp()
    {
      Vector2 vector2_1 = new Vector2(this.lerper.Value * 1024f, 0.0f);
      this.gameobjectninslice.vLocation = Vector2.Zero;
      Vector2 vector2_2 = new Vector2(-265f, -100f);
      if (this.blackmarketdealer != null)
      {
        this.box.DrawGameObjectNineSlice(AssetContainer.pointspritebatchTop05, AssetContainer.SpriteSheet, vector2_1, this.MainFrameScale);
        this.blackmarketdealer.DrawBlackMarketDealer(vector2_1 + this.box.vLocation - new Vector2(0.0f, this.MainFrameScale.Y * 0.5f), this.MainFrameScale);
        this.close.DrawBackButton(vector2_1);
      }
      if (this.customerViewManager != null)
        this.customerViewManager.DrawCustomerViewManager(vector2_1);
      else if (this.avatardisplay != null)
        this.avatardisplay.DrawAvatarDisplay(vector2_1, AssetContainer.pointspritebatchTop05);
      else if (this.employeeviewer != null)
        this.employeeviewer.DrawEmployeeViewManager(AssetContainer.pointspritebatchTop05, vector2_1);
      CustomerViewManager customerViewManager = this.customerViewManager;
    }
  }
}
