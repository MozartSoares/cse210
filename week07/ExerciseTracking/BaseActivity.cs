public abstract class BaseActivity {
    private DateOnly _date;
    private int _length;

    //these are read-only properties so they can be public
    public DateOnly Date => _date;
    public int Length => _length;

    public BaseActivity(DateOnly date, int length)
    {
        _date = date;
        _length = length;
    }
    
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name.Replace("Activity", "")} ({Length} min): " +
            $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min/mile";
    }
}