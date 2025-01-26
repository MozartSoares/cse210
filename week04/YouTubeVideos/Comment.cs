using System.Runtime.CompilerServices;

class Comment( string text,string author)
{
  private string _text = text;
  private string _author = author;

  public string GetFullComment()
  {
    return _author + ": " + _text;
  }
}