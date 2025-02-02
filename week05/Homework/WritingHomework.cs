public class WritingHomework : Homework
{
    private string _title;

    public WritingHomework(string studentName, string subject, string title)
        : base(studentName, subject)
    {
        _title = title;
    }

    public string GetWritingInfo()
    {
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}