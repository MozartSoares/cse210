class Video {
  private string _title;
  private string _author;
  private string _length;
  private List<Comment> _comments;

  public Video(string title, string author, string length) {
    _title = title;
    _author = author;
    _length = length;
    _comments = new List<Comment>();
  }
  public int GetCommentsLength() {
    return _comments.Count;
  }

  public List<Comment> GetComments() {
    return [.. _comments];
  }

  public void AddComment(Comment comment) {
    _comments.Add(comment);
  }

  public void DisplayVideoInfo() {
    Console.WriteLine("Title: " + _title);
    Console.WriteLine("Author: " + _author);
    Console.WriteLine("Length: " + _length);
    Console.WriteLine("Number of comments: " + GetCommentsLength());
    foreach (var comment in GetComments()) {
      Console.WriteLine(comment.GetFullComment());
    }
  }
}