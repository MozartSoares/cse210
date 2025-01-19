using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
class ScriptureLibrary {
    private readonly List<Scripture> _scriptures;
    private HttpClient _api;

    public ScriptureLibrary() {
        _scriptures = new List<Scripture>();
    }

    public async Task FetchRandomScriptureAsync() {
        _api = new HttpClient();
        string url = "https://bible-api.com/data/web/random";
        
        try {
            string json = await _api.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(json);
            RandomResponse response = JsonSerializer.Deserialize<RandomResponse>(doc.RootElement.GetRawText());
            List<Word> words = ParseTextIntoWords(response.RandomVerse.Text);
            string book = response.RandomVerse.Book;
            int chapter = response.RandomVerse.Chapter;
            int verse = response.RandomVerse.Verse;
            Reference newReference = new Reference(book, chapter, verse);
            CreateScripture(newReference, words);
        } catch (HttpRequestException e) {
            throw new Exception($"An error ocurred: The scripture could not be found, please try again.");
        }
    }
    public async Task FetchScriptureByReferenceAsync(Reference reference) {
        _api = new HttpClient();
        string url = $"https://bible-api.com/{reference.GetWholeReference(true)}";
        
        try {
            string json = await _api.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(json);
            NormalResponse response = JsonSerializer.Deserialize<NormalResponse>(doc.RootElement.GetRawText());
            List<Word> words = ParseTextIntoWords(response.Text);
            CreateScripture(reference, words);
        } catch (HttpRequestException e) {
            throw new Exception($"An error ocurred: The scripture could not be found, please try with another one.");
        }
    }

    private List<Word> ParseTextIntoWords(string text) {
        string[] rawWords = text.Split(' ');	
        List<Word> wordsList = new List<Word>();
        foreach (string word in rawWords) {
            if (word != "\n") {
                wordsList.Add(new Word(word));
            }
        }
        return wordsList;
    }

    private void CreateScripture(Reference reference, List<Word> words) {
        Scripture scripture = new Scripture(reference, words);
        _scriptures.Add(scripture);
    }

    public Scripture GetScripture(int index) {
        return _scriptures[index];
    }
    public Scripture GetLastScripture() {
        Scripture lastScripture = _scriptures[_scriptures.Count - 1];
        return lastScripture;
    }

    public void DisplayAllScriptures() {
        foreach (Scripture scripture in _scriptures) {
            scripture.DisplayText();
        }
    }
}


public class NormalResponse {
    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public class RandomResponse {
    [JsonPropertyName("random_verse")]
    public RandomVerse RandomVerse { get; set; }
}

public class RandomVerse {
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("book")]
    public string Book { get; set; }

    [JsonPropertyName("chapter")]
    public int Chapter { get; set; }

    [JsonPropertyName("verse")]
    public int Verse { get; set; }
}
