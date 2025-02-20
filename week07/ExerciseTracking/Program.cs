using System;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<BaseActivity>
        {
            new RunningActivity(new DateOnly(2022, 11, 3), 30, 3.0),
            new CyclingActivity(new DateOnly(2022, 11, 3), 30, 15.0),
            new SwimmingActivity(new DateOnly(2022, 11, 3), 30, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}