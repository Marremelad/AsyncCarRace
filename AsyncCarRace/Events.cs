namespace AsyncCarRace;

public static class Events
{
    private static readonly object LockEvent = new object();
    public static void RandomEvent(Car car)
    {
        int randomEvent = new Random().Next(1, 101);

        if (randomEvent is > 0 and < 11)
        {
            Console.WriteLine("Random event 1");
            car.Speed = 100;

        }
        else if (randomEvent is > 10 and < 101)
        {
            Console.WriteLine("Random event 2");
            car.Speed = 200;
        }
    }
}