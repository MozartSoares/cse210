using System.Text.Json.Serialization;

class User {
  public string Name { get; private set; }

  public User(string name) {
    Name = name;
  }
    public User() { }  

    [JsonConstructor]
    public User(string name, int level, int currentXp)
    {
        Initialize(name, level, currentXp);
    }

    private void Initialize(string name, int level, int currentXp)
    {
        Name = name;
        Level = level;
        CurrentXp = currentXp;
    }
    public int Level { get; private set; } = 1;
    public int CurrentXp { get; private set; } = 0;

    private const int BaseXp = 100;
    private const double Multiplier = 1.2;

    public int GetXpRequiredForNextLevel() 
    {
        return (int)(BaseXp * Math.Pow(Multiplier, Level - 1));
    }

    public void AddXp(int Xp)
    {
        CurrentXp += Xp;
        while (CurrentXp >= GetXpRequiredForNextLevel())
        {
            CurrentXp -= GetXpRequiredForNextLevel();
            Level++;
            InformLevelUp();
        }
    }

    public void ShowCurrentXp()
    {
        Console.WriteLine($"Xp: {CurrentXp}/{GetXpRequiredForNextLevel()}");
    } 

    public void ShowStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        ShowCurrentXp();
    }

    private void InformLevelUp() 
    {
        Console.WriteLine($"Congrats {Name}, you leveled up to level {Level}!");
    }

    public object ToJson()
    {
        return new {
            name = Name,
            level = Level,
            currentXp = CurrentXp
        };
    }
}