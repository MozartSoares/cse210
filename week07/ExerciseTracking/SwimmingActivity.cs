public class SwimmingActivity : BaseActivity
{
    private int _laps;

    public SwimmingActivity(DateOnly date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50 / 1000.0) * 0.621371;

    public override double GetSpeed() => (GetDistance() / Length) * 60;
    public override double GetPace() => Length / GetDistance();
}