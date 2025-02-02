public class MathHomework : Homework
{
    private string _section;
    private string _questions;

    public MathHomework(string studentName, string subject, string section, string questions)
        : base(studentName, subject)
    {
        _section = section;
        _questions = questions;
    }

    public string GetHomeworkList()
    {
        return $"Section {_section} questions {_questions}";
    }
}