// Decompiled with JetBrains decompiler
// Type: TinyZoo.OverWorld.Store_Local.Entries.EntryManager
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SEngine.Buttons;
using TinyZoo.Audio;

namespace TinyZoo.OverWorld.Store_Local.Entries
{
  internal class EntryManager
  {
    private StoreEntry[] entries;
    private ButtonRepeater repeater;
    public int Selected;

    public EntryManager()
    {
      this.repeater = new ButtonRepeater();
      this.entries = new StoreEntry[2];
      for (int index = 0; index < this.entries.Length; ++index)
      {
        this.entries[index] = new StoreEntry((StoreEntryType) index);
        this.entries[index].Location = new Vector2(180f, (float) (460 + index * 150));
      }
    }

    public bool UpdateEntryManager(float DeltaTime, Vector2 Offset, Player player)
    {
      bool flag = false;
      DirectionPressed Direction;
      if (this.repeater.UpdateMenuRepeats(DeltaTime, out Direction, player.inputmap.HeldButtons[16], player.inputmap.HeldButtons[17], false, false))
      {
        switch (Direction)
        {
          case DirectionPressed.Up:
            if (this.Selected > 0)
            {
              --this.Selected;
              flag = true;
              break;
            }
            break;
          case DirectionPressed.Down:
            if (this.Selected < this.entries.Length - 1)
            {
              ++this.Selected;
              flag = true;
              break;
            }
            break;
        }
      }
      for (int index = 0; index < this.entries.Length; ++index)
      {
        if (this.entries[index].UpdateStoreEntry(player, Offset) && index != this.Selected)
        {
          this.Selected = index;
          flag = true;
        }
      }
      if (flag)
        SoundEffectsManager.PlaySpecificSound(SoundEffectType.ClickSingle, Pitch: 0.4f);
      return flag;
    }

    public void DraEntryManager(Vector2 Offset, SpriteBatch DrawWithThis)
    {
      for (int index = 0; index < this.entries.Length; ++index)
        this.entries[index].DrawStoreEntry(Offset, this.Selected == index, DrawWithThis);
    }
  }
}
