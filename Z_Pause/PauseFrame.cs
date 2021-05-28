// Decompiled with JetBrains decompiler
// Type: TinyZoo.Z_Pause.PauseFrame
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyZoo.GamePlay.PauseScreen;
using TinyZoo.Settings.Sound;
using TinyZoo.Z_GenericUI;
using TinyZoo.Z_Pause.Elements;
using TinyZoo.Z_SummaryPopUps.People.Customer;

namespace TinyZoo.Z_Pause
{
  internal class PauseFrame
  {
    public Vector2 location;
    private UIScaleHelper scalehelper;
    private CustomerFrame customerFrame;
    private PhotoModeRow photo;
    private TextButton quitGameButton;
    private SFXButton sfxbutton;
    private SFXButton musicbutton;

    public PauseFrame(float BaseScale)
    {
      this.scalehelper = new UIScaleHelper(BaseScale);
      Vector2 defaultBuffer = this.scalehelper.DefaultBuffer;
      this.quitGameButton = new TextButton(BaseScale, "Quit Game", 55f);
      this.sfxbutton = new SFXButton(false, BaseScale);
      this.musicbutton = new SFXButton(true, BaseScale);
      this.photo = new PhotoModeRow(BaseScale);
      Vector2 _VSCale = new Vector2();
      _VSCale.Y += defaultBuffer.Y;
      this.sfxbutton.Location = _VSCale;
      this.sfxbutton.Location.Y += 0.5f * this.sfxbutton.GetSize().Y;
      _VSCale.Y += this.sfxbutton.GetSize().Y + defaultBuffer.Y;
      this.musicbutton.Location = _VSCale;
      this.musicbutton.Location.Y += 0.5f * this.musicbutton.GetSize().Y;
      _VSCale.Y += this.musicbutton.GetSize().Y + defaultBuffer.Y;
      _VSCale.Y += defaultBuffer.Y * 0.5f;
      this.photo.location = _VSCale;
      this.photo.location.X -= this.photo.GetSize().X * 0.5f;
      this.photo.location.Y += this.photo.GetSize().Y * 0.5f;
      _VSCale.Y += this.photo.GetSize().Y;
      _VSCale.Y += defaultBuffer.Y;
      _VSCale.Y += defaultBuffer.Y * 0.5f;
      this.quitGameButton.vLocation = _VSCale;
      this.quitGameButton.vLocation.Y += 0.5f * this.quitGameButton.GetSize_True().Y;
      _VSCale.Y += this.quitGameButton.GetSize_True().Y;
      _VSCale.Y += defaultBuffer.Y;
      _VSCale.X = this.scalehelper.ScaleX(300f);
      this.customerFrame = new CustomerFrame(_VSCale, CustomerFrameColors.Brown, BaseScale);
      Vector2 vector2 = -this.customerFrame.VSCale * 0.5f;
      this.quitGameButton.vLocation.Y += vector2.Y;
      this.sfxbutton.Location.Y += vector2.Y;
      this.musicbutton.Location.Y += vector2.Y;
      this.photo.location.Y += vector2.Y;
    }

    public Vector2 GetSize() => this.customerFrame.VSCale;

    public PauseScreenButton UpdatePauseFrame(
      Player player,
      float DeltaTime,
      Vector2 offset)
    {
      offset += this.location;
      if (this.quitGameButton.UpdateTextButton(player, offset, DeltaTime))
        return PauseScreenButton.Quit;
      this.sfxbutton.UpdateSoundButton(player, DeltaTime, offset);
      this.musicbutton.UpdateSoundButton(player, DeltaTime, offset);
      return this.photo.UpdatePhotoModeRow(player, DeltaTime, offset) ? PauseScreenButton.Camera : PauseScreenButton.Count;
    }

    public void DrawPauseFrame(Vector2 offset, SpriteBatch spriteBatch)
    {
      offset += this.location;
      this.customerFrame.DrawCustomerFrame(offset, spriteBatch);
      this.quitGameButton.DrawTextButton(offset, 1f, spriteBatch);
      this.sfxbutton.DrawSoundButton(offset);
      this.musicbutton.DrawSoundButton(offset);
      this.photo.DrawPhotoModeRow(offset, spriteBatch);
    }
  }
}
