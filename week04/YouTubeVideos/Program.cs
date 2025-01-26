using System;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var video1 = new Video("Exploring the Mountains", "Alice Johnson", "12:45");
        video1.AddComment(new Comment("Breathtaking views!", "John Doe"));
        video1.AddComment(new Comment("I want to visit this place someday!", "Emily Rose"));
        video1.AddComment(new Comment("Great camera work!", "Michael Smith"));

        var video2 = new Video("Top 10 Coding Tips", "David Brown", "15:30");
        video2.AddComment(new Comment("Tip #3 was a game changer!", "Sophia Lee"));
        video2.AddComment(new Comment("Very helpful for beginners, thanks!", "James Carter"));
        video2.AddComment(new Comment("More videos like this, please!", "Emma Wilson"));

        var video3 = new Video("The Art of Baking Bread", "Laura White", "25:20");
        video3.AddComment(new Comment("This was so easy to follow!", "Liam Johnson"));
        video3.AddComment(new Comment("My bread turned out perfect!", "Olivia Brown"));
        video3.AddComment(new Comment("What temperature should I use for whole wheat bread?", "Noah Miller"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}