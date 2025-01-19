using System.Formats.Asn1;
using System.Text.RegularExpressions;

class Reference {
  private string _book;
  private int _chapter;
  private int _verse;
  private int _endVerse;

  public Reference(string book, int chapter, int verse) {
    _book = book;
    _chapter = chapter;
    _verse = verse;
    _endVerse = verse;
  }
  public Reference(string book, int chapter, int verse, int endVerse) {
    _book = book;
    _chapter = chapter;
    _verse = verse;
    _endVerse = endVerse;
  }
  public string GetWholeReference(bool AsUrlReady = false) {
    string wholeReference = $"{_book} {_chapter}:{_verse}";
    if (_endVerse != _verse) {
      wholeReference += $"-{_endVerse}";
    }
    if(AsUrlReady) {
      wholeReference = wholeReference.Replace(" ", "+");
    }
    return wholeReference;
  }
}