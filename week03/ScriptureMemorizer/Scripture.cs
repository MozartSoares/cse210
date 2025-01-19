class Scripture {
  private Reference _reference;
  private List<Word> _words;

  private int _HiddenWordsCount = 0;

  public Scripture(Reference reference, List<Word> words) {
    _reference = reference;
    _words = words;
    }

  public void DisplayText() {
    string DisplayText = $"{_reference.GetWholeReference()}: \n"; 
    foreach (Word word in _words) {
      DisplayText += word.GetText() + " ";
    }
    Console.WriteLine(DisplayText);
  }

  public void HideRandomWords(int WordsToHideCount) {
    Random random = new();
    for (int i = 0; i < WordsToHideCount; i++) 
    {
      int randomNumber = random.Next(0, _words.Count);
      Word word = _words[randomNumber];
      if(word.IsHidden()) {
        i--;
      } else {
        HideWord(randomNumber);
      }
    }
  }

  private void HideWord(int index) {
    _words[index].Hide();
    _HiddenWordsCount++;
  }

  public bool GetIsCompletelyHidden() {
    return _HiddenWordsCount == _words.Count;
  }

  public void Reset() {
    foreach (Word word in _words) {
      word.Show();
    }
    _HiddenWordsCount = 0;
  }

  public int GetRemainingWordsCount() {
    return _words.Count - _HiddenWordsCount;
  }
}

