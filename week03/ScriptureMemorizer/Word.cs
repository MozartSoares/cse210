class Word {
  private string _text;
  private bool isHidden = false;

  public Word(string text) {
    _text = text;
  }

  public void Hide() {
    isHidden = true;
  }
  public void Show() {
    isHidden = false;
  }
  public bool IsHidden() {
    return isHidden;
  }

  public string GetText() {
    if (isHidden) {
      return new string('_', _text.Length);
    }
    return _text;
  }
}