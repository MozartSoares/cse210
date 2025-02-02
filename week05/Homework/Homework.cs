public class Homework
{
    private string _studentName;
    private string _subject;

    public Homework(string studentName, string subject)
    {
        _studentName = studentName;
        _subject = subject;
    }
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetSubject()
    {
        return _subject;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _subject;
    }
}