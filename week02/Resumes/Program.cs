using System;
using Resumes;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new()
        {
            _title = "Software developer",
            _company = "Microsoft",
            _endYear = 2024,
            _startYear = 2015
        };

        Job job2 = new()
        {
            _title = "CEO",
            _company = "Meta",
            _startYear = 1998,
            _endYear = 2025
        };

        Resume myResume = new()
        {
            _name = "Allison Rose"
        };

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}