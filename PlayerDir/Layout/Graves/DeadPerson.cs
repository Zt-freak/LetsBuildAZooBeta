// Decompiled with JetBrains decompiler
// Type: TinyZoo.PlayerDir.Layout.Graves.DeadPerson
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine;
using TinyZoo.PlayerDir.IntakeStuff;

namespace TinyZoo.PlayerDir.Layout.Graves
{
  internal class DeadPerson
  {
    public Vector2Int GraveLocation;
    public IntakePerson intakeperson;

    public DeadPerson(Vector2Int _Location, IntakePerson _person)
    {
      this.GraveLocation = _Location;
      this.intakeperson = _person;
    }

    public void SaveDeadPerson(Writer writer)
    {
      this.GraveLocation.SaveVector2Int(writer);
      this.intakeperson.SaveIntakePerson(writer);
    }

    public DeadPerson(Reader reader)
    {
      this.GraveLocation = new Vector2Int(reader);
      this.intakeperson = new IntakePerson(reader);
    }
  }
}
