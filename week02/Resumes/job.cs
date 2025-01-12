using System;

namespace Resumes
{
  public class Job
  {
    public string _title;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
      Console.WriteLine($"{_title} ({_company}) {_startYear}-{_endYear}");
    }
  }
}