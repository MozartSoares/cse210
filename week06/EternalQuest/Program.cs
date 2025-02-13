using System;

class Program
{
    private static readonly string _baseFileUrl = "goals.json";
    static void Main(string[] args)
    {
        var goalManager = new GoalManager(_baseFileUrl); 
        goalManager.ManageFile(FileAction.Load);
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
    }
}