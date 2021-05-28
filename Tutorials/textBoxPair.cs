// Decompiled with JetBrains decompiler
// Type: TinyZoo.Tutorials.textBoxPair
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using TinyZoo.GamePlay.Enemies;
using TinyZoo.GenericUI;

namespace TinyZoo.Tutorials
{
  internal class textBoxPair
  {
    public string Text;
    public AnimalType talkingguy;
    public float OverrideY = -1f;
    public TinyTextAndButton tinytext;

    public textBoxPair(string _Text, AnimalType _talkingguy, float _OverrideY = -1f, bool SetToBottom = false)
    {
      this.OverrideY = _OverrideY;
      this.Text = _Text;
      this.talkingguy = _talkingguy;
      if (!SetToBottom)
        return;
      this.OverrideY = 688f;
    }

    public void AddControllerButtonToLasttextBoxPair(TinyTextAndButton _tinytext) => this.tinytext = _tinytext;
  }
}
