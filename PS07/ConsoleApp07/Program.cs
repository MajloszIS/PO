using System;

public class Clock
{
    protected int hour;
    protected int minute;

    public Clock(int hour, int minute)
    {
        this.hour = hour;
        this.minute = minute;
    }

    public int Tick()
    {
        minute++;
    }

    public void DisplayTime()
    {
        Console.WriteLine($"{this.hour}:{this.minute}");
    }
}

public class FastClock extends Clock
{
    Fastclock()
}