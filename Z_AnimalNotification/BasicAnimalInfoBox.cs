// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_AnimalNotification.BasicAnimalInfoBox
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GamePlay.Enemies;
using TinyZoo.PlayerDir.Layout;
using TinyZoo.Z_AnimalsAndPeople;
using TinyZoo.Z_GenericUI;

namespace TinyZoo.Z_AnimalNotification
{
  internal class BasicAnimalInfoBox
  {
    private static Color cream = new Color(ColourData.Z_Cream);
    private AnimalInFrame animalInFrame;
    public Vector2 location;
    private Vector2 framescale;
    private Vector2 currLoc;
    private ZGenericText nameText;
    private Vector2 nameSize;
    private ZGenericText speciesText;
    private Vector2 textSize;
    private float basescale;

    public BasicAnimalInfoBox(PrisonerInfo info, float basescale_)
    {
      this.basescale = basescale_;
      UIScaleHelper uiScaleHelper = new UIScaleHelper(basescale_);
      AnimalType animaltype = info.intakeperson.animaltype;
      int clIndex = info.intakeperson.CLIndex;
      string name = info.intakeperson.Name;
      string enemyTypeName = EnemyData.GetEnemyTypeName(animaltype);
      int num1 = info.intakeperson.IsAGirl ? 1 : 0;
      string str = info.Age.ToString() + " days old";
      info.causeofdeath.GetName();
      this.nameText = new ZGenericText(name, this.basescale, false, _UseOnePointFiveFont: true);
      this.speciesText = new ZGenericText(enemyTypeName, this.basescale, false);
      float TargetSize = 50f * this.basescale;
      this.animalInFrame = new AnimalInFrame(animaltype, AnimalType.None, clIndex, TargetSize, BaseScale: (2f * this.basescale));
      this.framescale.X = uiScaleHelper.ScaleX(170f);
      this.framescale.Y = this.animalInFrame.GetSize().Y;
      float num2 = uiScaleHelper.ScaleX(10f);
      this.nameSize = this.nameText.GetSize();
      this.textSize = this.speciesText.GetSize();
      this.currLoc = Vector2.Zero;
      this.currLoc.X = -0.5f * this.framescale.X;
      this.currLoc.X += 0.5f * this.animalInFrame.GetSize().X;
      this.animalInFrame.Location = this.currLoc;
      this.currLoc.X += 0.5f * this.animalInFrame.GetSize().X + num2;
      this.currLoc.Y -= 0.5f * this.animalInFrame.GetSize().Y;
      this.nameText.vLocation = this.currLoc;
      this.currLoc.Y += this.nameSize.Y;
      this.speciesText.vLocation = this.currLoc;
    }

    public Vector2 GetSize() => this.framescale;

    public void DrawBasicAnimalInfoBox(Vector2 offset, SpriteBatch spritebatch)
    {
      offset += this.location;
      this.animalInFrame.DrawAnimalInFrame(offset, spritebatch);
      this.nameText.DrawZGenericText(offset, spritebatch);
      this.speciesText.DrawZGenericText(offset, spritebatch);
    }
  }
}
