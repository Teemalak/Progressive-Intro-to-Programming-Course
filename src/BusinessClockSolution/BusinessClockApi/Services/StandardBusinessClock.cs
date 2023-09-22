namespace BusinessClockApi.Services;

public class StandardBusinessClock : IProvideTheBusinessClock

{

    private readonly ISystemTime _theClock;

    public StandardBusinessClock(ISystemTime theClock)
    {
        _theClock = theClock;
    }

    public ClockResponse GetClock()
    {
        var now = _theClock.GetCurrent();
        var dayOfTheWeek = now.DayOfWeek;

        var hour = now.Hour;

        var openingTime = new TimeSpan(9, 0, 0);
        var closingTime = new TimeSpan(17, 0, 0);

        var isOpen = dayOfTheWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => hour >= openingTime.Hours && hour < closingTime.Hours,
        };


        if (isOpen)
        {
            return new ClockResponse(true, null);
        }

        var nextOpen = now;

        if (now.Hour > 16 && now.DayOfWeek == DayOfWeek.Friday) nextOpen = now.AddDays(3);
        else if (now.DayOfWeek == DayOfWeek.Saturday) nextOpen = now.AddDays(2);
        else if (now.Hour > 16 || now.DayOfWeek == DayOfWeek.Sunday) nextOpen = now.AddDays(1);

        nextOpen = nextOpen.Date.Add(openingTime);

        return new ClockResponse(false, nextOpen);
    }
}
