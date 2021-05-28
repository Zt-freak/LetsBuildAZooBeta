// Decompiled with JetBrains decompiler
// Type: TinyZoo.Utils.LanguageInformation
// Assembly: LetsBuildAZoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 015417EB-E6EF-4563-9388-74E46AE254CA
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Let's Build a Zoo Beta\LetsBuildAZoo.exe

using SEngine.Localization;
using System.Collections.Generic;

namespace TinyZoo.Utils
{
  internal class LanguageInformation
  {
    private static List<Language> languages;

    internal static List<Language> GetSupportedLanguages()
    {
      if (LanguageInformation.languages == null)
      {
        LanguageInformation.languages = new List<Language>();
        LanguageInformation.languages.Add(Language.English);
        LanguageInformation.languages.Add(Language.Japanese);
        LanguageInformation.languages.Add(Language.French);
        LanguageInformation.languages.Add(Language.Chinese_Simplified);
        LanguageInformation.languages.Add(Language.Chinese_Traditional);
        LanguageInformation.languages.Add(Language.Russian);
        LanguageInformation.languages.Add(Language.Korean);
        LanguageInformation.languages.Add(Language.German);
        LanguageInformation.languages.Add(Language.Spanish);
        LanguageInformation.languages.Add(Language.Portuguese);
      }
      return LanguageInformation.languages;
    }
  }
}
